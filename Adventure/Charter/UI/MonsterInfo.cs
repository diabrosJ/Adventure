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
        public void Info(CreateMonster monster)
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine($"직업 : {Job}");
                Console.WriteLine($"Lv : {Lv}");
                Console.WriteLine($"공격력 : {Str}");
                Console.WriteLine($"방어력 : {Def}");
                Console.WriteLine($"체력 : {Hp}");
                Console.WriteLine("1. 이전 메뉴로");


                int.TryParse(Console.ReadLine(), out int input);
                switch (input)
                {
                    case 1:
                        Console.Clear();
                        battle.getBattle();
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
