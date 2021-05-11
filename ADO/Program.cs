using System;
using System.Data.SqlClient;
namespace AdoNetConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program().CreateTable();
            Console.ReadKey();
        }
        public void CreateTable()
        {
            SqlConnection con = null;
            try
            {
                // Creating Connection  
                SqlConnection sqlConnection = new SqlConnection("data source=ABHISHAKSKINI\\SQLEXPRESS; database=Student; integrated security=SSPI");
                con = sqlConnection;

                Console.WriteLine("Enter your choice 1.CREATE A TABLE 2.INSERT DATA IN A TABLE 3.DISPLAY THE TABLE 4.DELETE FROM TABLE");
                
                int choice= Int32.Parse(Console.ReadLine());

switch(choice)
{
    case 1:
    {

        //create a table
        SqlCommand create = new SqlCommand("create table student(id int not null, name varchar(100), email varchar(50), join_date date)", con); 
         // Opening Connection  
          con.Open();
          // Executing the SQL query  
         create.ExecuteNonQuery();
        Console.WriteLine("Create a table");
        break;
    }


    case 2:
    {
         // writing sql query  
        SqlCommand write = new SqlCommand("insert into student (id, name, email, join_date) values ('101', 'Ronald Trump', 'ronald@example.com', '1/12/2017')", con); 
        // Opening Connection  
         con.Open();
        // Executing the SQL query  
         write.ExecuteNonQuery();
        Console.WriteLine("Record Inserted Successfully");
        break;
    }

    case 3:
    {
          //displaying every content
         SqlCommand display = new SqlCommand("Select * from student", con);
        // Opening Connection  
        con.Open();
        // Executing the SQL query  
        SqlDataReader sdr = display.ExecuteReader();
        // Iterating Data  
        while (sdr.Read())
                {
                    // Displaying Record  
                    Console.WriteLine(sdr["id"] + " " + sdr["name"] + " " + sdr["email"]); 
                }
        break;
    }

    case 4:
    {
        SqlCommand delete = new SqlCommand("delete from student where id = '101'", con);      
       //Opening connection
        con.Open();
        // Executing the SQL query  
        delete.ExecuteNonQuery();
         Console.WriteLine("Record Deleted Successfully");  
            break;
    }
    default:
    {
        Console.WriteLine("Choose correct option");
        break;
    }

    }  
    }
            catch (Exception e)
            {
                Console.WriteLine("OOPs, something went wrong." + e);
            }
            // Closing the connection  
            finally
            {
                con.Close();
            }
        }
    }
}