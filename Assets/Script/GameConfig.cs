using UnityEngine;
using DG.Tweening;
using System.Globalization;

/// <summary> 游戏参数配置 </summary>
public class GameConfig : MonoBehaviour
{
    public static GameConfig Instance;
    void Awake()
    {
        Instance = this;
    }

    [Header("测试模式")] public bool TestMode = false;

    [Space(20)]
    [Header("球速大于N出现拖尾")] public float BallSpeed_ShowTrail = 10f;
    [Header("同一音效播放间隔")] public float SoundGap = 0.2f;
    [Header("震动间隔")] public float VibrateGap = 0.1f;
    [Header("引导期间变成老虎机时间(秒)")] public int Become_SlotTime_InGuide = 10;

    [Space(20)]
    [Header("系数配置")]
    [Header("基础奖励")] public int BaseCoin = 1;
    [Header("基础奖励随机值")] public float BaseCoinRandomMin = 0.1f;
    [Header("基础奖励随机值")] public float BaseCoinRandomMax = 0.5f;
    [Header("基础奖励(钻石)")] public float BaseDiamond = 1;
    [Header("基础奖励随机值(钻石)")] public float BaseDiamondRandomMin = 0.1f;
    [Header("基础奖励随机值(钻石)")] public float BaseDiamondRandomMax = 0.5f;
    [Header("撞击金币奖励")] public float CoinHitReward = 0.1f;
    [Header("撞击钻石奖励")] public float DiamondHitReward = 0.1f;
    [Header("slot中奖权重")] public float SlotWinWeight = 0.7f;

    [Space(20)]
    [Header("点击掉球")]
    [Header("是否开启按住扔球")] public bool IsHoldDropBall = true;
    [Header("点击扔球间隔")] public float ClickDropBallGap = 0.5f;
    [Header("按住扔球间隔")] public float HoldDropBallGap = 0.5f;
    [Header("初始球数量")] public int FirstBallNum = 50;
    [Header("球数量恢复时间(秒)")] public int BallNumRecoveryTime = 5;
    //[Header("初始金币")] public int FirstCoinNum = 100;
    //[Header("看广告买金币数量")] public int AdBuyCoinNum = 100;
    [Header("金币买球价格")] public int BuyBallPrice = 1;
    [Header("买球数量")] public int BuyBallNum = 20;
    [Header("买球使用金币时间间隔")] public int BuyBallUseCoinTime = 600;

    [Space(20)]
    [Header("疯狂模式")]
    [Header("进入疯狂模式所需球数量")] public int FeverNum = 200;
    [Header("持续时间(秒)")] public int FeverTime = 10;
    [Header("生成球数量")] public int FeverBornNum = 100;
    [Header("一行物体移动时间")] public float ItemLineAnimTime = 1f;
    [Header("宝箱开启需要击打次数")] public int FeverChestNum = 10;

    [Space(20)]
    [Header("翻倍机")]
    [Header("生成间隔")] public float DoubleMachineBornInterval;
    [Header("动画曲线")] public Ease DoubleMachineAnimCurve = Ease.Linear;
    [Header("默认乘倍")] public int DoubleMachineDefaultMulti = 3;
    [Header("恢复默认状态时间")] public int DoubleMachineDefaultTime = 10;
    [Header("移动边界")] public int DoubleMachinePosLimit = 280;
    [Header("动画时间")] public float DoubleMachineAnimTime = 1f;

    [Space(20)]
    [Header("黑洞")]
    [Header("触发机台所需数量")] public int BlockHoleTarget = 50;
    [Header("外墙动画时间")] public float BlockHoleWallAnimTime = 1f;
    [Header("外墙动画停留时间")] public float BlockHoleWallAnimStayTime = 1f;
    [Header("外墙动画曲线")] public Ease BlockHoleWallAnimCurve = Ease.Linear;
    [Header("黑洞宝箱奖励系数")] public float BlockHoleChestRewardMulti = 1000;

    [Space(20)]
    [Header("场上物体小于N个后 补足至N个 (共50个)")] public int ReappearNum = 30;
    [Header("物体消除后重新出现时间")]
    [Header("普通模式")] public float ReappearTime = 1f;
    [Header("疯狂模式")] public float FeverReappearTime = .2f;

    [Space(20)]
    [Header("物体消除击中次数")]
    [Header("金币")] public int HitCount_Coin = 1;
    [Header("石头障碍")] public int HitCount_Rock = 99;
    [Header("弹性障碍")] public int HitCount_Bounce = 99;
    [Header("收集物A")] public int HitCount_CollectA = 3;
    [Header("收集物B")] public int HitCount_CollectB = 4;
    [Header("炸弹")] public int HitCount_Bomb = 3;
    [Header("分裂")] public int HitCount_Split = 3;
    [Header("转盘")] public int HitCount_Wheel = 1;
    [Header("钻石")] public int HitCount_Diamond = 4;
    [Header("大钻石")] public int HitCount_BigDiamond = 10;

    [Space(20)]
    [Header("物体出现时间")]
    [Header("收集物A")] public int ActiveTime_CollectA = 20;
    [Header("收集物B")] public int ActiveTime_CollectB = 15;
    [Header("转盘")] public int ActiveTime_Wheel = 60;

    [Space(20)]
    [Header("物体最大数量")]
    [Header("石头")] public int MaxNum_Rock = 2;
    [Header("弹性")] public int MaxNum_Bounce = 2;
    [Header("收集物A")] public int MaxNum_CollectA = 2;
    [Header("收集物B")] public int MaxNum_CollectB = 2;
    [Header("炸弹")] public int MaxNum_Bomb = 2;
    [Header("分裂")] public int MaxNum_Split = 2;
    [Header("转盘")] public int MaxNum_Wheel = 2;

    [Space(20)]
    [Header("物体刷新权重 （只有部分物体靠权重刷新）")]
    [Header("金币")] public int ItemWeight_Coin = 30;
    [Header("石头")] public int ItemWeight_Rock = 1;
    [Header("炸弹")] public int ItemWeight_Bomb = 1;
    [Header("分裂")] public int ItemWeight_Split = 1;
    [Header("钻石")] public int ItemWeight_Diamond = 10;

    [Space(20)]
    [Header("收集物位置")]
    [Header("收集物A")] public string CollectA_Pos = "上中";
    [Header("收集物B")] public string CollectB_Pos = "上中";

    [Space(20)]
    [Header("特殊物体")]
    [Header("炸弹范围")] public float BombRange = 1f;
    [Header("炸弹攻击力")] public int BombDamage = 10;
    [Header("分裂数量")] public int SplitCount = 5;
    [Header("分裂球发射力度")] public int SplitPower = 100;

    [Space(20)]
    [Header("掉球游戏")]
    [Header("初始球数量")] public int DropBallCount = 3;
    [Header("爪左右摇摆动画时间")] public int ClawRotateAnimTime = 2;
    [Header("掉球游戏的翻倍机")]
    [Header("移动边界")] public int DropBallDoubleMachinePosLimit = 400;
    [Header("乘倍")] public int[] DropBallDoubleMachineMultis;
    [Header("动画时间")] public float[] DropBallDoubleMachineAnimTime;
    [Header("弹板力度")] public int DropBallBouncePower = 5;

    [Space(20)]
    [Header("各类物理材质")]
    public PhysicsMaterial2D[] PhysicsMaterials;

    public void SetOnlineConfig() //部分数据使用后台配置
    {
        GameData gameData = WedSoulHue.Instance._RoomIraq;
        if (gameData != null)
        {
            BuyBallPrice = gameData.buyballprice;
            BuyBallNum = gameData.buyballnum;
            BuyBallUseCoinTime = gameData.buyball_usecointime;
            //FirstCoinNum = gameData.firstcoinnum;
            //AdBuyCoinNum = gameData.adbuycoinnum;
            BaseCoin = gameData.basereward_coin;
            BaseCoinRandomMin = (float)double.Parse(gameData.baserandom_coin.Split('#')[0], CultureInfo.InvariantCulture);
            BaseCoinRandomMax = (float)double.Parse(gameData.baserandom_coin.Split('#')[1], CultureInfo.InvariantCulture);
            BaseDiamond = (float)gameData.basereward_cash;
            BaseDiamondRandomMin = (float)double.Parse(gameData.baserandom_cash.Split('#')[0], CultureInfo.InvariantCulture);
            BaseDiamondRandomMax = (float)double.Parse(gameData.baserandom_cash.Split('#')[1], CultureInfo.InvariantCulture);
            CoinHitReward = (float)gameData.plinko_multi;
            //收集物
            if (gameData.collect_list != null)
            {
                for (int i = 0; i < gameData.collect_list.Count; i++)
                    SetOnlineConfig_Collect(gameData.collect_list[i].id, gameData.collect_list[i]);
            }
            //各种物体
            if (gameData.item_list != null)
            {
                for (int i = 0; i < gameData.item_list.Count; i++)
                    SetOnlineConfig_Item(gameData.item_list[i].id, gameData.item_list[i]);
            }
            //其余参数
            ClickDropBallGap = (float)gameData.click_drop_ball_gap;
            BlockHoleWallAnimTime = (float)gameData.block_wall_anim_time;
            BlockHoleWallAnimStayTime = (float)gameData.block_wall_stay_time;
            SlotWinWeight = (float)gameData.slot_win_weight;
            FirstBallNum = gameData.ball_count;
            BallNumRecoveryTime = gameData.ball_recover;
            DoubleMachineDefaultTime = gameData.split_lanch_time;
            FeverTime = gameData.fever_time;
            FeverNum = gameData.fever_count;
            FeverChestNum = gameData.fever_chest_count;
            BlockHoleChestRewardMulti = (float)gameData.jackpot_reward_multi;
            ReappearTime = gameData.supply_ball_time;
            ReappearNum = gameData.ball_less_total;
        }
    }
    void SetOnlineConfig_Collect(string collectName, CollectData data) //设置收集物配置
    {
        switch (collectName)
        {
            case "A":
                HitCount_CollectA = data.hp;
                ActiveTime_CollectA = data.cd;
                CollectA_Pos = data.position;
                MaxNum_CollectA = data.live_limit;
                break;
            case "B":
                HitCount_CollectB = data.hp;
                ActiveTime_CollectB = data.cd;
                CollectB_Pos = data.position;
                MaxNum_CollectB = data.live_limit;
                break;
        }
    }
    void SetOnlineConfig_Item(string itemName, ItemData data) //设置物体配置
    {
        switch (itemName)
        {
            case "币":
                HitCount_Coin = data.hp;
                ItemWeight_Coin = data.weight;
                break;
            case "石头":
                HitCount_Rock = data.hp;
                ItemWeight_Rock = data.weight;
                MaxNum_Rock = data.live_limit;
                break;
            case "弹性":
                HitCount_Bounce = data.hp;
                MaxNum_Bounce = data.live_limit;
                break;
            case "炸弹":
                HitCount_Bomb = data.hp;
                ItemWeight_Bomb = data.weight;
                MaxNum_Bomb = data.live_limit;
                break;
            case "分裂":
                HitCount_Split = data.hp;
                ItemWeight_Split = data.weight;
                MaxNum_Split = data.live_limit;
                break;
            case "转盘":
                HitCount_Wheel = data.hp;
                MaxNum_Wheel = data.live_limit;
                break;
            case "钻石":
                HitCount_Diamond = data.hp;
                ItemWeight_Diamond = data.weight;
                break;
            case "大钻石":
                HitCount_BigDiamond = data.hp;
                break;
        }
    }

    public float CountReward(RewardType Type, float Multi, bool IsUseRandom = true) //根据奖励系数和随机数计算奖励
    {
        if (Type == RewardType.Coin)
        {
            if (IsUseRandom)
                return (int)System.Math.Round(BaseCoin * Multi * GetCoinInitMulti() * Random.Range(BaseCoinRandomMin, BaseCoinRandomMax), 1);
            else
                return (int)System.Math.Round(BaseCoin * Multi, 1);
        }
        else
        {
            if (IsUseRandom)
                return (float)System.Math.Round(BaseDiamond * Multi  * GetCashInitMulti() * Random.Range(BaseDiamondRandomMin, BaseDiamondRandomMax), 1);
            else
                return (float)System.Math.Round(BaseDiamond * Multi, 1);
        }
    }
    public float GetTIpsReward() //弹出奖励提示
    {
        return (float)System.Math.Round((float)WedSoulHue.Instance._RoomIraq.break_multi * GetCashInitMulti() * (float)WedSoulHue.Instance._RoomIraq.basereward_cash * Random.Range(BaseDiamondRandomMin, BaseDiamondRandomMax), 1);
    }


    public double GetCashInitMulti() //获取现金倍数
    {
        return GetMulti((double)ZJT_Manager.AshForecast().GetMoney("JT_Money1"), WedSoulHue.Instance.WineIraq.cash_group);
    }
    public double GetCoinInitMulti() //获取金币倍数
    {
        return GetMulti((double)ZJT_Manager.AshForecast().GetMoney("JT_Money2"), WedSoulHue.Instance.WineIraq.gold_group);
    }

    private static double GetMulti(double cumulative, MultiGroup[] multiGroup)
    {
        foreach (MultiGroup item in multiGroup)
        {
            if (item.max > cumulative)
            {
                return item.multi;
            }
        }
        return 1;
    }
}



public enum ItemType
{
    Empty, // 空
    Coin, // 金币
    Rock, // 石头
    Bounce, // 弹性
    CollectA, // 收集物A
    CollectB, // 收集物B
    Bomb, // 炸弹
    Split, // 分裂
    Wheel, // 转盘
    Diamond, // 钻石
    BigDiamond, // 大钻石
}

public enum SlotBuffType // 老虎机buff类型
{
    DoubleMachine_Multi, // 翻倍机乘倍
    DoubleMachine_Length, // 翻倍机长度增加
    DoubleMachine_Stop, // 翻倍机动画停止
}

public enum ItemMoveType // 物体移动类型
{
    Line, // 横行水平移动
    Rotate, // 旋转
}

public enum RewardType
{
    Coin, // 金币
    Ball, // 球
    Diamond, // 钻石
}