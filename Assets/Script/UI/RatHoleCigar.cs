using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary> 买球面板  </summary>
public class RatHoleCigar : SakeUIDaddy
{
[UnityEngine.Serialization.FormerlySerializedAs("AdGetBtn")]    public Button ToAshPig;
[UnityEngine.Serialization.FormerlySerializedAs("CoinGetBtn")]    public Button CapeAshPig;
[UnityEngine.Serialization.FormerlySerializedAs("NumberText")]    public Text GlassyDrug;
[UnityEngine.Serialization.FormerlySerializedAs("NumberTMPText")]    public TextMeshProUGUI GlassyTMPDrug;
[UnityEngine.Serialization.FormerlySerializedAs("CloseBtn")]    public Button WispyPig;
[UnityEngine.Serialization.FormerlySerializedAs("CoinGet")]    public TextMeshProUGUI CapeAsh;

    private void Start()
    {
        ToAshPig.onClick.AddListener(() =>
        {
            ShootHue.AshForecast().NormButton(ShootMuch.UIMusic.click);
            ADGrecian.Forecast.AmidUnlessRebel((ok) =>
            {
                if (ok)
                {
                    AshUnless();
                    SashNewlyBroker.AshForecast().VastNewly("1007", "1");
                }
            }, "6");
        });
        CapeAshPig.onClick.AddListener(() =>
        {
            ShootHue.AshForecast().NormButton(ShootMuch.UIMusic.click);
            if (RoomCigar.Instance.CapeBuy >= GameConfig.Instance.BuyBallPrice)
            {
                RoomCigar.Instance.ImplyCape(-GameConfig.Instance.BuyBallPrice);
                AshUnless();
            }
        });
        WispyPig.onClick.AddListener(() =>
        {
            ShootHue.AshForecast().NormButton(ShootMuch.UIMusic.click);
            Wispy();
            SashNewlyBroker.AshForecast().VastNewly("1007", "0");
        });
    }

    public override void Display(object OrPureDemise)
    {
        base.Display(OrPureDemise);
        GlassyDrug.text = "ADD " + GameConfig.Instance.BuyBallNum + " BAllS";
        if (GlassyTMPDrug)
        {
            GlassyTMPDrug.text  = "ADD " + GameConfig.Instance.BuyBallNum + " BAllS";
        }
        //检查距离上次买球过了多长时间 大于规定时间用金币
        bool AdOrCoin = true;
        string LastBuyBallTime = PlayerPrefs.GetString("LastBuyBallTime", "0");
        long LastBuyBallTimeStamp = long.Parse(LastBuyBallTime);
        if (PestGrecian.AshForecast().AshHairPestLover() - LastBuyBallTimeStamp >= GameConfig.Instance.BuyBallUseCoinTime)
            AdOrCoin = false;
        if (RoomCigar.Instance.CapeBuy < GameConfig.Instance.BuyBallPrice)
            AdOrCoin = true;

        if (AdOrCoin)
        {
            ToAshPig.gameObject.SetActive(true);
            CapeAshPig.gameObject.SetActive(false);
        }
        else
        {
            ToAshPig.gameObject.SetActive(false);
            CapeAshPig.gameObject.SetActive(true);
            // CoinGetBtn.GetComponentInChildren<Text>().text = GameConfig.Instance.BuyBallPrice.ToString();
            CapeAsh.text = GameConfig.Instance.BuyBallPrice.ToString();
        }
    }

    void AshUnless()
    {
        WispyUIPure(nameof(RatHoleCigar));
        RoomCigar.Instance.MyRoomBeach(() =>
        {
            RoomCigar.Instance.PitHole(GameConfig.Instance.BuyBallNum);
            //RoomCigar.Instance.AddCoins(GameConfig.Instance.AdBuyCoinNum);

            //记录这次买球的时间戳
            PlayerPrefs.SetString("LastBuyBallTime", PestGrecian.AshForecast().AshHairPestLover().ToString());
        });
    }

    void Wispy()
    {
        WispyUIPure(nameof(RatHoleCigar));
        RoomCigar.Instance.MyRoomBeach();
        ADGrecian.Forecast.NoAssertPitImply();
    }
}
