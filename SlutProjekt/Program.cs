using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

string name;
string yn;

bool undead = false;

string choose;

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
    System.Console.WriteLine(role);
}

choose = Console.ReadLine().ToLower();

while(true)
{
    if(choose == "adventurer" || choose.Contains("ad"))
    {
        System.Console.WriteLine("The Adventurer class specializes in physical melee attacks as its main source of damage. You will have high STM (stamina), HP (health points), and DEF (defense) with average ATK (attack). However, you can't use magic; instead, you can use items to deal magic damage.");
        System.Console.WriteLine("You possess a shield that can reduce incoming damage by 5, but you will lose one turn. Additionally, you have a 'Charge Attack' skill that, when used, takes one turn and automatically attacks enemies with 3x damage.");
        System.Console.WriteLine("As a starting bonus, you receive 2x small healing potions (each healing 20 HP).");
        System.Console.WriteLine("Are you sure you want to start as the Adventurer?");

        yn = Console.ReadLine().ToLower();

        if (yn.Contains('y') || yn == "yes")
        {
            System.Console.WriteLine("Alright, let's start");
            break;
        }
        else if (yn.Contains('n') || yn == "no")
        {
            System.Console.WriteLine("Alright, let's decide again.");
            continue;
        }
        

    }

}


Console.ReadLine();