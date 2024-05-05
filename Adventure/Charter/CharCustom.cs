using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Adventure
{
    public class CharCustom
    {

        PlayerInfo player;
        //선택할 캐릭터
        string playerName;
        //info로 넘길 이름값
        public void MakeName(PlayerInfo player, Shop shop, Inventory inventory)
        {
            Console.WriteLine("게임에서 사용할 이름을 작성해주세요.");
            playerName = Console.ReadLine();
            Console.Clear();
            ChoiceClass(player,shop,inventory);
        }

        enum ClassType
        {
            Warrior = 1,
            Wizard = 2,
            Bandit = 3,
        }
        public void ChoiceClass(PlayerInfo player, Shop shop, Inventory inventory)
        {
            CreateClass createClass = new CreateClass();
            GoMain goMain = new GoMain();

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("****직업을 선택해주세요****");
                Console.ResetColor();
                Console.WriteLine();
                Console.Write("[1] 전사 : ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("+높은 체력, +높은 방어력, +높은 단일 타겟 공격력");
                Console.ResetColor();
                Console.WriteLine();
                Console.Write("[2] 마법사 : ");
                Console.ForegroundColor= ConsoleColor.Cyan;
                Console.WriteLine("+높은 마력, +높은 스킬 공격력, +광역 타겟 공격");
                Console.ResetColor();
                Console.WriteLine();
                Console.Write("[3] 도적 : ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("+많은 스테이지 클리어 보상, +유틸성이 많은 스킬들");
                Console.ResetColor(); Console.WriteLine();
                ClassType choice;
                int.TryParse(Console.ReadLine(), out int input);
                Console.Clear();
                switch (input)
                {
                    case 1:
                        choice = ClassType.Warrior;
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("*********************");
                        Console.WriteLine("전사를 선택하셨습니다");
                        Console.WriteLine("*********************");
                        Console.ResetColor();
                        Console.WriteLine();
                        player = createClass.warrior();
                        player.Name = playerName;
                        goMain.mainScence(player,shop,inventory);
                        //CreatClass Warrior랑 MainScence로 넘깁니다. 아래쪽도 동일
                        return;
                    case 2:
                        choice = ClassType.Wizard;
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("***********************");
                        Console.WriteLine("마법사를 선택하셨습니다");
                        Console.WriteLine("***********************");
                        Console.ResetColor();
                        Console.WriteLine();
                        player = createClass.wizard();
                        player.Name = playerName;
                        goMain.mainScence(player,shop, inventory);
                        return;
                    case 3:
                        choice = ClassType.Bandit;
                        Console.WriteLine();
                        Console.ForegroundColor= ConsoleColor.Green;
                        Console.WriteLine("*********************");
                        Console.WriteLine("도적를 선택하셨습니다");
                        Console.WriteLine("*********************");
                        Console.ResetColor();
                        Console.WriteLine();
                        player = createClass.bandit();
                        player.Name = playerName;
                        goMain.mainScence(player,shop, inventory);
                        return;
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
    }
}
