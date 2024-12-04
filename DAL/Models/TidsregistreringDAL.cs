﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TidsregistreringDAL
    {
        [Key]
        public int Id {  get; set; }
        public DateTime StartTid { get; set; }
        public DateTime SlutTid { get; set; }
        public SagDAL Sag {  get; set; }
        public MedarbejderDAL Medarbejder { get; set; }

        public TidsregistreringDAL(DateTime starttid, DateTime sluttid, MedarbejderDAL medarbejder,  SagDAL sag = null)
        {
            StartTid = starttid;
            SlutTid = sluttid;
            Medarbejder = medarbejder;
            Sag = sag;
        }
        public TidsregistreringDAL() { }
    }
}
