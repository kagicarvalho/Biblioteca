using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Api.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
    {
        public MyContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
            if(Environment.GetEnvironmentVariable("DATABASE").ToLower() == "SQLSERVER".ToLower()){
                optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("DATABASE"));
            }else{
                optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("DATABASE"));
            }
            return new MyContext(optionsBuilder.Options);
        }
    }
}