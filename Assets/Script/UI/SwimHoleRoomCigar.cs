using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

/// <summary> 松爪掉球游戏 </summary>
public class SwimHoleRoomCigar : SakeUIDaddy
{
    public static SwimHoleRoomCigar Instance; //单例
[UnityEngine.Serialization.FormerlySerializedAs("ClawBtn")]    public Button LifePig; //松开爪按钮
[UnityEngine.Serialization.FormerlySerializedAs("Claw")]    public Rigidbody2D Life;
[UnityEngine.Serialization.FormerlySerializedAs("LeftClaw")]    public Transform IbexLife; //左爪
[UnityEngine.Serialization.FormerlySerializedAs("RightClaw")]    public Transform LayerLife; //右爪

    int HoleImply;
[UnityEngine.Serialization.FormerlySerializedAs("BallCountText")]    public Text HoleImplyDrug; //球数文本
[UnityEngine.Serialization.FormerlySerializedAs("BallBornPos")]    public Transform HoleFrayTwo;
[UnityEngine.Serialization.FormerlySerializedAs("FirePos")]    public Transform MainTwo;
[UnityEngine.Serialization.FormerlySerializedAs("FirePower")]    public int MainAlloy= 100; //开火力度
    Transform AnLifeHole; //在爪子内的球
[UnityEngine.Serialization.FormerlySerializedAs("BallParent")]    public Transform HoleBeluga; //球父物体
    [HideInInspector] [UnityEngine.Serialization.FormerlySerializedAs("Balls")]public List<SwimHoleRoom_Hole> Steep= new List<SwimHoleRoom_Hole>(); //球列表
[UnityEngine.Serialization.FormerlySerializedAs("DoubleMachines")]
    public EnzymeSymptom[] EnzymeVascular; //翻倍机
[UnityEngine.Serialization.FormerlySerializedAs("Locks")]
    public Transform[] Magic; //锁
[UnityEngine.Serialization.FormerlySerializedAs("LockFirstPosY")]    public int PostCubicTwoY= -600; //锁初始位置
[UnityEngine.Serialization.FormerlySerializedAs("LockGapY")]    public int PostAndY= 200; //锁间距
    Text[] PostGlassyFaith; //锁数字
    Transform[] Cargo; //横线
    Transform[] Nebula; //箱子
[UnityEngine.Serialization.FormerlySerializedAs("UnLockNumber")]    public int[] MyPostGlassy; //解锁数量
    int NetPostSwing; //顶端锁索引
    int NetAugustGlassy;
    [HideInInspector] [UnityEngine.Serialization.FormerlySerializedAs("UnlockedNumber")]public int AlkalineGlassy; //已解锁数量
[UnityEngine.Serialization.FormerlySerializedAs("UnlockNumberText")]    public Text AugustGlassyDrug; //解锁数量文本


    private void Start()
    {
        Instance = this;
        LifePig.onClick.AddListener(() =>
        {
            ShootHue.AshForecast().NormButton(ShootMuch.UIMusic.click);
            MainHole();
        }); //添加松爪按钮点击事件监听
        //Claw.DORotate(new Vector3(0, 0, -40), GameConfig.Instance.ClawRotateAnimTime).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);

        for (int i = 0; i < EnzymeVascular.Length; i++)
        {
            if (i < 3)
                EnzymeVascular[i].Wine(false, GameConfig.Instance.DropBallDoubleMachineMultis[i], GameConfig.Instance.DropBallDoubleMachineAnimTime[i], HoleBeluga, true);
            else
                EnzymeVascular[i].Wine(false, GameConfig.Instance.DropBallDoubleMachineMultis[i], GameConfig.Instance.DropBallDoubleMachineAnimTime[i], HoleBeluga, false);
        }

        PostGlassyFaith = new Text[Magic.Length];
        Cargo = new Transform[Magic.Length];
        Nebula = new Transform[Magic.Length];
        for (int i = 0; i < Magic.Length; i++)
        {
            PostGlassyFaith[i] = Magic[i].Find("Text").GetComponent<Text>();
            PostGlassyFaith[i].text = MyPostGlassy[i].ToString();
            Cargo[i] = Magic[i].Find("横线");
            Nebula[i] = Magic[i].Find("宝箱");
        }
    }

    [Tooltip("摆动角度范围：-40到40度（Z轴）")]
[UnityEngine.Serialization.FormerlySerializedAs("minAngle")]    public float PegDecor= -40f;   // 左边界角度
[UnityEngine.Serialization.FormerlySerializedAs("maxAngle")]    public float HopDecor= 40f;    // 右边界角度
    [Tooltip("扭矩大小：控制摆动速度，值越大摆得越快")]
[UnityEngine.Serialization.FormerlySerializedAs("torqueForce")]    public float ConferTract= 5f;  // 扭矩力（根据钩爪质量调整）
    private void FixedUpdate()
    {
        // 根据当前角度切换扭矩方向
        float torque = 0f;
        if (Life.rotation >= HopDecor)
            torque = -ConferTract;
        else if (Life.rotation <= PegDecor)
            torque = ConferTract;
        else
            torque = Life.angularVelocity > 0 ? ConferTract : -ConferTract;
        Life.AddTorque(torque);
    }

    public void Wine()
    {
        Steep.Clear();
        HoleImply = GameConfig.Instance.DropBallCount;
        HoleImplyDrug.text = HoleImply.ToString();
        LifePig.gameObject.SetActive(false);
        FrayNetHole(); //生成顶端球

        NetPostSwing = 0;
        AlkalineGlassy = 0;
        AugustGlassyDrug.text = AlkalineGlassy.ToString();
        NetAugustGlassy = MyPostGlassy[NetPostSwing];
        for (int i = 0; i < Magic.Length; i++)
        {
            Magic[i].localPosition = new Vector2(0, PostCubicTwoY - i * PostAndY);
            Magic[i].gameObject.SetActive(true);
            if (PostGlassyFaith != null && PostGlassyFaith.Length > i)
                PostGlassyFaith[i].text = MyPostGlassy[i].ToString();
        }
    }

    bool TraitPatentHole() //检测场上是否还有激活的球
    {
        if (Steep.Count == 0)
            return false;

        foreach (var ball in Steep)
        {
            if (ball.gameObject.activeSelf)
                return true;
        }
        Steep.Clear();
        return false;
    }

    public void FrayNetHole() //生成在爪子内的顶端球
    {
        if (TraitPatentHole())
            return;
        if (HoleImply <= 0)
        {
            AnewUIPure(nameof(SwimHoleUnlessCigar));
            return;
        }

        HoleImply--;
        HoleImplyDrug.text = HoleImply.ToString();
        IbexLife.DOLocalRotate(Vector3.zero, 0.5f).SetEase(Ease.InBack); //左爪旋转
        LayerLife.DOLocalRotate(Vector3.zero, 0.5f).SetEase(Ease.InBack).OnComplete(() =>
        {
            SwimHoleRoom_Hole NewBall = ObjectPool.Instance.Get("松爪掉球_球").GetComponent<SwimHoleRoom_Hole>();
            AnLifeHole = NewBall.transform;
            NewBall.transform.SetParent(Life.transform);
            NewBall.transform.position = HoleFrayTwo.position;
            NewBall.transform.localScale = Vector3.one;
            Steep.Add(NewBall);
            LifePig.gameObject.SetActive(true);
        });
    }

    void MainHole()
    {
        LifePig.gameObject.SetActive(false);
        IbexLife.DOLocalRotate(new Vector3(0, 0, -45), 0.2f).SetEase(Ease.OutBack); //左爪旋转
        LayerLife.DOLocalRotate(new Vector3(0, 0, 45), 0.2f).SetEase(Ease.OutBack); //右爪旋转
        AnLifeHole.transform.SetParent(HoleBeluga);
        AnLifeHole.transform.localScale = Vector3.one;
    }

    public void PostPit()
    {
        if (NetAugustGlassy > 0)
        {
            NetAugustGlassy--;
            int NowLockIndex = NetPostSwing;
            PostGlassyFaith[NowLockIndex].text = NetAugustGlassy.ToString();
            Cargo[NowLockIndex].DOKill();
            Cargo[NowLockIndex].localPosition = Vector2.zero;
            Cargo[NowLockIndex].DOShakePosition(0.2f, 10);
            Nebula[NowLockIndex].DOKill();
            Nebula[NowLockIndex].localScale = Vector3.one;
            Nebula[NowLockIndex].DOScale(1.2f, 0.15f).SetLoops(2, LoopType.Yoyo);
        }
        else
        {
            AlkalineGlassy++;
            AugustGlassyDrug.text = AlkalineGlassy.ToString();
            Magic[NetPostSwing].gameObject.SetActive(false);
            NetPostSwing++;
            NetAugustGlassy = MyPostGlassy[NetPostSwing];
            for (int i = 0; i < Magic.Length; i++)
            {
                Magic[i].DOLocalMoveY(Magic[i].localPosition.y + 200, 0.5f).SetEase(Ease.OutBack);
            }
        }
    }
}
