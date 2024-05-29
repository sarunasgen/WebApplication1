using Dapper;
using System.Data;
using System.Data.SqlClient;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class DatabaseService : IDatabaseService
    {
        private readonly string _connectionString;
        public DatabaseService(string connectionString)
        { 
            _connectionString = connectionString;
        }
        public IEnumerable<ActorFilmDetail> GetActorFilmDetails()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                const string sql = @"
                SELECT a.first_name AS 'FirstName', a.last_name AS 'LastName', f.length 
                FROM actor a
                INNER JOIN film_actor fa ON a.actor_id = fa.actor_id
                INNER JOIN film f ON f.film_id = fa.film_id
                ORDER BY f.length ASC";

                return db.Query<ActorFilmDetail>(sql);
            }
        }
        public IEnumerable<TestObject2> GetTestObjectsType2()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                const string sql = "SELECT ID ,EMAIL FROM TestLentele2";

                return db.Query<TestObject2>(sql);
            }
        }
        public void DeleteRecord(int recordId)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                const string sql = "DELETE FROM TestLentele WHERE ID = @RecordIdToDelete;";
                db.Execute(sql, new { RecordIdToDelete = recordId });
            }
        }
        public void DeleteRecordType2(TestObject2 test)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                const string sql = "DELETE FROM TestLentele2 WHERE ID = @ID;";
                db.Execute(sql, test);
            }
        }
        public void InsertTestObject1(TestObject1 testObject)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                const string sql = "INSERT INTO TestLentele (EMAIL) VALUES (@Email);";
                db.Execute(sql, testObject);
            }
        }
        public void InsertTestObject2(TestObject2 testObject)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                const string sql = "INSERT INTO TestLentele2 (EMAIL) VALUES (@Email);";
                db.Execute(sql, testObject);
            }
        }
        public void InsertTestObject1Alternative(TestObject1 testObject)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                const string sql = "INSERT INTO test1 (ID, EMAIL) VALUES (@manoId, @manoEmail);";
                db.Execute(sql, new { manoId = testObject.ID, manoEmail = testObject.Email }); //Kai nurodome parametrus atskirai (one-by-one)
            }
        }
    }
}
