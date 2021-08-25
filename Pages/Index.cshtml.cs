using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public string PlayerSearch { get; set; }



        public IActionResult OnPostButtonSignIn(string playerSearch)
        {
            {

                PlayerSearch = playerSearch;
                var TryFindPlayer = from player in _context.Player where player.Email == PlayerSearch select player;
                Player = TryFindPlayer.FirstOrDefault();
                //Search using direct sql
                //var searchAgain = _context.Player.FromSqlRaw("SELECT * FROM dbo.Player where ").ToList();
                if (Player is null)
                {
                    ModelState.AddModelError("PlayerSearch","Player not registered, please sign up.");
                    return Page();
                }
                else return RedirectToPage("./Welcome", Player);

            }
        }
        [BindProperty]
        public Player Player { get; set; }

        public async Task<IActionResult> OnPostButtonSignUp()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Player.Alive = true;
            Player.PageProgress = 1;
            _context.Player.Add(Player);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Welcome", Player);
        }
    }
}