using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure
{
    internal class CharCustom
    {
        public void MaikingName()
        {
            Console.WriteLine(" 이름을 생성해주세요. ");
            //이름 생성후 직업 유형으로 넘어가게 만들 예정
        }

        enum ClassType
        {
            Warrior = 1,
            Wizard = 2,
            Bandit = 3,
        }
    }
}
