using Application.Use_Cases.Commands;
using Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Use_Cases.ComandHandlers
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand>
    {
        private readonly IBookRepository repository;
        public UpdateBookCommandHandler(IBookRepository repository)
        {
            this.repository = repository;
        }

        public async Task Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var existingBook = await repository.GetByIdAsync(request.Id);

            existingBook.Title = request.Title;
            existingBook.Author = request.Author;
            existingBook.ISBN = request.ISBN;
            existingBook.PublicationDate = request.PublicationDate;

            await repository.UpdateAsync(existingBook);
        }
    }
}
