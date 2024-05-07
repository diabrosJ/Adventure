using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Adventure.Charter.Skill
{
    public class SKill
    {
        PlayerInfo player;
        private int baseDamage = 10; // 기본 공격력

        public void warriorSkill1()
        {
            if (player.Mp >= 30) 
            {
                player.Mp -= 30;
                int totalDamage = baseDamage + (player.Str * 2); // 레벨에 따른 공격력 증가
                Console.WriteLine($"전사가 {totalDamage}의 데미지를 입힙니다.");
            }
            else
            {
                Console.WriteLine("마나가 부족합니다.");
            }

        }
        public void warriorSkill2()
        {
            if (player.Mp >= 30)
            {
                player.Mp -= 30;
                int totalDamage = baseDamage + (player.Str * 2); // 레벨에 따른 공격력 증가
                Console.WriteLine($"전사가 {totalDamage}의 데미지를 입힙니다.");
            }
            else
            {
                Console.WriteLine("마나가 부족합니다.");
            }

        }
        public void wizardSkill1()
        {
            if (player.Mp >= 30)
            {
                player.Mp -= 30;
                int totalDamage = baseDamage + (player.Str * 3); // 레벨에 따른 공격력 증가
                Console.WriteLine($"마법사가 마법을 시전하여 {totalDamage}의 데미지를 입힙니다.");
            }
            else
            {
                Console.WriteLine("마나가 부족합니다.");
            }
        }
        public void wizardSkill2()
        {
            if (player.Mp >= 30)
            {
                player.Mp -= 30;
                int totalDamage = baseDamage + (player.Str * 3); // 레벨에 따른 공격력 증가
                Console.WriteLine($"마법사가 마법을 시전하여 {totalDamage}의 데미지를 입힙니다.");
            }
            else
            {
                Console.WriteLine("마나가 부족합니다.");
            }
        }
        public void banditSkill1()
        {
            if(player.Mp >= 30)
            {
                player.Mp -= 30;
                int totalDamage = baseDamage + (player.Str * 4); // 레벨과 민첩성에 따른 공격력 증가
                Console.WriteLine($"도적이 뒷통수를 치며 {totalDamage}의 데미지를 입힙니다.");
            }
            else
            {
                Console.WriteLine("마나가 부족합니다.");
            }
        }
        public void banditSkill2()
        {
            if (player.Mp >= 30)
            {
                player.Mp -= 30;
                int totalDamage = baseDamage + (player.Str * 4); // 레벨과 민첩성에 따른 공격력 증가
                Console.WriteLine($"도적이 뒷통수를 치며 {totalDamage}의 데미지를 입힙니다.");
            }
            else
            {
                Console.WriteLine("마나가 부족합니다.");
            }
        }
    }

}
