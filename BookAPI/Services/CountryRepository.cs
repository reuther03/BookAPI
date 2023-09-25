
using Microsoft.EntityFrameworkCore;

namespace BookAPI;

public class CountryRepository : ICountryRepository
{
    private readonly BookDbContext _context;

    public CountryRepository(BookDbContext context)
    {
        _context = context;
    }

    public bool CountryExists(int id)
    {
        return _context.Countries
            .Any(c => c.Id == id);
    }

    public Country GetAuthorCountry(int authorId)
    {
        return _context.Countries
            .Where(c => c.Authors.Any(a => a.Id == authorId))
            .FirstOrDefault();
    }

    public ICollection<Country> GetCountries()
    {
        return _context.Countries
            .OrderBy(c => c.Name)
            .ToList();
    }

    public Country GetCountry(int id)
    {
        return _context.Countries
            .FirstOrDefault(c => c.Id == id);
    }

    public ICollection<Author> GetCountryAuthors(int id)
    {
        return _context.Countries
            .Include(c => c.Authors)
            .FirstOrDefault(c => c.Id == id)
            .Authors;

    }
}

