﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WildBerries.SubmitModels
{
    public class DrinkSubmitModel
    {
        public int Id { get; set; }
        public int Quantity { get; set; }        
    }
}