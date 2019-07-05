using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VM.Repository;

namespace VM_MVC.DI
{
    public static class RepositoryDI
    {
        public static void RegisterRepository(this ContainerBuilder builder)
        {
            builder.RegisterType<ProductRepository>().InstancePerRequest();
        }
    }
}