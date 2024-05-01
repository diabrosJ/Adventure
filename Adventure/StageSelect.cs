internal class StageSelect
{
    public void StageSelectMenu()
    {
        Console.Clear();

        Console.WriteLine("던전 입구입니다 아래 메뉴에서 선택해주세요");
        Console.WriteLine("");
        Console.WriteLine("1. 상태창");
        Console.WriteLine("2. 스테이지 선택");
        Console.WriteLine("3. 메인 메뉴");

        int choice = ConsoleUitility.PromptMenuCholce(1, 3);
        switch (choice)
        {
            case 1:

                break;
            case 2:

                break;
            case 3:
                StageMenu();
                break;
        }

    }
    public void StageMenu()
    {
        Console.Clear();
        Console.WriteLine("스테이지를 선택해주세요 \n");
        Console.WriteLine("1. 1스테이지\n");
        Console.WriteLine("2. 2스테이지\n");
        Console.WriteLine("3. 3스테이지\n");

        int choice = ConsoleUitility.PromptMenuCholce(1, 3);
        switch (choice)
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
        }
    }

    public void Stage1()
    {
        Console.Clear();
        Console.WriteLine("1스테이지 입니다.\n메뉴를 선택해 주세요");
        Console.WriteLine("1. 싸우러가기");
        Console.WriteLine("2. ");
    }
    public void Stage2()
    {
        Console.Clear();
        Console.WriteLine("2스테이지 입니다.\n메뉴를 선택해 주세요");
        Console.WriteLine("1. 싸우러가기");
        Console.WriteLine("2. ");
    }
    public void Stage3()
    {
        Console.Clear();
        Console.WriteLine("3스테이지 입니다.\n메뉴를 선택해 주세요");
        Console.WriteLine("1. 싸우러가기");
        Console.WriteLine("2. ");
    }
}