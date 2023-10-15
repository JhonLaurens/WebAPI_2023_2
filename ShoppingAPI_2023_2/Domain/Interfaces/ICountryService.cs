using ShoppingAPI_2023_2.DAL.Entities;

namespace ShoppingAPI_2023_2.Domain.Interfaces
{
    public interface ICountryService
    {

        Task<IEnumerable<Country>> GetCountriesAsync();//Una firma de método

    }
}
