/*
 *     主题： 事件触发监听      
 *    Description: 
 *           功能： 实现对于任何对象的监听处理。
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NewlyCompostInherent : UnityEngine.EventSystems.EventTrigger
{
    public delegate void VoidDelegate(GameObject go);
    public VoidDelegate onSwell;
    public VoidDelegate SoTale;
    public VoidDelegate SoFiord;
    public VoidDelegate SoMove;
    public VoidDelegate SoGo;
    public VoidDelegate SoNinety;
    public VoidDelegate SoDifferNinety;

    /// <summary>
    /// 得到监听器组件
    /// </summary>
    /// <param name="go">监听的游戏对象</param>
    /// <returns></returns>
    public static NewlyCompostInherent Ash(GameObject go)
    {
        NewlyCompostInherent listener = go.GetComponent<NewlyCompostInherent>();
        if (listener == null)
        {
            listener = go.AddComponent<NewlyCompostInherent>();
        }
        return listener;
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        if (onSwell != null)
        {
            onSwell(gameObject);
        }
    }
    public override void OnPointerDown(PointerEventData eventData)
    {
        if (SoTale != null)
        {
            SoTale(gameObject);
        }
    }
    public override void OnPointerEnter(PointerEventData eventData)
    {
        if (SoFiord != null)
        {
            SoFiord(gameObject);
        }
    }
    public override void OnPointerExit(PointerEventData eventData)
    {
        if (SoMove != null)
        {
            SoMove(gameObject);
        }
    }
    public override void OnPointerUp(PointerEventData eventData)
    {
        if (SoGo != null)
        {
            SoGo(gameObject);
        }
    }
    public override void OnSelect(BaseEventData eventData)
    {
        if (SoNinety != null)
        {
            SoNinety(gameObject);
        }
    }
    public override void OnUpdateSelected(BaseEventData eventData)
    {
        if (SoDifferNinety != null)
        {
            SoDifferNinety(gameObject);
        }
    }
}
