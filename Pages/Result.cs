using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FizzBuzzNET.Pages.Forms
{
    public class Result
    {
        [Display(Name = "Podaj liczbę")]
        public String NumberStr { get; set; }
        public int Number { get; set; }
        public String Wynik { get; set; }
        public DateTime Czas { get; set; }

    }
}
