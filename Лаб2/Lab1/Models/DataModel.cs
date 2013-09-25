using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Domain;
using Newtonsoft.Json;

namespace Lab.Models
{
    public class DataModel
    {
        public int Id { get; set; }
 
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

        public override string ToString()
        {
            return string.Format("<Id:{0};Фамилия:{1};FirstName:{2};MiddleName{3};BirthDay:{4};Sex:{5}>", Id, SurName, FirstName, MiddleName, BirthDay.ToShortDateString(), Sex);
        }
    }


}