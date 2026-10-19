// using System.IO.Pipelines;
// using System.Security.Cryptography;
// using System.Security.Cryptography.X509Certificates;

// // int x = 5;

// // DoubleValue(ref x);
// // Console.WriteLine(x); // 10 — изменилось

// // void DoubleValue(ref int number) {
// //     number *= 2;
// // }

// // Console.WriteLine();
// // int x1 = 9;
// // int y = 10;

// // Console.WriteLine($"x1 {x1} y{y}");
// // Swap(ref x1, ref y);
// // Console.WriteLine($"x1 {x1} y{y}");
// // void Swap(ref int a, ref int b){
// //     int c = a;
// //     int d = b;
// //     a = d;
// //     b = c;
// // }


// // int first= 17;
// // int second= 12;
// // int result;
// // int result_sc;
// // Console.WriteLine();
// // Console.WriteLine(TryDivide(first, second, out result,out result_sc));
// // Console.WriteLine($"частное:{result} ,остаток: {result_sc}");

// // bool TryDivide (int a,int b, out int result,out int result_sc){
// //     if (b==0){
// //         result = 0;result_sc = 0; return false;
// //     }else {
// //         result = a / b; result_sc=a%b;Console.WriteLine($"Результат деления: {result},остаток {result_sc}");return true;
// //     }
// // }


// // class Program
// // {

// //     static void Main()
// //     {
// //         CharacterStats stats = new CharacterStats();
// //         PrintStats(in stats);
// //     }
// //     struct CharacterStats
// //     {
// //         public int Health;
// //         public int Damage;
// //         public int Armor;
// //     }

// //     static void PrintStats(in CharacterStats stats)
// //     {
// //         Console.WriteLine($"HP: {stats.Health}");
// //         Console.WriteLine($"Урон: {stats.Damage}");
// //         Console.WriteLine($"Броня: {stats.Armor}");
// //     }

// // }



Character info = new Character();
info.name = "О' Хара";
info.gameClass = "Вор";
info.level = 1;
info.health = 100;
info.damage = 25;

Enemy stats = new Enemy();
stats.name_e = "Гоблин";
stats.damage_e = 11;
stats.health_e = 50;

int a = 100;
int b = 50;

Change_or_load(ref info);
//метод,который вызывает другие методы ref нужен,потому что метод будет вызывать методы,которые меняет значения.
    





void Change_Char(ref Character info){
    //ref нужен,чтобы метод мог вносить изменение в структе
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

void Change_or_load(ref Character info){
    int flag = 0;int var_2; string var_2_1="";int flag_1;
    while (flag == 0){
        Console.WriteLine("Изменить персонажа (1) или вывести (2)\nБой(3)\nДля отмены(0)\n");
        string variant = Console.ReadLine()!;
        Console.WriteLine();
    if (variant == "1"){
            Change_Char(ref info);
    }if (variant == "2"){
            var_2 = 0;
            while (var_2 == 0){
                Console.WriteLine("Хотите вывести только имя (0) имя+уровень+класс (1)?\n");
                Console.WriteLine("Введите число:\n");
                flag_1 = 0;
                while (flag_1 == 0) {
                    var_2_1 = Console.ReadLine()!;
                    if (var_2_1 == "1") { 
                        Console.WriteLine(); CharacterBase(in info,a,"1"); flag_1 = 1;var_2 = 1; 
                    }if (var_2_1 == "0"){
                        Console.WriteLine();CharacterBase(in info,a);flag_1 = 1;var_2 = 1;
                    }
                }

            }

    } else if (variant == "0"){
            Console.WriteLine("Выход"); flag=1;
    } else if (variant == "3")
        {
            battle(in info, in stats, out a, out b);
        }
        Console.WriteLine();
    } 
}

void CharacterBase(in Character info,int a,string variant = "0"){
//метод нужен,чтобы считывать информацию из структа и не вносить никаких изменений
    Console.WriteLine($"{info.name}-{a}hp");
    if (variant=="1"){
        Console.WriteLine($"{info.gameClass},{info.level}");//Форматирование,необязательные параметры
    }
}

void battle(in Character info,in Enemy stats,out int a,out int b){
//in считывает данные,а out выводит остаточное здоровье персонажей
    string move;a = info.health;b = stats.health_e;
    Console.WriteLine($"На вас нападает {stats.name_e}, наносит {stats.damage_e} урона"); a -= stats.damage_e;
    while (1==1)
    {
        Console.WriteLine($"Атаковать {stats.name_e}(1) или убежать(0)?\n");
        move = Console.ReadLine()!;
        if (move == "0"){
            break;
        }
        else if (move == "1" && b>0){
            Console.WriteLine($"\nВы атакуете {stats.name_e} и наносите ему {info.damage} урона, у противника ещё {b-info.damage} hp\n"); b -= info.damage;
        }else if (move == "1" && b<=0){
            Console.WriteLine($"{stats.name_e} повержен!");break;
        }


    }
}

struct Enemy
{
    public int health_e;
    public int damage_e;
    public string name_e;
}

struct Character
{
    public string name;
    public string gameClass;
    public int level;
    public int health;
    public int damage;
}