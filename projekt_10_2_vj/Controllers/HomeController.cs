using Newtonsoft.Json;
using projekt_10_2_vj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace projekt_10_2_vj.Controllers
{
    public class HomeController : Controller
    {
        KolegijREST service = new KolegijREST();

        // GET: Home
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            IEnumerable<Kolegij> all = await service.dohvatiKolegijeAsync()  ;

            return View(all);
        }

        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            Kolegij koleg = await service.dohvatiKolegijByIdAsync(id);

            return View(koleg);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Kolegij kolegij)
        {
            await service.kreirajKolegijAsync(kolegij);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            Kolegij koleg = await service.dohvatiKolegijByIdAsync(id);

            return View(koleg);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Kolegij kolegij)
        {
            Kolegij koleg = await service.kreirajKolegijAsync(kolegij);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            var respone = await service.DeleteKolegijAsync(id);

            return RedirectToAction("Index");
        }


    }

    public class KolegijREST
    {
        readonly string uri = "http://localhost:63749/api/";

        public async Task<IEnumerable<Kolegij>> dohvatiKolegijeAsync()
        {
            using (var client = new HttpClient())
            {
                var rezult = JsonConvert.DeserializeObject<IEnumerable<Kolegij>>(await client.GetStringAsync(uri + "Kolegijs"));

                return rezult;
            }
        }

        public async Task<Kolegij> dohvatiKolegijByIdAsync(int id)
        {
            using (var client = new HttpClient())
            {
                var rezult = JsonConvert.DeserializeObject<Kolegij>(await client.GetStringAsync(uri + "Kolegijs/" + id));
               
                return rezult;
            }
        }

        public async Task<Kolegij> kreirajKolegijAsync(Kolegij kolegij)
        {
            using (var client = new HttpClient())
            {
                var rezult = JsonConvert.SerializeObject(await client.PostAsJsonAsync(uri + "Kolegijs", kolegij));

                return kolegij;
            }
        }

        public async Task<Kolegij> PutKolegijAsync(Kolegij kolegij)
        {
            using (var client = new HttpClient())
            {
                var rezult = JsonConvert.SerializeObject(await client.PutAsJsonAsync(uri + "Kolegijs/" + kolegij.Id, kolegij));

                return kolegij;
            }
        }


        public async Task<HttpResponseMessage> DeleteKolegijAsync(int id)
        {
            using (var client = new HttpClient())
            {
                var respone = await client.DeleteAsync(uri + "Kolegijs/" + id);
                return respone;
            }
        }




    }
}