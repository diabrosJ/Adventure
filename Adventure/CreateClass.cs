using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure
{
    internal class CreateClass
    {
        PlayerInfo player;


        public PlayerInfo warrior()
        {
            player = new PlayerInfo("전사", 1, 10, 10, 150, 50, 1500);
            // 직업, 레벨, 공격력, 방어력,체력,마나,골드
            return player;
        }

        public PlayerInfo wizard()
        {
            player = new PlayerInfo("마법사", 1, 5, 8, 100, 140, 1500);
            // 직업, 레벨, 공격력, 방어력,체력,마나,골드
            return player;
        }
        public PlayerInfo bandit()
        {
            player = new PlayerInfo("마법사", 1, 7, 7, 80, 80, 1500);
            // 직업, 레벨, 공격력, 방어력,체력,마나,골드
            return player;
        }
    }
}
