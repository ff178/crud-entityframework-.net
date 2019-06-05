using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUD_EntityFramework.Models;
using CRUD_EntityFramework.Models.ViewModels;

namespace CRUD_EntityFramework.Controllers
{
    public class productsController : Controller
    {
        //
        // GET: /products/
        public ActionResult Index()
        {
            List<ListTablaViewModels> lst;
            using (EntityFrameworkTestEntities2 db = new EntityFrameworkTestEntities2())
            {
                lst = (from d in db.products
                           select new ListTablaViewModels
                           {
                               Id = d.ID,
                               Product = d.PRODUCT,
                               Quantity = d.QUANTITY,
                               Modified_Date = d.MODIFIED_DATE.Value
                           }).ToList();
            }
            return View(lst);
        }

        public ActionResult Nuevo() 
        {
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(TablaViewModels model)
        {
            try 
            {
                if (ModelState.IsValid) 
                {
                    using (EntityFrameworkTestEntities2 db = new EntityFrameworkTestEntities2()) 
                    {
                        var oProduct = new products();
                        oProduct.PRODUCT = model.Product;
                        oProduct.QUANTITY = model.Quantity;
                        oProduct.MODIFIED_DATE = model.Modified_Date;

                        db.products.Add(oProduct);
                        db.SaveChanges();
                    }
                    return Redirect("~/products/");
                }
                return View(model);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ActionResult Editar(int Id)
        {
            TablaViewModels model = new TablaViewModels();
            using(EntityFrameworkTestEntities2 db = new EntityFrameworkTestEntities2())
            {
                var oProduct = db.products.Find(Id);
                model.Product = oProduct.PRODUCT;
                model.Quantity = oProduct.QUANTITY;
                model.Modified_Date = oProduct.MODIFIED_DATE.Value;
                model.Id = oProduct.ID;
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Editar(TablaViewModels model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (EntityFrameworkTestEntities2 db = new EntityFrameworkTestEntities2())
                    {
                        var oProduct = db.products.Find(model.Id);
                        oProduct.PRODUCT = model.Product;
                        oProduct.QUANTITY = model.Quantity;
                        oProduct.MODIFIED_DATE = model.Modified_Date;

                        db.Entry(oProduct).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    return Redirect("~/products/");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult Eliminar(int Id)
        {
            using (EntityFrameworkTestEntities2 db = new EntityFrameworkTestEntities2())
            {
                var oProduct = db.products.Find(Id);
                db.products.Remove(oProduct);
                db.SaveChanges();
            }
            return Redirect("~/products/");
        }
	}
}