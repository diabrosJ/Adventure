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
        CharCustom Name;

        public PlayerInfo warrior()
        {
            player = new PlayerInfo("","전사", 1, 10, 10, 150, 50, 1500);
            // 직업, 레벨, 공격력, 방어력,체력,마나,골드
            return player;
        }

        public PlayerInfo wizard()
        {
            player = new PlayerInfo("", "마법사", 1, 5, 8, 100, 140, 1500);
            // 직업, 레벨, 공격력, 방어력,체력,마나,골드
            return player;
        }
        public PlayerInfo bandit()
        {
            player = new PlayerInfo("", "마법사", 1, 7, 7, 80, 80, 1500);
            // 직업, 레벨, 공격력, 방어력,체력,마나,골드
            return player;
        }
    }
}

internal class WarriorSkills
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

internal class WizardSkills
{
    private int level;
    private int experience;
    private int maxExperience = 150; // 레벨업을 위한 최대 경험치
    private int baseDamage = 8; // 기본 공격력
    private int mana = 100; // 마나

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
            Console.WriteLine($"마법사가 마법을 시전하여 {totalDamage}의 데미지를 입힙니다.");
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

internal class BanditSkills
{
    private int level;
    private int experience;
    private int maxExperience = 120; // 레벨업을 위한 최대 경험치
    private int baseDamage = 12; // 기본 공격력
    private int agility = 20; // 민첩성

    public BanditSkills()
    {
        level = 1;
        experience = 0;
    }

    public void Backstab()
    {
        int totalDamage = baseDamage + (level * 4) + (agility / 5); // 레벨과 민첩성에 따른 공격력 증가
        Console.WriteLine($"도적이 뒷통수를 치며 {totalDamage}의 데미지를 입힙니다.");
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
