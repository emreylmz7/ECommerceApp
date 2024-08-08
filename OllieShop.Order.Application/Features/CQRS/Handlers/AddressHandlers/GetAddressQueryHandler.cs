using Microsoft.AspNetCore.Http;
using OllieShop.Order.Application.Features.CQRS.Results.AddressResults;
using OllieShop.Order.Application.Interfaces;
using OllieShop.Order.Domain.Entities;
using System.Linq;
using System.Security.Claims;

namespace OllieShop.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class GetAddressQueryHandler
    {
        private readonly IRepository<Address> _repository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public GetAddressQueryHandler(IRepository<Address> repository, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _repository = repository;
        }

        public async Task<List<GetAddressQueryResult>> Handle()
        {
            var values = new List<Address>();
            var userId = _httpContextAccessor.HttpContext!.User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            if (userId != null)
            {
                values = await _repository.GetListByFilterAsync(x => x.UserId == userId);
            }

            if (values == null)
            {
                return null;
            }

            return values.Select(x => new GetAddressQueryResult
            {
                AddressId = x.AddressId,
                UserId = x.UserId,
                Surname = x.Surname,
                City = x.City,
                Country = x.Country,
                Description = x.Description,
                Email = x.Email,
                Name = x.Name,
                PhoneNumber = x.PhoneNumber,
                ZipCode = x.ZipCode,
            }).ToList();
        }
    }
}
