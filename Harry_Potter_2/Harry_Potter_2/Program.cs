using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Harry_Potter_2
{
    class Character
    {
        /* ...
        private string wand;
        private string patronus;
        private string species;
        private string bloodStatus;
        private string hair;
        private string eye;
        private string loyalty = null;
        private string skills = null;
        private string birth;
        private string death = null;
        private List<string> sentances;*/

        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }  
        public string Job { get; set; }
        public string House { get; set; }
        public string Wand { get; set; }
        public string Patronus { get; set; }
        public string Species { get; set; }
        public string BloodStatus { get; set; }
        public string Hair { get; set; }
        public string Eye { get; set; }
        public string Loyalty { get; set; }
        public string Skills { get; set; }
        public string Birth { get; set; }
        public string Death { get; set; }
        public List<string> Sentances { get; set; }

        public Character() { }

        
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //Character character = new Character();

            var characters = File.ReadLines(@"D:\Documents\School\5.felev\Alkalmazasfejlesztes-II\kötprog_1\kotprog-01-CLI\harry-potter-2\harry-potter-2\Characters.csv")
               .Select(line => line.Split(';'))
               .Select(tokens => new Character { Id = int.Parse(tokens[0]), Name = tokens[1], Gender = tokens[2], 
                                                 Job = tokens[3], House = tokens[4], Wand = tokens[5], Patronus = tokens[6],
                                                 Species = tokens[7], BloodStatus = tokens[8], Hair = tokens[9], Eye = tokens[10],
                                                 Loyalty = tokens[11], Skills = tokens[12], Birth = tokens[13], Death = tokens[14]})
               .ToList();

            foreach ( var character in characters)
            {
                Console.WriteLine(character.Name);
            }
            
        }
    }
}
