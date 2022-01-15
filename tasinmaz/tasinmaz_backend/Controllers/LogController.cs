using tasinmaz_backend.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace tasinmaz_backend.Controllers
{


    [Route("api/[controller]")]
[EnableCors("MyCorsImplementationPolicy")]
    //[ApiController]
    public class LogController : Controller
    {
        [HttpGet("List")]
        public IActionResult Get([FromQuery] string searchText, [FromQuery] int? page, [FromQuery] int pagesize=10)
        {
            using (var databasebaglanti = new DatabaseContext())
            {var logs=databasebaglanti.loglar.ToList().OrderByDescending(x => x.id);


            var query =string.IsNullOrEmpty(searchText)?logs
            :logs.Where(x =>
            x.islemtipi.ToLower().Contains(searchText.ToLower()) ||
            x.durum.ToLower().Contains(searchText.ToLower())||
            x.Acikklama.ToLower().Contains(searchText.ToLower())||
            x.Ip.ToLower().Contains(searchText.ToLower()) ||
            x.tarihsaat.ToLongDateString().Contains(searchText.ToLower())).ToList().OrderByDescending(x => x.id);;


                int totalCount= query.Count();
                PageResult<Log> result =new PageResult<Log>{

                count=totalCount,
                PageIndex= page ?? 1,
                PageSize=pagesize,
                Items=query.Skip((page-1 ?? 0)*pagesize).Take(pagesize).ToList()
                };

                return Ok(result);

            }

        }
        [HttpGet("{searchText}")]
        public  IActionResult Get(string searchText= "")
        {
            using (var databasebaglanti = new DatabaseContext())
            {var logs= databasebaglanti.loglar.Where(x =>
            x.islemtipi.ToLower().Contains(searchText.ToLower()) ||
            x.durum.ToLower().Contains(searchText.ToLower())||
            x.Acikklama.ToLower().Contains(searchText.ToLower())||
            x.Ip.ToLower().Contains(searchText.ToLower())
            ).ToList().OrderByDescending(x => x.id);



                return Ok(logs);

            }

        }
         [HttpGet]
        public  IActionResult Get()
        {
            using (var databasebaglanti = new DatabaseContext())
            {
                
               var log=  databasebaglanti.loglar.ToList().OrderByDescending(x => x.id);
                
                
               return Ok(log);



                

            }
        } 
        }   }