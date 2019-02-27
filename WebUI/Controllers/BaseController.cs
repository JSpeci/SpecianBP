using Microsoft.AspNetCore.Mvc;
using SpecianBP.Db;

namespace WebUI.Controllers
{
    public class BaseController : Controller
    {
        protected readonly DbService dbService;

        public BaseController(DbService context)
        {
            dbService = context;
        }
    }
}
