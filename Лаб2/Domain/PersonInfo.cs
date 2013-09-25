using System;

namespace Domain
{
    public class PersonInfo
    {
        public int Id { get; set; }

        public string SurName { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public DateTime BirthDay { get; set; }

        public Sex Sex { get; set; }
    }
}