using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ITJob.DomainModel.Modules.AdvertisementModule.Aggregates;
using ITJob.EntityFramework.Write.Context.Interfaces;
using ITJob.Infrastructure.Exceptions;
using ITJob.Infrastructure.Helper;
using SAF.SSN.Kernel.Infrastructure.Configuration;
using SAF.SSN.Kernel.Infrastructure.Domain;
using Configuration = ITJob.EntityFramework.Write.Implement.Migrations.Configuration;

namespace ITJob.EntityFramework.Write.Implement.Context.Implements
{
    public class DataContext : DbContext, IContext
    {

        public DataContext() : base(ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString)
        {
            Initialize();
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();


            if (!DataProviderConfigurator.IsConfigured)
                throw new DataProviderAssembliesNotFoundException();

            //Register FluentMappings
            Array.ForEach(DataProviderConfigurator.MappingAssemblies.ToArray(), modelBuilder.AddMappingsFromAssemblyOf);
            LoadEntities(typeof(Advertisement).Assembly, modelBuilder, "ITJob.DomainModel.Modules");
        }

        private static void LoadEntities(Assembly asm, DbModelBuilder modelBuilder, string nameSpace)
        {
            var entityTypes = asm.GetTypes()
                .Where(type => type.Namespace != null &&
                               type.BaseType != null &&
                               type.Namespace.Contains(nameSpace) &&
                               type.BaseType == typeof(EntityBase<Guid>)
                ).ToList();

            entityTypes.ForEach(modelBuilder.RegisterEntityType);
        }

        private void Initialize()
        {
            //IDataContext
            Configuration.LazyLoadingEnabled = true;
            Configuration.ProxyCreationEnabled = true;
            ////Configuration.ValidateOnSaveEnabled = true;
            Configuration.AutoDetectChangesEnabled = true;
            Database.CommandTimeout = 100000;

            //Database.SetInitializer(new DropCreateDatabaseAlways<DataContext>());
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DataContext, Configuration>());
            //CompositeDatabaseInitializer<DataContext<TDataTable>> compositeDatabaseInitializer = new CompositeDatabaseInitializer<DataContext<TDataTable>>(new MigrateDatabaseToLatestVersion<DataContext<TDataTable>, Migrations.Configuration<TDataTable>>(), new IndexInitializer<DataContext<TDataTable>>());
            //Database.SetInitializer(compositeDatabaseInitializer);

        }


        public static void ExecuteMigration()
        {
            try
            {
                var dx = new DataContext();
                dx.Database.Initialize(true);
            }
            catch (Exception exception)
            {
                throw exception;
            }

        }


        public new void Dispose()
        {
             base.Dispose();
        }
    }

}
