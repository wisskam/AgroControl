using AgroControl.DBContexts;
using AgroControl.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgroControl.ViewComponents
{
    public class DeleteModalViewComponent : ViewComponent
    {
        private readonly GospodarstwoContext _context;

        public DeleteModalViewComponent(GospodarstwoContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
