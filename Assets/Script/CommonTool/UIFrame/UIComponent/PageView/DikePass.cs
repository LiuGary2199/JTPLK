/**
 * 
 * 左右滑动的页面视图
 * 
 * ***/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class DikePass : MonoBehaviour,IBeginDragHandler,IEndDragHandler
{
[UnityEngine.Serialization.FormerlySerializedAs("rect")]    //scrollview
    public ScrollRect Rest;
    //求出每页的临界角，页索引从0开始
    List<float> posRent= new List<float>();
[UnityEngine.Serialization.FormerlySerializedAs("isDrag")]    //是否拖拽结束
    public bool GoDrag= false;
    bool RoofMime= true;
    //滑动的起始坐标  
    float StudioCircumvent= 0;
    float PrizeBonyCircumvent;
    float startTime = 0f;
[UnityEngine.Serialization.FormerlySerializedAs("smooting")]    //滑动速度  
    public float Inedible= 1f;
[UnityEngine.Serialization.FormerlySerializedAs("sensitivity")]    public float Lithography= 0.3f;
[UnityEngine.Serialization.FormerlySerializedAs("OnPageChange")]    //页面改变
    public Action<int> OrDikeFeeble;
    //当前页面下标
    int BesidesDikeSwing= -1;
    void Start()
    {
        Rest = this.GetComponent<ScrollRect>();
        float horizontalLength = Rest.content.rect.width - this.GetComponent<RectTransform>().rect.width;
        posRent.Add(0);
        for(int i = 1; i < Rest.content.childCount - 1; i++)
        {
            posRent.Add(GetComponent<RectTransform>().rect.width * i / horizontalLength);
        }
        posRent.Add(1);
    }

    
    void Update()
    {
        if(!GoDrag && !RoofMime)
        {
            startTime += Time.deltaTime;
            float t = startTime * Inedible;
            Rest.horizontalNormalizedPosition = Mathf.Lerp(Rest.horizontalNormalizedPosition, StudioCircumvent, t);
            if (t >= 1)
            {
                RoofMime = true;
            }
        }
        
    }
    /// <summary>
    /// 设置页面的index下标
    /// </summary>
    /// <param name="index"></param>
    void GelDikeSwing(int index)
    {
        if (BesidesDikeSwing != index)
        {
            BesidesDikeSwing = index;
            if (OrDikeFeeble != null)
            {
                OrDikeFeeble(index);
            }
        }
    }
    /// <summary>
    /// 开始拖拽
    /// </summary>
    /// <param name="eventData"></param>
    public void OnBeginDrag(PointerEventData eventData)
    {
        GoDrag = true;
        PrizeBonyCircumvent = Rest.horizontalNormalizedPosition;
    }
    /// <summary>
    /// 拖拽结束
    /// </summary>
    /// <param name="eventData"></param>
    public void OnEndDrag(PointerEventData eventData)
    {
        float posX = Rest.horizontalNormalizedPosition;
        posX += ((posX - PrizeBonyCircumvent) * Lithography);
        posX = posX < 1 ? posX : 1;
        posX = posX > 0 ? posX : 0;
        int index = 0;
        float offset = Mathf.Abs(posRent[index] - posX);
        for(int i = 0; i < posRent.Count; i++)
        {
            float temp = Mathf.Abs(posRent[i] - posX);
            if (temp < offset)
            {
                index = i;
                offset = temp;
            }
        }
        GelDikeSwing(index);
        StudioCircumvent = posRent[index];
        GoDrag = false;
        startTime = 0f;
        RoofMime = false;
    }
}
