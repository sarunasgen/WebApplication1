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
        public void DeleteActor(int actorId)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                const string sql = @"
                DELETE FROM actor WHERE actor_id = @actorId";
                db.Query(sql, new { actorId });
            }
        }
    }
}
