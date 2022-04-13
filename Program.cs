using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Linq;

namespace MyFirstProgram
{  //   1 завдання
   //   Дано список List<T> з об'єктами одного типу Obj, у якого в свою чергу є властивості Id та UserName.
   //   Організувати пошук для знаходження елемента колекції по обом властивостям

    class Player   // создаём класс игрока
    {
        public String username;  // объявляем переменные для характеристик игрока
        public Int32 id;
        public Player(String username, Int32 id) //передаём переменные игроку
        {
            this.username = username;
            this.id = id;

        }
        public override string ToString()  // объвляем метод, для конвертации данных из класса игрока,                                 
                                           //в формат string
        {
            return username;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Player> players = new List<Player>(); // создаём список игроков

            players.Add(new Player("Chad", 2124));
            players.Add(new Player("Steve", 54358));
            players.Add(new Player("Dasha", 9014));
            players.Add(new Player("Putin", 23124));    // добавляем игроков в список players
            players.Add(new Player("Dima", 2032));
            players.Add(new Player("Mike", 21939));
            foreach (Player player in players)
            {
                Console.WriteLine(player.username + " " + player.id);    // с помощью цикла форич перебираем всех пользователей и выводим их характеристики
                //Console.WriteLine(player);
            }
            var numberofpl = players.Count;   // подсчитываем кол-во игроков в списке 
            Console.WriteLine("Кол-во игроков:" + numberofpl);
            //  Console.WriteLine(players[0]);
            // Поиск по id
            Console.WriteLine("Введите 1, если хотите выполнить поиск по id, любую другую цифру, если по имени");
            int a = Int32.Parse(Console.ReadLine());
            if (a == 1)
            {
                Console.WriteLine("Введите id пользователя");
                int pattern = Int32.Parse(Console.ReadLine());
                Object finded = players.Find(item => item.id == pattern);                  // поиск имени игрока по характеристике ID и его позиция в списке
                int index1 = players.FindIndex(pattern => pattern == finded);       // используем методы Find, FindIndex для нашего поиска
                index1++;
                Console.WriteLine("Найденный пользователь - " + finded);
                Console.WriteLine("Найденный пользователь в списке игроков - " + index1);   // вывод
            }

            else
            {
                Console.WriteLine("Введитя Username пользователя");
                string pattern2 = Console.ReadLine();       // ввод имени пользователя                 // поиск ID игрока по характеристике username и его позиция в списке
                Object finded2 = players.Find(player => player.username == pattern2);         // создаём объект в который помещаем елемент, имя которого совпадает
                int index = players.FindIndex(pattern2 => pattern2 == finded2);        // поиск индекса елемента
                index++; 
                Player found = players.Find(item => item.username == pattern2);     // создаём объект в который помещаем елемент, имя которого совпадает
                Console.WriteLine("Найденный пользователь в списке игроков - " + index);   // вывод индеса пользователя
                Console.WriteLine("ID - " + found.id);  // найденный пользователь
            }

            Console.ReadKey();
            Console.WriteLine(new String('-', 50));

            // 2 завд
            // Написати програму для пошуку однакових значень пари ключ-значення.
            // Вхідний словник записати у JSON



            Dictionary<int, string> people = new Dictionary<int, string>();       // создаём словарь people с ключом и значением
            people.Add(12, "Misha");
            people.Add(13, "ork");
            people.Add(10, "Misha");      // добавляем людей в словарь
            people.Add(56, "ork");
            people.Add(5, "Kate");

            string json = JsonSerializer.Serialize(people);        // сериализация нашего словаря
            File.WriteAllText("dictionary.json", json);  //записываем словарь в json


            var result = 
                         from p in people            // объявляем некую переменную в словаре
                         group p by p.Value into g   // группируем все элементы этой переменной по значению в другую переменную
                         where g.Count() > 1     // подсчитываем эти елементы
                         select g;               // выбираем елементы

            foreach (var r in result)
            {                                            // с помощью цыкла форич перебираем все елменты в result
                var sameValue = (from p in r              // опеределяем ключи, к повторяющимся значениям
                                 select p.Key + "").ToArray();
                Console.WriteLine("{0} keys has the same value {1}",
                              string.Join(",", sameValue), r.Key);     // вывод
            }



            Console.ReadKey();
            Console.WriteLine(new String('-', 50));


            // 3 завд
            // Дана послідовність цілих чисел. Витягти з неї всі додатні числа,
            // зберігши їх вихідний порядок проходження.

            int[] arr = new int[] { -1, 1, -8, 3, 4, 2, -4, 900 };   // объявляем массив
            var res = String.Join(", ", arr.Where(n => n > 0));      // проводим поиск положительных елементов
            Console.WriteLine(res); // вывод
        }   
    }


}
