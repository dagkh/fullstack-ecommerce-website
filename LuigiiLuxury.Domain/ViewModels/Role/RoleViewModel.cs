﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LuigiiLuxury.Domain.ViewModels
{
    public class RoleViewModel
    {
        public string Code { get; set; }

        public string Name { get; set; }
    }
}
