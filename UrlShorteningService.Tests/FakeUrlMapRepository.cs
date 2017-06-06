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
        Dictionary<int, UrlMap> mappings = new Dictionary<int, UrlMap>();
        int i = 0;

        public FakeUrlMapRepository(int identitySeed)
        {
            i = identitySeed;
        }

        public void Delete(UrlMap entity)
        {
            mappings.Remove(entity.Id);
        }

        public UrlMap GetById(int id)
        {
            return mappings[id];
        }

        public void Insert(UrlMap entity)
        {
            if (mappings.Values.ToList().Contains(entity))
            {
                foreach (var map in mappings)
                {
                    if (map.Value == entity) entity = map.Value;
                    break;
                }
            }
            else
            {
                entity.Id = ++i;
                mappings.Add(entity.Id, entity);
            }
        }
    }
}
