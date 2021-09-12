using SnQPayWithFun.Contracts.Persistence.App;
using SnQPayWithFun.Logic.Contracts;
using SnQPayWithFun.Logic.Controllers.Business;
using SnQPayWithFun.Logic.Entities.Persistence.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnQPayWithFun.Logic.Controllers.Persistence.BookController
{
    class BookController : GenericPersistenceController<IBook, Book>
    {
        public BookController(IContext context) : base(context)
        {
        }

        public BookController(ControllerObject other) : base(other)
        {
        }

        protected override Book BeforeInsert(Book entity)
        {
            if (BookLogic.CheckISBNNumber(entity.ISBNNumber))
            {
                return base.BeforeInsert(entity);
            }
            throw new ArgumentException("Angegebene ISBN Nummer falsch!");
        }

        protected override Book BeforeUpdate(Book entity)
        {
            if (BookLogic.CheckISBNNumber(entity.ISBNNumber))
            {
                return base.BeforeUpdate(entity);
            }
            throw new ArgumentException("Angegebene ISBN Nummer Falsch!");
        }
    }
}
