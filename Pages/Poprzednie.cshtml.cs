using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using FizzBuzzNET.Pages.Forms;


namespace FizzBuzzNET.Pages
{
    public class PoprzednieModel : PageModel
    {
        public Result FizzBuzzResult { get; set; }
        public void OnGet()
        {
            var SessionValue = HttpContext.Session.GetString("SessionAddress");
            if (SessionValue != null)
                FizzBuzzResult = JsonConvert.DeserializeObject<Result>(SessionValue);
        }
    }
}
