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
    public class ReportingFinancialInstitutionController : TableController<ReportingFinancialInstitution>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            CallReporterContext context = new CallReporterContext();
            DomainManager = new EntityDomainManager<ReportingFinancialInstitution>(context, Request);
        }

        // GET tables/ReportingFinancialInstitution
        public IQueryable<ReportingFinancialInstitution> GetAllReportingFinancialInstitution()
        {
            return Query(); 
        }

        // GET tables/ReportingFinancialInstitution/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<ReportingFinancialInstitution> GetReportingFinancialInstitution(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/ReportingFinancialInstitution/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<ReportingFinancialInstitution> PatchReportingFinancialInstitution(string id, Delta<ReportingFinancialInstitution> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/ReportingFinancialInstitution
        public async Task<IHttpActionResult> PostReportingFinancialInstitution(ReportingFinancialInstitution item)
        {
            ReportingFinancialInstitution current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/ReportingFinancialInstitution/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteReportingFinancialInstitution(string id)
        {
             return DeleteAsync(id);
        }
    }
}
