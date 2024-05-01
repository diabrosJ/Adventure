using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure
{
    public class GoMain
    {
        Inventory inventory = new Inventory();
        Shop shop = new Shop();
        PlayerInfo playerinfo;
        CharCustom player;
        StageSelect stageselect;
        public void mainScence(PlayerInfo _playerinfo)
        {

            while (true)
            {
                playerinfo = _playerinfo;
                Console.WriteLine(" 스파르타 던전에 오신 여러분 환영합니다.");
                Console.WriteLine(" 전투 시작에 앞서 행동을 선택해 주세요. ");

                Console.WriteLine(" 1. Playerinfo");
                //인포창 넘어가기
                Console.WriteLine(" 2. Get in dungeon ");
                //던전으로 넘어가기
                Console.WriteLine(" 3. visitshop");
                //상점으로 넘어가기
                int input;
                int.TryParse(Console.ReadLine(), out input);
                switch (input)
                {
                    case 1:
                        playerinfo.Info();
                        break;
                    case 2:
                        stageselect.StageSelectMenu();
                        break;
                    case 3:
                        shop.VisitShop(playerinfo,shop,inventory);
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
