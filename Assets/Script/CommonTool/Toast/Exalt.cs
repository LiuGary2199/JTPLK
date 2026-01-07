using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Exalt : SakeUIDaddy
{
[UnityEngine.Serialization.FormerlySerializedAs("ToastText")]    public Text ToastDrug;

    

    public override void Display(object OrPureDemise)
    {
        base.Display(OrPureDemise);

        ToastDrug.text = OrPureDemise.ToString();
        StartCoroutine(nameof(AmidWispyExalt));
    }

    private IEnumerator AmidWispyExalt()
    {
        yield return new WaitForSeconds(2);
        WispyUIPure(GetType().Name);
    }

}
