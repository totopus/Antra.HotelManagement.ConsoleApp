using System;
using System.Collections.Generic;
using System.Text;
using Antra.HotelManagement.Data.Repository;
using Antra.HotelManagement.Data.Model;

namespace Antra.HotelManagement.ConsoleApp
{
    class ManageRoomTypes
    {
        IRepository<RoomTypes> roomTypesRepository;
        public ManageRoomTypes()
        {
            roomTypesRepository = new RoomTypesRepository();
        }

        void AddRoomTypes()
        {
            RoomTypes r = new RoomTypes();
            Console.Write("Enter Room Description: ");
            r.RTDesc = Console.ReadLine();
            Console.Write("Enter Rent: ");
            r.Rent = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine();
            if (roomTypesRepository.Insert(r)>0)
            
                Console.WriteLine("Room Type Successfully added!");
            
            else
            
                Console.WriteLine("Some Error has Occured");
            
        }

        void UpdateRoomTypes()
        {
            RoomTypes r = new RoomTypes();
            Console.WriteLine("Enter Id: ");
            r.Id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Room Type Description: ");
            r.RTDesc = Console.ReadLine();
            Console.Write("Enter Rent: ");
            r.Rent = Convert.ToDecimal(Console.ReadLine());

            if (roomTypesRepository.Update(r) > 0)
                Console.WriteLine("Room Type Updated Successfully");
            else
                Console.WriteLine("Some Error has Occured");
        }

        void RemoveRoomTypes()
        {
            RoomTypes r = new RoomTypes();
            Console.WriteLine("Enter Id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            if (roomTypesRepository.Delete(id) > 0)
            {
                Console.WriteLine("Room Type Deleted");
            }
            else
            {
                Console.WriteLine("No Record Found");
            }
        }
        
        void PrintAll()
        {
            var collection = roomTypesRepository.GetAll();
            foreach (var item in collection)
            {
                Console.WriteLine($"{item.Id} \t {item.RTDesc} \t {item.Rent}");
            }
        }

        void PrintRoomTypesById()
        {
            Console.Write("Enter Id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            RoomTypes item = roomTypesRepository.GetById(id);
            if (item != null)
            {
                Console.WriteLine($"{item.Id} \t {item.RTDesc} \t {item.Rent}");
            }
            else
            {
                Console.WriteLine("No Record Found");
            }
        }


        public void Run()
        {
            AddRoomTypes();
        }
    }
}
