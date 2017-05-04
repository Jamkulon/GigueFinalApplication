using AutoMapper.Configuration;
using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Web.Hosting;

[assembly: OwinStartup(typeof(GigueService.Startup))]

namespace GigueService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
        }

     
        
    }
}