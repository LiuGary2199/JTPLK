using Coffee.UIExtensions;
using DG.Tweening;
using Spine.Unity;
using UnityEngine;
using UnityEngine.UI;

/// <summary>  </summary>
public class Home : MonoBehaviour
{
    //0 空 1 金币 2 石头 3 弹性 4 收集物A 5 收集物B 6 收集物C 7 炸弹 8 分裂 9 转盘  10 钻石
    [HideInInspector] [UnityEngine.Serialization.FormerlySerializedAs("Type")]public ItemType Much;
    [HideInInspector] [UnityEngine.Serialization.FormerlySerializedAs("HitCount")]public int HotImply;
    Coroutine NovelWineIE;
[UnityEngine.Serialization.FormerlySerializedAs("Icons")]    public GameObject[] Group;
[UnityEngine.Serialization.FormerlySerializedAs("BombSpine")]    public SkeletonGraphic RoamDouse;
    [HideInInspector] [UnityEngine.Serialization.FormerlySerializedAs("BombAddedRange")]public float RoamCliffLease; //炸弹额外范围
[UnityEngine.Serialization.FormerlySerializedAs("InitEffect")]    public UIParticle WineButton;
[UnityEngine.Serialization.FormerlySerializedAs("RefreshEffect")]    public UIParticle CrystalButton;
[UnityEngine.Serialization.FormerlySerializedAs("DieEffect")]    public UIParticle TooButton;
[UnityEngine.Serialization.FormerlySerializedAs("HitEffect")]    public UIParticle HotButton;
[UnityEngine.Serialization.FormerlySerializedAs("FeverHitEffect")]    public UIParticle WhaleHotButton;
[UnityEngine.Serialization.FormerlySerializedAs("CoinImage")]    public Image CapeStorm;
[UnityEngine.Serialization.FormerlySerializedAs("DiamondImage")]    public Image MagentaStorm;
[UnityEngine.Serialization.FormerlySerializedAs("CollectAImage")]    public Image MethaneAStorm;
[UnityEngine.Serialization.FormerlySerializedAs("CollectBImage")]    public Image MethaneBStorm;
    float HotUnlessBuy; //被击中奖励
    float TooUnlessBuy; //消掉奖励


    public void Wine(ItemType TargetType)
    {
        if (NovelWineIE != null)
        {
            PestGrecian.AshForecast().AkinNovel(NovelWineIE);
            NovelWineIE = null;
        }
        transform.DOKill();
        transform.localScale = Vector3.one;
        HotImply = 0;
        Much = TargetType;
        for (int i = 0; i < Group.Length; i++)
            Group[i].SetActive(false);
        if (TargetType == ItemType.Empty)
            return;

        Group[(int)TargetType - 1].SetActive(true);
        WineButton.Play();
        switch (Much)
        {
            case ItemType.Coin:
                HotImply = GameConfig.Instance.HitCount_Coin;
                CapeStorm.color = Color.white;
                HotUnlessBuy = GameConfig.Instance.CountReward(RewardType.Coin, GameConfig.Instance.CoinHitReward);
                HotUnlessBuy = Mathf.Max(1, HotUnlessBuy);
                TooUnlessBuy = HotUnlessBuy * 2;
                break;
            case ItemType.Rock:
                HotImply = GameConfig.Instance.HitCount_Rock;
                break;
            case ItemType.Bounce:
                HotImply = GameConfig.Instance.HitCount_Bounce;
                break;
            case ItemType.CollectA:
                HotImply = GameConfig.Instance.HitCount_CollectA;
                MethaneAStorm.color = Color.white;
                break;
            case ItemType.CollectB:
                HotImply = GameConfig.Instance.HitCount_CollectB;
                MethaneBStorm.color = Color.white;
                break;
            case ItemType.Bomb:
                HotImply = GameConfig.Instance.HitCount_Bomb;
                RoamDouse.PlayAnim("1", true);
                RoamCliffLease = 0;
                break;
            case ItemType.Split:
                HotImply = GameConfig.Instance.HitCount_Split;
                break;
            case ItemType.Wheel:
                HotImply = GameConfig.Instance.HitCount_Wheel;
                break;
            case ItemType.Diamond:
                HotImply = GameConfig.Instance.HitCount_Diamond;
                MagentaStorm.color = Color.white;
                HotUnlessBuy = GameConfig.Instance.CountReward(RewardType.Diamond, GameConfig.Instance.DiamondHitReward);
                TooUnlessBuy = HotUnlessBuy * 2;
                break;
            case ItemType.BigDiamond:
                HotImply = GameConfig.Instance.HitCount_BigDiamond;
                MagentaStorm.color = Color.white;
                HotUnlessBuy = GameConfig.Instance.CountReward(RewardType.Diamond, GameConfig.Instance.DiamondHitReward);
                HotUnlessBuy *= 5;
                TooUnlessBuy = HotUnlessBuy * 2;
                break;
        }
    }
    public void NormCrystalButton()
    {
        CrystalButton.Play();
    }

    public ItemType AshHomeMuch() //生成规则 由位置 计时 概率等综合决定
    {
        // 疯狂模式下只生成金币和炸弹
        if (RoomCigar.Instance.OnWhaleTall)
        {
            int TotalWeightInFeverMode = GameConfig.Instance.ItemWeight_Coin + GameConfig.Instance.ItemWeight_Bomb;
            int RandomValueInFeverMode = Random.Range(0, TotalWeightInFeverMode);
            if (RandomValueInFeverMode < GameConfig.Instance.ItemWeight_Coin)
                return (ItemType)1;
            else
                return (ItemType)7;
        }

        // 根据权重生成Type
        // 0空 1 金币 2 石头 3 弹性 4 收集物A 5 收集物B  6 炸弹 7 分裂 8 转盘 9 钻石 10 大钻石
        int[] Indexs = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        int cashweith = GameConfig.Instance.ItemWeight_Diamond; // 9 钻石
        if (ColumnStud.OnDaily())
        {
            cashweith = 0;//审核期间关闭钻石产出
        }

        int[] Weights =
        {
            0, // 0 空
            GameConfig.Instance.ItemWeight_Coin, // 1 金币
            GameConfig.Instance.ItemWeight_Rock, // 2 石头
            0, // 3 弹性
            0, // 4 收集物A
            0, // 5 收集物B
            GameConfig.Instance.ItemWeight_Bomb, // 6 炸弹
            GameConfig.Instance.ItemWeight_Split, // 7 分裂
            0, // 8 转盘
           cashweith, // 9 钻石
            0, // 10 大钻石
        };

        // 超过最大数量时概率修正
        int RockNum = RoomCigar.Instance.AshMuchBuyAnHumor(ItemType.Rock);
        int BombCount = RoomCigar.Instance.AshMuchBuyAnHumor(ItemType.Bomb);
        int SplitCount = RoomCigar.Instance.AshMuchBuyAnHumor(ItemType.Split);
        if (RockNum >= GameConfig.Instance.MaxNum_Rock)
            Weights[2] = 0;
        if (BombCount >= GameConfig.Instance.MaxNum_Bomb)
            Weights[7] = 0;
        if (SplitCount >= GameConfig.Instance.MaxNum_Split)
            Weights[8] = 0;

        // 计算权重总和
        int totalWeight = 0;
        foreach (int weight in Weights)
            totalWeight += weight;
        // 生成0到总权重之间的随机数
        int randomValue = Random.Range(0, totalWeight);
        // 根据随机数落在的权重区间选择对应的索引
        int currentWeight = 0;
        for (int i = 0; i < Weights.Length; i++)
        {
            currentWeight += Weights[i];
            if (randomValue < currentWeight)
                return (ItemType)Indexs[i];
        }
        return (ItemType)1;
    }

    public void Hot(int Damage = 1, bool IsBounceBall = false)
    {
        // 单次被击实际造成的伤害 用来计算本次应获得的奖励
        int OnceHitValue = Mathf.Min(Damage, HotImply);

        HotImply -= Damage;
        // 被击缩放效果
        transform.DOKill();
        transform.localScale = Vector3.one;
        if (Much != ItemType.Rock)
        {
            float Scale = 0.7f;
            if (Much == ItemType.Bomb)
                Scale = 0.5f;
            else if (Much == ItemType.CollectA || Much == ItemType.CollectB)
                Scale = 0.9f;
            if (!RoomCigar.Instance.OnWhaleTall)
                transform.DOScale(Scale, 0.05f).SetLoops(2, LoopType.Yoyo);
        }
        if (Much != ItemType.Rock && Much != ItemType.Bounce)
        {
            if (!RoomCigar.Instance.OnWhaleTall)
                HotButton.Play();
            else
                WhaleHotButton.Play();
        }
        ShootHue.AshForecast().NormTraffic(Lofelt.NiceVibrations.HapticPatterns.PresetType.LightImpact);
        // 被消掉 触发各种效果
        if (HotImply <= 0)
        {
            RoomCigar.Instance.WhalePit();
            ShootHue.AshForecast().NormTraffic(Lofelt.NiceVibrations.HapticPatterns.PresetType.HeavyImpact);
            switch (Much)
            {
                case ItemType.Coin:
                    AshUnless(true, OnceHitValue, true);
                    TooButton.Play();
                    ShootHue.AshForecast().NormButton(ShootMuch.UIMusic.coin_broken);
                    break;
                case ItemType.Rock:
                    TooButton.Play();
                    break;
                case ItemType.Bounce:
                    TooButton.Play();
                    break;
                case ItemType.CollectA:
                    Methane();
                    ShootHue.AshForecast().NormButton(ShootMuch.UIMusic.hit_collect);
                    break;
                case ItemType.CollectB:
                    Methane();
                    ShootHue.AshForecast().NormButton(ShootMuch.UIMusic.hit_collect);
                    break;
                case ItemType.Bomb:
                    Roam(Damage);
                    break;
                case ItemType.Split:
                    Novel(IsBounceBall);
                    TooButton.Play();
                    ShootHue.AshForecast().NormButton(ShootMuch.UIMusic.strike_right);
                    break;
                case ItemType.Wheel:
                    Tinge();
                    ShootHue.AshForecast().NormButton(ShootMuch.UIMusic.lanch_wheel);
                    break;
                case ItemType.Diamond:
                    AshUnless(true, OnceHitValue, false);
                    TooButton.Play();
                    ShootHue.AshForecast().NormButton(ShootMuch.UIMusic.coin_broken);
                    break;
                case ItemType.BigDiamond:
                    AshUnless(true, OnceHitValue, false);
                    TooButton.Play();
                    ShootHue.AshForecast().NormButton(ShootMuch.UIMusic.coin_broken);
                    break;
            }

            // 隐藏 等CD重置
            Wine(ItemType.Empty);
            float CD = GameConfig.Instance.ReappearTime;
            if (RoomCigar.Instance.OnWhaleTall)
                CD = GameConfig.Instance.FeverReappearTime;
            NovelWineIE = PestGrecian.AshForecast().Novel_SoloBeach(CD, () =>
            {
                if (Much == ItemType.Empty)
                    Wine(AshHomeMuch());
                NovelWineIE = null;
            });
        }
        else //击中时一些物体的特殊表现
        {
            switch (Much)
            {
                case ItemType.Coin:
                    int Fade = 255 - (GameConfig.Instance.HitCount_Coin - HotImply) * 38;
                    CapeStorm.color = new Color32(255, 255, 255, (byte)Fade);
                    AshUnless(false, OnceHitValue, true);
                    ShootHue.AshForecast().NormButton(ShootMuch.UIMusic.hit_coin);
                    break;
                case ItemType.Rock:
                    ShootHue.AshForecast().NormButton(ShootMuch.UIMusic.hit_stone);
                    break;
                case ItemType.Bounce:
                    ShootHue.AshForecast().NormButton(ShootMuch.UIMusic.hit_bounce);
                    break;
                case ItemType.CollectA:
                    int FadeA = 255 - (GameConfig.Instance.HitCount_CollectA - HotImply) * 38;
                    MethaneAStorm.color = new Color32(255, 255, 255, (byte)FadeA);
                    ShootHue.AshForecast().NormButton(ShootMuch.UIMusic.hit_collect);
                    break;
                case ItemType.CollectB:
                    int FadeB = 255 - (GameConfig.Instance.HitCount_CollectB - HotImply) * 38;
                    MethaneBStorm.color = new Color32(255, 255, 255, (byte)FadeB);
                    ShootHue.AshForecast().NormButton(ShootMuch.UIMusic.hit_collect);
                    break;
                case ItemType.Bomb:
                    RoamDouse.PlayAnim((6 - HotImply).ToString(), true);
                    ShootHue.AshForecast().NormButton(ShootMuch.UIMusic.strike_right);
                    break;
                case ItemType.Split:
                    ShootHue.AshForecast().NormButton(ShootMuch.UIMusic.strike_right);
                    break;
                case ItemType.Wheel:
                    ShootHue.AshForecast().NormButton(ShootMuch.UIMusic.strike_right);
                    break;
                case ItemType.Diamond:
                    int Fade_D = 255 - (GameConfig.Instance.HitCount_Diamond - HotImply) * 38;
                    MagentaStorm.color = new Color32(255, 255, 255, (byte)Fade_D);
                    AshUnless(false, OnceHitValue, false);
                    ShootHue.AshForecast().NormButton(ShootMuch.UIMusic.hit_coin);
                    break;
                case ItemType.BigDiamond:
                    int Fade_B = 255 - (GameConfig.Instance.HitCount_Diamond - HotImply) * 38;
                    MagentaStorm.color = new Color32(255, 255, 255, (byte)Fade_B);
                    AshUnless(false, OnceHitValue, false);
                    ShootHue.AshForecast().NormButton(ShootMuch.UIMusic.hit_coin);
                    break;
            }
        }
    }

    void AshUnless(bool IsBreak, int OnceHitValue, bool CoinOrDiamond)
    {
        float UnlessBuy= OnceHitValue * HotUnlessBuy;
        if (IsBreak)
            UnlessBuy += TooUnlessBuy;
        if (CoinOrDiamond)
        {
            if (ColumnStud.OnDaily())
            {
                RoomCigar.Instance.PitHomeMagenta(UnlessBuy, transform.position);
            }
            else
            {
                RoomCigar.Instance.PitHomeCape(UnlessBuy, transform.position);
            }
        }
        else 
        {
            RoomCigar.Instance.PitHomeMagenta(UnlessBuy, transform.position);
        }
    }

    void Methane() // 收集物效果
    {
        RoomCigar.Instance.MethanePit(Much, transform.position);
    }

    void Roam(int Damage) // 炸弹效果
    {
        Much = ItemType.Empty; //相邻炸弹会互相检测导致卡死 需要及时重置本身Type
        if (Damage == GameConfig.Instance.BombDamage) //如果受到伤害为炸弹伤害 说明此炸弹由其他炸弹触发 延时爆炸做出连锁效果
            PestGrecian.AshForecast().Novel(0.3f, () => { RoamCleaner(); });
        else //如果受到伤害不为炸弹伤害 说明此炸弹由球触发 立即爆炸
            RoamCleaner();
    }
    void RoamCleaner() // 炸弹爆炸
    {
        Home[] Humor= transform.parent.parent.GetComponentsInChildren<Home>();
        for (int i = 0; i < Humor.Length; i++)
        {
            float Distance = Vector2.Distance(transform.position, Humor[i].transform.position);
            if (Humor[i].Much != ItemType.Empty && Humor[i] != transform && Distance > 0 && Distance < (GameConfig.Instance.BombRange + RoamCliffLease))
                Humor[i].Hot(GameConfig.Instance.BombDamage);
        }
        GameObject Button= ObjectPool.Instance.Get("炸弹特效");
        Button.transform.SetParent(UIGrecian.AshForecast()._TieMatrix);
        Button.transform.localScale = Vector3.one;
        Button.transform.position = transform.position;
        PestGrecian.AshForecast().Novel(2, () =>
        {
            ObjectPool.Instance.Return("炸弹特效", Button);
        });
        ShootHue.AshForecast().NormTraffic(Lofelt.NiceVibrations.HapticPatterns.PresetType.HeavyImpact);
        ShootHue.AshForecast().NormButton(ShootMuch.UIMusic.bomb);
        RoamDouse.StopAnim();
        // 调试用 显示炸弹范围
        if (Application.platform == RuntimePlatform.WindowsEditor)
            EvenRoamLease();
    }
    void EvenRoamLease() // 调试用 显示炸弹范围
    {
        float Sense= GameConfig.Instance.BombRange + RoamCliffLease;
        Color color = Color.red;
        float duration = 3f;
        int segments = 36; // 圆的细分段数，数值越大越平滑
        float radius = Sense;
        Vector3 position = transform.position;

        for (int i = 0; i < segments; i++)
        {
            float angle = i * Mathf.PI * 2 / segments;
            Vector3 start = position + new Vector3(Mathf.Sin(angle) * radius, Mathf.Cos(angle) * radius, 0);
            Vector3 end = position + new Vector3(Mathf.Sin(angle + Mathf.PI * 2 / segments) * radius, Mathf.Cos(angle + Mathf.PI * 2 / segments) * radius, 0);
            Debug.DrawLine(start, end, color, duration);
        }
    }

    void Novel(bool IsBounceBall) // 分裂效果
    {
        for (int i = 0; i < GameConfig.Instance.SplitCount; i++)
        {
            GameObject NewBall = ObjectPool.Instance.Get("球");
            NewBall.transform.SetParent(RoomCigar.Instance.HoleBeluga);
            NewBall.transform.localScale = Vector3.one;
            NewBall.transform.position = transform.position;
            Vector3 GoTwo= transform.position;
            GoTwo.y += 1;
            GoTwo.x += Random.Range(-.5f, .5f);
            Vector2 ForceDirection = (GoTwo - transform.position).normalized;
            NewBall.GetComponent<Rigidbody2D>().AddForce(ForceDirection * GameConfig.Instance.SplitPower);
            if (IsBounceBall)
                NewBall.GetComponent<Hole>().GelBackup();
        }
    }

    void Tinge() // 转盘
    {
        //测试
        if (GameConfig.Instance.TestMode)
            return;

        RoomCigar.Instance.RoomBeach();
        SkeletonGraphic TingeHomeDouse= RoomCigar.Instance.TingeHomeDouse;
        TingeHomeDouse.gameObject.SetActive(true);
        TingeHomeDouse.transform.position = transform.position;
        TingeHomeDouse.PlayAnim("hit", true);
        TingeHomeDouse.transform.DOMove(Vector2.zero, .5f).SetDelay(1).OnComplete(() =>
        {
            TingeHomeDouse.StopAnim();
            TingeHomeDouse.gameObject.SetActive(false);
            UIGrecian.AshForecast().EvenUIDaddy(nameof(TingeCigar));
        });
    }
}
