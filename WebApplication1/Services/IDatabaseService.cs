using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface IDatabaseService
    {
        IEnumerable<ActorFilmDetail> GetActorFilmDetails();
        void DeleteRecord(int recordId);
        void InsertTestObject1(TestObject1 testObject);
        void InsertTestObject2(TestObject2 testObject);
        IEnumerable<TestObject2> GetTestObjectsType2();
        void DeleteRecordType2(TestObject2 test);
    }
}