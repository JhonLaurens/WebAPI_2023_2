using Microsoft.AspNetCore.Mvc;
using ShoppingAPI_2023_2.DAL.Entities;
using ShoppingAPI_2023_2.Domain.Interfaces;

namespace ShoppingAPI_2023_2.Controllers
{
    [ApiController]
    [Route("api/[ApiController]")]//Esta es la primera parte de la URL de esta API: URL=api/countries

    public class CountriesController : Controller
    {
        private readonly ICountryService _countryService;

        public CountriesController(ICountryService countryService)
        {
            _countryService = countryService;

        }

        //En un controlador los Métodos cambian de nombre , y realmente se llaman ACCIUONES (ACTIONS - si es una API , se denomina ENDPOINT
        //Todo ENDPOINT retorna un ActionResult, significa que retorna el resultado de una acción

        public async Task<ActionResult<IEnumerable<Country>>> GetCountriesAsync()
        {

            var countries = await _countryService.GetCountriesAsync();//Aquí estoy yendo a mi capa Domain  
            //para traerme la lista de paises

            if (countries == null || !countries.Any())//El metoso Any() significa si hay al menos un elemento.
                                                      //El metodo !Any() significa si no hay  elementos
            {
                return NotFound();// NotFound() = 404 Http Status Code

            }

            return Ok(countries);//ok = 200 Http Status Code



        }






    }
}
