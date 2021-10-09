using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using Antra.HotelManagement.Data.Model;
using System.Data;

namespace Antra.HotelManagement.Data.Repository
{
    public class ServicesRepository : IRepository<Services>
    {
        HotelManagementContext db;
        public ServicesRepository()
        {
            db = new HotelManagementContext();
        }
       
        public int Delete(int id)
        {
            using (IDbConnection conn = db.GetConnection())
            {
                try
                {
                    return conn.Execute("Delete * from Services where Id=@Sid", new { sid = id });
                }
                catch (Exception ex)
                {

                }
                finally
                {
                }

            }
            return 0;
        }

        public IEnumerable<Services> GetAll()
        {
            string query = @"select s.Id, s.RoomNo, s.SDesc, s.Amount, s.ServiceDate, r.Id from Services s
                                left join Rooms r on s.RoomNo = r.Id";
            using (IDbConnection conn = db.GetConnection())
            {
                return conn.Query<Services, Rooms, Services>(query, (s, r) => { s.Rooms = r; return s; });
            }
        }

        public Services GetById(int id)
        {
            using (IDbConnection conn = db.GetConnection())
            {
                return conn.QueryFirstOrDefault<Services>(@"Select Id, RoomNo, SDesc, Amount, ServiceDate from
                                            Services where id=@sid", new { sid = id });
            }
        }

        public int Insert(Services item)
        {
            using (IDbConnection conn = db.GetConnection())
            {
                try
                { return conn.Execute("Insert into Services values ( @RoomNo, @SDesc, @Amount, @ServiceDate)", item); }

                catch (Exception ex)
                {

                }
                finally
                {

                }

            }
            return 0;
        }

        public int Update(Services item)
        {
            using (IDbConnection conn = db.GetConnection())
            {
                try
                {
                    return conn.Execute(@"Update Services set RoomNo=@RoomNo, SDesc=@SDesc, Amount=@Amount,ServiceDate= @ServiceDate where Id=@Id", item);
                }
                catch
                {

                }
                finally
                {

                }
            }

            return 0;
        }
    }
}
