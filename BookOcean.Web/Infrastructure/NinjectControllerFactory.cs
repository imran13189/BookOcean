using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Ninject;
using System.Web.Mvc;
using BookOcean.Repository.Abstract;
using BookOcean.Repository.Concrete;

namespace BookOcean.WebUI.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {

        private IKernel _kernel;

        public NinjectControllerFactory()
        {
            _kernel = new StandardKernel();
            AddBindings();

        }

        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)this._kernel.Get(controllerType);
        }


        private void AddBindings()
        {
            this._kernel.Bind<IStandard>().To<StandardRepo>();
            this._kernel.Bind<IBook>().To<BookRepo>();
            this._kernel.Bind<IUser>().To<UserRepo>();


        }
    }
}