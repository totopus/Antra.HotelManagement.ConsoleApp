using System;
using System.Collections.Generic;
using System.Text;
using Antra.HotelManagement.Data.Model;
using Dapper;
using System.Data;

namespace Antra.HotelManagement.Data.Repository
{
    public class RoomTypesRepository : IRepository<RoomTypes>
    {
        HotelManagementContext db;
        public RoomTypesRepository()
        {
            db = new HotelManagementContext();
        }
        

        public IEnumerable<RoomTypes> GetAll()
        {
            using(IDbConnection conn = db.GetConnection())
            {
                return conn.Query<RoomTypes>("Select Id,RTDesc,Rent from RoomTypes");
            }
            
        }

        public RoomTypes GetById(int id)
        {
            using (IDbConnection conn = db.GetConnection())
            {
                return conn.QueryFirstOrDefault<RoomTypes>(@"Select Id,RTDesc,Rent from
                                            RoomTypes where id=@rmid", new { rmid = id });
            } 
            
        }

        public int Insert(RoomTypes item)
        {
            using(IDbConnection conn = db.GetConnection())
            {
                try 
                { return conn.Execute("Insert into RoomTypes values (@RTDesc,@Rent)", item);}
                
                catch(Exception ex)
                {

                }
                finally
                {

                }
            
            }
            return 0;
        }

        public int Update(RoomTypes item)
        {
            using (IDbConnection conn = db.GetConnection())
            {
                try
                {
                    return conn.Execute(@"Update RoomTypes set RTDesc=@RTDesc, 
                                    Rent=@Rent where Id=@Id", item);
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
                    return conn.Execute("Delete * from RoomTypes where Id=@Rmid", new { rmid = id });
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
