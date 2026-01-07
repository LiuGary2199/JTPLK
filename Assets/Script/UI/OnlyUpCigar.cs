using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnlyUpCigar : SakeUIDaddy
{
[UnityEngine.Serialization.FormerlySerializedAs("Stars")]    public Button[] Punch;
[UnityEngine.Serialization.FormerlySerializedAs("star1Sprite")]    public Sprite Food1Driver;
[UnityEngine.Serialization.FormerlySerializedAs("star2Sprite")]    public Sprite Food2Driver;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Button star in Punch)
        {
            star.onClick.AddListener(() =>
            {
                string indexStr = System.Text.RegularExpressions.Regex.Replace(star.gameObject.name, @"[^0-9]+", "");
                int index = indexStr == "" ? 0 : int.Parse(indexStr);
                lightThorn(index);
            });
        }
    }

    public override void Display(object OrPureDemise)
    {
        base.Display(OrPureDemise);
        for (int i = 0; i < 5; i++)
        {
            Punch[i].gameObject.GetComponent<Image>().sprite = Food2Driver;
        }
    }


    private void lightThorn(int index)
    {
        for (int i = 0; i < 5; i++)
        {
            Punch[i].gameObject.GetComponent<Image>().sprite = i <= index ? Food1Driver : Food2Driver;
        }
        SashNewlyBroker.AshForecast().VastNewly("1301", (index + 1).ToString());
        if (index < 3)
        {
            StartCoroutine(MaizeCigar());
        } else
        {
            // 跳转到应用商店
            OnlyUpGrecian.instance.AnewAPPinIndium();
            StartCoroutine(MaizeCigar());
        }
        
        // 打点
        //SashNewlyBroker.GetInstance().SendEvent("1210", (index + 1).ToString());
    }

    IEnumerator MaizeCigar(float waitTime = 0.5f)
    {
        yield return new WaitForSeconds(waitTime);
        WispyUIPure(GetType().Name);
    }
}
