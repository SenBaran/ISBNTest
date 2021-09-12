using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SnQPayWithFun.Contracts.Persistence.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnQPayWithFun.WebApi.Controllers.Persistence
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : GenericController<IBook, Transfer.Models.Book>
    {
    }
}
