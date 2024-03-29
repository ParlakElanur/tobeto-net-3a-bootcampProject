﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class Blacklist : BaseEntity<int>
    {
        public string Reason { get; set; }
        public DateTime Date { get; set; }
        public int ApplicantId { get; set; }

        public Blacklist()
        {
        }
        public Blacklist(int id, string reason, DateTime date, int applicantId) : this()
        {
            Id = id;
            Reason = reason;
            Date = date;
            ApplicantId = applicantId;
        }
        public Applicant Applicant { get; set; }
    }
}
