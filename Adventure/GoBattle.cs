
internal class GoBattle
{
    public static void goBattle()
    {
        Console.Clear();

        Console.WriteLine("몬스터를 조우 하셨습니다.\n");
        Console.WriteLine("1. 몬스터 정보");
        Console.WriteLine("2. 일반 공격");
        Console.WriteLine("3. 스킬 사용");
        Console.WriteLine("4. 아이템 사용");

        int choice = ConsoleUitility.PromptMenuCholce(1, 4);
        switch (choice)
        {
            case 1:
                MonsterInfo();
                break;
            case 2:
                UseAttack();
                break;
            case 3:
                UseSkill();
                break;
            case 4:
                UsePotion();
                break;
        }

    }

}