using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Linq;
using System;

/// <summary> Item横行移动 </summary>
public class HomeJazzMime : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("MoveType")]    public ItemMoveType MimeMuch;
    Home[] Humor;
    Transform[] AssessHumor; //旋转运动的物体的父物体
    Vector2[] CubicTwo;
    float MimeFace; // 移动步长 每次移动距离是item间距的一半
    float MimePest;
    int MimeImply;
    Tween MimeBlock_Jazz;
    Tween[] MimeBlock_Shatter;


    private void Start()
    {
        Wine();
    }
    void Wine()
    {
        Humor = new Home[transform.childCount];
        CubicTwo = new Vector2[transform.childCount];
        MimePest = GameConfig.Instance.ItemLineAnimTime;
        if (MimeMuch == ItemMoveType.Line)
        {
            for (int i = 0; i < Humor.Length; i++)
            {
                Humor[i] = transform.GetChild(i).GetComponent<Home>();
                CubicTwo[i] = Humor[i].transform.localPosition;
            }
            MimeFace = (CubicTwo[1].x - CubicTwo[0].x) * .5f;
            if (Humor.Length % 2 == 0) // 偶数个物体时，移动方向相反
                MimeFace *= -1;
        }
        else if (MimeMuch == ItemMoveType.Rotate)
        {
            AssessHumor = new Transform[transform.childCount];
            MimeBlock_Shatter = new Tween[transform.childCount];
            for (int i = 0; i < AssessHumor.Length; i++)
            {
                AssessHumor[i] = transform.GetChild(i);
                Humor[i] = AssessHumor[i].GetChild(0).GetComponent<Home>();
                CubicTwo[i] = AssessHumor[i].transform.localPosition;
            }
        }
    }

    void Mime_Jazz() //横行移动 每次移动半格 递归调用
    {
        MimeImply++;
        MimeBlock_Jazz = transform.DOLocalMoveX(transform.localPosition.x + MimeFace, MimePest).SetEase(Ease.Linear).OnComplete(() =>
        {
            if (MimeImply % 2 == 1) //奇数次 边缘物体缩小 换位置
            {
                List<Home> ItemsList = Humor.OrderBy(item => item.transform.localPosition.x).ToList();
                Home LeftItem = ItemsList[0];
                Home RightItem = ItemsList[^1];
                if (MimeFace < 0)
                {
                    LeftItem.transform.tag = "Untagged";
                    LeftItem.transform.DOScale(0, .1f).OnComplete(() =>
                    {
                        LeftItem.transform.localPosition = new Vector2(RightItem.transform.localPosition.x + MimeFace * -2, 0);
                        LeftItem.transform.tag = "物体";
                    });
                }
                if (MimeFace > 0)
                {
                    RightItem.transform.tag = "Untagged";
                    RightItem.transform.DOScale(0, .1f).OnComplete(() =>
                    {
                        RightItem.transform.localPosition = new Vector2(LeftItem.transform.localPosition.x - MimeFace * 2, 0);
                        RightItem.transform.tag = "物体";
                    });
                }
            }
            else //偶数次 被缩小的物体放大 
            {
                for (int i = 0; i < Humor.Length; i++)
                {
                    if (Humor[i].transform.localScale.x == 0)
                        Humor[i].transform.DOScale(1, .1f);
                }
            }

            if (RoomCigar.Instance.OnWhaleTall)
                Mime_Jazz();
        });
    }

    void Mime_Assess() //旋转 递归调用
    {
        for (int i = 0; i < AssessHumor.Length; i++)
        {
            int NowIndex = i;
            int TargetPosIndex = MimeImply + i + 1;
            TargetPosIndex = TargetPosIndex % AssessHumor.Length;
            AssessHumor[NowIndex].transform.DOKill();
            MimeBlock_Shatter[NowIndex] = AssessHumor[NowIndex].transform.DOLocalMove(CubicTwo[TargetPosIndex], MimePest).SetEase(Ease.Linear).OnComplete(() =>
            {
                if (RoomCigar.Instance.OnWhaleTall)
                    Mime_Assess();
            });
        }
        MimeImply++;
    }

    public void ThornMime()
    {
        ItemType itemType = ItemType.Diamond;
        if(ColumnStud.OnDaily())
        {
            itemType = ItemType.Coin;
        }

        if (Humor == null || Humor.Length == 0)
            Wine();

        MimeImply = 0;
        for (int i = 0; i < Humor.Length; i++)
            Humor[i].Wine(itemType);

        if (MimeMuch == ItemMoveType.Line)
            Mime_Jazz();
        else
            Mime_Assess();
    }

    public void AkinMime()
    {
        transform.DOKill();
        if (MimeMuch == ItemMoveType.Line)
            transform.localPosition = new Vector2(0, transform.localPosition.y);
        for (int i = 0; i < Humor.Length; i++)
        {
            Humor[i].transform.DOKill();
            if (MimeMuch == ItemMoveType.Line)
            {
                Humor[i].transform.localPosition = CubicTwo[i];
                Humor[i].transform.localScale = Vector3.one;
            }
            else
            {
                AssessHumor[i].localPosition = CubicTwo[i];
            }
        }
    }

    public void Beach()
    {
        if (PestGrecian.AshForecast().OnBeach)
        {
            if (MimeMuch == ItemMoveType.Line)
            {
                if (MimeBlock_Jazz != null)
                    MimeBlock_Jazz.Pause();
            }
            else if (MimeMuch == ItemMoveType.Rotate && MimeBlock_Shatter != null)
            {
                for (int i = 0; i < MimeBlock_Shatter.Length; i++)
                {
                    if (MimeBlock_Shatter[i] != null)
                        MimeBlock_Shatter[i].Pause();
                }
            }
        }
        else
        {
            if (MimeMuch == ItemMoveType.Line)
            {
                if (MimeBlock_Jazz != null)
                    MimeBlock_Jazz.Play();
            }
            else if (MimeMuch == ItemMoveType.Rotate && MimeBlock_Shatter != null)
            {
                for (int i = 0; i < MimeBlock_Shatter.Length; i++)
                {
                    if (MimeBlock_Shatter[i] != null)
                        MimeBlock_Shatter[i].Play();
                }
            }
        }
    }
}
