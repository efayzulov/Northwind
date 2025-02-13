﻿using Ninject;
using Ninject.Web.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;

namespace Northwind.WebApi.Models
{
    public class NinjectDependencyResolver : NinjectDependencyScope, IDependencyResolver
    {
        private readonly IKernel kernel;
        public NinjectDependencyResolver(IKernel kernel) : base(kernel)
        {
            this.kernel = kernel;
        }
        public IDependencyScope BeginScope()
        {
            return new NinjectDependencyScope((IKernel)kernel.BeginBlock());
        }
    }
}