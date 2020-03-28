using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogSitesi.Models
{
    public class Category
    {
        public int Id { get; set; }//Tabloda birincil anahtar (primary key) görevi görmektedi Id yazıldığında otomatik algılanır.
        public String KategoriAdi { get; set; }
        public List<Blog> blogs { get; set; }//Tabloda bir değişiklik yapmamaktadır.
    }
}