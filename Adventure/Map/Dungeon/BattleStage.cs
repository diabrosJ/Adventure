using Adventure.Charter.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Adventure
{
    internal class BattleStage
    {
        private PlayerInfo player;
        private CreateMonster createMonster;
        private CreateMonster currentMonster;
        public BattleStage(PlayerInfo player, CreateMonster createMonster)
        {
            this.player = player;
            this.createMonster = createMonster;
        }
        public void getBattle(MonsterInfo monsterInfo, PlayerInfo info, Shop shop, Inventory inventoryl, PlayerInfo monster)
        {

            Console.Clear();


            Console.WriteLine("몬스터를 조우 하셨습니다.\n");
            Console.WriteLine("전투를 시작합니다!");

            Console.WriteLine("1. 몬스터 정보");
            Console.WriteLine("2. 일반 공격");
            Console.WriteLine("3. 스킬 사용");
            Console.WriteLine("4. 아이템 사용");
            Console.WriteLine("");

            currentMonster = monster;

            int.TryParse(Console.ReadLine(), out int input);

            switch (input)
            {
                case 1:
                    monsterInfo.Info(monster, info, shop, inventoryl);

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
        private void UseAttack()
        {
            int playerDamage = player.Str; 
            int monsterDamage = currentMonster.Str;

            currentMonster.Hp -= playerDamage;
            player.Hp -= monsterDamage;

            Console.WriteLine($"플레이어가 몬스터에게 {playerDamage}의 데미지를 입혔습니다.");
            Console.WriteLine($"몬스터가 플레이어에게 {monsterDamage}의 데미지를 입혔습니다.");
            Console.WriteLine($"플레이어 체력: {player.Hp}, 몬스터 체력: {currentMonster.Hp}");
        }
    }
}
