using Adventure.Charter.CreateFactory;

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
        public class WarriorSkills
        {
            private int baseDamage;
            private int level;

            // 이전 코드 생략

            public void Attack(string MeLeeMinion)
            {
                if (Monster.Monsters.ContainsKey(MeLeeMinion))
                {
                    CreateMonster monsterInfo = Monster.Monsters[MeLeeMinion];
                    int totalDamage = baseDamage + (level * 2); // 레벨에 따른 공격력 증가
                    Console.WriteLine($"전사가 몬스터에게 {totalDamage}의 데미지를 입힙니다.");
                    monsterInfo.Health -= totalDamage; // 몬스터의 체력을 감소시킴
                    if (monsterInfo.Health <= 0)
                    {
                        Console.WriteLine($"{monsterInfo.Name}을(를) 물리쳤습니다!");
                    }
                }
                else
                {
                    Console.WriteLine("해당하는 몬스터를 찾을 수 없습니다.");
                }
            }

            // 이후 코드 생략
        }

        public class WizardSkills
        {
            private static int mana;
            private static int baseDamage;
            private static int level;

            // 이전 코드 생략

            public static void CastSpell(string CannonMinion)
            {
                if (Monster.Monsters.ContainsKey(CannonMinion))
                {
                    CreateMonster monsterInfo = Monster.Monsters[CannonMinion];
                    if (mana >= 30)
                    {
                        mana -= 30;
                        int totalDamage = baseDamage + (level * 3); // 레벨에 따른 공격력 증가
                        Console.WriteLine($"마법사가 몬스터에게 {totalDamage}의 데미지를 입힙니다.");
                        monsterInfo.Health -= totalDamage; // 몬스터의 체력을 감소시킴
                        if (monsterInfo.Health <= 0)
                        {
                            Console.WriteLine($"{monsterInfo.Name}을(를) 물리쳤습니다!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("마나가 부족합니다.");
                    }
                }
                else
                {
                    Console.WriteLine("해당하는 몬스터를 찾을 수 없습니다.");
                }
            }

            // 이후 코드 생략
        }

        public class BanditSkills
        {
            // 이전 코드 생략

            public void Backstab(string Voidling)
            {
                if (Monster.Monsters.ContainsKey(Voidling))
                {
                }

            }

        }
    }
}
