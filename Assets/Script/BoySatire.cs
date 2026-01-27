using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary> 飞行气泡 </summary>
public class BoySatire : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("FlyX")]    public int BoyX= 1100;
[UnityEngine.Serialization.FormerlySerializedAs("TopY")]    public int NetY= 300;
[UnityEngine.Serialization.FormerlySerializedAs("BottomY")]    public int ExpendY= -220;
[UnityEngine.Serialization.FormerlySerializedAs("OffectY")]    public int CreaseY= 200;
    float SteepBuy;
[UnityEngine.Serialization.FormerlySerializedAs("RewardText")]    public Text UnlessDrug;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() =>
        {
            ShootHue.AshForecast().NormButton(ShootMuch.UIMusic.click);
            OnBubbleOnClick();
        });
    }

    public void Boy()
    {
        int AnimTime = 10;
        if (WedSoulHue.Instance._RoomIraq.fly_bubble != null && WedSoulHue.Instance._RoomIraq.fly_bubble.destroy_time > 0)
            AnimTime = (int)(WedSoulHue.Instance._RoomIraq.fly_bubble.destroy_time * 0.5f);
        SteepBuy = GameConfig.Instance.CountReward(RewardType.Diamond, (float)WedSoulHue.Instance._RoomIraq.fly_bubble.multi);
        UnlessDrug.text = SteepBuy.ToString("F2");
        gameObject.SetActive(true);
        //左上→右上
        transform.localPosition = new Vector3(-BoyX, NetY, 0);
        transform.DOLocalMoveY(NetY - CreaseY, 2).SetLoops(AnimTime, LoopType.Yoyo).SetEase(Ease.Linear);
        transform.DOLocalMoveX(BoyX, AnimTime).SetEase(Ease.Linear).OnComplete(() =>
        {
            transform.DOKill();
            //右下→左下
            transform.localPosition = new Vector3(BoyX, ExpendY, 0);
            transform.DOLocalMoveY(ExpendY + CreaseY, 2).SetLoops(AnimTime, LoopType.Yoyo).SetEase(Ease.Linear);
            transform.DOLocalMoveX(-BoyX, AnimTime).SetEase(Ease.Linear).OnComplete(() =>
            {
                transform.DOKill();
                gameObject.SetActive(false);
                //左上→右上
                // transform.localPosition = new Vector3(-FlyX, TopY, 0);
                // transform.DOLocalMoveY(TopY - OffectY, 1).SetLoops(AnimTime, LoopType.Yoyo).SetEase(Ease.Linear);
                // transform.DOLocalMoveX(FlyX, AnimTime).SetEase(Ease.Linear).OnComplete(() =>
                // {
                //     transform.DOKill();
                //     gameObject.SetActive(false);
                // });
            });
        });
    }

    void OnBubbleOnClick()
    {
        RoomCigar.Instance.RoomBeach();

        (UIGrecian.AshForecast().EvenUIDaddy(nameof(UnlessCigar)) as UnlessCigar).Wine(SteepBuy, RewardType.Diamond, false, () =>
        {
            RoomCigar.Instance.MyRoomBeach();
        }, "1006");
        transform.DOKill();
        gameObject.SetActive(false);
        //ShootHue.GetInstance().PlayEffect(ShootMuch.UIMusic.SFX_FlyBubble);
        //SashNewlyBroker.GetInstance().SendEvent("1016");
    }
}
