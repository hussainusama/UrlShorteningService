﻿using System.Threading.Tasks;

namespace UrlShorteningService.Models
{
    public interface IUrlMapRepository
    {
        Task<int> InsertAsync(string longUrl);
        Task<string> GetByIdAsync(int id);
    }
}