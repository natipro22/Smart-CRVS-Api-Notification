using AppDiv.CRVS.Application.Contracts.DTOs;
using AppDiv.CRVS.Domain.Entities;
namespace AppDiv.CRVS.Application.Interfaces
{
    public interface IDateAndAddressService
    {
        public (string, string) addressFormat(Guid? id);

        public (string[]?, string[]?)? SplitedAddress(string? am, string? or);
        public string[] SplitedAddressByLang(Guid? id);
        public Task<AddressResponseDTOE>? FormatedAddress(Guid? id);
        public string GetFullAddress(Address address);
        public bool IsCityAdmin(Guid? Id);
        // public (string?,string?) stringAddress(FormatedAddressDto? address);
        //  public FormatedAddressDto?  AddressfromProcedure(Guid? Id);
         public  Task<AddressResponseDTOE>? FormatedAddressLoop(Guid? id);



    }
}