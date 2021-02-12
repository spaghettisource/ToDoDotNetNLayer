using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Core;
using ToDoDotNet.Models;

namespace ToDoDotNet.App_Start
{
    public class MappingProfile : Profile
    {
        public static MapperConfiguration Configure()
        {
            var config = new MapperConfiguration(cfg =>
            {
                //way one 
                cfg.CreateMap<ToDo, ToDoViewModel>();
                cfg.CreateMap(typeof(QueryResult<>), typeof(QueryResultResource<>));
                cfg.CreateMap<ToDoQueryResource, ToDoQuery>();
            }
           );

            return config;
        }
    }
}
