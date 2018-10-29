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

namespace VehicleSalesDT.Unity
{
    public static class UnityConfig
    {
        private static readonly UnityContainer _container = new UnityContainer();

        public static void RegisterComponents()
        {            
            // register all your components with the container here 
            // it is NOT necessary to register your controllers 

            // e.g. container.RegisterType<ITestService, TestService>(); 

            _container.RegisterType<BLCommon>();
            _container.RegisterType<IDALSale, DALSale>();

            _container.RegisterType<BLSale>();
            _container.RegisterType<IBLSale, BLSale>();

        }
        public static T Retrieve<T>()
        {
            return _container.Resolve<T>();
        }
    }
}