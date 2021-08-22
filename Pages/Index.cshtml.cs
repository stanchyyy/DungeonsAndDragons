using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DungeonsAndDragons.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly Data.DungeonsAndDragonsContext _context;

        public IndexModel(ILogger<IndexModel> logger, Data.DungeonsAndDragonsContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }


        [BindProperty]
        public Player Player { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Player.Alive = true;
            Player.PageProgress= 1;
            _context.Player.Add(Player);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Welcome", Player);
        }
    }
}