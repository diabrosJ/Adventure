using Adventure;

public class GameManager
{
    private PlayerInfo playerInfo;
    private List<MonsterInfo> monsterInfo;
    static Random random = new Random();

    public GameManager()
    {
        IntiiallzeGame();
    }

    private void IntiiallzeGame()
    {
        playerInfo = new PlayerInfo(); ;

        monsterInfo = new List<MonsterInfo>();

        monsterInfo.Add(new MonsterInfo("미니언", 1, 50, 5));
        monsterInfo.Add(new MonsterInfo("대포 미니언", 1, 100, 5));
        monsterInfo.Add(new MonsterInfo("고블린", 1, 80, 5));
        monsterInfo.Add(new MonsterInfo("미니언", 1, 50, 5));
        int minMonsters = 1;
        int maxMonsters = 4;

        int numberOfMonsters = random.Next(minMonsters, maxMonsters);

    }

}