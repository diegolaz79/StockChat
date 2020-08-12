using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StockChat.Data;
using StockChat.Models;

namespace StockChat.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public readonly ApplicationDbContext _context;
        public readonly UserManager<ChatUser> _userManager;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, UserManager<ChatUser> userManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.CurrentUserName = currentUser.UserName;                
            }
            var messages = await _context.Messages.ToListAsync();
            return View(messages);
        }

        public async Task<IActionResult> Create(Message msg)//string msgText)
        {
            var now = new DateTime();
            //Message msg = new Message();
            if (ModelState.IsValid && msg != null && msg.Text.Length > 0)
            {
                if (msg.Text.Contains("/stock="))
                {
                    return Ok();
                }
                msg.UserName = User.Identity.Name;
                /*
                if (msg.Text.Contains("/stock="))
                {
                    string quote = msg.Text.Replace("/stock=", "");
                    StockBot bot = new StockBot();
                    msg.Text = bot.GetQuote(quote);
                    //StockBot stockBot = new StockBot();
                    //msg.Text = result;
                }
                */
                var sender = await _userManager.GetUserAsync(User);
                msg.UserID = sender.Id;
                await _context.Messages.AddAsync(msg);
                await _context.SaveChangesAsync();
                return Ok();
            }            
            return Error();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
