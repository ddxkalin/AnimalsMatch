namespace Pets.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Pets.Data.Models.Cats;
    using Pets.Data.Models.Dogs;
    using Pets.Services.Interfaces;
    using Pets.Web.Areas.Admin.Controllers.Base;
    using Pets.Web.Areas.Admin.Models;

    public class AdoptionController : EntityListController
    {
        private IAdoptionPetService<AdoptionCat> catService;
        private IAdoptionPetService<AdoptionDog> dogService;

        public AdoptionController(IAdoptionPetService<AdoptionCat> catService, IAdoptionPetService<AdoptionDog> dogService)
        {
            this.catService = catService;
            this.dogService = dogService;
        }

        [HttpGet]
        [Route("admin/actors")]
        public IActionResult Index(PaginationVM pagination, string name)
        {
            return View();
        }
    }
}
