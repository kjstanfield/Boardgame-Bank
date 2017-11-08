using System.Collections.Generic;
using System.Web.Mvc;

namespace BoardgameBank.Controllers
{
    public class AddGameViewModel
    {
        public string GameName { get; set; }
        public int PlayerCount { get; set; }
        public string PlayTime { get; set; }
        public int[] Categories { get; set; }

        public List<SelectListItem> AllCategories { get; set; }
        public List<SelectListItem> AllPlayerCounts { get; set; }
    }
}