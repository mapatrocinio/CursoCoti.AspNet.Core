using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
namespace Projeto.Application.Mappings
{
    public class AutoMapperConfig
    {
        public static void Register()
        {
            Mapper.Initialize(
            map =>
            {
                map.AddProfile<EntityToModelMapping>();
                map.AddProfile<ModelToEntityMapping>();
            });
        }
    }
}