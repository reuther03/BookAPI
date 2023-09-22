using Microsoft.AspNetCore.Mvc;

namespace BookAPI;
[ApiController]
[Route("[controller]")]
public class CountriesController : ControllerBase
{
    private readonly ICountryRepository _countryRepository;

    public CountriesController(ICountryRepository countryRepository)
    {
        _countryRepository = countryRepository;
    }
    [HttpGet]
    public IActionResult GetAllCountries()
    {
        var result = _countryRepository.GetCountries();

        return Ok(result);
    }
}

