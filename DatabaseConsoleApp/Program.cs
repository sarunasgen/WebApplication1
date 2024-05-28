
using WebApplication1.Models;
using WebApplication1.Services;

IDatabaseService databaseService = new DatabaseService("Server=MSI\\MSSQLSERVER01;Database=sakila;Integrated Security=True;");

List<ActorFilmDetail> actorFilmDetails = (databaseService.GetActorFilmDetails()).ToList();

foreach(ActorFilmDetail actorFilmDetail in actorFilmDetails)
{
    Console.WriteLine($"{actorFilmDetail.FirstName}  {actorFilmDetail.LastName}  {actorFilmDetail.Length}");
}
databaseService.DeleteActor(1);