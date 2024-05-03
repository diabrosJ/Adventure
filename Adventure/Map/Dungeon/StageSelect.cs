using Adventure;
using Adventure.Charter.UI;
using System.Numerics;
using System.Threading;

internal class StageSelect
{
    private PlayerInfo player;
    private CreateMonster createMonster;
    public void StageSelectMenu(PlayerInfo info,Shop shop, Inventory inventory, PlayerInfo monster)
    {
        Console.Clear();

        Console.WriteLine("던전 입구입니다 아래 메뉴에서 선택해주세요");
        Console.WriteLine("");
        Console.WriteLine("1. 상태창");
        Console.WriteLine("2. 스테이지 선택");
        Console.WriteLine("3. 메인 메뉴");

        int.TryParse(Console.ReadLine(), out int input);
        switch (input)
        {
            case 1:
                info.Info(info,shop,inventory);
                //playerinfo.info 진입
                break;
            case 2:
                StageMenu(info, shop, inventory, monster);
                break;
            case 3:
                Console.Clear();
                return;
        }

    }
    public void StageMenu(PlayerInfo info, Shop shop, Inventory inventory, PlayerInfo monster)
    {
        
        MonsterInfo monsterInfo = new MonsterInfo();
        BattleStage battleStage = new BattleStage(player, createMonster);
        BattleSystem battleSystem = new BattleSystem(player);

        Console.Clear();
        Console.WriteLine("스테이지를 선택해주세요 \n");
        Console.WriteLine("1. 1스테이지\n");
        Console.WriteLine("2. 2스테이지\n");
        Console.WriteLine("3. 3스테이지\n");
        Console.WriteLine("0. 메인 메뉴");

        int.TryParse(Console.ReadLine(), out int input);
        switch (input)
        {
            case 1:
                PlayerInfo minionMonster = createMonster.Minion();
                battleStage.getBattle(monsterInfo,info, shop, inventory, monster);
                break;
            //case 2:
            //    Stage2();
            //    break;
            //case 3:
            //    Stage3();
            //    break;
            default:
                if (input != 1 && input != 3)
                {
                    Console.WriteLine("잘못 입력하셨습니다.");
                    Console.WriteLine("다시 입력해주세요.");
                    Console.WriteLine("2초후 다시 선택창으로 넘어갑니다.");
                    Thread.Sleep(2000);
                    Console.Clear();
                }
                break;
        }
    }
}