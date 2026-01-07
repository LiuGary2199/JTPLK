using System.Collections;
using System.Collections.Generic;
using Coffee.UIExtensions;
using DG.Tweening;
using Spine.Unity;
using UnityEngine;
using UnityEngine.UI;

/// <summary> 翻倍机 </summary>
public class EnzymeSymptom : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("Body")]    public RectTransform Bold;
[UnityEngine.Serialization.FormerlySerializedAs("Left")]    public Transform Ibex;
[UnityEngine.Serialization.FormerlySerializedAs("Right")]    public Transform Layer;
[UnityEngine.Serialization.FormerlySerializedAs("Collider")]    public BoxCollider2D Consider;
    Vector2 BoldWish;
    Vector2 Layer_Two;
[UnityEngine.Serialization.FormerlySerializedAs("PassSpine")]    public SkeletonGraphic ChopDouse; //球穿过特效
    float DouseWish;
[UnityEngine.Serialization.FormerlySerializedAs("LightEffect")]    //public SkeletonGraphic FeverSpine; //疯狂模式特效
    //float FeverSpineSize;
    public UIParticle PlaceButton;
[UnityEngine.Serialization.FormerlySerializedAs("LightEffect1")]    public ParticleSystem PlaceButton1; // 闪电特效1
    float PlaceButton1Wish;
[UnityEngine.Serialization.FormerlySerializedAs("LightEffect2")]    public ParticleSystem PlaceButton2; // 闪电特效2
    float PlaceButton2Wish;
[UnityEngine.Serialization.FormerlySerializedAs("Line")]    public RectTransform Jazz;//轨道
[UnityEngine.Serialization.FormerlySerializedAs("LineEffect")]    public UIParticle JazzButton;

    [HideInInspector] [UnityEngine.Serialization.FormerlySerializedAs("Multi")]public int Finch;
[UnityEngine.Serialization.FormerlySerializedAs("MultiText")]    public Text FinchDrug;
    int PermFrayImply;
    float FrayMaternal; //生成间隔
    Transform HoleBeluga;
    bool CanyonBySwimHole;

    Tween MimeBlock;
    float MimeShoePest;
    int MimeTwoGroan;

    float Dose_Injury_Finch; // 长度乘倍
    bool Dose_Akin;


    private void Start()
    {
        FrayMaternal = GameConfig.Instance.DoubleMachineBornInterval;
        BoldWish = Bold.sizeDelta;
        Layer_Two = Layer.localPosition;
        if (ChopDouse != null)
            DouseWish = ChopDouse.transform.localScale.x;
        //if (FeverSpine != null)
        //    FeverSpineSize = FeverSpine.transform.localScale.x;
        if (PlaceButton1 != null)
            PlaceButton1Wish = PlaceButton1.shape.scale.x;
        if (PlaceButton2 != null)
            PlaceButton2Wish = PlaceButton2.shape.scale.x;

        PestGrecian.AshForecast().Minute_SoloBeach(0, FrayMaternal, () =>
        {
            if (PermFrayImply > 0)
                FrayHole();
        });
    }

    public void Wine(bool PlinkoOrDropBall, int Multi, float MoveAnimTime, Transform BallParent, bool IsMove)
    {
        this.CanyonBySwimHole = PlinkoOrDropBall;
        this.Finch = Multi;
        this.HoleBeluga = BallParent;
        this.MimeShoePest = MoveAnimTime;
        FinchDrug.text = "x" + Multi.ToString();
        if (PlinkoOrDropBall)
            MimeTwoGroan = GameConfig.Instance.DoubleMachinePosLimit;
        else
            MimeTwoGroan = GameConfig.Instance.DropBallDoubleMachinePosLimit;

        if (IsMove)
            Mime();
    }

    public void BreedPermFray() //清除等待生成的球
    {
        PermFrayImply = 0;
    }

    public void SwissFinch(int Multi = 3) //重置翻倍机奖励系数
    {
        this.Finch = Multi;
        FinchDrug.text = "x" + Multi.ToString();
        // if (Multi == 3)
        //     FeverSpine.StopAnim();
        // else
        //     FeverSpine.PlayAnim("fevertime_sd", true);
        if (Multi == 3)
            PlaceButton.StopEmission();
        else
            PlaceButton.StartEmission();
    }

    public void Beach()
    {
        if (Dose_Akin)
            return;

        if (PestGrecian.AshForecast().OnBeach)
            MimeBlock.Pause();
        else
            MimeBlock.Play();
    }

    void Mime() // 翻倍机移动
    {
        Vector2 MovePos = new Vector2(0, transform.localPosition.y);
        if (transform.localPosition.x >= 0)
            MovePos.x = -MimeTwoGroan;
        else
            MovePos.x = MimeTwoGroan;
        MimeBlock = transform.DOLocalMove(MovePos, MimeShoePest).SetEase(GameConfig.Instance.DoubleMachineAnimCurve).OnComplete(() =>
        {
            Mime();
        });
    }

    public void ChopTestify() //通过翻倍机
    {
        PermFrayImply += Finch;
        if (ChopDouse.IsComplete())
        {
            ChopDouse.PlayAnim("light_In", false);
            ShootHue.AshForecast().NormButton(ShootMuch.UIMusic.electricity);
        }
        CancelInvoke(nameof(ChopDouseShoePul));
        Invoke(nameof(ChopDouseShoePul), 0.2f);
    }
    void ChopDouseShoePul() //球穿过特效动画结束
    {
        ChopDouse.PlayAnim("light_end", false);
    }

    public void WhaleLowaPorous(bool IsOn) //疯狂模式特效切换
    {
        // if (IsOn)
        //     FeverSpine.PlayAnim("fevertime_sd", true);
        // else
        //     FeverSpine.StopAnim();

        if (IsOn)
            PlaceButton.StartEmission();
        else
            PlaceButton.StopEmission();
    }

    void FrayHole() //生成球
    {
        PermFrayImply--;
        if (CanyonBySwimHole)
        {
            GameObject NewBall = ObjectPool.Instance.Get("球");
            NewBall.transform.SetParent(HoleBeluga);
            NewBall.transform.localScale = Vector3.one;
            Vector2 Pos = transform.position;
            Pos.y -= .1f;
            Pos.x += Random.Range(-0.5f, 0.5f);
            NewBall.transform.position = Pos;
        }
        // 松爪掉球玩法
        else
        {
            SwimHoleRoom_Hole NewBall = ObjectPool.Instance.Get("松爪掉球_球").GetComponent<SwimHoleRoom_Hole>();
            NewBall.transform.SetParent(HoleBeluga);
            Vector2 Pos = transform.position;
            Pos.y -= .1f;
            Pos.x += Random.Range(-0.3f, 0.3f);
            NewBall.transform.position = Pos;
            NewBall.transform.localScale = Vector3.one;
            SwimHoleRoomCigar.Instance.Steep.Add(NewBall);
        }
    }

    public void GelDose_Injury(float BuffMulti)
    {
        Dose_Injury_Finch = BuffMulti;
        FeebleInjury(Dose_Injury_Finch);
    }

    public void GelDose_Akin(bool IsPause)
    {
        if (IsPause)
        {
            MimeBlock.Pause();
            Jazz.DOMoveX(transform.position.x, .5f);
            Vector2 NewSize = new Vector2(BoldWish.x + 60, Jazz.sizeDelta.y);
            Jazz.DOSizeDelta(NewSize, .5f);
            JazzButton.Play();
        }
        else
        {
            MimeBlock.Play();
            Jazz.DOMoveX(0, .5f);
            Vector2 NewSize = new Vector2(827, Jazz.sizeDelta.y);
            Jazz.DOSizeDelta(NewSize, .5f).OnComplete(() =>
            {
                JazzButton.Play();
            });
        }
    }

    public void FeebleInjury(float Length_Multi)
    {
        // 长度 柱子位置 碰撞器大小 渐变
        float CollectSize = BoldWish.x;
        Vector2 NewSize = new Vector2(BoldWish.x * Length_Multi, BoldWish.y);
        Vector2 NewPos = new Vector2(Layer_Two.x * Length_Multi, Layer_Two.y);
        Bold.DOSizeDelta(NewSize, .5f).SetEase(Ease.OutBack);
        Layer.DOLocalMove(NewPos, .5f).SetEase(Ease.OutBack);
        NewPos.x *= -1;
        Ibex.DOLocalMove(NewPos, .5f).SetEase(Ease.OutBack);
        if (ChopDouse != null)
            ChopDouse.transform.DOScaleX(DouseWish * Length_Multi, .5f);
        // if (FeverSpine != null)
        //     FeverSpine.transform.DOScaleX(FeverSpineSize * Length_Multi, .5f);
        if (PlaceButton1 != null)
        {
            var shape = PlaceButton1.shape;
            shape.scale = new Vector3(PlaceButton1Wish * Length_Multi, shape.scale.y, 1);
        }
        if (PlaceButton2 != null)
        {
            var shape = PlaceButton2.shape;
            shape.scale = new Vector3(PlaceButton2Wish * Length_Multi, shape.scale.y, 1);
        }
        DOTween.To(() => CollectSize, x => CollectSize = x, BoldWish.x * Length_Multi, .5f).OnUpdate(() =>
        {
            Consider.size = new Vector2(CollectSize, Consider.size.y);
        });

        // 移动边界 长度变化时需要重新计算  
        MimeTwoGroan = (int)(MimeTwoGroan - (BoldWish.x * .5));
        //print("移动边界:" + MovePosLimit);
        if (Length_Multi == 1)
        {
            if (CanyonBySwimHole)
                MimeTwoGroan = GameConfig.Instance.DoubleMachinePosLimit;
            else
                MimeTwoGroan = GameConfig.Instance.DropBallDoubleMachinePosLimit;
        }
        if (transform.localPosition.x >= MimeTwoGroan)
        {
            transform.localPosition = new Vector3(MimeTwoGroan, transform.localPosition.y, 0);
            MimeBlock.Kill();
            Mime();
        }
        else if (transform.localPosition.x <= -MimeTwoGroan)
        {
            transform.localPosition = new Vector3(-MimeTwoGroan, transform.localPosition.y, 0);
            MimeBlock.Kill();
            Mime();
        }
    }
}
