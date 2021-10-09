using System;
using System.Collections.Generic;
using System.Text;
using Antra.HotelManagement.Data.Model;
using Dapper;
using System.Data;

namespace Antra.HotelManagement.Data.Repository
{
    public class CustomersRepository : IRepository<Customers>
    {
        HotelManagementContext db;
        public CustomersRepository()
        {
            db = new HotelManagementContext();
        }
        public int Delete(int id)
        {
            using (IDbConnection conn = db.GetConnection())
            {
                try
                {
                    return conn.Execute("Delete * from Customers where Id=@cid", new { cid = id });
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

        public IEnumerable<Customers> GetAll()
        {
            string query = @"select c.Id,c.RoomNo, c.CName, c.Address, c.Phone, c.Email,
                                c.CheckIn, c.TotalPersons, c.BookingDays, c.Advance,r.Id, rt.Id,rt.RTDesc from Customers c 
                                left join Rooms r
                                on c.RoomNo = r.Id 
                                left join RoomTypes rt
                                on rt.Id = r.RTCode";
            using (IDbConnection conn = db.GetConnection())
            {

                return conn.Query<Customers, Rooms, RoomTypes, Customers>(query, (c,r,rt) => { c.Rooms = r; r.RoomTypes = rt; return c; });
            }
        }

        public Customers GetById(int id)
        {
            using (IDbConnection conn = db.GetConnection())
            {
                return conn.QueryFirstOrDefault<Customers>(@"Select @Id,@RoomNo, @CName, @Address, @Phone, @Email,
                                @CheckIn, @TotalPersons, @BookingDays, @Advance where id=@cid", new { cid = id });
            }
        }

        public int Insert(Customers item)
        {
            
            string queryTwo = "Update Rooms set Status = 0 where id = @cid";
            using (IDbConnection conn = db.GetConnection())
            {
                try
                {
                    conn.Execute(queryTwo, new { cid = item.RoomNo });
                    return conn.Execute(@"Insert into Customers values (@RoomNo, @CName, @Address, @Phone, @Email,
                                @CheckIn, @TotalPersons, @BookingDays, @Advance)", item);
                   
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                finally
                {

                }

            }
            return 0;
        }

        public int Update(Customers item)
        {
            using (IDbConnection conn = db.GetConnection())
            {
                try
                {
                    return conn.Execute(@"Update Customers set RoomNo=@RoomNo, CName=@CName, Address=@Address, Phone=@Phone, Email=@Email,
                                CheckIn=@CheckIn, TotalPersons=@TotalPersons, BookingDays=@BookingDays, Advance=@Advance where Id=@Id", item);
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
