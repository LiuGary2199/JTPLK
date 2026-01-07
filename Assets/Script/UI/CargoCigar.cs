using UnityEngine;
using UnityEngine.UI;

/// <summary> 屏蔽界面 阻止玩家操作 退出游戏 </summary>
public class CargoCigar : SakeUIDaddy
{
[UnityEngine.Serialization.FormerlySerializedAs("InfoText")]    public Text SoulDrug;
[UnityEngine.Serialization.FormerlySerializedAs("QuitBtn")]    public Button IdeaPig;

    private void Start()
    {
        IdeaPig.onClick.AddListener(Application.Quit);
    }

    public void EvenSoul(string info)
    {
        SoulDrug.text = info;
    }
}
