using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum TargetType
{
    Scene,
    UGUI
}
public enum LayoutType
{
    Sprite_First_Weight,
    Sprite_First_Height,
    Screen_First_Weight,
    Screen_First_Height,
    Bottom,
    Top,
    Left,
    Right
}
public enum RunTime
{
    Awake,
    Start,
    None
}
public class LinkInvade : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("Target_Type")]    public TargetType Athens_Much;
[UnityEngine.Serialization.FormerlySerializedAs("Layout_Type")]    public LayoutType Invade_Much;
[UnityEngine.Serialization.FormerlySerializedAs("Run_Time")]    public RunTime Fen_Pest;
[UnityEngine.Serialization.FormerlySerializedAs("Layout_Number")]    public float Invade_Glassy;
    private void Awake()
    {
        if (Fen_Pest == RunTime.Awake)
        {
            SocialMutual();
        }
    }
    private void Start()
    {
        if (Fen_Pest == RunTime.Start)
        {
            SocialMutual();
        }
    }

    public void SocialMutual()
    {
        if (Invade_Much == LayoutType.Sprite_First_Weight)
        {
            if (Athens_Much == TargetType.UGUI)
            {

                float scale = Screen.width / Invade_Glassy;
                //GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width, Screen.width / w * h);
                transform.localScale = new Vector3(scale, scale, scale);
            }
        }
        if (Invade_Much == LayoutType.Screen_First_Weight)
        {
            if (Athens_Much == TargetType.Scene)
            {
                float scale = AshPowderIraq.AshForecast().SapWeightHabit() / Invade_Glassy;
                transform.localScale = transform.localScale * scale;
            }
        }
        
        if (Invade_Much == LayoutType.Bottom)
        {
            if (Athens_Much == TargetType.Scene)
            {
                float screen_bottom_y = AshPowderIraq.AshForecast().SapWeightRevere() / -2;
                screen_bottom_y += (Invade_Glassy + (AshPowderIraq.AshForecast().SapDriverWish(gameObject).y / 2f));
                transform.position = new Vector3(transform.position.x, screen_bottom_y, transform.position.y);
            }
        }
    }
}
