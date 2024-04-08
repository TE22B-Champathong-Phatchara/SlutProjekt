using System.Data.Common;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading.Channels;


Char PlStat = new Char();
string name;
string yn;
int Floor = 1;

bool GameOver;


string Command;
bool TurnUsed;

Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine("_________________________________________________________\n");
System.Console.WriteLine("Warning: Do not press any key while dialog is processing.");
Console.WriteLine("_________________________________________________________");
Console.ResetColor();

Thread.Sleep(1000);
System.Console.WriteLine("\nWelcome to Rouge Path!");
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
                System.Console.WriteLine($"\nAlright {name} let's start!\n");
                Thread.Sleep(2000);
                Console.Clear();
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

    Char Enemy = new Char();

    if(GameOver)
    {
        continue;
    }
    
    PlStat.STM = 300;
    PlStat.BaseSTM = 300;
    PlStat.SPD = 10;
    PlStat.BaseHP = 100;
    PlStat.HP = 100;
    PlStat.AGI = 20;
    PlStat.SPD = 10;

    Console.ForegroundColor = ConsoleColor.Yellow;
    System.Console.WriteLine("\nTips: type 'help' to veiw the commands.\n");
    Console.ResetColor();


    while (Floor != 100 && GameOver == false)
    {

        bool EnemyIsDead = false;
        bool HeroIsdead;
        Enemy.HP = 20 + (Floor - 1) * 10;
        Enemy.BaseHP = 20 + (Floor - 1) * 10;
        Enemy.SPD = 12;
        Enemy.AGI = 1;
        Enemy.GetName = "The Enemy";


        
        
        
        

        System.Console.WriteLine("_______________________________________________________________________________________________________\n");
        System.Console.WriteLine($"Floor: {Floor}.");
        System.Console.WriteLine("_______________________________________________________________________________________________________\n");

        Thread.Sleep(500);
        System.Console.WriteLine($"You encounter an enemy!\n");
        System.Console.WriteLine($"\u001b[91m{Enemy.GetName}\u001b[0m's HP : [{Enemy.HP}/{Enemy.BaseHP}]");
        System.Console.WriteLine($"\n\u001b[36m{PlStat.GetName}\u001b[0m's HP: [{PlStat.HP}/{PlStat.BaseHP}]");

        while (true)
        {
            TurnUsed = false;
            PlStat.ATK = Random.Shared.Next(10, 15);
            Enemy.ATK = Random.Shared.Next(2 +(Floor - 1), 5 + (Floor - 1));

            Command = Console.ReadLine().ToLower();

            if (Command == "help")
            {
                System.Console.WriteLine("This is the command list:\n[Enter] to Attack.\nWrite 'stat' to veiw your status.\nWrite 'skill' for open skills list.\nWrite 'item' for items list.\nWrite 'run' or 'esc' to escape the enemy to previous floor (Chances up to your SPD).");
                System.Console.WriteLine("\n\u001b[33mTips: you can type info after the name of skill or item to the information.\u001b[0m\n");
                System.Console.WriteLine("\n[Enter] to continue.\n");
                continue;
            }
            if (Command == "stats" || Command == "stat")
            {
                System.Console.WriteLine($"\u001b[36m{PlStat.GetName}\u001b[0m's Status: \nHP: [{PlStat.HP}/{PlStat.BaseHP}]\nStamina: [{PlStat.STM}/{PlStat.BaseSTM}]\nSTR: [10]\nAGI: [{PlStat.AGI}]\nSPD: [{PlStat.SPD}]");
                System.Console.WriteLine("\n[Enter] to continue.\n");
                continue;
            }
            if (Command == "skill")
            {
                List<string> SkillList = new () {"Guarding", "Charge Attack"};
                System.Console.WriteLine("");
                foreach (var skills in SkillList)
                {
                    System.Console.WriteLine(skills);
                }
                System.Console.WriteLine("\n[Enter to continue]\n");
                Console.ReadLine();
                continue;
            }
            if(Command.Contains("guar") && Command.Contains("info"))
            {
                System.Console.WriteLine("\nReduce incoming damage by 5.\nConsumes 10 stamina.\n");
                continue;
            }
            else if(Command.Contains("guar"))
            {
                System.Console.WriteLine("\nYou raise up your shield.");
                Thread.Sleep(500);
                System.Console.WriteLine("10 stamina consumed.\n");
                PlStat.STM = PlStat.STM - 10;
            }
            if(Command.Contains("char") && Command.Contains("info"))
            {
                System.Console.WriteLine("\nDeal critical damage for the next attack.\nConsumes 25 stamina.\n");
                continue;
            }
            else if(Command.Contains("char"))
            {
                System.Console.WriteLine("\nYou make a concentrate to your next attack.");
                Thread.Sleep(500);
                System.Console.WriteLine("25 stamina consumed.\n");
                PlStat.ATK = PlStat.ATK * 2;
                PlStat.STM = PlStat.STM - 25;
            }


            if (Command == "item")
            {
                List<string> ItemList = new List<string>();

                if (ItemList.Count == 0)
                {
                    System.Console.WriteLine("\nYou don't have anything in your inventory.\n");
                    continue;
                }
                else
                {
                    System.Console.WriteLine("");
                    foreach (string item in ItemList)
                    {
                        System.Console.WriteLine(item);
                        continue;
                    }
                }
            }





            if(PlStat.HP > 0 && TurnUsed == false)
            {
                Enemy.HP = Enemy.HP - PlStat.ATK;
                System.Console.WriteLine($"You deal {PlStat.ATK} damage to the enemy!");
                Thread.Sleep(500);
                System.Console.WriteLine($"\n{Enemy.GetName}'s HP : [{Enemy.HP}/{Enemy.BaseHP}]");
                
            }
            
            Missed(Enemy, PlStat, Floor);

            if (!EnemyIsDead)
            {
                EnemyIsDead = Enemy.IsDead();
                HeroIsdead = PlStat.IsDead();
                if(EnemyIsDead)
                {
                    Thread.Sleep(1000);
                    System.Console.WriteLine("Moving to next floor.\n1 stamina used.");
                    Floor++;
                    PlStat.STM--;
                    break;
                }
                if (HeroIsdead)
                {
                    System.Console.WriteLine("\nContinue?\n");

                    while(true)
                    {
                        yn = Console.ReadLine().ToLower();
                        if (yn.Contains('y') || yn == "yes")
                        {
                            System.Console.WriteLine("May the light embraces.");
                            Console.Clear();
                            break;
                        }
                        else if (yn.Contains('n') || yn == "no")
                        {
                            System.Console.WriteLine("Understood. You can pick up your sword again anytime.");
                            Thread.Sleep(3000);
                            System.Environment.Exit(0);
                        }
                    }

                    GameOver = true;
                    break;
                }
                else
                {
                    PlStat.HP = PlStat.HP - Enemy.ATK;
                    System.Console.WriteLine($"Enemy deals {Enemy.ATK} damage to you!");
                    Thread.Sleep(500);
                    System.Console.WriteLine($"\n{PlStat.GetName}'s HP: [{PlStat.HP}/{PlStat.BaseHP}]");
                }
                
            }
            
            

        }
    }
    

}





static void Missed(Char Enemy, Char PlStat, int Floor)
{
    bool EnemyMissed = Enemy.Missed();
    bool PlayerMissed = PlStat.Missed();

    if(PlayerMissed)
    {
        PlStat.ATK = 0;
    }
    else if(!PlayerMissed)
    {
        PlStat.ATK = Random.Shared.Next(10,15);
    }

    if(EnemyMissed)
    {
        Enemy.ATK = 0;
    }
    else if(!EnemyMissed)
    {
        Enemy.ATK = Random.Shared.Next(2 +(Floor - 1), 5 + (Floor - 1));
    }
}