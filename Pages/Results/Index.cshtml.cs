using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FizzBuzzNET.Data;
using FizzBuzzNET.Models;

namespace FizzBuzzNET.Pages.Results
{
    public class IndexModel : PageModel
    {
        private readonly FizzBuzzNET.Data.FBContext _context;

        public IndexModel(FizzBuzzNET.Data.FBContext context)
        {
            _context = context;
        }

        public IList<FizzBuzz> FizzBuzz { get;set; }

        public void OnGet()
        {

            FizzBuzz = _context.FizzBuzz.OrderByDescending(u => u.Czas).Take(10).ToList();
        }
    }
}
