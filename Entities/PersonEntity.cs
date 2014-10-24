using GEDCOM.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEDCOM.Entities
{
    public class PersonEntity
    {
        public static PersonEntity Create(string[] elements)
        {
            var entity = new PersonEntity();

            entity.Id = elements[0].Replace("0 @", "").Replace("@ INDI", "").Replace("@","").Trim();
            entity.Gender = (Genders)Enum.Parse(typeof(Genders), elements.FirstOrDefault(e => e.Contains("SEX")).Trim().Replace("1 SEX ",""));

            //**************** NAME 
            var nameParts = elements.FirstOrDefault(e => e.Contains("NAME")).Replace("1 NAME ", "").Split(' ');
            entity.FirstName = nameParts[0].Replace(".","").Trim();

            for(int i = 1; i < nameParts.Length-1; i++)
            {
                entity.MiddleName = string.Format("{0}{2}{1}", entity.MiddleName, nameParts[i].Contains("/") ? "" : nameParts[i].Replace(".","").Trim(), entity.MiddleName.Length > 0 ? " ": "");
            }

            entity.SurName = nameParts.FirstOrDefault(n => n.Contains(@"/"));
            entity.SurName = entity.SurName.Replace("/", "").Trim();

            entity.Suffix = nameParts[nameParts.Length - 1].Contains("/") ? "" : nameParts[nameParts.Length - 1].Replace(".","").Trim();

            //**************** Picture and Files
            entity.PictureFileId = elements.FirstOrDefault(e => e.Contains("_PHOTO")) != null ? elements.FirstOrDefault(e => e.Contains("_PHOTO")).Replace("1 _PHOTO", "").Replace("@", "").Trim() : "";

            var files = elements.Where(e => e.Contains("OBJE"));
            entity.FileIds = new List<string>();
            foreach(var file in files)
            {
                entity.FileIds.Add(file.Split(' ')[2].Replace("@",""));
            }

            //******************** Facts

            var facts = Enum.GetValues(typeof(Facts));

            foreach (Facts fact in facts)
            {
                var factEntity = new FactEntity();
                var index = Array.FindIndex(elements, e => e.Contains(fact.ToString()));
                var indexOffset = fact == Enums.Facts.EVEN ? 1 : 0;

                if (index > 0) //Check if Fact not found.
                {
                    factEntity.Type = fact;
                    factEntity.TypeName = fact == Enums.Facts.EVEN ? elements[index + 1].Split(' ')[2] : fact.ToString();
                    factEntity.Description = elements[index].Split(' ').Length > 2 ? elements[index].Replace(string.Format("1 {0} ", fact.ToString()),"") : "";
                    factEntity.Date = elements[index + 1 + indexOffset].Contains("DATE") ? elements[index + 1 + indexOffset].Replace("2 DATE ", "") : "";
                    factEntity.Location = elements[index + 2 + indexOffset].Contains("PLAC") ?  elements[index + 2 + indexOffset].Replace("2 PLAC ", "") : "";

                    for (var i = index + 1; i < elements.Length; i++)
                    {
                        if (elements[i].Contains("2"))
                        {
                            if (elements[i].Contains("SOUR"))
                            {
                                factEntity.SourceIds.Add(elements[i].Replace("2 SOUR ", "").Replace("@", ""));
                            }
                        }
                        if (elements[i].Contains("3 _FOOT"))
                        {
                            factEntity.FootNote = elements[i].Replace("3 _FOOT ", "");
                            for (var fIndex = i + 1; fIndex < elements.Length; fIndex++)
                            {
                                if (elements[fIndex].Contains("4 CONC"))
                                {
                                    factEntity.FootNote = string.Format("{0} {1}", factEntity.FootNote, elements[fIndex]);
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                    entity.Facts.Add(factEntity);
                    if(factEntity.Type == Enums.Facts.BIRT)
                    {
                        entity.BirthDate = factEntity.Date;
                        if(!string.IsNullOrEmpty(factEntity.Date ))
                        {
                            var dateParts = factEntity.Date.Split(' ');
                            entity.BirthYear = int.Parse(dateParts.Last());
                        }
                    }
                    if(factEntity.Type == Enums.Facts.DEAT)
                    {
                        entity.DeathDate = factEntity.Date;
                    }
                }
            }

            //************************ Families

            entity.ChildhoodFamilyIds.AddRange(elements.Where(e => e.Contains("FAMC")).Select(e => e.Replace("1 FAMC ","").Replace("@","")));
            entity.MarriedFamilyIds.AddRange(elements.Where(e => e.Contains("FAMS")).Select(e => e.Replace("1 FAMS ", "").Replace("@", "")));

            return entity;
        }

        public PersonEntity()
        {
            Facts = new List<FactEntity>();
            ChildhoodFamilyIds = new List<string>();
            MarriedFamilyIds = new List<string>();
            FileIds = new List<string>();
            MiddleName = "";
            Suffix = "";
        }

        public string Id { get; set; }

        public string SurName { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string Suffix { get; set; }

        public string FullName { get { return string.Format("{0} {1}{4}{2}{5}{3}", this.FirstName, this.MiddleName, this.SurName, this.Suffix, this.MiddleName.Length > 0 ? " " : "", this.Suffix.Length > 0 ? " " : ""); } }

        public string PictureFileId { get; set; }
        
        public Genders Gender { get; set; }

        public List<FactEntity> Facts { get; set; }

        public List<string> ChildhoodFamilyIds { get; set; }

        public List<string> MarriedFamilyIds { get; set; }

        public List<string> FileIds { get; set; }

        public string BirthDate { get; set; }

        public string DeathDate { get; set; }

        public int BirthYear { get; set; }


    }
}
