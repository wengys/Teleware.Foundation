﻿using System;
using Autofac;
using Teleware.Foundation.Configuration;
using Teleware.Foundation.Configuration.Extensions;
using Microsoft.Extensions.Options;
using Teleware.Data;
using Teleware.Foundation.Data;
using System.Linq;
using Teleware.Foundation.Hosting.Application;
using Teleware.Foundation.Hosting;
using Teleware.Foundation.Domain.Entity;

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
            cb.RegisterModule<Teleware.Foundation.Data.Memory.Module>();
            //cb.RegisterModule<Teleware.Foundation.Data.EntityFramework.Module>();
            //cb.RegisterModule<Teleware.Foundation.Data.EntityFramework.Oracle.Module>();

            var container = cb.Build();
            using (var lt = container.BeginLifetimeScope())
            {
                var uow = lt.Resolve<IUnitOfWork>();
                var repo = lt.Resolve<ICRUDRepository<Test>>();
                var test = new Test();
                repo.Add(test);
                var item0 = repo.Query().FirstOrDefault();
                test.Foo = "a";
                repo.Update(test);
                var item = repo.Query().FirstOrDefault();
                repo.Remove(test);
                uow.Commit();
            }
        }

        private class Test : AbstractRootEntity
        {
            public string Foo { get; set; }
        }
    }
}