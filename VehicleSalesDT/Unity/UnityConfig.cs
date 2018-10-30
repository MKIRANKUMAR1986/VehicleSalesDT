using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unity;
using Unity.ResolverPolicy;
using VehicleSalesDT.BusinessLogic;
using VehicleSalesDT.BusinessLogic.Shared;
using VehicleSalesDT.DAL;
using VehicleSalesDT.Unity;
using Unity.Utility;
using VehicleSalesDT.Controllers;
using Unity.WebApi;
using System.Web.Http;

namespace VehicleSalesDT.Unity
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            RegisterWebApiComponents();
            RegisterMvcComponents();
        }
        public static void RegisterWebApiComponents()
        {
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            // Unity configuration
            // e.g. container.RegisterType<ITestService, TestService>();
            var container = RegisterGlobalServices();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
        public static void RegisterMvcComponents()
        {
            var container = RegisterGlobalServices();

            container.RegisterType<IController, SaleController>("sale");

            var factory = new UnityControllerFactory(container);
            ControllerBuilder.Current.SetControllerFactory(factory);
        }
        private static UnityContainer RegisterGlobalServices()
        {
            var container = new UnityContainer();

            container.RegisterType<IBLSale, BLSale>();
            container.RegisterType<IDALSale, DALSale>();

            container.RegisterType<IBLCommon, BLCommon>();
            container.RegisterType<IBLMonthPrice, BLMonthPrice>();
            container.RegisterType<IBLDealerSale, BLDealerSale>();
            container.RegisterType<IBLMonthVehicleSale, BLMonthVehicleSale>();
            container.RegisterType<IBLMonthSale, BLMonthSale>();
            container.RegisterType<IBLVehicle, BLVehicle>();

            return container;
        }
    }

}