using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using BlogSitesi.Models;

namespace BlogSitesi.Controllers
{
    /*
    WebApiConfig sınıfı bu denetleyici için yol eklemek için ek değişiklikler gerektirebilir. Bu deyimleri uygun olduğu şekilde WebApiConfig sınıfının Register yöntemiyle birleştirin. OData URL'lerinin büyük/küçük harfe duyarlı olduğunu unutmayın.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using BlogSitesi.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Category>("Categories");
    builder.EntitySet<Blog>("Bloglar"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class CategoriesController : ODataController
    {
        private BlogContext db = new BlogContext();

        // GET: odata/Categories
        [EnableQuery]
        public IQueryable<Category> GetCategories()
        {
            return db.Kategoriler;
        }

        // GET: odata/Categories(5)
        [EnableQuery]
        public SingleResult<Category> GetCategory([FromODataUri] int key)
        {
            return SingleResult.Create(db.Kategoriler.Where(category => category.Id == key));
        }

        // PUT: odata/Categories(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<Category> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Category category = db.Kategoriler.Find(key);
            if (category == null)
            {
                return NotFound();
            }

            patch.Put(category);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(category);
        }

        // POST: odata/Categories
        public IHttpActionResult Post(Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Kategoriler.Add(category);
            db.SaveChanges();

            return Created(category);
        }

        // PATCH: odata/Categories(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Category> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Category category = db.Kategoriler.Find(key);
            if (category == null)
            {
                return NotFound();
            }

            patch.Patch(category);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(category);
        }

        // DELETE: odata/Categories(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            Category category = db.Kategoriler.Find(key);
            if (category == null)
            {
                return NotFound();
            }

            db.Kategoriler.Remove(category);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/Categories(5)/blogs
        [EnableQuery]
        public IQueryable<Blog> Getblogs([FromODataUri] int key)
        {
            return db.Kategoriler.Where(m => m.Id == key).SelectMany(m => m.blogs);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CategoryExists(int key)
        {
            return db.Kategoriler.Count(e => e.Id == key) > 0;
        }
    }
}
