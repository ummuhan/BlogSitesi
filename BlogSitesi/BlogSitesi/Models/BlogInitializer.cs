using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BlogSitesi.Models
{
    public class BlogInitializer:DropCreateDatabaseIfModelChanges<BlogContext>//Bunu yaparken tablolarda değişim olduğunda tabloların silinip tekrar oluşmasını sağlar.
    {
        protected override void Seed(BlogContext context)
        {//Seed metodu test verileri eklememizi sağlamatadır.
            List<Category> Kategoriler = new List<Category>()
            {
                new Category(){KategoriAdi="Dersler"},
                new Category(){KategoriAdi="Videolar"},
                new Category(){KategoriAdi="Programlama Dilleri"},
                new Category(){KategoriAdi="Deneyimler"}
            };
            foreach (var item in Kategoriler)
            {
                context.Kategoriler.Add(item);//Kategorileri tek tek ekledik.
            }
            context.SaveChanges();//Ekleme yaptıktan sonra verileri korumamız gerekmektedir.
            List<Blog> Bloglar = new List<Blog>()
            {
                new Blog(){Baslik="Dersler",EklenmeTarih=DateTime.Now.AddDays(-10),Anasayfa=true,Aciklama="sdsafdfagfdgfldgkjfjgdglfdkalgf",Icerik="aDsfDSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSS",Onay=true,CategoryiId=1},
                new Blog(){Baslik="Dersler",EklenmeTarih=DateTime.Now.AddDays(-10),Anasayfa=true,Aciklama="sdsafdfagfdgfldgkjfjgdglfdkalgf",Icerik="aDsfDSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSS",Onay=true,CategoryiId=1},
                new Blog(){Baslik="Dersler",EklenmeTarih=DateTime.Now.AddDays(-34),Anasayfa=true,Aciklama="sdsafdfagfdgfldgkjfjgdglfdkalgf",Icerik="aDsfDSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSS",Onay=true,CategoryiId=2},
                new Blog(){Baslik="Dersler",EklenmeTarih=DateTime.Now.AddDays(-10),Anasayfa=true,Aciklama="sdsafdfagfdgfldgkjfjgdglfdkalgf",Icerik="aDsfDSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSS",Onay=false,CategoryiId=1},
                new Blog(){Baslik="Dersler",EklenmeTarih=DateTime.Now.AddDays(-68),Anasayfa=true,Aciklama="sdsafdfagfdgfldgkjfjgdglfdkalgf",Icerik="aDsfDSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSS",Onay=true,CategoryiId=2},
                new Blog(){Baslik="Dersler",EklenmeTarih=DateTime.Now.AddDays(-10),Anasayfa=true,Aciklama="sdsafdfagfdgfldgkjfjgdglfdkalgf",Icerik="aDsfDSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSS",Onay=false,CategoryiId=1},
                new Blog(){Baslik="Dersler",EklenmeTarih=DateTime.Now.AddDays(-23),Anasayfa=true,Aciklama="sdsafdfagfdgfldgkjfjgdglfdkalgf",Icerik="aDsfDSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSS",Onay=true,CategoryiId=2},

            };
            foreach (var item in Bloglar)
            {
                context.Bloglar.Add(item);

            }
            context.SaveChanges();
            base.Seed(context);
        }
    }
}