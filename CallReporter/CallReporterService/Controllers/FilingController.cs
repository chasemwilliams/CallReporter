using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.Azure.Mobile.Server;
using CallReporterService.DataObjects;
using CallReporterService.Models;

namespace CallReporterService.Controllers
{
    public class FilingController : TableController<Filing>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            CallReporterContext context = new CallReporterContext();
            DomainManager = new EntityDomainManager<Filing>(context, Request);
        }

        // GET tables/Filing
        public IQueryable<Filing> GetAllFiling()
        {
            return Query(); 
        }

        // GET tables/Filing/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Filing> GetFiling(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Filing/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Filing> PatchFiling(string id, Delta<Filing> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/Filing
        public async Task<IHttpActionResult> PostFiling(Filing item)
        {
            Filing current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/Filing/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteFiling(string id)
        {
             return DeleteAsync(id);
        }
    }
}
