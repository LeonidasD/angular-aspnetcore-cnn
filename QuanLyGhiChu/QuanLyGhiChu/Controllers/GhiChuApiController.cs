using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language.CodeGeneration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using QuanLyGhiChu.Models;

namespace QuanLyGhiChu.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class GhiChuApiController : Controller
    {
        private QuanLyGhiChuContext db;

        [HttpPost("[action]")]
        public async Task<IActionResult> Create(string data)
        {
            dynamic results = JsonConvert.DeserializeObject<dynamic>(data);
            string title = results.title;
            string context = results.context;
            string hashString = Guid.NewGuid().ToString().Replace("-", "");
            DateTime dt = DateTime.Now;
            string timeNow = dt.ToString("yyMdhhmm");

            var list = new List<Ghichu>();
           



            //var item = new Ghichu
            //{
            //    HashCode = hashString.Substring(0, 6) + timeNow,
            //    Token = hashString,
            //    Title = title,
            //    Context = context,
            //    TimeCreated = dt,
            //    TimeUpdated = dt,
            //    HienAn = 1
            //};

            db.Ghichu.Add(item);
            await db.SaveChangesAsync();

            return Content("OK");
            JObject jsonString = new JObject(
                    new JProperty("status", "200"),
                    new JProperty("message", "Tạo ghi chú thành công")
                );
            return Content(jsonString.ToString());
        }
    }
}