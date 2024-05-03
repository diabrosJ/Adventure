using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Adventure.Charter.UI
{
    internal class MonsterInfo
    {
        MonsterInfo monsterInfo;
        BattleStage battle;
        PlayerInfo player;
        public void Info(CreateMonster monster, PlayerInfo info, Shop shop, Inventory inventory)
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine(monster);

                int.TryParse(Console.ReadLine(), out int input);
                switch (input)
                {
                    case 1:
                        Console.Clear();
                        battle.getBattle(monsterInfo, info, shop, inventory);
                        return;
                    default:
                        if (input != 1 && input != 3)
                        {
                            Console.WriteLine("잘못 입력하셨습니다.");
                            Console.WriteLine("다시 입력해주세요.");
                            Console.WriteLine("2초후 다시 선택창으로 넘어갑니다.");
                            Thread.Sleep(2000);
                            Console.Clear();
                        }
                        break;
                }
            }
        }
    }
}
