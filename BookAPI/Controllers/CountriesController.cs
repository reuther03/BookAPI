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
    [ProducesResponseType(400)]
    [ProducesResponseType(200, Type = typeof(IEnumerable<CountryDto>))]
    public IActionResult GetAllCountries()
    {
        var result = _countryRepository.GetCountries();
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

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

    [HttpGet("{id}")]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    [ProducesResponseType(200, Type = typeof(CountryDto))]
    public IActionResult GetCountry(int id)
    {
        if (!_countryRepository.CountryExists(id))
            return NotFound();

        var result = _countryRepository.GetCountry(id);

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var countryDto = new CountryDto()
        {
            Id = result.Id,
            Name = result.Name
        };

        return Ok(countryDto);
    }
}

