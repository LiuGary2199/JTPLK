using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BlueHappily : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("mask")]    public RectTransform Soul;
[UnityEngine.Serialization.FormerlySerializedAs("mypageview")]    public DikePass Attachment;
    private void Awake()
    {
        Attachment.OrDikeFeeble = Serigraphy;
    }

    void Serigraphy(int index)
    {
        if (index >= this.transform.childCount) return;
        Vector3 pos= this.transform.GetChild(index).GetComponent<RectTransform>().position;
        Soul.GetComponent<RectTransform>().position = pos;
    }
}
