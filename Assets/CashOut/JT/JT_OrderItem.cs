using System;
using UnityEngine;
using UnityEngine.UI;

public class JT_OrderItem : MonoBehaviour
{
#if JT

    JT_OrderItemData Data;
    public Image PlatformIcon;
    public Text MoneyText;
    public Text TimeText;
    public Text QueueText;


    public void Init(JT_OrderItemData Data)
    {
        this.Data = Data;
        PlatformIcon.sprite = JT_Manager.AshForecast()._CashOutPanel.PlatformIcons[Data.PlatformIndex];
        MoneyText.text = Data.Money.ToString("F2") + " USD";
        TimeText.text = JT_Manager.AshForecast().Translate("Redeemm in") + " " + JT_Manager.AshForecast().GetTimeStr(Data.Time, true);

        DateTime recordTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Local).AddSeconds(Data.Time);
        DateTime currentTime = DateTime.Now;
        TimeSpan timeDiff = currentTime - recordTime;
        int days = timeDiff.Days;
        int originalQueue = Data.Queue;
        int NewQueue = originalQueue;
        // 排队计算累计衰减（每日衰减25%，向上取整，最少减1）
        for (int i = 0; i < days; i++)
        {
            double decayValue = Math.Ceiling(NewQueue * 0.25);
            int dailyDecay = Math.Max(1, (int)decayValue);
            NewQueue = Math.Max(0, NewQueue - dailyDecay);
            if (NewQueue == 0) break;
        }
        if (NewQueue <= 0)
            QueueText.text = "";
        else
            QueueText.text = JT_Manager.AshForecast().Translate("Your queue position is") + " <color=#FF2222>" + NewQueue + "</color>";

    }


#endif
}
