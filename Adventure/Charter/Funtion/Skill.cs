using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure
{
    internal class SKill
    {

        public string Name { get; set; }
        public int Str { get; set; }
        public int Mp { get; set; }

        public SKill(string name, int str, int mp)

        { //생성자 < 

            Name = name;
            //이름
            Str = str;
            //공격력
            Mp = mp;
            //마력
        }
    }

}
