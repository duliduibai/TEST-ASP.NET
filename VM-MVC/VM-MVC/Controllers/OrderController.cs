﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VM.Entity;
using VM.Service.OrderDB;
using VM_MVC.Models;

namespace VM_MVC.Controllers
{
    public class OrderController : VmController
    {
        public IOrderService orderService { get; private set; }

        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
            this.AddDisposableObject(orderService);
        }

        // GET: Order
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult ShoppingCart(
            [ModelBinder(typeof(ShoppingCartBinder))] ShoppingCart shoppingCart)
        {
            ///TODO:Model Binder是什么？？？
            return View(shoppingCart);
        }

        [HttpPost]
        public ActionResult ShoppingCart(string productId, string productName, 
            decimal price, [ModelBinder(typeof(ShoppingCartBinder))] ShoppingCart shoppingCart, int number = 1)
        {
            shoppingCart.Add(productId, productName, price, number);
            return View(ShoppingCartBinder.GetShoppingCart());
        }

        [HttpPost]
        public ActionResult Remove(string productId, 
            [ModelBinder(typeof(ShoppingCartBinder))]ShoppingCart shoppingCart)
        {
            ShoppingCartItem item = shoppingCart.Items.FirstOrDefault(o => o.ProductId == productId);
            if (null != item)
            {
                shoppingCart.Items.Remove(item);
            }
            return RedirectToAction("ShoppingCart");
        }

        [Authorize]
        [HandleError(View= "ShoppingCart")]
        public ActionResult CheckOut(
            [ModelBinder(typeof(ShoppingCartBinder))]ShoppingCart shoppingCart)
        {
            Order order = new Order
            {
                OrderID = Guid.NewGuid().ToString(),
                OrderTime = DateTime.Now,
                UserName = User.Identity.Name
            };

            foreach (ShoppingCartItem item in shoppingCart.Items)
            {
                order.OrderLines.Add(new OrderLine
                {
                    Order = order,
                    OrderID = order.OrderID,
                    ProductID = item.ProductId,
                    Quantity = item.Quantity
                });
            }

            this.orderService.SubmitOrder(order);
            ShoppingCartBinder.Clear();
            return View();
        }
    }
}