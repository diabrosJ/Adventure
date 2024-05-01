using Adventure;

internal class StageSelect
{
    public void StageSelectMenu(PlayerInfo info)
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
                info.Info(info);
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
                Stage1();
                break;
            case 2:
                Stage2();
                break;
            case 3:
                Stage3();
                break;
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

    public void Stage1()
    {
        Console.Clear();
        Console.WriteLine("1스테이지 입니다.\n메뉴를 선택해 주세요");
        Console.WriteLine("1. 싸우러가기\n");
        Console.WriteLine("0. 메인 메뉴");

        int.TryParse(Console.ReadLine(), out int input);
        switch (input)
        {
            case 1:
                Stage1();
                break;
            default:
                if (input != 1)
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
    public void Stage2()
    {
        Console.Clear();
        Console.WriteLine("2스테이지 입니다.\n메뉴를 선택해 주세요");
        Console.WriteLine("1. 싸우러가기\n");
        Console.WriteLine("0. 메인 메뉴");

        int.TryParse(Console.ReadLine(), out int input);
        switch (input)
        {
            case 1:
                Stage1();
                break;
            default:
                if (input != 2)
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
    public void Stage3()
    {
        Console.Clear();
        Console.WriteLine("3스테이지 입니다.\n메뉴를 선택해 주세요");
        Console.WriteLine("1. 싸우러가기\n");
        Console.WriteLine("0. 메인 메뉴");

        int.TryParse(Console.ReadLine(), out int input);
        switch (input)
        {
            case 0:
                return;
            case 1:
                Stage1();
                break;
            default:
                if (input != 3)
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