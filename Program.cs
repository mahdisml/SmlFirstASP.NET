var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

String Hi(String Hi) {
    return Hi + "Salam";
}

app.MapGet("/", () => {
    var hi = "hi";
    App.MyDb.People people;
    using (var db = new App.MyDb()) {
        Console.WriteLine($"Database path: {db.DbPath}.");
        Console.WriteLine("Inserting a new people");
        db.Add(new App.MyDb.People { Name = "Asghar",Age = new Random().Next(20,1000000000) });
        db.SaveChanges();
        Console.WriteLine("Querying for a blog");
        people = db.Peoples!
            .OrderByDescending(b => b.Age)
            .First();
    }
    return Hi(hi + people.Age);
});

app.Run();
