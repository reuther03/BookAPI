namespace BookAPI;

public interface ICountryRepository
{
   ICollection<Country> GetCountries();
   Country GetCountry(int id);
   Country GetAuthorCountry(int authorId);
   ICollection<Author> GetCountryAuthors(int id);
   bool CountryExists(int id);
}
