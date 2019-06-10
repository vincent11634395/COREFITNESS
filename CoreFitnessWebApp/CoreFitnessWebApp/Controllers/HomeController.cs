using CoreFitnessWebApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CoreFitnessWebApp.Controllers
{
    public class HomeController : Controller
    {
        //CoreFitnessWebAppContext db = new CoreFitnessWebAppContext();
        // GET: Home
        public ActionResult Index()
        {
            CoreFitnessWebAppContext db = new CoreFitnessWebAppContext();
            var productList = new List<Product>();
            try
            {
                productList = db.Products.ToList();
            }
            catch (Exception ex)
            {

            }
            return View(productList);
        }

        public ActionResult ViewProduct(int id)
        {
            CoreFitnessWebAppContext db = new CoreFitnessWebAppContext();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product productDetails = db.Products.Find(id);
            if (productDetails == null)
            {
                return HttpNotFound();
            }
            return View(productDetails);
        }

        public JsonResult AddToCart(ShoppingCart shoppingCart)
        {
            CoreFitnessWebAppContext db = new CoreFitnessWebAppContext();
            try
            {
                db.ShoppingCarts.Add(shoppingCart);
                db.SaveChanges();
                return Json(new
                {
                    result = "Product added to cart successfully.",
                    redirectUrl = Url.Action("Index", "Home"),
                    isRedirect = true
                });
            }
            catch (RetryLimitExceededException /* dex */)
            {
                return Json(new
                {
                    result = "Product could not be added to cart, please try again later."
                });
            }

        }

        public ActionResult ViewCart()
        {
            CoreFitnessWebAppContext db = new CoreFitnessWebAppContext();
            var shoppingCartList = new List<ShoppingCart>();
            try
            {
                 var listOfIds = (from n in db.ShoppingCarts where n.sessionID == 10 select n);
                foreach(ShoppingCart cart in listOfIds)
                {
                    shoppingCartList.Add(cart);
                }
            }
            catch (Exception ex)
            {

            }
            return View(shoppingCartList);
        }

        public ActionResult RemoveItem(string id)
        {
            CoreFitnessWebAppContext db = new CoreFitnessWebAppContext();

            var split = id.Split('T');
            int sessionID = Convert.ToInt32(split[1]);
            int idProduct = Convert.ToInt32(split[0]);

            var itemToRemove = db.ShoppingCarts.SingleOrDefault(x => x.sessionID == sessionID && x.idProduct==idProduct); 

            if (itemToRemove != null)
            {
                    db.ShoppingCarts.Remove(itemToRemove);
                    db.SaveChanges();
            }
            return RedirectToAction("ViewCart");
        }
    }
}