using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure
{
    // 스킬을 정의하는 인터페이스
    public interface ISkill
    {
        void UseSkill(PlayerInfo player);
    }

    public class WarriorSkill : ISkill
    {
        private int manaCost = 10;

        public void UseSkill(PlayerInfo player)
        {
            if (player.Mp >= manaCost)
            {
                player.Mp -= manaCost;
                player.Str *= 2; // 공격력을 두 배로 증가
                Console.WriteLine("워리어의 스킬을 사용했습니다. 공격력이 두 배가 되었습니다.");
            }
            else
            {
                Console.WriteLine("마나가 부족하여 스킬을 사용할 수 없습니다.");
            }
        }
    }

    public class WizardSkill : ISkill
    {
        private int manaCost = 30;

        public void UseSkill(PlayerInfo player)
        {
            if (player.Mp >= manaCost)
            {
                player.Mp -= manaCost;
                player.Hp -= 30; // 적의 체력을 30 감소시킴
                Console.WriteLine("위저드의 스킬을 사용했습니다. 적의 체력이 30 감소했습니다.");
            }
            else
            {
                Console.WriteLine("마나가 부족하여 스킬을 사용할 수 없습니다.");
            }
        }
    }

    public class BanditSkill : ISkill
    {
        private int manaCost = 20;

        public void UseSkill(PlayerInfo player)
        {
            if (player.Mp >= manaCost)
            {
                player.Mp -= manaCost;
                player.Str *= 2; // 공격력을 두 배로 증가
                Console.WriteLine("벤딧의 스킬을 사용했습니다. 공격력이 두 배가 되었습니다.");
            }
            else
            {
                Console.WriteLine("마나가 부족하여 스킬을 사용할 수 없습니다.");
            }
        }
    }
}