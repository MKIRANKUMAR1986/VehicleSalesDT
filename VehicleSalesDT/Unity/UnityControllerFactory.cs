using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unity;
using System.Web.Routing;

namespace VehicleSalesDT.Unity
{
    public class UnityControllerFactory : IControllerFactory
    {
        private IUnityContainer _container;
        private IControllerFactory _innerFactory;

        public UnityControllerFactory(IUnityContainer container)
            : this(container, new DefaultControllerFactory())
        {
        }

        protected UnityControllerFactory(IUnityContainer container, IControllerFactory innerFactory)
        {
            _container = container;
            _innerFactory = innerFactory;
        }

        public IController CreateController(RequestContext requestContext, string controllerName)
        {
            if (_container.IsRegistered<IController>(controllerName.ToLower()))
            {
                return _container.Resolve<IController>(controllerName.ToLower());
            }
            else
            {
                return _innerFactory.CreateController(requestContext, controllerName);
            }
        }

        public void ReleaseController(IController controller)
        {
            IDisposable dispose = controller as IDisposable;

            if (dispose != null)
            {
                dispose.Dispose();
            }
        }

        public System.Web.SessionState.SessionStateBehavior GetControllerSessionBehavior(RequestContext requestContext, string controllerName)
        {
            return System.Web.SessionState.SessionStateBehavior.Default;
        }


    }
}