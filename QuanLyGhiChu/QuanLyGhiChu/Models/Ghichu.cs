using System;
using System.Collections.Generic;

namespace QuanLyGhiChu.Models
{
    public partial class Ghichu
    {
        public int Id { get; set; }
        public string HashCode { get; set; }
        public string Token { get; set; }
        public string Title { get; set; }
        public string Context { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime? TimeUpdated { get; set; }
        public byte HienAn { get; set; }
    }
}
