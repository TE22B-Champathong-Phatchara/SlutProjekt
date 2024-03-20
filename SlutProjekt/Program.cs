using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Threading.Channels;

string name;
string yn;

bool undead = false;

string choose;
bool adv = false;
bool mag = false;

int Floor = 1;

bool EnimyIsDead = false;

string Command;

Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine("_________________________________________________________\n");
System.Console.WriteLine("Warning: Do not press any key while dialog is processing.");
Console.WriteLine("_________________________________________________________");
Console.ResetColor();

Thread.Sleep(1000);
System.Console.WriteLine("Welcome to Rouge Path!");
System.Console.WriteLine("The goal of this game is reach the 100th floor of the Hopeless Tower!!");
System.Console.WriteLine("Let's give a name of hero who dares to beat the tower:\n");
while(true)
{
    name = Console.ReadLine();

    System.Console.WriteLine($"\nIs your name '{name}'?\n");

    yn = Console.ReadLine().ToLower();

    if(yn == "y" || yn == "yes")
    {
        System.Console.WriteLine($"\nAlright {name} choose your class!\n");
        break;
    }
    else if (yn == "n" || yn == "no")
    {
        System.Console.WriteLine("\nLet's write it again.\n");
        continue;
    }
    else
    {
        System.Console.WriteLine("\n Please answer the question.\n");
        continue;
    }

}








while(true)
{
    List<string> classes = new List<string>(["Adventurer" , "Mage" , "Archer"]);

    if (undead == false){
        classes.Add("LOCKED");
    }
    if (undead == true)
    {
        classes.Add("Undead");
    }

    foreach (var role in classes)
    {
        System.Console.WriteLine(role + "\n");
    }



    choose = Console.ReadLine().ToLower();

    if(choose == "adventurer" || choose.Contains("ad"))
    {
        System.Console.WriteLine("\nThe Adventurer class specializes in physical melee attacks as its main source of damage. You can't use magic; instead, you can use items to deal magic damage.");
        System.Console.WriteLine("As a starting bonus, you receive 2x small healing potions (each healing 20 HP).");
        System.Console.WriteLine("Are you sure you want to start as the Adventurer?");

        yn = Console.ReadLine().ToLower();

        if (yn.Contains('y') || yn == "yes")
        {
            System.Console.WriteLine("Alright, let's start");
            adv = true;
            break;
        }
        else if (yn.Contains('n') || yn == "no")
        {
            System.Console.WriteLine("Alright, let's decide again.");
            continue;
        }
    }

    else if(choose == "mage" || choose.Contains("ma"))
    {
        System.Console.WriteLine("The Mage class specializes in magic attacks");
        
        yn = Console.ReadLine().ToLower();

        if (yn.Contains('y') || yn == "yes")
        {
            System.Console.WriteLine("Alright, let's start");
            mag = true;
            break;
        }
        else if (yn.Contains('n') || yn == "no")
        {
            System.Console.WriteLine("Alright, let's decide again.");
            continue;
        }
    }

    else{
        System.Console.WriteLine("Ivalid input.");
        continue;
    }

}

Char PlStat = new Char();

Char Enemy = new Char();
PlStat.IsDead();
Enemy.IsDead();

Mechanics(PlStat, Enemy);
if (adv == true)
{
    


    PlStat.GetName = name;
    PlStat.HP = 100;
    PlStat.ATK = Random.Shared.Next(10,15);
    

    System.Console.WriteLine(PlStat.GetName);
    while(Floor != 100)
    {
        if (Floor == 1 && EnimyIsDead == false)
        {
            Enemy.GetName = "The Rat";
            Enemy.HP = 20;
            Enemy.ATK = Random.Shared.Next(2,5);

            System.Console.WriteLine($"You've faced {Enemy.GetName}");

            while(EnimyIsDead == false)
            {
                Command = Console.ReadLine().ToLower();a

            }
        }
    }
}
if(mag == true)




Console.ReadLine();












static void Mechanics(Char PlStat, Char Enemy)
{
    if (PlStat.AGI > Enemy.AGI)
    {
        int Chance = PlStat.AGI - Enemy.AGI;
        int Dodge = Random.Shared.Next(0, Chance);

        if (Dodge > 5)
        {
            System.Console.WriteLine("The enemy missed the attack!");
        }
    }

}