using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Spine.Unity;
using UnityEngine;
using UnityEngine.UI;

/// <summary> 底部收集器（管子） </summary>
public class Circulate : MonoBehaviour
{
    RewardType Much;
[UnityEngine.Serialization.FormerlySerializedAs("CoinIcon")]    public Image CapeDarn;
[UnityEngine.Serialization.FormerlySerializedAs("DiamondIcon")]    public Image MagentaDarn;
[UnityEngine.Serialization.FormerlySerializedAs("NumberText")]    public Text GlassyDrug;
    [UnityEngine.Serialization.FormerlySerializedAs("NumberText")] public Text GlassyDrugcash;

    [UnityEngine.Serialization.FormerlySerializedAs("CollectSpine1")]    public SkeletonGraphic MethaneDouse1;
[UnityEngine.Serialization.FormerlySerializedAs("CollectSpine2")]    public SkeletonGraphic MethaneDouse2;
[UnityEngine.Serialization.FormerlySerializedAs("SpineName")]    public string DouseLash;

    private void Start()
    {
        Wine();
    }

    public void Wine()
    {
        CapeDarn.DOKill(true);
        MagentaDarn.DOKill(true);
        GlassyDrug.DOKill(true);
        GlassyDrugcash.DOKill(true);
        CapeDarn.transform.localScale = Vector3.one;
        MagentaDarn.transform.localScale = Vector3.one;
        GlassyDrug.transform.localScale = Vector3.one;
        GlassyDrugcash.transform.localScale = Vector3.one;
        CapeDarn.transform.DOScale(Vector3.zero, 0.2f);
        MagentaDarn.transform.DOScale(Vector3.zero, 0.2f);
        GlassyDrugcash.transform.DOScale(Vector3.zero, 0.2f).OnComplete(() =>
        { });
        GlassyDrug.transform.DOScale(Vector3.zero, 0.2f).OnComplete(() =>
        {
            Much = Random.value < 0.5f ? RewardType.Coin : RewardType.Diamond;
            if (ColumnStud.OnDaily())
                Much = RewardType.Coin;
            float Finch= AshUnlessFinchDyRotate();
            float Reward = GameConfig.Instance.CountReward(RewardType.Diamond, Finch);
            if (Much == RewardType.Coin)
                Reward = GameConfig.Instance.CountReward(RewardType.Coin, Finch);
   
            if (Much == RewardType.Coin)
            {
                GlassyDrug.text = Reward.ToString();
                GlassyDrugcash.text = "";
                GlassyDrug.gameObject.SetActive(true);
            }
            else
            {
                GlassyDrug.text = "";
                GlassyDrugcash.text = Reward.ToString();
                GlassyDrugcash.gameObject.SetActive(true);
            }
            CapeDarn.gameObject.SetActive(Much == RewardType.Coin);
            MagentaDarn.gameObject.SetActive(Much == RewardType.Diamond);

         

            CapeDarn.transform.DOScale(Vector3.one, 0.3f).SetEase(Ease.OutBack);
            MagentaDarn.transform.DOScale(Vector3.one, 0.3f).SetEase(Ease.OutBack);
            GlassyDrug.transform.DOScale(Vector3.one, 0.3f).SetEase(Ease.OutBack);
            GlassyDrugcash.transform.DOScale(Vector3.one, 0.3f).SetEase(Ease.OutBack);
        });
    }
    float AshUnlessFinchDyRotate() //根据权重获取奖励倍率
    {
        int sum = 0;
        foreach (var item in WedSoulHue.Instance._RoomIraq.under_collecter_award_list)
            sum += item.weight;
        int random = Random.Range(0, sum);
        int index = 0;
        for (int i = 0; i < WedSoulHue.Instance._RoomIraq.under_collecter_award_list.Count; i++)
        {
            random -= WedSoulHue.Instance._RoomIraq.under_collecter_award_list[i].weight;
            if (random <= 0)
            {
                index = i;
                break;
            }
        }
        return (float)WedSoulHue.Instance._RoomIraq.under_collecter_award_list[index].multi;
    }

    public void Methane()
    {
        float Money = GlassyDrug.text == ""? float.Parse(GlassyDrugcash.text): float.Parse(GlassyDrug.text);
        if (ColumnStud.OnDaily()) 
        {
            RoomCigar.Instance.PitHomeUnlessAnWhaleTall(Money);
        }
        else
        {
            if (RoomCigar.Instance.OnWhaleTall && Much == RewardType.Diamond)
                RoomCigar.Instance.PitHomeUnlessAnWhaleTall(Money);
            else
            {
                if (Much == RewardType.Coin)
                    RoomCigar.Instance.PitPlumb((int)Money, false);
                else
                    RoomCigar.Instance.PitMonarchy(Money, false);
            }
        }
       
        UnlessBut();
        DouseFace1();
        //CollectSpine1.PlayAnim(SpineName, false);
        Wine();
    }
    void UnlessBut()
    {
        string TipName = Much == RewardType.Coin ? "钱图标" : "钻石图标";
        Transform Tip = ObjectPool.Instance.Get(TipName).transform;
        Tip.transform.SetParent(UIGrecian.AshForecast()._TieMatrix);
        Tip.transform.position = CapeDarn.transform.position;
        Tip.transform.localScale = Vector3.zero;
        Tip.transform.DOScale(1, 0.3f);
        Tip.transform.DOMoveY(Tip.transform.position.y + .3f, 0.5f).OnComplete(() =>
        {
            ObjectPool.Instance.Return(TipName, Tip.gameObject);
        });
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            MethaneDouse1.PlayAnim(DouseLash + "_stay", true);
            MethaneDouse2.PlayAnim("light_all", false);
        }
    }

    void DouseFace1()
    {
        MethaneDouse2.PlayAnim("light_all", false);
        if (!MethaneDouse1.IsPlaying(DouseLash + "_stay"))
        {
            MethaneDouse1.PlayAnim(DouseLash + "_in", false);
            Invoke(nameof(DouseFace2), 0.1f);
            ShootHue.AshForecast().NormButton(ShootMuch.UIMusic.fall_light);
        }
        CancelInvoke(nameof(DouseFace3));
        Invoke(nameof(DouseFace3), 0.12f);
    }
    void DouseFace2()
    {
        MethaneDouse1.PlayAnim(DouseLash + "_stay", true);
    }
    void DouseFace3()
    {
        MethaneDouse1.PlayAnim(DouseLash + "_out", false);
    }
}
