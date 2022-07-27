using BookApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookApi.Controllers;
[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    public static List<Book> books = new List<Book>
    {
        new Book
        {
            Id = 1,
            Name = "O'tkan kunlar",
            Pages = 400,
            Author = "Abdulla Qodiriy"
        },
        new Book
        {
            Id = 2,
            Name = "Jamila",
            Pages = 400,
            Author = "Chingiz Aytmatov"
        },
        new Book
        {
            Id = 3,
            Name = "Xamsa",
            Pages = 600,
            Author = "Alisher Navoiy"
        }
    };
    
    [HttpGet]
    public IActionResult GetBooks()
        => Ok(books);

    [HttpGet("{id}")]
    public IActionResult GetBook([FromRoute]int id)
    {
        var book = books.FirstOrDefault(b => b.Id == id);
        if(book == default) return NotFound("Unaqa kitob topilmadi");
        return Ok(book);
    }

    [HttpPost]
    public IActionResult PostBook([FromForm]Book book)
    {
        books.Add(book);
        return Created("api/books", book);
    }

    [HttpPut("{id}")]
    public IActionResult PutBook([FromRoute]int id, [FromForm]Book book)
    {
        var old = books.FirstOrDefault(b => b.Id == id);
        if(old == default) return NotFound();
        old.Name = book.Name;
        old.Author = book.Author;
        old.Pages = book.Pages;
        return Accepted();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteBook([FromRoute]int id)
    {
        var book = books.FirstOrDefault(b => b.Id == id);
        if(book == default) return NotFound();
        books.Remove(book);
        return Accepted();
    }
}