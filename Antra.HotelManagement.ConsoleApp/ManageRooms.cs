using System;
using System.Collections.Generic;
using System.Text;
using Antra.HotelManagement.Data.Repository;
using Antra.HotelManagement.Data.Model;

namespace Antra.HotelManagement.ConsoleApp
{
    class ManageRooms
    {
        IRepository<Rooms> roomsRepository;
        public ManageRooms()
        {
            roomsRepository = new RoomsRepository();
        }
        void PrintAll()
        {
            var collection = roomsRepository.GetAll();
            foreach (var item in collection)
            {
                Console.WriteLine($"{item.Id}{item.RTCode}{item.Status}");
            }
        }

        void PrintRoomsById()
        {
            Console.Write("Enter Id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Rooms item = roomsRepository.GetById(id);
            if (item != null)
            {
                Console.WriteLine($"{item.Id} \t {item.RTCode} \t {item.Status}");
            }
            else
            {
                Console.WriteLine("No Record Found");
            }
        }

        void AddRooms()
        {
            Rooms r = new Rooms();
            Console.Write("Enter Room Type Code: ");
            r.RTCode = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Status: ");
            r.Status = Convert.ToBoolean(Console.ReadLine());
            Console.WriteLine();
            if (roomsRepository.Insert(r) > 0)

                Console.WriteLine("Room Successfully added!");

            else

                Console.WriteLine("Some Error has Occured");
        }

        void UpdateRooms()
        {
            Rooms r = new Rooms();
            Console.WriteLine("Enter Id: ");
            r.Id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Room Type Code: ");
            r.RTCode = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Status: ");
            r.Status = Convert.ToBoolean(Console.ReadLine());

            if (roomsRepository.Update(r) > 0)
                Console.WriteLine("Room Updated Successfully");
            else
                Console.WriteLine("Some Error has Occured");
        }

        void RemoveRooms()
        {
            Rooms r = new Rooms();
            Console.WriteLine("Enter Id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            if (roomsRepository.Delete(id) > 0)
            {
                Console.WriteLine("Room Deleted");
            }
            else
            {
                Console.WriteLine("No Record Found");
            }
        }
        public void Run()
        {
            PrintAll();
        }
    }
}
