using Microsoft.AspNetCore.Mvc;

namespace BookAPI;

[ApiController]
[Route("api/[controller]")]
public class CountriesController : ControllerBase
{
    private readonly ICountryRepository _countryRepository;

    public CountriesController(ICountryRepository countryRepository)
    {
        _countryRepository = countryRepository;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<CountryDto>), StatusCodes.Status200OK)]
    public IActionResult GetAllCountries()
    {
        var result = _countryRepository.GetCountries();
        var countriesDto = new List<CountryDto>();

        foreach (var country in result)
        {
            countriesDto.Add(new CountryDto
            {
                Id = country.Id,
                Name = country.Name
            });
        }

        return Ok(countriesDto);
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(CountryDto), StatusCodes.Status200OK)]
    public IActionResult GetCountry([FromRoute] int id)
    {
        if (!_countryRepository.CountryExists(id))
            return NotFound();

        var result = _countryRepository.GetCountry(id);
        var countryDto = new CountryDto
        {
            Id = result.Id,
            Name = result.Name
        };

        return Ok(countryDto);
    }

    [HttpGet("authors/{authorId:int}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CountryDto))]
    public IActionResult GetAuthorCountry(int authorId)
    {
        var result = _countryRepository.GetAuthorCountry(authorId);
        if (result is null)
            return NotFound();

        var countryDto = new CountryDto
        {
            Id = result.Id,
            Name = result.Name

        };

        return Ok(countryDto);
    }
}

