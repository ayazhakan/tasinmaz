using tasinmaz_backend.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Cors;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace tasinmaz_backend.Controllers
{
    [Route("api/kullanici")]
    [ApiController]

    public class KullanıcıController : Controller
    {

        
        [EnableCors("MyCorsImplementationPolicy")]
        [HttpGet("List")]

        public IActionResult Get([FromQuery] string searchText, [FromQuery] int? page, [FromQuery] int pagesize=10)
        {
            using (var databasebaglanti = new DatabaseContext())
            {
                databasebaglanti.loglar.Add(Logger.Loglayıcı("başarılı", "Kullanıcı Listele", "Tüm Kullanıcıları Listele"));
                databasebaglanti.SaveChanges();

            var gelenKullanicilar=databasebaglanti.kullanicilar.Where(y => y.silindimi == false).ToList().OrderByDescending(x => x.kullaniciid);

            var query =string.IsNullOrEmpty(searchText)?gelenKullanicilar
            :gelenKullanicilar.Where(x =>
            x.soyad.ToLower().Contains(searchText.ToLower()) ||
            x.email.ToLower().Contains(searchText.ToLower())||
            x.adres.ToLower().Contains(searchText.ToLower())||
            x.ad.ToLower().Contains(searchText.ToLower())
            );

            int totalCount= query.Count();

            PageResult<Kullanici> result =new PageResult<Kullanici>{

                count=totalCount,
                PageIndex= page ?? 1,
                PageSize=pagesize,
                Items=query.Skip((page-1 ?? 0)*pagesize).Take(pagesize).ToList()
                };

                return Ok(result);
            }
        }
         
        [HttpGet("GetByText/{searchText}")]
        public  IActionResult Get(string searchText= "")
        {
           var databasebaglanti = new DatabaseContext();
              var gelenKullanicilar= databasebaglanti.kullanicilar.Where(y => y.silindimi == false).Where(x =>
            x.ad.ToLower().Contains(searchText.ToLower()) ||
            x.soyad.ToLower().Contains(searchText.ToLower())||
            x.email.ToLower().Contains(searchText.ToLower())||
            x.adres.ToLower().Contains(searchText.ToLower())||
            x.rol.ToString().ToLower().Contains(searchText.ToLower())
            ).ToList().OrderByDescending(x => x.kullaniciid);

                return Ok(gelenKullanicilar);

            

        }


        [EnableCors("MyCorsImplementationPolicy")]
        [HttpGet("GetById/{id}")]

        public IActionResult Get(int id)
        {
            using (var databasebaglanti = new DatabaseContext())
            {

                var kullanıcı = databasebaglanti.kullanicilar.Find(id);
                if (kullanıcı != null)
                {
                    databasebaglanti.loglar.Add(Logger.Loglayıcı("başarılı", "Kullanıcı Listele", "Id'si belirlenen kullanıcıyı getir"));
                    databasebaglanti.SaveChanges();
                    return Ok(kullanıcı);
                }
                databasebaglanti.loglar.Add(Logger.Loglayıcı("başarısız", "Kullanıcı Listele", "Id'si belirlenen kullanıcıyı getir"));

                databasebaglanti.SaveChanges();
                return NotFound();

            }

        }
        
        [EnableCors("MyCorsImplementationPolicy")]
        [HttpPost]
        public IActionResult CreateKullanıcı([FromBody] Kullanici kullanıcı)
        {

            using (var databasebaglantı = new DatabaseContext())
            {

                if (databasebaglantı.kullanicilar.FirstOrDefault(x => x.email == kullanıcı.email) != null&&
                databasebaglantı.kullanicilar.FirstOrDefault(x => x.ad == kullanıcı.ad) != null&&
                databasebaglantı.kullanicilar.FirstOrDefault(x => x.soyad == kullanıcı.soyad) != null&&
                databasebaglantı.kullanicilar.FirstOrDefault(x => x.adres == kullanıcı.adres) != null&&
                databasebaglantı.kullanicilar.FirstOrDefault(x => x.rol == kullanıcı.rol) != null)
                {
                    databasebaglantı.loglar.Add(Logger.Loglayıcı("başarısız", "Kullanıcı Ekle", "Kullanıcıyı Ekle"));
                    databasebaglantı.SaveChanges();
                    return BadRequest();
                }
                if (!ModelState.IsValid)
                {

                    databasebaglantı.loglar.Add(Logger.Loglayıcı("başarısız", "Kullanıcı Ekle", "Kullanıcıyı Ekle"));
                    databasebaglantı.SaveChanges();
                    return BadRequest();
                }

                kullanıcı.silindimi = false;
                databasebaglantı.kullanicilar.Add(kullanıcı);
                databasebaglantı.loglar.Add(Logger.Loglayıcı("başarılı", "Kullanıcı Ekle", "Kullanıcıyı Ekle"));
                databasebaglantı.SaveChanges();
                return Ok(kullanıcı);

            }

        }

        [EnableCors("MyCorsImplementationPolicy")]
        [HttpPut]
        public IActionResult  UpdateKullanıcı([FromBody] Kullanici kullanıcı)
        { 
            using (var databasebaglanti = new DatabaseContext())
            {
                databasebaglanti.Entry<Kullanici>(kullanıcı).State = Microsoft.EntityFrameworkCore.EntityState.Modified;


                if (!ModelState.IsValid)
                {
                    databasebaglanti.loglar.Add(Logger.Loglayıcı("başarısız", "Kullanıcı Güncelle", "Kullanıcı Güncellenemedi"));
                    databasebaglanti.SaveChanges();
                    return BadRequest();
                }


                if (databasebaglanti.kullanicilar.Find(kullanıcı.kullaniciid) == null)
                {
                    databasebaglanti.loglar.Add(Logger.Loglayıcı("başarısız", "Kullanıcı Güncelle", "Kullanıcı Güncellenemedi"));
                    databasebaglanti.SaveChanges();
                    return NotFound("kullanıcı bulunamadı");
                }


                kullanıcı.silindimi = false;
                databasebaglanti.kullanicilar.Update(kullanıcı);
                databasebaglanti.loglar.Add(Logger.Loglayıcı("başarılı", "Kullanıcı Güncelle", "Kullanıcı Güncellendi"));
                databasebaglanti.SaveChanges();
                return Ok(kullanıcı);
            }
        }
        [EnableCors("MyCorsImplementationPolicy")]
        [HttpDelete("{id}")]

        public void DeleteKullanıcı(int id)
        {
            using (var databasebaglanti = new DatabaseContext())
            {
                var silinecekkisi = databasebaglanti.kullanicilar.Find(id);
                silinecekkisi.silindimi = true;
                databasebaglanti.loglar.Add(Logger.Loglayıcı("başarılı", "Kullanıcı Sil", "Kullanıcı silindi"));
                databasebaglanti.SaveChanges();

            }


        }

        [HttpGet]
        public  IActionResult Get()
        {
            using (var databasebaglanti = new DatabaseContext())
            {
                
              var kullanici=databasebaglanti.kullanicilar.Where(y => y.silindimi == false).ToList().OrderByDescending(x => x.kullaniciid);
                
                
               return Ok(kullanici);



                

            }
        } 
        


    }
}

