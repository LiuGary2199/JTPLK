using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 基础UI窗体脚本（父类，其他窗体都继承此脚本）
/// </summary>
public class SakeUIDaddy : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("_CurrentUIType")]    //当前（基类）窗口的类型
    public UIMuch _DiscernUIMuch= new UIMuch();
    [HideInInspector]
[UnityEngine.Serialization.FormerlySerializedAs("close_button")]    public Button Maize_Africa;
    //属性，当前ui窗体类型
    internal UIMuch DiscernUIMuch    {
        set
        {
            _DiscernUIMuch = value;
        }
        get
        {
            return _DiscernUIMuch;
        }
    }
    protected virtual void Awake()
    {
        ThaiModalPitKatherine(gameObject);
        if (transform.Find("Window/Content/CloseBtn"))
        {
            Maize_Africa = transform.Find("Window/Content/CloseBtn").GetComponent<Button>();
            Maize_Africa.onClick.AddListener(() =>
            {
                UIGrecian.AshForecast().WispyBySymbolUIDaddy(this.GetType().Name);
            });
        }
        if (_DiscernUIMuch.UIForms_Type == UIFormType.PopUp)
        {
            gameObject.AddComponent<CanvasGroup>();
        }
        gameObject.name = GetType().Name;
    }


    public static void ThaiModalPitKatherine(GameObject goParent)
    {
        Transform parent = goParent.transform;
        int childCount = parent.childCount;
        for (int i = 0; i < childCount; i++)
        {
            Transform chile = parent.GetChild(i);
            if (chile.GetComponent<Button>())
            {
                chile.GetComponent<Button>().onClick.AddListener(() =>
                {

                    //ShootHue.GetInstance().PlayEffect(ShootMuch.UIMusic.Sound_UIButton);
                });
            }

            if (chile.childCount > 0)
            {
                ThaiModalPitKatherine(chile.gameObject);
            }
        }
    }

    //页面显示
    public virtual void Display(object OrPureDemise)
    {
        //Debug.Log(this.GetType().Name);
        this.gameObject.SetActive(true);
        // 设置模态窗体调用(必须是弹出窗体)
        if (_DiscernUIMuch.UIForms_Type == UIFormType.PopUp && _DiscernUIMuch.UIForm_LucencyType != UIFormLucenyType.NoMask)
        {
            UIBlueHue.AshForecast().GelBlueIncise(this.gameObject, _DiscernUIMuch.UIForm_LucencyType);
            ShootHue.AshForecast().NormButton(ShootMuch.UIMusic.panel_pop);
        }
        if (_DiscernUIMuch.UIForms_Type == UIFormType.PopUp)
        {

            //动画添加
            switch (_DiscernUIMuch.UIForm_animationType)
            {
                case UIFormShowAnimationType.scale:
                    VisualizeConformity.RobEven(gameObject, () =>
                    {

                    });
                    break;

            }

        }
        //NewUserManager.GetInstance().TriggerEvent(TriggerType.panel_display);
    }
    //页面隐藏（不在栈集合中）
    public virtual void Hidding(System.Action finish = null)
    {
        //if (_DiscernUIMuch.UIForms_Type == UIFormType.PopUp && _DiscernUIMuch.UIForm_LucencyType != UIFormLucenyType.NoMask)
        //{
        //    UIBlueHue.AshForecast().DeepBlueIncise();
        //}

        //取消模态窗体调用

        if (_DiscernUIMuch.UIForms_Type == UIFormType.PopUp)
        {
            switch (_DiscernUIMuch.UIForm_animationType)
            {
                case UIFormShowAnimationType.scale:
                    VisualizeConformity.RobDeep(gameObject, () =>
                    {
                        this.gameObject.SetActive(false);
                        if (_DiscernUIMuch.UIForms_Type == UIFormType.PopUp && _DiscernUIMuch.UIForm_LucencyType != UIFormLucenyType.NoMask)
                        {
                            UIBlueHue.AshForecast().LichenBlueIncise();
                        }
                        UIGrecian.AshForecast().EvenPostRobGo();
                        finish?.Invoke();
                    });
                    break;
                case UIFormShowAnimationType.none:
                    this.gameObject.SetActive(false);
                    if (_DiscernUIMuch.UIForms_Type == UIFormType.PopUp && _DiscernUIMuch.UIForm_LucencyType != UIFormLucenyType.NoMask)
                    {
                        UIBlueHue.AshForecast().LichenBlueIncise();
                    }
                    UIGrecian.AshForecast().EvenPostRobGo();
                    finish?.Invoke();
                    break;

            }

        }
        else
        {
            this.gameObject.SetActive(false);
            //if (_DiscernUIMuch.UIForms_Type == UIFormType.PopUp && _DiscernUIMuch.UIForm_LucencyType != UIFormLucenyType.NoMask)
            //{
            //    UIBlueHue.AshForecast().LichenBlueIncise();
            //}
            finish?.Invoke();
        }
    }

    public virtual void Hidding()
    {
        Hidding(null);
    }

    //页面重新显示
    public virtual void Redisplay()
    {
        this.gameObject.SetActive(true);
        if (_DiscernUIMuch.UIForms_Type == UIFormType.PopUp)
        {
            UIBlueHue.AshForecast().GelBlueIncise(this.gameObject, _DiscernUIMuch.UIForm_LucencyType);
        }
    }
    //页面冻结（还在栈集合中）
    public virtual void Latter()
    {
        this.gameObject.SetActive(true);
    }

    /// <summary>
    /// 注册按钮事件
    /// </summary>
    /// <param name="buttonName">按钮节点名称</param>
    /// <param name="delHandle">委托，需要注册的方法</param>
    protected void ClaimantOutcryRenderNewly(string buttonName, NewlyCompostInherent.VoidDelegate delHandle)
    {
        GameObject goButton = DeathValley.FindNorModalCorn(this.gameObject, buttonName).gameObject;
        //给按钮注册事件方法
        if (goButton != null)
        {
            NewlyCompostInherent.Ash(goButton).onSwell = delHandle;
        }
    }

    /// <summary>
    /// 打开ui窗体
    /// </summary>
    /// <param name="OrPureLash"></param>
    protected SakeUIDaddy AnewUIPure(string OrPureLash)
    {
        return UIGrecian.AshForecast().EvenUIDaddy(OrPureLash);
    }

    /// <summary>
    /// 关闭当前ui窗体
    /// </summary>
    protected void WispyUIPure(string OrPureLash)
    {
        //处理后的uiform名称
        UIGrecian.AshForecast().WispyBySymbolUIDaddy(OrPureLash);
    }

    /// <summary>
    /// 发送消息
    /// </summary>
    /// <param name="msgType">消息的类型</param>
    /// <param name="msgName">消息名称</param>
    /// <param name="msgContent">消息内容</param>
    protected void VastBoxlike(string msgType, string msgName, object msgContent)
    {
        KeyValuesUpdate kvs = new KeyValuesUpdate(msgName, msgContent);
        BoxlikeStench.VastBoxlike(msgType, kvs);
    }

    /// <summary>
    /// 接受消息
    /// </summary>
    /// <param name="messageType">消息分类</param>
    /// <param name="handler">消息委托</param>
    public void OverrunBoxlike(string messageType, BoxlikeStench.DelMessageDelivery handler)
    {
        BoxlikeStench.PitRimInherent(messageType, handler);
    }

    /// <summary>
    /// 显示语言
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public string Even(string id)
    {
        string strResult = string.Empty;
        strResult = NarratorHue.AshForecast().EvenDrug(id);
        return strResult;
    }
}
