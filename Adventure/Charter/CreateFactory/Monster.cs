﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure.Charter.CreateFactory
{
    internal class Monster
    {

        public static Dictionary<string, CreateMonster> Monsters = new Dictionary<string, CreateMonster>
        {
            {"CannonMinion", new CreateMonster("대포미니언", 2, 30, 12)},
            {"MeleeMinion", new CreateMonster("미니언", 1, 20, 8)},
            {"Voidling", new CreateMonster("공허충", 1, 50, 5)}
        };
        Monster()
        {
            

        }
    }
    
}
