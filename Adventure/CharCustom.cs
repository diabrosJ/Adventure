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
        public void MakeName()
        {
            Console.WriteLine("게임에서 사용할 이름을 작성해주세요.");
            playerName = Console.ReadLine();
            Console.Clear();
            ChoiceClass();
        }

        enum ClassType
        {
            Warrior = 1,
            Wizard = 2,
            Bandit = 3,
        }
        public void ChoiceClass()
        {
            CreateClass createClass = new CreateClass();
            GoMain goMain = new GoMain();

            while (true)
            {

                Console.WriteLine("직업을 선택해주세요.");
                Console.WriteLine("[1] 전사");
                Console.WriteLine("[2] 마법사");
                Console.WriteLine("[3] 도적");
                ClassType choice;
                int.TryParse(Console.ReadLine(), out int input);
                Console.Clear();
                switch (input)
                {
                    case 1:
                        choice = ClassType.Warrior;
                        Console.WriteLine("전사를 선택하셨습니다.");
                        player = createClass.warrior();
                        player.Name = playerName;
                        goMain.mainScence(player);
                        //CreatClass Warrior랑 MainScence로 넘깁니다. 아래쪽도 동일
                        return;
                    case 2:
                        choice = ClassType.Wizard;
                        Console.WriteLine("마법사를 선택하셨습니다.");
                        player = createClass.wizard();
                        player.Name = playerName;
                        goMain.mainScence(player);
                        return;
                    case 3:
                        choice = ClassType.Bandit;
                        Console.WriteLine("도적를 선택하셨습니다.");
                        player = createClass.bandit();
                        player.Name = playerName;
                        goMain.mainScence(player);
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
