using System;

namespace Domain
{
    public class PersonInfo
    {
        protected bool Equals(PersonInfo other)
        {
            return Id == other.Id;
        }

        public override int GetHashCode()
        {
            return Id;
        }

        public int Id { get; set; }

        public string SurName { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public DateTime BirthDay { get; set; }

        public Sex Sex { get; set; }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((PersonInfo) obj);
        }
    }
}