using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;


/// <summary> 引导面板 </summary>
public class ReactCigar : SakeUIDaddy
{
    Image Cargo;
[UnityEngine.Serialization.FormerlySerializedAs("Center")]    public RectTransform Stench;
[UnityEngine.Serialization.FormerlySerializedAs("Hand")]    public Transform Also;
[UnityEngine.Serialization.FormerlySerializedAs("InfoBg")]    public Transform SoulHe;
[UnityEngine.Serialization.FormerlySerializedAs("Info")]    public Text Soul;
    [HideInInspector] [UnityEngine.Serialization.FormerlySerializedAs("GuideIndex")]public int ReactSwing;
[UnityEngine.Serialization.FormerlySerializedAs("NextBtn")]    public Button NextPig;
    Coroutine SoulMimeIE;


    public override void Display(object OrPureDemise)
    {
        base.Display(OrPureDemise);
        Cargo = GetComponent<Image>();
        Deep(true);
    }

    public void EvenBlue(Transform Target, float Scale = 1)
    {
        RectTransform TargetRect = Target.GetComponent<RectTransform>();
        EvenBlue(TargetRect.position, TargetRect.sizeDelta * Target.localScale * Scale);
    }
    void EvenBlue(Vector2 Pos, Vector2 Size)
    {
        Cargo.raycastTarget = true;
        Stench.DOKill();
        Stench.DOMove(Pos, .5f);
        Stench.DOSizeDelta(Size, .7f).OnComplete(() =>
        {
            Cargo.raycastTarget = false;
        });
    }

    public void EvenBlue_Round(Vector2 Pos, Vector2 Size)
    {
        Cargo.raycastTarget = true;
        Stench.DOKill();
        Stench.DOLocalMove(Pos, .5f);
        Stench.DOSizeDelta(Size, .7f).OnComplete(() =>
        {
            Cargo.raycastTarget = false;
        });
    }

    public void EvenAlso(Vector2[] Poss)
    {
        Also.DOKill();
        Also.gameObject.SetActive(true);
        Also.position = Poss[0];
        if (Poss.Length > 1)
            AlsoShoe(Poss, 0);
    }
    void AlsoShoe(Vector2[] Poss, int Index)
    {
        Also.DOMove(Poss[Index], .4f).SetEase(Ease.Linear).OnComplete(() =>
        {
            if (Also.gameObject.activeSelf)
            {
                if (Index < Poss.Length - 1)
                    AlsoShoe(Poss, Index + 1);
                else
                    AlsoShoe(Poss, 0);
            }
        });
    }

    public void EvenSoul(string Text, int PosY = 0)
    {
        Soul.DOKill();
        SoulHe.DOKill();
        Soul.text = "";
        SoulHe.gameObject.SetActive(true);
        SoulHe.localScale = new Vector2(0, 1);
        SoulHe.DOScale(Vector2.one, .3f);
        Soul.DOText(Text, .3f).SetDelay(.3f);

        if (SoulMimeIE != null)
            StopCoroutine(SoulMimeIE);
        if (SoulHe.localPosition.y != PosY)
            SoulMimeIE = StartCoroutine(nameof(SoulMime), PosY);
    }
    IEnumerator SoulMime(int PosY)
    {
        Vector2 UpdatePos = SoulHe.localPosition;
        Vector2 TargetPos = new Vector2(0, PosY);
        while (true)
        {
            yield return null;
            TargetPos.y = PosY;
            UpdatePos.y = Mathf.Lerp(UpdatePos.y, TargetPos.y, Time.deltaTime * 10);
            SoulHe.localPosition = UpdatePos;
            if (Mathf.Abs(UpdatePos.y - TargetPos.y) < 1)
                break;
        }
    }

    public void EvenPostPig(Action OnBtnClick)
    {
        NextPig.onClick.RemoveAllListeners();
        NextPig.onClick.AddListener(() =>
        {
            NextPig.onClick.RemoveAllListeners();
            OnBtnClick();
        });
        NextPig.gameObject.SetActive(false);
        Invoke(nameof(EvenPostPig), 1f);
    }
    void EvenPostPig()
    {
        NextPig.gameObject.SetActive(true);
    }

    public void Deep(bool IsBlcok)
    {
        Also.DOKill();
        Soul.DOKill();
        SoulHe.DOKill();
        Stench.DOKill();
        Also.gameObject.SetActive(false);
        Soul.text = "";
        SoulHe.gameObject.SetActive(false);
        NextPig.gameObject.SetActive(false);
        Stench.localPosition = Vector2.zero;
        Stench.sizeDelta = Vector2.one * 3000;
        Cargo.raycastTarget = IsBlcok;
    }

}
