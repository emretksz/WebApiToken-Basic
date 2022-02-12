using AspNetBolumler.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace AspNetBolumler.Controllers
{
       [Authorize]
    public class TokenApiController : ApiController
    {
        Models.model1 db = new Models.model1();
        [HttpGet]
        public IQueryable<Employees> Calisanlar()
        {
            return db.Employees;
        }

        [HttpPost]
        public IHttpActionResult CalisanEkle(Employees employees)
        {
            db.Employees.Add(employees);
            db.SaveChanges();
            return Json("Ekleme Başarılı");
        }

        [HttpPut]
        public IHttpActionResult CalisanGuncelle(Employees employees)
        {
            db.Entry(employees).State = EntityState.Modified;
            db.SaveChanges();
            return Json("Güncelleme başarılı");
        }
       [HttpDelete]
       public IHttpActionResult CalisanSil(int id)
        {
            var sil = db.Employees.FirstOrDefault(m => m.EmployeeID == id);
            db.Employees.Remove(sil);
            db.SaveChanges();
            return Json("Başarılı");
        }

    }
}
