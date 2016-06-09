using System.Linq;
using Licensing.Web.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Licensing.Web.Modules.Features
{
    public class FeaturesIndexQueryHandler : Controller
    {
        private readonly LicensingContext _context;

        public FeaturesIndexQueryHandler(LicensingContext context)
        {
            _context = context;
        }

        [HttpGet("/features")]
        public IActionResult Handle()
        {
            var features = _context.Features
                .AsNoTracking()
                .OrderBy(f => f.Name)
                .Select(f => new ResultItem
                {
                    Id = f.Id,
                    Name = f.Name
                })
                .ToList();

            return View("/Modules/Features/FeaturesIndex.cshtml", features);
        }

        public class ResultItem
        {
            public int Id { get; set; }

            public string Name { get; set; }
        }
    }
}
