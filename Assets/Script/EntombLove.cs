using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using Spine.Unity;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

/// <summary> 老虎机 </summary>
public class EntombLove : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("UpPos")]    public int GoTwo;
[UnityEngine.Serialization.FormerlySerializedAs("DownPos")]    public int TaleTwo;
[UnityEngine.Serialization.FormerlySerializedAs("SlotSprites")]    public Sprite[] LovePrimary;
[UnityEngine.Serialization.FormerlySerializedAs("RealItemParent")]    public Transform DragHomeBeluga;
    private List<List<Transform>> DragHumor;
    int[] DragWareImply= new int[3];
[UnityEngine.Serialization.FormerlySerializedAs("FakeItemsParent")]    public Transform GobiHumorBeluga;
    List<List<Transform>> GobiHumor;
    int[] GobiWareImply= new int[3];
    int GobiWareHim= 15;
    int HomeStun= 200;
    int Net= 400;
    int Expend= -400;
    bool OnLateral;
    bool OnLoveDay;
    int DaySwing;
[UnityEngine.Serialization.FormerlySerializedAs("RewardText")]    public Text UnlessDrug;
[UnityEngine.Serialization.FormerlySerializedAs("WinSpine")]    public SkeletonGraphic DayDouse;
    int PermToCompostBuy= 0;
[UnityEngine.Serialization.FormerlySerializedAs("WaitToTriggerNumText")]    public Text PermGoCompostBuyDrug;
[UnityEngine.Serialization.FormerlySerializedAs("TimeFill")]    public Image PestJune;


    void Start()
    {
        if (ColumnStud.OnDaily())
        {
            LovePrimary[1] = LovePrimary[4];
            LovePrimary[10] = LovePrimary[8];
        }

        if (DragHumor == null || DragHumor.Count == 0)
            Wine();

        UnlessDrug.text = "???";
        GelPermGoCompostBuyDrug();
        PestJune.transform.parent.gameObject.SetActive(false);
        PestJune.fillAmount = 0;
    }

    void Wine()
    {
        DragHumor = new List<List<Transform>>();
        for (int i = 0; i < 3; i++)
        {
            DragHumor.Add(new List<Transform>());
            for (int j = 0; j < 1; j++)
            {
                Transform Home = DragHomeBeluga.GetChild(i * 1 + j);
                GelLoveDarn(Home, 0);
                Home.gameObject.SetActive(false);
                Home.name = $"第{i + 1}列  第{j + 1}行";
                DragHumor[i].Add(Home);
            }
        }
        GobiHumor = new List<List<Transform>>();
        for (int i = 0; i < 3; i++)
        {
            GobiHumor.Add(new List<Transform>());
            for (int j = 0; j < 5; j++)
            {
                Transform Home = GobiHumorBeluga.GetChild(i * 5 + j);
                //int Index = UnityEngine.Random.Range(0, SlotSprites.Length);
                GelLoveDarn(Home, 0);
                Home.name = $"第{i + 1}列  第{j + 1}行";
                GobiHumor[i].Add(Home);
            }
        }
    }

    public void Love()
    {
        if (RoomCigar.Instance.OnWhaleTall)
            return;

        if (!OnLateral)
            ThornLove();
        else
        {
            PermToCompostBuy++;
            GelPermGoCompostBuyDrug();
        }
    }

    public void SewerageLove_PloyWhalePul()  // fever模式结束后继续 slot
    {
        if (PermToCompostBuy > 0)
            ThornLove();
    }

    void GelPermGoCompostBuyDrug()
    {
        if (PermToCompostBuy > 0)
        {
            PermGoCompostBuyDrug.text = PermToCompostBuy.ToString();
            if (RoomCigar.Instance.LieuUI.localPosition.x != -460)
                RoomCigar.Instance.LieuUI_Ford(true, false);
        }
        else
        {
            RoomCigar.Instance.LieuUI_Ford(false, false);
        }
    }

    void ThornLove()
    {
        ZJT_Manager.AshForecast().AddTaskValue("Slots", 1);
        OnLateral = true;
        PermToCompostBuy--;
        if (PermToCompostBuy < 0)
            PermToCompostBuy = 0;
        GelPermGoCompostBuyDrug();
        PestJune.DOFillAmount(1, .1f).SetEase(Ease.Linear);
        OnLoveDay = Random.value < GameConfig.Instance.SlotWinWeight;
        bool IsFirstSlot = CellIraqGrecian.GetBool("IsFirstSlot");
        if (!IsFirstSlot) //第一次必中奖
            OnLoveDay = true;
        int[] RealItemIndex = new int[3];
        if (OnLoveDay)
        {
            DaySwing = AshDaySwingDyRotate();
            if (!IsFirstSlot) //第一次中奖必是加球
            {
                DaySwing = 5;
                CellIraqGrecian.SetBool("IsFirstSlot", true);
            }
            if (ColumnStud.OnDaily())
            {
                DaySwing = 5;
            }
            for (int i = 0; i < 3; i++)
                RealItemIndex[i] = DaySwing;
        }
        else
        {
            DaySwing = -1;
            //生成3个不重复随机数
            List<int> RandomList = new List<int>();
            while (RandomList.Count < 3)
            {
                int RandomNum = Random.Range(0, LovePrimary.Length);
                if (!RandomList.Contains(RandomNum))
                    RandomList.Add(RandomNum);
            }
            for (int i = 0; i < 3; i++)
                RealItemIndex[i] = RandomList[i];
        }

        for (int i = 0; i < 3; i++)
        {
            DragWareImply[i] = 0;
            GobiWareImply[i] = 0;
            for (int j = 0; j < 5; j++)
            {
                if (Mathf.Abs(GobiHumor[i][j].transform.localPosition.y) < 10)
                    GobiHumor[i][j].transform.Find("Icon").GetComponent<Image>().sprite = DragHumor[i][0].Find("Icon").GetComponent<Image>().sprite;
                GobiHumor[i][j].Find("Icon").gameObject.SetActive(true);
            }
            int Index = i;
            PestGrecian.AshForecast().Novel(Index * .4f, () =>
            {
                GobiRotPosterShoe(Index, "开始");
                //ShootHue.GetInstance().PlayEffect(ShootMuch.UIMusic.slots_rotate);
            });
        }
        for (int i = 0; i < 3; i++)
        {
            Transform Home = DragHumor[i][0];
            GelLoveDarn(Home, RealItemIndex[i]);
            Home.gameObject.SetActive(false);
            Home.transform.localPosition = new Vector2(Home.transform.localPosition.x, HomeStun);
        }
        ShootHue.AshForecast().NormButton(ShootMuch.UIMusic.slots_rotate);
        SashNewlyBroker.AshForecast().VastNewly("1003", DaySwing.ToString());
    }

    void GelLoveDarn(Transform Home, int Index)
    {
        Home.Find("Icon").GetComponent<Image>().sprite = LovePrimary[Index];
        Home.Find("Icon").gameObject.SetActive(true);
    }

    void DragRotPosterShoe(int Index)
    {
        float AnimTime = 0.2f;
        Ease AnimEase = Ease.OutBack;
        for (int i = 0; i < 1; i++)
        {
            Transform Home = DragHumor[Index][i];
            Home.gameObject.SetActive(true);
            Home.transform.DOLocalMoveY(Home.transform.localPosition.y - HomeStun, AnimTime).SetEase(AnimEase).OnUpdate(() =>
            {
                for (int j = 0; j < 5; j++)
                {
                    Transform FakeItem = GobiHumor[Index][j];
                   // if (Mathf.Abs(Home.transform.position.y - FakeItem.transform.position.y) < 2f)
                        FakeItem.Find("Icon").gameObject.SetActive(false);
                }
            });
        }
        PestGrecian.AshForecast().Novel_SoloBeach(AnimTime, () =>
        {
            // if (Index == 0)
            //     ShootHue.GetInstance().PlayEffect(ShootMuch.UIMusic.Sound_High_Rate_3Slot);
            // else if (Index == 1)
            //     ShootHue.GetInstance().PlayEffect(ShootMuch.UIMusic.Sound_High_Rate_4Slot);
            // else if (Index == 2)
            //     ShootHue.GetInstance().PlayEffect(ShootMuch.UIMusic.Sound_High_Rate_5Slot);
            if (Index == 2)
                LoveFright();
        });
    }
    void GobiRotPosterShoe(int Index, string AnimType)
    {
        float AnimTime = 0;
        Ease AnimEase = Ease.Linear;
        if (AnimType == "开始")
        {
            AnimTime = 0.2f;
            AnimEase = Ease.InSine;
        }
        else if (AnimType == "持续")
        {
            AnimTime = 0.05f;
            AnimEase = Ease.Linear;
        }
        else if (AnimType == "结束")
        {
            AnimTime = 0.2f;
            AnimEase = Ease.OutBack;
        }
        for (int i = 0; i < 5; i++)
        {
            Transform Home = GobiHumor[Index][i];
            Home.transform.DOLocalMoveY(Home.transform.localPosition.y - HomeStun, AnimTime).SetEase(AnimEase);
        }
        PestGrecian.AshForecast().Novel(AnimTime, () =>
        {
            for (int i = 0; i < 5; i++)
            {
                Transform Home = GobiHumor[Index][i];
                if (Home.transform.localPosition.y < Expend)
                {
                    Home.transform.localPosition = new Vector2(Home.transform.localPosition.x, Net);
                    GelLoveDarn(Home, UnityEngine.Random.Range(0, LovePrimary.Length));
                    break;
                }
            }

            if (AnimType == "开始")
                GobiRotPosterShoe(Index, "持续");
            else if (AnimType == "持续")
            {
                GobiWareImply[Index]++;
                if (GobiWareImply[Index] < GobiWareHim)
                    GobiRotPosterShoe(Index, "持续");
                else
                    GobiRotPosterShoe(Index, "结束");

                if (GobiWareImply[Index] == GobiWareHim)
                    DragRotPosterShoe(Index);
            }
        });
    }

    // 0球变成弹力球  1区域变钻石  2翻倍*5  3翻倍*7  4翻倍*10  5落球*10  6落球*50  7落球*100  8物体变炸弹  9物体变分裂  10给钻石
    int AshDaySwingDyRotate()
    {
        //return 10;

        int[] DaySwing= new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        int[] Weights = new int[DaySwing.Length];
        for (int i = 0; i < DaySwing.Length; i++)
        {
            SlotsData Data = AshLoveIraqDySwing(i);
            Weights[i] = Data.weight;
            //print($"索引{i}  类型{data.type}  权重{data.weight}");
        }
        // 超过最大数量时概率修正
        int BombCount = RoomCigar.Instance.AshMuchBuyAnHumor(ItemType.Bomb);
        int SplitCount = RoomCigar.Instance.AshMuchBuyAnHumor(ItemType.Split);
        int BounceCount = RoomCigar.Instance.AshMuchBuyAnHumor(ItemType.Bounce);
        if (BombCount >= GameConfig.Instance.MaxNum_Bomb)
            Weights[7] = 0;
        if (SplitCount >= GameConfig.Instance.MaxNum_Split)
            Weights[8] = 0;
        if (BounceCount >= GameConfig.Instance.MaxNum_Bounce)
            Weights[9] = 0;

        int Sum = 0;
        for (int i = 0; i < DaySwing.Length; i++)
            Sum += Weights[i];
        int RandomNum = Random.Range(0, Sum);
        for (int i = 0; i < DaySwing.Length; i++)
        {
            RandomNum -= Weights[i];
            if (RandomNum < 0)
                return DaySwing[i];
        }
        return 0;
    }
    SlotsData AshLoveIraqDySwing(int Index) // 根据索引获取slot数据 
    {
        switch (Index)
        {
            case 0: return WedSoulHue.Instance._RoomIraq.slots_list.FirstOrDefault(x => x.type == "bounce_wall"); // 球变成弹力球
            case 1: return WedSoulHue.Instance._RoomIraq.slots_list.FirstOrDefault(x => x.type == "add_diamond"); // 区域变钻石
            case 2: return WedSoulHue.Instance._RoomIraq.slots_list.FirstOrDefault(x => x.type == "split_mutli_few"); // 翻倍*5
            case 3: return WedSoulHue.Instance._RoomIraq.slots_list.FirstOrDefault(x => x.type == "split_mutli_standard"); // 翻倍*7
            case 4: return WedSoulHue.Instance._RoomIraq.slots_list.FirstOrDefault(x => x.type == "split_mutli_more"); // 翻倍*10
            case 5: return WedSoulHue.Instance._RoomIraq.slots_list.FirstOrDefault(x => x.type == "fallball_few"); // 落球*10
            case 6: return WedSoulHue.Instance._RoomIraq.slots_list.FirstOrDefault(x => x.type == "fallball_standard"); // 落球*50
            case 7: return WedSoulHue.Instance._RoomIraq.slots_list.FirstOrDefault(x => x.type == "fallball_more"); // 落球*100
            case 8: return WedSoulHue.Instance._RoomIraq.slots_list.FirstOrDefault(x => x.type == "add_boom"); // 物体变炸弹
            case 9: return WedSoulHue.Instance._RoomIraq.slots_list.FirstOrDefault(x => x.type == "add_split_ball"); // 物体变弹性
            case 10: return WedSoulHue.Instance._RoomIraq.slots_list.FirstOrDefault(x => x.type == "diamond_value_up"); // 给钻石
        }
        Debug.LogError($"Slot对应数据没有找到 Index:{Index} ");
        SlotsData Empty = new SlotsData
        {
            type = "Null",
            weight = 0,
            value = 0,
        };
        return Empty;
    }

    void LoveFright()
    {
        if (DaySwing == -1)
        {
            print("老虎机 没中奖");
            ShootHue.AshForecast().NormButton(ShootMuch.UIMusic.regret);
            Deep(.1f);
            return;
        }
        DayDouse.gameObject.SetActive(true);
        PestJune.transform.parent.gameObject.SetActive(true);
        ShootHue.AshForecast().NormButton(ShootMuch.UIMusic.slots_win);
        SlotsData Data = AshLoveIraqDySwing(DaySwing);
        if (DaySwing == 0)
        {
            UnlessDrug.text = "球变成弹力球";
            Deep((int)Data.value);
            RoomCigar.Instance.Hole_UsefulBackup((int)Data.value);
            //RoomCigar.Instance.Wall_BecomeBounce((int)Data.value);
        }
        else if (DaySwing == 1)
        {
            UnlessDrug.text = "区域变钻石";
            int AreaIndex = Random.Range(0, 3);
            int[] ItemIndex = null;
            if (AreaIndex == 0)
                ItemIndex = new int[20] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19 };
            else if (AreaIndex == 1)
                ItemIndex = new int[19] { 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38 };
            else if (AreaIndex == 2)
                ItemIndex = new int[] { 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55 };
            UnlessDrug.text = $"区域{AreaIndex + 1}全部变钻石";
            Deep(.1f * ItemIndex.Length);
            RoomCigar.Instance.Home_UsefulMagenta(ItemIndex);
        }
        else if (DaySwing == 2)
        {
            UnlessDrug.text = "翻倍*5";
            UnlessDrug.text = "翻倍机加倍率";
            Deep(10);
            RoomCigar.Instance.GelDose_CargoMuchByEnzymeSymptom(SlotBuffType.DoubleMachine_Multi, (int)Data.value);
        }
        else if (DaySwing == 3)
        {
            UnlessDrug.text = "翻倍*7";
            UnlessDrug.text = "翻倍机加倍率";
            Deep(10);
            RoomCigar.Instance.GelDose_CargoMuchByEnzymeSymptom(SlotBuffType.DoubleMachine_Multi, (int)Data.value);
        }
        else if (DaySwing == 4)
        {
            UnlessDrug.text = "翻倍*10";
            UnlessDrug.text = "翻倍机加倍率";
            Deep(10);
            RoomCigar.Instance.GelDose_CargoMuchByEnzymeSymptom(SlotBuffType.DoubleMachine_Multi, (int)Data.value);
        }
        else if (DaySwing == 5)
        {
            UnlessDrug.text = "落球*10";
            Deep((float)(1.5f + ((int)Data.value * 0.1f)));
            RoomCigar.Instance.TopiHole((int)Data.value);
        }
        else if (DaySwing == 6)
        {
            UnlessDrug.text = "落球*50";
            Deep((float)(1.5f + ((int)Data.value * 0.1f)));
            RoomCigar.Instance.TopiHole((int)Data.value);
        }
        else if (DaySwing == 7)
        {
            UnlessDrug.text = "落球*100";
            Deep((float)(1.5f + ((int)Data.value * 0.1f)));
            RoomCigar.Instance.TopiHole((int)Data.value);
        }
        else if (DaySwing == 8)
        {
            UnlessDrug.text = "物体变炸弹";
            int AreaIndex = Random.Range(0, 5);
            int[] ItemIndex = null;
            if (AreaIndex == 0)
                ItemIndex = new int[] { 7, 9, 11 };
            else if (AreaIndex == 1)
                ItemIndex = new int[] { 8, 10, 12 };
            else if (AreaIndex == 2)
                ItemIndex = new int[] { 27, 29, 31 };
            else if (AreaIndex == 3)
                ItemIndex = new int[] { 44, 51 };
            else if (AreaIndex == 4)
                ItemIndex = new int[] { 43, 52 };
            Deep(.2f * ItemIndex.Length);
            RoomCigar.Instance.Home_UsefulRoam(ItemIndex);
        }
        else if (DaySwing == 9)
        {
            UnlessDrug.text = "物体变分裂";
            int RandomIndex = Random.Range(0, 3);
            int[] ItemIndex = new int[] { 0, 1, 2, 3, 4, 5, 6 };
            if (RandomIndex == 1)
                ItemIndex = new int[] { 7, 8, 9, 10, 11, 12 };
            else if (RandomIndex == 2)
                ItemIndex = new int[] { 13, 14, 15, 16, 17, 18, 19 };
            Deep(.2f * (int)Data.value);
            RoomCigar.Instance.Home_UsefulNovel(ItemIndex);
        }
        else if (DaySwing == 10)
        {
            UnlessDrug.text = "物体变大钻石";
            int BigDiamondNum = RoomCigar.Instance.Home_UsefulBatMagenta();
            Deep(.2f * BigDiamondNum);
        }

        print("老虎机奖励： " + UnlessDrug.text);
    }

    public void Deep(float Delay = 0) //隐藏 （由奖励界面关闭回调调用）
    {
        PestJune.DOFillAmount(0, Delay).SetEase(Ease.Linear);
        PestGrecian.AshForecast().Novel_SoloBeach(Delay, () =>
        {
            OnLateral = false;
            PestJune.transform.parent.gameObject.SetActive(false);
            DayDouse.gameObject.SetActive(false);
            RoomCigar.Instance.LoveFright();
            if (!RoomCigar.Instance.OnWhaleTall && PermToCompostBuy > 0)
                PestGrecian.AshForecast().Novel_SoloBeach(1, () => ThornLove());
        });
    }

}
