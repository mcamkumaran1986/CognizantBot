﻿using Cognizant.BotStore.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Serilog;
using System;

namespace Cognizant.BotStore.Shared
{
    public class DatabaseConfigurationProvider : ConfigurationProvider
    {
        Action<DbContextOptionsBuilder> OptionsAction { get; }
        public DatabaseConfigurationProvider(Action<DbContextOptionsBuilder> optionsAction)
        {
            OptionsAction = optionsAction;
        }

        public override void Load()
        {
            var builder = new DbContextOptionsBuilder<BotStoreDBContext>();
            OptionsAction(builder);

            using (var dbContext = new BotStoreDBContext(builder.Options))
            {
                try
                {
                    dbContext.Database.EnsureCreated();
                }
                catch (Exception ex)
                {
                    Log.Error("Exception occurred in Config Load {ex}", ex);
                }
            }
        }
    }

    public class DatabaseConfigSource : IConfigurationSource
    {
        private readonly Action<DbContextOptionsBuilder> _optionsAction;

        public DatabaseConfigSource(Action<DbContextOptionsBuilder> optionsAction)
        {
            _optionsAction = optionsAction;
        }

        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            return new DatabaseConfigurationProvider(_optionsAction);
        }
    }

    public static class EntityFrameworkExtensions
    {
        public static IConfigurationBuilder AddConfigurationFromTable(
            this IConfigurationBuilder builder, Action<DbContextOptionsBuilder> setup)
        {
            return builder.Add(new DatabaseConfigSource(setup));
        }
    }
}
