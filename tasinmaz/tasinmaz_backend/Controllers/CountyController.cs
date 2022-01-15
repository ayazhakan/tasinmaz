using tasinmaz_backend.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Cors;

namespace tasinmaz_backend.Controllers
{
    [EnableCors("MyCorsImplementationPolicy")]
    [Route("api/[controller]")]
    //[ApiController]
    public class CountyController : Controller
    {

[EnableCors("MyCorsImplementationPolicy")]
        [HttpGet]
        public List<County> Get()
        {
            using (var databasebaglantı = new DatabaseContext())
            {

                return databasebaglantı.counties.ToList();

            }
        }
[EnableCors("MyCorsImplementationPolicy")]
        [HttpGet("{cityid}")]
        public async Task<ActionResult> Get(int cityid)
        {
            using (var databasebaglantı = new DatabaseContext())
            {

                var ilce = await databasebaglantı.counties.Include(x => x.City).Select(x => new
                {
                        
                    cityid=x.cityid,

                    countyid = x.countyid,

                    cityname = x.City.cityname,

                    countyname = x.countyname


                }).Where(x => x.cityid==cityid).ToListAsync();

databasebaglantı.SaveChanges();
return Ok(ilce);


            }




        }



    }}
