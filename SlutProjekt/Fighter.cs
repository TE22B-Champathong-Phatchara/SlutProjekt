
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;


class Char
{
    public int HP;
    public int BaseHP;
    public int STM;
    public int BaseSTM;
    public int ATK;
    public int BaseATK;

    public int AGI;
    public string GetName;

    public int SPD;

    public bool IsDead()
    {
        if(HP <= 0)
        {
            System.Console.WriteLine($"\n{GetName} Is dead!\n");
            return true;
        }
        return false;
    }


    public bool Tired()
    {
        if(STM <= 0)
        {
            System.Console.WriteLine("\nYou are too tired to swing your sword.");
            System.Console.WriteLine("Your death approches.\n");
            return true;
        }
        return false;
    }


    
}


