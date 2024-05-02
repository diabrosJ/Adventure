using Adventure.Charter.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure
{
    internal class BattleStage
    {
        public void getBattle()
        {
            Console.Clear();

            Console.WriteLine("몬스터를 조우 하셨습니다.\n");
            Console.WriteLine("1. 몬스터 정보");
            Console.WriteLine("2. 일반 공격");
            Console.WriteLine("3. 스킬 사용");
            Console.WriteLine("4. 아이템 사용");

            int.TryParse(Console.ReadLine(), out int input);

            switch (input)
            {
                case 1:
                    monsterInfo.Info();
                    break;
                case 2:
                    UseAttack();
                    break;
                    //case 3:
                    //    UseSkill();
                    //    break;
                    //case 4:
                    //    UsePotion();
                    //    break;
            }

        }
    }
}
