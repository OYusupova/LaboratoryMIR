using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Lab1.Models
{
    public class DataModel
    {
        [Required]
        [DisplayName("Фамилия")]
        public string SurName { get; set; }

        [Required]
        [DisplayName("Имя")]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Отчество")]
        public string MiddleName { get; set; }

        [Required]
        [DisplayName("Дата рождения")]
        [DataType(DataType.Date)]
        public DateTime BirthDay { get; set; }

        [Required]
        [DisplayName("Пол")]
        public Sex Sex { get; set; }
    }

    public enum Sex
    {
        Жен = 0,
        Муж = 1
    }
}