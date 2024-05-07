using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Adventure
{
    public class Inventory
    {
        private List<Item> items; // 인벤토리에 보유한 아이템을 저장하는 리스트

        public Inventory()
        {
            //인벤토리 객체 초기화. 내부적으로 아이템을 저장할 리스트 생성
            items = new List<Item>();
        }

        public void ShowInventory(PlayerInfo player, Shop shop, Inventory inventory)
        {
            Console.Clear();
            Console.WriteLine("** 인벤토리 **");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine();

            List<Item> items = inventory.GetItems(); //인벤토리 객체에서 아이템 목록 가져오기

            //만약 인벤토리에 아이템이 없다면
            if (items.Count == 0)
            {
                Console.WriteLine("보유 중인 아이템이 없습니다.");
            }
            else //인벤토리에 아이템이 있다면
            {
                for (int i = 0; i < items.Count; i++)
                {
                    //아이템이 장착되어 있으면 "[E]"를, 아니면 빈 문자열을 'equipped'에 저장
                    string equipped = items[i].IsEquipped ? "[E]" : "";
                    if (items[i].IsEquipped)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    Console.WriteLine($"{i + 1}. {equipped}{items[i].Name} | {items[i].Description}");
                    Console.ResetColor();
                }
            }
            Console.WriteLine();
            Console.WriteLine("1. 장착 관리");
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.Write("원하시는 행동을 입력해주세요: ");
            
            int input = int.Parse(Console.ReadLine());

            switch (input) 
            {
                case 1:
                    EquipmentManage(player, shop, inventory); break;
                case 2:
                    shop.VisitShop(player, shop, inventory); break;
                case 0:
                    return;
                default:
                    Console.WriteLine("잘못된 입력입니다.");
                    Thread.Sleep(1000);
                    ShowInventory(player, shop, inventory); 
                    break;
            }


        }

        public void EquipmentManage(PlayerInfo player, Shop shop, Inventory inventory)
        {
            
                Console.Clear();
                Console.WriteLine("** 인벤토리 - 장착 관리");
                Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
                Console.WriteLine();

                List<Item> items = inventory.GetItems(); //인벤토리 객체에서 아이템 목록 가져오기

                for (int i = 0; i < items.Count; i++)
                {
                    //아이템이 장착되어 있다면 "[E]"를, 아니면 빈 문자열을 equipped에 저장
                    string equipped = items[i].IsEquipped ? "[E]" : "";
                    if (items[i].IsEquipped)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    Console.WriteLine($"{i + 1}. {equipped}{items[i].Name} | {items[i].Description}");
                    Console.ResetColor();
                }
                Console.WriteLine();
                Console.WriteLine("0. 나가기");
                Console.WriteLine("원하시는 아이템을 선택해주세요.");

                int selectedIndex; //플레이어가 선택한 아이템의 인덱스

                //입력한 값을 정수로 저장하고, 범위 안에 있는지 확인
                if (!int.TryParse(Console.ReadLine(), out selectedIndex) || selectedIndex < 0 || selectedIndex > items.Count)
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    Thread.Sleep(1000);
                    EquipmentManage(player, shop, inventory);
                }

                //선택한 아이템의 인덱스 조정
                selectedIndex--;

                if (selectedIndex == -1)
                {
                
                    //나가기
                    player.Info(player, shop, inventory);
                }
                //플레이어가 유효한 아이템을 선택한 경우
                else if (selectedIndex >= 0 && selectedIndex < items.Count)
                {
                    //아이템이 장착되어있는지 확인
                    Item selected = items[selectedIndex];

                    if (selected.IsEquipped)
                    {
                        //장착 해제
                        player.UnequipItem(selected);
                        selected.IsEquipped = false;
                        Console.WriteLine($"{selected.Name}을(를) 장착 해제했습니다.");
                        Thread.Sleep(1000);
                        EquipmentManage(player,shop,inventory);
                    }
                    else
                    {
                        //장착
                        player.EquipItem(selected);
                        selected.IsEquipped = true;
                        Console.WriteLine($"{selected.Name}을(를) 장착했습니다.");
                        Thread.Sleep(1000);
                        EquipmentManage(player,shop,inventory);
                    }
                }
                //상태 보기 메뉴에서 플레이어의 상태가 업데이트 되어야 함
                player.Info(player, shop, inventory);
            
        }

        //아이템 조회
        public List<Item> GetItems()
        {
            //인벤토리에 있는 모든 아이템 반환. 다른 클래스에서 인벤토리에 접근하여 확인할 수 있음.
            return items;
        }

        public void AddItem(Item item)
        {
            //주어진 아이템을 인벤토리 리스트에 추가. 추가할 아이템을 파라미터로 전달받아 리스트에 추가.
            items.Add(item);
        }

        public void RemoveItem(Item item)
        {
            //주어진 아이템을 인벤토리에서 제거함. 제거할 아이템을 파라미터로 전달받아 리스트에서 제거.
            items.Remove(item);
        }
    }
}
