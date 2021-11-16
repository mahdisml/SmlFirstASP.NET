using Microsoft.EntityFrameworkCore;

namespace App;

public class MyDb : DbContext{
    public string DbPath { get; private set; }
    public DbSet<People>? Peoples { get; set; }

    public MyDb(){
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = $"{path}{System.IO.Path.DirectorySeparatorChar}MyDb.db";
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options){
        options.UseSqlite($"Data Source={DbPath}");
    }
    public class People{
        public int Id { get; set; }
        public int? Age { get; set; }
        public string? Name { get; set;}
    }
}

