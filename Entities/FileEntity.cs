using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEDCOM.Entities
{
    public class FileEntity
    {
        public static FileEntity Create(string[] elements)
        {
            var entity = new FileEntity();

            entity.Id = elements[0].Replace("0 @", "").Replace("@ OBJE", "").Replace("@","").Trim();
            var fileNamePath = elements.FirstOrDefault(e => e.Contains("FILE")) != null ? elements.FirstOrDefault(e => e.Contains("FILE")).Replace("1 FILE", "").Trim() : "";
            var fileNamePathParts = fileNamePath.Split('\\');
            entity.FileName = fileNamePathParts[fileNamePathParts.Length - 1];
            entity.Title = elements.FirstOrDefault(e => e.Contains("TITL")) != null ? elements.FirstOrDefault(e => e.Contains("TITL")).Replace("2 TITL", "").Trim() : "";

            return entity;
        }

        public string Id { get; set; }

        public string FileName { get; set; }

        public string Title { get; set; }
    }
}
