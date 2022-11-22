﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
    internal class PLanguage
    {
        public string Lang_name { get; set; }
        public double Lang_ver { get; set; }
        public string[] Prorerties { get; set; }

        public PLanguage(string lang_name, double lang_ver,params string[] prorerties)
        {
            Lang_name = lang_name;
            Lang_ver = lang_ver;
            Prorerties = prorerties;
        }

        public void ChangeName(string n)
        {
            Console.WriteLine($"---Изменено имя языка {Lang_name} на {n} --");
            Lang_name = n;
        }
        public void ChangeVer(double v)
        {
            Console.WriteLine("---Изменена версия--");
            Lang_ver = v;
        }

        public void AddProperty(string prop)
        {
            string[] temp = new string[Prorerties.Length + 1];
            for (int i = 0; i < Prorerties.Length; i++)
            {
                temp[i] = Prorerties[i];
            }
            temp[temp.Length - 1] = prop;
            Prorerties = temp;
            Console.WriteLine($"Языку {Lang_name} добавлено свойство: {prop}");
        }
        public void DeleteProperty(string somePror)
        {
            bool y = false;
            for (int i = 0; i < Prorerties.Length; i++)
            {
                if (Prorerties[i] == somePror)
                {
                    y = true;
                }
            }
            if (y == true)
            {
                string[] temp = new string[Prorerties.Length - 1];
                int a = 0;
                for (int o = 0; o < Prorerties.Length; o++)
                {
                    if (Prorerties[o] != somePror)
                        temp[a] = Prorerties[o];
                    a++;
                }
                Prorerties = temp;
                Console.WriteLine($"Из языка {Lang_name} исключено свойство : {somePror}");
            }
            else
                Console.WriteLine("Заданное свойство не найдено");
        }

        public override string ToString()
        {
            string s = "";
            for (int i = 0; i < this.Prorerties.Length; i++)
            {
                s += this.Prorerties[i] + ", ";
            }
             s = s.Remove(s.Length - 2, 1);
            return $"\nЯзык: {this.Lang_name} версии {this.Lang_ver}\nСвойства: {s}\n";
        }


    }
}
