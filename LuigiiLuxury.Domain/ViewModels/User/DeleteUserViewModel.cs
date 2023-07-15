﻿using System.ComponentModel.DataAnnotations;

namespace LuigiiLuxury.Domain.ViewModels
{
    public class DeleteUserViewModel
    {
        public int Id { get; set; }


        [Display(Name = "First Name")]
        public string FirstName { get; set; }


        [Display(Name = "Last Name")]
        public string LastName { get; set; }


        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
