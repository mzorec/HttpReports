﻿using HttpReports;
using HttpReports.Core;
using HttpReports.Storage.Abstractions;
using HttpReports.Storage.PostgreSQL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceBuildExtensions
    {
        public static IHttpReportsBuilder UsePostgreSQLStorage(this IHttpReportsBuilder builder)
        {
            builder.Services.AddOptions();
            builder.Services.Configure<PostgreStorageOptions>(builder.Configuration.GetSection("Storage"));

            return builder.UsePostgreSQLStorageService();
        }

        public static IHttpReportsBuilder UsePostgreSQLStorage(this IHttpReportsBuilder builder,Action<PostgreStorageOptions> options)
        {
            builder.Services.AddOptions();
            builder.Services.Configure<PostgreStorageOptions>(options); 

            return builder.UsePostgreSQLStorageService();
        }

        internal static IHttpReportsBuilder UsePostgreSQLStorageService(this IHttpReportsBuilder builder)
        { 
            builder.Services.AddSingleton<IHttpReportsStorage, PostgreSQLStorage>();

            return builder;
        }

    }
}
