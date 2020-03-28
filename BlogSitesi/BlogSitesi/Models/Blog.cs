using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogSitesi.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public String Baslik { get; set; }
        public String Aciklama { get; set; }

        public String Resim { get; set; }
        public String Icerik { get; set; }
        public DateTime EklenmeTarih { get; set; }
        public bool Onay { get; set; }
        public bool Anasayfa { get; set; }
        public int CategoryiId { get; set; }

        public  Category Category { get; set; }

    }
}