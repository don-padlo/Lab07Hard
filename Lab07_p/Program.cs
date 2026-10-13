using System.IO.Pipelines;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

// int x = 5;

// DoubleValue(ref x);
// Console.WriteLine(x); // 10 — изменилось

// void DoubleValue(ref int number) {
//     number *= 2;
// }

// Console.WriteLine();
// int x1 = 9;
// int y = 10;

// Console.WriteLine($"x1 {x1} y{y}");
// Swap(ref x1, ref y);
// Console.WriteLine($"x1 {x1} y{y}");
// void Swap(ref int a, ref int b){
//     int c = a;
//     int d = b;
//     a = d;
//     b = c;
// }


// int first= 17;
// int second= 12;
// int result;
// int result_sc;
// Console.WriteLine();
// Console.WriteLine(TryDivide(first, second, out result,out result_sc));
// Console.WriteLine($"частное:{result} ,остаток: {result_sc}");

// bool TryDivide (int a,int b, out int result,out int result_sc){
//     if (b==0){
//         result = 0;result_sc = 0; return false;
//     }else {
//         result = a / b; result_sc=a%b;Console.WriteLine($"Результат деления: {result},остаток {result_sc}");return true;
//     }
// }


// class Program
// {

//     static void Main()
//     {
//         CharacterStats stats = new CharacterStats();
//         PrintStats(in stats);
//     }
//     struct CharacterStats
//     {
//         public int Health;
//         public int Damage;
//         public int Armor;
//     }

//     static void PrintStats(in CharacterStats stats)
//     {
//         Console.WriteLine($"HP: {stats.Health}");
//         Console.WriteLine($"Урон: {stats.Damage}");
//         Console.WriteLine($"Броня: {stats.Armor}");
//     }

// }


class Program
{
    static void Main()
    {
        Character info = new Character();
        Change_or_load(ref info);
    }


    public struct Character
    {
        public string name;
        public string gameClass;
        public string level;

        public Character()
        {
            name = "О' Хара";
            gameClass = "Вор";
            level = "11";
        }
    }


    static void Change_Char(ref Character info){
        string variant;int flag = 0;
        while (flag == 0){
            Console.WriteLine("Изменить: имя(1), класс(2).\nВыход(0)\n");
            variant = Console.ReadLine()!;
            Console.WriteLine();

            if (variant == "1"){
                Console.WriteLine("Введите новое имя персонажа\n");
                info.name = Console.ReadLine()!;
                Console.WriteLine($"\nИмя персонажа теперь - {info.name}\n");
            }
            
            if (variant == "2"){
                Console.WriteLine("Введите новое название класса для вашего персонажа\n");
                info.gameClass = Console.ReadLine()!;
                Console.WriteLine($"\n{info.name} теперь - {info.gameClass}\n");
            }
            
            if (variant == "0"){
                Console.WriteLine("До свидания");flag = 1;
            }
        }
    }

    static void Change_or_load(ref Character info){
        int flag = 0;int var_2; string var_2_1="";string var_2_2="";int flag_1;int flag_2;
        while (flag == 0){
            Console.WriteLine("Изменить персонажа (1) или вывести (2)\nДля отмены(0)\n");
            string variant = Console.ReadLine()!;
            Console.WriteLine();
        if (variant == "1"){
                Change_Char(ref info);
        }if (variant == "2"){
                var_2 = 0;
                while (var_2 == 0){
                    Console.WriteLine("Хотите вывести только имя (0|0) имя+уровень (0|1) имя+класс (1|0) или всё вместе (1|1)?\n");
                    Console.WriteLine("Первое число:\n");
                    flag_1 = 0;
                    while (flag_1 == 0) {
                        var_2_1 = Console.ReadLine()!;
                        if (var_2_1 == "1" || var_2_1== "0") flag_1= 1;
                        }
                    Console.WriteLine("\nВторое число:\n");
                    flag_2 = 0;
                    while (flag_2==0){
                        var_2_2 = Console.ReadLine()!;
                        if (var_2_2 == "1" || var_2_2 == "0") flag_2 = 1;
                        }
                    Console.WriteLine(); CharacterBase(ref info, var_2_1, var_2_2);var_2 = 1;
                }
                
        } else if (variant == "0"){
                Console.WriteLine("Выход"); flag=1;
        }
            Console.WriteLine();
        } 
    }

    static void CharacterBase(ref Character info,string variant = "0",string level_var = "0"){
        if (variant == "0" && level_var == "0") {
            Console.WriteLine(info.name);
        }else if (variant == "1" && level_var == "0") {
            Console.WriteLine($"{info.name} - {info.gameClass}");
        }else if (variant == "0" && level_var == "1"){
            Console.WriteLine($"{info.name} - {info.level} уровень");
        }else if (variant == "1" && level_var =="1"){
            Console.WriteLine($"{info.name} - {info.gameClass} {info.level} уровня");
        }
    }
}