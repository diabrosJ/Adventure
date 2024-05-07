using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure
{
    public class WarriorSkills
    {
        private int baseDamage = 10; // 기본 공격력

        public void Attack(int level)
        {
            int totalDamage = baseDamage + (level * 2); // 레벨에 따른 공격력 증가
            Console.WriteLine($"전사가 {totalDamage}의 데미지를 입힙니다.");
        }

        public void ShieldBlock()
        {
            Console.WriteLine("전사가 방패로 적의 공격을 막습니다.");
        }
    }

    public class WizardSkills
    {
        private int baseDamage = 8; // 기본 공격력
        private int mana = 100; // 마나

        public void CastSpell(int level)
        {
            int totalDamage = baseDamage + (level * 3); // 레벨에 따른 공격력 증가
            Console.WriteLine($"마법사가 마법을 시전하여 {totalDamage}의 데미지를 입힙니다.");
        }

        public void Fireball(int level)
        {
            if (mana >= 50)
            {
                mana -= 50;
                int totalDamage = baseDamage + (level * 5); // 레벨에 따른 공격력 증가
                Console.WriteLine($"마법사가 화염구를 발사하여 {totalDamage}의 데미지를 입힙니다.");
            }
            else
            {
                Console.WriteLine("마나가 부족합니다.");
            }
        }
    }

    public class BanditSkills
    {
        private int baseDamage = 12; // 기본 공격력

        public void Backstab(int level)
        {
            int totalDamage = baseDamage + (level * 4); // 레벨에 따른 공격력 증가
            Console.WriteLine($"도적이 뒷통수를 치며 {totalDamage}의 데미지를 입힙니다.");
        }

        public void Stealth()
        {
            Console.WriteLine("도적이 은신하여 적에게 감추어집니다.");
        }
    }
}