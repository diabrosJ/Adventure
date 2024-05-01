using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure
{
    public class PlayerInfo
    {
        CharCustom name;
        GoMain main;
        Inventory inventory;
        Shop shop;
        public string Name { get; set; }
        public string Job { get; set; }
        public int Lv { get; set; }
        public int Str { get; set; }
        public int Def { get; set; }
        public int Hp { get; set; }
        public int Gold { get; set; }
        public int menu { get; set; }
        public int Mp { get; set; }

        private List<Item> equippedItems;

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
        }
        public void Info()
        {
            Console.Clear();

            while (true)
            {
                Console.WriteLine($"이름 : {Name}");
                Console.WriteLine($"직업 : {Job}");
                Console.WriteLine($"Lv : {Lv}");
                Console.WriteLine($"공격력 : {Str}");
                Console.WriteLine($"방어력 : {Def}");
                Console.WriteLine($"체력 : {Hp}");
                Console.WriteLine($"마력 : {Mp}");
                Console.WriteLine($"골드 : {Gold}");
                
                int input;
                int.TryParse(Console.ReadLine(), out input);
                switch (input)
                {
                    case 1:
                        Console.Clear();
                        return;
                }
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
