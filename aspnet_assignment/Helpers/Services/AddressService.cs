using aspnet_assignment.Helpers.Repositories;
using aspnet_assignment.Models.Entities;
using aspnet_assignment.Models.Identity;

namespace aspnet_assignment.Helpers.Services
{
    public class AddressService
    {
        private readonly AddressRepository _addressRepo;
        private readonly UserAddressRepository _userAddressRepo;


        public AddressService(AddressRepository addressRepo, UserAddressRepository userAddressRepo)
        {
            _addressRepo = addressRepo;
            _userAddressRepo = userAddressRepo;
        }

        public async Task<AddressEntity> GetOrCreateAddressAsync(AddressEntity addressEntity)
        {
            var entity = await _addressRepo.GetAsync(x => x.StreetName == addressEntity.StreetName && x.City == addressEntity.City && x.PostalCode == addressEntity.PostalCode);
            if(entity == null)
            {
                entity = await _addressRepo.AddAsync(addressEntity);
            }
            return entity;
        }

        public async Task AddAddressAsync(CustomUser user, AddressEntity addressEntity)
        {
            await _userAddressRepo.AddAsync(new UserAddressEntity
            {
                UserId = user.Id,
                AddressId = addressEntity.Id,
            });
        }
    }
}
