using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace Adventure
{
    class Shop
    {

        //GoMain goMain;
        private List<Item> availableItems;


        //상점 판매 목록 아이템 데이터
        public Shop()
        {
            //가격,추가 공격력, 추가 방어력, 추가 체력, 추가 마나 순서
            availableItems = new List<Item>
            {
                new Item("아이템1","아이템이 주는 스탯 | 아이템 설명 ", 1000,10,5,50,20),
                new Item("아이템2","아이템이 주는 스탯 | 아이템 설명 ", 2000,20,10,100,30),
                new Item("아이템3","아이템이 주는 스탯 | 아이템 설명 ", 3000,45,15,200,60),
                new Item("아이템4","아이템이 주는 스탯 | 아이템 설명 ", 4000,80,50,250,80),
                new Item("아이템5","아이템이 주는 스탯 | 아이템 설명 ", 5000,100,70,270,100),
                new Item("아이템6","아이템이 주는 스탯 | 아이템 설명 ", 6000,150,80,300,120),

           };
        }

        //상점에서 구매 가능한 아이템 목록 가져오는 메서드
        public List<Item> GetAvailableItems(PlayerInfo player)
        {
            List<Item> result = new List<Item>();

            foreach (var item in availableItems)
            {
                if (!item.IsPurchased || player.Gold >=item.Price)
                {
                    result.Add(item);
                }
            }
            return result;
        }

        //아이템 구매 메커니즘 메서드
        public bool IsPurchaseItem(PlayerInfo player, Item item)
        {
            if (player.Gold >=item.Price && !item.IsPurchased)
            {
                //플레이어 골드 조정 메서드(-item.Price) 아이템 가격만큼 재화를 차감
                item.IsPurchased = true; // 아이템 구매 상태 변경
                return true;
            }
            return false;
        }

        //아이템 판매 메커니즘 메서드
        public void SellItem(PlayerInfo player, Item item)
        {
            int sellPrice = (int)(item.Price * 100); //판매가격
            //플레이어 골드 조정 메서드(sellPrice);
            item.IsPurchased = false;

            if (item.IsEquipped)
            {
                //플레이어 장비 해제 메서드(item);
                item.IsEquipped = false;

            }

        }

        //상점 기능
        public void VisitShop(PlayerInfo player, Shop shop,Inventory inventory)
        {
            bool exitShop = false;

            while (!exitShop)
            {
                Console.Clear();
                Console.WriteLine("** 상점 **");
                Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
                Console.WriteLine();
                Console.WriteLine($"[보유 골드] {player.Gold} G");
                Console.WriteLine();

                List<Item> items = shop.GetAvailableItems(player); //플레이어가 구매할 수 있는 아이템 목록 가져오기

                //구매 가능한 아이템이 없다면
                if (items.Count == 0)
                {
                    Console.WriteLine("구매 가능한 아이템이 없습니다.");
                    Thread.Sleep(2000); exitShop = true;
                }
                else//구매 가능한 아이템이 있다면
                {
                    foreach (var item in items)
                    {
                        string purchased = item.IsPurchased ? "구매완료" : $"{item.Price} G";
                        Console.WriteLine($"- {item.Name} | {item.Description} | {purchased}");
                    }
                }

                Console.WriteLine();
                Console.WriteLine("1 .아이템 구매");
                Console.WriteLine("2. 아이템 판매");
                Console.WriteLine("0. 나가기");
                Console.WriteLine();
                Console.WriteLine("원하시는 행동을 입력해주세요.");

                int input;
                int.TryParse(Console.ReadLine(), out input);

                switch (input)
                {
                    case 1:
                        shop.BuyItemShop(player, shop, inventory);
                        exitShop = true;
                        break;
                    case 2:
                        shop.SellItemShop(player,shop,inventory);
                        exitShop = true;
                        break;
                    case 0:
                        //goMain.mainScene();
                        exitShop = true;
                        break;

                }

            }
        }

        //상점 - 아이템 구매
        public void BuyItemShop(PlayerInfo player, Shop shop, Inventory inventory)
        {
            Console.Clear();
            Console.WriteLine("** 상점 - 아이템 구매 **");
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
            Console.WriteLine();

            //구매할 수 있는 아이템 목록 가져오기
            List<Item> availableItems = shop.GetAvailableItems(player);

            if (availableItems.Count == 0)
            {
                Console.WriteLine("구매 가능한 아이템이 없습니다.");
                Thread.Sleep(2000);
                return;
            }
            //구매 가능한 모든 아이템에 대해서 반복
            for (int i = 0; i < availableItems.Count; i++)
            {
                //아이템이 이미 구매되었다면 "구매 완료"를, 아니면 가격을 표시
                string purchased = availableItems[i].IsPurchased ? "구매완료" : $"{availableItems[i].Price} G";
                Console.WriteLine($"{i + 1}. {availableItems[i].Name} | {availableItems[i].Description} | {purchased}");
            }

            Console.WriteLine("0.나가기") ;
                Console.WriteLine();
                Console.WriteLine("원하시는 아이템을 선택해주세요: ");

                int selectedIndex; //사용자가 선택한 아이템의 인덱스

                //입력한 값을 정수로 변환하고, 범위 안에 있는 지 확인
                if (!int.TryParse(Console.ReadLine(), out selectedIndex) || selectedIndex < 0 || selectedIndex > availableItems.Count)
                {
                    Console.Clear();
                    Console.WriteLine("잘못된 입력입니다.");
                Thread.Sleep(1000);
                    return;
                }

                //선택한 아이템의 인덱스 조정
                selectedIndex--;

                if (selectedIndex == -1)
                {
                    return;

                }
                else if (selectedIndex >= 0 && selectedIndex < availableItems.Count)
                {
                    //사용자가 선택한 아이템 가져오기
                    Item selected = availableItems[selectedIndex];

                    //구매 성공 여부
                    bool purchased = shop.IsPurchaseItem(player, selected);

                    //구매했다면
                    if (purchased)
                    {
                        //인벤토리에 아이템 추가
                        inventory.AddItem(selected);
                        //구매 할 수 있는 아이템 목록에서 제거
                        availableItems.Remove(selected);
                    }
                    else
                    {
                        Console.WriteLine("Gold가 부족하거나 이미 구매한 아이템입니다.");
                        Thread.Sleep(2000);
                        BuyItemShop(player, shop, inventory);
                    }
                }

            }


 

        //상점 - 아이템 판매
        public void SellItemShop(PlayerInfo player, Shop shop, Inventory inventory)
        {
            Console.Clear();
            Console.WriteLine("**상점 - 아이템 판매 **");
            Console.WriteLine("보유 중인 아이템을 판매합니다.");
            Console.WriteLine();

            List<Item> playerItems = inventory.GetItems();

            if (playerItems.Count == 0)
            {
                Console.WriteLine("보유 중인 아이템이 없습니다.");
                Thread.Sleep(2000);
                return;
            }

            for (int i = 0; i < playerItems.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {playerItems[i].Name} | {playerItems[i].Price * 100} G"); //판매 가격 표시 추후 조정
            }
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.Write("판매할 아이템을 선택해주세요.");

            int selectedIndex;

            if (!int.TryParse(Console.ReadLine(), out selectedIndex) || selectedIndex < 0 || selectedIndex > playerItems.Count)
            {
                Console.WriteLine("잘못된 입력입니다.");
                Thread.Sleep(2000);
                return;
            }

            selectedIndex--;

            if (selectedIndex == -1)
            {
                return;
            }
            else if (selectedIndex >= 0 && selectedIndex < playerItems.Count)
            {
                Item selected = playerItems[selectedIndex];
                shop.SellItem(player, selected);
                inventory.RemoveItem(selected);
                
            }

        }
    }
}
