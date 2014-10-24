using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEDCOM.Entities
{
    public class SourceEntity
    {
        public static SourceEntity Create(string[] elements)
        {
            var entity = new SourceEntity();

            entity.Id = elements[0].Replace("0 @", "").Replace("@ SOUR", "").Replace("@","").Trim();
            entity.Author = elements.FirstOrDefault(e => e.Contains("AUTH")) != null ? elements.FirstOrDefault(e => e.Contains("AUTH")).Replace("1 AUTH", "").Trim() : "";
            entity.Title = elements.FirstOrDefault(e => e.Contains("TITL")) != null ? elements.FirstOrDefault(e => e.Contains("TITL")).Replace("1 TITL", "").Trim() : "";
            entity.Note = elements.FirstOrDefault(e => e.Contains("EMAIL")) != null ? elements.FirstOrDefault(e => e.Contains("EMAIL")).Replace("1 EMAIL", "").Trim() : "";
            entity.RepositoryId = elements.FirstOrDefault(e => e.Contains("REPO")) != null ? elements.FirstOrDefault(e => e.Contains("REPO")).Replace("1 REPO", "").Replace("@", "").Trim() : "";
            entity.Publication = elements.FirstOrDefault(e => e.Contains("PUBL")) != null ? elements.FirstOrDefault(e => e.Contains("PUBL")).Replace("1 PUBL", "").Trim() : "";

            var index = Array.FindIndex(elements, e => e.Contains("1 NOTE"));
            if (index > 0)
            {
                for (var i = index+1; i < elements.Length; i++)
                {
                    entity.Note = string.Format("{0}{2}{1}", entity.Note, elements[i].Replace("2 CONC", "").Replace("2 CONT", "").Trim(), entity.Note.Length > 0 ? " " : "");
                }
            }
            entity.Note = entity.Note.Trim();

            return entity;


        }

        public string Id { get; set; }

        public string Author { get; set; }

        public string Title { get; set; }

        public string Note { get; set; }

        public string Publication { get; set; }

        public string RepositoryId { get; set; }

    }
}
