﻿using Messenger.DataContext;
using Messenger.Repository;
using Messenger.Repository.Interfaces;
using Messenger.Service;
using Messenger.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Messenger.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddDataContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<MessengerDataContext>(
            (provider, builder) =>
            {
                var connectionString = configuration.GetConnectionString("MessengerDB");
                builder.UseSqlServer(connectionString);
                builder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTrackingWithIdentityResolution);
            },
            ServiceLifetime.Transient);
    }

    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
    }

    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
    }

}
