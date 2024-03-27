using System.Data.Common;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading.Channels;


Char PlStat = new Char();
string name;
string yn;

bool undead = false;

string choose;
bool adv = false;
bool mag = false;

int Floor = 1;

bool GameOver = true;


string Command;

Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine("_________________________________________________________\n");
System.Console.WriteLine("Warning: Do not press any key while dialog is processing.");
Console.WriteLine("_________________________________________________________");
Console.ResetColor();

Thread.Sleep(1000);
System.Console.WriteLine("Welcome to Rouge Path!");
System.Console.WriteLine("The goal of this game is reach the 100th floor of the Hopeless Tower!!");
System.Console.WriteLine("Let's give a name for the hero who dares to beat the tower:\n");







bool NameCon = false;
while (true)
{
    
    while(!NameCon)
    {
        
        
        name = Console.ReadLine();
        PlStat.GetName = name;
        while(true)
        {
            System.Console.WriteLine($"\nIs your name '{name}'?\n");

            yn = Console.ReadLine().ToLower();

            if(yn == "y" || yn == "yes")
            {
                System.Console.WriteLine($"\nAlright {name} choose your class!\n");
                NameCon = true;
                break;
            }
            else if (yn == "n" || yn == "no")
            {
                System.Console.WriteLine("\nLet's write it again.\n");
                break;
            }
            else
            {
                System.Console.WriteLine("\nPlease answer the question.\n");
                continue;
            }
        }
        if(NameCon)
        {
            break;
        }
    }

    GameOver = false;

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

        else if(choose == "name")
        {
            System.Console.WriteLine("\nDo you wish to change your name?\n");
            
            yn = Console.ReadLine().ToLower();

            if (yn.Contains('y') || yn == "yes")
            {
                NameCon = false;
                break;
            }
            else if (yn.Contains('n') || yn == "no")
            {
                continue;
            }


        }
        else{
            System.Console.WriteLine($"\nThe class you provide is unavailable. If you wish to change your name type 'name'.\n");
            continue;
        }

    }

    

    Char Enemy = new Char();

    if(GameOver)
    {
        continue;
    }
    
    if (adv == true)
    {

        PlStat.SPD = 10;
        PlStat.BaseHP = 100;
        PlStat.HP = 100;
        PlStat.AGI = 20;
        PlStat.SPD = 10;

        while (Floor != 100 && GameOver == false)
        {

            bool EnemyIsDead = false;
            bool HeroIsdead;
            Enemy.HP = 20 + (Floor - 1) * 10;
            Enemy.BaseHP = 20 + (Floor - 1) * 10;
            Enemy.SPD = 12;
            Enemy.AGI = 12;
            Enemy.GetName = "The Rat";
            
            
            
            System.Console.WriteLine($"Floor: {Floor}.\n");
            System.Console.WriteLine($"You've faced {Enemy.GetName}\n");
            System.Console.WriteLine($"{Enemy.GetName}'s HP : [{Enemy.HP}/{Enemy.BaseHP}]");

            while (true)
            {
                PlStat.ATK = Random.Shared.Next(10, 15);

                Command = Console.ReadLine().ToLower();
                // Mechanics(PlStat, Enemy);

                if (Command == "help")
                {
                    System.Console.WriteLine("This is the command list:\n[Enter] to Attack.\nWrite 'stat' to veiw your status.\nWrite 'skill' for open skill list.\nWrite 'item' for item list.\nWrite 'run' or 'esc' to escape the enemy to previous floor (Chances up to your SPD).");
                    System.Console.WriteLine("\n[Enter] to continue.\n");
                    continue;
                }
                if (Command == "stats" || Command == "stat")
                {
                    System.Console.WriteLine($"{PlStat.GetName}' Status:\nHP: [{PlStat.HP}]\nSTR: [10]\nAGI: [{PlStat.AGI}]\nSPD: [{PlStat.SPD}]");
                    System.Console.WriteLine("\n[Enter] to continue.\n");
                    continue;
                }

                Enemy.HP = Enemy.HP - PlStat.ATK;
                System.Console.WriteLine($"You deal {PlStat.ATK} damage to the enemy!");
                System.Console.WriteLine($"Enemy's HP is now {Enemy.HP}!");

                
                if (!EnemyIsDead)
                {
                    EnemyIsDead = Enemy.IsDead();
                    HeroIsdead = PlStat.IsDead();
                    if(EnemyIsDead)
                    {
                        Floor++;
                        break;
                    }
                    if (HeroIsdead)
                    {
                        
                        GameOver = true;
                        break;
                    }
                    else
                    {
                    
                        Enemy.ATK = Random.Shared.Next(2 +(Floor - 1), 5 + (Floor - 1));
                        PlStat.HP = PlStat.HP - Enemy.ATK;
                        System.Console.WriteLine($"Enemy deals {Enemy.ATK} damage to you!");
                        System.Console.WriteLine($"Your HP is now {PlStat.HP}!");
                    }
                    
                }
                
                

            }
        }
    }

    if(mag == true)
    {

    }



}
Console.ReadLine();












// static bool Mechanics(Char PlStat, Char Enemy)
// {
//     if (PlStat.SPD > Enemy.SPD)
//     {
//         int Chance = PlStat.SPD - Enemy.SPD;
//         int Dodge = Random.Shared.Next(0, Chance);

//         if (Dodge > 5)
//         {
//             System.Console.WriteLine("The enemy missed the attack!");
//             PlStat.ATK = 0;
//             return true;
//         }
        
//     }
//     return false;

// }