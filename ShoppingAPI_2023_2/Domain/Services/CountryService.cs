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
        //generate method create country async usando try catch 
        public async Task<Country> CreateCountryAsync(Country country)
        {
            try
            {
                country.Id = Guid.NewGuid();
                country.CreatedDate = DateTime.Now;

                _context.Countries.Add(country);
                await _context.SaveChangesAsync();

                return country;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
            
        }


        public async Task<Country> GetCountryByIdAsync(Guid id)
        {
            return await _context.Countries.FirstOrDefaultAsync(c => c.Id == id);
        }
        public async Task<Country> GetCountryByNameAsync(string name)
        {
            return await _context.Countries.FirstOrDefaultAsync(c => c.Name == name);
        }
        //generate method edit country async usando try catch método Update que es de EF CORE me sirve para Actualizar un objeto
        public async Task<Country> EditCountryAsync(Country country)
        {
            try
            {
                country.ModifiedDate = DateTime.Now;
                _context.Countries.Update(country);
                await _context.SaveChangesAsync();
                return country;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }
        //ID que traigo desde el controller, estoy recuperando el país que luego voy a eliminar
        //Ese país que recupero lo guardo en la variable country

        public async Task<Country> DeleteCountryAsync(Guid id)
        {
            //try catch
            try
            {
                var country = await _context.Countries.FirstOrDefaultAsync(c => c.Id == id);
                if (country == null) return null;
                _context.Countries.Remove(country);
                await _context.SaveChangesAsync();
                return country;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }


            
        }
        
    }



}
