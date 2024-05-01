internal class MonsterInfo
{
    public string Name { get; set; }
    public int Lv { get; set; }
    public int Hp { get; set; }
    public int Attack { get; set; }

    public MonsterInfo(string name, int lv, int hp, int attack)
    {
        Name = name;
        Lv = lv;
        Hp = hp;
        Attack = attack;
    }

}