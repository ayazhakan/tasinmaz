using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using tasinmaz_backend.Models;

namespace tasinmaz_backend.Controllers
{


    [Route("api/login")]
    [ApiController]
    public class LoginController : Controller
    {
        [EnableCors("MyCorsImplementationPolicy")]
        [HttpPost]

        public IActionResult Get(Login model)
        {

            using (var databasebaglanti = new DatabaseContext())
            {


                var gelenKullanicilar = databasebaglanti.kullanicilar.Where(y => y.silindimi == false).ToList();

                foreach (var kullanici in gelenKullanicilar)
                {

                    if (kullanici.email == model.email && kullanici.sifre == model.sifre)
                    {

                        databasebaglanti.loglar.Add(Logger.Loglayıcı("başarılı", kullanici.email + " logged in", "Giriş yapıldı"));
                        databasebaglanti.SaveChanges();
                        return Ok(kullanici);

                    }


                }


                databasebaglanti.loglar.Add(Logger.Loglayıcı("başarısız", " email veya sifre hatali", "Giriş yapılamadı"));
                databasebaglanti.SaveChanges();
                return BadRequest("email veya sifre hatali");




            }
        }
    }
}