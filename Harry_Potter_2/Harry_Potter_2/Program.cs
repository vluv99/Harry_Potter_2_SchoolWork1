using CsvHelper;
using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Harry_Potter_2
{
    class Character
    {
        //1. feladat
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Job { get; set; }
        public string House { get; set; }
        public string Wand { get; set; }
        public string Patronus { get; set; }
        public string Species { get; set; }
        [Name("Blood status")]
        public string BloodStatus { get; set; }
        [Name("Hair colour")]
        public string Hair { get; set; }
        [Name("Eye colour")]
        public string Eye { get; set; }
        public string Loyalty { get; set; }
        public string Skills { get; set; }
        public string Birth { get; set; }
        public string Death { get; set; }
        public List<string> Sentances { get; set; }

        public Character()
        {
            Sentances = new List<string>();
        }


    }

    class Sentance
    {
        [Name("Character")]
        public string name { get; set; }
        [Name("Sentence")]
        public string sentance { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //2. feladat
            var reader = new StreamReader(@"Characters.csv");
            var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture);
            csvReader.Configuration.Delimiter = ";";
            var characters = csvReader.GetRecords<Character>().ToList();

            //2. feladat kiratas - 10. feladat
            WriteData(characters, 2);

            #region old
            /*
var lines =
    from line in File.ReadLines(@"Characters.csv").Skip(1)
    select line.Split(';');

var characters =
    from tokens in lines
    select new Character
    {
        Id = int.Parse(tokens[0]),
        Name = tokens[1],
        Gender = tokens[2],
        Job = tokens[3].Split('|').ToList(),
        House = tokens[4],
        Wand = tokens[5],
        Patronus = tokens[6],
        Species = tokens[7],
        BloodStatus = tokens[8],
        Hair = tokens[9].Split('|').ToList(),
        Eye = tokens[10],
        Loyalty = tokens[11].Split('|').ToList(),
        Skills = tokens[12].Split('|').ToList(),
        Birth = tokens[13],
        Death = tokens[14]
    };



 var characters = File.ReadLines(@"..\Characters.csv")
   .Select(line => line.Split(';'))
   .Select(tokens => new Character
   {
       Id = int.Parse(tokens[0]),
       Name = tokens[1],
       Gender = tokens[2],
       Job = tokens[3].Split('|').ToList(),
       House = tokens[4],
       Wand = tokens[5],
       Patronus = tokens[6],
       Species = tokens[7],
       BloodStatus = tokens[8],
       Hair = tokens[9].Split('|').ToList(),
       Eye = tokens[10],
       Loyalty = tokens[11].Split('|').ToList(),
       Skills = tokens[12].Split('|').ToList(),
       Birth = tokens[13],
       Death = tokens[14]
   })
   .ToList();
*/


            /*foreach (var character in characters) //character read test
            {
                Console.WriteLine(character.Name);
            }*/
            #endregion

            //3. feladat
            var reader2 = new StreamReader(@"Harry-Potter-2.csv");
            var csvReader2 = new CsvReader(reader2, CultureInfo.InvariantCulture);
            csvReader2.Configuration.Delimiter = ";";
            var sentances = csvReader2.GetRecords<Sentance>().ToList();

            var nicknameToName = new Dictionary<string, string>();
            nicknameToName.Add("HARRY", "Harry James Potter"); //
            nicknameToName.Add("VERNON", "Vernon Dursley"); //
            nicknameToName.Add("PETUNIA", "Petunia Dursley"); //
            nicknameToName.Add("UNCLE VERNON", "Vernon Dursley"); //
            nicknameToName.Add("AUNT PETUNIA", "Petunia Dursley"); //
            nicknameToName.Add("DUDLEY", "Dudley Dursley"); //
            nicknameToName.Add("DOBBY", "Dobby"); //
            nicknameToName.Add("RON", "Ronald Bilius Weasley"); //
            nicknameToName.Add("GEORGE", "George Weasley"); //
            nicknameToName.Add("FRED", "Fred Weasley"); //
            //nicknameToName.Add("AUNT PETUNIA & DUDLEY", "Vernon Dursley"); //
            //nicknameToName.Add("AUNT PETUNIA & DUDLEY", "Petunia Dursley"); //
            nicknameToName.Add("MRS. WEASLEY", "Molly Weasley"); //
            nicknameToName.Add("GINNY", "Ginevra (Ginny) Molly Weasley"); //
            nicknameToName.Add("MR. WEASLEY", "Arthur Weasley"); //
            //nicknameToName.Add("FRED, GEORGE, RON", "Fred Weasley");
            //nicknameToName.Add("FRED, GEORGE, RON", "George Weasley");
            //nicknameToName.Add("FRED, GEORGE, RON", "Ronald Bilius Weasley");
            //nicknameToName.Add("FRED, GEORGE, RON, HARRY", "Vernon Dursley");
            //nicknameToName.Add("FRED, GEORGE, RON, HARRY", "Vernon Dursley");
            //nicknameToName.Add("FRED, GEORGE, RON, HARRY", "Vernon Dursley");
            //nicknameToName.Add("FRED, GEORGE, RON, HARRY", "Vernon Dursley");
            nicknameToName.Add("PERCY", "Percy Ignatius Weasley"); //
            nicknameToName.Add("MR. BORGIN", "none"); //
            nicknameToName.Add("LUCIUS MALFOY", "Lucius Malfoy"); //
            nicknameToName.Add("DRACO", "Draco Malfoy"); //
            nicknameToName.Add("WITCH", "none"); //
            nicknameToName.Add("HAGRID", "Rubeus Hagrid"); //
            nicknameToName.Add("HERMIONE", "Hermione Jean Granger"); //
            nicknameToName.Add("MAN", "none"); //
            nicknameToName.Add("PHOTOGRAPHER", "none"); //
            nicknameToName.Add("LOCKHART", "Gilderoy Lockhart"); //
            nicknameToName.Add("TRAINMASTER", "none"); //
            //nicknameToName.Add("HARRY AND RON", "Lucius Malfoy"); 
            //nicknameToName.Add("HARRY AND RON", "Lucius Malfoy"); 
            nicknameToName.Add("FILCH", "Argus Filch"); //
            nicknameToName.Add("SNAPE", "Severus Snape"); //
            nicknameToName.Add("DUMBLEDORE", "Albus Percival Wulfric Brian Dumbledore"); //
            nicknameToName.Add("MCGONAGALL", "Minerva McGonagall"); //
            nicknameToName.Add("PROFESSOR SPROUT", "Pomona Sprout"); //
            nicknameToName.Add("CLASS", "none");
            nicknameToName.Add("SEAMUS", "Seamus Finnigan"); //
            nicknameToName.Add("PENELOPE CLEARWATER", "Penelope Clearwater"); //
            nicknameToName.Add("SIR NICHOLAS", "Nicholas de Mimsy-Porpington"); //
            nicknameToName.Add("COLIN", "Colin Creevey"); //
            nicknameToName.Add("DEAN", "Dean Thomas"); //
            nicknameToName.Add("NEVILLE", "Neville Longbottom"); //
            nicknameToName.Add("GILDEROY LOCKHART", "Gilderoy Lockhart"); //
            nicknameToName.Add("CORNISH PIXIES", "none"); //
            nicknameToName.Add("WOOD", "Oliver Wood"); //
            nicknameToName.Add("FLINT", "Marcus Flint"); //
            nicknameToName.Add("VOICE", "none"); //
            nicknameToName.Add("BOY", "none"); //
            nicknameToName.Add("PICTURE", "none"); //
            nicknameToName.Add("LEE JORDAN", "Lee Jordan "); //
            nicknameToName.Add("SLYTHERINS", "none");
            nicknameToName.Add("MADAM POMFREY", "Poppy Pomfrey"); //
            nicknameToName.Add("MOANING MYRTLE", "Myrtle Elizabeth Warren (Moaning Myrtle)"); //
            nicknameToName.Add("JUSTIN FINCH-FLETCHLEY", "Justin Finch-Fletchley"); //
            nicknameToName.Add("SORTING HAT", "none"); //
            nicknameToName.Add("CRABBE", "Vincent Crabbe"); //
            nicknameToName.Add("DIARY", "none"); //
            nicknameToName.Add("TOM RIDDLE", "Tom Marvolo Riddle"); //
            //nicknameToName.Add("HARRY-RON-HERMIONE", "none");
            nicknameToName.Add("FUDGE", "Cornelius Oswald Fudge"); //
            nicknameToName.Add("ARAGOG", "none"); //
            //nicknameToName.Add("HARRY AND RON", "none");
            nicknameToName.Add("STUDENT", "none"); //
            //nicknameToName.Add("FRED, GEORGE, RON", "Vernon Dursley");
            //nicknameToName.Add("FRED, GEORGE, RON", "Vernon Dursley");
            //nicknameToName.Add("FRED, GEORGE, RON", "Vernon Dursley");

            foreach (var sentance in sentances)
            {
                List<string> lits;
                if (!nicknameToName.ContainsKey(sentance.name.Trim()))
                {
                    lits = sentance.name.Split(new[] { ",", "-", "&", "AND" }, StringSplitOptions.RemoveEmptyEntries).Select(i => i.Trim()).ToList();

                }
                else
                {
                    lits = new List<string>();
                    lits.Add(sentance.name);
                }

                foreach (var item in lits)
                {
                    if (nicknameToName.ContainsKey(item.Trim()))
                    {

                        string personName = nicknameToName[item.Trim()];

                        var person =
                            (from c in characters
                             where c.Name == personName
                             select c).FirstOrDefault();

                        if (person == null)
                        {
                            //Console.WriteLine(sentance.name);
                        }
                        else
                        {
                            person.Sentances.Add(sentance.sentance);
                        }
                    }
                    else
                    {
                        Console.WriteLine(item);
                    }
                }
            }

            //3. feladat kiratas - 10. feladat
            var Z_A =
                from c in characters
                orderby c.Name descending
                select c;

            var writer = new StreamWriter($"task3.csv");
            var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture);
            csvWriter.Configuration.Delimiter = ";";

            foreach (var item in Z_A)
            {
                foreach (var s in item.Sentances)
                {
                    csvWriter.WriteField(item.Name);
                    csvWriter.WriteField(item.House);
                    csvWriter.WriteField(item.Patronus);
                    csvWriter.WriteField(s);
                    csvWriter.NextRecord();
                }

                writer.Flush();
            }

            //4. feladat
            var bloods =
                from c in characters
                group c by c.BloodStatus;

            //4. feladat kiratas - 10. feladat
            writer = new StreamWriter($"task4.csv");
            csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture);
            csvWriter.Configuration.Delimiter = ";";

            foreach (var item in bloods)
            {
                csvWriter.WriteField(item.Key);
                csvWriter.WriteField(item.Count());

                csvWriter.NextRecord();
                writer.Flush();
            }

            //5. feladat
            var houses =
                from c in characters
                where c.Job.Contains("Student")
                group c by c.House into h
                select (h.Count(), h.Key);

            var max = houses.Max().Key;
            var maxNum = houses.Max().Item1;

            //5. feladat kiratas - 10. feladat
            writer = new StreamWriter($"task5.csv");
            csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture);
            csvWriter.Configuration.Delimiter = ";";

            csvWriter.WriteField(max);
            csvWriter.WriteField(maxNum);

            csvWriter.NextRecord();
            writer.Flush();

            //6. feladat
            var min = houses.Min().Key;
            var minNum = houses.Min().Item1;

            //6. feladat kiratas - 10. feladat
            writer = new StreamWriter($"task6.csv");
            csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture);
            csvWriter.Configuration.Delimiter = ";";

            csvWriter.WriteField(min);
            csvWriter.WriteField(minNum);

            csvWriter.NextRecord();
            writer.Flush();

            //7. feladat
            var sentanceCount =
                from c in characters
                where c.Sentances.Count > 10
                orderby c.Sentances.Count
                select (c, c.Sentances.Count);

            //7. feladat kiratas - 10. feladat
            writer = new StreamWriter($"task7.csv");
            csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture);
            csvWriter.Configuration.Delimiter = ";";

            foreach (var item in sentanceCount)
            {
                csvWriter.WriteField(item.c.Name);
                csvWriter.WriteField(item.Count);

                csvWriter.NextRecord();
                writer.Flush();
            }

            //8. feladat
            var genderRatio =
                from c in characters
                where !string.IsNullOrWhiteSpace(c.House)
                group c by c.House into h
                select (h.Key,
                    (from m in h
                     where m.Gender == "Male"
                     select m).Count(),
                     (from f in h
                      where f.Gender == "Female"
                      select f).Count()
                    );

            //8. feladat kiratas - 10. feladat
            writer = new StreamWriter($"task8.csv");
            csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture);
            csvWriter.Configuration.Delimiter = ";";

            foreach (var item in genderRatio)
            {
                csvWriter.WriteField(item.Key);
                csvWriter.WriteField(item.Item2);
                csvWriter.WriteField(item.Item3);

                csvWriter.NextRecord();
                writer.Flush();
            }

            //9. feladat
            var notStudents =
                from c in characters
                where !c.Job.Contains("Student")
                select c;

            //9. feladat kiratas - 10. feladat
            writer = new StreamWriter($"task9.csv");
            csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture);
            csvWriter.Configuration.Delimiter = ";";

            foreach (var item in notStudents)
            {
                csvWriter.WriteField(item.Name);
                csvWriter.WriteField(item.Job);

                csvWriter.NextRecord();
                writer.Flush();
            }
        }

        static void WriteData(IEnumerable<Character> list, int i)
        {
            var writer = new StreamWriter($"task{i}.csv");
            var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture);
            csvWriter.Configuration.Delimiter = ";";
            csvWriter.WriteRecords(list);
            writer.Flush();
        }
    }
}
