using Microsoft.AspNetCore.Mvc;

namespace BookAPI;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoriesController(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<CategoryDto>), StatusCodes.Status200OK)]
    public IActionResult GetAllCategories()
    {
        var result = _categoryRepository.GetCategories();
        var categoriesDto = new List<CategoryDto>();

        foreach (var category in result)
        {
            categoriesDto.Add(new CategoryDto
            {
                Id = category.Id,
                Name = category.Name
            });
        }

        return Ok(categoriesDto);
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CountryDto))]
    public IActionResult GetCategory([FromRoute] int id)
    {
        var result = _categoryRepository.GetCategory(id);
        if (result is null) return NotFound();

        var categoryDto = new CategoryDto
        {
            Id = result.Id,
            Name = result.Name
        };

        return Ok(categoryDto);
    }

    [HttpGet("Book/{bookId:int}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(IEnumerable<CategoryDto>), StatusCodes.Status200OK)]
    public IActionResult GetBookCategories([FromRoute] int bookId)
    {
        var result = _categoryRepository.GetBookCategories(bookId);
        var categoriesDto = new List<CategoryDto>();

        if (result is null) return NotFound();

        foreach (var country in result)
        {
            categoriesDto.Add(new CategoryDto
            {
                Id = country.Id,
                Name = country.Name
            });
        }

        return Ok(categoriesDto);
    }

    [HttpGet("Category/{categoryId:int}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(IEnumerable<BookDto>), StatusCodes.Status200OK)]
    public IActionResult GetCategoryBooks([FromRoute] int categoryId)
    {
        var result = _categoryRepository.GetCategoryBooks(categoryId);
        var bookDtos = new List<BookDto>();

        if (result is null) return NotFound();

        foreach (var book in result)
        {
            bookDtos.Add(new BookDto
            {
                Id = book.Id,
                Isbn = book.Isbn,
                Title = book.Title
            });
        }

        return Ok(bookDtos);
    }
}

