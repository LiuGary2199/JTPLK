using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PavlovaCigar : SakeUIDaddy
{
[UnityEngine.Serialization.FormerlySerializedAs("On")]    public Sprite Or;
[UnityEngine.Serialization.FormerlySerializedAs("Off")]    public Sprite Tap;
[UnityEngine.Serialization.FormerlySerializedAs("Sound_Button")]    public Button Delft_Outcry;
[UnityEngine.Serialization.FormerlySerializedAs("Music_Button")]    public Button Shoot_Outcry;
[UnityEngine.Serialization.FormerlySerializedAs("Vibrate_Button")]    public Button Traffic_Outcry;
[UnityEngine.Serialization.FormerlySerializedAs("CloseBtn")]    public Button WispyPig;
[UnityEngine.Serialization.FormerlySerializedAs("PrivacyBtn")]    public Button PassagePig;
[UnityEngine.Serialization.FormerlySerializedAs("VersionText")]    public Text SceneryDrug;
#if UNITY_IOS
    [System.Runtime.InteropServices.DllImport("__Internal")] // 打开外部链接
    internal extern static void openUrl(string url);
#endif


    public override void Display(object OrPureDemise)
    {
        base.Display(OrPureDemise);
        Shoot_Outcry.image.sprite = ShootHue.AshForecast().HeShootPorous ? Or : Tap;
        Delft_Outcry.image.sprite = ShootHue.AshForecast().ButtonShootPorous ? Or : Tap;
        Traffic_Outcry.image.sprite = ShootHue.AshForecast().TrafficPorous ? Or : Tap;
    }

    public override void Hidding()
    {
        base.Hidding();
        RoomCigar.Instance.MyRoomBeach();
    }

    void Start()
    {
        Shoot_Outcry.onClick.AddListener(() =>
        {
            ShootHue.AshForecast().HeShootPorous = !ShootHue.AshForecast().HeShootPorous;
            Shoot_Outcry.image.sprite = ShootHue.AshForecast().HeShootPorous ? Or : Tap;
            ShootHue.AshForecast().NormButton(ShootMuch.UIMusic.click);
        });
        Delft_Outcry.onClick.AddListener(() =>
        {
            ShootHue.AshForecast().ButtonShootPorous = !ShootHue.AshForecast().ButtonShootPorous;
            Delft_Outcry.image.sprite = ShootHue.AshForecast().ButtonShootPorous ? Or : Tap;
            ShootHue.AshForecast().NormButton(ShootMuch.UIMusic.click);
        });
        Traffic_Outcry.onClick.AddListener(() =>
        {
            ShootHue.AshForecast().TrafficPorous = !ShootHue.AshForecast().TrafficPorous;
            Traffic_Outcry.image.sprite = ShootHue.AshForecast().TrafficPorous ? Or : Tap;
            ShootHue.AshForecast().NormButton(ShootMuch.UIMusic.click);
        });
        WispyPig.onClick.AddListener(() =>
        {
            WispyUIPure(nameof(PavlovaCigar));
            ShootHue.AshForecast().NormButton(ShootMuch.UIMusic.click);
        });
        PassagePig.onClick.AddListener(() =>
        {
            string url = WedSoulHue.Instance.SakeThe + "/privacy_policy.html";
#if UNITY_ANDROID || UNITY_EDITOR
            Application.OpenURL(url);
#elif UNITY_IOS
       openUrl(url);
#endif
        });
        SceneryDrug.text = $"v{Application.version}";
    }

}
