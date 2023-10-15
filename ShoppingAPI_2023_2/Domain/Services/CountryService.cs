using Microsoft.EntityFrameworkCore;
using ShoppingAPI_2023_2.DAL;
using ShoppingAPI_2023_2.DAL.Entities;
using ShoppingAPI_2023_2.Domain.Interfaces;

namespace ShoppingAPI_2023_2.Domain.Services
{
    public class CountryService : ICountryService
    {
        public readonly DataBaseContext _context;

        public CountryService(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Country>> GetCountriesAsync()
        {
            return await _context.Countries.ToListAsync();//aqui lo que hago es traerme todos los datos que tengo en mi tabla Countries.


        }
    }
}
