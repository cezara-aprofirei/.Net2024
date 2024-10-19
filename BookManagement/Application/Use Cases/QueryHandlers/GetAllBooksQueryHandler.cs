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
    public class GetAllBooksQueryHandler : IRequestHandler<GetAllBooksQuery, List<BookDto>>
    {
        private readonly IBookRepository repository;
        private readonly IMapper mapper;

        public GetAllBooksQueryHandler(IBookRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<List<BookDto>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            var books = await repository.GetAllAsync();
            return books.Select(book => mapper.Map<BookDto>(book)).ToList();

        }
    }
}
