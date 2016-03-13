using ProductSample.Models;
using ProductSample.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ProductSample.Controllers
{
    public class ProductController : BaseController
    {
        //ProductRepository repo = RepositoryHelper.GetProductRepository();

        // GET: Product
        public ActionResult Index()
        {
            var data = repo.All().Take(5);

            //var data = repo.Get超級複雜的資料集();

            //var repoOL = RepositoryHelper.GetOrderLineRepository(repo.UnitOfWork);

            return View(data);
        }

        [HttpPost]
        public ActionResult Index(IList<ProductIndexViewModel> data)
        {
            if (ModelState.IsValid)
            {
                foreach (var item in data)
                {
                    var product = repo.Find(item.ProductId);
                    product.Stock = item.Stock;
                    product.Price = item.Price;
                }

                repo.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }

            return View(repo.All().Take(5));
        }

        // GET: Product/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var product = repo.Find(id);

            if (product == null)
            {
                return HttpNotFound();
            }
            //ViewData["OrderLines"] = product.OrderLine.ToList();
            ViewBag.OrderLines = product.OrderLine.ToList();

            return View(product);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,ProductName,Price,Active,Stock")] Product product)
        {
            if (ModelState.IsValid)
            {
                repo.Add(product);
                repo.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = repo.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Product/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        //這邊放入FormCollection 純粹是要與GET方法分開 做判斷用的
        public ActionResult Edit(int id, FormCollection form)
        {
            //[Bind(Include = "ProductId,ProductName,Price,Active,Stock")] Product product

            //Product product = repo.Find(id);

            //if (ModelState.IsValid)
            //{
            //    var db = (FabricsEntities)repo.UnitOfWork.Context;
            //    db.Entry(product).State = EntityState.Modified;
            //    db.SaveChanges();

            //    TempData["ProductsEditDoneMsg"] = "商品編輯成功";

            //    return RedirectToAction("Index");
            //}

            ////延遲驗證:先找到資料，再做model binding
            //if(TryUpdateModel<Product>(product, new string[] {
            //    "ProductId","ProductName","Price","Active","Stock" }))
            //{
            //    repo.UnitOfWork.Commit();

            //    TempData["ProductsEditDoneMsg"] = "商品編輯成功";

            //    return RedirectToAction("Index");
            //}

            IProduct product = repo.Find(id);

            if (TryUpdateModel<IProduct>(product))
            {
                repo.UnitOfWork.Commit();

                TempData["ProductsEditDoneMsg"] = "商品編輯成功";

                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var product = repo.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var product = repo.Find(id);
            product.IsDeleted = true;
            repo.UnitOfWork.Commit();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                var db = (FabricsEntities)repo.UnitOfWork.Context;
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
