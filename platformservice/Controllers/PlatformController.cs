using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using platformservice.Data;
using platformservice.Dtos;
using platformservice.Entities;

namespace platformservice.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PlatformController : ControllerBase
{
    private readonly IPlatformRepository _repository;
    private readonly IMapper _mapper;

    public PlatformController(IPlatformRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }


    [HttpGet]
    public  ActionResult<IEnumerable<PlatformReadDto>> GetPlatform()
    {
        Console.WriteLine("-----> Getting Platforms ......");

        var platformItem = _repository.GetAllPlatforms();

        return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(platformItem));

    }

    [HttpGet("{id}",Name = "GetPlatformById")]

    public ActionResult<PlatformReadDto> GetPlatformById( int id)
    {
        var platformItem = _repository.GetPlatformById(id);

        if(platformItem != null)
        {
           return Ok(_mapper.Map<PlatformReadDto>(platformItem));
        }

        return NotFound();

    }
  

    [HttpPost]
    public ActionResult<PlatformReadDto> CreatePlatform(PlatformCreateDto platform)
    {
        var platformModel = _mapper.Map<Platform>(platform);

        _repository.CreatePlatform(platformModel);
        _repository.SaveChanges();

        var platformReadDto = _mapper.Map<PlatformReadDto>(platformModel);

        return CreatedAtRoute(nameof(GetPlatformById), new{Id = platformReadDto.Id}, platformReadDto);
    }


}

