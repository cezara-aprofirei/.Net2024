using Application.DTOs;
using Application.Use_Cases.Queries;
using AutoMapper;
using Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Use_Cases.QueryHandlers
{
    public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, BookDto>
    {
        private readonly IBookRepository repository;
        private readonly IMapper mapper;

        public GetBookByIdQueryHandler(IBookRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<BookDto> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            var book = await repository.GetByIdAsync(request.Id);
            //return new BookDto
            //{
            //    Id = book.Id,
            //    Title = book.Title,
            //    Author = book.Author,
            //    ISBN = book.ISBN,
            //    PublicationDate = book.PublicationDate
            //};
            return mapper.Map<BookDto>(book);
        }
    }
}
