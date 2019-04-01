using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Reflection;
using System.Reflection.Emit;


namespace ReflectionOne
{
    public class MainClass
    {
        public static void Main()
        {
            Type listType = typeof(List<>);
            Console.WriteLine("List<>: {0}, {1}", listType.IsGenericType, listType.ContainsGenericParameters);
            Type listIntType = typeof(List<int>);
            Console.WriteLine("List<int>: {0}, {1}", listIntType.IsGenericType, listIntType.ContainsGenericParameters);
            Console.WriteLine("  ");



            ///**/
            //Assembly assembly = Assembly.GetExecutingAssembly();
            //foreach (var item in assembly.GetTypes())
            //{
            //    Console.WriteLine($"{item.Namespace}.{item.Name}");

            //    foreach (var property in item.GetProperties())
            //    {
            //       // Console.WriteLine(property.Name);

            //        Console.WriteLine($"{property.PropertyType}/{property.Name}");
            //    }

            //}

            //Console.WriteLine("  ");




            User user = new User();
            var type = user.GetType();
            foreach (var property in type.GetProperties())
            {
                // Console.WriteLine(property.Name);

                Console.WriteLine($"{property.PropertyType}/{property.Name}");
            }
        }


        public class Product
        {
            public string Name { get; set; }

        }

        public class User
        {
            public string FullName { get; set; }
            public int Password { get; set; }

        }

    }
}
//List<>: True, True
//List: True, False