using Application.DTOs;
using Application.Use_Cases.Commands;
using Application.Use_Cases.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookManagement.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IMediator mediator;

        public BooksController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateBook(CreateBookCommand command)
        {
             var id = await mediator.Send(command);
             return CreatedAtAction(nameof(GetBookById), new { Id = id }, command);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<BookDto>> GetBookById(Guid id)
        {
            return await mediator.Send(new GetBookByIdQuery { Id = id });
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> DeleteBook(Guid id)
        {
            var command = new DeleteBookCommand { Id = id };
            await mediator.Send(command);
            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<List<BookDto>>> GetAllBooks()
        {
            return await mediator.Send(new GetAllBooksQuery());
        }

        [HttpPut]
        public async Task<ActionResult> UpdateBook(UpdateBookCommand command)
        {
            await mediator.Send(command);
            return NoContent();
        }
    }
}
