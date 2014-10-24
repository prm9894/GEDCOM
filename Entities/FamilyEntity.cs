using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEDCOM.Entities
{
    public class FamilyEntity
    {
        public static FamilyEntity Create(string[] elements)
        {
            var entity = new FamilyEntity();

            entity.Id = elements[0].Replace("0 @", "").Replace("@ FAM", "").Replace("@","").Trim();
            entity.HusbandId = elements.FirstOrDefault(e => e.Contains("HUSB")) != null ? elements.FirstOrDefault(e => e.Contains("HUSB")).Replace("1 HUSB", "").Replace("@", "").Trim() : "";
            entity.WifeId = elements.FirstOrDefault(e => e.Contains("WIFE")) != null ? elements.FirstOrDefault(e => e.Contains("WIFE")).Replace("1 WIFE", "").Replace("@", "").Trim() : "";
           
            var childRecords = elements.Where(e => e.Contains("CHIL"));
            if(childRecords != null && childRecords.Any())
            {
                entity.ChildrenId.AddRange(childRecords.Select(c => c.Replace("1 CHIL ","").Replace("@","")));
            }

            var index = Array.FindIndex(elements, e => e.Contains("1 MARR"));
            if (index > 0)
            {
                var marriageFact = new FactEntity();
                marriageFact.Date = elements[index + 1].Replace("2 DATE", "").Trim();
                marriageFact.Location = elements[index + 2].Replace("2 PLAC", "").Trim();

                entity.Marrage = marriageFact;
            }
            return entity;
        }

        public FamilyEntity()
        {
            ChildrenId = new List<string>();

        }

        public string Id { get; set; }

        public string HusbandId { get; set; }

        public string WifeId { get; set; }

        public List<string> ChildrenId { get; set; }

        public FactEntity Marrage { get; set; }
    }
}
