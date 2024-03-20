using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;


class Char
{
    public int HP;
    public int ATK;
    public string GetName;

    public int AGI;

    public void IsDead()
    {
        if(HP <= 0)
        {
            System.Console.WriteLine($"{GetName} Is Dead!");
        }
    }


    
}


