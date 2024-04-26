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
    int coinsdrop;
    int coins;
    PlStat.STM = 300;
    PlStat.BaseSTM = 300;
    PlStat.SPD = 10;
    PlStat.BaseHP = 100;
    PlStat.HP = 100;
    PlStat.AGI = 8;
    PlStat.SPD = 10;
    PlStat.BaseATK = 10;
    int potionPrice = 20;
    int BigpotionPrice = 50;
    int ATKprice = 100;
    int HPprice = 100;
    int STRup= 0;
    coins = 0;
    coinsdrop = 0;
    int potions = 0;
    int BiggerPotion = 0;
    
    while(!NameCon)
    {
        
        
        name = Console.ReadLine();
        PlStat.GetName = name;
        while(true)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                System.Console.WriteLine("\nYou can't leave you name empty!\n");
                break;
            }

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
    
    bool Skill1 = false;
    bool Skill2 = false;

    Char Enemy = new Char();
    
    

    System.Console.WriteLine("\n\u001b[33mTips: type 'help' to veiw the commands.\n\u001b[0m");
    
    bool BossStage = false;
    int Floor = 1;
    while (Floor != 100 && GameOver == false)
    {
        

        

        
        bool EnemyIsDead = false;
        bool HeroIsdead;
        

        Enemy.GetName = EnemiesName();
        if (!BossStage)
        {
            
            if (Enemy.GetName == "Rat")
            {
                Enemy.HP = 10 + (Floor - 1) * 10;
                Enemy.BaseHP = 10 + (Floor - 1) * 10;
                Enemy.ATK = Random.Shared.Next(2 +(Floor - 1), 4 + (Floor - 1));
                Enemy.AGI = Random.Shared.Next(1,8);
                Enemy.SPD = Random.Shared.Next(10,20);
                coinsdrop = Random.Shared.Next(12 + Floor, 19 + Floor);

            }
            else if (Enemy.GetName == "Goblin")
            {
                Enemy.HP = 25 + (Floor - 1) * 10;
                Enemy.BaseHP = 25 + (Floor - 1) * 10;
                Enemy.ATK = Random.Shared.Next(3 +(Floor - 1), 5 + (Floor - 1));
                Enemy.AGI = Random.Shared.Next(1,15);
                Enemy.SPD = Random.Shared.Next(3,15);
                coinsdrop = Random.Shared.Next(17 + Floor, 22 + Floor);
            }
            else if (Enemy.GetName == "Slime")
            {
                Enemy.HP = 30 + (Floor - 1) * 10;
                Enemy.BaseHP = 30 + (Floor - 1) * 10;
                Enemy.ATK = Random.Shared.Next(1 +(Floor - 1), 4 + (Floor - 1));
                Enemy.AGI = Random.Shared.Next(1,8);
                Enemy.SPD = Random.Shared.Next(3,17);
                coinsdrop = Random.Shared.Next(14 + Floor, 18 + Floor);
            }
        }
        else if (BossStage)
        {
            if (Enemy.GetName == "Rat")
            {
                Enemy.GetName = "The Rat King";
                Enemy.HP = 150;
                Enemy.BaseHP = 150;
                Enemy.ATK = Random.Shared.Next(12,18);
                Enemy.AGI = Random.Shared.Next(1,10);
                Enemy.SPD = Random.Shared.Next(18,20);
                coinsdrop = Random.Shared.Next(90, 120);

            }
            else if (Enemy.GetName == "Goblin")
            {
                Enemy.GetName = "The Goblin King";
                Enemy.HP = 230;
                Enemy.BaseHP = 230;
                Enemy.ATK = Random.Shared.Next(10,25);
                Enemy.AGI = Random.Shared.Next(5,15);
                Enemy.SPD = Random.Shared.Next(5,15);
                coinsdrop = Random.Shared.Next(100, 150);
            }
            else if (Enemy.GetName == "Slime")
            {
                Enemy.GetName = "The Slime King";
                Enemy.HP = 350;
                Enemy.BaseHP = 350;
                Enemy.ATK = Random.Shared.Next(9,14);
                Enemy.AGI = Random.Shared.Next(1,6);
                Enemy.SPD = Random.Shared.Next(6,15);
                coinsdrop = Random.Shared.Next(70, 100);
            }
        }

        
        
        
        

        System.Console.WriteLine("_______________________________________________________________________________________________________\n");
        System.Console.WriteLine($"Floor: {Floor}.");
        System.Console.WriteLine("_______________________________________________________________________________________________________\n");

        Thread.Sleep(500);
        if (BossStage)
        {
            System.Console.WriteLine("\n\u001b[34mThe Boss Has Appear!!\u001b[0m\n");
            System.Console.WriteLine($"You encounter \u001b[91m{Enemy.GetName}\u001b[0m!\n");
        }
        else
        {
            System.Console.WriteLine($"You encounter a \u001b[91m{Enemy.GetName}\u001b[0m!\n");
        }

        System.Console.WriteLine($"\u001b[91m{Enemy.GetName}\u001b[0m's HP : [{Enemy.HP}/{Enemy.BaseHP}]");
        System.Console.WriteLine($"\n\u001b[36m{PlStat.GetName}\u001b[0m's HP: [{PlStat.HP}/{PlStat.BaseHP}]");
        System.Console.WriteLine($"\u001b[36m{PlStat.GetName}\u001b[0m's Stamina: [{PlStat.STM}/{PlStat.BaseSTM}]\n");
        int SkillDuration = 0;
        bool Guarded = false;
        bool ThornGuarded = false;
        bool Spdboost = false;
        while (true)
        {
            if (Spdboost) 
            {
                if (SkillDuration >= 2) 
                {
                    PlStat.SPD = 10;
                    Spdboost = false;
                    SkillDuration = 0;    
                } else {
                    SkillDuration++; 
                }
            }
            
            TurnUsed = false;
            PlStat.ATK = Random.Shared.Next(10 + STRup, 15 + STRup);
            

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
                System.Console.WriteLine($"\n\u001b[36m{PlStat.GetName}\u001b[0m's Status: \nHP: [{PlStat.HP}/{PlStat.BaseHP}]\nStamina: [{PlStat.STM}/{PlStat.BaseSTM}]\nSTR: [{PlStat.BaseATK}]\nAGI: [10]\nSPD: [{PlStat.SPD}]");
                Console.ForegroundColor = ConsoleColor.Yellow;
                System.Console.WriteLine($"\nCoins(s): [{coins}] Gold.");
                Console.ResetColor();
                System.Console.WriteLine("\n[Enter] to continue.\n");
                continue;
            }
            if (Command == "skill")
            {
                List<string> SkillList = new () {};
                if (!Skill1)
                {
                    SkillList.Add("[Guarding]");
                }
                else if (Skill1)
                {
                    SkillList.Add("\u001b[35m[Guarding Thorns]\u001b[0m");
                }
                if (!Skill2)
                {
                    SkillList.Add("[Charge Attack]");
                }
                else if (Skill2)
                {
                    SkillList.Add("\u001b[35m[Super Charge Attack]\u001b[0m");
                }
                SkillList.Add("[Speed Boost]");

                System.Console.WriteLine("");
                foreach (var skills in SkillList)
                {
                    System.Console.WriteLine(skills);
                }
                System.Console.WriteLine("\n[Enter] to continue\n");
                continue;
            }
            if(Command.Contains("guar") && Command.Contains("info") && !Skill1)
            {
                System.Console.WriteLine("\nReduce incoming damage by 8.\nConsumes 10 stamina.\n");
                continue;
            }
            else if(Command.Contains("guar") && Command.Contains("info") && Skill1)
            {
                System.Console.WriteLine("Reduce incoming damage by 8 and reflex back by 3.\nConsumes 10 stamina.\n");
            }
            else if(Command.Contains("guar") && !Skill1)
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
            else if(Command.Contains("guar") && Skill1)
            {   
                if (PlStat.STM >= 10)
                {
                    System.Console.WriteLine("\nYou raise up your shield. You feel an uneasy power from it.");
                    Thread.Sleep(500);
                    System.Console.WriteLine("10 stamina consumed.\n");
                    TurnUsed = true;
                    ThornGuarded = true;
                    PlStat.STM = PlStat.STM - 10;
                }
                else
                {
                    System.Console.WriteLine("\nYou don't have enough stamina to use that skill\n");
                    continue;
                }
            }
            
            if(Command.Contains("char") && Command.Contains("info") && !Skill2)
            {
                System.Console.WriteLine("\nDeal critical damage for the next attack.\nConsumes 25 stamina.\n");
                continue;
            }
            if(Command.Contains("char") && Command.Contains("info") && Skill2)
            {
                System.Console.WriteLine("\nDeal 4x damage for the next attack.\nConsumes 30 stamina.\n");
                continue;
            }

            else if(Command.Contains("char") && !Skill2)
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
            else if(Command.Contains("char") && Skill2)
            {
                if (PlStat.STM >= 30)
                {
                    System.Console.WriteLine("\nYou make a concentrate to your next attack. The mysterious power makes you feel extra concentration.");
                    Thread.Sleep(500);
                    System.Console.WriteLine("30 stamina consumed.\n");
                    PlStat.ATK = PlStat.ATK * 4;
                    PlStat.STM = PlStat.STM - 30;
                }
                else
                {
                    System.Console.WriteLine("\nYou don't have enough stamina to use that skill\n");
                    continue;
                }
            }
            if ((Command.Contains("spe") || Command.Contains("boo")) && Command.Contains("info"))
            {
                System.Console.WriteLine("\nIncrease your SPD by 20 for two turns.\nConsumes 40 stamina.\n");
                continue;
            }
            else if (Command.Contains("spe") || Command.Contains("boo"))
            {
                if (PlStat.STM >= 40)
                {
                    System.Console.WriteLine("\nYou pray for the God of Wind. Your body feels more agile.");
                    Thread.Sleep(500);
                    System.Console.WriteLine("40 stamina comsumed.\n");
                    PlStat.STM = PlStat.STM - 40;
                    PlStat.SPD = 20;  
                    Spdboost = true; 
                    SkillDuration = 1;
                    TurnUsed = true;
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
                System.Console.WriteLine("\nHeals 70 amount of HP.\n");
                continue;
            }
            if (PotionContains(Command) && Command.Contains("info"))
            {
                System.Console.WriteLine("\nHeals 30 amount of HP.\n");
                continue;
            }
            if (PotionContains(Command) && Command.Contains("big") && BiggerPotion > 0 && PlStat.HP < PlStat.BaseHP)
            {
                int healAmount2 = Math.Min(70, PlStat.BaseHP - PlStat.HP);
                PlStat.HP = PlStat.HP + healAmount2;
                System.Console.WriteLine($"\nHealed {healAmount2} amount of HP.");
                Thread.Sleep(500);
                System.Console.WriteLine("1 Big Healing Potion consumed");
                BiggerPotion --;
                TurnUsed = true;
            }
            else if (PotionContains(Command) && potions > 0 && PlStat.HP < PlStat.BaseHP)
            {
                int healAmount1 = Math.Min(30, PlStat.BaseHP - PlStat.HP);
                PlStat.HP = PlStat.HP + healAmount1;
                System.Console.WriteLine($"\nHealed {healAmount1} amount of HP.");
                Thread.Sleep(500);
                System.Console.WriteLine("1 Healing Potion consumed.\n");
                potions --;
                TurnUsed = true;
            }
            
            else if (PotionContains(Command) && (BiggerPotion > 0 || potions > 0) && PlStat.HP >= PlStat.BaseHP)
            {
                System.Console.WriteLine("Your HP is already full.");
                continue;
            }
            else if (PotionContains(Command) && (potions <= 0 || BiggerPotion <= 0))
            {
                System.Console.WriteLine("\nYou don't have that.\n");
                continue;
            }
            



            // Missed(Enemy, PlStat, Floor, STRup, TurnUsed);
    

            if(PlStat.HP > 0 && TurnUsed == false)
            {
                if (Enemy.SPD > PlStat.AGI)
                {
                    // Console.WriteLine($"Debug: SPD = {Enemy.SPD}, AGI = {PlStat.AGI}");
                    int Chance = Enemy.SPD - PlStat.AGI; 
                    int ChanceToMiss = Random.Shared.Next(0,Chance);
                    // Console.WriteLine($"Debug: Chance = {Chance}, ChanceToMiss = {ChanceToMiss}");

                    if (ChanceToMiss > 7)
                    {
                        if (Enemy.HP > 0 && TurnUsed == false)
                        {
                            System.Console.WriteLine($"You missed!");
                            PlStat.ATK = 0;
                        }
                    }

                }
                Enemy.HP = Enemy.HP - PlStat.ATK;
                System.Console.WriteLine($"You deal {PlStat.ATK} damage to the enemy!");
                Thread.Sleep(500);
                System.Console.WriteLine($"\n\u001b[91m{Enemy.GetName}\u001b[0m's HP : [{Enemy.HP}/{Enemy.BaseHP}]\n");
                
            }

            
            

            
            if (!EnemyIsDead)
            {
                EnemyIsDead = Enemy.IsDead();
                HeroIsdead = PlStat.IsDead() || PlStat.Tired();
                

                if(EnemyIsDead)
                {
                    if(BossStage)
                    {
                        System.Console.WriteLine("\n\u001b[91m{Enemy.GetName}\u001b[0m has been defeated!!\n");
                        BossStage = false;
                    }
                    Thread.Sleep(500);
                    coins = coins + coinsdrop;
                    int potionsDrop = Random.Shared.Next(1,12);
                    if(potionsDrop == 1)
                    {
                        Thread.Sleep(500);
                        System.Console.WriteLine("\nThe Enemy had dropped an item!");
                        System.Console.WriteLine("1x Healing Potion obtained.\n");
                        potions++;
                    }

                    System.Console.WriteLine($"\nCoin(s) obtained [{coinsdrop}]\n");
                    
                    int StaminaLoses = Random.Shared.Next(3,6);
                    PlStat.STM = PlStat.STM - StaminaLoses;
                    System.Console.WriteLine($"Moving to next floor.\n{StaminaLoses} stamina used.");
                    
                    Floor++;

                    if (Floor > 5)
                    {
                        int SafeZone = Random.Shared.Next(1, 10);
                        int Void = Random.Shared.Next(1,20);

                        bool Shop;
                        bool Continue;

                        

                        if (Void == 5)
                        {
                            System.Console.WriteLine("_______________________________________________________________________________________________________\n");
                            System.Console.WriteLine("You entered the \u001b[91m!£@$€!\u001b[0m.");
                            System.Console.WriteLine("_______________________________________________________________________________________________________\n");
                            Thread.Sleep(1000);
                            System.Console.WriteLine("You feel unsafe here and you want to get out as fast as you can.");
                            System.Console.WriteLine("\n\u001b[91m'Hello.'\u001b[0m \nHowever, a mysterious and chilling voice stops you in your tracks.");
                            System.Console.WriteLine("This is unsafe for your life. Choose wisely whether you want to \u001b[32mlisten\u001b[0m to the voice or \u001b[32mget out\u001b[0m of here?\n");
                            while (true)
                            {
                                Command = Console.ReadLine().ToLower();

                                if (Command.Contains("lis"))
                                {
                                    System.Console.WriteLine("\nYou turn toward the source of the voice.");
                                    Thread.Sleep(500);
                                    System.Console.WriteLine("\u001b[91m'Good decision...'\u001b[0m");
                                    Thread.Sleep(500);
                                    System.Console.WriteLine("says the voice, as a shadowy figure appears before you.");
                                    System.Console.WriteLine("\u001b[91m'Call me Mr. A. I'm here to help you upgrade your skills.'\u001b[0m\n");

                                    System.Console.WriteLine("\u001b[33mTips: Write 'cancel' to refuse skill upgrades.\u001b[0m\n");

                                    while(true)
                                    {
                                        List<string> UpgradeList = new() {};
                                        if (Skill1 == false)
                                        {
                                            UpgradeList.Add("Guarding Thorns: 30 MaxHP.");
                                        }
                                        else if (Skill1 == true)
                                        {
                                            UpgradeList.Add("[Skill Already Upgraded]");
                                        }
                                        if (Skill2 == false)
                                        {
                                            UpgradeList.Add("Super Charge Attack: 70 MaxHP.");
                                        }
                                        else if (Skill1 == true)
                                        {
                                            UpgradeList.Add("[Skill Already Upgraded]");
                                        }
                                        System.Console.WriteLine("_______________________________________________________________________________________________________\n");
                                        foreach (String Upgrade in UpgradeList)
                                        {
                                            System.Console.WriteLine(Upgrade);

                                        }
                                        System.Console.WriteLine("_______________________________________________________________________________________________________\n");
                                        
                                        Command = Console.ReadLine().ToLower();

                                        if (Command.Contains("gua") || Command.Contains("tho") && Skill1 == false)
                                        {
                                            System.Console.WriteLine("\nUsing Guarding skill now reflects 3 damage back to the enemy.");
                                            Shop = ShopConfirm();
                                            if (Shop && PlStat.HP > 30)
                                            {
                                                PlStat.HP = PlStat.HP - 30;
                                                PlStat.BaseHP = PlStat.BaseHP - 30;
                                                Skill1 = true;
                                                System.Console.WriteLine($"\nYour skill has been upgraded.\nYour HP is now [{PlStat.HP}/{PlStat.BaseHP}].");
                                                Continue = ContinueShop();
                                                if(Continue)
                                                {
                                                    continue;
                                                }
                                                else
                                                {
                                                    break;
                                                }
                                            }
                                            else if (Shop && PlStat.HP <= 30)
                                            {
                                                System.Console.WriteLine("\n\u001b[91m'Not enough HP.'\u001b[0m\n");
                                                continue;
                                            }
                                            
                                        }
                                        if (Command.Contains("sup") || Command.Contains("cha") && Skill2== false)
                                        {
                                            System.Console.WriteLine("\nSuper Charge attack now deals x4 damage and counsumes 30 stamina.");
                                            Shop = ShopConfirm();
                                            if (Shop && PlStat.HP > 70)
                                            {
                                                PlStat.HP = PlStat.HP - 70;
                                                PlStat.BaseHP = PlStat.BaseHP - 70;
                                                Skill2 = true;
                                                System.Console.WriteLine($"\nYour skill has been upgraded.\nYour HP is now [{PlStat.HP}/{PlStat.BaseHP}].");
                                                Continue = ContinueShop();
                                                if(Continue)
                                                {
                                                    continue;
                                                }
                                                else
                                                {
                                                    break;
                                                }
                                            }
                                            else if (Shop && PlStat.HP <= 70)
                                            {
                                                System.Console.WriteLine("\n\u001b[91m'Not enough HP.'\u001b[0m\n");
                                                continue;
                                            }
                                            
                                        }
                                        if (Command.Contains("can"))
                                        {
                                            System.Console.WriteLine("\u001b[91m'You will regret this...'\u001b[0m said the voice before it faded away.");
                                            break;
                                        }
                                    }
                                    break;

                                }
                                if (Command.Contains('g') || Command.Contains('o'))
                                {
                                    System.Console.WriteLine("\nYou choose to turn back. Not any futher voice you can hear...\n");
                                    break;
                                }
                                else
                                {
                                    System.Console.WriteLine("\nWhat do you want to do?\n");
                                    continue;
                                }
                                
                            }
                        }

                        else if (SafeZone > 5)
                        {

                            System.Console.WriteLine("_______________________________________________________________________________________________________\n");
                            System.Console.WriteLine("You entered the Safe Zone.");
                            System.Console.WriteLine("_______________________________________________________________________________________________________\n");
                            Thread.Sleep(1000);
                            System.Console.WriteLine("\nThe Mystery Market has appeared!");
                            System.Console.WriteLine("You feel you can rest here. However, you're limited with the time in the Safe Zone.");
                            System.Console.WriteLine("You need to choose wisely. Do you want to take a look at the \u001b[32mmarket\u001b[0m or \u001b[32mrest\u001b[0m to recover 70 stamina and 20 HP?\n");
                            while (true)
                            {
                                Command = Console.ReadLine().ToLower();

                                if (Command.Contains("mar") || Command.Contains("sho"))
                                {
                                    System.Console.WriteLine("\nYou entered the Mystery Market.\n'Welcome' the voice appears in front of you. But there is no one in your sight.");
                                    System.Console.WriteLine($"\nGold you have: {coins} Gold.\n");
                                    
                                    
        
                                    
                                    System.Console.WriteLine("\n\u001b[33mTips: Write 'cancel' to exit the shop\u001b[0m");

                                    

                                    while(true)
                                    {
                                        
                                        
                                        List<(string, int)> ShopItems = new() {("Healing Potions", potionPrice),  ("Big Healing Potions", BigpotionPrice), ("ATK orb upgrade", ATKprice), ("HP orb upgrade", HPprice)};
                                        System.Console.WriteLine("_______________________________________________________________________________________________________\n");
                                        
                                        foreach (var item in ShopItems)
                                        {
                                            System.Console.WriteLine($"{item.Item1}: [{item.Item2}] Gold.");
                    
                                        }
                                        System.Console.WriteLine("_______________________________________________________________________________________________________\n");
                                        

                                        System.Console.WriteLine("\n'What do you want?' The voice asks you.\n");

                                        Command = Console.ReadLine().ToLower();

                                        if(PotionContains(Command) && Command.Contains("big"))
                                        {
                                            System.Console.WriteLine("\nThe Bigger Healing Potion heals 70 amount of HP.");
                                            Shop = ShopConfirm();
                                            if(Shop && coins >= BigpotionPrice)
                                            {
                                                coins -= BigpotionPrice;
                                                System.Console.WriteLine($"\nYou bought Big Healing Potion.\nYou have {coins} Gold left.");
                                                BiggerPotion ++;
                                                Continue = ContinueShop();
                                                if(Continue)
                                                {
                                                    continue;
                                                }
                                                else
                                                {
                                                    break;
                                                }
                                            }
                                            else if (Shop && coins < BigpotionPrice)
                                            {
                                                System.Console.WriteLine("\nYou don't have enough Gold to buy that.\n");
                                                continue;
                                            }
                                        }
                                        else if (PotionContains(Command))
                                        {
                                            System.Console.WriteLine("\nThe Healing Potion heals 30 amount of HP.");
                                            Shop = ShopConfirm();
                                            if (Shop && coins >= potionPrice)
                                            {
                                                coins -= potionPrice;
                                                System.Console.WriteLine($"You bought Healing Potion.\nYou have {coins} Gold left.");
                                                potions ++;
                                                Continue = ContinueShop();
                                                if(Continue)
                                                {
                                                    continue;
                                                }
                                                else
                                                {
                                                    break;
                                                }
                                            }
                                            else if (Shop && coins < potionPrice)
                                            {
                                                System.Console.WriteLine("\nYou don't have enough Gold to buy that.\n");
                                                continue;
                                            }
                                        }
                                        

                                        if (Command.Contains("atk"))
                                        {
                                            System.Console.WriteLine("\nIncrease your STR by 5.");
                                            Shop = ShopConfirm();
                                            if (Shop && coins >= ATKprice)
                                            {

                                                coins -= ATKprice;
                                                System.Console.WriteLine($"Your STR increased by 5.\nYou have {coins} Gold left.");
                                                PlStat.BaseATK += 5;
                                                Continue = ContinueShop();
                                                STRup += 5;
                                                ATKprice += 20;


                                                if(Continue)
                                                {
                                                    continue;
                                                }
                                                else
                                                {
                                                    break;
                                                }
                                            }
                                            else if (Shop && coins < ATKprice)
                                            {
                                                System.Console.WriteLine("\nYou don't have enough Gold to buy that.\n");
                                                continue;
                                            }
                                            
                                        }
                                        if (Command.Contains("hp"))
                                        {
                                            System.Console.WriteLine("\nIncrease your HP by 20.");
                                            Shop = ShopConfirm();
                                            if (Shop && coins >= HPprice)
                                            {
                                                coins -= HPprice;
                                                
                                                System.Console.WriteLine($"Your HP increased by 20.\nYou have {coins} Gold left.");
                                                PlStat.HP += 20;
                                                PlStat.BaseHP += 20;
                                                Continue = ContinueShop();
                                                HPprice = HPprice + 20;

                                                if(Continue)
                                                {
                                                    continue;
                                                }
                                                else
                                                {
                                                    break;
                                                }
                                            }
                                            else if (Shop && coins < HPprice)
                                            {
                                                System.Console.WriteLine("\nYou don't have enough Gold to buy that.\n");
                                                continue;
                                            }
                                            
                                        }
                                        if (Command == "cancel")
                                        {
                                            Console.WriteLine("\nThanks for visiting. See you later.\n");
                                            Thread.Sleep(500);
                                            break;
                                        }
                                    }



                                    break;
                                }
                                else if (Command.Contains("re"))
                                {
                                    System.Console.WriteLine("\nYou find some place to sleep. After you wake up the Mystery Market was gone.\n");
                                    PlStat.STM += 70;
                                    int RestoreAmount = Math.Min(20, PlStat.BaseHP - PlStat.HP);
                                    PlStat.HP += RestoreAmount;
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


                    if (Floor == 10)
                    {
                        System.Console.WriteLine("\n_______________________________________________________________________________________________________\n");
                        System.Console.WriteLine("Congratulation! This is really unexpect that you are able to reach the 10th floor...");
                        Thread.Sleep(1000);
                        System.Console.WriteLine("However, the way after this is really tough. Do you still wish to continue?\n");
                        while (true)
                        {
                            yn = Console.ReadLine().ToLower();

                            if(YesContains(yn))
                            {
                                System.Console.WriteLine("\nGood, you deserve to be a hero.\n");
                                Thread.Sleep(2000);
                                Console.Clear();
                                BossStage = true;
                                break;
                            }
                            else if(NoContains(yn))
                            {
                                System.Console.WriteLine("\nUnderstood. You can try it next time.\n");
                                Thread.Sleep(2000);
                                Console.Clear();
                                GameOver = true;
                                break;
                            }
                            else
                            {
                                System.Console.WriteLine("\nPlease answer the question.\n");
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
                    if (PlStat.SPD > Enemy.AGI)
                    {
                        // Console.WriteLine($"Debug: SPD = {PlStat.SPD}, AGI = {Enemy.AGI}");
                        int Chance = PlStat.SPD - Enemy.AGI;
                        int ChanceToMiss = Random.Shared.Next(0, Chance);
                        // Console.WriteLine($"Debug: Chance = {Chance}, ChanceToMiss = {ChanceToMiss}");
                        if (ChanceToMiss > 5)
                        {
                            if (Enemy.HP > 0)
                            {
                                System.Console.WriteLine($"\u001b[91m{Enemy.GetName}\u001b[0m missed!");
                                Enemy.ATK = 0;
                            }
                        }
                        else
                        {
                            Enemy.ATK = Random.Shared.Next(2 +(Floor - 1), 5 + (Floor - 1));
                            
                        }
                    }
                    
                    if (Guarded)
                    {  
                        if (Enemy.ATK < 8)
                        {
                            Enemy.ATK = 0;
                        }
                        else if (Enemy.ATK >= 8)
                        {
                            Enemy.ATK = Enemy.ATK - 8;
                        }
                    }
                    if (ThornGuarded  && Enemy.ATK != 0)
                    {
                        Enemy.HP -= 3;
                        if (Enemy.ATK < 8)
                        {
                            Enemy.ATK = 0;
                        }
                        else if (Enemy.ATK >= 8)
                        {
                            Enemy.ATK = Enemy.ATK - 8;
                        }
                    }
                    
                    Guarded = false;
                    PlStat.HP = PlStat.HP - Enemy.ATK;
                    System.Console.WriteLine($"\u001b[91m{Enemy.GetName}\u001b[0m deals {Enemy.ATK} damage to you!");
                    if (ThornGuarded  && Enemy.ATK != 0)
                    {
                        System.Console.WriteLine("The mysterious power from your shield strikes the enemy back with 3 damage.");
                        System.Console.WriteLine($"\n\u001b[91m{Enemy.GetName}\u001b[0m's HP : [{Enemy.HP}/{Enemy.BaseHP}]\n");
                    }
                    
                    Thread.Sleep(500);
                    System.Console.WriteLine($"\n\u001b[36m{PlStat.GetName}\u001b[0m's HP: [{PlStat.HP}/{PlStat.BaseHP}]");
                    System.Console.WriteLine($"\u001b[36m{PlStat.GetName}\u001b[0m's Stamina: [{PlStat.STM}/{PlStat.BaseSTM}]\n");
                }
                
            }
        }
    }
    if(GameOver)
    {
        continue;
    }

}





// static void Missed(Char Enemy, Char PlStat, int Floor, int STRup, bool TurnUsed)

// {   


//     if (PlStat.SPD > Enemy.AGI)
//     {
//         // Console.WriteLine($"Debug: SPD = {PlStat.SPD}, AGI = {Enemy.AGI}");
//         int Chance = PlStat.SPD - Enemy.AGI;
//         int ChanceToMiss = Random.Shared.Next(0, Chance);
//         // Console.WriteLine($"Debug: Chance = {Chance}, ChanceToMiss = {ChanceToMiss}");
//         if (ChanceToMiss > 5)
//         {
//             if (Enemy.HP > 0)
//             {
//                 System.Console.WriteLine($"\u001b[91m{Enemy.GetName}\u001b[0m missed!");
//                 Enemy.ATK = 0;
//             }
//         }
//         else
//         {
//             Enemy.ATK = Random.Shared.Next(2 +(Floor - 1), 5 + (Floor - 1));
            
//         }
//     }
//     if (Enemy.SPD > PlStat.AGI)
//     {
//         int Chance = Enemy.SPD - PlStat.AGI; 
//         int ChanceToMiss = Random.Shared.Next(0,Chance);

//         if (ChanceToMiss > 5)
//         {
//             if (Enemy.HP > 0 && TurnUsed == false)
//             {
//                 System.Console.WriteLine($"You missed!");
//                 PlStat.ATK = 0;
//             }
//         }
//         else
//         {
//             PlStat.ATK = Random.Shared.Next(10 + STRup, 15 + STRup);
//         }

//     }

// }

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

static bool ShopConfirm()
{
    System.Console.WriteLine("\nDo wish to buy that?\n");
    while(true)
    {
        string yn = Console.ReadLine().ToLower();
        if(YesContains(yn) || yn == "yes")
        {
            
            return true;
            
        }
        else if (NoContains(yn) || yn == "no")
        {

            System.Console.WriteLine("Understood.");
            return false;
        }
        else
        {
            System.Console.WriteLine("\nPlease answer the question.\n");
            continue;
        }

    }
}

static bool ContinueShop()
{
    System.Console.WriteLine("\nContinue Shopping?\n");
    while(true)
    {
        string yn = Console.ReadLine().ToLower();
        if(YesContains(yn) || yn == "yes")
        {
            
            return true;
        }
        else if (NoContains(yn) || yn == "no")
        {
            System.Console.WriteLine("Thanks for purchased. Hope to see you again.");
            return false;
        }
        else
        {
            System.Console.WriteLine("\nPlease answer the question.\n");
            continue;
        }
    }
}

static string EnemiesName()
{
    List<string> EnemyName = new List<string>() {"Rat", "Goblin", "Slime"} ;

    int R = Random.Shared.Next(EnemyName.Count);

    return EnemyName[R];

} 