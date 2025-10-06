using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Extensions;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace api.Controller
{
    [Route("api/portfolio")]
    [ApiController]
    public class PortfolioController : ControllerBase
    {
        private readonly IStockRepository _stockRepo;
        private readonly IPortfolioRepository _portfolioRepo;
        private readonly UserManager<AppUser> _userManager;
        public PortfolioController(UserManager<AppUser> userManager,
        IStockRepository stockRepository,IPortfolioRepository portfolioRepo
        )
        {
            _stockRepo = stockRepository;
            _portfolioRepo = portfolioRepo;
            _userManager = userManager;
        }

        [HttpGet]
        [Authorize]

        public async Task<IActionResult> GetUserPortfolio()
        {
            var username = User.GetUserName();
            var AppUser = await _userManager.FindByNameAsync(username);
            var userPortfolio = await _portfolioRepo.GetUserPortfolio(AppUser);
            return Ok(userPortfolio);


        }

    }
}