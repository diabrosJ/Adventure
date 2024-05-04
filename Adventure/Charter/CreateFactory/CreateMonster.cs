using Adventure;
using System.Threading;
using System.Collections.Generic;
public class CreateMonster
{
    public string Name { get; }
    public int Level { get; }
    public int Hp { get; set; }
    public int Atk { get; }

    public CreateMonster(string name, int level, int hp, int atk)
    {
        Name = name;
        Level = level;
        Hp = hp;
        Atk = atk;
    }

    public CreateMonster(CreateMonster other) 
    {
        Name = other.Name;
        Level = other.Level;
        Hp=other.Hp;
        Atk = other.Atk;    
    }
}
