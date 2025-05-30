﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace DAL
{
    public class AfdelingDAL
    {
        [Key]
        public int Id { get; set; }
        public string Navn { get; set; }
        public int Nummer { get; set; }
        public List<MedarbejderDAL> Medarbejdere { get; set; }
        public List<SagDAL> Sager { get; set; }

        public AfdelingDAL(string navn, int nummer)
        {
            Navn = navn;
            Nummer = nummer;
        }

        public AfdelingDAL() { }
    }
}
