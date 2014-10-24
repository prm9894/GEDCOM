using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEDCOM.Entities
{
    public class RepositoryEntity
    {
        public static RepositoryEntity Create(string[] elements)
        {
            var entity = new RepositoryEntity();

            entity.Id = elements[0].Replace("0 @", "").Replace("@ REPO", "").Replace("@","").Trim();
            entity.Name = elements.FirstOrDefault(e => e.Contains("NAME")) != null  ? elements.FirstOrDefault(e => e.Contains("NAME")).Replace("1 NAME", "").Trim() : "";
            entity.Address = elements.FirstOrDefault(e => e.Contains("ADDR")) != null ? elements.FirstOrDefault(e => e.Contains("ADDR")).Replace("1 ADDR", "").Trim() : "";
            entity.Email = elements.FirstOrDefault(e => e.Contains("EMAIL")) != null ? elements.FirstOrDefault(e => e.Contains("EMAIL")).Replace("1 EMAIL", "").Trim() : "";
            entity.Phone = elements.FirstOrDefault(e => e.Contains("PHON")) != null ? elements.FirstOrDefault(e => e.Contains("PHON")).Replace("1 PHON", "").Trim() : "";

            return entity;
            
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }
    }
}
