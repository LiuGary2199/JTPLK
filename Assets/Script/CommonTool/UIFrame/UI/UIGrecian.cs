/*
*
*   功能：整个UI框架的核心，用户程序通过调用本类，来调用本框架的大多数功能。  
*           功能1：关于入“栈”与出“栈”的UI窗体4个状态的定义逻辑
*                 入栈状态：
*                     Freeze();   （上一个UI窗体）冻结
*                     Display();  （本UI窗体）显示
*                 出栈状态： 
*                     Hiding();    (本UI窗体) 隐藏
*                     Redisplay(); (上一个UI窗体) 重新显示
*          功能2：增加“非栈”缓存集合。 
* 
* 
* ***/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
/// <summary>
/// UI窗体管理器脚本（框架核心脚本）
/// 主要负责UI窗体的加载、缓存、以及对于“UI窗体基类”的各种生命周期的操作（显示、隐藏、重新显示、冻结）。
/// </summary>
public class UIGrecian : MonoBehaviour
{
    [HideInInspector]
[UnityEngine.Serialization.FormerlySerializedAs("MainCanvas")]    public Canvas MainEnsure;
    private static UIGrecian _Forecast= null;
    //ui窗体预设路径（参数1，窗体预设名称，2，表示窗体预设路径）
    private Dictionary<string, string> _FeeDaddyArise;
    //缓存所有的ui窗体
    private Dictionary<string, SakeUIDaddy> _FeeALLUIDaddy;
    //栈结构标识当前ui窗体的集合
    private Stack<SakeUIDaddy> _SodDiscernUIDaddy;
    //当前显示的ui窗体
    private Dictionary<string, SakeUIDaddy> _FeeDiscernEvenUIDaddy;
    //临时关闭窗口
    private List<UIFormParams> _PermUIDaddy;
    //ui根节点
    private Transform _TieEnsureShortness= null;
    //全屏幕显示的节点
    [HideInInspector] [UnityEngine.Serialization.FormerlySerializedAs("_TraNormal")]public Transform _TieMatrix= null;
    //固定显示的节点
    private Transform _TiePeace= null;
    //弹出节点
    private Transform _TieRobGo= null;
    //ui特效节点
    [HideInInspector] [UnityEngine.Serialization.FormerlySerializedAs("_Top")]public Transform _Net= null;
    //ui管理脚本的节点
    private Transform _TieUISuggest= null;
    [HideInInspector] [UnityEngine.Serialization.FormerlySerializedAs("_TraUICamera")]public Transform _TieUIWeight= null;
    public Camera UIWeight{ get; private set; }
    [HideInInspector]
[UnityEngine.Serialization.FormerlySerializedAs("PanelName")]    public string CigarLash;
    List<string> CigarLashRent;
    public List<UIFormParams> PermUIDaddy    {
        get
        {
            return _PermUIDaddy;
        }
    }
    //得到实例
    public static UIGrecian AshForecast()
    {
        if (_Forecast == null)
        {
            _Forecast = new GameObject("_UIManager").AddComponent<UIGrecian>();

        }
        return _Forecast;
    }
    //初始化核心数据，加载ui窗体路径到集合中
    public void Awake()
    {
        CigarLashRent = new List<string>();
        //字段初始化
        _FeeALLUIDaddy = new Dictionary<string, SakeUIDaddy>();
        _FeeDiscernEvenUIDaddy = new Dictionary<string, SakeUIDaddy>();
        _PermUIDaddy = new List<UIFormParams>();
        _FeeDaddyArise = new Dictionary<string, string>();
        _SodDiscernUIDaddy = new Stack<SakeUIDaddy>();
        //初始化加载（根ui窗体）canvas预设
        WineForkEnsureLoading();
        //得到UI根节点，全屏节点，固定节点，弹出节点
        //Debug.Log("this.gameobject" + this.gameObject.name);
        _TieEnsureShortness = GameObject.FindGameObjectWithTag(CupBorrow.SYS_TAG_CANVAS).transform;
        _TieMatrix = DeathValley.FindNorModalCorn(_TieEnsureShortness.gameObject, CupBorrow.SYS_NORMAL_NODE);
        _TiePeace = DeathValley.FindNorModalCorn(_TieEnsureShortness.gameObject, CupBorrow.SYS_FIXED_NODE);
        _TieRobGo = DeathValley.FindNorModalCorn(_TieEnsureShortness.gameObject, CupBorrow.SYS_POPUP_NODE);
        _Net = DeathValley.FindNorModalCorn(_TieEnsureShortness.gameObject, CupBorrow.SYS_TOP_NODE);
        _TieUISuggest = DeathValley.FindNorModalCorn(_TieEnsureShortness.gameObject, CupBorrow.SYS_SCRIPTMANAGER_NODE);
        _TieUIWeight = DeathValley.FindNorModalCorn(_TieEnsureShortness.gameObject, CupBorrow.SYS_UICAMERA_NODE);
        //把本脚本作为“根ui窗体”的子节点
        DeathValley.PitModalCornGoBelugaCorn(_TieUISuggest, this.gameObject.transform);
        //根UI窗体在场景转换的时候，不允许销毁
        DontDestroyOnLoad(_TieEnsureShortness);
        //初始化ui窗体预设路径数据
        WineUIDaddyAriseIraq();
        //初始化UI相机参数，主要是解决URP管线下UI相机的问题
        WineWeight();
    }
    private void PitCigar(string name)
    {
        if (!CigarLashRent.Contains(name))
        {
            CigarLashRent.Add(name);
            CigarLash = name;
        }
    }
    private void EarCigar(string name)
    {
        if (CigarLashRent.Contains(name))
        {
            CigarLashRent.Remove(name);
        }
        if (CigarLashRent.Count == 0)
        {
            CigarLash = "";
        }
        else
        {
            CigarLash = CigarLashRent[0];
        }
    }
    //初始化加载（根ui窗体）canvas预设
    private void WineForkEnsureLoading()
    {
        MainEnsure = EmbroiderHue.AshForecast().FourDozen(CupBorrow.SYS_PATH_CANVAS, false).GetComponent<Canvas>();
    }
    /// <summary>
    /// 显示ui窗体
    /// 功能：1根据ui窗体的名称，加载到所有ui窗体缓存集合中
    /// 2,根据不同的ui窗体的显示模式，分别做不同的加载处理
    /// </summary>
    /// <param name="OrPureLash">ui窗体预设的名称</param>
    public SakeUIDaddy EvenUIDaddy(string OrPureLash, object OrPureDemise = null)
    {
        //参数的检查
        if (string.IsNullOrEmpty(OrPureLash)) return null;
        //根据ui窗体的名称，把加载到所有ui窗体缓存集合中
        //ui窗体的基类
        SakeUIDaddy baseUIForms = FourDaddyGoALLUIDaddyCanoe(OrPureLash);
        if (baseUIForms == null) return null;

        PitCigar(OrPureLash);

        //判断是否清空“栈”结构体集合
        if (baseUIForms.DiscernUIMuch.OnBreedExploreFeeble)
        {
            BreedAnnexGreen();
        }
        //根据不同的ui窗体的显示模式，分别做不同的加载处理
        switch (baseUIForms.DiscernUIMuch.UIForm_ShowMode)
        {
            case UIFormShowMode.Normal:
                FiordUIDaddyThigh(OrPureLash, OrPureDemise);
                break;
            case UIFormShowMode.ReverseChange:
                FateUIDaddy(OrPureLash, OrPureDemise);
                break;
            case UIFormShowMode.HideOther:
                FiordUIResaleGoThighDeepInfer(OrPureLash, OrPureDemise);
                break;
            case UIFormShowMode.Wait:
                FiordUIDaddyThighPermWispy(OrPureLash, OrPureDemise);
                break;
            default:
                break;
        }
        return baseUIForms;
    }

    /// <summary>
    /// 关闭或返回上一个ui窗体（关闭当前ui窗体）
    /// </summary>
    /// <param name="strUIFormsName"></param>
    public void WispyBySymbolUIDaddy(string strUIFormsName)
    {
        EarCigar(strUIFormsName);
        //Debug.Log("关闭窗体的名字是" + strUIFormsName);
        //ui窗体的基类
        SakeUIDaddy baseUIForms = null;
        if (string.IsNullOrEmpty(strUIFormsName)) return;
        _FeeALLUIDaddy.TryGetValue(strUIFormsName, out baseUIForms);
        //所有窗体缓存中没有记录，则直接返回
        if (baseUIForms == null) return;
        //判断不同的窗体显示模式，分别处理
        switch (baseUIForms.DiscernUIMuch.UIForm_ShowMode)
        {
            case UIFormShowMode.Normal:
                MoveUIDaddyThigh(strUIFormsName);
                break;

            case UIFormShowMode.ReverseChange:
                RobUIDaddy();
                break;
            case UIFormShowMode.HideOther:
                MoveUIDaddyAreaThighSkyEvenInfer(strUIFormsName);
                break;
            case UIFormShowMode.Wait:
                MoveUIDaddyThigh(strUIFormsName);
                break;
            default:
                break;
        }

    }
    /// <summary>
    /// 显示下一个弹窗如果有的话
    /// </summary>
    public void EvenPostRobGo()
    {
        if (_PermUIDaddy.Count > 0)
        {
            EvenUIDaddy(_PermUIDaddy[0].OrPureLash, _PermUIDaddy[0].OrPureDemise);
            _PermUIDaddy.RemoveAt(0);
        }
    }

    /// <summary>
    /// 清空当前等待中的UI
    /// </summary>
    public void BreedPermUIDaddy()
    {
        if (_PermUIDaddy.Count > 0)
        {
            _PermUIDaddy = new List<UIFormParams>();
        }
    }
    /// <summary>
    /// 根据UI窗体的名称，加载到“所有UI窗体”缓存集合中
    /// 功能： 检查“所有UI窗体”集合中，是否已经加载过，否则才加载。
    /// </summary>
    /// <param name="uiFormsName">UI窗体（预设）的名称</param>
    /// <returns></returns>
    private SakeUIDaddy FourDaddyGoALLUIDaddyCanoe(string OrPureLash)
    {
        //加载的返回ui窗体基类
        SakeUIDaddy baseUIResult = null;
        _FeeALLUIDaddy.TryGetValue(OrPureLash, out baseUIResult);
        if (baseUIResult == null)
        {
            //加载指定名称ui窗体
            baseUIResult = FourUIPure(OrPureLash);

        }
        return baseUIResult;
    }
    /// <summary>
    /// 加载指定名称的“UI窗体”
    /// 功能：
    ///    1：根据“UI窗体名称”，加载预设克隆体。
    ///    2：根据不同预设克隆体中带的脚本中不同的“位置信息”，加载到“根窗体”下不同的节点。
    ///    3：隐藏刚创建的UI克隆体。
    ///    4：把克隆体，加入到“所有UI窗体”（缓存）集合中。
    /// 
    /// </summary>
    /// <param name="OrPureLash">UI窗体名称</param>
    private SakeUIDaddy FourUIPure(string OrPureLash)
    {
        string strUIFormPaths = null;
        GameObject goCloneUIPrefabs = null;
        SakeUIDaddy baseUIForm = null;
        //根据ui窗体名称，得到对应的加载路径
        _FeeDaddyArise.TryGetValue(OrPureLash, out strUIFormPaths);
        if (!string.IsNullOrEmpty(strUIFormPaths))
        {
            //加载预制体
            goCloneUIPrefabs = EmbroiderHue.AshForecast().FourDozen(strUIFormPaths, false);
        }
        //设置ui克隆体的父节点（根据克隆体中带的脚本中不同的信息位置信息）
        if (_TieEnsureShortness != null && goCloneUIPrefabs != null)
        {
            baseUIForm = goCloneUIPrefabs.GetComponent<SakeUIDaddy>();
            if (baseUIForm == null)
            {
                Debug.Log("baseUiForm==null! ,请先确认窗体预设对象上是否加载了baseUIForm的子类脚本！ 参数 OrPureLash=" + OrPureLash);
                return null;
            }
            switch (baseUIForm.DiscernUIMuch.UIForms_Type)
            {
                case UIFormType.Normal:
                    goCloneUIPrefabs.transform.SetParent(_TieMatrix, false);
                    break;
                case UIFormType.Fixed:
                    goCloneUIPrefabs.transform.SetParent(_TiePeace, false);
                    break;
                case UIFormType.PopUp:
                    goCloneUIPrefabs.transform.SetParent(_TieRobGo, false);
                    break;
                case UIFormType.Top:
                    goCloneUIPrefabs.transform.SetParent(_Net, false);
                    break;
                default:
                    break;
            }
            //设置隐藏
            goCloneUIPrefabs.SetActive(false);
            //把克隆体，加入到所有ui窗体缓存集合中
            _FeeALLUIDaddy.Add(OrPureLash, baseUIForm);
            return baseUIForm;
        }
        else
        {
            Debug.Log("_TraCanvasTransfrom==null Or goCloneUIPrefabs==null!! ,Plese Check!, 参数OrPureLash=" + OrPureLash);
        }
        Debug.Log("出现不可以预估的错误，请检查，参数 OrPureLash=" + OrPureLash);
        return null;
    }
    /// <summary>
    /// 把当前窗体加载到当前窗体集合中
    /// </summary>
    /// <param name="OrPureLash">窗体预设的名字</param>
    private void FiordUIDaddyThigh(string OrPureLash, object OrPureDemise)
    {
        //ui窗体基类
        SakeUIDaddy baseUIForm;
        //从所有窗体集合中得到的窗体
        SakeUIDaddy baseUIFormFromAllCache;
        //如果正在显示的集合中存在该窗体，直接返回
        _FeeDiscernEvenUIDaddy.TryGetValue(OrPureLash, out baseUIForm);
        if (baseUIForm != null) return;
        //把当前窗体，加载到正在显示集合中
        _FeeALLUIDaddy.TryGetValue(OrPureLash, out baseUIFormFromAllCache);
        if (baseUIFormFromAllCache != null)
        {
            _FeeDiscernEvenUIDaddy.Add(OrPureLash, baseUIFormFromAllCache);
            //显示当前窗体
            baseUIFormFromAllCache.Display(OrPureDemise);

        }
    }

    /// <summary>
    /// 卸载ui窗体从当前显示的集合缓存中
    /// </summary>
    /// <param name="strUIFormsName"></param>
    private void MoveUIDaddyThigh(string strUIFormsName)
    {
        //ui窗体基类
        SakeUIDaddy baseUIForms;
        //正在显示ui窗体缓存集合没有记录，则直接返回
        _FeeDiscernEvenUIDaddy.TryGetValue(strUIFormsName, out baseUIForms);
        if (baseUIForms == null) return;
        //指定ui窗体，运行隐藏，且从正在显示ui窗体缓存集合中移除
        baseUIForms.Hidding();
        _FeeDiscernEvenUIDaddy.Remove(strUIFormsName);
    }

    /// <summary>
    /// 加载ui窗体到当前显示窗体集合，且，隐藏其他正在显示的页面
    /// </summary>
    /// <param name="strUIFormsName"></param>
    private void FiordUIResaleGoThighDeepInfer(string strUIFormsName, object OrPureDemise)
    {
        //窗体基类
        SakeUIDaddy baseUIForms;
        //所有窗体集合中的窗体基类
        SakeUIDaddy baseUIFormsFromAllCache;
        _FeeDiscernEvenUIDaddy.TryGetValue(strUIFormsName, out baseUIForms);
        //正在显示ui窗体缓存集合里有记录，直接返回
        if (baseUIForms != null) return;
        Debug.Log("关闭其他窗体");
        //正在显示ui窗体缓存 与栈缓存集合里所有的窗体进行隐藏处理
        List<SakeUIDaddy> ShowUIFormsList = new List<SakeUIDaddy>(_FeeDiscernEvenUIDaddy.Values);
        foreach (SakeUIDaddy baseUIFormsItem in ShowUIFormsList)
        {
            //Debug.Log("_DicCurrentShowUIForms---------" + baseUIFormsItem.transform.name);
            if (baseUIFormsItem.DiscernUIMuch.UIForms_Type == UIFormType.PopUp)
            {
                //baseUIFormsItem.Hidding();
                MoveUIDaddyAreaThighSkyEvenInfer(baseUIFormsItem.GetType().Name);
            }
        }
        List<SakeUIDaddy> CurrentUIFormsList = new List<SakeUIDaddy>(_SodDiscernUIDaddy);
        foreach (SakeUIDaddy baseUIFormsItem in CurrentUIFormsList)
        {
            //Debug.Log("_StaCurrentUIForms---------"+baseUIFormsItem.transform.name);
            //baseUIFormsItem.Hidding();
            MoveUIDaddyAreaThighSkyEvenInfer(baseUIFormsItem.GetType().Name);
        }
        //把当前窗体，加载到正在显示ui窗体缓存集合中 
        _FeeALLUIDaddy.TryGetValue(strUIFormsName, out baseUIFormsFromAllCache);
        if (baseUIFormsFromAllCache != null)
        {
            _FeeDiscernEvenUIDaddy.Add(strUIFormsName, baseUIFormsFromAllCache);
            baseUIFormsFromAllCache.Display(OrPureDemise);
        }
    }
    /// <summary>
    /// 把当前窗体加载到当前窗体集合中
    /// </summary>
    /// <param name="OrPureLash">窗体预设的名字</param>
    private void FiordUIDaddyThighPermWispy(string OrPureLash, object OrPureDemise)
    {
        //ui窗体基类
        SakeUIDaddy baseUIForm;
        //从所有窗体集合中得到的窗体
        SakeUIDaddy baseUIFormFromAllCache;
        //如果正在显示的集合中存在该窗体，直接返回
        _FeeDiscernEvenUIDaddy.TryGetValue(OrPureLash, out baseUIForm);
        if (baseUIForm != null) return;
        bool havePopUp = false;
        foreach (SakeUIDaddy uiforms in _FeeDiscernEvenUIDaddy.Values)
        {
            if (uiforms.DiscernUIMuch.UIForms_Type == UIFormType.PopUp)
            {
                havePopUp = true;
                break;
            }
        }
        if (!havePopUp)
        {
            //把当前窗体，加载到正在显示集合中
            _FeeALLUIDaddy.TryGetValue(OrPureLash, out baseUIFormFromAllCache);
            if (baseUIFormFromAllCache != null)
            {
                _FeeDiscernEvenUIDaddy.Add(OrPureLash, baseUIFormFromAllCache);
                //显示当前窗体
                baseUIFormFromAllCache.Display(OrPureDemise);

            }
        }
        else
        {
            _PermUIDaddy.Add(new UIFormParams() { OrPureLash = OrPureLash, OrPureDemise = OrPureDemise });
        }

    }
    /// <summary>
    /// 卸载ui窗体从当前显示窗体集合缓存中，且显示其他原本需要显示的页面
    /// </summary>
    /// <param name="strUIFormsName"></param>
    private void MoveUIDaddyAreaThighSkyEvenInfer(string strUIFormsName)
    {
        //ui窗体基类
        SakeUIDaddy baseUIForms;
        _FeeDiscernEvenUIDaddy.TryGetValue(strUIFormsName, out baseUIForms);
        if (baseUIForms == null) return;
        //指定ui窗体 ，运行隐藏状态，且从正在显示ui窗体缓存集合中删除
        baseUIForms.Hidding();
        _FeeDiscernEvenUIDaddy.Remove(strUIFormsName);
        //正在显示ui窗体缓存与栈缓存集合里素有窗体进行再次显示
        //foreach (SakeUIDaddy baseUIFormsItem in _DicCurrentShowUIForms.Values)
        //{
        //    baseUIFormsItem.Redisplay();
        //}
        //foreach (SakeUIDaddy baseUIFormsItem in _StaCurrentUIForms)
        //{
        //    baseUIFormsItem.Redisplay();
        //}
    }
    /// <summary>
    /// ui窗体入栈
    /// 功能：1判断栈里是否已经有窗体，有则冻结
    ///   2先判断ui预设缓存集合是否有指定的ui窗体，有则处理
    ///   3指定ui窗体入栈
    /// </summary>
    /// <param name="strUIFormsName"></param>
    private void FateUIDaddy(string strUIFormsName, object OrPureDemise)
    {
        //ui预设窗体
        SakeUIDaddy baseUI;
        //判断栈里是否已经有窗体,有则冻结
        if (_SodDiscernUIDaddy.Count > 0)
        {
            SakeUIDaddy topUIForms = _SodDiscernUIDaddy.Peek();
            topUIForms.Latter();
            //Debug.Log("topUIForms是" + topUIForms.name);
        }
        //先判断ui预设缓存集合是否有指定ui窗体，有则处理
        _FeeALLUIDaddy.TryGetValue(strUIFormsName, out baseUI);
        if (baseUI != null)
        {
            baseUI.Display(OrPureDemise);
        }
        else
        {
            Debug.Log(string.Format("/PushUIForms()/ baseUI==null! 核心错误，请检查 strUIFormsName={0} ", strUIFormsName));
        }
        //指定ui窗体入栈
        _SodDiscernUIDaddy.Push(baseUI);

    }

    /// <summary>
    /// ui窗体出栈逻辑
    /// </summary>
    private void RobUIDaddy()
    {

        if (_SodDiscernUIDaddy.Count >= 2)
        {
            //出栈逻辑
            SakeUIDaddy topUIForms = _SodDiscernUIDaddy.Pop();
            //出栈的窗体进行隐藏
            topUIForms.Hidding(() =>
            {
                //出栈窗体的下一个窗体逻辑
                SakeUIDaddy nextUIForms = _SodDiscernUIDaddy.Peek();
                //下一个窗体重新显示处理
                nextUIForms.Redisplay();
            });
        }
        else if (_SodDiscernUIDaddy.Count == 1)
        {
            SakeUIDaddy topUIForms = _SodDiscernUIDaddy.Pop();
            //出栈的窗体进行隐藏处理
            topUIForms.Hidding();
        }
    }


    /// <summary>
    /// 初始化ui窗体预设路径数据
    /// </summary>
    private void WineUIDaddyAriseIraq()
    {
        IWinterGrecian configMgr = new WinterGrecianDyMute(CupBorrow.SYS_PATH_UIFORMS_CONFIG_INFO);
        if (_FeeDaddyArise != null)
        {
            _FeeDaddyArise = configMgr.SeaPavlova;
        }
    }

    /// <summary>
    /// 初始化UI相机参数
    /// </summary>
    private void WineWeight()
    {
        //当渲染管线为URP时，将UI相机的渲染方式改为Overlay，并加入主相机堆栈
        // RenderPipelineAsset currentPipeline = GraphicsSettings.renderPipelineAsset;
        // if (currentPipeline != null && currentPipeline.name == "UniversalRenderPipelineAsset")
        // {
        //     UICamera = _TraUICamera.GetComponent<Camera>();
        //     UICamera.GetUniversalAdditionalCameraData().renderType = CameraRenderType.Overlay;
        //     Camera.main.GetUniversalAdditionalCameraData().cameraStack.Add(_TraUICamera.GetComponent<Camera>());
        // }
    }

    /// <summary>
    /// 清空栈结构体集合
    /// </summary>
    /// <returns></returns>
    private bool BreedAnnexGreen()
    {
        if (_SodDiscernUIDaddy != null && _SodDiscernUIDaddy.Count >= 1)
        {
            _SodDiscernUIDaddy.Clear();
            return true;
        }
        return false;
    }
    /// <summary>
    /// 获取当前弹框ui的栈
    /// </summary>
    /// <returns></returns>
    public Stack<SakeUIDaddy> AshDiscernPureAnnex()
    {
        return _SodDiscernUIDaddy;
    }


    /// <summary>
    /// 根据panel名称获取panel gameObject
    /// </summary>
    /// <param name="OrPureLash"></param>
    /// <returns></returns>
    public GameObject AshCigarDyLash(string OrPureLash)
    {
        //ui窗体基类
        SakeUIDaddy baseUIForm;
        //如果正在显示的集合中存在该窗体，直接返回
        _FeeALLUIDaddy.TryGetValue(OrPureLash, out baseUIForm);
        return baseUIForm?.gameObject;
    }

    /// <summary>
    /// 获取所有打开的panel（不包括Normal）
    /// </summary>
    /// <returns></returns>
    public List<GameObject> AshSurfaceUnseen(bool containNormal = false)
    {
        List<GameObject> openingPanels = new List<GameObject>();
        List<SakeUIDaddy> allUIFormsList = new List<SakeUIDaddy>(_FeeALLUIDaddy.Values);
        foreach (SakeUIDaddy panel in allUIFormsList)
        {
            if (panel.gameObject.activeInHierarchy)
            {
                if (containNormal || panel._DiscernUIMuch.UIForms_Type != UIFormType.Normal)
                {
                    openingPanels.Add(panel.gameObject);
                }
            }
        }

        return openingPanels;
    }
}

public class UIFormParams
{
    public string OrPureLash;   // 窗体名称
    public object OrPureDemise; // 窗体参数
}
