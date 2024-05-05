using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Adventure
{
    public class PlayerInfo
    {
        CharCustom name;
        GoMain main;
        Inventory inventory = new Inventory();
        Shop shop = new Shop();

        public string Name { get; set; }
        public string Job { get; set; }
        public int Lv { get; set; }
        public int Str { get; set; }
        public int Def { get; set; }
        public int Hp { get; set; }
        public int Gold { get; set; }
        public int Mp { get; set; }
        //public int equippedHP { get; set; }
        //public int equippedMP { get; set; }
        //public int equippedAtk { get; set; }
        //public int equippedDef { get; set; }


        private List<Item> equippedItems;

        List<SKill> sKill;


        public PlayerInfo(string name, string job,int lv, int str, int def, int hp, int mp, int gold)

        { //생성자 < 

            Name = name;
            //이름
            Job = job;
            //직업
            Lv = lv;
            //레벨
            Str = str;
            //공격력
            Def = def;
            //방어력
            Hp = hp;
            //체력
            Mp = mp;
            //마력
            Gold = gold;
            //골드


          

            equippedItems = new List<Item>();
            //장착한 아이템 목록
            sKill = new List<SKill>();
            //스킬 목록

            if (Job == "전사")
            {
                sKill.Add(new SKill("전사스킬1", 10, 10));
                sKill.Add(new SKill("전사스킬2", 10, 10));
                sKill.Add(new SKill("전사스킬3", 10, 10));
            }
            else if(Job == "마법사")
            {
                sKill.Add(new SKill("마법사스킬1", 10, 10));
                sKill.Add(new SKill("마법사스킬2", 10, 10));
                sKill.Add(new SKill("마법사스킬3", 10, 10));
            }
            else
            {
                sKill.Add(new SKill("도적스킬1", 10, 10));
                sKill.Add(new SKill("도적스킬2", 10, 10));
                sKill.Add(new SKill("도적스킬3", 10, 10));
            }
        }
        public void Info(PlayerInfo player, Shop shop, Inventory inventory)
        {
            int equippedAtk = GetEquippedAttack();//장비 장착 시 총 공격력
            int increasedAttack = equippedAtk - player.Str; //장비 장착으로 얻게 된 공격력

            int equippedDef = GetEquippedDefense();//장비 장착 시 총 방어력
            int increasedDefense = equippedDef - player.Def; //장비 장착으로 얻게 된 방어력

            int equippedHP = GetEquippedHP(); //장비 장착 시 총 체력
            int increasedHP = equippedHP - player.Hp;

            int equippedMP = GetEquippedMP(); //장비 장착 시 총 마나
            int increasedMP = equippedMP - player.Mp;

          
                Console.Clear();
                Console.WriteLine($"이름 : {Name}");
                Console.WriteLine($"직업 : {Job}");
                Console.WriteLine($"Lv : {Lv}");
                Console.WriteLine($"공격력 : {equippedAtk} (+{increasedAttack})");
                Console.WriteLine($"방어력 : {equippedDef} (+{increasedDefense})");
                Console.WriteLine($"체력 : {equippedHP} (+{increasedHP})");
                Console.WriteLine($"마력 : {equippedMP} (+{increasedMP})");
                Console.WriteLine($"골드 : {Gold}\n");
                for (int i = 0; i < sKill.Count; i++)
                {
                    Console.WriteLine();
                    Console.WriteLine($"스킬이름: {sKill[i].Name} 스킬공격력: {sKill[i].Str} 스킬소모값: {sKill[i].Mp} ");
                }
                Console.WriteLine("\n1. 이전 메뉴로");
                Console.WriteLine("2. 인벤토리");
                Console.WriteLine("3. 상점 입장하기");
                

                int.TryParse(Console.ReadLine(), out int input);
                switch (input)
                {
                    case 1:
                        Console.Clear();
                        //main.mainScence(player, shop, inventory); <<버그 수정해야됨
                        return;
                    case 2:
                        inventory.ShowInventory(player, shop, inventory); //<< 수정 완료
                        //인벤토리로 바로 들어가는거 확인했습니다
                        //return 바로 메인으로 갑니다.
                        //저장된 아이템이 등록과 확인이 되는지 부탁드립니다.
                        Console.Clear();
                        break;
                    case 3:
                        shop.VisitShop(player, shop, inventory);
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

        //장착한 아이템을 포함한 총 공격력 계산
        public int GetEquippedAttack()
        {
            int total = Str;
            foreach(var item in equippedItems)
            {
                total += item.AttackBonus;
            }
            return total;
        }

        //장착한 아이템을 포함한 총 방어력 계산
        public int GetEquippedDefense()
        {
            int total = Def;
            foreach(var item in equippedItems)
            {
                total += item.DefenseBonus;
            }
            return total;
        }

        //장착한 아이템을 포함한 총 체력 계산
        public int GetEquippedHP()
        {
            int total = Hp;
            foreach(var item in equippedItems)
            {
                total += item.HpBonus;

            }
            return total;
        }

        //장착한 아이템을 포함한 총 마나 계산
        public int GetEquippedMP() 
        {
            int total = Mp;
            foreach(var item in equippedItems)
            {
                total += item.MpBonus;
            }
            return total;
        }

        //아이템 장착
        public void EquipItem(Item item)
        {
            equippedItems.Add(item);
        }

        //아이템 장착 해제
        public void UnequipItem(Item item)
        {
            equippedItems.Remove(item);
        }

        //골드 조정, 지정된 양만큼 증감
        public void AdjustGold(int amount)
        {
            Gold += amount;
        }

    }
}
