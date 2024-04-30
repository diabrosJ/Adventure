using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure
{
    internal class PlayerInfo
    {
        GoMain main;
        public string Job { get; set; }
        public int Lv { get; set; }
        public int Str { get; set; }
        public int Def { get; set; }
        public int Hp { get; set; }
        public int Gold { get; set; }
        public int menu { get; set; }
        public int Mp { get; set; }

        public PlayerInfo(string job,int lv, int str, int def, int hp, int mp, int gold)
        { //생성자 < 

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
        }
        public void Info()
        {
            Console.Clear();

            while (true)
            {
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
    }
}
