using Api.Data.Context;
using Api.Data.Repository;
using Api.Data.UserImplementation;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services.User;
using Api.Domain.Repository;
using Api.Service.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        private const string V = "Server=localhost;Port=3306;DataBase=dbBiblioteca;Uid=root;Pwd=teste123";

        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection){
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            serviceCollection.AddScoped<IUserRepository, UserImplementation>();
            serviceCollection.AddDbContext<MyContext>(options => options.UseMySql(V));
            
        }
        
    }
}