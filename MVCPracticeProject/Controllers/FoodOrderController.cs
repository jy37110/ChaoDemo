using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using MVCPracticeProject.Models;
using MVCPracticeProject.Models.FoodOrder;

namespace MVCPracticeProject.Controllers
{
    public class FoodOrderController : Controller
    {
        public ApplicationDbContext DbContext = new ApplicationDbContext();

        public ActionResult Index()
        {
            var model = DbContext.Dishes.ToList();
            return View(model);
        }

        public ActionResult SaveOrderItems(List<string> names, List<string> price, List<string> quantity)
        {
             var orderItems = new List<OrderItem>();
             decimal totalPrice = 0;
            for (var i = 0; i < names.Count(); i++)
            {
                var tempItem = new OrderItem
                {
                    DishName = names[i],
                    Price = Convert.ToDecimal(price[i]),
                    Quantity = Convert.ToInt16(quantity[i])
                };
                totalPrice += Convert.ToDecimal(price[i]);
                orderItems.Add(tempItem);
            }
            Session["orderItems"] = orderItems;
            Session["total"] = totalPrice;
            return Json(new { success = true, responseText = "Your message successfuly sent!" }, JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        public ActionResult OrderInfo()
        {
            var model = new Order();
            return View(model);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult OrderInfo([Bind(Include = "Id,PhoneNumber,Address")] Order order)
        {
            var userId = User.Identity.GetUserId();
            order.User = DbContext.Users.Single(u => u.Id == userId);
            order.Status = "Confirmed";
            order.Subtotal = (decimal) Session["total"];
            order.OrderList = (List<OrderItem>) Session["orderItems"];
            if (ModelState.IsValid)
            {
                DbContext.Orders.Add(order);
                DbContext.SaveChanges();
                return RedirectToAction("MyOrder","FoodOrder");
            }
            var model = new Order();
            return View(model);
        }

        [Authorize]
        public ActionResult MyOrder()
        {
            var userId = User.Identity.GetUserId();
            var model = DbContext.Orders.Where(o => o.User.Id == userId && o.Status == "Confirmed");
            return View(model);
        }

        [Authorize]
        [HttpPost]
        public ActionResult MyOrder(string id)
        {
            Order order = DbContext.Orders.Find(Convert.ToInt32(id));
            order.Status = "Canceled";
            DbContext.Entry(order).State = EntityState.Modified;
            DbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}