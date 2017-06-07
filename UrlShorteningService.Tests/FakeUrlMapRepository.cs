using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShorteningService.Models;

namespace UrlShorteningService.Tests
{
    class FakeUrlMapRepository : IUrlMapRepository
    {
        Dictionary<int, string> mappings = new Dictionary<int, string>();
        int i = 0;

        public FakeUrlMapRepository(int identitySeed)
        {
            i = identitySeed;
        }

        public Task<string> GetByIdAsync(int id)
        {
            return Task.FromResult(mappings[id]);
        }

        public Task<int> InsertAsync(string longUrl)
        {
            mappings.Add(++i, longUrl);
            return Task.FromResult(i);
        }
    }
}
