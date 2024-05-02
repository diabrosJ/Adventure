using Adventure;

internal class CreateMonster
{
    PlayerInfo monster;
    //호출시켜야할 몬스터 내용은 이걸로 불러주세요

    public PlayerInfo Minion()
    {
        monster = new PlayerInfo("", "미니언", 1, 10, 0, 50, 0, 10);
        // 몬스터 이름, 레벨, 공격력, 방어력, 체력, 마나, 골드
        return monster;
    }
    public PlayerInfo canonMinion()
    {
        monster = new PlayerInfo("", "대포 미니언", 1, 10, 0, 50, 0, 10);
        // 몬스터 이름, 레벨, 공격력, 방어력, 체력, 마나, 골드
        return monster;
    }
    public PlayerInfo goBlin()
    {
        monster = new PlayerInfo("", "고블린", 1, 10, 0, 50, 0, 10);
        // 몬스터 이름, 레벨, 공격력, 방어력, 체력, 마나, 골드
        return monster;
    }

}