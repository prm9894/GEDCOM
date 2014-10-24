using GEDCOM.Entities;
using GEDCOM.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEDCOM.DataSource
{


    /// <summary>
    /// 
    /// </summary>
    public static class GEDCOM_Cache
    {
        /// <summary>
        /// The __gedcom cache
        /// </summary>
        private static GEDCOM __gedcomCache;

        /// <summary>
        /// Fetches the specified file path.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <returns></returns>
        public static GEDCOM Load(string filePath)
        {
            if(__gedcomCache == null)
            {
                var gedCom = new GEDCOM(filePath);
                gedCom.Load();

                __gedcomCache = gedCom;
            }

            return __gedcomCache;
        }

        public static GEDCOM Fetch()
        {
            return __gedcomCache;
        }

    }

    /// <summary>
    /// 
    /// </summary>
    public class GEDCOM
    {
        private string __filePath;
        private string __gedcomFileContent;
        private Data __data;

        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        public Data Data { get { return __data; } set { __data = value; } }

        /// <summary>
        /// Gedcoms the specified file path.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        public GEDCOM(string filePath)
        {
            this.__filePath = filePath;
        }

        /// <summary>
        /// Loads this instance.
        /// </summary>
        public void Load()
        {
            this.__data = new Data();

            this.__gedcomFileContent = ReadGedcomFileContents(this.__filePath);

            //Split on "0 @" to get an array of Individuals, Families, Notes, Source, Repository, Object (File)
            string[] records = this.__gedcomFileContent.Replace("0 @", "\u0646@").Split('\u0646');

            foreach(var record in records)
            {
                if (record.StartsWith("@") && !record.StartsWith("@SUBM@ SUBM"))
                {
                    //The GEDCOM file is structured one row per element. Split the record into elements.
                    var elements = record.Replace("\r\n", "\r").Split('\r');

                    RecordTypes recordType = (RecordTypes)Enum.Parse(typeof(RecordTypes), elements[0].Replace(" ", "").Split('@')[2]);

                    //Check what type of record we are working with.
                    switch (recordType)
                    {
                        case RecordTypes.INDI:
                            __data.Individuals.Add(PersonEntity.Create(elements));
                            break;
                        case RecordTypes.FAM:
                            __data.Families.Add(FamilyEntity.Create(elements));
                            break;
                        case RecordTypes.NOTE:
                            __data.Notes.Add(NoteEntity.Create(elements));
                            break;
                        case RecordTypes.OBJE:
                            __data.Objects.Add(FileEntity.Create(elements));
                            break;
                        case RecordTypes.REPO:
                            __data.Repositories.Add(RepositoryEntity.Create(elements));
                            break;
                        case RecordTypes.SOUR:
                            __data.Sources.Add(SourceEntity.Create(elements));
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Reads the gedcom file contents.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <returns></returns>
        private string ReadGedcomFileContents(string filePath)
        {
            try
            {
                //Open path to GED file
                StreamReader reader = new StreamReader(filePath);

                if(reader != null)
                {
                    return reader.ReadToEnd();
                }

                return null;

            }catch(Exception ex)
            {
                return null;
            }
        }


    }
}
