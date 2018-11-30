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
using QuanLyGhiChu.Models;

namespace QuanLyGhiChu.Controllers
{
    [Produces("application/json")]
    [Route("api/GhiChu")]
    public class GhiChuApiController : ControllerBase
    {
        private readonly QuanLyGhiChuContext _context;

        public async Task<IActionResult> Create(string title, string context)
        {
            string md5String = Encoding.ASCII.GetString(MD5.Create().ComputeHash(Encoding.ASCII.GetBytes(title)));
            DateTime dt = DateTime.Now;
            string timeNow = dt.ToString("yyMdhhmm");

            var item = new Ghichu
            {
                HashCode = md5String.Substring(0, 6) + "_" + timeNow,
                Token = md5String,
                Title = title,
                Context = context,
                TimeCreated = dt,
                TimeUpdated = null,
                HienAn = 1
            };

            _context.Ghichu.Add(item);
            await _context.SaveChangesAsync();

            return  JsonConvert.
        }
    }
}