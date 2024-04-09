using System.Data.Common;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading.Channels;


Char PlStat = new Char();
string name;
string yn;


bool GameOver;

int potions = 3;
int BiggerPotion = 2;

int coinsdrop;
int coins;

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

            if(YesContains(yn))
            {
                System.Console.WriteLine($"\nAlright {name} let's start!\n");
                Thread.Sleep(2000);
                Console.Clear();
                NameCon = true;
                break;
            }
            else if (NoContains(yn))
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
    
    PlStat.STM = 300;
    PlStat.BaseSTM = 300;
    PlStat.SPD = 10;
    PlStat.BaseHP = 100;
    PlStat.HP = 100;
    PlStat.AGI = 13;
    PlStat.SPD = 10;
    coins = 0;


    System.Console.WriteLine("\n\u001b[33mTips: type 'help' to veiw the commands.\n\u001b[0m");
    

    int Floor = 1;
    while (Floor != 100 && GameOver == false)
    {

        bool EnemyIsDead = false;
        bool HeroIsdead;
        Enemy.HP = 20 + (Floor - 1) * 10;
        Enemy.BaseHP = 20 + (Floor - 1) * 10;
        Enemy.SPD = Random.Shared.Next(5,15);
        Enemy.AGI = Random.Shared.Next(1,10);
        Enemy.GetName = "The Enemy";


        
        
        
        

        System.Console.WriteLine("_______________________________________________________________________________________________________\n");
        System.Console.WriteLine($"Floor: {Floor}.");
        System.Console.WriteLine("_______________________________________________________________________________________________________\n");

        Thread.Sleep(500);
        System.Console.WriteLine($"You encounter an enemy!\n");
        System.Console.WriteLine($"\u001b[91m{Enemy.GetName}\u001b[0m's HP : [{Enemy.HP}/{Enemy.BaseHP}]");
        System.Console.WriteLine($"\n\u001b[36m{PlStat.GetName}\u001b[0m's HP: [{PlStat.HP}/{PlStat.BaseHP}]");
        System.Console.WriteLine($"\u001b[36m{PlStat.GetName}\u001b[0m's Stamina: [{PlStat.STM}/{PlStat.BaseSTM}]\n");
        bool Guarded = false;
        while (true)
        {
            TurnUsed = false;
            PlStat.ATK = Random.Shared.Next(10, 15);
            Enemy.ATK = Random.Shared.Next(2 +(Floor - 1), 5 + (Floor - 1));

            Command = Console.ReadLine().ToLower();

            if (Command == "help")
            {
                System.Console.WriteLine("This is the command list:\n[Enter] to Attack.\nWrite 'stat' to veiw your status.\nWrite 'skill' for open skills list.\nWrite 'item' for items list.");
                System.Console.WriteLine("\n\u001b[33mTips: you can type 'info' after the name of skill or item to check the information.\u001b[0m\n");
                System.Console.WriteLine("\n[Enter] to continue.\n");
                continue;
            }
            if (Command == "stats" || Command == "stat")
            {
                System.Console.WriteLine($"\u001b[36m{PlStat.GetName}\u001b[0m's Status: \nHP: [{PlStat.HP}/{PlStat.BaseHP}]\nStamina: [{PlStat.STM}/{PlStat.BaseSTM}]\nSTR: [10]\nAGI: [{PlStat.AGI}]\nSPD: [{PlStat.SPD}]");
                Console.ForegroundColor = ConsoleColor.Yellow;
                System.Console.WriteLine($"\nCoins(s): [{coins}]");
                Console.ResetColor();
                System.Console.WriteLine("\n[Enter] to continue.\n");
                continue;
            }
            if (Command == "skill")
            {
                List<string> SkillList = new () {"[Guarding]", "[Charge Attack]"};
                System.Console.WriteLine("");
                foreach (var skills in SkillList)
                {
                    System.Console.WriteLine(skills);
                }
                System.Console.WriteLine("\n[Enter] to continue\n");
                continue;
            }
            if(Command.Contains("guar") && Command.Contains("info"))
            {
                System.Console.WriteLine("\nReduce incoming damage by 5.\nConsumes 10 stamina.\n");
                continue;
            }
            else if(Command.Contains("guar"))
            {   
                if (PlStat.STM >= 10)
                {
                    System.Console.WriteLine("\nYou raise up your shield.");
                    Thread.Sleep(500);
                    System.Console.WriteLine("10 stamina consumed.\n");
                    TurnUsed = true;
                    Guarded = true;
                    PlStat.STM = PlStat.STM - 10;
                }
                else
                {
                    System.Console.WriteLine("\nYou don't have enough stamina to use that skill\n");
                    continue;
                }
            }
            if(Command.Contains("char") && Command.Contains("info"))
            {
                System.Console.WriteLine("\nDeal critical damage for the next attack.\nConsumes 25 stamina.\n");
                continue;
            }
            else if(Command.Contains("char"))
            {
                if (PlStat.STM >= 25)
                {
                    System.Console.WriteLine("\nYou make a concentrate to your next attack.");
                    Thread.Sleep(500);
                    System.Console.WriteLine("25 stamina consumed.\n");
                    PlStat.ATK = PlStat.ATK * 2;
                    PlStat.STM = PlStat.STM - 25;
                }
                else
                {
                    System.Console.WriteLine("\nYou don't have enough stamina to use that skill\n");
                    continue;
                }
            }


            if (Command == "item")
            {
                List<(string, int)> ItemList = new();

                if (potions > 0)
                {
                    ItemList.Add(("Healing Potion(s)", potions));
                }
                if (BiggerPotion > 0)
                {
                    ItemList.Add(("Big Healing Potion(s)", BiggerPotion));
                }


                if (ItemList.Count == 0)
                {
                    System.Console.WriteLine("\nYou don't have anything in your inventory.\n");
                    continue;
                }
                else
                {
                    System.Console.WriteLine("");
                    foreach (var item in ItemList)
                    {
                        System.Console.WriteLine($"{item.Item1} x{item.Item2}");
                       
                    }
                    System.Console.WriteLine("");
                    continue;
                }
            }
            if (PotionContains(Command) && Command.Contains("info") && Command.Contains("big"))
            {
                System.Console.WriteLine("\nHeals 50 amount of HP.\n");
                continue;
            }
            if (PotionContains(Command) && Command.Contains("info"))
            {
                System.Console.WriteLine("\nHeals 20 amount of HP.\n");
                continue;
            }
            if (PotionContains(Command) && Command.Contains("big") && BiggerPotion > 0 && PlStat.HP < PlStat.BaseHP)
            {
                int healAmount2 = Math.Min(50, PlStat.BaseHP - PlStat.HP);
                PlStat.HP = PlStat.HP + healAmount2;
                System.Console.WriteLine($"\nHealed {healAmount2} amount of HP.");
                Thread.Sleep(500);
                System.Console.WriteLine("1 Big Healing Potion consumed");
                TurnUsed = true;
            }
            else if (PotionContains(Command) && potions > 0 && PlStat.HP < PlStat.BaseHP)
            {
                int healAmount1 = Math.Min(20, PlStat.BaseHP - PlStat.HP);
                PlStat.HP = PlStat.HP + healAmount1;
                System.Console.WriteLine($"\nHealed {healAmount1} amount of HP.");
                Thread.Sleep(500);
                System.Console.WriteLine("1 Healing Potion consumed.\n");
                TurnUsed = true;
            }
            
            else if (PotionContains(Command) && (BiggerPotion > 0 || potions > 0) && PlStat.HP == PlStat.BaseHP)
            {
                System.Console.WriteLine("Your HP is already full.");
                continue;
            }
            else if (PotionContains(Command) && (potions <= 0 || BiggerPotion <= 0))
            {
                System.Console.WriteLine("\nYou don't have that.\n");
                continue;
            }




            if(PlStat.HP > 0 && TurnUsed == false)
            {
                Enemy.HP = Enemy.HP - PlStat.ATK;
                System.Console.WriteLine($"You deal {PlStat.ATK} damage to the enemy!");
                Thread.Sleep(500);
                System.Console.WriteLine($"\n{Enemy.GetName}'s HP : [{Enemy.HP}/{Enemy.BaseHP}]\n");
                
            }

            Missed(Enemy, PlStat, Floor);

            if (!EnemyIsDead)
            {
                EnemyIsDead = Enemy.IsDead();
                HeroIsdead = PlStat.IsDead() || PlStat.Tired();
                

                if(EnemyIsDead)
                {
                    Thread.Sleep(500);
                    coinsdrop = Random.Shared.Next(2 + Floor, 6 + Floor);
                    coins = coins + coinsdrop;

                    System.Console.WriteLine($"\nCoin(s) obtained [{coinsdrop}]\n");
                    
                    int StaminaLoses = Random.Shared.Next(3,6);
                    PlStat.STM = PlStat.STM - StaminaLoses;
                    System.Console.WriteLine($"Moving to next floor.\n{StaminaLoses} stamina used.");
                    
                    
                    Floor++;

                    if (Floor > 5)
                    {
                        int SafeZone = Random.Shared.Next(10);

                        if (SafeZone > 5)
                        {
                            System.Console.WriteLine("\nYou have enter the Safe Zone.");
                            Thread.Sleep(1000);
                            System.Console.WriteLine("\nThe Mystery Market has appeared!");
                            System.Console.WriteLine("You feel you can rest here. However, you're limited with the time in the Safe Zone.");
                            System.Console.WriteLine("You need to choose wisely. Do you want to take a look at the shop or rest to recover 50 statmina?\n");
                            while (true)
                            {
                                yn = Console.ReadLine();
                                if (YesContains(yn))
                                {
                                    List<string> ShopItems = new() {"Healing Potions", "Big Healing Potions", "ATK orb upgrade", "HP orb upgrade"};
                                    break;
                                }
                                else if (NoContains(yn))
                                {
                                    System.Console.WriteLine("\nYou find some place to sleep. After you wake up the Mystery Market has disappeared.\n");
                                    PlStat.STM += 50;
                                    break;
                                }
                                else
                                {
                                    System.Console.WriteLine("\nWhat do you want to do?\n");
                                    continue;
                                }
                            }
                        }
                    }




                    break;
                }
                if (HeroIsdead)
                {
                    System.Console.WriteLine("\nContinue?\n");

                    while(true)
                    {
                        yn = Console.ReadLine().ToLower();
                        if (YesContains(yn))
                        {
                            System.Console.WriteLine("May the light embraces.");
                            Thread.Sleep(2000);
                            GameOver = true;
                            Console.Clear();
                            break;
                        }
                        else if (NoContains(yn))
                        {
                            System.Console.WriteLine("Understood. You can pick up your sword again anytime.");
                            Thread.Sleep(3000);
                            System.Environment.Exit(0);
                        }
                        else
                        {
                            System.Console.WriteLine("Please answer the question.");
                            continue;
                        }
                    }
                    break;
                }
                else
                {
                    
                    if (Guarded)
                    {  
                        if (Enemy.ATK < 5)
                        {
                            Enemy.ATK = 0;
                        }
                        else if (Enemy.ATK >= 5)
                        {
                            Enemy.ATK = Enemy.ATK - 5;
                        }
                    }
                    Guarded = false;
                    PlStat.HP = PlStat.HP - Enemy.ATK;
                    System.Console.WriteLine($"Enemy deals {Enemy.ATK} damage to you!");
                    Thread.Sleep(500);
                    System.Console.WriteLine($"\n{PlStat.GetName}'s HP: [{PlStat.HP}/{PlStat.BaseHP}]\n");
                }
                
            }
        }
    }
    if(GameOver)
    {
        continue;
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

static bool PotionContains(string Command)
{
    return Command.Contains("heal") || Command.Contains("pot");
}

static bool YesContains(string yn)
{
    return yn.Contains('y') || yn == "yes";
}
static bool NoContains(string yn)
{
    return yn.Contains('n') || yn == "no";
}

