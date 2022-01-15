using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;
using System;
using tasinmaz_backend.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Cors;

namespace tasinmaz_backend.Controllers
{
    [EnableCors("MyCorsImplementationPolicy")]
    [Route("api/[controller]")]
    //[ApiController]
    public class NeighborhoodController : Controller
    {
        [EnableCors("MyCorsImplementationPolicy")]
        [HttpGet]
        public List<Neighborhood> Get()
        {
            using (var databasebaglanti = new DatabaseContext())
            {

                return databasebaglanti.neighborhoods.ToList();

            }

        }
        [EnableCors("MyCorsImplementationPolicy")]
        [HttpGet("{countyid}")]

        public async Task<ActionResult> GetNeighborhoodByCounty(int countyid)
        {

            using (var databasebaglanti = new DatabaseContext())
            {

                var mahalle = await databasebaglanti.neighborhoods.Include(x => x.county).Include(x => x.county.City)
                .Select(x => new
                {
                    neighborhoodid = x.neighborhoodid,

                    countyid = x.countyid,

                    cityname = x.county.City.cityname,

                    countyname = x.county.countyname,

                    neighborhoodname = x.neighborhoodname

                }).Where(x => x.countyid == countyid).ToListAsync();
                databasebaglanti.SaveChanges();
                return Ok(mahalle);

            }



        }

    }
}