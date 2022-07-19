using brunsker_api.models;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;

namespace brunsker_api.data;
public class AppDbContext
{

    const string connectionString = @"Server=localhost;Database=DB-Brunsker;User Id=root;Password=my-secret-pw;";








    // protected override void OnConfiguring(DbContextOptionsBuilder options)
    //  => options.UseMySql(connectionString: @"Server=localhost;Database=DB-Brunsker;User Id=root;Password=my-secret-pw;",
    //     new MySqlServerVersion(new Version(8, 0, 29))
    //  );

    // public DbSet<Imovel> imoveis { get; set; }
    // public DbSet<Corretor> corretores { get; set; }

}