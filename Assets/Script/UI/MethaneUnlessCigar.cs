using System.Collections;
using System.Collections.Generic;
using Coffee.UIExtensions;
using DG.Tweening;
using Spine.Unity;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary> 收集物奖励面板 </summary>
public class MethaneUnlessCigar : SakeUIDaddy
{
    ItemType Much;
[UnityEngine.Serialization.FormerlySerializedAs("As")]    public GameObject[] Ox;
[UnityEngine.Serialization.FormerlySerializedAs("Bs")]    public GameObject[] ID;
[UnityEngine.Serialization.FormerlySerializedAs("ScaleGos")]    public Transform[] CeaseAsk; //参与缩放动画的物体
[UnityEngine.Serialization.FormerlySerializedAs("EnterGo")]    public Transform FiordNo;
[UnityEngine.Serialization.FormerlySerializedAs("TitleSpine")]    public SkeletonGraphic ProwlDouse;
[UnityEngine.Serialization.FormerlySerializedAs("Effect")]    public UIParticle Button;
[UnityEngine.Serialization.FormerlySerializedAs("AdBtn")]    public Button ToPig;
[UnityEngine.Serialization.FormerlySerializedAs("GetBtn")]    public Button AshPig;
    float UnlessBuy;
[UnityEngine.Serialization.FormerlySerializedAs("RewardNumText")]    public Text UnlessBuyDrug;
    string NewlyID;
    string To9007Swing;
[UnityEngine.Serialization.FormerlySerializedAs("RewardTmpText")]    public TextMeshProUGUI UnlessHayDrug;
[UnityEngine.Serialization.FormerlySerializedAs("m_ParticleIn")]
    public GameObject m_PharmacyAn;

    public TextMeshProUGUI CashUgui;

    public GameObject coinObj;
    public GameObject cashObj;
    public GameObject coinimg;
    public GameObject cashimg;
    public GameObject coinbj;
    public GameObject cashbj;
    private void Start()
    {
        AshPig.onClick.AddListener(() =>
        {
            ShootHue.AshForecast().NormButton(ShootMuch.UIMusic.click);
            AshUnless();
            ADGrecian.Forecast.NoAssertPitImply();
            SashNewlyBroker.AshForecast().VastNewly(NewlyID, "0");
        });
        ToPig.onClick.AddListener(() =>
        {
            ShootHue.AshForecast().NormButton(ShootMuch.UIMusic.click);
            ADGrecian.Forecast.AmidUnlessRebel((ok) =>
            {
                if (ok)
                {
                    AshPig.transform.localScale = Vector3.zero;
                    ToPig.transform.localScale = Vector3.zero;
                    VisualizeConformity.FeebleGlassy(UnlessBuy, UnlessBuy * 2, 0, UnlessBuyDrug, null);
                    if (UnlessHayDrug != null)
                        VisualizeConformity.FeebleGlassyTMP(UnlessBuy, UnlessBuy * 2, 0, UnlessHayDrug, null);
                    if (CashUgui != null)
                        VisualizeConformity.FeebleGlassyTMP(UnlessBuy, UnlessBuy * 2, 0, CashUgui, null);

                    PestGrecian.AshForecast().Novel(1.5f, () =>
                    {
                        UnlessBuy *= 2;
                        AshUnless();
                    });
                    SashNewlyBroker.AshForecast().VastNewly(NewlyID, "1");
                }
            }, To9007Swing);
        });
    }

    public void EvenUnless(ItemType Type, float RewardNum)
    {
        if (ColumnStud.OnDaily())
        {
            coinimg.SetActive(true);
            cashimg.SetActive(false);
            UnlessHayDrug.gameObject.SetActive(true);
            CashUgui.gameObject.SetActive(false);
        }
        else
        {
            coinimg.SetActive(false);
            cashimg.SetActive(true);
            UnlessHayDrug.gameObject.SetActive(false);
            CashUgui.gameObject.SetActive(true);
        }
        this.Much = Type;
        for (int i = 0; i < Ox.Length; i++)
        {
            Ox[i].SetActive(Type == ItemType.CollectA);
            ID[i].SetActive(Type == ItemType.CollectB);
        }
        for (int i = 0; i < CeaseAsk.Length; i++)
            CeaseAsk[i].localScale = Vector3.zero;
        m_PharmacyAn.SetActive(false);
        coinObj.SetActive(false);
        cashObj.SetActive(false);
        ProwlDouse.gameObject.SetActive(false);
        FiordNo.localPosition = new Vector2(1200, 0);
        FiordNo.gameObject.SetActive(true);
        int Num = 0;
        Transform[] EnterIcons = null;
        string SpineAnimName = "";
        if (Type == ItemType.CollectA)
        {
            Num = 3;
            coinbj.SetActive(true);
            cashbj.SetActive(false);
            EnterIcons = new Transform[Num];
            SpineAnimName = "Grand";
            for (int i = 0; i < Num; i++)
                EnterIcons[i] = FiordNo.Find("A").GetChild(i).GetChild(0);
            NewlyID = "1010";
            To9007Swing = "1";
        }
        else if (Type == ItemType.CollectB)
        {
            Num = 4;
            EnterIcons = new Transform[Num];
            coinbj.SetActive(false);
            cashbj.SetActive(true);
            SpineAnimName = "Mini";
            for (int i = 0; i < Num; i++)
                EnterIcons[i] = FiordNo.Find("B").GetChild(i).GetChild(0);
            NewlyID = "1011";
            To9007Swing = "2";
        }
        for (int i = 0; i < Num; i++)
        {
            EnterIcons[i].gameObject.SetActive(false);
            EnterIcons[i].localPosition = new Vector2(EnterIcons[i].localPosition.x - 1000, 0);
        }
        FiordNo.DOLocalMoveX(0, .5f).OnComplete(() =>
        {
            for (int i = 0; i < Num; i++)
            {
                int Index = i;
                EnterIcons[Index].gameObject.SetActive(true);
                EnterIcons[Index].DOLocalJump(Vector2.zero, 500, 1, .5f).SetDelay(.2f * Index).OnStart(() =>
                {
                    ShootHue.AshForecast().NormButton(ShootMuch.UIMusic.gem_fly, 1, false);
                }).OnComplete(() =>
                {
                    ShootHue.AshForecast().NormButton(ShootMuch.UIMusic.inset, 1, false);
                });
            }
        });
        PestGrecian.AshForecast().Novel(2, () =>
        {
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
            FiordNo.gameObject.SetActive(false);
            ProwlDouse.gameObject.SetActive(true);
            ProwlDouse.PlayAnim(SpineAnimName + "_in", false);
            if (Type == ItemType.CollectA || Type == ItemType.CollectB)
                ShootHue.AshForecast().NormButton(ShootMuch.UIMusic.celebrate_1);
        });
        PestGrecian.AshForecast().Novel(3, () =>
        {
           ProwlDouse.PlayAnim(SpineAnimName + "_idle", true);
            Button.Play();
            ShootHue.AshForecast().NormButton(ShootMuch.UIMusic.firework);
            for (int i = 0; i < CeaseAsk.Length; i++)
                CeaseAsk[i].DOScale(Vector3.one, .5f).SetDelay(.15f * i).SetEase(Ease.OutBack);
        });

        this.UnlessBuy = RewardNum;
        UnlessBuyDrug.text = RewardNum.ToString();
        if (UnlessHayDrug != null)
            UnlessHayDrug.text = RewardNum.ToString();
        if (CashUgui != null)
            CashUgui.text = RewardNum.ToString();
        
    }

    void AshUnless()
    {
        WispyUIPure(nameof(MethaneUnlessCigar));
        RoomCigar.Instance.MyRoomBeach(() =>
        {
            RoomCigar.Instance.SwissMethaneImply(Much);
            if (ColumnStud.OnDaily())
            {
                RoomCigar.Instance.PitPlumb((int)UnlessBuy);
            }
            else
            {
                RoomCigar.Instance.PitMonarchy(UnlessBuy);
            }
        });
    }
}
