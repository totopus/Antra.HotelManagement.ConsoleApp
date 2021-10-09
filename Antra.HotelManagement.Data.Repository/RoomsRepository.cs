using System;
using System.Collections.Generic;
using System.Text;
using Antra.HotelManagement.Data.Model;
using Dapper;
using System.Data;

namespace Antra.HotelManagement.Data.Repository
{
    public class RoomsRepository : IRepository<Rooms>
    {
        HotelManagementContext db;
        public RoomsRepository()
        {
            db = new HotelManagementContext();
        }

       

        public IEnumerable<Rooms> GetAll()
        {
            using (IDbConnection conn = db.GetConnection())
            {
                return conn.Query<Rooms>("Select Id,RTCode,Status from Rooms");
            }
        }

        public Rooms GetById(int id)
        {
            using (IDbConnection conn = db.GetConnection())
            {
                return conn.QueryFirstOrDefault<Rooms>(@"Select Id,RTCode,Status from
                                            Rooms where id=@rid", new { rid = id });
            }
        }

        public int Insert(Rooms item)
        {
            using (IDbConnection conn = db.GetConnection())
            {
                try
                { return conn.Execute("Insert into Rooms values (@RTCode,@Status)", item); }

                catch (Exception ex)
                {

                }
                finally
                {

                }

            }
            return 0;
        }

        public int Update(Rooms item)
        {
            using (IDbConnection conn = db.GetConnection())
            {
                try
                {
                    return conn.Execute(@"Update Rooms set RTCode=@RTCode, 
                                    Status=@Status where Id=@Id", item);
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
        public int Delete(int id)
        {
            using (IDbConnection conn = db.GetConnection())
            {
                try
                {
                    return conn.Execute("Delete * from Rooms where Id=@Rid", new { rid = id });
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
    }
}
