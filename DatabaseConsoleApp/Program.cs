
using WebApplication1.Models;
using WebApplication1.Services;

IDatabaseService databaseService = new DatabaseService("Server=MSI\\MSSQLSERVER01;Database=testduombaze;Integrated Security=True;");

//List<ActorFilmDetail> actorFilmDetails = (databaseService.GetActorFilmDetails()).ToList();

//foreach(ActorFilmDetail actorFilmDetail in actorFilmDetails)
//{
//    Console.WriteLine($"{actorFilmDetail.FirstName}  {actorFilmDetail.LastName}  {actorFilmDetail.Length}");
//}
Console.WriteLine("Iveskite ID ir Email: ");
TestObject1 test1 = new TestObject1 { ID = int.Parse(Console.ReadLine()), Email = Console.ReadLine() };
databaseService.InsertTestObject1(test1);
Console.WriteLine("Iveskite ID kuri norite istrinti: ");
databaseService.DeleteRecord(int.Parse(Console.ReadLine()));
Console.WriteLine("Iveskite Email: ");
TestObject2 test2 = new TestObject2 { Email = Console.ReadLine() };
databaseService.InsertTestObject2(test2);

List<TestObject2> list = (databaseService.GetTestObjectsType2()).ToList();

databaseService.DeleteRecordType2(list.FirstOrDefault());