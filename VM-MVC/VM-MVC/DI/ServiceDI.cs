using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VM.Service.ProductDB;

namespace VM_MVC.DI
{
    public static class ServiceDI
    {
        public static void RegisterService(this ContainerBuilder builder)
        {
            builder.RegisterType<ProductService>().InstancePerRequest();
        }
    }
}