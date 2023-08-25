﻿using System.ComponentModel.DataAnnotations.Schema;

namespace ETicaret.Model
{
    [Table("tblUser")]
    public class User
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int RoleId { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string PhoneNumber { get; set; }

        public bool Active { get; set; }

        public DateTime? BirthDate { get; set; }

        public DateTime RegistryDate { get; set; }
    }
}