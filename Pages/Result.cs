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

        //[Range(1, 1000, ErrorMessage = "Podana liczba musi należeć do przedziału 1-1000!")]
        public int Number { get; set; }
        public String Wynik { get; set; }
        public DateTime Czas { get; set; }

    }
}
