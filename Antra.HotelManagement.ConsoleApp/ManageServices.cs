using System;
using System.Collections.Generic;
using System.Text;
using Antra.HotelManagement.Data.Model;
using Antra.HotelManagement.Data.Repository;

namespace Antra.HotelManagement.ConsoleApp
{
    class ManageServices
    {
        IRepository<Services> servicesRepository;
        public ManageServices()
        {
            servicesRepository = new ServicesRepository();
        }

        void PrintAll()
        {
            var collection = servicesRepository.GetAll();
            foreach (var item in collection)
            {
                Console.WriteLine($"{item.Id} \t {item.RoomNo} \t {item.SDesc} \t {item.Amount} \t {item.ServiceDate}");
            }
        }

        void PrintServicesById()
        {
            Console.Write("Enter Id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Services item = servicesRepository.GetById(id);
            if (item != null)
            {
                Console.WriteLine($"{item.Id} \t {item.RoomNo} \t {item.SDesc} \t {item.Amount} \t {item.ServiceDate}");
            }
            else
            {
                Console.WriteLine("No Record Found");
            }
        }

        void AddServices()
        {
            Services r = new Services();
            Console.Write("Enter Room No.: ");
            r.RoomNo = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Service Description: ");
            r.SDesc = Console.ReadLine();
            Console.Write("Enter Service Amount: ");
            r.Amount = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Enter Service Date: ");
            r.ServiceDate = Convert.ToDateTime(Console.ReadLine());

            if (servicesRepository.Insert(r) > 0)

                Console.WriteLine("Service Successfully Added!");

            else

                Console.WriteLine("Some Error has Occured");

        }

        void UpdateServices()
        {
            Services r = new Services();
            Console.WriteLine("Enter Id: ");
            r.Id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Room No.: ");
            r.RoomNo = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Service Description: ");
            r.SDesc = Console.ReadLine();
            Console.Write("Enter Service Amount: ");
            r.Amount = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Enter Service Date: ");
            r.ServiceDate = Convert.ToDateTime(Console.ReadLine());

            if (servicesRepository.Update(r) > 0)
                Console.WriteLine("Service Updated Successfully");
            else
                Console.WriteLine("Some Error has Occured");
        }


        void RemoveServices()
        {
            Services r = new Services();
            Console.WriteLine("Enter Id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            if (servicesRepository.Delete(id) > 0)
            {
                Console.WriteLine("Service Deleted");
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
