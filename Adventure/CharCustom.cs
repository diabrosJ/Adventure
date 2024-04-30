using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Adventure
{
    internal class CharCustom
    {

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

                int input;
                ClassType choice;
                int.TryParse(Console.ReadLine(), out input);
                Console.Clear();
                switch (input)
                {
                    case 1:
                        choice = ClassType.Warrior;
                        Console.WriteLine("전사를 선택하셨습니다.");
                        goMain.mainScence(createClass.warrior());
                        return;
                    case 2:
                        choice = ClassType.Wizard;
                        Console.WriteLine("마법사를 선택하셨습니다.");
                        goMain.mainScence(createClass.wizard());
                        return;
                    case 3:
                        choice = ClassType.Bandit;
                        Console.WriteLine("도적를 선택하셨습니다.");
                        goMain.mainScence(createClass.bandit());
                        return;
                }
            }

        }


    }
}
