using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NZWalksAPI.CustomActionFilters;
using NZWalksAPI.Models.Domain;
using NZWalksAPI.Models.DTO;
using NZWalksAPI.Repositories;

namespace NZWalksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IWalkRepository walkRepository;
        private readonly IMapper mapper;

        public WalksController(IWalkRepository walkRepository, IMapper mapper)
        {
            this.walkRepository = walkRepository;
            this.mapper = mapper;
        }

        [HttpPost]
        [ValidateModel]
        [Authorize(Roles ="Writer")]
        public async Task<IActionResult> Create([FromBody] AddWalkRequestDto request)
        {
            var walkDomainModel = mapper.Map<Walk>(request);
            
            walkDomainModel = await walkRepository.CreateAsync(walkDomainModel);

            var walkDto = mapper.Map<WalkDto>(walkDomainModel);

            return Ok(walkDto);
        }

        [HttpGet]
        [Authorize(Roles ="Reader")]
        public async Task<IActionResult> GetAll([FromQuery] string? filterOn, [FromQuery] string? filterQuery,
            [FromQuery] string? sortBy, [FromQuery] bool? isAscending,
            [FromQuery] int pageNumber = 1, [FromQuery] int PageSize = 1000)
        {
            var walks = await walkRepository.GetAllAsync(filterOn, filterQuery, sortBy, isAscending ?? true,
                pageNumber, PageSize);

            return Ok(mapper.Map<List<WalkDto>>(walks));
        }

        [HttpGet]
        [Route("{id:guid}")]
        [Authorize(Roles ="Reader")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var walkDomainModel = await walkRepository.GetByIdAsync(id);

            if(walkDomainModel == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<WalkDto>(walkDomainModel));
        }

        [HttpPut]
        [Route("{id:guid}")]
        [ValidateModel]
        [Authorize(Roles ="Writer")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateWalkRequestDto request)
        {
            var walkDomainModel = mapper.Map<Walk>(request);

            walkDomainModel = await walkRepository.UpdateAsync(id, walkDomainModel);

            if(walkDomainModel == null)
            {
                return NotFound();
            }

            //map domain to dto
            return Ok(mapper.Map<WalkDto>(walkDomainModel));
        }

        [HttpDelete]
        [Route("{id:guid}")]
        [Authorize(Roles ="Writer")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var deleteWalkDomain = await walkRepository.DeleteAsync(id);
            
            if(deleteWalkDomain == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<WalkDto>(deleteWalkDomain));
        }
    }
}
