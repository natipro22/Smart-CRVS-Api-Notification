﻿using Ab.Domain.Configuration.Settings;
using AppDiv.CRVS.Domain.Configuration.Settings;
using AppDiv.CRVS.Domain.Entities.Audit;
using AppDiv.CRVS.Domain.Entities.Settings;
using AppDiv.CRVS.Infrastructure.Context;
using Audit.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Newtonsoft.Json;
using AppDiv.CRVS.Application.Interfaces.Persistence;
using AppDiv.CRVS.Domain;
using AppDiv.CRVS.Infrastructure.Seed;
using Audit.EntityFramework;
using AppDiv.CRVS.Domain.Entities;
using AppDiv.CRVS.Domain.Entities.Notifications;
using Microsoft.AspNetCore.Identity;
using AppDiv.CRVS.Domain.Configuration;
using Microsoft.EntityFrameworkCore.Infrastructure;
using AppDiv.CRVS.Domain.Configurations;

namespace AppDiv.CRVS.Infrastructure
{
    public class CRVSDbContext : AuditIdentityDbContext<ApplicationUser>, ICRVSDbContext
    {
        private readonly IUserResolverService userResolverService;
        public DbSet<UserGroup> UserGroups { get; set; }

        // public DbSet<AuditLog> AuditLogs { get; set; }
        // public DbSet<BirthNotification> BirthNotifications { get; set; }
        public DbSet<Issuer> Issuers { get; set; }
        public DbSet<Deceased> Deceased { get; set; }
        // public DbSet<DeathRegistrar> DeathRegistrars { get; set; }
        public DbSet<DeathNotification> DeathNotifications { get; set; }
        public DbSet<BirthNotification> BirthNotifications { get; set; }


        public CRVSDbContext(DbContextOptions<CRVSDbContext> options, IUserResolverService userResolverService) : base(options)
        {
            this.ChangeTracker.LazyLoadingEnabled = false;
            this.userResolverService = userResolverService;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            // To run sql scripts, example alter database to set collation, create stored procedure, function, view ....
            // optionsBuilder.ReplaceService<IMigrationsSqlGenerator, CustomSqlServerMigrationsSqlGenerator>();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            #region Entity Configuration
            {
                // modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
                // modelBuilder.ApplyConfiguration(new UserGroupEntityConfiguration());
                modelBuilder.ApplyConfiguration(new DeathNotificationEntityConfiguration());
                modelBuilder.ApplyConfiguration(new IssuerEntityConfiguration());
                // modelBuilder.ApplyConfiguration(new DeathRegistrarEntityConfiguration());
                // modelBuilder.ApplyConfiguration(new DeceasedEntityConfiguration());
            }
            #endregion
            base.OnModelCreating(modelBuilder);

            // SeedData.SeedRoles(modelBuilder);
            // SeedData.SeedUsers(modelBuilder);
            // SeedData.SeedUserRoles(modelBuilder);
            // SeedData.SeedGender(modelBuilder);
            // SeedData.SeedSuffix(modelBuilder);


            #region Audit Config
            Audit.Core.Configuration.Setup()
                .UseEntityFramework(config => config
                .AuditTypeMapper(t => typeof(AuditLog))
                .AuditEntityAction<AuditLog>((auditEvent, auditedEntity, auditEntity) =>
                {
                    auditEntity.AuditData = JsonConvert.SerializeObject(auditedEntity, GetJsonSerializerSettings());
                    auditEntity.EntityType = auditedEntity.EntityType.Name;
                    auditEntity.AuditDate = DateTime.Now;
                    auditEntity.AuditUserId = Guid.NewGuid();
                    if (userResolverService != null)
                    {
                        var userId = userResolverService.GetUserId();

                        auditEntity.AuditUserId = userId != null
                                ? new Guid(userId)
                                : Guid.Empty;
                    }

                    auditEntity.Action = auditedEntity.Action;
                    auditEntity.Enviroment = JsonConvert.SerializeObject(new AuditEventEnvironment
                    {
                        UserName = auditEvent.Environment.UserName,
                        MachineName = auditEvent.Environment.MachineName,
                        DomainName = auditEvent.Environment.DomainName,
                        CallingMethodName = auditEvent.Environment.CallingMethodName,
                        Exception = auditEvent.Environment.Exception,
                        Culture = auditEvent.Environment.Culture
                    }, GetJsonSerializerSettings());
                    /*if (auditedEntity.EntityType == typeof(test))
                    {
                        var json = auditEntity.AuditData.Replace("'", "\"");
                        var jo = JsonConvert.DeserializeObject<Newtonsoft.Json.Linq.JObject>(json);
                        var referenceNo = jo["ColumnValues"]["ReferenceNumber"];
                        auditEntity.TablePk = jo["ColumnValues"]["ReferenceNumber"].ToString();
                    }*/
                    //else
                    {
                        auditEntity.TablePk = auditedEntity.PrimaryKey.First().Value.ToString();
                    }
                }).IgnoreMatchedProperties(true));
            #endregion
        }

        public static JsonSerializerSettings GetJsonSerializerSettings()
        {
            return new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                DateFormatString = "yyyy-MM-dd hh:mm:ss",
                StringEscapeHandling = StringEscapeHandling.EscapeHtml,
                Formatting = Newtonsoft.Json.Formatting.Indented
            };
        }

        public Guid GetCurrentUserId()
        {
            var userId = userResolverService.GetUserId();
            return userId != null ? new Guid(userId) : Guid.Empty;

        }
    }
}
