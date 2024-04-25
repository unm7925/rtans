using System.ComponentModel.Design;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks.Dataflow;
using System.Xml;
using static SpartaDun.Program;

namespace SpartaDun
{
    internal class Program
    {
        private static int luck;
        private static int choice;

        private static string taptap = "\t\t\t\t\t";
        private static string playerT = taptap + taptap;

        private static Random random = new Random();
        
        static void Main(string[] args)
        {
            bool isPlayerTalk = true;
            UserInfoStruct infoData = new UserInfoStruct(1,"none","none",10,5,100,1500);
            EveryFunction func = new EveryFunction(infoData);
            Place map = new Place();
            Player play = new Player();
            
            
            
            

            
            map.StartPlace();
            Console.WriteLine("??? : \"안녕하세요. 처음뵙겠습니다.\n      당신의 운은 좋으신가요?\"");
            Console.WriteLine($"{playerT}1.네\t2.아니요");
            play.PlayLucky();
            if (luck == 1)
            {
                luck = random.Next(1, 7);
                Console.WriteLine();
                Console.WriteLine($"{taptap}주사위가 굴러간다 . . .");
                Console.WriteLine($"{taptap}주사위가 멈췄다 . . . {luck}\n");

                if (luck == 1)
                {
                    Console.WriteLine("??? : \"운이 정말 좋으신가보네요!\"");
                    Console.WriteLine($"{taptap}당신을 무시하는 것 같다.\n" +
                                      $"{playerT}1.지나간다\t2.반응한다.");
                    play.PlayTalk();
                    if (choice == 1)
                    {
                        Console.WriteLine($"{taptap}\'터벅 .. 터벅 .. 터벅 ..\'\n");
                    }
                    else if (choice == 2)
                    {
                        Console.WriteLine("??? : \"네에∼ 네에∼ \"\n");
                        Console.WriteLine($"{taptap}들을 생각이 없어보인다.\n");
                    }
                }
                else if (luck <= 3)
                {
                    Console.WriteLine("??? : \"여긴 왜 오신걸까요?\"");
                    Console.WriteLine($"{playerT}1.과제\t2.재미");
                    play.PlayTalk();
                    if(choice==1)
                    {
                        Console.WriteLine("??? :\" 그게 무슨..? \"\n");
                    }
                    else if(choice==2)
                    {
                        Console.WriteLine("??? : \"재미..? 스릴 넘치겠네요!\"\n");
                    }
                }
                else if (luck < 6) 
                { 
                    Console.WriteLine("??? : \"애매한것이 안좋은 것보다 못하다는 사실 아시나요?\"\n");
                    Console.WriteLine($"{playerT}1.안다\t2.모른다");
                    play.PlayTalk();
                    if(choice == 1) 
                    {
                        Console.WriteLine("??? : \"아시는 구나. . . 그럼 화이팅하시길\"\n");
                        Console.WriteLine($"{taptap}왜인지 모르게 침울한 것 같다.\n");
                    }
                    else if(choice==2)
                    {
                        Console.WriteLine("??? : \"이걸 모르시네. . 저도 몰라요 어디서 나온말인지\"\n");
                    }
                }
                else 
                {
                    Console.WriteLine("??? : \"여태 어떻게 살아오신걸까요?\"\n");
                    Console.WriteLine($"{playerT}무슨 뜻인걸까?\n" +
                        $"{playerT}1.묻는다\t2.안묻는다.");
                    play.PlayTalk();
                    if(choice == 1)
                    {
                        Console.WriteLine("??? : \"그냥 . . 단순한 호기심이였어요.\"\n");
                    }
                    else if(choice == 2)
                    {
                        Console.WriteLine($"{taptap}???이 모습을 감추었다.\n");
                    }
                }
            }
            else
            {
                luck = 3;
                Console.WriteLine($"??? : \"앞으론 자신을 믿어봅시다. 당신의 운은 {luck} 이정도 라고 하고 다니세요.\"");
            }
            
            Console.WriteLine($"{taptap}더이상 할 것이 없는 것 같다\n{taptap}그 자리에서 뒤를 돌았다.");
            Console.WriteLine($"{taptap}아무소리도 들리지 않고\n{taptap}앞에 길이 흐릿하게 보일정도의 어두움이다.\n" +
                $"{playerT}1.따라간다.\t2.안간다");
            play.PlayTalk();
            if(choice == 1) 
            {
                map.StandardPlace();
                Console.WriteLine($"{taptap}점점 빛이 들어오기 시작하고\n{taptap}#이 그려진 건물이 보인다.");
            }
            else if(choice == 2) 
            {
                Console.WriteLine($"{taptap}점점 더 어두워지는 것 같다.\n{taptap}뒤에서 발걸음 소리가 들려온다.");
                Console.WriteLine($"{playerT}1.길을 따라간다\t2.안간다.");
                play.PlayTalk();
                if(choice == 1)
                {
                    map.StandardPlace();
                    Console.WriteLine($"{taptap}점점 빛이 들어오기 시작하고\n{taptap}#이 그려진 건물이 보인다.");
                }
                else if(choice ==2)
                {
                    Console.WriteLine($"{taptap}형태가 드러날 정도의 거리가 되자 정신을 잃었다.\n{taptap}정신이 돌아오고 있을 무렵 땅에 쓸린 상처가 생겼다.");
                    map.StandardPlace();
                    Console.WriteLine($"{taptap}갑자기 보인 환한 빛 앞으로\n{taptap}#이 그려진 건물이 보인다.");
                }
            }
            Console.WriteLine($"{taptap}바닥에 떨어진 쪽지를 발견했다.\n\n쪽지의 내용 \'나는 여기서 죽었다. 여기 올 누군가를 위해 적는다.\'\n　　　 　　 \'여기는 위험하다, 나가는 곳도 없다. 희망갖지마라.\'\n");
            Console.WriteLine($"{taptap}불길한 내용을 보고 무엇이라도 해야할 것 같다.\n");

            while (isPlayerTalk)
            {
                Console.WriteLine($"\n{playerT}1.상태보기\n" +
                                  $"{playerT}2.가방열기\n" +
                                  $"{playerT}3.#점\n{playerT}0.나가기\n");
            Console.Write($"{playerT}당신의 선택은?\n" +
            $"{playerT} ");
            
                play.PlayerSelect();
                if (choice == 1)
                {
                    func.UsingStats();
                    
                }
                else if (choice == 2)
                {
                    func.UsingInven();
                    
                }
                else if (choice == 3)
                {
                    func.UsingShop();
                }
                else if (choice == 0)
                {
                    Console.WriteLine($"{taptap}어디를 가야할지 막막하다.");
                    isPlayerTalk = false;
                }
                else
                {
                    Console.WriteLine($"{playerT}잘못된 입력입니다.\n");
                }
            }
            isPlayerTalk = true;




        }
        public class Place
        {
            public void StartPlace()
            {
                Console.WriteLine($"{taptap}┌──────────────┐\n" +
                              $"{taptap}│　 Lcuky Day　│\n" +
                              $"{taptap}└──────────────┘\n" +
                              "────────────────────────────────────────────────" +
                              "────────────────────────────────────────────────");
            }
            public void StandardPlace()
            {
                Console.WriteLine($"{taptap}º￣￣￣￣￣￣￣￣￣￣￣￣￣￣￣￣º\n" +
                                  $"{taptap}§└ 　 　　 　　■　　■　  　  ┘ §\n" +
                                  $"{taptap}＠　º　　　 ■■■■■■　   º  ＠\n" +
                                  $"{taptap}　　§┐　　 　■　　■　 　 ┌ §\n" +
                                  $"{taptap}　　＠│　　■■■■■■  　 │ ＠\n" +
                                  $"{taptap}　　  │　　 ■　　■　   　 │ \n"+
                                  $"{taptap}　　  ├──┬───────────────┬──┤ \n" +
                                  $"{taptap}　　  ￣ │ 　　　　 　   │  ￣ \n" +
                                  $"{taptap}　　 　　│　　　　     　│ \n"+
                                  $"{taptap}　　 　　┴　　　　     　┴ \n");
            }
        }
        public class Player
        {
         //   private int life = 5;
            public void PlayTalk()
            {
                Console.Write($"\n{playerT}당신의 선택은?\n" +
                $"{playerT} ");
                PlayerSelect();
                if (choice != 1 && choice != 2)
                {
                    Console.WriteLine($"{playerT}다시");
                    PlayTalk();
                }
            }
            public void PlayLucky()
            {
                Console.Write($"\n{playerT}당신의 선택은?\n" +
                $"{playerT} ");
                string act = Console.ReadLine();
                luck = int.Parse(act);
                if(luck !=1 && luck !=2)
                {
                    Console.WriteLine($"{playerT}다시");
                    PlayLucky();
                }
            }
            public void PlayerSelect()
            {
                choice = int.Parse(Console.ReadLine());
            }
            
            
        }
        
        public struct UserInfoStruct
        {
            public int Level { get; set; }
            public string Name { get; set; }
            public string Job { get; set; }
            public int Attack { get; set; }
            public int Defence { get; set; }
            public int HP { get; set; }
            public int Gold { get; set; }
            
            //01,"none","무직",10,5,100,1500
            public UserInfoStruct(int level, string name, string job, int attack, int defence, int hp, int gold )
            {
                Level = level;
                Name = name;
                Job = job;
                Attack = attack;
                Defence = defence;
                HP = hp;
                Gold = gold;
            }
            
            public void UserChangeStats(int addAttack,int addDefence)
            {
                this.Attack += addAttack;
                this.Defence += addDefence;   
            }
            public void UserChangeGold(int addGold)
            {
                this.Gold += addGold;
            }
            public void UserLevelUp(int level,int addAttack, int hp)
            {
                this.Level += level;
                this.Attack += addAttack;
                this.HP += hp;
            }
        }
        struct ItemStruct
        {
            public string Name { get; set; }
            public string Option { get; set; }
            public string Tmi { get; set; }
            public int OptionValue { get; set; }
            public int AddGold { get; set; }

            public bool Equip {  get; set; }
            public bool Purchase { get; set; }
            public int InvenItem {  get; set; }
            public ItemStruct(string name,string option, int optionValue, string tmi ,int addGold)
            {
                Name = name;
                Option = option;
                Tmi = tmi;
                OptionValue = optionValue;
                AddGold = addGold;
                Purchase=false;
                Equip = false;
                InvenItem = 0;
            }
        }

        
        
        public class EveryFunction
        {
            List<ItemStruct> items = new List<ItemStruct>();
            UserInfoStruct userInfo;

            bool isUsingInven;
            bool isUsingShop;
            bool isPurchaseCheck;
            bool isTakeItem;
            int invenItemNum = 0;
            public EveryFunction(UserInfoStruct userInfoStruct)
            {
                userInfo = userInfoStruct;
                InfoItem();
            }
            public void InfoItem()
            {
                items.Add(new ItemStruct("C#강의", "공격력", 100, "C#의 모든것을 담았다.", 30000));
                items.Add(new ItemStruct("개인과제", "공격력", 200, "할수있으면 해보도록", 50000));
                items.Add(new ItemStruct("롱 소드", "공격력", 10, "재미없는 긴 검", 100));
                items.Add(new ItemStruct("초록슬리퍼", "방어력", 20, "누구에게나 열려있습니다.", 0));
                items.Add(new ItemStruct("쇠사슬 조끼", "방어력", 50, "어딘가 익숙한 이름이다.", 500));
                items.Add(new ItemStruct("킹왕짱킹갓제네럴검", "공격력", 1000, "킹왕짱킹갓제네럴", 100000));
                items.Add(new ItemStruct("신속의 바지", "방어력", 15, "시원함이 일품", 200));
                items.Add(new ItemStruct("초보자 모자", "방어력", 30, "바가지 상품", 300));
            }
            public void ItemListTypeEquip()
            {
                if (isUsingInven && !isTakeItem)
                {
                    for (int i = 0; i < items.Count; i++)
                    {
                        if (items[i].Purchase == true)
                        {
                            if (items[i].Equip == true)
                            {
                                Console.WriteLine($" - [E]{items[i].Name}       | {items[i].Option}+{items[i].OptionValue}     | {items[i].Tmi}");
                            }
                            else
                            {
                                Console.WriteLine($" - {items[i].Name}       | {items[i].Option}+{items[i].OptionValue}     | {items[i].Tmi}");
                            }
                        }
                    }
                }
                else if (isUsingInven && isTakeItem)
                {
                    for (int i = 0; i < items.Count; i++)
                    {

                        if (items[i].Purchase == true)
                        {
                            invenItemNum++;
                            if (items[i].Equip == true)
                            {
                                Console.WriteLine($" - {invenItemNum} [E]{items[i].Name}       | {items[i].Option}+{items[i].OptionValue}     | {items[i].Tmi}");
                                var currentItem = items[i];
                                currentItem.InvenItem = invenItemNum;
                                items[i] = currentItem;
                            }
                            else
                            {
                                Console.WriteLine($" - {invenItemNum} {items[i].Name}       | {items[i].Option}+{items[i].OptionValue}     | {items[i].Tmi}");
                                var currentItem = items[i];
                                currentItem.InvenItem = invenItemNum;
                                items[i] = currentItem;
                            }
                        }
                    }
                    invenItemNum = 0;
                }
                else if (isUsingShop && !isPurchaseCheck)
                {
                    for (int i = 0; i < items.Count; i++)
                    {
                        if (items[i].Purchase == true)
                        {
                            Console.WriteLine($" -  {items[i].Name}       | {items[i].Option}+{items[i].OptionValue}     | {items[i].Tmi}    | 구매완료");
                        }
                        else
                        {
                            Console.WriteLine($" -  {items[i].Name}       | {items[i].Option}+{items[i].OptionValue}     | {items[i].Tmi}    | {items[i].AddGold}");
                        }
                    }
                }
                else if (isUsingShop && isPurchaseCheck)
                {
                    for (int i = 0; i < items.Count; i++)
                    {
                        if (items[i].Purchase == true)
                        {
                            Console.WriteLine($" - {i + 1} {items[i].Name}       | {items[i].Option}+{items[i].OptionValue}     | {items[i].Tmi}    | 구매완료");
                        }
                        else
                        {
                            Console.WriteLine($" - {i + 1} {items[i].Name}       | {items[i].Option}+{items[i].OptionValue}     | {items[i].Tmi}    | {items[i].AddGold}");
                        }
                    }
                }
            }
            
            public void UsingInven()
            {
                int invenChoice;
                isTakeItem = false;
                isUsingInven = true;
                int selectIndexInven;
                while (isUsingInven)
                {
                    Console.WriteLine("아이템 목록\n\n");
                    ItemListTypeEquip();

                    Console.WriteLine($"{playerT}1.장착관리\t0.나가기");
                    Console.Write($"{playerT}");
                    invenChoice = int.Parse(Console.ReadLine());


                    if (invenChoice == 1)
                    {
                        isTakeItem=true;
                        while (isTakeItem)
                        {
                            ItemListTypeEquip();
                            Console.WriteLine($"{playerT}장착할 아이템을 선택");
                            Console.WriteLine($"{playerT}0.나가기");
                            Console.Write($"{playerT}");
                            selectIndexInven = int.Parse(Console.ReadLine());

                            if (selectIndexInven > 0 && selectIndexInven <= items.Count)
                            {
                                for (int i = 0; i < items.Count; i++)
                                {
                                    if (items[i].InvenItem == selectIndexInven)
                                    {
                                        var currentItem = items[i];
                                        currentItem.Equip = !currentItem.Equip;
                                        items[i] = currentItem;
                                        Console.WriteLine($"{taptap}{currentItem.Name}을(를) 장착하였습니다.\n\n");
                                        break;
                                    }
                                }
                            }
                            else if(selectIndexInven == 0)
                            {
                                isTakeItem = false;
                            }
                            else
                            {
                                Console.WriteLine($"{playerT}잘못누르셨습니다.");
                            }

                        }
                    }
                    else if (invenChoice == 0)
                    {
                        isUsingInven = false;
                    }
                    else
                    {
                        Console.WriteLine($"{playerT}잘못입력하셨습니다.\n");
                    }
                    Console.Write($"{taptap}가방을 닫고 앞을 바라봅니다. ");
                }

            }
            public void UsingStats()
            {
                
                int statsChoice=1;
                Console.WriteLine($"{taptap}캐릭터 정보");

                int addAttack = 0;
                int addDefence = 0;

                for (int i = 0; i < items.Count; i++)
                {
                    if (items[i].Equip == true)
                    {
                        if(items[i].Option =="공격력")
                        {
                            addAttack += items[i].OptionValue;
                        }
                        else if (items[i].Option=="방어력")
                        {
                            addDefence += items[i].OptionValue;
                        }
                    }
                }
                Console.WriteLine($"Lv. {userInfo.Level}\n{userInfo.Name} ( {userInfo.Job} )\n공격력 : {userInfo.Attack+addAttack}+({addAttack})\n방어력 : {userInfo.Defence+addDefence}+({addDefence})\n체　력 : {userInfo.HP}\nGold : {userInfo.Gold} G\n");
                Console.Write($"{playerT}0.나가기\n{playerT}당신의 선택은?\n" +
                $"{playerT} ");
                
                while (statsChoice != 0)
                {
                    statsChoice = int.Parse(Console.ReadLine());
                    Console.WriteLine($"{playerT}잘못 입력하였습니다.\n");
                    Console.Write($"{playerT} ");
                }
                Console.WriteLine($"{taptap}몸 매무세를 정돈하고 앞을 바라봅니다. ");
            }
            

            public void UsingShop()
            {
                
                isUsingShop = true;
                int selectIndex=0;
                int shopChoice;
                Console.WriteLine($"{taptap}#건물에 다가갔다.\n" +
                $"{taptap} 다양한 물건들과 정체모를 사람이 있다.\n" +
                $"{taptap} 자세히 보니물건과 가격표가 적혀있었다.\n\n");
                Console.WriteLine($"{taptap}# ShopEnter #\n" +
                    $"{playerT}My Gold : {userInfo.Gold}G\n\n");

                Console.WriteLine("아이템 목록\n\n");
                
                while (isUsingShop)
                {
                    ItemListTypeEquip();
                    
                    Console.WriteLine($"{playerT}1.아이템 구매\t0.나가기");
                    Console.Write($"{playerT} ");
                    shopChoice = int.Parse(Console.ReadLine());
                
                    if (shopChoice == 1)
                    {
                        isPurchaseCheck = true;
                        ItemListTypeEquip();
                        Console.WriteLine($"{playerT}구매할 아이템을 선택하세요:");
                        Console.Write($"{playerT} ");
                        
                            selectIndex = int.Parse(Console.ReadLine());
                        if( 0 < selectIndex && selectIndex <= items.Count)
                        {
                            selectIndex--;
                            if (items[selectIndex].Purchase == true)
                            {
                                Console.WriteLine($"선택한 아이템: {items[selectIndex].Name}는(은) 이미 있습니다\n");
                            }
                            else
                            {
                                Console.WriteLine($"선택한 아이템: {items[selectIndex].Name}       | {items[selectIndex].Option}+{items[selectIndex].OptionValue}     | {items[selectIndex].Tmi}    | {items[selectIndex].AddGold}G");
                                Console.WriteLine($"{playerT}1.구매\t2.취소");
                                Console.Write($"{playerT} ");

                                while (isPurchaseCheck)
                                {
                                    int buyChoice = int.Parse(Console.ReadLine());
                                    if (buyChoice == 1)
                                    {
                                        // 아이템 구매 처리
                                        if (userInfo.Gold >= items[selectIndex].AddGold)
                                        {
                                            Console.WriteLine($"{playerT}아이템을 구매하였습니다.");
                                            var currentItem = items[selectIndex];
                                            currentItem.Purchase = !currentItem.Purchase;
                                            items[selectIndex] = currentItem;
                                            userInfo.UserChangeGold(-items[selectIndex].AddGold);
                                            
                                            // info.Gold -= items[itemIndex].AddGold; // 골드 차감
                                            
                                        }
                                        else
                                        {
                                            Console.WriteLine($"{playerT}골드가 부족하여 아이템을 구매할 수 없습니다.\n");
                                        }
                                        isPurchaseCheck = false;
                                    }
                                    else if (buyChoice == 2)
                                    {
                                        Console.WriteLine($"{playerT}구매를 취소하였습니다.\n");
                                        isPurchaseCheck = false;
                                    }
                                    else
                                    {
                                        Console.WriteLine($"{playerT}잘못누르셨습니다.");
                                        Console.Write($"{playerT} ");
                                    }
                                }

                            }
                        }
                        else { Console.WriteLine($"{playerT}잘못누르셨습니다."); }
                    }
                    else if(shopChoice==0)
                    {
                        isUsingShop = false;
                    }
                    else
                    {
                        Console.WriteLine($"{playerT}잘못누르셨습니다.");
                    }
                }
                Console.WriteLine($"{taptap}#건물에서 나왔다.");
            }
        }

    }
}
