﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ITJob.QueryService.Implements.AdvertisementModule.Mappers;

namespace ITJob.QueryService.Implements.Installer
{
    public static class ActiveMapper
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<AdvertismentMapperProfile>();
            });
        }
    }
}
