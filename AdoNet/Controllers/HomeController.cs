using AdoNet.Helpers;
using AdoNet.Models;
using AdoNet.Services.Implements;
using AdoNet.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace AdoNet.Controllers
{
    public class HomeController : Controller
    {

        public async Task<IActionResult> Index()
        {
            List<Filial> Filiales = new List<Filial>();
            DataTable dt = await SqlHelper.SelectAsync("SELECT * FROM Filial");
            foreach (DataRow item in dt.Rows)
            {
                Filiales.Add(new()
                {
                    Id = (int)item[0],
                    Name = (string)item[1]
                });
            }
            return View(Filiales);


        }
        [HttpPost]
        public async Task<IActionResult> Filial(string name)
        {
            var res = await SqlHelper.ExecuteAsync($"INSERT INTO Filial VALUES ('{name}')");
            return Content(res.ToString());
        }
        public async Task<IActionResult> FilialGetAll()
        {
            IFilialService service = new FilialService();
            return Json(await service.GetAllAsync());
        }
        public async Task<IActionResult> FilialGetById(int id)
        {
            IFilialService service = new FilialService();
            return Json(await service.GetByIdAsync(id));
        }
        


    }
}