
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;


class Char
{
    public int HP;
    public int BaseHP;
    public int ATK;

    public int AGI;
    public string GetName;
    private int ChanceToMiss;
    private int Chance;

    public int SPD;

    public bool IsDead()
    {
        if(HP <= 0)
        {
            System.Console.WriteLine($"{GetName} Is Dead!");
            return true;
        }
        return false;
    }

    public bool Missed()
    {
        
        if(SPD > AGI)
        {
            Chance = SPD - AGI;
            ChanceToMiss = Random.Shared.Next(0,Chance);
            
            if (ChanceToMiss > 5)
            {
                System.Console.WriteLine($"{GetName} missed!");
                return true;
            }   
            
        }
        return false;
    }


    
}


