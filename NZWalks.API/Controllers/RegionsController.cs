using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Controllers
{
    // https://localhost:portnumber/api/regions
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly NZWalksDbContext dbContext;

        public RegionsController(NZWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // GET All Regions
        // GET : https://localhost:portnumber/api/regions
        [HttpGet]
        public IActionResult GetAll()
        {
            var regions = dbContext.Regions.ToList();

            //var regions = new List<Region>
            //{
            //    new Region
            //    {
            //        Id = Guid.NewGuid(),
            //        Name = "Uttar Pradesh",
            //        Code = "UP",
            //        RegionImageUrl = "https://media.istockphoto.com/id/952763206/photo/taj-mahal-agra-india.jpg?s=2048x2048&w=is&k=20&c=mRe_PPha6JTgIJf6-w96qZMImqQh4O_GQ14Y-Sq4cR0="
            //    },
            //    new Region
            //    {
            //        Id = Guid.NewGuid(),
            //        Name = "Himachal Pradesh",
            //        Code = "HP",
            //        RegionImageUrl = "https://media.istockphoto.com/id/537988165/photo/varanasi.jpg?s=1024x1024&w=is&k=20&c=zlypUzvUt1fFpvA7ESTKB6UE4KEY7paAizZWVhQmz2E="
            //    },
            //};
            return Ok(regions);
        }

        // GET Single Region (Get region by id)
        // GET : https://localhost:portnumber/api/regions/{id}
        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var region = dbContext.Regions.Find(id);

            //var region = dbContext.Regions.FirstOrDefault(x => x.Id == id);

            if (region == null)
            {
                return NotFound();
            }
            return Ok(region);
        }

    }
}
