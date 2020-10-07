using System;
using System.Collections.Generic;
using System.IO;

namespace BinaryTree
{
    class Program
    {
        // Пример использования дерева для поиска по интервалу
        static void Main(string[] args)
        {





            var tree = LoadTree("keys","dict.txt");
            var list = tree.FindInInterval(1,1000); 
            foreach(var x in list)
                Console.WriteLine(x.Key  + "  " + x.Data);
        }
        // Добавление в дерево узлов из файлов
        static Tree<int, string> LoadTree(string pathToKey,string pathToValue)
        {
            List<string> listKey;
            string str;
            var rnd = new Random();
            using (var sr = new StreamReader(pathToKey))
            {
                str = sr.ReadToEnd();
            }
            listKey = new List<string>(str.Split('\n'));
            using(var sr = new StreamReader(pathToValue))
            {
                str = sr.ReadToEnd();

            }
            var listValue = new List<string>(str.Split('\n'));
            var tree = new Tree<int, string>();
            for(int i = 0; i < listKey.Count-1; i++)
            {
                tree.Add(int.Parse(listKey[i]), listValue[rnd.Next(1,listValue.Count)]);
            }
            return tree;
        }



    }
}
