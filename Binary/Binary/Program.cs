using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using EmployeeLib;

namespace Binary
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee emp = new Employee
            {
                Id = 1,
                FirstName = "HarshaVardhan",
                LastName = "Raju",
                Salary = 50000.00
            };

            // Binary Serialization
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fileStream = new FileStream("D:\\M\\Day-21\\Assignment24\\employee.bin", FileMode.Create))
            {
                formatter.Serialize(fileStream, emp);
            }

            // Binary Deserialization
            using (FileStream fileStream1 = new FileStream("D:\\M\\Day-21\\Assignment24\\employee.bin", FileMode.Open))
            {
                Employee deserializedEmp = (Employee)formatter.Deserialize(fileStream1);
                Console.WriteLine($"Deserialized Employee: Id={deserializedEmp.Id}, FirstName={deserializedEmp.FirstName}, LastName={deserializedEmp.LastName}, Salary={deserializedEmp.Salary}");
            }
            Console.ReadKey();

            // XML Serialization
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Employee));
            using (StreamWriter writer = new StreamWriter("D:\\M\\Day-21\\Assignment24\\employee.xml"))
            {
                xmlSerializer.Serialize(writer, emp);
            }

            // XML Deserialization
            using (StreamReader reader = new StreamReader("D:\\M\\Day-21\\Assignment24\\employee.xml"))
            {
                Employee deserializedEmp = (Employee)xmlSerializer.Deserialize(reader);
                Console.WriteLine($"Deserialized Employee: Id={deserializedEmp.Id}, FirstName={deserializedEmp.FirstName}, LastName={deserializedEmp.LastName}, Salary={deserializedEmp.Salary}");
            }
            Console.ReadKey();
        }
    }
}
