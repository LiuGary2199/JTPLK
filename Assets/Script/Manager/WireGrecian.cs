using UnityEngine;

public class WireGrecian : MonoBehaviour
{
    public static WireGrecian instance;
    private bool Blame= false;

    private void Awake()
    {
        instance = this;
        Application.targetFrameRate = 60;
        DG.Tweening.DOTween.SetTweensCapacity(1000, 200); //设置DOTween的最大缓存数量
    }

    public void TireWine()
    {
        bool isNewPlayer = !PlayerPrefs.HasKey(CWinter.Or_OnOatViewer + "Bool") || CellIraqGrecian.GetBool(CWinter.Or_OnOatViewer);

        SandalWineGrecian.Instance.WineSandalIraq(isNewPlayer);

        if (isNewPlayer)
        {
            // 新用户
            CellIraqGrecian.SetBool(CWinter.Or_OnOatViewer, false);
            //CellIraqGrecian.SetInt("CoinNum", GameConfig.Instance.FirstCoinNum);
        }

        ShootHue.AshForecast().NormHe(ShootMuch.SceneMusic.BGM);

        UIGrecian.AshForecast().EvenUIDaddy(nameof(RoomCigar));

        SashNewlyBroker.AshForecast().VastNewly("1001");

        Blame = true;
    }

    //切前后台也需要检测屏蔽 防止游戏中途更改手机状态
    private void OnApplicationFocus(bool focusStatus)
    {
        if (focusStatus)
            ColumnStud.BizarreCargoTrait();
    }
}
