using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using FizzBuzzNET.Data;
using FizzBuzzNET.Models;
using FizzBuzzNET.Pages.Results;
namespace FizzBuzzNET.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly FBContext _context;

        [BindProperty]
        public FizzBuzz FizzBuzzResult { get; set; }


        //public IList<FizzBuzz> FBResults { get; set; }

        public IndexModel(ILogger<IndexModel> logger, FBContext context)
        {
            _logger = logger;
            _context = context;
        }

        public void OnGet()
        {
            //FBResults = _context.FizzBuzz.ToList();
        }
        public async Task<IActionResult> OnPost()
        {
            
            //if( ModelState.IsValid )
            //{
                int temp;
                if (Int32.TryParse(FizzBuzzResult.NumberStr, out temp))
                { 
                    FizzBuzzResult.Number = temp;
                    if (FizzBuzzResult.Number >= 1 && FizzBuzzResult.Number <= 1000)
                    {
                        if (FizzBuzzResult.Number % 3 == 0 && FizzBuzzResult.Number % 5 == 0)
                            FizzBuzzResult.Wynik = "FizzBuzz";
                        else if (FizzBuzzResult.Number % 3 == 0)
                            FizzBuzzResult.Wynik = "Fizz";
                        else if (FizzBuzzResult.Number % 5 == 0)
                            FizzBuzzResult.Wynik = "Buzz";
                        else FizzBuzzResult.Wynik = "None";

                        FizzBuzzResult.Czas = DateTime.Now;
                        HttpContext.Session.SetString("SessionAddress", JsonConvert.SerializeObject(FizzBuzzResult));
                        if (ModelState.IsValid)
                        {
                            await _context.FizzBuzz.AddAsync(FizzBuzzResult);
                            await _context.SaveChangesAsync();
                            return Page();
                        }
                    }
                else { FizzBuzzResult.Wynik = "Error"; }
            }
            //}
            else { FizzBuzzResult.Wynik = "Error"; }
            return Page();
        }
    }
}
