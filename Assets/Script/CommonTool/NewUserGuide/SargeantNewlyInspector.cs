using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 事件渗透
/// </summary>
public class SargeantNewlyInspector : MonoBehaviour, ICanvasRaycastFilter
{
    private Image StudioStorm;
    public void GelAthensStorm(Image target)
    {
        StudioStorm = target;
    }
    public bool IsRaycastLocationValid(Vector2 sp, Camera eventCamera)
    {
        if (StudioStorm == null)
        {
            return true;
        }
        return !RectTransformUtility.RectangleContainsScreenPoint(StudioStorm.rectTransform, sp, eventCamera);
    }
}