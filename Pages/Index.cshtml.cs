using FizzBuzzNET.Pages.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
namespace FizzBuzzNET.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        [BindProperty]
        public Result FizzBuzzResult { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                int temp; Boolean dalej;
                dalej = Int32.TryParse(FizzBuzzResult.NumberStr, out temp);
                if(dalej==true)
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
                    }
                    else { FizzBuzzResult.Wynik = "Error"; }
                }
                else { FizzBuzzResult.Wynik = "Error"; }
            }
            else { FizzBuzzResult.Wynik = "Error"; }
            return Page();
        }
    }
}
