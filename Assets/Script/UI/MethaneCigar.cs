using System.Collections;
using System.Collections.Generic;
using Spine.Unity;
using UnityEngine;
using UnityEngine.UI;

public class MethaneCigar : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("sliderImage")]    public Image CarpetStorm;
[UnityEngine.Serialization.FormerlySerializedAs("progressText")]    public Text HithertoDrug;
[UnityEngine.Serialization.FormerlySerializedAs("Spine")]    public SkeletonGraphic Douse;
[UnityEngine.Serialization.FormerlySerializedAs("LittleTitle")]    public GameObject EntombProwl; //安卓副标题

    void Start()
    {
        CarpetStorm.fillAmount = 0;
        HithertoDrug.text = "0%";
        if (EntombProwl != null)
            EntombProwl.SetActive(false);

        PestGrecian.AshForecast().Novel(1, () =>
        {
            Douse.PlayAnim("in", false);
        });
        PestGrecian.AshForecast().Novel(1.86f, () =>
        {
            Douse.PlayAnim("idle", false);
            if (EntombProwl != null && Application.platform != RuntimePlatform.IPhonePlayer)
                EntombProwl.SetActive(true);
        });
		ZJT_Manager.AshForecast().RecordStartTime();
	}

    // Update is called once per frame
    void Update()
    {
        if (CarpetStorm.fillAmount <= 0.8f || (WedSoulHue.Instance.Blame && ZJT_Manager.AshForecast().CashOutReady()))
        {
            CarpetStorm.fillAmount += Time.deltaTime * .2f;
            HithertoDrug.text = (int)(CarpetStorm.fillAmount * 100) + "%";
            if (CarpetStorm.fillAmount >= 1)
            {
                // 安卓平台特殊屏蔽规则 被屏蔽玩家显示提示 阻止进入
                if (ColumnStud.BizarreCargoTrait())
                    return;
                //主动调用一次IsApple 判断是否符合屏蔽规则
                ColumnStud.OnDaily();

                Destroy(transform.parent.gameObject);
                WireGrecian.instance.TireWine();

				ZJT_Manager.AshForecast().ReportEvent_LoadingTime();
			}
        }
    }
}
