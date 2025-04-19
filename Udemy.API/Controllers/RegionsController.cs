using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Udemy.API.DBContext;
using Udemy.API.Models;
using Udemy.API.Repository;

namespace Udemy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RegionsController : ControllerBase
    {
        private readonly UdemyDB context;

        private readonly IRegionRepository RegionRepository;
        private IMapper _mapper;

        public RegionsController(IRegionRepository regionRepository, IMapper mapper)
        {
            this.context = context;
            RegionRepository = regionRepository;
            _mapper = mapper;
        }
        // Get all region methos
        [HttpGet]
        public async Task<IActionResult> GetALl()
        {
            var regions = await RegionRepository.GetAllAsync();

            _mapper.Map<Region>(regions);
            //var regions = new List<Region>
            //{ 
            //    new Region
            //    {
            //        Id = Guid.NewGuid(),
            //        Name = "Ravi",
            //        Code = "wew",
            //        RegionImageUrl ="asndks"
            //    }

            //};
            return Ok(regions);

        }

        // GET 

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            //var region=context.Regions.Find(id);
            var region = await context.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (region == null)
            {
                return NotFound();
            }
            return Ok(region);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Region region)
        {
            var region1 = await context.Regions.AddAsync(region);
            await context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = region.Id }, region1);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] Region region)
        {
            var region1 = await context.Regions.FirstOrDefaultAsync(y => y.Id == id);
            if (region1.Id == null)
            {
                return NotFound();
            }
            context.Regions.Update(region1);
            await context.SaveChangesAsync();
            return Ok(region);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult Delete([FromRoute] Guid id)
        {
            var regionmodel = context.Regions.FirstOrDefault(i => i.Id == id);

            if (regionmodel == null)
            {
                return NotFound(id);
            }
            context.Regions.Remove(regionmodel);
            context.SaveChanges();
            return Ok();
        }
    }
}
