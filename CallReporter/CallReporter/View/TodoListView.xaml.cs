﻿using GalaSoft.MvvmLight.Messaging;
using CallReporter.Messages;
using CallReporter.Model;
using CallReporter.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using CallReporter.Utils;
using Plugin.Connectivity;
using System.Net.Http;

#if __IOS__
#elif __ANDROID__
using CallReporter.Droid;
#elif WINDOWS_PHONE_APP || WINDOWS_APP || XBOX
#endif

namespace CallReporter.View
{
#if !OnlineOnly
    public partial class TodoListView : ContentPage
#endif
#if OnlineOnly
    public partial class TodoListView : ContentPage
#endif
    {
        public TodoListView()
        {
            InitializeComponent();

            // Set conflict resolver that knows how to resolve sychronization conflicts
            Locator.Instance.ConflictResolver = Resolve;
            Messenger.Default.Register<ShowMessageDialog>(this, new Action<ShowMessageDialog>(DisplayMessageDialog));
            Messenger.Default.Register<PersistanceException>(this, new Action<PersistanceException>(ReportPersistanceException));
            Messenger.Default.Register<ResetUI>(this, new Action<ResetUI>(ResetUI));
            Messenger.Default.Register<InitializePage>(this, new Action<InitializePage>(InitializePage));

            ResetUI(null);
        }

        async public Task<ResolverResponse> Resolve(object server, object local)
        {
            const string keepLocal = "Keep your changes";
            const string keepServer = "Keep their changes";
            const string cancel = "Cancel";
            string answer = null;

            ResolverResponse result = new ResolverResponse();

            answer = await DisplayActionSheet("Someone else has updated this same record so you will have to decide which changes you want to keep.\n\nYour Changes:\n" + local + "\n\nTheir Changes:\n" + server, cancel, null, keepLocal, keepServer);

            if (answer == keepLocal)
                result = ResolverResponse.LocalVersion;
            else if (answer == keepServer)
                result = ResolverResponse.ServerVersion;
            else
                result = ResolverResponse.Cancel;

            return result;
        }

        async protected override void OnAppearing()
        {
            base.OnAppearing();

//            BindingContext = Locator.Instance;

            if (!Locator.Instance.IsLoginNeeded)
                await InitializePage();
        }

        private async Task InitializePage()
        {
            try
            {
                Locator.Instance.IsBusy = true;

                if (App.Platform == "WINDOWS_APP" || App.Platform == "WINDOWS_UWP")
                    AddRightHandGutter(App.Platform);

                await Locator.Instance.GetTodoItems();

                // Need to reassign BindingContext now that we have list items 
                // because ListView binding does not fire for some reason
                BindingContext = null;
                BindingContext = Locator.Instance;

                if (ApplicationCapabilities.ModeOfOperation != ModeOfOperation.OfflineOnly)
                {
                    if (await Locator.Instance.IsMobileAppServiceReachable())
                    {
                        if (Locator.Instance.IsPushNotificationRequired &&
                            (!ApplicationCapabilities.IsAuthenticationRequired || Locator.Instance.IsAuthenticated))
                            await Locator.Instance.Notifier.InitializeNotificationsAsync();

                        // Now that offline data have been fetched and bound, attempt to sync data with server.
                        // Note: Call to Locator.Instance.SyncChanges() after you call Locator.Instance.GetTodoItems()
                        // so page is fully active while sync executing asynchronously
                        if (Locator.Instance.IsSyncEnabled && await Locator.Instance.IsConnected())
                            await Locator.Instance.SyncChanges();
                    }
                    else
                    {
                        if (ApplicationCapabilities.ModeOfOperation == ModeOfOperation.OnlineAndOffline)
                            DisplayMessageDialog(new ShowMessageDialog() { Title = "Be Aware", Message = "Could not connect to the app service so the application will run in offline mode." });
                    }
                }
            }
            catch (Exception e)
            {
                if (ApplicationCapabilities.ModeOfOperation == ModeOfOperation.OnlineOnly)
                {
                    DisplayMessageDialog(new ShowMessageDialog() { Title = "Connectivity Error", Message = "Could not connect to app service and ModeOfOperation is set to OnlineOnly so you will need to try again when network connectivity has been restored" });
                }
            }
            finally
            {
                Locator.Instance.IsBusy = false;
            }
        }

        void AddRightHandGutter(string platform)
        {
            double gutter = (platform == "WINDOWS_APP" ? 12 : 8);

            OuterGrid.ColumnDefinitions = new ColumnDefinitionCollection
            {
                new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                new ColumnDefinition { Width = new GridLength(gutter, GridUnitType.Absolute) }
            };

            OuterGrid.Children.Add(new ContentView
            {
                BackgroundColor = Color.White
            }, 1, 2);
        }

        async void DisplayMessageDialog(ShowMessageDialog message)
        {
            await DisplayAlert(message.Title, message.Message, message.OkLabel == null ? "Ok" : message.OkLabel);

            if (message.Title.ToLower().Contains("error"))
                ContentHost.IsEnabled = false;
        }

        async void ReportPersistanceException(PersistanceException exception)
        {
            // ToDo: Add code to handle Mobile App persistance exceptions and then have catch all for everything else
            await DisplayAlert("Persistence Error", exception.Exception.Message, "OK");
        }

        void ResetUI(ResetUI unused)
        {
            // Reset ViewModel which does 2 things:
            // 1) Clears any previous ModelView values
            // 2) Causes all dependent data bindings to rebind
            Locator.Instance.TodoListViewModel = null;

            newItemName.Unfocus();
        }

        async void InitializePage(InitializePage unused)
        {
            await InitializePage();
        }

        // Event handlers
        public void OnCompleted(object sender, SelectedItemChangedEventArgs e)
        {
            // ListView has some strange behavior where the ItemSelected event fires twice when an item 
            // is selected so I had to add this workaround to ignore that second event
            if ((e.SelectedItem as TodoItemViewModel).Done)
                return;

            // ToDo: When, if ever, EventToCommand becomes available in MVVM Light for Xamarin.Forms
            // get rid of this event handler and switch to EventToCommand in XAML markup
            Locator.Instance.TodoListViewModel.CompleteCommand.Execute(e.SelectedItem);
        }

        public void OnAdd(object sender, EventArgs e)
        {
            // ToDo: When, if ever, EventToCommand becomes available in MVVM Light for Xamarin.Forms
            // get rid of this event handler and switch to EventToCommand in XAML markup
            Locator.Instance.TodoListViewModel.AddCommand.Execute(null);
        }

        // http://developer.xamarin.com/guides/cross-platform/xamarin-forms/working-with/listview/#pulltorefresh
        public void OnRefresh(object sender, EventArgs e)
        {
            Locator.Instance.TodoListViewModel.SyncCommand.Execute(null);
        }

        async void OnLoginTapped(object sender, EventArgs args)
        {
            if (!Locator.Instance.IsAuthenticated)
            {
                // Shows the login dialog
                Locator.Instance.IsLoginRequested = true;
            }
            else
            {
                await Locator.Instance.Logout();
            }
        }
    }
}
