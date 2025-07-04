using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    public interface IPortfolioRepository
    {
        Task<List<Stock>> GetUserPortfolio(AppUser user);
        Task<Portifolio> CreateAsync(Portifolio portfolio);
        Task<Portifolio> DeletePortfolio(AppUser appUser, string symbol);
    }
}