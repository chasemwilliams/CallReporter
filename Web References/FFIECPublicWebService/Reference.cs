﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.42000.
// 
#pragma warning disable 1591

namespace CallReporter.FFIECPublicWebService {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="RetrievalServiceSoap", Namespace="http://cdr.ffiec.gov/public/services")]
    public partial class RetrievalService : Microsoft.Web.Services2.WebServicesClientProtocol {
        
        private System.Threading.SendOrPostCallback TestUserAccessOperationCompleted;
        
        private System.Threading.SendOrPostCallback RetrieveReportingPeriodsOperationCompleted;
        
        private System.Threading.SendOrPostCallback RetrievePanelOfReportersOperationCompleted;
        
        private System.Threading.SendOrPostCallback RetrieveFilersSubmissionDateTimeOperationCompleted;
        
        private System.Threading.SendOrPostCallback RetrieveFilersSinceDateOperationCompleted;
        
        private System.Threading.SendOrPostCallback RetrieveFacsimileOperationCompleted;
        
        private System.Threading.SendOrPostCallback RetrieveUBPRReportingPeriodsOperationCompleted;
        
        private System.Threading.SendOrPostCallback RetrieveUBPRXBRLFacsimileOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public RetrievalService() {
            this.Url = global::CallReporter.Properties.Settings.Default.CallReporter_FFIECPublicWebService_RetrievalService;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event TestUserAccessCompletedEventHandler TestUserAccessCompleted;
        
        /// <remarks/>
        public event RetrieveReportingPeriodsCompletedEventHandler RetrieveReportingPeriodsCompleted;
        
        /// <remarks/>
        public event RetrievePanelOfReportersCompletedEventHandler RetrievePanelOfReportersCompleted;
        
        /// <remarks/>
        public event RetrieveFilersSubmissionDateTimeCompletedEventHandler RetrieveFilersSubmissionDateTimeCompleted;
        
        /// <remarks/>
        public event RetrieveFilersSinceDateCompletedEventHandler RetrieveFilersSinceDateCompleted;
        
        /// <remarks/>
        public event RetrieveFacsimileCompletedEventHandler RetrieveFacsimileCompleted;
        
        /// <remarks/>
        public event RetrieveUBPRReportingPeriodsCompletedEventHandler RetrieveUBPRReportingPeriodsCompleted;
        
        /// <remarks/>
        public event RetrieveUBPRXBRLFacsimileCompletedEventHandler RetrieveUBPRXBRLFacsimileCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://cdr.ffiec.gov/public/services/TestUserAccess", RequestNamespace="http://cdr.ffiec.gov/public/services", ResponseNamespace="http://cdr.ffiec.gov/public/services", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool TestUserAccess() {
            object[] results = this.Invoke("TestUserAccess", new object[0]);
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void TestUserAccessAsync() {
            this.TestUserAccessAsync(null);
        }
        
        /// <remarks/>
        public void TestUserAccessAsync(object userState) {
            if ((this.TestUserAccessOperationCompleted == null)) {
                this.TestUserAccessOperationCompleted = new System.Threading.SendOrPostCallback(this.OnTestUserAccessOperationCompleted);
            }
            this.InvokeAsync("TestUserAccess", new object[0], this.TestUserAccessOperationCompleted, userState);
        }
        
        private void OnTestUserAccessOperationCompleted(object arg) {
            if ((this.TestUserAccessCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.TestUserAccessCompleted(this, new TestUserAccessCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://cdr.ffiec.gov/public/services/RetrieveReportingPeriods", RequestNamespace="http://cdr.ffiec.gov/public/services", ResponseNamespace="http://cdr.ffiec.gov/public/services", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string[] RetrieveReportingPeriods(ReportingDataSeriesName dataSeries) {
            object[] results = this.Invoke("RetrieveReportingPeriods", new object[] {
                        dataSeries});
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        public void RetrieveReportingPeriodsAsync(ReportingDataSeriesName dataSeries) {
            this.RetrieveReportingPeriodsAsync(dataSeries, null);
        }
        
        /// <remarks/>
        public void RetrieveReportingPeriodsAsync(ReportingDataSeriesName dataSeries, object userState) {
            if ((this.RetrieveReportingPeriodsOperationCompleted == null)) {
                this.RetrieveReportingPeriodsOperationCompleted = new System.Threading.SendOrPostCallback(this.OnRetrieveReportingPeriodsOperationCompleted);
            }
            this.InvokeAsync("RetrieveReportingPeriods", new object[] {
                        dataSeries}, this.RetrieveReportingPeriodsOperationCompleted, userState);
        }
        
        private void OnRetrieveReportingPeriodsOperationCompleted(object arg) {
            if ((this.RetrieveReportingPeriodsCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.RetrieveReportingPeriodsCompleted(this, new RetrieveReportingPeriodsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://cdr.ffiec.gov/public/services/RetrievePanelOfReporters", RequestNamespace="http://cdr.ffiec.gov/public/services", ResponseNamespace="http://cdr.ffiec.gov/public/services", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlArrayItemAttribute(IsNullable=false)]
        public ReportingFinancialInstitution[] RetrievePanelOfReporters(ReportingDataSeriesName dataSeries, string reportingPeriodEndDate) {
            object[] results = this.Invoke("RetrievePanelOfReporters", new object[] {
                        dataSeries,
                        reportingPeriodEndDate});
            return ((ReportingFinancialInstitution[])(results[0]));
        }
        
        /// <remarks/>
        public void RetrievePanelOfReportersAsync(ReportingDataSeriesName dataSeries, string reportingPeriodEndDate) {
            this.RetrievePanelOfReportersAsync(dataSeries, reportingPeriodEndDate, null);
        }
        
        /// <remarks/>
        public void RetrievePanelOfReportersAsync(ReportingDataSeriesName dataSeries, string reportingPeriodEndDate, object userState) {
            if ((this.RetrievePanelOfReportersOperationCompleted == null)) {
                this.RetrievePanelOfReportersOperationCompleted = new System.Threading.SendOrPostCallback(this.OnRetrievePanelOfReportersOperationCompleted);
            }
            this.InvokeAsync("RetrievePanelOfReporters", new object[] {
                        dataSeries,
                        reportingPeriodEndDate}, this.RetrievePanelOfReportersOperationCompleted, userState);
        }
        
        private void OnRetrievePanelOfReportersOperationCompleted(object arg) {
            if ((this.RetrievePanelOfReportersCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.RetrievePanelOfReportersCompleted(this, new RetrievePanelOfReportersCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://cdr.ffiec.gov/public/services/RetrieveFilersSubmissionDateTime", RequestNamespace="http://cdr.ffiec.gov/public/services", ResponseNamespace="http://cdr.ffiec.gov/public/services", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlArrayItemAttribute(IsNullable=false)]
        public RetrieveFilersDateTime[] RetrieveFilersSubmissionDateTime(ReportingDataSeriesName dataSeries, string reportingPeriodEndDate, string lastUpdateDateTime) {
            object[] results = this.Invoke("RetrieveFilersSubmissionDateTime", new object[] {
                        dataSeries,
                        reportingPeriodEndDate,
                        lastUpdateDateTime});
            return ((RetrieveFilersDateTime[])(results[0]));
        }
        
        /// <remarks/>
        public void RetrieveFilersSubmissionDateTimeAsync(ReportingDataSeriesName dataSeries, string reportingPeriodEndDate, string lastUpdateDateTime) {
            this.RetrieveFilersSubmissionDateTimeAsync(dataSeries, reportingPeriodEndDate, lastUpdateDateTime, null);
        }
        
        /// <remarks/>
        public void RetrieveFilersSubmissionDateTimeAsync(ReportingDataSeriesName dataSeries, string reportingPeriodEndDate, string lastUpdateDateTime, object userState) {
            if ((this.RetrieveFilersSubmissionDateTimeOperationCompleted == null)) {
                this.RetrieveFilersSubmissionDateTimeOperationCompleted = new System.Threading.SendOrPostCallback(this.OnRetrieveFilersSubmissionDateTimeOperationCompleted);
            }
            this.InvokeAsync("RetrieveFilersSubmissionDateTime", new object[] {
                        dataSeries,
                        reportingPeriodEndDate,
                        lastUpdateDateTime}, this.RetrieveFilersSubmissionDateTimeOperationCompleted, userState);
        }
        
        private void OnRetrieveFilersSubmissionDateTimeOperationCompleted(object arg) {
            if ((this.RetrieveFilersSubmissionDateTimeCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.RetrieveFilersSubmissionDateTimeCompleted(this, new RetrieveFilersSubmissionDateTimeCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://cdr.ffiec.gov/public/services/RetrieveFilersSinceDate", RequestNamespace="http://cdr.ffiec.gov/public/services", ResponseNamespace="http://cdr.ffiec.gov/public/services", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public int[] RetrieveFilersSinceDate(ReportingDataSeriesName dataSeries, string reportingPeriodEndDate, string lastUpdateDateTime) {
            object[] results = this.Invoke("RetrieveFilersSinceDate", new object[] {
                        dataSeries,
                        reportingPeriodEndDate,
                        lastUpdateDateTime});
            return ((int[])(results[0]));
        }
        
        /// <remarks/>
        public void RetrieveFilersSinceDateAsync(ReportingDataSeriesName dataSeries, string reportingPeriodEndDate, string lastUpdateDateTime) {
            this.RetrieveFilersSinceDateAsync(dataSeries, reportingPeriodEndDate, lastUpdateDateTime, null);
        }
        
        /// <remarks/>
        public void RetrieveFilersSinceDateAsync(ReportingDataSeriesName dataSeries, string reportingPeriodEndDate, string lastUpdateDateTime, object userState) {
            if ((this.RetrieveFilersSinceDateOperationCompleted == null)) {
                this.RetrieveFilersSinceDateOperationCompleted = new System.Threading.SendOrPostCallback(this.OnRetrieveFilersSinceDateOperationCompleted);
            }
            this.InvokeAsync("RetrieveFilersSinceDate", new object[] {
                        dataSeries,
                        reportingPeriodEndDate,
                        lastUpdateDateTime}, this.RetrieveFilersSinceDateOperationCompleted, userState);
        }
        
        private void OnRetrieveFilersSinceDateOperationCompleted(object arg) {
            if ((this.RetrieveFilersSinceDateCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.RetrieveFilersSinceDateCompleted(this, new RetrieveFilersSinceDateCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://cdr.ffiec.gov/public/services/RetrieveFacsimile", RequestNamespace="http://cdr.ffiec.gov/public/services", ResponseNamespace="http://cdr.ffiec.gov/public/services", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute(DataType="base64Binary")]
        public byte[] RetrieveFacsimile(ReportingDataSeriesName dataSeries, string reportingPeriodEndDate, FinancialInstitutionIDType fiIDType, int fiID, FacsimileFormat facsimileFormat) {
            object[] results = this.Invoke("RetrieveFacsimile", new object[] {
                        dataSeries,
                        reportingPeriodEndDate,
                        fiIDType,
                        fiID,
                        facsimileFormat});
            return ((byte[])(results[0]));
        }
        
        /// <remarks/>
        public void RetrieveFacsimileAsync(ReportingDataSeriesName dataSeries, string reportingPeriodEndDate, FinancialInstitutionIDType fiIDType, int fiID, FacsimileFormat facsimileFormat) {
            this.RetrieveFacsimileAsync(dataSeries, reportingPeriodEndDate, fiIDType, fiID, facsimileFormat, null);
        }
        
        /// <remarks/>
        public void RetrieveFacsimileAsync(ReportingDataSeriesName dataSeries, string reportingPeriodEndDate, FinancialInstitutionIDType fiIDType, int fiID, FacsimileFormat facsimileFormat, object userState) {
            if ((this.RetrieveFacsimileOperationCompleted == null)) {
                this.RetrieveFacsimileOperationCompleted = new System.Threading.SendOrPostCallback(this.OnRetrieveFacsimileOperationCompleted);
            }
            this.InvokeAsync("RetrieveFacsimile", new object[] {
                        dataSeries,
                        reportingPeriodEndDate,
                        fiIDType,
                        fiID,
                        facsimileFormat}, this.RetrieveFacsimileOperationCompleted, userState);
        }
        
        private void OnRetrieveFacsimileOperationCompleted(object arg) {
            if ((this.RetrieveFacsimileCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.RetrieveFacsimileCompleted(this, new RetrieveFacsimileCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://cdr.ffiec.gov/public/services/RetrieveUBPRReportingPeriods", RequestNamespace="http://cdr.ffiec.gov/public/services", ResponseNamespace="http://cdr.ffiec.gov/public/services", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string[] RetrieveUBPRReportingPeriods() {
            object[] results = this.Invoke("RetrieveUBPRReportingPeriods", new object[0]);
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        public void RetrieveUBPRReportingPeriodsAsync() {
            this.RetrieveUBPRReportingPeriodsAsync(null);
        }
        
        /// <remarks/>
        public void RetrieveUBPRReportingPeriodsAsync(object userState) {
            if ((this.RetrieveUBPRReportingPeriodsOperationCompleted == null)) {
                this.RetrieveUBPRReportingPeriodsOperationCompleted = new System.Threading.SendOrPostCallback(this.OnRetrieveUBPRReportingPeriodsOperationCompleted);
            }
            this.InvokeAsync("RetrieveUBPRReportingPeriods", new object[0], this.RetrieveUBPRReportingPeriodsOperationCompleted, userState);
        }
        
        private void OnRetrieveUBPRReportingPeriodsOperationCompleted(object arg) {
            if ((this.RetrieveUBPRReportingPeriodsCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.RetrieveUBPRReportingPeriodsCompleted(this, new RetrieveUBPRReportingPeriodsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://cdr.ffiec.gov/public/services/RetrieveUBPRXBRLFacsimile", RequestNamespace="http://cdr.ffiec.gov/public/services", ResponseNamespace="http://cdr.ffiec.gov/public/services", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute(DataType="base64Binary")]
        public byte[] RetrieveUBPRXBRLFacsimile(string reportingPeriodEndDate, FinancialInstitutionIDType fiIDType, int fiID) {
            object[] results = this.Invoke("RetrieveUBPRXBRLFacsimile", new object[] {
                        reportingPeriodEndDate,
                        fiIDType,
                        fiID});
            return ((byte[])(results[0]));
        }
        
        /// <remarks/>
        public void RetrieveUBPRXBRLFacsimileAsync(string reportingPeriodEndDate, FinancialInstitutionIDType fiIDType, int fiID) {
            this.RetrieveUBPRXBRLFacsimileAsync(reportingPeriodEndDate, fiIDType, fiID, null);
        }
        
        /// <remarks/>
        public void RetrieveUBPRXBRLFacsimileAsync(string reportingPeriodEndDate, FinancialInstitutionIDType fiIDType, int fiID, object userState) {
            if ((this.RetrieveUBPRXBRLFacsimileOperationCompleted == null)) {
                this.RetrieveUBPRXBRLFacsimileOperationCompleted = new System.Threading.SendOrPostCallback(this.OnRetrieveUBPRXBRLFacsimileOperationCompleted);
            }
            this.InvokeAsync("RetrieveUBPRXBRLFacsimile", new object[] {
                        reportingPeriodEndDate,
                        fiIDType,
                        fiID}, this.RetrieveUBPRXBRLFacsimileOperationCompleted, userState);
        }
        
        private void OnRetrieveUBPRXBRLFacsimileOperationCompleted(object arg) {
            if ((this.RetrieveUBPRXBRLFacsimileCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.RetrieveUBPRXBRLFacsimileCompleted(this, new RetrieveUBPRXBRLFacsimileCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1586.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://cdr.ffiec.gov/public/services")]
    public enum ReportingDataSeriesName {
        
        /// <remarks/>
        Call,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1586.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://cdr.ffiec.gov/public/services")]
    public partial class ReportingFinancialInstitution {
        
        private int iD_RSSDField;
        
        private int fDICCertNumberField;
        
        private int oCCChartNumberField;
        
        private int oTSDockNumberField;
        
        private int primaryABARoutNumberField;
        
        private string nameField;
        
        private string stateField;
        
        private string cityField;
        
        private string addressField;
        
        private int zIPField;
        
        private string filingTypeField;
        
        private bool hasFiledForReportingPeriodField;
        
        /// <remarks/>
        public int ID_RSSD {
            get {
                return this.iD_RSSDField;
            }
            set {
                this.iD_RSSDField = value;
            }
        }
        
        /// <remarks/>
        public int FDICCertNumber {
            get {
                return this.fDICCertNumberField;
            }
            set {
                this.fDICCertNumberField = value;
            }
        }
        
        /// <remarks/>
        public int OCCChartNumber {
            get {
                return this.oCCChartNumberField;
            }
            set {
                this.oCCChartNumberField = value;
            }
        }
        
        /// <remarks/>
        public int OTSDockNumber {
            get {
                return this.oTSDockNumberField;
            }
            set {
                this.oTSDockNumberField = value;
            }
        }
        
        /// <remarks/>
        public int PrimaryABARoutNumber {
            get {
                return this.primaryABARoutNumberField;
            }
            set {
                this.primaryABARoutNumberField = value;
            }
        }
        
        /// <remarks/>
        public string Name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
        
        /// <remarks/>
        public string State {
            get {
                return this.stateField;
            }
            set {
                this.stateField = value;
            }
        }
        
        /// <remarks/>
        public string City {
            get {
                return this.cityField;
            }
            set {
                this.cityField = value;
            }
        }
        
        /// <remarks/>
        public string Address {
            get {
                return this.addressField;
            }
            set {
                this.addressField = value;
            }
        }
        
        /// <remarks/>
        public int ZIP {
            get {
                return this.zIPField;
            }
            set {
                this.zIPField = value;
            }
        }
        
        /// <remarks/>
        public string FilingType {
            get {
                return this.filingTypeField;
            }
            set {
                this.filingTypeField = value;
            }
        }
        
        /// <remarks/>
        public bool HasFiledForReportingPeriod {
            get {
                return this.hasFiledForReportingPeriodField;
            }
            set {
                this.hasFiledForReportingPeriodField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1586.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://cdr.ffiec.gov/public/services")]
    public partial class RetrieveFilersDateTime {
        
        private int iD_RSSDField;
        
        private string dateTimeField;
        
        /// <remarks/>
        public int ID_RSSD {
            get {
                return this.iD_RSSDField;
            }
            set {
                this.iD_RSSDField = value;
            }
        }
        
        /// <remarks/>
        public string DateTime {
            get {
                return this.dateTimeField;
            }
            set {
                this.dateTimeField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1586.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://cdr.ffiec.gov/public/services")]
    public enum FinancialInstitutionIDType {
        
        /// <remarks/>
        ID_RSSD,
        
        /// <remarks/>
        FDICCertNumber,
        
        /// <remarks/>
        OCCChartNumber,
        
        /// <remarks/>
        OTSDockNumber,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1586.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://cdr.ffiec.gov/public/services")]
    public enum FacsimileFormat {
        
        /// <remarks/>
        PDF,
        
        /// <remarks/>
        XBRL,
        
        /// <remarks/>
        SDF,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    public delegate void TestUserAccessCompletedEventHandler(object sender, TestUserAccessCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class TestUserAccessCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal TestUserAccessCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public bool Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    public delegate void RetrieveReportingPeriodsCompletedEventHandler(object sender, RetrieveReportingPeriodsCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class RetrieveReportingPeriodsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal RetrieveReportingPeriodsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    public delegate void RetrievePanelOfReportersCompletedEventHandler(object sender, RetrievePanelOfReportersCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class RetrievePanelOfReportersCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal RetrievePanelOfReportersCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public ReportingFinancialInstitution[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((ReportingFinancialInstitution[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    public delegate void RetrieveFilersSubmissionDateTimeCompletedEventHandler(object sender, RetrieveFilersSubmissionDateTimeCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class RetrieveFilersSubmissionDateTimeCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal RetrieveFilersSubmissionDateTimeCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public RetrieveFilersDateTime[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((RetrieveFilersDateTime[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    public delegate void RetrieveFilersSinceDateCompletedEventHandler(object sender, RetrieveFilersSinceDateCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class RetrieveFilersSinceDateCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal RetrieveFilersSinceDateCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public int[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((int[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    public delegate void RetrieveFacsimileCompletedEventHandler(object sender, RetrieveFacsimileCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class RetrieveFacsimileCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal RetrieveFacsimileCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public byte[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((byte[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    public delegate void RetrieveUBPRReportingPeriodsCompletedEventHandler(object sender, RetrieveUBPRReportingPeriodsCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class RetrieveUBPRReportingPeriodsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal RetrieveUBPRReportingPeriodsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    public delegate void RetrieveUBPRXBRLFacsimileCompletedEventHandler(object sender, RetrieveUBPRXBRLFacsimileCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class RetrieveUBPRXBRLFacsimileCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal RetrieveUBPRXBRLFacsimileCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public byte[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((byte[])(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591