﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Unity;
using VehicleSalesDT.BusinessLogic;
using VehicleSalesDT.BusinessLogic.Shared;
using VehicleSalesDT.Controllers;
using VehicleSalesDT.DAL;
using VehicleSalesDT.Unity;

namespace VehicleSalesDT
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            UnityConfig.RegisterMvcComponents();
            UnityConfig.RegisterWebApiComponents();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
