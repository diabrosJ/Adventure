using Adventure.Charter.CreateFactory;
using Adventure.Charter.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Adventure
{
    public class BattleSystem
    {
        private PlayerInfo player;
        private Dictionary<string, Monster> monsters;
        private StageSelect stageSelect = new StageSelect();

        

        private Random random;

        public BattleSystem(PlayerInfo player, Shop shop, Inventory inventory)
        {
            this.player = player;

            random = new Random();

        }

        public void StartBattle(PlayerInfo plyaer, Shop shop, Inventory inventory)
        {
            Console.Clear();
            Console.WriteLine("전투 시작!!");

            //랜덤하게 몬스터 생성
            CreateMonster[] monsters = new CreateMonster[random.Next(1, 5)];

            for (int i = 0; i < monsters.Length; i++)
            {
                int monsterType = random.Next(1, 4);

                switch (monsterType)
                {
                    case 1:
                        monsters[i] = new CreateMonster(Monster.Monsters["CannonMinion"]);
                        break;
                    case 2:
                        monsters[i] = new CreateMonster(Monster.Monsters["MeleeMinion"]);
                        break;
                    case 3:
                        monsters[i] = new CreateMonster(Monster.Monsters["Voidling"]);
                        break;
                    default:
                        monsters[i] = new CreateMonster(Monster.Monsters["Minion"]);
                        break;
                }
            }

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("[몬스터 정보]");
                foreach (var monster in monsters)
                {
                    if (monster.Hp <= 0)
                    {
                        Console.Write($"Lv.{monster.Level} {monster.Name}");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(" [DEAD]");
                        Console.ResetColor();
                    }
                    if (monster.Hp > 0)
                        Console.WriteLine($"Lv.{monster.Level} {monster.Name} HP: {monster.Hp}");
                }
                Console.WriteLine();

                //플레이어의 턴
                PlayerTurn(player, shop, inventory, monsters);

                //몬스터가 모두 죽었는지 확인
                bool allMonsterDead = true;
                foreach (var monster in monsters)
                {
                    if (monster.Hp > 0)
                    {
                        allMonsterDead = false;
                        break;
                    }
                }

                if (allMonsterDead)
                {
                    //전투 결과 호출 -승리
                    Console.WriteLine("전투에서 승리하셨습니다!");
                    player.WinBattle(monsters.Length);
                    Thread.Sleep(1000);
                    Console.Clear();
                    if (AskForRetry())
                    {
                        // 다시 전투하기
                        StartBattle(player, shop, inventory);
                    }
                    else
                    {
                        stageSelect.StageMenu(player, shop, inventory);
                    }
                    break;
                }


                Console.Clear();
                MonsterTurn(monsters, player);

                //플레이어가 죽었는지 확인

                if (player.Hp <= 0)
                {
                    Console.WriteLine("패배하셨습니다!");
                    player.MAXHP();
                    if (AskForRetry())
                    {
                        // 다시 전투하기
                        StartBattle(player, shop, inventory);
                    }
                    else
                    {
                        stageSelect.StageMenu(player, shop, inventory);
                    }
                    break;
                }

            }
        }

        private void PlayerTurn(PlayerInfo player, Shop shop, Inventory inventory, CreateMonster[] monsters)
        {
            int playerHP = player.GetEquippedHP();
            int playerMP = player.GetEquippedMP();

            Console.WriteLine("[내 정보]");
            Console.WriteLine($"Lv.{player.Lv} {player.Name} ({player.Job})");
            Console.WriteLine($"HP : {playerHP}");
            Console.WriteLine($"MP : {playerMP}");
            Console.WriteLine();
            Console.WriteLine("1. 공격");
            Console.WriteLine("2. 스킬 사용");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Attack(monsters);
                    Thread.Sleep(1000);
                    Console.Clear();
                    break;
                case 2:
                    //스킬 사용
                    UseSkill();
                    break;
                default:
                    Console.WriteLine("잘못된 입력입니다.");
                    Thread.Sleep(1000);
                    break;
            }
        }

        private void Attack(CreateMonster[] monsters)
        {
            Console.WriteLine();
            Console.WriteLine("공격할 몬스터 선택: ");

            //몬스터 리스트 출력
            for (int i = 0; i < monsters.Length; i++)
            {
                if (monsters[i].Hp > 0)
                {
                    Console.WriteLine($"{i + 1}. {monsters[i].Name} - HP : {monsters[i].Hp}");
                }
                if (monsters[i].Hp < 0)
                {
                    Console.Write($"{i + 1}. {monsters[i].Name} : ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("[DEAD]\n");
                    Console.ResetColor();
                }
            }
            Console.WriteLine();

            int targetIndex = int.Parse(Console.ReadLine()) - 1;

            if (targetIndex < 0 || targetIndex >= monsters.Length)
            {
                Console.WriteLine("잘못된 입력입니다!");
                Thread.Sleep(1000);
                Attack(monsters);
            }

            CreateMonster target = monsters[targetIndex];

            if (target.Hp <= 0)
            {
                Console.WriteLine("이미 죽은 적입니다.");
                Thread.Sleep(1000);
                Attack(monsters);
            }

            //공격력 계산
            int baseDamage = player.GetEquippedAttack();
            int damage = random.Next((int)(baseDamage * 0.9), (int)(baseDamage * 1.1) + 1);

            //몬스터에게 데미지 적용
            target.Hp -= damage;
            if (target.Hp <= 0)
            {
                target.Hp = 0;
                Console.WriteLine($"{target.Name} 은 죽었다!");
                Thread.Sleep(1000);
            }
            else
            {
                Console.WriteLine($"{target.Name}은 {damage} 만큼 데미지를 입었다!");
            }


        }

        private void UseSkill()
        {
            //해당 직업의 스킬 사용 구현
            if (player.Job == "전사")
            {
                Console.WriteLine("**스킬 목록**");
                Console.WriteLine("1. 스킬 이름 - MP ??");
                Console.WriteLine("--스킬 효과 설명--");
                Console.WriteLine("2. 스킬 이름 - MP ??");
                Console.WriteLine("--스킬 효과 설명--");
                Console.WriteLine();
                Console.WriteLine("사용할 스킬을 선택하세요.");

                int skillChoice = int.Parse(Console.ReadLine());
                switch (skillChoice)
                {
                    case 1:
                        //전사 스킬 1번
                        break;
                    case 2:
                        //전사 스킬 2번
                        break;
                    default:
                        Console.WriteLine("잘못된 입력입니다!..");
                        Thread.Sleep(1000);
                        UseSkill();
                        break;
                }
            }
            else if (player.Job == "마법사")
            {
                Console.WriteLine("**스킬 목록**");
                Console.WriteLine("1. 스킬 이름 - MP ??");
                Console.WriteLine("--스킬 효과 설명--");
                Console.WriteLine("2. 스킬 이름 - MP ??");
                Console.WriteLine("--스킬 효과 설명--");
                Console.WriteLine();
                Console.WriteLine("사용할 스킬을 선택하세요.");

                int skillChoice = int.Parse(Console.ReadLine());
                switch (skillChoice)
                {
                    case 1:
                        //마법사 스킬 1번
                        break;
                    case 2:
                        //마법사 스킬 2번
                        break;
                    default:
                        Console.WriteLine("잘못된 입력입니다!..");
                        Thread.Sleep(1000);
                        UseSkill();
                        break;
                }
            }
            else if (player.Job == "도적")
            {
                Console.WriteLine("**스킬 목록**");
                Console.WriteLine("1. 스킬 이름 - MP ??");
                Console.WriteLine("--스킬 효과 설명--");
                Console.WriteLine("2. 스킬 이름 - MP ??");
                Console.WriteLine("--스킬 효과 설명--");
                Console.WriteLine();
                Console.WriteLine("사용할 스킬을 선택하세요.");

                int skillChoice = int.Parse(Console.ReadLine());
                switch (skillChoice)
                {
                    case 1:
                        //도적 스킬 1번
                        break;
                    case 2:
                        //도적 스킬 2번
                        break;
                    default:
                        Console.WriteLine("잘못된 입력입니다!..");
                        Thread.Sleep(1000);
                        UseSkill();
                        break;
                }
            }

        }

        private void MonsterTurn(CreateMonster[] monsters, PlayerInfo player)
        {
            foreach (var monster in monsters)
            {
                if (monster.Hp > 0)
                {
                    //continue;
                    //Console.Clear();
                    //몬스터가 플레이어 공격
                    int playerDef = (int)player.GetEquippedDefense() / 3;

                    int baseDamage = monster.Atk;
                    int damgage = random.Next((int)(baseDamage * 0.9), (int)(baseDamage * 1.1) + 1);

                    if (damgage - playerDef < 0)
                    {
                        damgage = 0;
                    }

                    player.Hp -= damgage - playerDef;

                    Console.WriteLine($"{monster.Name} 공격! {player.Name} (은)는 {damgage} 만큼 데미지를 입었다!");
                    Console.WriteLine();
                }
                else
                {
                    continue;
                }
            }
        }
        private bool AskForRetry()
        {
            Console.WriteLine("다시 전투하시겠습니까? (Y/N)");
            string input = Console.ReadLine().ToUpper();
            return input == "Y";
            
        }
    }
}