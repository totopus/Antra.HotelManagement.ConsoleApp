using System;
using System.Collections.Generic;
using System.Text;
using Antra.HotelManagement.Data.Model;
using Antra.HotelManagement.Data.Repository;

namespace Antra.HotelManagement.ConsoleApp
{
    class ManageCustomers
    {
        IRepository<Customers> customersRepository;
        public ManageCustomers()
        {
            customersRepository = new CustomersRepository();
        }

        void PrintAll()
        {
            var collection = customersRepository.GetAll();
            foreach (var item in collection)
            {
                Console.WriteLine($"{item.Id} \t {item.RoomNo} \t {item.CName} \t {item.Address} \t {item.Phone} \t {item.Email} \t{item.CheckIn} \t {item.TotalPersons} \t {item.BookingDays} \t{item.Advance} \t {item.Rooms.RoomTypes.RTDesc} ");
            }
        }

        void PrintCustomersById()
        {
            Console.Write("Enter Id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Customers item = customersRepository.GetById(id);
            if (item != null)
            {
                Console.WriteLine($"{item.Id} \t {item.RoomNo} \t  {item.CName} \t {item.Address} \t {item.Phone} \t {item.Email} \t{item.CheckIn} \t {item.TotalPersons} \t {item.BookingDays} \t{item.Advance}");
            }
            else
            {
                Console.WriteLine("No Record Found");
            }
        }

        void AddCustomers()
        {
            Customers r = new Customers();
            Console.Write("Enter Room No.: ");
            r.RoomNo = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Customer Name: ");
            r.CName = Console.ReadLine();
            Console.Write("Enter Customer Address: ");
            r.Address = Console.ReadLine(); 
            Console.Write("Enter Phone Number: ");
            r.Phone = Console.ReadLine();
            Console.Write("Enter Email Address: ");
            r.Email = Console.ReadLine();
            Console.Write("Enter Check In Date: ");
            r.CheckIn = Convert.ToDateTime(Console.ReadLine());
            Console.Write("Enter Total No. of Guest(s): ");
            r.TotalPersons = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Booked Days: ");
            r.BookingDays = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Amount Paid in Advanced: ");
            r.Advance = Convert.ToDecimal(Console.ReadLine());

            if (customersRepository.Insert(r) > 0)

                Console.WriteLine("Customer Successfully Added!");

            else

                Console.WriteLine("Some Error has Occured");

        }

        void UpdateCustomers()
        {
            Customers r = new Customers();
            Console.WriteLine("Enter Id: ");
            r.Id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Room No.: ");
            r.RoomNo = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Customer Name: ");
            r.CName = Console.ReadLine();
            Console.Write("Enter Customer Address: ");
            r.Address = Console.ReadLine();
            Console.Write("Enter Phone Number: ");
            r.Phone = Console.ReadLine();
            Console.Write("Enter Email Address: ");
            r.Email = Console.ReadLine();
            Console.Write("Enter Check In Date: ");
            r.CheckIn = Convert.ToDateTime(Console.ReadLine());
            Console.Write("Enter Total No. of Guest(s): ");
            r.TotalPersons = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Booked Days: ");
            r.BookingDays = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Amount Paid in Advanced: ");
            r.Advance = Convert.ToDecimal(Console.ReadLine());
            
            
            if (customersRepository.Update(r) > 0)
                Console.WriteLine("Customer Updated Successfully");
            else
                Console.WriteLine("Some Error has Occured");
        }


        void RemoveCustomers()
        {
            Customers r = new Customers();
            Console.WriteLine("Enter Id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            if (customersRepository.Delete(id) > 0)
            {
                Console.WriteLine("Customer Deleted");
            }
            else
            {
                Console.WriteLine("No Record Found");
            }
        }
        public void Run()
        {
            AddCustomers();
        }
    }
}
