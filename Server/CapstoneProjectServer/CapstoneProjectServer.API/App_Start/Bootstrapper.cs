﻿using CapstoneProjectServer.API.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace CapstoneProjectServer.API.App_Start
{
    public class Bootstrapper
    {

        public static void Run()
        {
            //Configure AutoFac  
            AutofacWebapiConfig.Initialize(GlobalConfiguration.Configuration);
        }

    }
}