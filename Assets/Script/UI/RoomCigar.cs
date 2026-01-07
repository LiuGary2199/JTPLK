using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Coffee.UIExtensions;
using DG.Tweening;
using Spine;
using Spine.Unity;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RoomCigar : SakeUIDaddy
{
    public static RoomCigar Instance;
    Camera _Weight;

    [Header("UI")]
[UnityEngine.Serialization.FormerlySerializedAs("Bg")]    public Image He;
[UnityEngine.Serialization.FormerlySerializedAs("GameZone")]    public Transform RoomWake;
[UnityEngine.Serialization.FormerlySerializedAs("SetBtn")]    public Button GelPig;
    [HideInInspector] [UnityEngine.Serialization.FormerlySerializedAs("CoinNum")]public int CapeBuy;
    [HideInInspector] [UnityEngine.Serialization.FormerlySerializedAs("CashNum")]public float MothBuy;
[UnityEngine.Serialization.FormerlySerializedAs("CoinIcon")]
    public Transform CapeDarn;
[UnityEngine.Serialization.FormerlySerializedAs("CoinText")]    public Text CapeDrug;
[UnityEngine.Serialization.FormerlySerializedAs("CashText")]    public Text MothDrug;
[UnityEngine.Serialization.FormerlySerializedAs("_CashOutEnter")]    public Transform _MothDewFiord; //TODO假提现 可能需要替换的
[UnityEngine.Serialization.FormerlySerializedAs("CashFlyPos")]    public Transform MothBoyTwo;
[UnityEngine.Serialization.FormerlySerializedAs("TopSpine")]    public SkeletonGraphic NetDouse;
[UnityEngine.Serialization.FormerlySerializedAs("TransitionSpine")]    public SkeletonGraphic PolychromeDouse; // 转场动画spine
[UnityEngine.Serialization.FormerlySerializedAs("_FlyBubble")]    public BoySatire _BoySatire;
    int BoySatireTenet;
[UnityEngine.Serialization.FormerlySerializedAs("WheelItemSpine")]    public SkeletonGraphic TingeHomeDouse;
[UnityEngine.Serialization.FormerlySerializedAs("TempMoneyBG")]    public Transform SaltSteepBG;
[UnityEngine.Serialization.FormerlySerializedAs("TempMoneyText")]    public Text SaltSteepDrug;
[UnityEngine.Serialization.FormerlySerializedAs("TempDiamondText")]    public Text SaltMagentaDrug;
[UnityEngine.Serialization.FormerlySerializedAs("SideUI")]    public Transform LieuUI; // 侧边UI
[UnityEngine.Serialization.FormerlySerializedAs("m_CashBtn")]    public Button m_MothPig;
[UnityEngine.Serialization.FormerlySerializedAs("cashitrmObj")]
    public GameObject BirthdayDig;
[UnityEngine.Serialization.FormerlySerializedAs("jindu1rect")]    public RectTransform Horde1Rest;
[UnityEngine.Serialization.FormerlySerializedAs("jindu2rect")]   public RectTransform Horde2Rest;
[UnityEngine.Serialization.FormerlySerializedAs("jindu3rect")]    public RectTransform Horde3Rest;
[UnityEngine.Serialization.FormerlySerializedAs("jindu4rect")]    public RectTransform Horde4Rest;
[UnityEngine.Serialization.FormerlySerializedAs("Coinobj")]    public GameObject Various;
[UnityEngine.Serialization.FormerlySerializedAs("Cashobj")]    public GameObject Rebirth;
[UnityEngine.Serialization.FormerlySerializedAs("bottom")]
    public Transform Spread;
[UnityEngine.Serialization.FormerlySerializedAs("MiddleTransParent")]    public Transform LinearUpsetBeluga;
[UnityEngine.Serialization.FormerlySerializedAs("bottomTransParent")]    public Transform SpreadUpsetBeluga;
    public Transform bottomZhiyin;

    [Header("点击掉球")]
[UnityEngine.Serialization.FormerlySerializedAs("DropBallTrigger")]    public EventTrigger SwimHoleCompost;
[UnityEngine.Serialization.FormerlySerializedAs("BallBornPos")]    public Transform HoleFrayTwo;
    float SwellSwimHoleAnd;
    bool BlissOnLoss;
    float LossSwimHoleAnd;
[UnityEngine.Serialization.FormerlySerializedAs("BallParent")]    public Transform HoleBeluga;
    int HoleBuy;
[UnityEngine.Serialization.FormerlySerializedAs("BallNumText")]    public Text HoleBuyDrug;
    //public Text BuyBallPriceText;
    int HoleAdaptiveTenet;
[UnityEngine.Serialization.FormerlySerializedAs("BallRecoveryTimeText")]    public Text HoleAdaptivePestDrug;
[UnityEngine.Serialization.FormerlySerializedAs("ItemParten")]    public Transform HomeRegain;
    List<Home> Humor= new List<Home>();
    List<Home> ReleaseHumor= new List<Home>(); //记录特殊物品 切换游戏模式时记录 切回来恢复
    List<ItemType> ReleaseHomeEntry= new List<ItemType>(); //记录特殊物品类型 切换游戏模式时记录 切回来恢复
    int Newly_SwimHoleImply;

    [Header("疯狂模式")]
[UnityEngine.Serialization.FormerlySerializedAs("FeverNumImage")]    public Image WhaleBuyStorm; // 疯狂模式计数进度条
    int WhaleBuy;  // 疯狂模式计数
    int HoleBuy_AnWhaleTall; // 疯狂模式中的球数量
[UnityEngine.Serialization.FormerlySerializedAs("BallNum_InFever_Icon")]    public GameObject HoleBuy_AnWhale_Darn;
    [HideInInspector] [UnityEngine.Serialization.FormerlySerializedAs("IsFeverMode")]public bool OnWhaleTall; // 是否处于疯狂模式
    float WhaleTenet; // 疯狂模式持续时间
[UnityEngine.Serialization.FormerlySerializedAs("FeverItemParent")]    public Transform WhaleHomeBeluga;
[UnityEngine.Serialization.FormerlySerializedAs("Lines")]    public List<HomeJazzMime> Cargo= new List<HomeJazzMime>();
[UnityEngine.Serialization.FormerlySerializedAs("Fever_NeedHide")]    public GameObject[] Whale_PeepDeep; // 疯狂模式需要隐藏的物体
[UnityEngine.Serialization.FormerlySerializedAs("Fever_NeedShow")]    public GameObject[] Whale_PeepEven; // 疯狂模式需要显示的物体
[UnityEngine.Serialization.FormerlySerializedAs("FeverChest")]    public Transform WhaleAngle;
[UnityEngine.Serialization.FormerlySerializedAs("FeverChestSpine")]    public SkeletonGraphic WhaleAngleDouse;
[UnityEngine.Serialization.FormerlySerializedAs("FeverChestRewardEffect")]    public UIParticle WhaleAngleUnlessButton;
    public UIParticle CoinBoom;
    int WhaleAngleBuy; // 疯狂模式宝箱开启需要击打次数
[UnityEngine.Serialization.FormerlySerializedAs("FeverChestNumText")]    public Text WhaleAngleBuyDrug; // 疯狂模式宝箱开启需要击打次数文字
    float WagonMagentaBuyAnWhaleTall; // 疯狂模式获得的钻石数量
[UnityEngine.Serialization.FormerlySerializedAs("GetedDiamondNumInFeverModeText")]    public Text WagonMagentaBuyAnWhaleTallDrug; // 疯狂模式获得的钻石数量文字
[UnityEngine.Serialization.FormerlySerializedAs("EnterFeverSpine")]    public SkeletonGraphic FiordWhaleDouse;
[UnityEngine.Serialization.FormerlySerializedAs("EnterFeverGO1")]    public Transform FiordWhaleGO1;
[UnityEngine.Serialization.FormerlySerializedAs("EnterFeverGO1_Lights")]    public Image[] FiordWhaleGO1_Teapot;
[UnityEngine.Serialization.FormerlySerializedAs("EnterFeverGO2")]    public Transform FiordWhaleGO2;
[UnityEngine.Serialization.FormerlySerializedAs("EnterFeverEffect")]    public UIParticle FiordWhaleButton;
[UnityEngine.Serialization.FormerlySerializedAs("FeverSpine")]    public SkeletonGraphic WhaleDouse;
[UnityEngine.Serialization.FormerlySerializedAs("FeverSpineheng")]    public SkeletonGraphic WhaleLegendary;
[UnityEngine.Serialization.FormerlySerializedAs("Lights1")]
    public Image[] Teapot1; //灯光效果
[UnityEngine.Serialization.FormerlySerializedAs("Lights2")]    public Image[] Teapot2; //灯光效果
[UnityEngine.Serialization.FormerlySerializedAs("FeveLightAnim")]    public Animator HomoPlaceShoe;
[UnityEngine.Serialization.FormerlySerializedAs("FeverSpineEnter")]    public SkeletonGraphic WhaleDouseFiord;
    [Header("底部收集器/老虎机/开启翻倍机")]
[UnityEngine.Serialization.FormerlySerializedAs("UnderCollecters")]    public Circulate[] AsideEvanescent; //底部收集器
[UnityEngine.Serialization.FormerlySerializedAs("SlotMachine")]    public EntombLove LoveSymptom; // 老虎机
[UnityEngine.Serialization.FormerlySerializedAs("SlotMachine_AutoFallBallEffect")]    public UIParticle LoveSymptom_LinkTopiHoleButton;

    [Header("翻倍机")]
[UnityEngine.Serialization.FormerlySerializedAs("_DoubleMachine")]    public EnzymeSymptom _EnzymeSymptom;
    int EnzymeSymptom_IgneousTenet;

    [Header("收集物")]
[UnityEngine.Serialization.FormerlySerializedAs("CollectASigns")]    public GameObject[] MethaneAEthic; // 收集标志
[UnityEngine.Serialization.FormerlySerializedAs("CollectBSigns")]    public GameObject[] MethaneBEthic; // 收集标志
[UnityEngine.Serialization.FormerlySerializedAs("CollectASignEffects")]    public UIParticle[] MethaneAItemFiction;
[UnityEngine.Serialization.FormerlySerializedAs("CollectBSignEffects")]    public UIParticle[] MethaneBItemFiction;
[UnityEngine.Serialization.FormerlySerializedAs("CollectAOkSigns")]    public UIParticle[] MethaneAIfEthic; // 收集成功标志
[UnityEngine.Serialization.FormerlySerializedAs("CollectBOkSigns")]    public UIParticle[] MethaneBIfEthic; // 收集成功标志
    int[] MethaneBuy= new int[3]; // 各类物品收集数量
    int MethaneA_Tenet; // 收集物A出现计时
    int MethaneB_Tenet; // 收集物B出现计时
    float[] Methane_UnlessNine= new float[2]; // 收集物奖励数值
[UnityEngine.Serialization.FormerlySerializedAs("Collect_RewardTexts")]    public Text[] Methane_UnlessFaith; // 收集物奖励文字
    int Tinge_Tenet; //转盘出现计时
    public GameObject cashimg1;
    public GameObject cashimg2;

    [Header("黑洞")]
[UnityEngine.Serialization.FormerlySerializedAs("BlockHole")]    public GameObject BlockHole;
    int RoundMuchBuy; // 黑洞收集到小球数量
[UnityEngine.Serialization.FormerlySerializedAs("BlackHoleNumText")]    public Text RoundMuchBuyDrug; // 黑洞数字
[UnityEngine.Serialization.FormerlySerializedAs("BlockHoleWallParent")]    public Transform CargoMuchSoupBeluga; //黑洞外墙父物体
[UnityEngine.Serialization.FormerlySerializedAs("BlockHoleWall1")]    public Transform CargoMuchSoup1; //黑洞外墙
[UnityEngine.Serialization.FormerlySerializedAs("BlockHoleWall2")]    public Transform CargoMuchSoup2; //黑洞外墙
[UnityEngine.Serialization.FormerlySerializedAs("BlockAddBallEffect")]    public UIParticle CargoPitHoleButton;

    [Header("Buff")]
[UnityEngine.Serialization.FormerlySerializedAs("BounceWallOutline")]    public DrugBenefit[] BackupSoupBenefit; //弹力墙外描边
[UnityEngine.Serialization.FormerlySerializedAs("Wall_PhysicsMaterial")]    public PhysicsMaterial2D Soup_TypicalRotation; //墙物理材质
    bool Dose_Soup_Backup; // 是否有变弹力墙事件
    int Dose_Soup_Backup_Tenet; // 变弹力墙事件
    bool Dose_EnzymeSymptom_Finch; // 乘倍
    int Dose_EnzymeSymptom_Finch_Tenet;
    bool Dose_EnzymeSymptom_Injury;
    float Dose_EnzymeSymptom_Injury_Tenet;
    bool Dose_EnzymeSymptom_Akin;
    float Dose_EnzymeSymptom_Akin_Tenet;
    bool Dose_BackupHole;
    int Dose_BackupHole_Tenet;
    List<Coroutine> TopiHoleIndividual= new List<Coroutine>(); // 记录所有掉球协程

    [HideInInspector] [UnityEngine.Serialization.FormerlySerializedAs("_GuidePanel")]public ReactCigar _ReactCigar;

    //测试模式
    float Gain_LinkSwimHoleTenet;
    int Gain_SwimHoleBuy;
    int Gain_AnCargoBuy;



    private void OnApplicationPause(bool pause)
    {
        if (GameConfig.Instance.BallNumRecoveryTime > 0 && !pause && Time.time > 30)
            PitHole_Restful();
    }

    void Start()
    {
        Instance = this;
        ZJT_Manager.AshForecast().AfterReduceMoneyAction += Newly1;
        ZJT_Manager.AshForecast().AfterReduceMoneyAction += Newly2;
        _Weight = Camera.main;
        BoySatireTenet = WedSoulHue.Instance._RoomIraq.fly_bubble.cold_down;
        PolychromeDouse.transform.SetParent(UIGrecian.AshForecast()._Net);
        GelPig.onClick.AddListener(() =>
        {
            if (PestGrecian.AshForecast().OnBeach)
                return;
            ShootHue.AshForecast().NormButton(ShootMuch.UIMusic.click);
            RoomBeach();
            AnewUIPure(nameof(PavlovaCigar));
        });
        m_MothPig.onClick.AddListener(() =>
        {
            if (PestGrecian.AshForecast().OnBeach)
                return;
            ShootHue.AshForecast().NormButton(ShootMuch.UIMusic.click);
            RoomBeach();
            if (RoomCigar.Instance._ReactCigar != null)
                RoomCigar.Instance._ReactCigar.Deep(false);
            UIGrecian.AshForecast().EvenUIDaddy(nameof(JT_CashOutPanel));
        });
        //CapeBuy = CellIraqGrecian.GetInt("CoinNum");
        CapeBuy =(int) ZJT_Manager.AshForecast().GetMoney("JT_Money2");
        CapeDrug.text = CapeBuy.ToString();

        MothBuy = ZJT_Manager.AshForecast().GetMoney();
        MothDrug.text = MothBuy.ToString("F1");

        //掉球按钮EventTrigger添加事件
        EventTrigger.Entry entry = new EventTrigger.Entry { eventID = EventTriggerType.PointerDown };
        entry.callback.AddListener(data => SwellSkySwimHole((PointerEventData)data));
        SwimHoleCompost.triggers.Add(entry);
        entry = new EventTrigger.Entry { eventID = EventTriggerType.PointerUp };
        entry.callback.AddListener(data => BlissGo((PointerEventData)data));
        SwimHoleCompost.triggers.Add(entry);

        HoleFrayTwo.gameObject.SetActive(false);
        if (!PlayerPrefs.HasKey("BallNum"))
            HoleBuy = GameConfig.Instance.FirstBallNum;
        else
            HoleBuy = CellIraqGrecian.GetInt("BallNum");
        HoleBuyDrug.text = HoleBuy.ToString();
        //BuyBallPriceText.text = GameConfig.Instance.BuyBallPrice.ToString();
        //BallNumText.gameObject.SetActive(BallNum > 0);
        //BuyBallPriceText.gameObject.SetActive(BallNum <= 0);
        if (GameConfig.Instance.BallNumRecoveryTime > 0)
        {
            HoleAdaptiveTenet = GameConfig.Instance.BallNumRecoveryTime;
            PitHole_Restful();
        }

        WhaleBuy = 0;
        WhaleBuyStorm.fillAmount = 0;
        PlaceShoe();
        LieuUI.localPosition = new Vector2(-700, LieuUI.localPosition.y);

        Tinge_Tenet = GameConfig.Instance.ActiveTime_Wheel;

        _EnzymeSymptom.Wine(true, GameConfig.Instance.DoubleMachineDefaultMulti, GameConfig.Instance.DoubleMachineAnimTime, HoleBeluga, true);
        EnzymeSymptom_IgneousTenet = GameConfig.Instance.DoubleMachineDefaultTime;

        // if (PlayerPrefs.HasKey("BlackHoleNum"))
        //     BlackHoleNum = CellIraqGrecian.GetInt("BlackHoleNum");
        // else
        //     BlackHoleNum = GameConfig.Instance.BlockHoleTarget;
        RoundMuchBuyDrug.text = RoundMuchBuy.ToString();
        CargoSoupShoe();

        Humor = HomeRegain.GetComponentsInChildren<Home>().ToList();
        HumorIgneousWine();
        for (int i = 0; i < Humor.Count; i++)
            Humor[i].transform.name = i.ToString();

        Methane_UnlessNine[0] = GameConfig.Instance.CountReward(RewardType.Diamond, WedSoulHue.Instance._RoomIraq.collect_A_count, false);
        Methane_UnlessNine[1] = GameConfig.Instance.CountReward(RewardType.Diamond, WedSoulHue.Instance._RoomIraq.collect_B_count, false);
        for (int i = 0; i < Methane_UnlessFaith.Length; i++)
            Methane_UnlessFaith[i].text = Methane_UnlessNine[i].ToString();
        MethaneBuy[0] = PlayerPrefs.HasKey("CollectNum_A") ? CellIraqGrecian.GetInt("CollectNum_A") : 0;
        if (MethaneBuy[0] >= 3)
            MethaneBuy[0] = 2;
        for (int i = 0; i < MethaneBuy[0]; i++)
            MethaneAEthic[i].gameObject.SetActive(true);
        MethaneBuy[1] = PlayerPrefs.HasKey("CollectNum_B") ? CellIraqGrecian.GetInt("CollectNum_B") : 0;
        if (MethaneBuy[1] >= 4)
            MethaneBuy[1] = 3;
        for (int i = 0; i < MethaneBuy[1]; i++)
            MethaneBEthic[i].gameObject.SetActive(true);

        PestGrecian.AshForecast().Minute_SoloBeach(1, 1, () => { PestImply(); });
        if (ColumnStud.OnDaily())
        {
            Horde4Rest.anchoredPosition = new Vector2(Horde4Rest.anchoredPosition.x, 718.2f);
            BirthdayDig.SetActive(false);
        }
        //UI适配
        bool IsLongScreen = ((float)Screen.height / (float)Screen.width) >= 2f;
        if (!IsLongScreen)
        {

            RoomWake.localPosition = new Vector2(0, -200);
            //  _CashOutEnter.transform.parent.localScale = Vector3.one * .8f;
            //  _CashOutEnter.transform.parent.localPosition = new Vector2(0, -741);
            //   SetBtn.transform.localPosition = new Vector2(-432, 694);
         //   TempMoneyBG.localPosition = new Vector2(0, -730);
        }
        else {
            Horde1Rest.anchoredPosition = new Vector2(Horde1Rest.anchoredPosition.x, Horde1Rest.anchoredPosition.y - 40);
         //   jindu2rect.anchoredPosition = new Vector2(jindu2rect.anchoredPosition.x, jindu2rect.anchoredPosition.y - 40);
          //  jindu3rect.anchoredPosition = new Vector2(jindu3rect.anchoredPosition.x, jindu3rect.anchoredPosition.y - 40);
        }


        if (ColumnStud.OnDaily())
        {
            cashimg1.SetActive(false);
            cashimg2.SetActive(false);
            _MothDewFiord.transform.parent.gameObject.SetActive(false);
       //     TempMoneyBG.gameObject.SetActive(true);
            SaltPitSteep(0);
            SaltPitMagenta(0);

            bool IsGuideCashOut = CellIraqGrecian.GetBool("IsGuideCashOut");
            if (!IsGuideCashOut)
            {
                RoomBeach();
                PestGrecian.AshForecast().Novel(1, () =>
                {
                    _ReactCigar = AnewUIPure(nameof(ReactCigar)).GetComponent<ReactCigar>();
                    React2();
                    CellIraqGrecian.SetBool("IsGuideCashOut", true);
                });
            }
        }
        else
        {
            SaltSteepBG.gameObject.SetActive(false);
            bool IsGuideCashOut = CellIraqGrecian.GetBool("IsGuideCashOut");
            if (!IsGuideCashOut)
            {
                RoomBeach();
                PestGrecian.AshForecast().Novel(1, () =>
                {
                    React1();
                    //Guide2();
                    CellIraqGrecian.SetBool("IsGuideCashOut", true);
                });
            }
        }
        if (ColumnStud.OnDaily())
        {
            Various.SetActive(true);
            Rebirth.SetActive(false);
        }
        else
        {
            Various.SetActive(false);
            Rebirth.SetActive(true);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            UIGrecian.AshForecast().EvenUIDaddy(nameof(JT_CashOutPanel));
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            (AnewUIPure(nameof(BatDayCigar)) as BatDayCigar).Wine(100f, () =>
            {
            });
        }


        //按住持续扔球
        if (Input.GetMouseButton(0))
        {
            if (BlissOnLoss
            && GameConfig.Instance.IsHoldDropBall
            && HoleBuy > 0
            && GameConfig.Instance.IsHoldDropBall
            && !PestGrecian.AshForecast().OnBeach)
            {
                LossSwimHoleAnd += Time.deltaTime;
                if (LossSwimHoleAnd >= GameConfig.Instance.HoldDropBallGap)
                    SwellSkySwimHole();
            }
        }
        SwellSwimHoleAnd += Time.deltaTime;



        //测试
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (PestGrecian.AshForecast().OnBeach)
                RoomBeach(false);
            else
                RoomBeach();
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            if (Random.value < .5f)
                VisualizeConformity.AshSoonAiryShoe(100);
            else
                VisualizeConformity.AshSoonMagentaShoe(100);
        }
        else if (Input.GetKeyDown(KeyCode.T))
        {
            CompostLove();
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            RoomBeach();
            UIGrecian.AshForecast().EvenUIDaddy(nameof(TingeCigar));
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            MethanePit(Random.value < .5f ? ItemType.CollectA : ItemType.CollectB, Vector2.zero);
        }
        else if (Input.GetKey(KeyCode.F))
        {
            WhalePit();
        }
        else if (Input.GetKey(KeyCode.B))
        {
            if (RoundMuchBuy > 0)
                CargoMuchPit();
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            // 开启新机台
            foreach (Transform child in HoleBeluga)
            {
                if (child.gameObject.activeSelf)
                {
                    ObjectPool.Instance.Return("球", child.gameObject);
                }
            }
            _EnzymeSymptom.BreedPermFray();
            HardenReleaseHome();
            Polychrome(() =>
            {
                WispyUIPure(nameof(RoomCigar));
                (AnewUIPure(nameof(SwimHoleRoomCigar)) as SwimHoleRoomCigar).Wine();
                RoundMuchBuy = GameConfig.Instance.BlockHoleTarget;
                RoundMuchBuyDrug.text = RoundMuchBuy.ToString();
            });
        }
        if (GameConfig.Instance.TestMode)
        {
            Gain_LinkSwimHoleTenet += Time.deltaTime;
            if (Gain_LinkSwimHoleTenet >= GameConfig.Instance.ClickDropBallGap)
            {
                Gain_LinkSwimHoleTenet = 0;
                Gain_SwimHoleBuy++;

                HoleFrayTwo.position = new Vector2(Random.Range(-1.8f, 1.8f), HoleFrayTwo.position.y);
                GameObject NewBall = ObjectPool.Instance.Get("球");
                NewBall.transform.SetParent(HoleBeluga);
                NewBall.transform.localScale = Vector3.one;
                NewBall.transform.position = HoleFrayTwo.position;
                BlissOnLoss = true;
                LossSwimHoleAnd = 0;
                ShootHue.AshForecast().NormButton(ShootMuch.UIMusic.drop_ball);
                if (Dose_BackupHole)
                    NewBall.GetComponent<Hole>().GelBackup();
            }
        }
    }

    void HumorIgneousWine()  // 物品默认初始化
    {
        ItemType itemType = ItemType.Diamond;
        if (ColumnStud.OnDaily())
        {
            itemType = ItemType.Coin;
        }
        for (int i = 0; i < Humor.Count; i++)
        {
            if ((i >= 7) && (i <= 12) || (i >= 20) && (i <= 25) || (i >= 33) && (i <= 38))
                Humor[i].Wine(itemType);
            else
                Humor[i].Wine(ItemType.Coin);
        }
    }

    void HardenReleaseHome() // 记录特殊物品
    {
        for (int i = 0; i < Humor.Count; i++)
        {
            if (Humor[i].Much == ItemType.Bomb
            || Humor[i].Much == ItemType.Split
            || Humor[i].Much == ItemType.Wheel
            || Humor[i].Much == ItemType.CollectA
            || Humor[i].Much == ItemType.CollectB)
            {
                ReleaseHumor.Add(Humor[i]);
                ReleaseHomeEntry.Add(Humor[i].Much);
            }
        }
    }
    public void SwissReleaseHome() // 重置特殊物品
    {
        for (int i = 0; i < ReleaseHumor.Count; i++)
            ReleaseHumor[i].Wine(ReleaseHomeEntry[i]);
        ReleaseHumor.Clear();
        ReleaseHomeEntry.Clear();
    }

    void PestImply() //自定义计时器 每秒一次 受TimeManager的IsPause影响
    {
        // 根据时间恢复球数量
        if (GameConfig.Instance.BallNumRecoveryTime > 0)
        {
            if (HoleBuy < GameConfig.Instance.FirstBallNum)
            {
                HoleAdaptiveTenet--;
                HoleAdaptivePestDrug.text = HoleAdaptiveTenet + "s";
                if (HoleAdaptiveTenet <= 0)
                {
                    HoleBuy++;
                    HoleAdaptiveTenet = GameConfig.Instance.BallNumRecoveryTime;
                    CellIraqGrecian.SetInt("BallNum", HoleBuy);
                    if (!OnWhaleTall)
                        HoleBuyDrug.text = HoleBuy.ToString();
                }
            }
            else
                HoleAdaptivePestDrug.text = "";
            if (OnWhaleTall)
                HoleAdaptivePestDrug.text = "";
        }

        // 收集物计时
        int CollectA_Num = AshMuchBuyAnHumor(ItemType.CollectA);
        int CollectB_Num = AshMuchBuyAnHumor(ItemType.CollectB);
        int Wheel_Num = AshMuchBuyAnHumor(ItemType.Wheel);
        bool CollectAmostFull = (MethaneBuy[0] == 2 || MethaneBuy[1] == 3);
        bool SpecialItemOverOne = (CollectA_Num + CollectB_Num + Wheel_Num) >= 1;
        bool CanShow = true;
        if (CollectAmostFull && SpecialItemOverOne)
            CanShow = false;

        if (!OnWhaleTall)
        {
            if (CollectA_Num >= GameConfig.Instance.MaxNum_CollectA)
                MethaneA_Tenet = 0;
            else
                MethaneA_Tenet++;
            if (MethaneA_Tenet >= GameConfig.Instance.ActiveTime_CollectA)
            {
                MethaneA_Tenet = 0;
                if (CanShow && CollectA_Num < GameConfig.Instance.MaxNum_CollectA)
                {
                    var TempItems = Humor.FindAll(item => item.Much == ItemType.Empty && (GameConfig.Instance.CollectA_Pos.Contains(item.transform.parent.name) || GameConfig.Instance.CollectA_Pos.Contains(item.transform.parent.parent.name))).OrderBy(item => Random.Range(0, 100)).ToList();
                    if (TempItems != null && TempItems.Count > 0)
                    {
                        TempItems[0].Wine(ItemType.CollectA);
                        TempItems[0].NormCrystalButton();
                    }
                }
            }

            if (CollectB_Num >= GameConfig.Instance.MaxNum_CollectB)
                MethaneB_Tenet = 0;
            else
                MethaneB_Tenet++;
            if (MethaneB_Tenet >= GameConfig.Instance.ActiveTime_CollectB)
            {
                MethaneB_Tenet = 0;
                if (CanShow && CollectB_Num < GameConfig.Instance.MaxNum_CollectB)
                {
                    var TempItems = Humor.FindAll(item => item.Much == ItemType.Empty && (GameConfig.Instance.CollectB_Pos.Contains(item.transform.parent.name) || GameConfig.Instance.CollectB_Pos.Contains(item.transform.parent.parent.name))).OrderBy(item => Random.Range(0, 100)).ToList();
                    if (TempItems != null && TempItems.Count > 0)
                    {
                        TempItems[0].Wine(ItemType.CollectB);
                        TempItems[0].NormCrystalButton();
                    }
                }
            }
        }

        //转盘 把下部区域的某个物体变成转盘 (优先级:空位>石头>polinko币)
        if (Tinge_Tenet > 0 && !OnWhaleTall)
        {
            ItemType itemType = ItemType.Wheel;
            if (ColumnStud.OnDaily())
            {
                itemType = ItemType.Coin;
            }
            if (Wheel_Num >= GameConfig.Instance.MaxNum_Wheel)
                Tinge_Tenet = GameConfig.Instance.ActiveTime_Wheel;
            else
                Tinge_Tenet--;
            if (Tinge_Tenet <= 0)
            {
                Tinge_Tenet = GameConfig.Instance.ActiveTime_Wheel;
                if (CanShow && Wheel_Num < GameConfig.Instance.MaxNum_Wheel)
                {
                    Tinge_Tenet = GameConfig.Instance.ActiveTime_Wheel;
                    List<Home> UnderItems = Humor.FindAll(item => item.transform.parent.parent.name == "下").OrderBy(item => Random.Range(0, 100)).ToList();
                    Home NeedChangeItem = UnderItems.FirstOrDefault(item => item.Much == ItemType.Empty)
                          ?? UnderItems.FirstOrDefault(item => item.Much == ItemType.Rock)
                          ?? UnderItems.FirstOrDefault(item => item.Much == ItemType.Coin)
                          ?? UnderItems.FirstOrDefault();
                    NeedChangeItem.Wine(itemType);
                    NeedChangeItem.NormCrystalButton();
                }
            }
        }

        //场上剩余物体大于ReappearNum个计时
        int EmptyNum = AshMuchBuyAnHumor(ItemType.Empty);
        if (Humor.Count - EmptyNum < GameConfig.Instance.ReappearNum)
        {
            List<Home> EmptyItems = Humor.FindAll(item => item.Much == ItemType.Empty).OrderBy(item => Random.Range(0, 100)).ToList();
            int ReappearItemNum = GameConfig.Instance.ReappearNum - (Humor.Count - EmptyNum);
            //print("场上剩余物体数量： " + (Items.Count - EmptyNum) + "   需要补全物体数量： " + ReappearItemNum);
            for (int i = 0; i < ReappearItemNum; i++)
            {
                Home Temp = EmptyItems[i];
                PestGrecian.AshForecast().Novel_SoloBeach(i * 0.03f, () =>
                {
                    Temp.Wine(Temp.AshHomeMuch());
                });
            }
        }

        //翻倍机恢复默认状态(buff状态 疯狂模式 不计时)
        if (!Dose_EnzymeSymptom_Finch
        && !Dose_EnzymeSymptom_Injury
        && !Dose_EnzymeSymptom_Akin
        && !OnWhaleTall
        && EnzymeSymptom_IgneousTenet > 0
        && _EnzymeSymptom.Finch != GameConfig.Instance.DoubleMachineDefaultMulti)
        {
            EnzymeSymptom_IgneousTenet--;
            if (EnzymeSymptom_IgneousTenet <= 0)
            {
                EnzymeSymptom_IgneousTenet = GameConfig.Instance.DoubleMachineDefaultTime;
                _EnzymeSymptom.SwissFinch();
                _EnzymeSymptom.GelDose_Injury(1);
            }
        }

        // buff计时
        if (Dose_EnzymeSymptom_Finch) //翻倍机乘倍
        {
            if (Dose_EnzymeSymptom_Finch_Tenet > 0)
                Dose_EnzymeSymptom_Finch_Tenet--;
            else
            {
                Dose_EnzymeSymptom_Finch = false;
                _EnzymeSymptom.SwissFinch();
                _EnzymeSymptom.FeebleInjury(1);
            }
        }
        if (Dose_EnzymeSymptom_Injury) //翻倍机长度
        {
            if (Dose_EnzymeSymptom_Injury_Tenet > 0)
                Dose_EnzymeSymptom_Injury_Tenet--;
            else
            {
                Dose_EnzymeSymptom_Injury = false;
                _EnzymeSymptom.GelDose_Injury(1);
            }
        }
        if (Dose_EnzymeSymptom_Akin) //翻倍机停止
        {
            if (Dose_EnzymeSymptom_Akin_Tenet > 0)
                Dose_EnzymeSymptom_Akin_Tenet--;
            else
            {
                Dose_EnzymeSymptom_Akin = false;
                _EnzymeSymptom.GelDose_Akin(false);
            }
        }
        if (Dose_BackupHole) // 变弹力球
        {
            if (Dose_BackupHole_Tenet > 0)
                Dose_BackupHole_Tenet--;
            else
                Dose_BackupHole = false;
        }

        // if (Buff_Wall_Bounce) // 变弹力墙
        // {
        //     if (Buff_Wall_Bounce_Timer > 0)
        //         Buff_Wall_Bounce_Timer--;
        //     else
        //     {
        //         Buff_Wall_Bounce = false;
        //         Wall_BecomeNormal();
        //     }
        // }

        //飞行气泡
        if (BoySatireTenet > 0 && !OnWhaleTall)
        {
            if (ColumnStud.OnDaily())
            {
                return;
            }
            BoySatireTenet--;
            if (BoySatireTenet <= 0)
            {
                BoySatireTenet = WedSoulHue.Instance._RoomIraq.fly_bubble.cold_down;
                _BoySatire.Boy();
            }
        }


        //测试
        if (GameConfig.Instance.TestMode)
        {
            int GameTime = (int)Time.time;
            int minutes = GameTime / 60; // 计算分钟数
            int seconds = GameTime % 60; // 计算剩余秒数
            string GameTimeStr = string.Format("{0:D2}:{1:D2}", minutes, seconds);
            print("游戏运行时间： " + GameTimeStr + "  掉球数量： " + Gain_SwimHoleBuy + "  进黑洞数量： " + Gain_AnCargoBuy);
        }
    }

    public int AshMuchBuyAnHumor(ItemType Type) // 获取指定类型物品数量
    {
        return Humor.FindAll(item => item.Much == Type).Count;
    }

    public void Polychrome(UnityAction action) // 转场动画播放
    {
        RoomBeach();
        PolychromeDouse.gameObject.SetActive(true);
        PolychromeDouse.PlayAnim("animation", false);
        PestGrecian.AshForecast().Novel(1.8f, () =>
        {
            action?.Invoke();
        });
        PestGrecian.AshForecast().Novel(3, () =>
        {
            PolychromeDouse.gameObject.SetActive(false);
            MyRoomBeach();
        });
    }

    public void LieuUI_Ford(bool IsShow, bool FeverOrSlot)
    {
        LieuUI.DOKill(true);
        if (IsShow) //显示
        {
            if (LieuUI.localPosition.x == -700) //在外侧 直接更换显示内容 再弹出
            {
                if (FeverOrSlot)
                {
                    WagonMagentaBuyAnWhaleTallDrug.gameObject.SetActive(true);
                    WagonMagentaBuyAnWhaleTall = 0;
                    WagonMagentaBuyAnWhaleTallDrug.text = "0";

                    LoveSymptom.PermGoCompostBuyDrug.gameObject.SetActive(false);
                }
                else
                {
                    WagonMagentaBuyAnWhaleTallDrug.gameObject.SetActive(false);
                    LoveSymptom.PermGoCompostBuyDrug.gameObject.SetActive(true);
                }
                LieuUI.localPosition = new Vector2(-700, LieuUI.localPosition.y);
                LieuUI.DOLocalMoveX(-460, .5f).SetDelay(1);
            }
            else //在内侧 先退回外侧 更换显示内容后重新弹出
            {
                LieuUI.localPosition = new Vector2(-460, LieuUI.localPosition.y);
                LieuUI.DOLocalMoveX(-700, .5f).SetEase(Ease.InBack).onComplete += () =>
                {
                    if (FeverOrSlot)
                    {
                        WagonMagentaBuyAnWhaleTallDrug.gameObject.SetActive(true);
                        WagonMagentaBuyAnWhaleTall = 0;
                        WagonMagentaBuyAnWhaleTallDrug.text = "0";

                        LoveSymptom.PermGoCompostBuyDrug.gameObject.SetActive(false);
                    }
                    else
                    {
                        WagonMagentaBuyAnWhaleTallDrug.gameObject.SetActive(false);
                        LoveSymptom.PermGoCompostBuyDrug.gameObject.SetActive(true);
                    }
                    LieuUI.localPosition = new Vector2(-700, LieuUI.localPosition.y);
                    LieuUI.DOLocalMoveX(-460, .5f);
                };
            }
        }
        else
        {
            if (LieuUI.localPosition.x == -700)
                return;
            LieuUI.localPosition = new Vector2(-460, LieuUI.localPosition.y);
            LieuUI.DOLocalMoveX(-700, .5f);
        }
    }

    #region 加钱
    public void PitHomeCape(float Coin, Vector2 StartPos) // 获得撞击物品金币
    {
        VisualizeConformity.AshAiryDrugShoe(Coin, StartPos);
        ImplyCape((int)Coin);

        SaltPitSteep((int)Coin);
    }
    public void PitPlumb(int Coin, bool IsAnim = true) //各种玩法 获得大量金币
    {
        if (IsAnim)
        {
            VisualizeConformity.AshSoonAiryShoe((int)Coin);
            PestGrecian.AshForecast().Novel(1.4f, () =>
            {
                ImplyCape(Coin);
                ShootHue.AshForecast().NormButton(ShootMuch.UIMusic.collect_coin);

                SaltPitSteep(Coin);
            });
        }
        else
        {
            ImplyCape(Coin);

            SaltPitSteep(Coin);
        }
    }
    public void ImplyMoth(float Cash)
    {
        ZJT_Manager.AshForecast().AddMoney(Cash, "JT_Money1");
        MothDrug.text = ZJT_Manager.AshForecast().GetMoney().ToString("F1");
    }
    public void ImplyCape(int Coin)
    {

        ZJT_Manager.AshForecast().AddMoney(Coin, "JT_Money2");
        CapeBuy += Coin;
        CellIraqGrecian.SetInt("CoinNum", CapeBuy);
        if (ColumnStud.OnDaily())
        {
            CapeDrug.text = CapeBuy.ToString();
        }
        else
        {
            CapeDrug.text = ZJT_Manager.AshForecast().GetMoney("JT_Money2").ToString("F0");
        }
    }

    public void PitHomeMagenta(float Diamond, Vector2 StartPos) // 获得撞击物品钻石
    {
        if (OnWhaleTall) //疯狂模式统计在此期间获得数量
        {
            PitHomeUnlessAnWhaleTall(Diamond);
            VisualizeConformity.AshMagentaDrugShoe(Diamond, StartPos);
        }
        else //正常模式直接加钱 
        {
            VisualizeConformity.AshMagentaDrugShoe(Diamond, StartPos);
            ImplyMoth(Diamond);
            SaltPitMagenta(Diamond);
        }
    }
    public void PitMonarchy(float Diamond, bool IsAnim = true) //各种玩法 获得大量钻石
    {
        if (IsAnim)
        {
            VisualizeConformity.AshSoonMagentaShoe((int)Diamond);
            PestGrecian.AshForecast().Novel(1.4f, () =>
            {
                ImplyMoth(Diamond);
                ShootHue.AshForecast().NormButton(ShootMuch.UIMusic.collect_coin);
                SaltPitMagenta(Diamond);
            });
        }
        else
        {

            ImplyMoth(Diamond);
            SaltPitMagenta(Diamond);
        }
    }

    public void PitHomeUnlessAnWhaleTall(float Diamond) // 疯狂模式不直接加钱 统计数量
    {
        WagonMagentaBuyAnWhaleTall += Diamond;
        WagonMagentaBuyAnWhaleTall = (float)System.Math.Round(WagonMagentaBuyAnWhaleTall, 1);
        WagonMagentaBuyAnWhaleTallDrug.text = WagonMagentaBuyAnWhaleTall.ToString();
    }

    void SaltPitSteep(int Coin) //审模式下假UI加钱
    {
        if (ColumnStud.OnDaily())
        {
            int TempMoney = PlayerPrefs.GetInt("TempMoney");
            TempMoney += Coin;
            PlayerPrefs.SetInt("TempMoney", TempMoney);
            SaltSteepDrug.text = TempMoney.ToString();
        }
    }
    void SaltPitMagenta(float Diamond) //审模式下假UI加钻石
    {
        if (ColumnStud.OnDaily())
        {
            float TempDiamond = PlayerPrefs.GetFloat("TempDiamond");
            TempDiamond += Diamond;
            PlayerPrefs.SetFloat("TempDiamond", TempDiamond);
            SaltMagentaDrug.text = TempDiamond.ToString("F1");
        }
    }

    #endregion

    #region  暂停
    public void RoomBeach(bool IsPause = true) //游戏暂停
    {
        PestGrecian.AshForecast().OnBeach = IsPause;
        BlissGo();
        //球移动开关
        foreach (Transform child in HoleBeluga)
        {
            if (child.gameObject.activeSelf)
            {
                Rigidbody2D rb = child.GetComponent<Rigidbody2D>();
                rb.simulated = !PestGrecian.AshForecast().OnBeach;
            }
        }
        //翻倍机移动开关
        _EnzymeSymptom.Beach();
        // 物体移动开关
        foreach (HomeJazzMime line in Cargo)
            line.Beach();

    }
    public void MyRoomBeach(UnityAction action = null, float Delay = .31f) //游戏恢复(由于各类弹窗关闭动画需要时间 所以游戏继续之前起码要等待一段时间)
    {
        PestGrecian.AshForecast().Novel(Delay, () =>
        {
            action?.Invoke();
            RoomBeach(false);
        });
    }
    #endregion

    #region  点击扔球
    void SwellSkySwimHole(PointerEventData eventData = null) //点击扔一个球(由掉球按钮的EventTrigger调用)
    {
        if (PestGrecian.AshForecast().OnBeach)
            return;

        if (SwellSwimHoleAnd >= GameConfig.Instance.ClickDropBallGap)
            SwellSwimHoleAnd = 0;
        else
            return;

        if (OnWhaleTall)
        {
            if (HoleBuy_AnWhaleTall > 0)
            {
                HoleBuy_AnWhaleTall--;
                HoleBuyDrug.text = HoleBuy_AnWhaleTall.ToString();
                //BallNumText.gameObject.SetActive(BallNum_InFeverMode > 0);
                //BuyBallPriceText.gameObject.SetActive(BallNum_InFeverMode <= 0);
                SwimHole();
            }
            // else if (CoinNum >= GameConfig.Instance.BuyBallPrice)
            // {
            //     CountCoin(-GameConfig.Instance.BuyBallPrice);
            //     DropBall();
            // }
        }
        else
        {
            if (HoleBuy > 0)
            {
                HoleBuy--;
                ZJT_Manager.AshForecast().AddTaskValue("drop_ball", 1);
                HoleBuyDrug.text = HoleBuy.ToString();
                CellIraqGrecian.SetInt("BallNum", HoleBuy);
                //BallNumText.gameObject.SetActive(BallNum > 0);
                //BuyBallPriceText.gameObject.SetActive(BallNum <= 0);
                SwimHole();
            }
            // else if (CoinNum >= GameConfig.Instance.BuyBallPrice)
            // {
            //     CountCoin(-GameConfig.Instance.BuyBallPrice);
            //     DropBall();
            // }
            else
            {
                RoomBeach();
                AnewUIPure(nameof(RatHoleCigar));
            }
        }
    }
    void SwimHole()
    {
        Vector2 MousePos = _Weight.ScreenToWorldPoint(Input.mousePosition);
        MousePos.y = HoleFrayTwo.position.y;
        MousePos.x += Random.Range(-.1f, .1f);
        HoleFrayTwo.position = MousePos;
        GameObject NewBall = ObjectPool.Instance.Get("球");
        NewBall.transform.SetParent(HoleBeluga);
        NewBall.transform.localScale = Vector3.one;
        NewBall.transform.position = HoleFrayTwo.position;
        BlissOnLoss = true;
        LossSwimHoleAnd = 0;
        ShootHue.AshForecast().NormButton(ShootMuch.UIMusic.drop_ball);
        if (Dose_BackupHole)
            NewBall.GetComponent<Hole>().GelBackup();

        if (!OnWhaleTall)
        {
            Newly_SwimHoleImply++;
            if (Newly_SwimHoleImply % 30 == 0)
                SashNewlyBroker.AshForecast().VastNewly("1014", Newly_SwimHoleImply.ToString());
        }

        ADGrecian.Forecast.DifferAwfulBuy(1);
    }
    void BlissGo(PointerEventData eventData = null) // 鼠标抬起(由掉球按钮的EventTrigger调用 暂停也会调用)
    {
        BlissOnLoss = false;
    }

    public void PitHole(int Count) // 增加球
    {
        HoleBuy += Count;
        VisualizeConformity.AshSoonHoleShoe(Count);
        PestGrecian.AshForecast().Novel(1.4f, () =>
        {
            HoleBuyDrug.text = HoleBuy.ToString();
            //BallNumText.gameObject.SetActive(BallNum > 0);
            //BuyBallPriceText.gameObject.SetActive(BallNum <= 0);
        });
        ShootHue.AshForecast().NormButton(ShootMuch.UIMusic.collect_ball);
    }

    void PitHole_Restful()
    {
        int offlineTime = PestGrecian.AshForecast().AshRestfulPest();
        int addBallNum = Mathf.CeilToInt(offlineTime / GameConfig.Instance.BallNumRecoveryTime);
        print("离线时间：" + offlineTime + " 增加球数：" + addBallNum + " 原始球数： " + HoleBuy);
        HoleBuy += addBallNum;
        if (HoleBuy > GameConfig.Instance.FirstBallNum)
            HoleBuy = GameConfig.Instance.FirstBallNum;
        HoleBuyDrug.text = HoleBuy.ToString();
        CellIraqGrecian.SetInt("BallNum", HoleBuy);
    }

    #endregion

    #region  疯狂模式
    public void WhalePit() // 疯狂模式数量统计 进入疯狂模式
    {
        Spread.SetParent(LinearUpsetBeluga);
        if (GameConfig.Instance.TestMode)
            return;

        if (OnWhaleTall)
            return;

        WhaleBuy++;
        WhaleBuyStorm.fillAmount = (float)WhaleBuy / GameConfig.Instance.FeverNum;
        if (WhaleBuy >= GameConfig.Instance.FeverNum)
        {
            OnWhaleTall = true;
            LieuUI_Ford(false, true);

            //停掉老虎机带来的各类效果
            Dose_Soup_Backup_Tenet = 0;
            Dose_EnzymeSymptom_Finch = false;
            Dose_EnzymeSymptom_Finch_Tenet = 0;
            _EnzymeSymptom.FeebleInjury(1);
            LoveSymptom_LinkTopiHoleButton.StopEmission();
            for (int i = 0; i < TopiHoleIndividual.Count; i++)
            {
                if (TopiHoleIndividual[i] != null)
                    PestGrecian.AshForecast().StopCoroutine(TopiHoleIndividual[i]);
            }
            TopiHoleIndividual.Clear();
            LoveSymptom.Deep();

            RoomBeach();
            ShootHue.AshForecast().NormButton(ShootMuch.UIMusic.lanch_wheel);
            ShootHue.AshForecast().NormButton(ShootMuch.UIMusic.light_blast);
            HomoPlaceShoe.SetBool("feve", true);
            //EnterFeverGO1.gameObject.SetActive(true);
            // 灯交替闪
            for (int i = 0; i < FiordWhaleGO1_Teapot.Length; i++)
                FiordWhaleGO1_Teapot[i].color = new Color(1, 1, 1, 0);
            int[] LightGroup1 = { 0, 2 };
            int[] LightGroup2 = { 1 };
            for (int i = 0; i < LightGroup1.Length; i++)
                FiordWhaleGO1_Teapot[LightGroup1[i]].DOFade(1, 0.1f).SetLoops(8, LoopType.Yoyo).SetEase(Ease.Linear);
            for (int i = 0; i < LightGroup2.Length; i++)
                FiordWhaleGO1_Teapot[LightGroup2[i]].DOFade(1, 0.1f).SetLoops(8, LoopType.Yoyo).SetDelay(0.02f).SetEase(Ease.Linear);

            //EnterFeverSpine.PlayAnim("1", true);
            PestGrecian.AshForecast().Novel(1, () =>
            {
                FiordWhaleGO1.gameObject.SetActive(false);
                HomoPlaceShoe.SetBool("feve", false);
                WhaleLegendary.gameObject.SetActive(false);
                for (int i = 0; i < FiordWhaleGO1_Teapot.Length; i++)
                {
                    FiordWhaleGO1_Teapot[i].DOKill();
                    FiordWhaleGO1_Teapot[i].color = new Color(1, 1, 1, 0);
                }
                FiordWhaleGO2.gameObject.SetActive(true);
                FiordWhaleGO2.localPosition = new Vector2(0, 2400);
              //  EnterFeverGO2.DOLocalMoveY(-439.07f, 0.5f).SetEase(Ease.OutBack).OnComplete(() =>
                FiordWhaleGO2.DOLocalMoveY(0f, 0.5f).SetEase(Ease.OutBack).OnComplete(() =>
                {
                    FiordWhaleButton.Play();
                    ShootHue.AshForecast().NormButton(ShootMuch.UIMusic.fall_light);
                    foreach (Transform child in HoleBeluga)
                    {
                        if (child.gameObject.activeSelf)
                            ObjectPool.Instance.Return("球", child.gameObject);
                    }
                    MyRoomBeach(() => { FiordWhaleTall(); });
                });
                FiordWhaleGO2.DOLocalMoveY(2400, 0.5f).SetDelay(1.5f).OnComplete(() =>
                {

                    FiordWhaleGO2.gameObject.SetActive(false);
                    WhaleDouse.gameObject.SetActive(true);
                    WhaleLegendary.gameObject.SetActive(true);
                    WhaleDouse.PlayAnim("animation", true);
                    WhaleLegendary.Skeleton.SetToSetupPose();
                    WhaleLegendary.AnimationState.ClearTracks();
                    WhaleLegendary.PlayAnim("heng", true);
                  
                });
                //EnterFeverSpine.PlayAnim("2", false);
                //UnGamePause(() => { EnterFeverMode(); });
            });
        }
    }
    void FiordWhaleTall()
    {
        Physics2D.gravity = new Vector2(0, -8);

        //ShootHue.GetInstance().PlayEffect(ShootMuch.UIMusic.lanch_fever);
        //ShootHue.GetInstance().PlayEffect(ShootMuch.UIMusic.light_blast);
        ShootHue.AshForecast().NormHe(ShootMuch.SceneMusic.fever_BGM);

        LieuUI_Ford(true, true);

        HoleBuy_AnWhaleTall = 50;
        HoleBuyDrug.text = HoleBuy_AnWhaleTall.ToString();
        HoleBuy_AnWhale_Darn.SetActive(true);
        //BallNumText.gameObject.SetActive(true);
        //BuyBallPriceText.gameObject.SetActive(false);

        _EnzymeSymptom.SwissFinch(10);
        _EnzymeSymptom.FeebleInjury(2.5f);
        _EnzymeSymptom.WhaleLowaPorous(true);

        HardenReleaseHome();
        for (int i = 0; i < AsideEvanescent.Length; i++)
            AsideEvanescent[i].Wine();

        HomeRegain.gameObject.SetActive(false);
        WhaleHomeBeluga.gameObject.SetActive(true);

        Cargo[^1].gameObject.SetActive(false);
        JazzMime();
        PlaceShoe();

        _BoySatire.gameObject.SetActive(false);
        for (int i = 0; i < Whale_PeepDeep.Length; i++)
            Whale_PeepDeep[i].SetActive(false);
        for (int i = 0; i < Whale_PeepEven.Length; i++)
            Whale_PeepEven[i].SetActive(true);

        WhaleAngle.gameObject.SetActive(true);
        CoinBoom.gameObject.SetActive(true);
        WhaleAngleUnlessButton.gameObject.SetActive(false);
        WhaleAngleDouse.PlayAnim("idle", true);
        WhaleAngleDouse.Skeleton.SetSkin("default");
        WhaleAngleDouse.Skeleton.SetToSetupPose();
        WhaleAngleDouse.AnimationState.Apply(WhaleAngleDouse.Skeleton);
        WhaleAngleBuy = GameConfig.Instance.FeverChestNum;
        WhaleAngleBuyDrug.text = WhaleAngleBuy.ToString();
        WhaleTenet = GameConfig.Instance.FeverTime;

        He.DOColor(new Color(255 / 255f, 106 / 255f, 0 / 255f, 1), 1);
        // FeverSpine.PlayAnim("animation", true);
        // FeverSpine.gameObject.SetActive(true);
        StartCoroutine(WhaleTallPestImply());
        float TimeStep = (float)(GameConfig.Instance.FeverTime - 1) / GameConfig.Instance.FeverBornNum;
        for (int i = 0; i < GameConfig.Instance.FeverBornNum; i++)
        {
            PestGrecian.AshForecast().Novel_SoloBeach(TimeStep * i, () =>
            {
                Vector2 BornPos = HoleFrayTwo.position;
                BornPos.x = Random.Range(-2.5f, 2.5f);
                GameObject NewBall = ObjectPool.Instance.Get("球");
                NewBall.transform.SetParent(HoleBeluga);
                NewBall.transform.localScale = Vector3.one;
                NewBall.transform.position = BornPos;
            });
        }
        SashNewlyBroker.AshForecast().VastNewly("1004");
    }
    IEnumerator WhaleTallPestImply() // 疯狂模式结束
    {
        if (OnWhaleTall)
        {
            while (true)
            {
                yield return null;
                if (!PestGrecian.AshForecast().OnBeach)
                {
                    WhaleTenet -= Time.deltaTime;
                    WhaleBuyStorm.fillAmount = (float)WhaleTenet / GameConfig.Instance.FeverTime;
                    if (WhaleTenet <= 0)
                    {
                        OnWhaleTall = false;
                        RoomBeach();
                        Physics2D.gravity = new Vector2(0, -4);
                        ShootHue.AshForecast().NormHe(ShootMuch.SceneMusic.BGM);

                        HoleBuy = CellIraqGrecian.GetInt("BallNum");
                        HoleBuyDrug.text = HoleBuy.ToString();
                        HoleBuy_AnWhale_Darn.SetActive(false);
                        //BallNumText.gameObject.SetActive(BallNum > 0);
                        //BuyBallPriceText.gameObject.SetActive(BallNum <= 0);

                        HomeRegain.gameObject.SetActive(true);
                        WhaleHomeBeluga.gameObject.SetActive(false);

                        JazzMime();
                        PlaceShoe();

                        _EnzymeSymptom.SwissFinch();
                        _EnzymeSymptom.FeebleInjury(1);
                        EnzymeSymptom_IgneousTenet = GameConfig.Instance.DoubleMachineDefaultTime;
                        _EnzymeSymptom.WhaleLowaPorous(false);

                        HumorIgneousWine();
                        SwissReleaseHome();

                        for (int i = 0; i < Whale_PeepDeep.Length; i++)
                            Whale_PeepDeep[i].SetActive(true);
                        for (int i = 0; i < Whale_PeepEven.Length; i++)
                            Whale_PeepEven[i].SetActive(false);

                        WhaleBuy = 0;
                        WhaleBuyStorm.fillAmount = 0;

                        He.DOColor(Color.white, 1);
                        WhaleDouse.StopAnim();
                        WhaleLegendary.StopAnim();
                        WhaleDouse.gameObject.SetActive(false);
                        WhaleLegendary.gameObject.SetActive(false);
                        foreach (Transform child in HoleBeluga)
                        {
                            if (child.gameObject.activeSelf)
                                ObjectPool.Instance.Return("球", child.gameObject);
                        }
                        _EnzymeSymptom.BreedPermFray();
                        Spread.SetParent(SpreadUpsetBeluga);
                        //疯狂模式奖励
                        (AnewUIPure(nameof(BatDayCigar)) as BatDayCigar).Wine(WagonMagentaBuyAnWhaleTall, () =>
                        {
                            //领取完疯狂模式奖励后 判断是否领取疯狂宝箱
                            // if (FeverChestNum <= 0)
                            // {
                            //     PestGrecian.GetInstance().Delay(0.31f, () =>
                            //     {
                            //         (OpenUIForm(nameof(UnlessCigar)) as UnlessCigar).Init(88, () => { UnGamePause(); });
                            //     });
                            // }
                            // else
                            LieuUI_Ford(false, true);
                            MyRoomBeach(() =>
                            {
                                //好评引导
                                if (!ColumnStud.OnDaily() && !CellIraqGrecian.GetBool("RateUs"))
                                {
                                    CellIraqGrecian.SetBool("RateUs", true);
                                    AnewUIPure(nameof(OnlyUpCigar));
                                }

                                //继续slot
                                LoveSymptom.SewerageLove_PloyWhalePul();
                            });
                        });
                        break;
                    }
                }
            }
        }

    }

    void JazzMime() // 所有物体移动
    {
        foreach (HomeJazzMime line in Cargo)
        {
            if (OnWhaleTall)
                line.ThornMime();
            else
                line.AkinMime();
        }
    }

    public void WhaleAnglePit() // 疯狂模式宝箱增加
    {
        WhaleAngleBuy--;
        if (WhaleAngleBuy < 0)
            return;
        int HitStep = (GameConfig.Instance.FeverChestNum / 3);
        if (WhaleAngleBuy >= HitStep * 2)
            WhaleAngleDouse.Skeleton.SetSkin("default");
        else if (WhaleAngleBuy >= HitStep)
            WhaleAngleDouse.Skeleton.SetSkin("2");
        else
            WhaleAngleDouse.Skeleton.SetSkin("3");
        WhaleAngleDouse.Skeleton.SetToSetupPose();
        WhaleAngleDouse.AnimationState.Apply(WhaleAngleDouse.Skeleton);
        WhaleAngleDouse.AnimationState.SetAnimation(1, "hit", false);
        WhaleAngleBuyDrug.text = WhaleAngleBuy.ToString();
        if (WhaleAngleBuy <= 0)
        {
            ShootHue.AshForecast().NormButton(ShootMuch.UIMusic.egg_explode);
            ShootHue.AshForecast().NormButton(ShootMuch.UIMusic.lots_coin);
            WhaleAngleBuyDrug.text = "";
            WhaleAngleDouse.Skeleton.SetSkin("4");
            WhaleAngleDouse.PlayAnim("boom", false);
            if (!ColumnStud.OnDaily())
            {
                WhaleAngleUnlessButton.gameObject.SetActive(true);
                WhaleAngleUnlessButton.Play();
            }
            else
            {
                CoinBoom.gameObject.SetActive(true);
                CoinBoom.Play();
            }
            float ChestReward = GameConfig.Instance.CountReward(RewardType.Diamond, (float)WedSoulHue.Instance._RoomIraq.fever_chest_award_mutli);
            ZJT_Manager.AshForecast().AddTaskValue("box_break", 1);
            PitHomeUnlessAnWhaleTall(ChestReward);
            PestGrecian.AshForecast().Novel_SoloBeach(2, () =>
            {
                WhaleAngle.gameObject.SetActive(false);
                Cargo[^1].gameObject.SetActive(true);
                //FeverChestRewardEffect.Play();
                ShootHue.AshForecast().NormButton(ShootMuch.UIMusic.hit_chest);
                ShootHue.AshForecast().NormWareButton(ShootMuch.UIMusic.crazy_coin);
            });
            PestGrecian.AshForecast().Novel_SoloBeach(10f, () =>
            {
                ShootHue.AshForecast().AkinWareButton(ShootMuch.UIMusic.crazy_coin);
            });
        }
    }

    void PlaceShoe()
    {
        float AnimTime = 1;
        float Delay = .5f;
        if (OnWhaleTall)
        {
            AnimTime = .2f;
            Delay = .1f;
        }
        for (int i = 0; i < Teapot1.Length; i++)
        {
            Teapot1[i].DOKill();
            Teapot1[i].color = Color.white;
            Teapot1[i].DOFade(0, AnimTime).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
        }
        for (int i = 0; i < Teapot2.Length; i++)
        {
            Teapot2[i].DOKill();
            Teapot2[i].color = Color.white;
            Teapot2[i].DOFade(0, AnimTime).SetEase(Ease.Linear).SetDelay(Delay).SetLoops(-1, LoopType.Yoyo);
        }
    }

    #endregion

    #region 底部收集器/开启翻倍机

    #endregion

    #region  黑洞

    public void CargoMuchPit() // 黑洞收集到小球
    {
        RoundMuchBuy++;
        if (RoundMuchBuy < 0)
            return;
        RoundMuchBuyDrug.text = RoundMuchBuy.ToString();
        //CellIraqGrecian.SetInt("BlackHoleNum", BlackHoleNum);
        CargoPitHoleButton.gameObject.SetActive(true);
        CargoPitHoleButton.Play();
        PestGrecian.AshForecast().Novel(1.5f, () =>
        {
            CargoPitHoleButton.gameObject.SetActive(false);
        });

        // if (BlackHoleNum <= 0)
        // {
        //     GamePause();
        //     OpenUIForm(nameof(SurmiseCigar));

        //     // 开启新机台
        //     // foreach (Transform child in BallParent)
        //     // {
        //     //     if (child.gameObject.activeSelf)
        //     //     {
        //     //         ObjectPool.Instance.Return("球", child.gameObject);
        //     //     }
        //     // }
        //     // _DoubleMachine.ClearWaitBorn();
        //     // RecordSpecialItem();
        //     // Transition(() =>
        //     // {
        //     //     CloseUIForm(nameof(RoomCigar));
        //     //     (OpenUIForm(nameof(SwimHoleRoomCigar)) as SwimHoleRoomCigar).Init();
        //     //     BlackHoleNum = GameConfig.Instance.BlockHoleTarget;
        //     //     BlackHoleNumText.text = BlackHoleNum.ToString();
        //     // });
        // }

        CompostLove();

        if (GameConfig.Instance.TestMode)
            Gain_AnCargoBuy++;
    }

    public void WispyCargoMuchUnless()
    {
        MyRoomBeach();
        RoundMuchBuy = GameConfig.Instance.BlockHoleTarget;
        RoundMuchBuyDrug.text = RoundMuchBuy.ToString();
        CellIraqGrecian.SetInt("BlackHoleNum", RoundMuchBuy);
    }

    void CargoSoupShoe(int Index = 0)
    {
        if (Index == 0) // 上
        {
            int TargetY = (int)CargoMuchSoupBeluga.localPosition.y + 50;
            CargoMuchSoupBeluga.DOLocalMoveY(TargetY, GameConfig.Instance.BlockHoleWallAnimTime).SetEase(GameConfig.Instance.BlockHoleWallAnimCurve);
        }
        else if (Index == 1) // 下
        {
            int TargetY = (int)CargoMuchSoupBeluga.localPosition.y - 50;
            CargoMuchSoupBeluga.DOLocalMoveY(TargetY, GameConfig.Instance.BlockHoleWallAnimTime).SetEase(GameConfig.Instance.BlockHoleWallAnimCurve);
        }
        else if (Index == 2) //外
        {
            int TargetX = -40;
            CargoMuchSoup1.DOLocalMoveX(CargoMuchSoup1.localPosition.x + TargetX, GameConfig.Instance.BlockHoleWallAnimTime).SetEase(GameConfig.Instance.BlockHoleWallAnimCurve);
            CargoMuchSoup2.DOLocalMoveX(CargoMuchSoup2.localPosition.x - TargetX, GameConfig.Instance.BlockHoleWallAnimTime).SetEase(GameConfig.Instance.BlockHoleWallAnimCurve);
        }
        else if (Index == 3) //内
        {
            int TargetX = 40;
            CargoMuchSoup1.DOLocalMoveX(CargoMuchSoup1.localPosition.x + TargetX, GameConfig.Instance.BlockHoleWallAnimTime).SetEase(GameConfig.Instance.BlockHoleWallAnimCurve);
            CargoMuchSoup2.DOLocalMoveX(CargoMuchSoup2.localPosition.x - TargetX, GameConfig.Instance.BlockHoleWallAnimTime).SetEase(GameConfig.Instance.BlockHoleWallAnimCurve);
        }
        PestGrecian.AshForecast().Novel_SoloBeach(GameConfig.Instance.BlockHoleWallAnimTime + GameConfig.Instance.BlockHoleWallAnimStayTime, () =>
        {
            Index++;
            if (Index >= 4)
                Index = 0;
            CargoSoupShoe(Index);
        });
    }

    public void CompostLove() // 触发老虎机
    {
        bool IsGuideSlot = CellIraqGrecian.GetBool("IsGuideSlot2");
        if (!IsGuideSlot)
        {
            React7();
            CellIraqGrecian.SetBool("IsGuideSlot2", true);
        }
        else
            LoveSymptom.Love();
        ShootHue.AshForecast().NormButton(ShootMuch.UIMusic.lanch_slots);
    }

    public void LoveFright()
    {

    }

    #endregion

    #region  收集物
    public void MethanePit(ItemType Type, Vector2 Pos) // 收集物增加
    {
        if (GameConfig.Instance.TestMode)
            return;

        int Index = 0;
        int MaxNum = 3;
        float Reward = 0;
        GameObject[] CollectSigns = null;
        UIParticle[] CollectSignEffects = null;
        UIParticle[] OkSign = null;
        if (Type == ItemType.CollectA)
        {
            Index = 0;
            MaxNum = 3;
            Reward = Methane_UnlessNine[0];
            CollectSigns = MethaneAEthic;
            CollectSignEffects = MethaneAItemFiction;
            OkSign = MethaneAIfEthic;
        }
        else if (Type == ItemType.CollectB)
        {
            Index = 1;
            MaxNum = 4;
            Reward = Methane_UnlessNine[1];
            CollectSigns = MethaneBEthic;
            CollectSignEffects = MethaneBItemFiction;
            OkSign = MethaneBIfEthic;
        }

        if (MethaneBuy[Index] >= MaxNum)
            return;
        MethaneBuy[Index]++;
        if (Type == ItemType.CollectA)
            CellIraqGrecian.SetInt("CollectNum_A", MethaneBuy[0]);
        else if (Type == ItemType.CollectB)
            CellIraqGrecian.SetInt("CollectNum_B", MethaneBuy[1]);
        if (MethaneBuy[Index] >= MaxNum)
            RoomBeach();
        for (int i = 0; i < MaxNum; i++)
            CollectSigns[i].SetActive(MethaneBuy[Index] > i);

        Transform Sign = CollectSigns[MethaneBuy[Index] - 1].transform;
        Vector2 CubicTwo= Sign.position;
        Sign.position = Pos;
        Vector2 JumpPos = new Vector2(Pos.x + Random.Range(-.2f, .2f), Pos.y);
        Sign.DOJump(JumpPos, .5f, 1, .4f, false);
        Sign.DOScale(Vector3.one * 1.5f, .4f);
        Sign.DOScale(Vector3.one, .4f).SetDelay(.7f);
        Sign.DOMove(CubicTwo, .4f).SetDelay(.7f).SetEase(Ease.InBack).OnComplete(() =>
        {
            ShootHue.AshForecast().NormButton(ShootMuch.UIMusic.inset);
            CollectSignEffects[MethaneBuy[Index] - 1].Play();
            PestGrecian.AshForecast().Novel(.5f, () =>
            {
                if (MethaneBuy[Index] >= MaxNum)
                {
                    for (int i = 0; i < OkSign.Length; i++)
                        OkSign[i].Play();
                    ShootHue.AshForecast().NormButton(ShootMuch.UIMusic.collect_full);
                    PestGrecian.AshForecast().Novel(1f, () =>
                    {
                        ((MethaneUnlessCigar)AnewUIPure(nameof(MethaneUnlessCigar))).EvenUnless(Type, Reward);
                    });
                }
            });
        }).OnStart(() =>
        {
            ShootHue.AshForecast().NormButton(ShootMuch.UIMusic.gem_fly);
        });
    }
    public void SwissMethaneImply(ItemType Type) // 重置收集物数量    
    {
        int Index = 0;
        int MaxNum = 3;
        GameObject[] CollectSigns = null;
        UIParticle[] CollectSignEffects = null;
        if (Type == ItemType.CollectA)
        {
            Index = 0;
            MaxNum = 3;
            CollectSigns = MethaneAEthic;
            CollectSignEffects = MethaneAItemFiction;
        }
        else if (Type == ItemType.CollectB)
        {
            Index = 1;
            MaxNum = 4;
            CollectSigns = MethaneBEthic;
            CollectSignEffects = MethaneBItemFiction;
        }

        MethaneBuy[Index] = 0;
        if (Type == ItemType.CollectA)
            CellIraqGrecian.SetInt("CollectNum_A", MethaneBuy[0]);
        else if (Type == ItemType.CollectB)
            CellIraqGrecian.SetInt("CollectNum_B", MethaneBuy[1]);
        for (int i = 0; i < MaxNum; i++)
        {
            CollectSigns[i].SetActive(false);
            //CollectSignEffects[i].SetActive(false);
        }
    }

    #endregion

    #region 老虎机各类效果

    // public void Wall_BecomeBounce(int Time) // 弹力墙生效
    // {
    //     Buff_Wall_Bounce = true;
    //     Buff_Wall_Bounce_Timer = Time;

    //     for (int i = 0; i < BounceWallOutline.Length; i++)
    //         BounceWallOutline[i].gameObject.SetActive(true);
    //     Wall_PhysicsMaterial.bounciness = 1;
    //     int OutlineWidth = 0;
    //     DOTween.To(() => OutlineWidth, x =>
    //     {
    //         OutlineWidth = x;
    //         for (int i = 0; i < BounceWallOutline.Length; i++)
    //         {
    //             BounceWallOutline[i].OutlineWidth = OutlineWidth;
    //             BounceWallOutline[i].Refresh();
    //         }
    //     }, 5, .5f).SetLoops(Time * 2, LoopType.Yoyo);
    // }
    // void Wall_BecomeNormal()
    // {
    //     for (int i = 0; i < BounceWallOutline.Length; i++)
    //         BounceWallOutline[i].gameObject.SetActive(false);
    //     Wall_PhysicsMaterial.bounciness = .5f;
    // }

    public void Hole_UsefulBackup(int Time) //球变弹力球
    {
        Dose_BackupHole = true;
        Dose_BackupHole_Tenet = Time;
    }

    public void Home_ThaiUsefulAiry(int ChangeCount) // 石头变金币   
    {
        List<Home> TempItems = Humor.Where(item => (item.Much == ItemType.Empty || item.Much == ItemType.Rock || item.Much == ItemType.Bounce)).OrderBy(item => Random.Range(0, 100)).ToList();
        int Count = Mathf.Min(ChangeCount, TempItems.Count);
        for (int i = 0; i < Count; i++)
        {
            int Index = i;
            PestGrecian.AshForecast().Novel(Index * .2f, () =>
            {
                LoveBoyButton(TempItems[Index].transform.position, () =>
                {
                    TempItems[Index].Wine(ItemType.Coin);
                    TempItems[Index].NormCrystalButton();
                });
            });
        }
    }

    public void Home_UsefulRoam(int[] ItemIndex) // 物品变炸弹 
    {
        for (int i = 0; i < ItemIndex.Length; i++)
        {
            int Index = ItemIndex[i];
            PestGrecian.AshForecast().Novel(i * .2f, () =>
            {
                LoveBoyButton(Humor[Index].transform.position, () =>
                {
                    Humor[Index].Wine(ItemType.Bomb);
                    Humor[Index].Hot(GameConfig.Instance.HitCount_Bomb - 1);
                    Humor[Index].NormCrystalButton();
                    Humor[Index].RoamCliffLease = .4f;
                });
            });
        }
    }

    public void Home_UsefulNovel(int[] ItemIndex) // 物品变分裂   
    {
        for (int i = 0; i < ItemIndex.Length; i++)
        {
            int Index = ItemIndex[i];
            PestGrecian.AshForecast().Novel(i * .2f, () =>
            {
                LoveBoyButton(Humor[Index].transform.position, () =>
                {
                    Humor[Index].Wine(ItemType.Split);
                    Humor[Index].NormCrystalButton();
                });
            });
        }
    }

    public void Home_UsefulBackup(int ChangeCount) // 物品变弹跳   
    {
        int Count = ChangeCount;
        List<Home> TempItems = Humor.Where(item => item.Much == ItemType.Empty).OrderBy(item => Random.Range(0, 100)).ToList();
        if (TempItems.Count < Count)
            TempItems = Humor.Where(item => item.Much == ItemType.Coin).OrderBy(item => Random.Range(0, 100)).ToList();
        for (int i = 0; i < Count; i++)
        {
            int Index = i;
            PestGrecian.AshForecast().Novel(Index * .2f, () =>
            {
                LoveBoyButton(TempItems[Index].transform.position, () =>
                {
                    TempItems[Index].Wine(ItemType.Bounce);
                    TempItems[Index].NormCrystalButton();
                });
            });
        }
    }

    public void Home_UsefulMagenta(int[] ItemIndex) // 物品变钻石       
    {
        ItemType itemType = ItemType.Diamond;
        if (ColumnStud.OnDaily())
        {
            itemType = ItemType.Coin;
        }
        for (int i = 0; i < ItemIndex.Length; i++)
        {
            int Index = ItemIndex[i];
            PestGrecian.AshForecast().Novel(i * .1f, () =>
            {
                LoveBoyButton(Humor[Index].transform.position, () =>
                {
                    Humor[Index].Wine(itemType);
                    Humor[Index].NormCrystalButton();
                });
            });
        }
    }

    public int Home_UsefulBatMagenta() // 物品变大钻石       
    {
        int FirstIndex = Random.Range(0, Humor.Count);
        //print("初始位置: " + FirstIndex);
        //找到和FirstIndex坐标距离v2.distance小于1的
        List<int> ItemIndex = new List<int>();
        for (int i = 0; i < Humor.Count; i++)
        {
            if (Vector2.Distance(Humor[FirstIndex].transform.position, Humor[i].transform.position) <= .8f)
                ItemIndex.Add(i);
        }

        for (int i = 0; i < ItemIndex.Count; i++)
        {
            int Index = ItemIndex[i];
            PestGrecian.AshForecast().Novel(i * .1f, () =>
            {
                LoveBoyButton(Humor[Index].transform.position, () =>
                {
                    Humor[Index].Wine(ItemType.BigDiamond);
                    Humor[Index].NormCrystalButton();
                });
            });
        }
        return ItemIndex.Count;
    }

    void LoveBoyButton(Vector3 FlyPos, UnityAction action) //各类物体从老虎机飞向目标动画     
    {
        if (OnWhaleTall)
            return;

        Transform Button= ObjectPool.Instance.Get("Slot飞图标特效").transform;
        Button.SetParent(transform);
        Button.localScale = Vector3.one;
        Button.position = LoveSymptom.transform.position;
        Vector3 MidPos = (Button.position + FlyPos) * .5f;
        MidPos.x += Random.Range(-2f, 2f);
        Vector3[] PathPoints = new Vector3[]
        {
            Button.position,
            MidPos,
            FlyPos
        };
        Button.DOPath(PathPoints, .6f, PathType.CatmullRom).SetEase(Ease.Linear).OnComplete(() =>
        {
            ObjectPool.Instance.Return("Slot飞图标特效", Button.gameObject);
            action?.Invoke();
        });
    }

    public void TopiHole(int Count) //随机落球        
    {
        LoveSymptom_LinkTopiHoleButton.StartEmission();
        LoveSymptom_LinkTopiHoleButton.Play();
        PestGrecian.AshForecast().Novel_SoloBeach(0.1f * Count, () =>
        {
            LoveSymptom_LinkTopiHoleButton.StopEmission();
            for (int i = 0; i < TopiHoleIndividual.Count; i++)
            {
                if (TopiHoleIndividual[i] != null)
                    PestGrecian.AshForecast().StopCoroutine(TopiHoleIndividual[i]);
            }
            TopiHoleIndividual.Clear();
        });

        for (int i = 0; i < Count; i++)
        {
            Coroutine Temp = PestGrecian.AshForecast().Novel_SoloBeach(0.1f * i, () =>
             {
                 Vector2 BornPos = HoleFrayTwo.position;
                 BornPos.x = Random.Range(-2.5f, 2.5f);
                 GameObject NewBall = ObjectPool.Instance.Get("球");
                 NewBall.transform.SetParent(HoleBeluga);
                 NewBall.transform.localScale = Vector3.one;
                 NewBall.transform.position = BornPos;
             });
            TopiHoleIndividual.Add(Temp);
        }
    }

    public void GelDose_CargoMuchByEnzymeSymptom(SlotBuffType BuffType, int Value) // 设置黑洞和翻倍机buff       
    {
        switch (BuffType)
        {
            case SlotBuffType.DoubleMachine_Multi: // 翻倍机加倍
                Dose_EnzymeSymptom_Finch = true;
                Dose_EnzymeSymptom_Finch_Tenet = 10;
                _EnzymeSymptom.SwissFinch(Value);
                _EnzymeSymptom.FeebleInjury(2);
                break;
            case SlotBuffType.DoubleMachine_Length: // 翻倍机延长
                Dose_EnzymeSymptom_Injury = true;
                Dose_EnzymeSymptom_Injury_Tenet = Value;
                _EnzymeSymptom.GelDose_Injury(2.5f);
                break;
            case SlotBuffType.DoubleMachine_Stop: // 翻倍机停止
                Dose_EnzymeSymptom_Akin = true;
                Dose_EnzymeSymptom_Akin_Tenet = Value;
                _EnzymeSymptom.GelDose_Akin(true);
                break;
        }
    }

    #endregion

    #region 引导
    void React1()
    {
        MyRoomBeach();
        _ReactCigar = AnewUIPure(nameof(ReactCigar)).GetComponent<ReactCigar>();
       _ReactCigar.EvenBlue(_MothDewFiord.transform.parent);
        _ReactCigar.EvenSoul("Help you understand how to withdraw cash", -650);
        _ReactCigar.EvenAlso(new Vector2[] { _MothDewFiord.transform.parent.position });
    }
    public void React2()
    {

        _ReactCigar.EvenBlue_Round(new Vector2(0, -100), new Vector2(1000, 1300));
        _ReactCigar.EvenSoul("Click the circled area to place the ball", 820);
        _ReactCigar.EvenPostPig(() => { React3(); });
    }
    void React3()
    {
        _ReactCigar.EvenBlue(bottomZhiyin);
        _ReactCigar.EvenSoul("Landing a ball in a grid earns its reward and triggers a refresh", -350);
        _ReactCigar.EvenPostPig(() => { React4(); });
    }
    void React4()
    {
        _ReactCigar.EvenBlue(_EnzymeSymptom.transform, 2f);
        _ReactCigar.EvenSoul("Balls split when passing through", -200);
        _ReactCigar.EvenPostPig(() => { React5(); });
    }
    void React5()
    {
        _ReactCigar.EvenBlue(BlockHole.transform, 3f);
        _ReactCigar.EvenSoul("Hole falling into a black hole triggers the slots", 0);
        _ReactCigar.EvenPostPig(() =>
        {
            _ReactCigar.Deep(false);
            _ReactCigar = null;
            MyRoomBeach();
        });
    }

    public void React6(Transform Target)
    {
        RoomBeach();
        _ReactCigar = AnewUIPure(nameof(ReactCigar)).GetComponent<ReactCigar>();
        _ReactCigar.EvenBlue(Target, .8f);
        _ReactCigar.EvenSoul("It triggers the slots", -420);
        _ReactCigar.EvenPostPig(() =>
        {
            _ReactCigar.Deep(false);
            _ReactCigar = null;
            MyRoomBeach();
        });
    }
    void React7()
    {
        RoomBeach();
        _ReactCigar = AnewUIPure(nameof(ReactCigar)).GetComponent<ReactCigar>();
        _ReactCigar.EvenBlue(LoveSymptom.transform);
        _ReactCigar.EvenSoul("Randomly receive massive favorable rewards", 460);
        _ReactCigar.EvenPostPig(() =>
        {
            _ReactCigar.Deep(false);
            _ReactCigar = null;
            WispyUIPure(nameof(ReactCigar));
            MyRoomBeach(() =>
            {
                LoveSymptom.Love();
            });
        });
    }
    #endregion
    void Newly1()
    {
        MothDrug.text = ZJT_Manager.AshForecast().GetMoney().ToString("F1");
        print("刷新游戏内UI  货币量显示  购买按钮变灰等等");
    }
    void Newly2()
    {
        print("没钱了遥控用户手机爆炸");
    }
}
