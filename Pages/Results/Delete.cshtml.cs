﻿using System;
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
    public class DeleteModel : PageModel
    {
        private readonly FizzBuzzNET.Data.FBContext _context;

        public DeleteModel(FizzBuzzNET.Data.FBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public FizzBuzz FizzBuzz { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            FizzBuzz = await _context.FizzBuzz.FirstOrDefaultAsync(m => m.Id == id);

            if (FizzBuzz == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            FizzBuzz = await _context.FizzBuzz.FindAsync(id);

            if (FizzBuzz != null)
            {
                _context.FizzBuzz.Remove(FizzBuzz);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
