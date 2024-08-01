using BookCatalogApi.Context;
using BookCatalogApi.Migrations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookCatalogApi.Models;

namespace BookCatalogApi.Controllers;

[Route("[controller]")]
[ApiController]
public class BookController : ControllerBase 
{
    private readonly AppDbContext _context;

    public BookController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Book>> Get () 
    {
        var books = _context.Books.ToList();

        if (books is null)
            return NotFound("No books were found.");
        
            
        return books;

        
    }

    [HttpGet("{id:int}", Name = "GettingBook")]
    public ActionResult<Book> GetById (int id) 
    {
        var book = _context.Books.FirstOrDefault(b => b.Id == id);

        if (book is null)
            return NotFound("Book not found.");

        return book;
    }

    [HttpPost]
    public ActionResult<Book> Post(Book book) 
    {
        if (book is null)
        return BadRequest();
        
        _context.Books.Add(book);
        _context.SaveChanges();

        return new CreatedAtRouteResult("GettingBook",
            new { id = book.Id }, book );

    }
}