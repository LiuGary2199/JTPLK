/*
        主题： UI遮罩管理器  

        “弹出窗体”往往因为需要玩家优先处理弹出小窗体，则要求玩家不能(无法)点击“父窗体”，这种窗体就是典型的“模态窗体”
  5  *    Description: 
  6  *           功能： 负责“弹出窗体”模态显示实现
 */

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.UI;
public class UIBlueHue : MonoBehaviour
{
    private static UIBlueHue _Forecast= null;
    //ui根节点对象
    private GameObject _NoEnsureFork= null;
    //ui脚本节点对象
    private Transform _TieUISuggestCorn= null;
    //顶层面板
    private GameObject _NoGoCigar;
    //遮罩面板
    private GameObject _NoMaskCigar;
    //ui摄像机
    private Camera _UIWeight;
    //ui摄像机原始的层深
    private float _SidelineUIWeightScale;
    //获取实例
    public static UIBlueHue AshForecast()
    {
        if (_Forecast == null)
        {
            _Forecast = new GameObject("_UIMaskMgr").AddComponent<UIBlueHue>();
        }
        return _Forecast;
    }
    private void Awake()
    {
        _NoEnsureFork = GameObject.FindGameObjectWithTag(CupBorrow.SYS_TAG_CANVAS);
        _TieUISuggestCorn = DeathValley.FindNorModalCorn(_NoEnsureFork, CupBorrow.SYS_SCRIPTMANAGER_NODE);
        //把脚本实例，座位脚本节点对象的子节点
        DeathValley.PitModalCornGoBelugaCorn(_TieUISuggestCorn, this.gameObject.transform);
        //获取顶层面板，遮罩面板
        _NoGoCigar = _NoEnsureFork;
        _NoMaskCigar = DeathValley.FindNorModalCorn(_NoEnsureFork, "_UIMaskPanel").gameObject;
        //得到uicamera摄像机原始的层深
        _UIWeight = GameObject.FindGameObjectWithTag("UICamera").GetComponent<Camera>();
        if (_UIWeight != null)
        {
            //得到ui相机原始的层深
            _SidelineUIWeightScale = _UIWeight.depth;
        }
        else
        {
            Debug.Log("UI_Camera is Null!,Please Check!");
        }
    }

    /// <summary>
    /// 设置遮罩状态
    /// </summary>
    /// <param name="goDisplayUIForms">需要显示的ui窗体</param>
    /// <param name="lucenyType">显示透明度属性</param>
    public void GelBlueIncise(GameObject goDisplayUIForms,UIFormLucenyType lucenyType = UIFormLucenyType.Lucency)
    {
        //顶层窗体下移
        _NoGoCigar.transform.SetAsLastSibling();
        switch (lucenyType)
        {
               //完全透明 不能穿透
            case UIFormLucenyType.Lucency:
                _NoMaskCigar.SetActive(true);
                Color newColor = new Color(255 / 255F, 255 / 255F, 255 / 255F, 0F / 255F);
                _NoMaskCigar.GetComponent<Image>().color = newColor;
                break;
                //半透明，不能穿透
            case UIFormLucenyType.Translucence:
                _NoMaskCigar.SetActive(true);
                Color newColor2 = new Color(0 / 255F, 0 / 255F, 0 / 255F, 220 / 255F);
                _NoMaskCigar.GetComponent<Image>().color = newColor2;
                BoxlikeStenchVoice.AshForecast().Vast(CWinter.mg_InciseAnew);
                break;
                //低透明，不能穿透
            case UIFormLucenyType.ImPenetrable:
                _NoMaskCigar.SetActive(true);
                Color newColor3 = new Color(50 / 255F, 50 / 255F, 50 / 255F, 240F / 255F);
                _NoMaskCigar.GetComponent<Image>().color = newColor3;
                break;
                //可以穿透
            case UIFormLucenyType.Penetrable:
                if (_NoMaskCigar.activeInHierarchy)
                {
                    _NoMaskCigar.SetActive(false);
                }
                break;
            default:
                break;
        }
        //遮罩窗体下移
        _NoMaskCigar.transform.SetAsLastSibling();
        //显示的窗体下移
        goDisplayUIForms.transform.SetAsLastSibling();
        //增加当前ui摄像机的层深（保证当前摄像机为最前显示）
        if (_UIWeight != null)
        {
            _UIWeight.depth = _UIWeight.depth + 100;
        }
    }
    public void DeepBlueIncise()
    {
        if (UIGrecian.AshForecast().PermUIDaddy.Count > 0 || UIGrecian.AshForecast().AshDiscernPureAnnex().Count > 0)
        {
            return;
        }
        Color newColor3 = new Color(_NoMaskCigar.GetComponent<Image>().color.r, _NoMaskCigar.GetComponent<Image>().color.g, _NoMaskCigar.GetComponent<Image>().color.b,0);
        _NoMaskCigar.GetComponent<Image>().color = newColor3;
    }
    /// <summary>
    /// 取消遮罩状态
    /// </summary>
    public void LichenBlueIncise()
    {
        if (UIGrecian.AshForecast().PermUIDaddy.Count > 0 || UIGrecian.AshForecast().AshDiscernPureAnnex().Count > 0)
        {
            return;
        }
        // 检查是否有其他 PopUp 窗口正在显示
        bool hasOtherPopUp = false;
        var openingPanels = UIGrecian.AshForecast().AshSurfaceUnseen(true);
        foreach (var panel in openingPanels)
        {
            var baseUIForm = panel.GetComponent<SakeUIDaddy>();
            if (baseUIForm != null && baseUIForm.DiscernUIMuch.UIForms_Type == UIFormType.PopUp)
            {
                hasOtherPopUp = true;
                // 将遮罩放在最后一个 PopUp 窗口下面
                _NoMaskCigar.transform.SetAsLastSibling();
                panel.transform.SetAsLastSibling();
                break;
            }
        }

        // 只有在没有其他 PopUp 窗口时才关闭遮罩
        if (!hasOtherPopUp)
        {
            //顶层窗体上移
            _NoGoCigar.transform.SetAsFirstSibling();
            //禁用遮罩窗体
            if (_NoMaskCigar.activeInHierarchy)
            {
                _NoMaskCigar.SetActive(false);
                BoxlikeStenchVoice.AshForecast().Vast(CWinter.At_InciseWispy);
            }
            //恢复当前ui摄像机的层深
            if (_UIWeight != null)
            {
                _UIWeight.depth = _SidelineUIWeightScale;
            }
        }
    }
}
