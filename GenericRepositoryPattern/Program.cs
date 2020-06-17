using GenericRepositoryPattern.DataContext;
using GenericRepositoryPattern.Entities;
using GenericRepositoryPattern.Repos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GenericRepositoryPattern
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //This is for demo porpouses, use dependecy injection in a real project...
            SampleDataContext context = new SampleDataContext();

            //**************************************************************************************
            //Here you see how the same generic repo can be used for distinct entities...
            GenericRepo<Customer> customersRepo = new GenericRepo<Customer>(context);
            GenericRepo<Order> ordersRepo = new GenericRepo<Order>(context);
            GenericRepo<Invoice> invoicesRepo = new GenericRepo<Invoice>(context);
            //**************************************************************************************

            Customer customer = new Customer() { FirstName = "Jhon" };

            await customersRepo.AddAsync(customer);
            await customersRepo.SaveAsync();

            List<Customer> customers = new List<Customer>();

            customers = await customersRepo.GetAllAsync();

            foreach (var cust in customers)
            {
                Console.WriteLine($"Customer name: {cust.FirstName}");
            }
            
            Console.ReadLine();
        }
    }
}
