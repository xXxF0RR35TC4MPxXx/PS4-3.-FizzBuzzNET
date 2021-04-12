using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FizzBuzzNET.Models
{
    public class FizzBuzz
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Wartość w polu jest wymagana!")]
        public String NumberStr { get; set; }
        
        public int Number { get; set; }
        
        public String Wynik { get; set; }
        
        public DateTime Czas { get; set; }
    }
}
