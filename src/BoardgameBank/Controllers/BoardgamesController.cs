using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BoardgameBank.Controllers
{
    public class BoardgamesController : Controller
    {
        public ActionResult Search()
        {
            return new ContentResult()
            {
                Content = "Hello from the comic books controller!"
            };
        }
    }
}