using CommonBase.Extensions;
using SnQPayWithFun.Contracts;
using SnQPayWithFun.Contracts.Client;
using SnQPayWithFun.Contracts.Persistence.App;
using SnQPayWithFun.Logic.Contracts;
using SnQPayWithFun.Logic.Controllers;
using SnQPayWithFun.Logic.Controllers.Persistence.BookController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnQPayWithFun.Logic
{
    partial class Factory
    {

        static partial void CreateController<C>(ControllerObject controllerObject, ref IControllerAccess<C> controller) where C : IIdentifiable
        {
            controllerObject.CheckArgument(nameof(controllerObject));

            if (typeof(C) == typeof(IBook))
            {
                controller = new BookController(controllerObject) as IControllerAccess<C>;
            }

        }

        static partial void CreateController<C>(IContext context, ref IControllerAccess<C> controller) where C : IIdentifiable
        {

            if (typeof(C) == typeof(IBook))
            {
                controller = new BookController(context) as IControllerAccess<C>;
            }
        }

    }
}
