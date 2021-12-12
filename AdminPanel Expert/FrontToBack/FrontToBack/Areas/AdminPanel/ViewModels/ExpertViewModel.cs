using FrontToBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontToBack.Areas.AdminPanel.ViewModels
{
    public class ExpertViewModel
    {
        public List<Expert> Experts  { get; set; }

        public ExpertText ExpertText { get; set; }
    }
}
