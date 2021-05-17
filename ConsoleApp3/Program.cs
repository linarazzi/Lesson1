using System;
using System.Reflection;
using ClassLibrary1;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {

            Assembly asm = Assembly.LoadFrom("ClassLibrary1.dll");

            Console.WriteLine("Типы в сборке:");

            foreach (Type item in asm.GetTypes())
            {
                Console.WriteLine(item.FullName);
            }

            Type HumanType = asm.GetType("ClassLibrary1.Human");

            ShowMethodsInfo(HumanType);

            ShowConstructors(HumanType);

            Type ConverterType = asm.GetType("ClassLibrary1.Converter");


            ShowMethodsInfo(ConverterType);

            ShowConstructors(ConverterType);

        }
         

        static void ShowConstructors(Type type)
        {
            Console.WriteLine($"Конструкторы типа {type.Name}:");
            foreach (ConstructorInfo construct in type.GetConstructors())
            { 
                foreach (ParameterInfo item in construct.GetParameters())
                {
                    Console.WriteLine(item.ParameterType.Name + " " + item.Name);
                }  
            }
        }

        static void ShowMethodsInfo(Type type)
        {
            Console.WriteLine($"Методы типа {type.Name}");
            foreach (MethodInfo item in type.GetMethods())
            {
                Console.WriteLine($"Метод {item.Name}");

                foreach (ParameterInfo par in item.GetParameters())
                {
                    Console.WriteLine("Параметр " + par.Name + " тип " + par.ParameterType);
                }

            }
        }
    }
}
