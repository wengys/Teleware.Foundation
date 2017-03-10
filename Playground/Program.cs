﻿using System;
using Autofac;
using Teleware.Foundation.Configuration;
using Teleware.Foundation.Configuration.Extensions;
using Microsoft.Extensions.Options;
using Teleware.Data;
using A.Playground.LandRegulation;
using Teleware.Foundation.Data;
using Teleware.FJJG.DataPump.Entity;
using System.Linq;
using Teleware.Foundation.Hosting.Application;
using Teleware.Foundation.Hosting;

namespace Playground
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var env = new ApplicationEnvironment();
            var bootupConfigurationProvider = new BootupConfigurationProvider(env);

            Autofac.ContainerBuilder cb = new Autofac.ContainerBuilder();
            cb.RegisterInstance<IEnvironment>(env);
            cb.RegisterInstance(bootupConfigurationProvider).As<IBootupConfigurationProvider>();

            cb.RegisterModule<Teleware.Foundation.Core.Module>();
            cb.RegisterModule<Teleware.Foundation.Configuration.Module>();
            cb.RegisterModule<Teleware.Foundation.Data.EntityFramework.Module>();
            cb.RegisterModule<Teleware.Foundation.Data.EntityFramework.Oracle.Module>();
            cb.RegisterType<ZZ_YSMapping>().As<IDbObjConfiguration>();
            cb.ConfigureOptions<Test>();

            var container = cb.Build();
            using (var lt = container.BeginLifetimeScope())
            {
                //var provider = lt.Resolve<BootupConfigurationProvider>();
                //var configFactory = lt.Resolve<IConfigurationFactory>();
                //var configRoot = configFactory.GetConfigurationRoot();
                //var opt = lt.Resolve<IOptionsSnapshot<Test>>().Value;

                var repo = lt.Resolve<ICRUDRepository<ZZ_YS>>();
                var item = repo.Query().FirstOrDefault();
            }
        }

        private class Test
        {
            public string Foo { get; set; }
        }
    }
}