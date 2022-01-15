using tasinmaz_backend.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Cors;

namespace tasinmaz_backend.Controllers
{

[EnableCors("MyCorsImplementationPolicy")]
    [Route("api/[controller]")]
    //[ApiController]
    public class CityController : Controller
    {[EnableCors("MyCorsImplementationPolicy")]
        [HttpGet]
        public List<City> Get()
        {
            using (var databasebaglanti = new DatabaseContext())
            {


                return databasebaglanti.cities.ToList();

            }

        }

        [EnableCors("MyCorsImplementationPolicy")]
        [HttpGet("GetById/{id}")]
        public IActionResult GetCityById(int id)
        {
            using (var databasebaglanti = new DatabaseContext())
            {


                var sehir= databasebaglanti.cities.Find(id);


                    return Ok(sehir);
            }

        }
    }
}