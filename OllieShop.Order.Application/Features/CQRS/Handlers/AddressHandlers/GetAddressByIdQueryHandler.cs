using Microsoft.AspNetCore.Http;
using OllieShop.Order.Application.Features.CQRS.Queries.AddressQueries;
using OllieShop.Order.Application.Features.CQRS.Results.AddressResults;
using OllieShop.Order.Application.Interfaces;
using OllieShop.Order.Domain.Entities;
using System.Security.Claims;

namespace OllieShop.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class GetAddressByIdQueryHandler
    {
        private readonly IRepository<Address> _repository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public GetAddressByIdQueryHandler(IRepository<Address> repository, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _repository = repository;
        }

        public async Task<GetAddressByIdQueryResult> Handle(GetAddressByIdQuery query)
        {
            var values = new Address();
            var userId = _httpContextAccessor.HttpContext!.User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            if (userId != null)
            {
                values = await _repository.GetByFilterAsync(x => x.UserId == userId && x.AddressId == query.Id); 
            }

            if (values == null)
            {
                return null!;
            }

            return new GetAddressByIdQueryResult
            {
                AddressId = values.AddressId,
                UserId = values.UserId,
                Surname = values.Surname,
                City = values.City,
                Country = values.Country,
                Description = values.Description,
                Email = values.Email,
                Name = values.Name,
                PhoneNumber = values.PhoneNumber,
                ZipCode = values.ZipCode,
            };
        }
    }
}
