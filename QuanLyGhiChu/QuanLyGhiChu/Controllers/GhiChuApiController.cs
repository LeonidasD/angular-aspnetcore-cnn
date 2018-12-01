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
        private readonly QuanLyGhiChuContext _context;

        public GhiChuApiController(QuanLyGhiChuContext context)
        {
            _context = context;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create(string data)
        {
            dynamic results = JsonConvert.DeserializeObject<dynamic>(data);
            string title = results.title;
            string context = results.context;

            string token = Guid.NewGuid().ToString().Replace("-", "");
            string hashCode = token.Substring(0, 10);
            DateTime dt = DateTime.Now;

            var item = new Ghichu
            {
                HashCode = hashCode,
                Token = token,
                Title = title,
                Context = context,
                TimeCreated = dt,
                TimeUpdated = null,
                HienAn = 1
            };

            await _context.Ghichu.AddAsync(item);
            await _context.SaveChangesAsync();

            JObject jsonString = new JObject(
                    new JProperty("status", "200"),
                    new JProperty("message", "Tạo ghi chú thành công"),
                    new JProperty("code", hashCode),
                    new JProperty("token", token)
                );

            return Content(jsonString.ToString());
        }
    }
}