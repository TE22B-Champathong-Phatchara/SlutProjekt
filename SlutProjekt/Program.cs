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

bool EnemyIsDead = false;

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


if (adv == true)
{
    


    PlStat.GetName = name;
    PlStat.AGI = 10;
    

    System.Console.WriteLine(PlStat.GetName);
    while(Floor != 100)
    {
        if (Floor == 1)
        {
            Enemy.GetName = "The Rat";
            Enemy.HP = 20;
            
            Enemy.AGI = 12;

            System.Console.WriteLine($"You've faced {Enemy.GetName}");

            while(EnemyIsDead == false)
            {
                PlStat.ATK = Random.Shared.Next(10,15);
                
                Command = Console.ReadLine().ToLower();

                if (Command == "help")
                {
                    System.Console.WriteLine("This this command list:");
                    continue;
                }
                else if(EnemyIsDead == false)
                {
                    
                    Mechanics(PlStat, Enemy);
                    PlStat.HP = Enemy.HP - PlStat.ATK;
                    System.Console.WriteLine($"You deal {PlStat.ATK} damage to enemy!");
                    System.Console.WriteLine($"Enemy's  HP is now {Enemy.HP}!");

                    if (Enemy.HP <= 0)
                    {
                        Enemy.IsDead();
                        EnemyIsDead = true;
                    }
                    else
                    {
                        PlStat.HP = 100;
                        Enemy.ATK = Random.Shared.Next(2,5);
                        PlStat.HP = PlStat.HP - Enemy.ATK;
                        System.Console.WriteLine($"Enemy deal {Enemy.ATK} damage to you!");
                        System.Console.WriteLine($"your HP is now {PlStat.HP}!");
                    }
                }
                

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
            PlStat.ATK = 0;
        }
    }

}