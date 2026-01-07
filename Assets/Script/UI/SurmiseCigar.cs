using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using DG.Tweening;
using Coffee.UIExtensions;
using Spine.Unity;


/// <summary> 黑洞宝箱奖励 </summary>
public class SurmiseCigar : SakeUIDaddy
{
[UnityEngine.Serialization.FormerlySerializedAs("CoinText")]    public Text CapeDrug;
    float CapeUnless;
[UnityEngine.Serialization.FormerlySerializedAs("AdBtn")]    public Button ToPig;
[UnityEngine.Serialization.FormerlySerializedAs("GetBtn")]    public Button AshPig;
[UnityEngine.Serialization.FormerlySerializedAs("FinishEvent")]    public UnityAction FrightNewly;
[UnityEngine.Serialization.FormerlySerializedAs("Effect")]    public UIParticle Button;
[UnityEngine.Serialization.FormerlySerializedAs("CloseChest")]    public Sprite WispyAngle;
[UnityEngine.Serialization.FormerlySerializedAs("OpenChest")]    public Sprite AnewAngle;
[UnityEngine.Serialization.FormerlySerializedAs("ChestImages")]    public Image[] AngleRefute;
[UnityEngine.Serialization.FormerlySerializedAs("ChestSpines")]    public SkeletonGraphic[] AngleBarren;
[UnityEngine.Serialization.FormerlySerializedAs("Coins")]    public Transform[] Plumb;


    private void Start()
    {
        ToPig.onClick.AddListener(() =>
        {
            ShootHue.AshForecast().NormButton(ShootMuch.UIMusic.click);
            ADGrecian.Forecast.AmidUnlessRebel((ok) =>
            {
                if (ok)
                {
                    AshPig.transform.localScale = Vector3.zero;
                    ToPig.transform.localScale = Vector3.zero;
                    VisualizeConformity.FeebleGlassy(CapeUnless, CapeUnless * 2, 0, CapeDrug, null);
                    PestGrecian.AshForecast().Novel(1.5f, () =>
                    {
                        CapeUnless *= 2;
                        AshUnless();
                    });
                    SashNewlyBroker.AshForecast().VastNewly("1009", "1");
                }
            }, "7");
        });
        AshPig.onClick.AddListener(() =>
        {
            ShootHue.AshForecast().NormButton(ShootMuch.UIMusic.click);
            AshUnless();
            ADGrecian.Forecast.NoAssertPitImply();
            SashNewlyBroker.AshForecast().VastNewly("1009", "0");
        });
    }

    public override void Display(object OrPureDemise)
    {
        base.Display(OrPureDemise);
        Wine();
    }

    public void Wine()
    {
        CapeUnless = GameConfig.Instance.CountReward(RewardType.Diamond,GameConfig.Instance.BlockHoleChestRewardMulti);
        CapeDrug.text = "0";
        for (int i = 0; i < AngleRefute.Length; i++)
        {
            int Index = i;
            float OnceReward = (CapeUnless / AngleRefute.Length) * (Index + 1);
            AngleRefute[Index].sprite = WispyAngle;
            Plumb[Index].localPosition = Vector2.zero;
            Plumb[Index].localScale = Vector3.zero;
            AngleBarren[Index].PlayAnim("idle2", false);
            PestGrecian.AshForecast().Novel(1 + 0.3f * Index, () =>
            {
                //ChestImages[Index].sprite = OpenChest;
                AngleBarren[Index].PlayAnim("fire1", false);
                Plumb[Index].DOScale(Vector3.one, 0.2f).SetDelay(1.3f).OnStart(() =>
                {
                    ShootHue.AshForecast().NormButton(ShootMuch.UIMusic.open_chest);
                    VisualizeConformity.FeebleGlassy(0, OnceReward, 0.1f, CapeDrug, null);
                });
                Plumb[Index].DOLocalJump(new Vector2(0, 30), 100, 1, 0.2f).SetDelay(1.3f);
            });
        }
        ToPig.transform.localScale = Vector3.zero;
        AshPig.transform.localScale = Vector3.zero;
        PestGrecian.AshForecast().Novel(2, () =>
        {
            Button.Play();
            ShootHue.AshForecast().NormButton(ShootMuch.UIMusic.firework);
            ToPig.transform.DOScale(Vector3.one, 0.2f);
            AshPig.transform.DOScale(Vector3.one, 0.2f);
        });

        //ShootHue.GetInstance().PlayEffect(ShootMuch.UIMusic.SFX_BigWin);
    }

    void AshUnless()
    {
        RoomCigar.Instance.WispyCargoMuchUnless();
        RoomCigar.Instance.PitPlumb((int)CapeUnless);
        FrightNewly?.Invoke();
        FrightNewly = null;
        WispyUIPure(nameof(SurmiseCigar));
    }
}
