﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Xml.Linq;
using System.Data;

namespace Lab11
{
    public static class Reflector
    {
        public static StreamWriter Write = new("toWrite.txt", false);
        static StreamReader Read = new("toRead.txt");
        static public void AssemblyInfo(string Name)
        {
            if (Name == "CheckRefl")
            {
                string full = "Lab11." + Name;
                var mytype = Type.GetType(full);
                Assembly assembly = Assembly.GetExecutingAssembly();
                Console.WriteLine($"Сборка - {mytype.Assembly}");
                Write.WriteLine($"Сборка - {mytype.Assembly}");
            }
            else
            {
                Assembly assembly = Assembly.GetExecutingAssembly();
                Console.WriteLine($"Сборка - {assembly.FullName}");
                Write.WriteLine($"Сборка - {assembly.FullName}");
            }

        }

        static public void CtorInfo(string Name)
        {
            Type mytype;
            string full;
            if (Name == "CheckRefl")
            {
                full = "Lab11." + Name;
                mytype = Type.GetType(full);

            }
            else {
                full = Name;
                mytype = full.GetType();
            }
            Console.WriteLine("\nИнформация о конструкторах");
            Write.WriteLine("\nИнформация о конструкторах");
            foreach (var el in mytype.GetConstructors())
            {
                if (el.IsPublic)
                {
                    Console.WriteLine("Публичный конструктор:" + el);
                    Write.WriteLine("Публичный конструктор:" + el);
                }
            }
        }

        public static  void Method(string Name)
        { 
            int i = 1;
            Type mytype;
            string full;
            if (Name == "CheckRefl")
            {
                full = "Lab11." + Name;
                mytype = Type.GetType(full);

            }
            else
            {
                full = Name;
                mytype = full.GetType();
            }
            Console.WriteLine("\nМетоды класса:");
            Write.WriteLine("\nМетоды класса:");
            foreach (MethodInfo mi in mytype.GetMethods())
            {
                if (mi.IsPublic)
                {
                    Console.WriteLine($"Имя метода #{i} = {mi.Name}");
                    Console.WriteLine("Тип возвращаемого значения = " + mi.ReturnType);
                    i++;
                    Write.WriteLine($"Имя метода #{i} = {mi.Name}, тип возвращаемого значения = {mi.ReturnType} ");
                    foreach (ParameterInfo pi in mi.GetParameters())
                    {
                        Console.WriteLine("Название параметра = " + pi.Name);
                        Console.WriteLine("Тип параметра = " + pi.ParameterType);
                    }
                }
            }
        }
        static public void Interface(string Name)
        {
            Type mytype;
            string full;
            if (Name == "CheckRefl")
            {
                full = "Lab11." + Name;
                mytype = Type.GetType(full);

            }
            else
            {
                full = Name;
                mytype = full.GetType();
            }
            Console.WriteLine("\nИнтерфейсы класса:");
            Write.WriteLine("\nИнтерфейсы класса:");
            foreach(Type iType in mytype.GetInterfaces())
            {
                Console.WriteLine(iType.Name);
                Write.WriteLine(iType.Name);
            }
        }
        static public void MethodForType(string Name, Type parametr)
        {
            int a = 0;
            Type mytype;
            string full;
            if (Name == "CheckRefl")
            {
                full = "Lab11." + Name;
                mytype = Type.GetType(full);

            }
            else
            {
                full = Name;
                mytype = full.GetType();
            }
            Write.WriteLine($"\nМетоды класса \"{Name}\" с типом параметра {parametr}:");
            Console.WriteLine($"\nМетоды класса \"{Name}\" с типом параметра {parametr}:");
            foreach(MethodInfo mi in mytype.GetMethods())
            {
                foreach (ParameterInfo pi in mi.GetParameters())
                {
                    if(pi.ParameterType == parametr)
                    {
                        Console.WriteLine($"Имя метода = {mi.Name}");
                        Write.WriteLine($"Имя метода = {mi.Name}");
                        a++;
                        break;
                    }
                }
            }
            if(a == 0)
            {
                Console.WriteLine("Такие методы отсутствуют");
                Write.WriteLine("Такие методы отсутствуют");
            }

        }
        static public void Voke(string name, string methode)
        {
            string p = Read.ReadLine();
            var parms = new object[] {p};
            string full = "Lab11." + name;
            var type = Type.GetType(full);
            var obj = Activator.CreateInstance(type);
            var methodInfo = type.GetMethod(methode);
            var result = methodInfo.Invoke(obj, parms);
            Console.WriteLine("\n\nРезультат метода Voke: " + result);
            Write.WriteLine("\n\nРезультат метода Voke: " + result + "\n\n\n");
        }
        public static object Create(string name, object[] param)
        {
            int a = 0;
            string full = "Lab11." + name;
            var mytype = Type.GetType(full);
            object obj = Activator.CreateInstance(mytype, param);
            Console.WriteLine(obj.ToString());
            return obj;

        }
    }
}
 