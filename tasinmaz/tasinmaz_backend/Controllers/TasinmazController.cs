using tasinmaz_backend.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;
using System;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
namespace tasinmaz_backend.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("MyCorsImplementationPolicy")]
    public class TasinmazController : Controller
    {
        [EnableCors("MyCorsImplementationPolicy")]
        [HttpGet("List")]
        public IActionResult Get([FromQuery] string searchText, [FromQuery] int? page, [FromQuery] int pagesize = 10)
        {
            using (var databasebaglanti = new DatabaseContext())
            {

                databasebaglanti.loglar.Add(Logger.Loglayıcı("başarılı", "Taşınmaz Listele", "Taşınmazlar Listelendi"));
                databasebaglanti.SaveChanges();

                var tasinmaz = databasebaglanti.tasinmazlar.Include(x => x.neighborhood)

                .Include(x => x.neighborhood.county).Include(x => x.neighborhood.county.City)

                .Select(x => new Tasinmaz
                {
                    cityid = x.neighborhood.county.City.cityid,
                    countyid = x.neighborhood.countyid,
                    neighborhoodid = x.neighborhoodid,
                    neighborhoodname = x.neighborhood.neighborhoodname,
                    countyname = x.neighborhood.county.countyname,
                    cityname = x.neighborhood.county.City.cityname,
                    tasinmazid = x.tasinmazid,
                    ada = x.ada,
                    parsel = x.parsel,
                    nitelik = x.nitelik,
                    adres = x.adres,
                    silindimi = x.silindimi
                }).Where(y => y.silindimi == false).ToList().OrderByDescending(x => x.tasinmazid); ;


                var query = string.IsNullOrEmpty(searchText) ? tasinmaz
        : tasinmaz.Where(x =>
         x.adres.ToLower().Contains(searchText.ToLower()) ||
         x.nitelik.ToLower().Contains(searchText.ToLower())


        );



                int totalCount = query.Count();

                PageResult<Tasinmaz> result = new PageResult<Tasinmaz>
                {

                    count = totalCount,
                    PageIndex = page ?? 1,
                    PageSize = pagesize,
                    Items = query.Skip((page - 1 ?? 0) * pagesize).Take(pagesize).ToList()
                };

                return Ok(result);



            }
        }
        [EnableCors("MyCorsImplementationPolicy")]
        [HttpGet("GetByText/{searchText}")]
        public IActionResult Get(string searchText = "")
        {
            var databasebaglanti = new DatabaseContext();
            var gelenTasinmaz = databasebaglanti.tasinmazlar.Include(x => x.neighborhood)

              .Include(x => x.neighborhood.county).Include(x => x.neighborhood.county.City)

              .Select(x => new Tasinmaz
              {
                  cityid = x.neighborhood.county.City.cityid,
                  countyid = x.neighborhood.countyid,
                  neighborhoodid = x.neighborhoodid,
                  neighborhoodname = x.neighborhood.neighborhoodname,
                  countyname = x.neighborhood.county.countyname,
                  cityname = x.neighborhood.county.City.cityname,
                  tasinmazid = x.tasinmazid,
                  ada = x.ada,
                  parsel = x.parsel,
                  nitelik = x.nitelik,
                  adres = x.adres,
                  silindimi = x.silindimi
              }).Where(y => y.silindimi == false).Where(x =>
          x.ada.ToString().Contains(searchText.ToLower()) ||
          x.parsel.ToString().Contains(searchText.ToLower()) ||
          x.cityname.ToLower().Contains(searchText.ToLower()) ||
          x.countyname.ToLower().Contains(searchText.ToLower()) ||
          x.neighborhoodname.ToLower().Contains(searchText.ToLower()) ||
          x.nitelik.ToLower().Contains(searchText.ToLower()) ||
          x.adres.ToLower().Contains(searchText.ToLower())
          ).ToList().OrderByDescending(x => x.tasinmazid);

            return Ok(gelenTasinmaz);



        }
        [EnableCors("MyCorsImplementationPolicy")]
        [HttpGet("GetById/{id}")]
        public IActionResult Get(int id)
        {
            using (var databasebaglanti = new DatabaseContext())
            {

                var tasinmaz = databasebaglanti.tasinmazlar.Include(x => x.neighborhood)

               .Include(x => x.neighborhood.county).Include(x => x.neighborhood.county.City)

               .Select(x => new Tasinmaz
               {
                   cityid = x.neighborhood.county.City.cityid,
                   countyid = x.neighborhood.countyid,
                   neighborhoodid = x.neighborhoodid,
                   neighborhoodname = x.neighborhood.neighborhoodname,
                   countyname = x.neighborhood.county.countyname,
                   cityname = x.neighborhood.county.City.cityname,
                   tasinmazid = x.tasinmazid,
                   ada = x.ada,
                   parsel = x.parsel,
                   nitelik = x.nitelik,
                   adres = x.adres,
                   silindimi = x.silindimi
               }).Where(y => y.silindimi == false).ToList();


                foreach (var donenTasinmaz in tasinmaz)
                {

                    if (donenTasinmaz.tasinmazid == id && donenTasinmaz != null)
                    {
                        databasebaglanti.loglar.Add(Logger.Loglayıcı("başarılı", "Taşınmaz Listele", "Taşınmazlar Listelendi"));
                        databasebaglanti.SaveChanges();
                        return Ok(donenTasinmaz);
                    }

                }

                databasebaglanti.loglar.Add(Logger.Loglayıcı("başarısız", "Taşınmaz Listele", "Taşınmazlar Listelenemedi"));
                databasebaglanti.SaveChanges();
                return NotFound();




            }
        }

        [EnableCors("MyCorsImplementationPolicy")]
        [HttpPost]
        public IActionResult CreateTasinmaz([FromBody] Tasinmaz yenitasinmaz)
        {

            using (var databasebaglantı = new DatabaseContext())
            {

                if (databasebaglantı.tasinmazlar.FirstOrDefault(x => x.adres == yenitasinmaz.adres) != null &&
                 databasebaglantı.tasinmazlar.FirstOrDefault(x => x.parsel == yenitasinmaz.parsel) != null &&
                 databasebaglantı.tasinmazlar.FirstOrDefault(x => x.nitelik == yenitasinmaz.nitelik) != null &&
                 databasebaglantı.tasinmazlar.FirstOrDefault(x => x.ada == yenitasinmaz.ada) != null)
                {
                    databasebaglantı.loglar.Add(Logger.Loglayıcı("başarısız", "Taşınmaz Ekle", "Taşınmazlar Eklenemedi"));
                    databasebaglantı.SaveChanges();
                    return BadRequest("Var Olan Taşınmaz");

                }
                if (!ModelState.IsValid)
                {
                    databasebaglantı.loglar.Add(Logger.Loglayıcı("başarısız", "Taşınmaz Ekle", "Taşınmazlar Eklenemedi"));
                    databasebaglantı.SaveChanges();
                    return BadRequest(ModelState);
                }
                databasebaglantı.loglar.Add(Logger.Loglayıcı("başarılı", "Taşınmaz Ekle", "Taşınmazlar Eklendi"));
                databasebaglantı.SaveChanges();
                yenitasinmaz.silindimi = false;
                databasebaglantı.tasinmazlar.Add(yenitasinmaz);
                databasebaglantı.SaveChanges();

                return Ok(yenitasinmaz);

            }

        }
        [EnableCors("MyCorsImplementationPolicy")]
        [HttpPut]
        public IActionResult UpdateTasinmaz([FromBody] Tasinmaz tasinmaz)

        {



            using (var databasebaglanti = new DatabaseContext())
            {

                databasebaglanti.Entry<Tasinmaz>(tasinmaz).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                if (!ModelState.IsValid)
                {
                    databasebaglanti.loglar.Add(Logger.Loglayıcı("başarısız", "Taşınmaz Güncelle", "Taşınmazlar Güncellenemedi"));
                    databasebaglanti.SaveChanges();
                    return BadRequest();
                }

                if (databasebaglanti.tasinmazlar.Find(tasinmaz.tasinmazid) == null)
                {
                    databasebaglanti.loglar.Add(Logger.Loglayıcı("başarısız", "Taşınmaz Güncelle", "Taşınmazlar Güncellenemedi"));
                    databasebaglanti.SaveChanges();
                    return NotFound("tasinmaz bulunamadı");
                }

                databasebaglanti.tasinmazlar.Update(tasinmaz);
                databasebaglanti.loglar.Add(Logger.Loglayıcı("başarılı", "Taşınmaz Güncelle", "Taşınmazlar Güncellendi"));
                databasebaglanti.SaveChanges();
                return Ok(tasinmaz);
            }
        }
        [EnableCors("MyCorsImplementationPolicy")]
        [HttpDelete("{id}")]
        public void DeleteTasinmaz(int id)
        {
            using (var databasebaglanti = new DatabaseContext())
            {
                var silinecekTasinmaz = databasebaglanti.tasinmazlar.Find(id);
                silinecekTasinmaz.silindimi = true;

                databasebaglanti.tasinmazlar.Update(silinecekTasinmaz);
                databasebaglanti.loglar.Add(Logger.Loglayıcı("başarılı", "Taşınmaz Sil", "Taşınmazlar Silindi"));
                databasebaglanti.SaveChanges();

            }


        }
        [HttpGet]
        public IActionResult Get()
        {
            using (var databasebaglanti = new DatabaseContext())
            {



                var tasinmaz = databasebaglanti.tasinmazlar.Include(x => x.neighborhood)

                .Include(x => x.neighborhood.county).Include(x => x.neighborhood.county.City)

                .Select(x => new Tasinmaz
                {
                    cityid = x.neighborhood.county.City.cityid,
                    countyid = x.neighborhood.countyid,
                    neighborhoodid = x.neighborhoodid,
                    neighborhoodname = x.neighborhood.neighborhoodname,
                    countyname = x.neighborhood.county.countyname,
                    cityname = x.neighborhood.county.City.cityname,
                    tasinmazid = x.tasinmazid,
                    ada = x.ada,
                    parsel = x.parsel,
                    nitelik = x.nitelik,
                    adres = x.adres,
                    silindimi = x.silindimi
                }).Where(y => y.silindimi == false).ToList().OrderByDescending(x => x.tasinmazid);

                return Ok(tasinmaz);


            }
        }

    }
}