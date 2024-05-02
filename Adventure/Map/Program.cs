using System.Numerics;
﻿using System;

namespace Adventure
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PlayerInfo player = new PlayerInfo("","",1,1,1,1,1,1);
            Shop shop = new Shop();
            Inventory inventory = new Inventory();

   
            CharCustom charCustom = new CharCustom();
            charCustom.MakeName(player,shop,inventory);

            //시작후 CharCustom으로 넘길 예정

        }
    }
}
