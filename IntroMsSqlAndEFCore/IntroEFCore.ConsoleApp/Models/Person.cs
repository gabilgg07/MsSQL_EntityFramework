using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace IntroEFCore.ConsoleApp.Models
{
    public partial class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime? BirthDay { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
