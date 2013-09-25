using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Domain;

namespace Lab.Models
{
    public class Mapping
    {
        public static void CreateMapping()
        {
            Mapper.CreateMap<PersonInfo, DataModel>();
            Mapper.CreateMap<DataModel, PersonInfo>();
        }
    }
}