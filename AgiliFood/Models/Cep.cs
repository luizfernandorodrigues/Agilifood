﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgiliFood.Models
{
    public class Cep
    {
        public Guid Id { get; set; }
        public string _Cep { get; set; }
        public DateTime TimesTamp { get; set; }
        public Cidade Cidade { get; set; }
    }
}