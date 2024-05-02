using Adventure;
using Adventure.Charter.UI;

internal class StageSelect
{
    public void StageSelectMenu(PlayerInfo info,Shop shop, Inventory inventory)
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
                StageMenu();
                break;
            case 3:
                Console.Clear();
                return;
        }

    }
    public void StageMenu()
    {
        BattleStage battleStage = new BattleStage();
        MonsterInfo monsterInfo = new MonsterInfo();

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
                battleStage.getBattle(monsterInfo);
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