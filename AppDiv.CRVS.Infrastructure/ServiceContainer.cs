using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using AppDiv.CRVS.Domain;
using AppDiv.CRVS.Utility.Config;
using AppDiv.CRVS.Application.Interfaces.Persistence.Base;
using AppDiv.CRVS.Infrastructure.Persistence;
using AppDiv.CRVS.Domain.Repositories;
using AppDiv.CRVS.Application.Interfaces.Persistence;
using AppDiv.CRVS.Infrastructure.Services;
using AppDiv.CRVS.Utility.Services;
using Twilio.Clients;
using AppDiv.CRVS.Application.Interfaces;
using AppDiv.CRVS.Application.Service;
using AppDiv.CRVS.Infrastructure.Extensions;
// using AppDiv.CRVS.Infrastructure.Extensions;

namespace AppDiv.CRVS.Infrastructure
{
    public static class ServiceContainer
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
        {
            #region  db configuration


            // services.AddDbContext<CRVSDbContext>(
            //     options => options.UseSqlServer(
            //         configuration.GetConnectionString("CRVSConnectionString"),
            //         o => o.MigrationsAssembly(typeof(ServiceContainer).Assembly.FullName)
            //     ).EnableSensitiveDataLogging()
            // );
            services.AddDbContext<CRVSDbContext>(
                options =>
                {
                    // options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                    options.UseMySql(configuration.GetConnectionString("CRVSConnectionString"),
                        Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.29-mysql"),
                        mySqlOptions => mySqlOptions.EnableRetryOnFailure());
                });
            services.AddDbContext<NotificationDbContext>(
                options =>
                {
                    options.UseMySql(configuration.GetConnectionString("NotificationConnectionString"),
                        Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.29-mysql"),
                        mySqlOptions => mySqlOptions.EnableRetryOnFailure());
                });

            #endregion db configuration

            // #region  elasticSearch    

            services.AddElasticSearch(configuration);

            // #endregion elasticSearch

            #region  identity
            services.AddIdentity<ApplicationUser, IdentityRole>()
                      .AddEntityFrameworkStores<CRVSDbContext>()
                      .AddEntityFrameworkStores<NotificationDbContext>()
                      .AddDefaultTokenProviders();


            services.Configure<IdentityOptions>(options =>
               {
                   // Default Lockout settings.
                   options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromDays(99999);
                   options.Lockout.MaxFailedAccessAttempts = 4;
                   options.Lockout.AllowedForNewUsers = true;
                   // Default Password settings.
                   options.Password.RequireDigit = false;
                   options.Password.RequireLowercase = false;
                   options.Password.RequireNonAlphanumeric = false; // For special character
                   options.Password.RequireUppercase = false;
                   options.Password.RequiredLength = 3;
                   options.Password.RequiredUniqueChars = 0;

                   // //TODO:add policy object names
                   // options.Password.RequireDigit = passwordpolicy.Value<bool>("number");
                   // options.Password.RequireLowercase = passwordpolicy.Value<bool>("lowerCase");
                   // options.Password.RequireNonAlphanumeric = passwordpolicy.Value<bool>("otherCharacter"); // For special character
                   // options.Password.RequireUppercase = passwordpolicy.Value<bool>("upperCase");
                   // options.Password.RequiredLength = passwordpolicy.Value<int>("minLength");
                   // options.Password.RequiredUniqueChars = 0;
                   // Default SignIn settings.
                   options.SignIn.RequireConfirmedEmail = false;
                   options.SignIn.RequireConfirmedPhoneNumber = false;
                   options.User.RequireUniqueEmail = true;
               });
            #endregion identity


            // services.Configure<RabbitMQConfiguration>(configuration.GetSection(RabbitMQConfiguration.CONFIGURATION_SECTION));
            services.Configure<SMTPServerConfiguration>(configuration.GetSection(SMTPServerConfiguration.CONFIGURATION_SECTION));
            services.Configure<TwilioConfiguration>(configuration.GetSection(TwilioConfiguration.CONFIGURATION_SECTION));
            services.Configure<AfroMessageConfiguration>(configuration.GetSection(AfroMessageConfiguration.CONFIGURATION_SECTION));



            services.AddSingleton<IUserResolverService, UserResolverService>();
            services.AddSingleton<IFileService, FileService>();

            services.AddSingleton<IMailService, MailKitService>();
            services.AddSingleton<ISmsService, TwilioService>();
            services.AddSingleton<ISmsService, AfroMessageService>();
            services.AddScoped<ISettingRepository, SettingRepository>();




            #region Repositories DI         

            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IGroupRepository, GroupRepository>();
            services.AddTransient<IDeathNotificationRepository, DeathNotificationRepository>();
            services.AddTransient<IBirthNotificationRepository, BirthNotificationRepository>();
            services.AddTransient<IOnlineApplicationRepository, OnlineApplicationRepository>();
            services.AddTransient<IAddressLookupRepository, AddressLookupRepository>();
            services.AddTransient<ISettingRepository, SettingRepository>();
            services.AddTransient<ICourtRepository, CourtRepository>();
            services.AddTransient<IReportRepostory, ReportRepostory>();
            services.AddTransient<ILookupRepository, LookupRepository>();
            services.AddTransient<IDateAndAddressService, DateAndAddressService>();

            services.AddScoped<CRVSDbContextInitializer>();
            services.AddHttpClient<ITwilioRestClient, TwilioClient>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();

            #endregion Repositories DI

            return services;
        }
    }
}
