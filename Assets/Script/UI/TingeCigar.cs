using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using Spine.Unity;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary> 转盘 </summary>
public class TingeCigar : SakeUIDaddy
{
    [UnityEngine.Serialization.FormerlySerializedAs("Coin")] public Sprite Cape;
    [UnityEngine.Serialization.FormerlySerializedAs("Hole")] public Sprite Hole;
    [UnityEngine.Serialization.FormerlySerializedAs("Diamond")] public Sprite Magenta;
    [UnityEngine.Serialization.FormerlySerializedAs("SpinBtn")] public Button LowaPig;
    [UnityEngine.Serialization.FormerlySerializedAs("BigWheel")] public Transform BatTinge;
    [UnityEngine.Serialization.FormerlySerializedAs("BigWheelItem")] public Transform[] BatTingeHome; //12个
    [UnityEngine.Serialization.FormerlySerializedAs("SmallWheel")] public Transform TowelTinge;
    [UnityEngine.Serialization.FormerlySerializedAs("SmallWheelText")] public Transform[] TowelTingeDrug; //6个
    int[] TowelTingeFrance = new int[] { 5, 2, 6, 1, 10, 3 };
    [UnityEngine.Serialization.FormerlySerializedAs("Pointer")] public Transform Varnish;
    [UnityEngine.Serialization.FormerlySerializedAs("FinishImage")] public Image FrightStorm;
    [UnityEngine.Serialization.FormerlySerializedAs("Light1")] public Image Place1;
    [UnityEngine.Serialization.FormerlySerializedAs("Light2")] public Image Place2;
    int BatSwing;
    int TowelSwing;
    WheelData DayIraq;
    [UnityEngine.Serialization.FormerlySerializedAs("Fake_BigWheelItem")]    //转盘由12*6扩充为24*24 多出来的格子是假数据
    public Transform[] Gobi_BatTingeHome; //12个
    [UnityEngine.Serialization.FormerlySerializedAs("Fake_SmallWheelText")] public Transform[] Gobi_TowelTingeDrug; //18个
    [UnityEngine.Serialization.FormerlySerializedAs("WimSpine")] public SkeletonGraphic RunDouse;
    [UnityEngine.Serialization.FormerlySerializedAs("SpinBtndi")] public GameObject LowaJuice;

    private void Start()
    {
        LowaPig.onClick.AddListener(() =>
        {
            ShootHue.AshForecast().NormButton(ShootMuch.UIMusic.click);
            Lowa();
        });
    }

    public override void Display(object OrPureDemise)
    {
        base.Display(OrPureDemise);
        RunDouse.gameObject.SetActive(false);
        LowaPig.gameObject.SetActive(true);
        LowaJuice.gameObject.SetActive(true);
        //   FrightStorm.color = new Color32(255, 255, 255, 0);
        //Place1.color = new Color32(255, 255, 255, 0);
        // Place2.color = new Color32(255, 255, 255, 0);
        // Place1.DOFade(1, 2).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
        //  Place2.DOFade(1, 2).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear).SetDelay(.5f);
        BatTinge.DOKill();
        BatTinge.eulerAngles = Vector3.zero;
        BatTinge.DORotate(
            new Vector3(0, 0, 180),
            30f,
            RotateMode.FastBeyond360
        ).SetEase(Ease.Linear).SetLoops(-1, LoopType.Restart);
        TowelTinge.DOKill();
        TowelTinge.eulerAngles = Vector3.zero;
        TowelTinge.DORotate(
            new Vector3(0, 0, -180),
            30f,
            RotateMode.FastBeyond360
        ).SetEase(Ease.Linear).SetLoops(-1, LoopType.Restart);

        //转盘大圈数据随机排列
        WheelData[] BigWheelItemData = new WheelData[]
        {
            new WheelData { type = "币", count = 20 },
            new WheelData { type = "币", count = 30 },
            new WheelData { type = "币", count = 50 },
            new WheelData { type = "币", count = 100 },
            new WheelData { type = "钻石", count = 2 },
            new WheelData { type = "钻石", count = 5 },
            new WheelData { type = "钻石", count = 10 },
            new WheelData { type = "钻石", count = 20 },
            new WheelData { type = "钻石", count = 50 },
            new WheelData { type = "球", count = 2 },
            new WheelData { type = "球", count = 5 },
            new WheelData { type = "球", count = 10 },
        };
        BigWheelItemData = BigWheelItemData.OrderBy(x => Random.value).ToArray();
        for (int i = 0; i < BatTingeHome.Length; i++)
        {
            TextMeshProUGUI textCoin = BatTingeHome[i].Find("TMPCoin").GetComponent<TextMeshProUGUI>();
            textCoin.text = BigWheelItemData[i].count.ToString();
            TextMeshProUGUI TxtCash = BatTingeHome[i].Find("TMPCash").GetComponent<TextMeshProUGUI>();
            TxtCash.text = BigWheelItemData[i].count.ToString();
            TextMeshProUGUI TextBall = BatTingeHome[i].Find("TMPBall").GetComponent<TextMeshProUGUI>();
            TextBall.text = BigWheelItemData[i].count.ToString();
            textCoin.gameObject.SetActive(false);
            TxtCash.gameObject.SetActive(false);
            TextBall.gameObject.SetActive(false);
            if (BigWheelItemData[i].type == "币")
            {
                textCoin.gameObject.SetActive(true);
                BatTingeHome[i].Find("Icon").GetComponent<Image>().sprite = Cape;
            }
            else if (BigWheelItemData[i].type == "球")
            {
                TextBall.gameObject.SetActive(true);
                BatTingeHome[i].Find("Icon").GetComponent<Image>().sprite = Hole;
            }
            else if (BigWheelItemData[i].type == "钻石")
            {
                TxtCash.gameObject.SetActive(true);
                BatTingeHome[i].Find("Icon").GetComponent<Image>().sprite = Magenta;
            }
            BatTingeHome[i].Find("Icon").GetComponent<Image>().SetNativeSize();
        }
        //转盘小圈倍率随机排列
        TowelTingeFrance = TowelTingeFrance.OrderBy(x => Random.value).ToArray();
        for (int i = 0; i < TowelTingeDrug.Length; i++)
            TowelTingeDrug[i].Find("Text").GetComponent<Text>().text = "x" + TowelTingeFrance[i].ToString();

        //假格子
        for (int i = 0; i < Gobi_BatTingeHome.Length; i++)
        {
            TextMeshProUGUI gameObject1 = Gobi_BatTingeHome[i].Find("TMPCoin").GetComponent<TextMeshProUGUI>();
            gameObject1.text = BigWheelItemData[i].count.ToString();
            TextMeshProUGUI gameObject2 = Gobi_BatTingeHome[i].Find("TMPCash").GetComponent<TextMeshProUGUI>();
            gameObject2.text = BigWheelItemData[i].count.ToString();
            TextMeshProUGUI gameObject3 = Gobi_BatTingeHome[i].Find("TMPBall").GetComponent<TextMeshProUGUI>();
            gameObject3.text = BigWheelItemData[i].count.ToString();

            gameObject1.gameObject.SetActive(false);
            gameObject2.gameObject.SetActive(false);
            gameObject3.gameObject.SetActive(false);

            if (BigWheelItemData[i].type == "币")
            {
                gameObject1.gameObject.SetActive(true);
                Gobi_BatTingeHome[i].Find("Icon").GetComponent<Image>().sprite = Cape;
            }
            else if (BigWheelItemData[i].type == "球")
            {
                gameObject3.gameObject.SetActive(true);
                Gobi_BatTingeHome[i].Find("Icon").GetComponent<Image>().sprite = Hole;
            }
            else if (BigWheelItemData[i].type == "钻石")
            {
                gameObject2.gameObject.SetActive(true);
                Gobi_BatTingeHome[i].Find("Icon").GetComponent<Image>().sprite = Magenta;
            }
            Gobi_BatTingeHome[i].Find("Icon").GetComponent<Image>().SetNativeSize();
        }
        for (int i = 0; i < Gobi_TowelTingeDrug.Length; i++)
        {
            int Value = TowelTingeFrance[Random.Range(0, TowelTingeFrance.Length)];
            Gobi_TowelTingeDrug[i].Find("Text").GetComponent<Text>().text = "x" + Value.ToString();
        }

        //计算中奖
        DayIraq = AshUnlessDyRotate();
        int WinCount = DayIraq.count;
        //把中奖总额拆分成大圈金额和小圈倍率的乘积 确定BigIndex和SmallIndex
        for (int i = 0; i < BigWheelItemData.Length; i++)
        {
            if (BigWheelItemData[i].type != DayIraq.type)
                continue;
            int bigValue = BigWheelItemData[i].count;
            if (bigValue == 0)
                continue; // 避免除以零
            // 检查当前大圈数值是否能被中奖总额整除
            if (WinCount % bigValue != 0)
                continue;
            int requiredMulti = WinCount / bigValue;
            // 在小圈中查找匹配的倍率
            for (int j = 0; j < TowelTingeFrance.Length; j++)
            {
                if (TowelTingeFrance[j] == requiredMulti)
                {
                    BatSwing = i;
                    TowelSwing = j;
                    i = BigWheelItemData.Length; // 跳出外层循环
                    break;
                }
            }
        }
        print($"奖励类型: {DayIraq.type},   奖励金额: {WinCount}");
    }
    WheelData AshUnlessDyRotate()
    {
        if (!CellIraqGrecian.GetBool(CWinter.sv_zhuanpan_first))
        {
            Debug.Log("第一次转盘必中奖");
             WheelData  wheelData = new WheelData();
            wheelData.type = "钻石";
            wheelData.count = 100;
            wheelData.weight = 0;
           CellIraqGrecian.SetBool(CWinter.sv_zhuanpan_first, true);
           return wheelData;
        }
        WheelData[] Datas = WedSoulHue.Instance._RoomIraq.wheel_list.ToArray();
        int totalWeight = Datas.Sum(x => x.weight);
        int randomWeight = Random.Range(0, totalWeight);
        int currentWeight = 0;
        foreach (var item in Datas)
        {
            currentWeight += item.weight;
            if (currentWeight >= randomWeight)
                return item;
        }
        return null;
    }

    void Lowa()
    {
        LowaPig.gameObject.SetActive(false);
        LowaJuice.gameObject.SetActive(false);
        //   Place1.DOKill();
        //  Place2.DOKill();
        // Place1.color = new Color32(255, 255, 255, 0);
        //  Place2.color = new Color32(255, 255, 255, 0);
        //  Place1.DOFade(1, .4f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
        //Place2.DOFade(1, .4f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear).SetDelay(.2f);

        Varnish.DOKill();
        Varnish.eulerAngles = Vector3.zero;
        VarnishShoe();

        //BigIndex = Random.Range(0, BigWheelItem.Length);
        //SmallIndex = Random.Range(0, SmallWheelText.Length);

        // 大圈：每格15度，索引0~11是真实奖励，12~23是假的，不用管
        float bigAnglePerSlot = 360f / 24; // 15度
        float bigTargetAngle = 360 * 3 - bigAnglePerSlot * BatSwing; // BigIndex 取 0~11
        BatTinge.DOKill();
        BatTinge.DORotate(
            new Vector3(0, 0, bigTargetAngle),
            2f,
            RotateMode.FastBeyond360
        ).OnComplete(() =>
        {

            ShootHue.AshForecast().NormButton(ShootMuch.UIMusic.wheel_stop);
        });

        // 小圈：同理，每格15度，真实奖励索引在 0~5
        float smallAnglePerSlot = 360f / 24; // 15度
        float smallTargetAngle = -360 * 3 - smallAnglePerSlot * TowelSwing; // SmallIndex 取 0~5
        TowelTinge.DOKill();
        TowelTinge.DORotate(
            new Vector3(0, 0, smallTargetAngle),
            3f,
            RotateMode.FastBeyond360
        ).SetEase(Ease.InOutSine).OnComplete(() =>
        {
            // FrightStorm.DOFade(1, 0.1f).SetLoops(5, LoopType.Yoyo);

            //    Place1.DOKill();
            //     Place2.DOKill();
            //   Place1.color = new Color32(255, 255, 255, 0);
            //   Place2.color = new Color32(255, 255, 255, 0);
            //   Place1.DOFade(1, .2f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
            //     Place2.DOFade(1, .2f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
            ShootHue.AshForecast().NormButton(ShootMuch.UIMusic.wheel_stop);
            ShootHue.AshForecast().NormButton(ShootMuch.UIMusic.wheel_win);
            RunDouse.gameObject.SetActive(true);
            RunDouse.PlayAnim("animation", true);
        });

        PestGrecian.AshForecast().Novel(4.5f, () =>
        {
            RunDouse.gameObject.SetActive(false);
            //   FrightStorm.DOKill();
            Place1.DOKill();
            Place2.DOKill();

            WispyUIPure(nameof(TingeCigar));
            CellIraqGrecian.SetBool(CWinter.sv_zhuanpan_rot, true);
            RewardType Much = RewardType.Coin;
            if (DayIraq.type == "币")
                Much = RewardType.Coin;
            else if (DayIraq.type == "球")
                Much = RewardType.Ball;
            else if (DayIraq.type == "钻石")
                Much = RewardType.Diamond;
            (UIGrecian.AshForecast().EvenUIDaddy(nameof(UnlessCigar)) as UnlessCigar).Wine(DayIraq.count, Much, true, () =>
            {
                if (!CellIraqGrecian.GetBool(CWinter.sv_zhuanpan_finish) && !ColumnStud.OnDaily())
                {
                    PestGrecian.AshForecast().Novel(1.4f, () =>
                    {
                        RoomCigar.Instance.RoomBeach();
                        RoomCigar.Instance.React1();
                        CellIraqGrecian.SetBool(CWinter.sv_zhuanpan_finish, true);
                    });
                
                }
                else
                {
                    RoomCigar.Instance.MyRoomBeach();
                }
            }, "1013");
        });
    }

    void VarnishShoe()
    {
        int LoopCount = 24;

        Sequence seq = DOTween.Sequence();
        seq.Append(Varnish.transform.DOLocalRotate(new Vector3(0, 0, -20 + Random.Range(-2f, 2f)), 6f / LoopCount * 0.3f).SetEase(Ease.Linear));
        seq.AppendCallback(() =>
        {
            ShootHue.AshForecast().NormButton(ShootMuch.UIMusic.rotate_wheel, 1, false);
            ShootHue.AshForecast().NormTraffic(Lofelt.NiceVibrations.HapticPatterns.PresetType.SoftImpact);
        });
        seq.SetLoops(LoopCount, LoopType.Yoyo);
        seq.SetEase(Ease.InOutSine);
        seq.Play();
    }
}
