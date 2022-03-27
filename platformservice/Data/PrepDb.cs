using platformservice.Entities;

namespace platformservice.Data;

public class PrepDb
{
    public static void PrepPopulation(IApplicationBuilder app)
    {
        using( var serviceScope = app.ApplicationServices.CreateScope())
        {
            SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
        } 
    }
    private static void SeedData(AppDbContext context)
    {
        if(!context.Platforms.Any())
        {
           Console.WriteLine("---> Seeding data");

            context.Platforms.AddRange(
                new Platform() { Id = 1 ,Name = "Dot Net", Publisher = "Microsoft", Cost = "Free" },
                new Platform() { Id = 2 ,Name = "Cubirnetes", Publisher = "Cloud Native Computer Foundation", Cost = "Free" }
            );

            context.SaveChanges();
        }
        else
        {
            Console.WriteLine("---> We already have data");
            
        }
    }
}