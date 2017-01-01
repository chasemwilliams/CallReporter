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
    public class FilingProcessorProfileController : TableController<FilingProcessorProfile>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            CallReporterContext context = new CallReporterContext();
            DomainManager = new EntityDomainManager<FilingProcessorProfile>(context, Request);
        }

        // GET tables/FilingProcessorProfile
        public IQueryable<FilingProcessorProfile> GetAllFilingProcessorProfile()
        {
            return Query(); 
        }

        // GET tables/FilingProcessorProfile/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<FilingProcessorProfile> GetFilingProcessorProfile(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/FilingProcessorProfile/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<FilingProcessorProfile> PatchFilingProcessorProfile(string id, Delta<FilingProcessorProfile> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/FilingProcessorProfile
        public async Task<IHttpActionResult> PostFilingProcessorProfile(FilingProcessorProfile item)
        {
            FilingProcessorProfile current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/FilingProcessorProfile/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteFilingProcessorProfile(string id)
        {
             return DeleteAsync(id);
        }
    }
}
