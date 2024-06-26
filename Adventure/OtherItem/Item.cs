﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Adventure
{
    public class Item
    {
        public string Name { get; } // 아이템 이름
        public string Description { get; } // 아이템 설명
        public int Price { get; } // 아이템 가격
        public int AttackBonus { get; } //아이템이 주는 공격력
        public int DefenseBonus { get; } //아이템이 주는 방어력
        public int HpBonus { get; } //아이템이 주는 체력
        public int MpBonus { get; } //아이템이 주는 마나
        public bool IsEquipped { get; set; } //아이템 장착 여부
        public bool IsPurchased { get; set; } //아이템 구매 여부

        //아이템 속성 초기화하는 생성자:
        public Item(string name, string description, int price, int attackBonus, int defenseBonus,int hpBonus,int mpBonus)
        {
            Name = name;
            Description = description;
            Price = price;
            AttackBonus = attackBonus;
            DefenseBonus = defenseBonus;
            HpBonus = hpBonus;
            MpBonus = mpBonus;
            IsEquipped = false;
            IsPurchased = false;

        }

    }
}
