﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Responses.Blacklist
{
    public class UpdateBlacklistResponse
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Reason { get; set; }
        public DateTime Date { get; set; }
        public int ApplicantId { get; set; }
    }
}
