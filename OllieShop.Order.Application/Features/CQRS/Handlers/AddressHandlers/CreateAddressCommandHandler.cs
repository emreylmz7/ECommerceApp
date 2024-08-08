using OllieShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using OllieShop.Order.Application.Interfaces;
using OllieShop.Order.Domain.Entities;

namespace OllieShop.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class CreateAddressCommandHandler
    {
        private readonly IRepository<Address> _repository;

        public CreateAddressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateAddressCommand createAddressCommand)
        {
            await _repository.CreateAsync(new Address
            {
                UserId = createAddressCommand.UserId,
                Surname = createAddressCommand.Surname, 
                City = createAddressCommand.City,
                Country = createAddressCommand.Country,
                Description = createAddressCommand.Description,
                Email = createAddressCommand.Email,
                Name = createAddressCommand.Name,
                PhoneNumber = createAddressCommand.PhoneNumber,
                ZipCode = createAddressCommand.ZipCode,
            });
        }
    }
}
