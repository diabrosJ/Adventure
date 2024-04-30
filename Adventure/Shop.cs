using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Media;
using System.Text;

namespace Adventure
{
    class Shop
    {
        private List<Item> availableItems;

        

        public Shop()
        {
            //가격,추가 HP, 추가 MP, 추가 공격력, 추가 방어력 순서
            availableItems = new List<Item>
            {
                new Item("아이템1","아이템이 주는 스탯 | 아이템 설명 ", 1000,100,50,3,1),
                new Item("아이템2","아이템이 주는 스탯 | 아이템 설명 ", 2000,200,100,6,2),
                new Item("아이템3","아이템이 주는 스탯 | 아이템 설명 ", 3000,300,150,9,4),
                new Item("아이템4","아이템이 주는 스탯 | 아이템 설명 ", 4000,400,200,12,8),
                new Item("아이템5","아이템이 주는 스탯 | 아이템 설명 ", 5000,500,250,15,16),
                new Item("아이템6","아이템이 주는 스탯 | 아이템 설명 ", 6000,600,300,18,),

           };
        }

        //상점에서 구매 가능한 아이템 목록 가져오는 메서드
        public List<Item> GetAvailableItems(/*플레이어 매개변수*/)
        {
            List<Item> result = new List<Item>();

            foreach(var item in availableItems )
            {
                if(!item.IsPurchased || /*플레이어 골드 >= item.Price*/)
                {
                    result.Add(item);
                }
            }
            return result;
        }

        //아이템 구매
        public bool PurchaseItem(/*플레이어 매개변수*/ Item item)
        {
            if(/*플레이어 골드* >= item.Price &&*/ !item.IsPurchased )
            {
                //플레이어 골드 조정 메서드(-item.Price) 아이템 가격만큼 재화를 차감
                item.IsPurchased = true; // 아이템 구매 상태 변경
                return true;
            }
            return false;
        }

        public void SellItem(/*플레이어 매개변수*/ Item item)
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

    

    }
}
