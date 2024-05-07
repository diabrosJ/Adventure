using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure
{
    internal class SKill
    {

        public string Name { get; set; }
        public int Str { get; set; }
        public int Mp { get; set; }

        public SKill(string name, int str, int mp)

        { //생성자 < 

            Name = name;
            //이름
            Str = str;
            //공격력
            Mp = mp;
            //마력
        }
    }

}

namespace Adventure
{
    public class WarriorSkills
    {
        private int level;
        private int experience;
        private int maxExperience = 100; // 레벨업을 위한 최대 경험치
        private int baseDamage = 10; // 기본 공격력

        public WarriorSkills()
        {
            level = 1;
            experience = 0;
        }

        public void Attack()
        {
            int totalDamage = baseDamage + (level * 2); // 레벨에 따른 공격력 증가
            Console.WriteLine($"전사가 {totalDamage}의 데미지를 입힙니다.");
        }

        public void GainExperience(int amount)
        {
            experience += amount;
            if (experience >= maxExperience)
            {
                LevelUp();
            }
        }

        private void LevelUp()
        {
            level++;
            experience = 0;
            maxExperience *= 2; // 다음 레벨을 위한 경험치 배수 증가
            Console.WriteLine($"레벨 업! 현재 레벨: {level}");
        }
    }

    public class WizardSkills
    {
        private int level;
        private int experience;
        private int maxExperience = 150; // 레벨업을 위한 최대 경험치
        private int baseDamage = 8; // 기본 공격력
        private int mana = 100; // 마나
        private string skillName = "마법 시전";

        public WizardSkills()
        {
            level = 1;
            experience = 0;
        }

        public void CastSpell()
        {
            if (mana >= 30)
            {
                mana -= 30;
                int totalDamage = baseDamage + (level * 3); // 레벨에 따른 공격력 증가
                Console.WriteLine($"{skillName}! 마나 -30, HP -10, 데미지 {totalDamage}");
            }
            else
            {
                Console.WriteLine("마나가 부족합니다.");
            }
        }

        public void GainExperience(int amount)
        {
            experience += amount;
            if (experience >= maxExperience)
            {
                LevelUp();
            }
        }

        private void LevelUp()
        {
            level++;
            experience = 0;
            maxExperience *= 2; // 다음 레벨을 위한 경험치 배수 증가
            Console.WriteLine($"레벨 업! 현재 레벨: {level}");
        }
    }

    public class BanditSkills
    {
        private int level;
        private int experience;
        private int maxExperience = 120; // 레벨업을 위한 최대 경험치
        private readonly int baseDamage = 12; // 기본 공격력
        private int agility = 20; // 민첩성
        private string skillName = "뒷통수 치기";

        public BanditSkills()
        {
            level = 1;
            experience = 0;
        }

        public void Backstab()
        {
            int totalDamage = baseDamage + (level * 4) + (agility / 5); // 레벨과 민첩성에 따른 공격력 증가
            Console.WriteLine($"{skillName}! HP -5, 데미지 {totalDamage}");
        }

        public void GainExperience(int amount)
        {
            experience += amount;
            if (experience >= maxExperience)
            {
                LevelUp();
            }
        }

        private void LevelUp()
        {
            level++;
            experience = 0;
            maxExperience *= 2; // 다음 레벨을 위한 경험치 배수 증가
            Console.WriteLine($"레벨 업! 현재 레벨: {level}");
        }
    }
}
