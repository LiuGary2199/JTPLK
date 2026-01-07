using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

public class VisualizeConformity : MonoBehaviour
{
    /// <summary>
    /// 弹窗出现效果
    /// </summary>
    /// <param name="PopBarUp"></param>
    public static void RobEven(GameObject PopBarUp, System.Action finish)
    {
        /*-------------------------------------初始化------------------------------------*/
        PopBarUp.GetComponent<CanvasGroup>().alpha = 0;
        PopBarUp.transform.localScale = new Vector3(0, 0, 0);
        /*-------------------------------------动画效果------------------------------------*/
        PopBarUp.GetComponent<CanvasGroup>().DOFade(1, 0.3f);
        PopBarUp.transform.DOScale(1, 0.5f).SetEase(Ease.OutBack).OnComplete(() =>
        {
            finish?.Invoke();
        });
    }


    /// <summary>
    /// 弹窗消失效果
    /// </summary>
    /// <param name="PopBarDisapper"></param>
    public static void RobDeep(GameObject PopBarDisapper, System.Action finish)
    {
        /*-------------------------------------初始化------------------------------------*/
        PopBarDisapper.GetComponent<CanvasGroup>().alpha = 1;
        PopBarDisapper.transform.localScale = new Vector3(1, 1, 1);
        /*-------------------------------------动画效果------------------------------------*/
        PopBarDisapper.GetComponent<CanvasGroup>().DOFade(0, 0.3f);
        PopBarDisapper.transform.DOScale(0, 0.3f).SetEase(Ease.InBack).OnComplete(() =>
        {
            finish?.Invoke();
        });
    }
    /// <summary>
    /// 数字变化动画
    /// </summary>
    /// <param name="startNum"></param>
    /// <param name="endNum"></param>
    /// <param name="text"></param>
    /// <param name="finish"></param>
    public static void FeebleGlassy(int startNum, int endNum, float delay, Text text, System.Action finish)
    {
        DOTween.To(() => startNum, x => text.text = x.ToString(), endNum, 0.5f).SetDelay(delay).OnComplete(() =>
        {
            finish?.Invoke();
        });
    }


    public static void FeebleGlassy(double startNum, double endNum, float delay, Text text, System.Action finish)
    {
        FeebleGlassy(startNum, endNum, delay, text, "", finish);
    }
    public static void FeebleGlassyTMP(double startNum, double endNum, float delay, TextMeshProUGUI text, System.Action finish)
    {
        FeebleGlassyTMPS(startNum, endNum, delay, text, "", finish);
    }
    public static void FeebleGlassy(double startNum, double endNum, float delay, Text text, string prefix, System.Action finish)
    {

        DOTween.To(() => startNum, x => text.text = prefix + GlassyStud.EnzymeGoNss(x), endNum, 0.5f).SetDelay(delay).OnComplete(() =>
        {
            finish?.Invoke();
        }).OnUpdate(() =>
        {
            if (Time.frameCount % 2 == 0)
                ShootHue.AshForecast().NormButton(ShootMuch.UIMusic.num_roll);
        });
    }

    public static void FeebleGlassyTMPS(double startNum, double endNum, float delay, TextMeshProUGUI text, string prefix, System.Action finish)
    {

        DOTween.To(() => startNum, x => text.text = prefix + GlassyStud.EnzymeGoNss(x), endNum, 0.5f).SetDelay(delay).OnComplete(() =>
        {
            finish?.Invoke();
        }).OnUpdate(() =>
        {
            if (Time.frameCount % 2 == 0)
                ShootHue.AshForecast().NormButton(ShootMuch.UIMusic.num_roll);
        });
    }

    /// <summary>
    /// 收金币
    /// </summary>
    /// <param name="GoldImage">金币图标</param>
    /// <param name="a">金币数量</param>
    /// <param name="StartPosition">起始位置</param>
    /// <param name="EndPosition">最终位置</param>
    /// <param name="finish">结束回调</param>
    public static void AiryMimeJuly(GameObject GoldImage, int a, Vector2 StartPosition, Vector2 EndPosition, System.Action finish)
    {
        //如果没有就算了
        if (a == 0)
        {
            finish?.Invoke();
        }
        //数量不超过15个
        else if (a > 15)
        {
            a = 15;
        }
        //每个金币的间隔
        float Delaytime = 0;
        for (int i = 0; i < a; i++)
        {
            int t = i;
            //每次延迟+1
            Delaytime += 0.06f;
            //复制一个图标
            GameObject GoldIcon = Instantiate(GoldImage, GoldImage.transform.parent);
            GoldIcon.SetActive(true);
            //初始化
            GoldIcon.transform.position = StartPosition;
            //GoldIcon.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
            //金币弹出随机位置
            float OffsetX = UnityEngine.Random.Range(-0.8f, 0.8f);
            float OffsetY = UnityEngine.Random.Range(-0.8f, 0.8f);
            //创建动画队列
            var s = DOTween.Sequence();
            //金币出现
            s.Append(GoldIcon.transform.DOMove(new Vector3(GoldIcon.transform.position.x + OffsetX, GoldIcon.transform.position.y + OffsetY, GoldIcon.transform.position.z), 0.15f).SetDelay(Delaytime).OnComplete(() =>
            {
                //限制音效播放数量
                //if (Mathf.Sin(t) > 0)
                if (t % 5 == 0)
                {
                    ShootHue.AshForecast().NormButton(ShootMuch.UIMusic.hit_coin);
                }
            }));
            //金币移动到最终位置
            s.Append(GoldIcon.transform.DOMove(EndPosition, 0.6f).SetDelay(0.2f));
            s.Join(GoldIcon.transform.DOScale(1.5f, 0.3f).SetEase(Ease.InBack));
            s.AppendCallback(() =>
            {
                //收尾
                s.Kill();
                Destroy(GoldIcon);
                if (t == a - 1)
                {
                    finish?.Invoke();
                }
            });
        }
    }
    public static void AiryMimeJuly(GameObject GoldImage, int a, Transform StartTF, Transform EndTF, System.Action finish)
    {
        AiryMimeJuly(GoldImage, a, StartTF.position, EndTF.position, finish);
    }

    /// <summary>
    /// 横向滚动
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="addPosition"></param>
    /// <param name="Finish"></param>
    public static void CircumventPoster(GameObject obj, float addPosition, System.Action Finish)
    {
        float positionX = obj.transform.localPosition.x;
        float endPostion = positionX + addPosition;
        obj.transform.DOLocalMoveX(endPostion, 2f).SetEase(Ease.InOutQuart).OnComplete(() =>
        {
            Finish?.Invoke();
        });
    }


    public static void AshAiryShoe(Vector2 StartPos, Vector2 EndPos)
    {
        Transform Gold = ObjectPool.Instance.Get("钱图标").transform;
        Gold.SetParent(UIGrecian.AshForecast()._TieMatrix);
        Gold.localScale = Vector3.one;
        Gold.position = StartPos;
        if (Random.value < .5f)
        {
            Gold.DOMoveY(EndPos.y, 0.3f).SetEase(Ease.Linear);
            Gold.DOMoveX(EndPos.x, 0.3f).SetEase(Ease.Linear).SetDelay(0.3f).OnComplete(() =>
            {
                ObjectPool.Instance.Return("钱图标", Gold.gameObject);
            });
        }
        else
        {
            Gold.DOMoveX(EndPos.x, 0.3f).SetEase(Ease.Linear);
            Gold.DOMoveY(EndPos.y, 0.3f).SetEase(Ease.Linear).SetDelay(0.3f).OnComplete(() =>
            {
                ObjectPool.Instance.Return("钱图标", Gold.gameObject);
            });
        }
    }

    public static void AshAiryDrugShoe(float Value, Vector2 Pos)
    {
        Text GoldText = ObjectPool.Instance.Get("加钱文字").GetComponent<Text>();
        GoldText.text = Value.ToString();
        GoldText.transform.SetParent(UIGrecian.AshForecast()._TieMatrix);
        GoldText.transform.position = Pos;
        GoldText.transform.localScale = Vector3.zero;
        GoldText.transform.DOScale(1, 0.3f);
        GoldText.transform.DOMoveY(Pos.y + .3f, 0.5f).OnComplete(() =>
        {
            ObjectPool.Instance.Return("加钱文字", GoldText.gameObject);
        });
    }

    public static void AshMagentaDrugShoe(float Value, Vector2 Pos)
    {
        Text MagentaDrug= ObjectPool.Instance.Get("加钻文字").GetComponent<Text>();
        MagentaDrug.text = Value.ToString();
        MagentaDrug.transform.SetParent(UIGrecian.AshForecast()._TieMatrix);
        MagentaDrug.transform.position = Pos;
        MagentaDrug.transform.localScale = Vector3.zero;
        MagentaDrug.transform.DOScale(1, 0.3f);
        MagentaDrug.transform.DOMoveY(Pos.y + .3f, 0.5f).OnComplete(() =>
        {
            ObjectPool.Instance.Return("加钻文字", MagentaDrug.gameObject);
        });
    }

    public static void AshSoonAiryShoe(int MoneyNum)
    {
        // 目标位置（收集点）
        Vector2 TargetPos = RoomCigar.Instance.CapeDarn.transform.position;
        if (ColumnStud.OnDaily())
            TargetPos = RoomCigar.Instance.CapeDarn.transform.position; 
        // 定义三个同心圆的参数：半径和每个圆上的金币数量
        var circles = new List<(float radius, int count)> { (100f, 8) };
        if (MoneyNum <= 50)
            circles.Add((200f, 16));
        else if (MoneyNum > 50)
        {
            circles.Add((200f, 16));
            circles.Add((300f, 24));
        }
        int circleIndex = 0;
        foreach (var circle in circles)
        {
            float radius = circle.radius;
            int count = circle.count;
            // 计算每个金币在圆上的角度
            for (int i = 0; i < count; i++)
            {
                // 获取金币对象
                Transform Gold = ObjectPool.Instance.Get("钱图标").transform;
                Gold.SetParent(UIGrecian.AshForecast()._TieMatrix);
                Gold.localScale = Vector3.zero;
                // 计算角度（弧度）
                float angle = (i * 2 * Mathf.PI) / count;
                // 根据角度计算圆上的位置
                float x = radius * Mathf.Cos(angle);
                float y = radius * Mathf.Sin(angle);
                Vector2 Pos = new Vector2(x, y);
                Gold.localPosition = Pos;
                // 计算延迟时间，让不同圆和位置的金币有错落感
                float delay = circleIndex * 0.1f + i * 0.01f;
                // 缩放动画
                Gold.DOScale(Vector3.one, .3f).SetDelay(delay);
                // 飞向目标点的动画
                Gold.DOMove(TargetPos, 0.6f)
                    .SetDelay(1f + delay)  // 等待缩放完成后再开始移动
                    .SetEase(Ease.InOutQuad)
                    .OnComplete(() =>
                    {
                        ObjectPool.Instance.Return("钱图标", Gold.gameObject);
                    });
            }
            circleIndex++;
        }
    }

    public static void AshSoonMagentaShoe(int MoneyNum)
    {
        // 目标位置（收集点）
        //Vector2 TargetPos = new Vector2(0,0);
        Vector2 TargetPos = RoomCigar.Instance.MothBoyTwo.position;
        if (ColumnStud.OnDaily())
            TargetPos = RoomCigar.Instance.SaltSteepBG.transform.position;
        // 定义三个同心圆的参数：半径和每个圆上的钻石数量
        var circles = new List<(float radius, int count)> { (350f, 24) };
        if (MoneyNum <= 50)
            circles.Add((250f, 16));
        else if (MoneyNum > 50)
        {
            circles.Add((250f, 16));
            circles.Add((150f, 8));
        }
        int circleIndex = 0;
        foreach (var circle in circles)
        {
            float radius = circle.radius;
            int count = circle.count;
            // 计算每个钻石在圆上的角度
            for (int i = 0; i < count; i++)
            {
                // 获取钻石对象
                Transform Magenta= ObjectPool.Instance.Get("钻石图标").transform;
                Magenta.SetParent(UIGrecian.AshForecast()._TieMatrix);
                Magenta.localScale = Vector3.zero;
                // 计算角度（弧度）
                float angle = (i * 2 * Mathf.PI) / count;
                // 根据角度计算圆上的位置
                float x = radius * Mathf.Cos(angle);
                float y = radius * Mathf.Sin(angle);
                Vector2 Pos = new Vector2(x, y);
                Magenta.localPosition = Pos;
                // 计算延迟时间，让不同圆和位置的金币有错落感
                float delay = circleIndex * 0.1f + i * 0.01f;
                // 缩放动画
                Magenta.DOScale(Vector3.one, .3f).SetDelay(delay);
                // 飞向目标点的动画
                Magenta.DOMove(TargetPos, 0.6f)
                    .SetDelay(1f + delay)  // 等待缩放完成后再开始移动
                    .SetEase(Ease.InOutQuad)
                    .OnComplete(() =>
                    {
                        ObjectPool.Instance.Return("钻石图标", Magenta.gameObject);
                    });
            }
            circleIndex++;
        }
    }


    public static void AshSoonHoleShoe(int BallNum)
    {
        Vector2 TargetPos = RoomCigar.Instance.HoleBuyDrug.transform.position;
        for (int i = 0; i < 20; i++)
        {
            Transform Hole= ObjectPool.Instance.Get("球图标").transform;
            Hole.SetParent(UIGrecian.AshForecast()._TieMatrix);
            Hole.localScale = Vector3.zero;
            Hole.position = new Vector2(-2 + .2f * i, TargetPos.y - 1);
            Hole.DOScale(Vector3.one, .2f).SetDelay(.05f * i);
            Hole.DOMove(TargetPos, .3f).SetDelay(1 + .05f * i).SetEase(Ease.InBack).OnComplete(() =>
            {
                ObjectPool.Instance.Return("球图标", Hole.gameObject);
                ShootHue.AshForecast().NormButton(ShootMuch.UIMusic.collect_ball);
            });
        }
    }

}
