using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using DG.Tweening;
using Coffee.UIExtensions;
using TMPro;

/// <summary> 通用奖励面板 </summary>
public class UnlessCigar : SakeUIDaddy
{
[UnityEngine.Serialization.FormerlySerializedAs("RewardIcon_Coin")]    public GameObject UnlessDarn_Cape;
[UnityEngine.Serialization.FormerlySerializedAs("RewardIcon_Ball")]    public GameObject UnlessDarn_Hole;
[UnityEngine.Serialization.FormerlySerializedAs("RewardIcon_Diamond")]        public GameObject UnlessDarn_Magenta;
[UnityEngine.Serialization.FormerlySerializedAs("CoinText")]    public Text CapeDrug;
[UnityEngine.Serialization.FormerlySerializedAs("TMPCoinText")]    public TextMeshProUGUI TMPCapeDrug;
        RewardType _UnlessMuch;
    bool SteepByHole;
    float UnlessBuy;
[UnityEngine.Serialization.FormerlySerializedAs("AdAllBtn")]    public Button ToTowPig; //广告全额领奖按钮
[UnityEngine.Serialization.FormerlySerializedAs("GetHalfBtn")]    public Button AshDataPig; //一半奖励按钮
[UnityEngine.Serialization.FormerlySerializedAs("AdDoubleBtn")]    public Button ToEnzymePig; //广告双倍按钮
[UnityEngine.Serialization.FormerlySerializedAs("GetBtn")]    public Button AshPig; //全部奖励按钮
[UnityEngine.Serialization.FormerlySerializedAs("FinishEvent")]    public UnityAction FrightNewly;
[UnityEngine.Serialization.FormerlySerializedAs("Effect")]    public UIParticle Button;
    Coroutine NovelEvenAshPig;
    string OnEverestAD;
    string NewlyID;

    public TextMeshProUGUI TMPCash;
    void Start()
    {
        AshDataPig.onClick.AddListener(() =>
        {
            ShootHue.AshForecast().NormButton(ShootMuch.UIMusic.click);
            OnEverestAD = "0";
            UnlessBuy *= .3f;
            AshUnlessSkyVastNewlySkyWispy();
            ADGrecian.Forecast.NoAssertPitImply();
        });
        ToTowPig.onClick.AddListener(() =>
        {
            ShootHue.AshForecast().NormButton(ShootMuch.UIMusic.click);
            ADGrecian.Forecast.AmidUnlessRebel((ok) =>
            {
                if (ok)
                {
                    OnEverestAD = "1";
                    AshDataPig.transform.localScale = Vector3.zero;
                    ToTowPig.transform.localScale = Vector3.zero;
                    AshUnlessSkyVastNewlySkyWispy();
                }
            }, Ash9007ToSwing());
        });


        AshPig.onClick.AddListener(() =>
        {
            ShootHue.AshForecast().NormButton(ShootMuch.UIMusic.click);
            OnEverestAD = "0";
            AshUnlessSkyVastNewlySkyWispy();
            ADGrecian.Forecast.NoAssertPitImply();
        });
        ToEnzymePig.onClick.AddListener(() =>
        {
            ShootHue.AshForecast().NormButton(ShootMuch.UIMusic.click);
            ADGrecian.Forecast.AmidUnlessRebel((ok) =>
            {
                if (ok)
                {
                    OnEverestAD = "1";
                    AshPig.transform.localScale = Vector3.zero;
                    ToEnzymePig.transform.localScale = Vector3.zero;
                    VisualizeConformity.FeebleGlassy(UnlessBuy, UnlessBuy * 2, 0, CapeDrug, null);
                    if (TMPCapeDrug)
                        VisualizeConformity.FeebleGlassyTMP(UnlessBuy, UnlessBuy * 2, 0, TMPCapeDrug, null);
                    if (TMPCash)
                        VisualizeConformity.FeebleGlassyTMP(UnlessBuy, UnlessBuy * 2, 0, TMPCash, null);
                    UnlessBuy *= 2;
                    PestGrecian.AshForecast().Novel(1.5f, () =>
                    {
                        AshUnlessSkyVastNewlySkyWispy();
                    });
                }
            }, Ash9007ToSwing());
        });
    }

    /// <summary>奖励界面初始化 </summary>
    /// <param name="RewardNum"> 奖励数量 </param>
    /// <param name="MoneyOrBall"> true:金币 false:球 </param>
    /// <param name="IsAdDouble"> true:双倍 false:50% </param>
    /// <param name="FinishEvent"> 关闭事件 </param>
    /// <param name="EventID"> 打点ID </param>
       public void Wine(float RewardNum, RewardType rewardType, bool IsAdDouble, UnityAction FinishEvent, string EventID)
    {
        this.FrightNewly = FinishEvent;
        this.NewlyID = EventID;
        this.UnlessBuy = RewardNum;
        this._UnlessMuch = rewardType;
        if (ColumnStud.OnDaily() && this._UnlessMuch == RewardType.Diamond)
        {
            this._UnlessMuch = RewardType.Coin;

        }
        if (_UnlessMuch == RewardType.Coin)
        {
            UnlessDarn_Cape.SetActive(true);
            UnlessDarn_Hole.SetActive(false);
            UnlessDarn_Magenta.SetActive(false);
            TMPCapeDrug.gameObject.SetActive(true);
            TMPCash.gameObject.SetActive(false);
            CapeDrug.gameObject.SetActive(false);
        }
        else if (_UnlessMuch == RewardType.Ball)
        {
            UnlessDarn_Cape.SetActive(false);
            UnlessDarn_Hole.SetActive(true);
            UnlessDarn_Magenta.SetActive(false);
            TMPCapeDrug.gameObject.SetActive(false);
            TMPCash.gameObject.SetActive(false);
            CapeDrug.gameObject.SetActive(true);
        }
        else if (_UnlessMuch == RewardType.Diamond)
        {
            UnlessDarn_Cape.SetActive(false);
            UnlessDarn_Hole.SetActive(false);
            UnlessDarn_Magenta.SetActive(true);
            TMPCapeDrug.gameObject.SetActive(false);
            TMPCash.gameObject.SetActive(true);
            CapeDrug.gameObject.SetActive(false);
        }
        VisualizeConformity.FeebleGlassy(0, RewardNum, 0.1f, CapeDrug, null);

        if (TMPCapeDrug)
        {
            VisualizeConformity.FeebleGlassyTMP(0, RewardNum, 0.1f, TMPCapeDrug, null);
        }
        if (TMPCash)
        {
            VisualizeConformity.FeebleGlassyTMP(0, RewardNum, 0.1f, TMPCash, null);
        }

        if (IsAdDouble)
        {
            ToEnzymePig.transform.localScale = Vector3.one;
            AshPig.transform.localScale = Vector3.one;
            ToTowPig.transform.localScale = Vector3.zero;
            AshDataPig.transform.localScale = Vector3.zero;
        }
        else
        {
            ToTowPig.transform.localScale = Vector3.one;
            AshDataPig.transform.localScale = Vector3.one;
            ToEnzymePig.transform.localScale = Vector3.zero;
            AshPig.transform.localScale = Vector3.zero;
        }
        Button.Play();
        ShootHue.AshForecast().NormButton(ShootMuch.UIMusic.firework);
    }

    void AshUnlessSkyVastNewlySkyWispy()
    {
       if (_UnlessMuch == RewardType.Coin)
            RoomCigar.Instance.PitPlumb((int)UnlessBuy);
        else if (_UnlessMuch == RewardType.Ball)
            RoomCigar.Instance.PitHole((int)UnlessBuy);
        else if (_UnlessMuch == RewardType.Diamond)
            RoomCigar.Instance.PitMonarchy(UnlessBuy);
        FrightNewly?.Invoke();
        FrightNewly = null;
        WispyUIPure(nameof(UnlessCigar));
        SashNewlyBroker.AshForecast().VastNewly(NewlyID, OnEverestAD, UnlessBuy.ToString());
    }

    string Ash9007ToSwing()
    {
        if (NewlyID == "1006") return "5"; //飞行气泡
        if (NewlyID == "1008") return "9"; //slot现金奖励
        if (NewlyID == "1013") return "8"; //转盘
        return "0";
    }

}
