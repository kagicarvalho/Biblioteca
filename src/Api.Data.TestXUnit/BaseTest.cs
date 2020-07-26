using System;
using Api.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Api.Data.Test
{
    public abstract class BaseTest
    {
        public BaseTest()
        {
            
        }
    }

    public class DbTeste : IDisposable
    {
        private string dataBaseName = $"dbBibliotecaTeste_{Guid.NewGuid().ToString().Replace("-", string.Empty)}";
        
        public ServiceProvider ServiceProvider {get; private set;}

        public DbTeste(){
            var serviceColleciont = new ServiceCollection();
            serviceColleciont.AddDbContext<MyContext>(d => 
                d.UseSqlServer($"Server=.\\SQLEXPRESS;Initial Catalog={dataBaseName};MultipleActiveResultSets=true; User Id=sa;Password=Mercuri@123"),
                ServiceLifetime.Transient);

            ServiceProvider = serviceColleciont.BuildServiceProvider();

            using(var context = ServiceProvider.GetService<MyContext>())
            {
                context.Database.EnsureCreated();
            }
        }

        public void Dispose()
        {
            using(var context = ServiceProvider.GetService<MyContext>())
            {
                context.Database.EnsureCreated();
            }
        }
    }
}
