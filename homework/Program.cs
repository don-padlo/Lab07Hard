int butterCost = 300;
int breadCost = 100;

void SwapCost(ref int a,ref int b){
    int c;int d;
    c = a;d = b;
    a = d;b = c;
}

Console.WriteLine($"до | Масло:{butterCost} Хлеб:{breadCost}");
SwapCost(ref butterCost, ref breadCost);
Console.WriteLine($"после | Масло:{butterCost} Хлеб:{breadCost}");
Console.WriteLine();

int wallet = 5000;
Console.WriteLine("Введите сумму покупки: ");
int cost = int.Parse(Console.ReadLine()!);
bool minusMoney_try;

balanceCheck(ref wallet, in cost, out minusMoney_try);
Console.WriteLine($"Операция успешна: {minusMoney_try}, Остаток на балансе: {wallet}, Стоимость покупок: {cost}");
Console.WriteLine();


void balanceCheck(ref int wallet, in int cost, out bool minusMoney_try)
{
    if (cost <= wallet)
    {
        wallet -= cost;
        minusMoney_try = true;
    }
    else
    {
        minusMoney_try = false;
    }
}
