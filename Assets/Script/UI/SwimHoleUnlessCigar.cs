using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary> 掉球游戏奖励面板 </summary>
public class SwimHoleUnlessCigar : SakeUIDaddy
{
[UnityEngine.Serialization.FormerlySerializedAs("GetBtn")]    public Button AshPig;
[UnityEngine.Serialization.FormerlySerializedAs("NumberText")]    public Text GlassyDrug;
[UnityEngine.Serialization.FormerlySerializedAs("Rewards")]    public Transform[] Replica;

    private void Start()
    {
        AshPig.onClick.AddListener(() =>
        {
            ShootHue.AshForecast().NormButton(ShootMuch.UIMusic.click);
            AshUnless();
        });
    }

    public override void Display(object OrPureDemise)
    {
        base.Display(OrPureDemise);
        GlassyDrug.text = "收集宝箱x" + SwimHoleRoomCigar.Instance.AlkalineGlassy;
        for (int i = 0; i < Replica.Length; i++)
        {
            Transform RewardItem = Replica[i];
            RewardItem.GetChild(0).gameObject.SetActive(true);
            RewardItem.GetChild(1).gameObject.SetActive(false);
            RewardItem.gameObject.SetActive(i < SwimHoleRoomCigar.Instance.AlkalineGlassy);

            PestGrecian.AshForecast().Novel(1 + i * .5f, () =>
            {
                RewardItem.GetChild(0).gameObject.SetActive(false);
                RewardItem.GetChild(1).gameObject.SetActive(true);
            });
        }
    }

    void AshUnless()
    {
        RoomCigar.Instance.Polychrome(() =>
        {
            WispyUIPure(nameof(SwimHoleUnlessCigar));
            WispyUIPure(nameof(SwimHoleRoomCigar));
            AnewUIPure(nameof(RoomCigar));
            RoomCigar.Instance.SwissReleaseHome();
        });
    }
}
