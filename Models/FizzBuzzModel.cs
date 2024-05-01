using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FizzBuzzAPP.Services;
using System.ComponentModel.DataAnnotations;

namespace FizzBuzzAPP.Models
{
    public class FizzBuzzModel : PageModel
    {
        private readonly FizzBuzzService _fizzBuzzService;

        public FizzBuzzModel(FizzBuzzService fizzBuzzService)
        {
            _fizzBuzzService = fizzBuzzService;
        }
        [BindProperty]
        [Required, Range(1, 1000)]
        public int InputValue { get; set; }

      
        public List<string> FizzBuzzResults { get; set; } = new List<string>();

        [BindProperty]
        public int StartIndex { get; set; } = 0;
        [BindProperty]
        public int EndIndex { get; set; } = 20;

        public void OnGet()
        {
            // Optional: Initialize any default values
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            
            FizzBuzzResults = _fizzBuzzService.GenerateFizzBuzzResults(InputValue);
            return Page();
        }
        public IActionResult OnGetPrevious()
        {
            if (StartIndex >= 20)
            {
                StartIndex -= 20;
                EndIndex -= 20;
            }
            return Page();
        }
        public IActionResult OnGetNext()
        {
            if (FizzBuzzResults != null)
            {
                // Calculate the next page indices
                int pageSize = 20; 
                int newStartIndex = StartIndex + pageSize;
                int newEndIndex = Math.Min(EndIndex + pageSize, FizzBuzzResults.Count);

                // Update indices only if the new end index is within bounds
                if (newEndIndex <= FizzBuzzResults.Count)
                {
                    StartIndex = newStartIndex;
                    EndIndex = newEndIndex;
                }
            }

            return Page();
        }
    }
}
