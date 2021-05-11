using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EF.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace EF
{
    public class Program
    {
      
        public static void Main(string[] args)
        {

        Console.WriteLine("Enter Your Choice..1.Insert 2.Display 3.Update 4.Delete");
        int choice = Convert.ToInt32(Console.ReadLine());
        using ( var db = new Models.StudentContext())
        {
            switch(choice)
            {
                case 1:
                {
                    Console.WriteLine("Enter the ID.");
                            string ID = Console.ReadLine();
                            Console.WriteLine("Enter the  name.");
                            string name = Console.ReadLine();
                            Console.WriteLine("Enter the Email");
                            string email = Console.ReadLine();
                            Console.WriteLine("Enter the joining date");
                            string date= Console.ReadLine();

                 
                            // Adding a new record into database 
                            db.Students.Add(
                                new Student
                                {
                                    Id= Int32.Parse(ID),
                                    Name = name,
                                    JoinDate = Convert.ToDateTime(date),
                                    Email=email

                                }
                            );
                            db.SaveChanges();
                            Console.WriteLine("Record inserted successfully...");
                    break;
                }

                case 2:
                {

                   
                            Console.WriteLine("Id\t\tName \t\tEmail \t\t\t\tJoining Date");
                            foreach (var stu in db.Students)
                            {
                                Console.WriteLine(  stu.Id + "\t\t" + stu.Name + "\t\t" + stu.Email +"\t\t\t"+stu.JoinDate);
                                
                            }
                            break;
                }
                case 3:
                {
                //Updating  a record
                 Console.WriteLine("Enter the Studnet Id to be updated:");
                            int updateId = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("1.Update  Name. 2.Update Email. 3.Update Joining Date.");
                            Console.WriteLine("Enter your choice ");
                            int updateFieldChoice = Convert.ToInt32(Console.ReadLine());

                             Student update;
                             String updateContent;

                            switch (updateFieldChoice)
                            {
                                
                                case 1:
                                     update = db.Students.First(e => e.Id == updateId);
                                    Console.WriteLine("Enter the new Name");
                                   updateContent = Console.ReadLine();
                                    update.Name = updateContent;
                                    db.SaveChanges();
                                    Console.WriteLine("Record updated successfully...");
                                    break;

                                case 2:
                                   update = db.Students.First(e => e.Id == updateId);
                                    Console.WriteLine("Enter the new Email");
                                   updateContent = Console.ReadLine();
                                    update.Email = updateContent;
                                    db.SaveChanges();
                                    Console.WriteLine("Record updated successfully...");
                                    break;

                                case 3:
                                     update = db.Students.First(e => e.Id == updateId);
                                    Console.WriteLine("Enter the new release date.");
                                   updateContent = Console.ReadLine();
                                    update.JoinDate= Convert.ToDateTime(updateContent);
                                    db.SaveChanges();
                                    Console.WriteLine("Record updated successfully...");
                                    break;


                            }

                            break;
                }

                case 4:
                {
                     Console.WriteLine("Enter the Student Id to be Deleted:");
                            int remid = Convert.ToInt32(Console.ReadLine());
                           // Removing a record with the given Student Id
                           Student rem = db.Students.First(e => e.Id == remid);
                            db.Students.Remove(rem);
                            db.SaveChanges();
                            Console.WriteLine("Record deleted successfully...");
                            break;
                }

                default :
                {
                    Console.WriteLine("Choose another option");
                    break;
                }
            }
            
        }

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
