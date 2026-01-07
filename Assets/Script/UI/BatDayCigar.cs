using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using Spine.Unity;
using DG.Tweening;
using TMPro;

/// <summary> 奖励面板 </summary>
public class BatDayCigar : SakeUIDaddy
{
    [UnityEngine.Serialization.FormerlySerializedAs("TitleSpine")] public SkeletonGraphic ProwlDouse;
    [UnityEngine.Serialization.FormerlySerializedAs("RewardIcon")] public Transform UnlessDarn;
    [UnityEngine.Serialization.FormerlySerializedAs("RewardIconImage")] public Image UnlessDarnStorm;
    [UnityEngine.Serialization.FormerlySerializedAs("RewardIconImage1")] public GameObject UnlessDarnStorm1;
    [UnityEngine.Serialization.FormerlySerializedAs("Lights")] public Image[] Teapot;
    [UnityEngine.Serialization.FormerlySerializedAs("DiamondText")] public Text MagentaDrug;
    [UnityEngine.Serialization.FormerlySerializedAs("DiamondTextUgui")] public TextMeshProUGUI MagentaDrugWire;
    float MagentaUnless;
    [UnityEngine.Serialization.FormerlySerializedAs("LeftToCenterTransforms")] public Transform[] IbexGoStenchPlaywright;
    [UnityEngine.Serialization.FormerlySerializedAs("AdBtn")] public Button ToPig;
    [UnityEngine.Serialization.FormerlySerializedAs("GetBtn")] public Button AshPig;
    [UnityEngine.Serialization.FormerlySerializedAs("FinishEvent")] public UnityAction FrightNewly;
    [UnityEngine.Serialization.FormerlySerializedAs("m_ParticleIn")]
    public GameObject m_PharmacyAn;
    [UnityEngine.Serialization.FormerlySerializedAs("Coinobj")]
    public GameObject Various;
    [UnityEngine.Serialization.FormerlySerializedAs("Cashobj")] public GameObject Rebirth;


    public GameObject coinObj;
    public GameObject cashObj;
    public Transform FLy;


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
                    VisualizeConformity.FeebleGlassy(MagentaUnless, MagentaUnless * 3, 0, MagentaDrug, null);
                    if (MagentaDrugWire)
                    {
                        VisualizeConformity.FeebleGlassyTMP(MagentaUnless, MagentaUnless * 3, 0, MagentaDrugWire, null);
                    }
                    PestGrecian.AshForecast().Novel(1.5f, () =>
                    {
                        MagentaUnless *= 3;
                        AshUnless();
                    });
                }
                SashNewlyBroker.AshForecast().VastNewly("1005", "1");
            }, "4");
        });
        AshPig.onClick.AddListener(() =>
        {
            ShootHue.AshForecast().NormButton(ShootMuch.UIMusic.click);
            AshUnless();
            ADGrecian.Forecast.NoAssertPitImply();
            SashNewlyBroker.AshForecast().VastNewly("1005", "0");
        });
    }

    public void Wine(float DiamondNum, UnityAction FinishEvent)
    {
        ZJT_Manager.AshForecast().AddTaskValue("Bigwin", 1);
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
        this.FrightNewly = FinishEvent;
        MagentaUnless = DiamondNum;
        MagentaDrug.text = DiamondNum.ToString();
        if (MagentaDrugWire)
        {
            MagentaDrugWire.text = DiamondNum.ToString();
        }

        ProwlDouse.gameObject.SetActive(false);
        m_PharmacyAn.SetActive(false);
        coinObj.SetActive(false);
        cashObj.SetActive(false);
        UnlessDarnStorm.enabled = true;
        UnlessDarnStorm1.SetActive(false);
        UnlessDarnStorm1.transform.localScale = Vector3.zero;
        for (int i = 0; i < IbexGoStenchPlaywright.Length; i++)
            IbexGoStenchPlaywright[i].localPosition = new Vector2(-1000, IbexGoStenchPlaywright[i].localPosition.y);
        ShootHue.AshForecast().NormButton(ShootMuch.UIMusic.lanch_wheel);
        AshPig.transform.localScale = Vector3.one;
        ToPig.transform.localScale = Vector3.one;
        // 灯交替闪
        for (int i = 0; i < Teapot.Length; i++)
            Teapot[i].color = new Color(1, 1, 1, 0);
        int[] LightGroup1 = { 0 };
        int[] LightGroup2 = { 1 };
        for (int i = 0; i < LightGroup1.Length; i++)
            Teapot[LightGroup1[i]].DOFade(1, 0.1f).SetLoops(8, LoopType.Yoyo).SetEase(Ease.Linear);
        for (int i = 0; i < LightGroup2.Length; i++)
            Teapot[LightGroup2[i]].DOFade(1, 0.1f).SetLoops(8, LoopType.Yoyo).SetDelay(0.02f).SetEase(Ease.Linear);

        // 图标飞入
        FLy.GetComponent<RectTransform>().anchoredPosition = new Vector2(-435.8f, 464.7f);
        //   UnlessDarn.localPosition = new Vector2(-460, 464.7f);
        FLy.DOLocalMove(new Vector2(-35.91f, -136.5f), .5f).SetDelay(1).SetEase(Ease.OutBack);
        UnlessDarn.localScale = Vector3.one * .35f;
        UnlessDarn.DOScale(Vector3.one * 1.2f, .5f).SetDelay(1).OnComplete(() =>
        {
            UnlessDarnStorm1.SetActive(true);
            UnlessDarnStorm1.transform.DOScale(Vector3.one, .3f).SetEase(Ease.OutBack);
        });

        // 隐藏背景
        PestGrecian.AshForecast().Novel(1f, () =>
        {
            UnlessDarnStorm.enabled = false;

            for (int i = 0; i < Teapot.Length; i++)
            {
                Teapot[i].DOKill();
                Teapot[i].color = new Color(1, 1, 1, 0);
            }
        });
        // 标题spine
        PestGrecian.AshForecast().Novel(1.5f, () =>
        {
            ProwlDouse.gameObject.SetActive(true);
            ProwlDouse.PlayAnim("bigwin_in", false);
            m_PharmacyAn.SetActive(true);
            if (ColumnStud.OnDaily())
            {
                coinObj.SetActive(true);
                cashObj.SetActive(false);
            }
            else
            {
                coinObj.SetActive(false);
                cashObj.SetActive(true);
            }

            ShootHue.AshForecast().NormButton(ShootMuch.UIMusic.big_win);
        });
        // 其他东西飞入
        PestGrecian.AshForecast().Novel(2f, () =>
        {
            ProwlDouse.PlayAnim("bigwin_idle", true);
            for (int i = 0; i < IbexGoStenchPlaywright.Length; i++)
                IbexGoStenchPlaywright[i].DOLocalMoveX(0, .5f).SetDelay(i * 0.1f).SetEase(Ease.OutBack);
        });
    }

    void AshUnless()
    {
        ProwlDouse.StopAnim();
        if (ColumnStud.OnDaily())
        {
            RoomCigar.Instance.PitPlumb((int)MagentaUnless);
        }
        else
        {
            RoomCigar.Instance.PitMonarchy(MagentaUnless);
        }
        FrightNewly?.Invoke();
        FrightNewly = null;
        WispyUIPure(nameof(BatDayCigar));
    }
}
