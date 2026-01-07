/***
 * 
 * 
 * 网络信息控制
 * 
 * **/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;
using System.Runtime.InteropServices;
//using MoreMountains.NiceVibrations;

public class WedSoulHue : MonoBehaviour
{

    public static WedSoulHue Instance;
    //请求超时时间
    private static float TIMEOUT= 3f;
[UnityEngine.Serialization.FormerlySerializedAs("BaseUrl")]    //base
    public string SakeThe;
[UnityEngine.Serialization.FormerlySerializedAs("BaseLoginUrl")]    //登录url
    public string SakeCrampThe;
[UnityEngine.Serialization.FormerlySerializedAs("BaseConfigUrl")]    //配置url
    public string SakeWinterThe;
[UnityEngine.Serialization.FormerlySerializedAs("BaseTimeUrl")]    //时间戳url
    public string SakePestThe;
[UnityEngine.Serialization.FormerlySerializedAs("BaseAdjustUrl")]    //更新AdjustId url
    public string SakeSandalThe;
[UnityEngine.Serialization.FormerlySerializedAs("GameCode")]    //后台gamecode
    public string RoomTeam= "20000";
[UnityEngine.Serialization.FormerlySerializedAs("Channel")]    //channel渠道平台
    public string Terrain= "AppStore";
    //工程包名
    private string PackageLash{ get { return Application.identifier; } }
    //登录url
    private string CrampThe= "";
    //配置url
    private string WinterThe= "";
    //更新AdjustId url
    private string SandalThe= "";
[UnityEngine.Serialization.FormerlySerializedAs("country")]    //国家
    public string Insight= "";
[UnityEngine.Serialization.FormerlySerializedAs("ConfigData")]    //服务器Config数据
    public ServerData WinterIraq;
[UnityEngine.Serialization.FormerlySerializedAs("InitData")]    //游戏内数据
    public Init WineIraq;
[UnityEngine.Serialization.FormerlySerializedAs("_GameData")]    public GameData _RoomIraq;
[UnityEngine.Serialization.FormerlySerializedAs("CashOut_Data")]    //提现相关后台数据
    public CashOutData MothDew_Iraq;
[UnityEngine.Serialization.FormerlySerializedAs("adManager")]    //ADGrecian
    public GameObject SoGrecian;
    [HideInInspector]
[UnityEngine.Serialization.FormerlySerializedAs("gaid")]    public string Code;
    [HideInInspector]
[UnityEngine.Serialization.FormerlySerializedAs("aid")]    public string Era;
    [HideInInspector]
[UnityEngine.Serialization.FormerlySerializedAs("idfa")]    public string Love;
    int Blame_Drink= 0;
[UnityEngine.Serialization.FormerlySerializedAs("ready")]    public bool Blame= false;
[UnityEngine.Serialization.FormerlySerializedAs("BlockRule")]    //ios 获取idfa函数声明
    public BlockRuleData CargoDeny;
#if UNITY_IOS
    [DllImport("__Internal")]
    internal extern static void getIDFA();
#endif
 
    [HideInInspector] [UnityEngine.Serialization.FormerlySerializedAs("DataFrom")]public string IraqArea; //数据来源 打点用
                                              //提现相关后台数据
#if ZT
    public CashOutData CashOut_Data;
#endif
#if JT
    public JT_CashOutData JT_CashOut_Data;
#endif

    void Awake()
    {
        Instance = this;
        CrampThe = SakeCrampThe + RoomTeam + "&channel=" + Terrain + "&version=" + Application.version;
        WinterThe = SakeWinterThe + RoomTeam + "&channel=" + Terrain + "&version=" + Application.version;
        SandalThe = SakeSandalThe + RoomTeam;
    }
    private void Start()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            AndroidJavaClass aj = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject p = aj.GetStatic<AndroidJavaObject>("currentActivity");
            p.Call("getGaid");
            p.Call("getAid");
        }
        else if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
#if UNITY_IOS
            getIDFA();
            string idfv = UnityEngine.iOS.Device.vendorIdentifier;
            CellIraqGrecian.SetString("idfv", idfv);
#endif
        }
        else
        {
            Cramp();           //编辑器登录
        }
        //获取config数据
        AshWinterIraq();


        //提现登录
        ZJT_Manager.AshForecast().Login();
    }

    /// <summary>
    /// 获取gaid回调
    /// </summary>
    /// <param name="gaid_str"></param>
    public void gaidAction(string gaid_str)
    {
        Debug.Log("unity收到gaid：" + gaid_str);
        Code = gaid_str;
        if (Code == null || Code == "")
        {
            Code = CellIraqGrecian.GetString("gaid");
        }
        else
        {
            CellIraqGrecian.SetString("gaid", Code);
        }
        Blame_Drink++;
        if (Blame_Drink == 2)
        {
            Cramp();
        }
    }
    /// <summary>
    /// 获取aid回调
    /// </summary>
    /// <param name="aid_str"></param>
    public void aidAction(string aid_str)
    {
        Debug.Log("unity收到aid：" + aid_str);
        Era = aid_str;
        if (Era == null || Era == "")
        {
            Era = CellIraqGrecian.GetString("aid");
        }
        else
        {
            CellIraqGrecian.SetString("aid", Era);
        }
        Blame_Drink++;
        if (Blame_Drink == 2)
        {
            Cramp();
        }
    }
    /// <summary>
    /// 获取idfa成功
    /// </summary>
    /// <param name="message"></param>
    public void idfaSuccess(string message)
    {
        Debug.Log("idfa success:" + message);
        Love = message;
        CellIraqGrecian.SetString("idfa", Love);
        Cramp();
    }
    /// <summary>
    /// 获取idfa失败
    /// </summary>
    /// <param name="message"></param>
    public void idfaFail(string message)
    {
        Debug.Log("idfa fail");
        Love = CellIraqGrecian.GetString("idfa");
        Cramp();
    }
    /// <summary>
    /// 登录
    /// </summary>
    public void Cramp()
    {
        //获取本地缓存的Local用户ID
        string localId = CellIraqGrecian.GetString(CWinter.Or_LocalTrimAt);

        //没有用户ID，视为新用户，生成用户ID
        if (localId == "" || localId.Length == 0)
        {
            //生成用户随机id
            TimeSpan st = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0);
            string timeStr = Convert.ToInt64(st.TotalSeconds).ToString() + UnityEngine.Random.Range(0, 10).ToString() + UnityEngine.Random.Range(1, 10).ToString() + UnityEngine.Random.Range(1, 10).ToString() + UnityEngine.Random.Range(1, 10).ToString();
            localId = timeStr;
            CellIraqGrecian.SetString(CWinter.Or_LocalTrimAt, localId);
        }

        //拼接登录接口参数
        string url = "";
        if (Application.platform == RuntimePlatform.IPhonePlayer)       //一个参数 - iOS
        {
            url = CrampThe + "&" + "randomKey" + "=" + localId + "&idfa=" + Love + "&packageName=" + PackageLash;
        }
        else if (Application.platform == RuntimePlatform.Android)  //两个参数 - Android
        {
            url = CrampThe + "&" + "randomKey" + "=" + localId + "&gaid=" + Code + "&androidId=" + Era + "&packageName=" + PackageLash;
        }
        else //编辑器
        {
            url = CrampThe + "&" + "randomKey" + "=" + localId + "&packageName=" + PackageLash;
        }

        //获取国家信息
        SapViolent(() =>
        {
            url += "&country=" + Insight;
            //登录请求
            WedLackGrecian.AshForecast().HttpAsh(url,
                (data) =>
                {
                    Debug.Log("Login 成功" + data.downloadHandler.text);
                    CellIraqGrecian.SetString("init_time", DateTime.Now.ToString());
                    ServerUserData serverUserData = JsonMapper.ToObject<ServerUserData>(data.downloadHandler.text);
                    CellIraqGrecian.SetString(CWinter.Or_RoundInformAt, serverUserData.data.ToString());

                    VastSandalSpew();

                    if (PlayerPrefs.GetInt("SendedEvent") != 1 && !String.IsNullOrEmpty(ColumnStud.FaceMaw))
                        ColumnStud.VastNewly();
                },
                () =>
                {
                    Debug.Log("Login 失败");
                });
        });
    }
    /// <summary>
    /// 获取国家
    /// </summary>
    /// <param name="cb"></param>
    private void SapViolent(Action cb)
    {
        bool callBackReady = false;
        if (String.IsNullOrEmpty(Insight))
        {
            WedLackGrecian.AshForecast().HttpAsh("https://a.mafiagameglobal.com/event/country/", (data) =>
            {
                Insight = JsonMapper.ToObject<Dictionary<string, string>>(data.downloadHandler.text)["country"];
                Debug.Log("获取国家 成功:" + Insight);
                if (!callBackReady)
                {
                    callBackReady = true;
                    cb?.Invoke();
                }
            },
            () =>
            {
                Debug.Log("获取国家 失败");
                if (!callBackReady)
                {
                    Insight = "";
                    callBackReady = true;
                    cb?.Invoke();
                }
            });
        }
        else
        {
            if (!callBackReady)
            {
                callBackReady = true;
                cb?.Invoke();
            }
        }
    }

    /// <summary>
    /// 获取服务器Config数据
    /// </summary>
    private void AshWinterIraq()
    {
        Debug.Log("GetConfigData:" + WinterThe);
        //获取并存入Config
        WedLackGrecian.AshForecast().HttpAsh(WinterThe,
        (data) =>
        {
            IraqArea = "OnlineData";
            Debug.Log("ConfigData 成功" + data.downloadHandler.text);
            CellIraqGrecian.SetString("OnlineData", data.downloadHandler.text);
            GelWinterIraq(data.downloadHandler.text);
        },
        () =>
        {
            Debug.Log("ConfigData 失败");
            AshNationalIraq();
        });
    }

    /// <summary>
    /// 获取本地Config数据
    /// </summary>
    private void AshNationalIraq()
    {
        //是否有缓存
        if (CellIraqGrecian.GetString("OnlineData") == "" || CellIraqGrecian.GetString("OnlineData").Length == 0)
        {
            IraqArea = "LocalData_Updated"; //已联网更新过的数据
            Debug.Log("本地数据");
            TextAsset json = Resources.Load<TextAsset>("LocationJson/LocationData");
            GelWinterIraq(json.text);
        }
        else
        {
            IraqArea = "LocalData_Original"; //原始数据
            Debug.Log("服务器缓存数据");
            GelWinterIraq(CellIraqGrecian.GetString("OnlineData"));
        }
    }

    /// <summary>
    /// 解析config数据
    /// </summary>
    /// <param name="configJson"></param>
    void GelWinterIraq(string configJson)
    {
        //如果已经获得了数据则不再处理
        if (WinterIraq == null)
        {
            RootData rootData = JsonMapper.ToObject<RootData>(configJson);
            WinterIraq = rootData.data;
            WineIraq = JsonMapper.ToObject<Init>(WinterIraq.init);
            _RoomIraq = JsonMapper.ToObject<GameData>(WinterIraq.GameData);
            GameConfig.Instance.SetOnlineConfig();

            if (!string.IsNullOrEmpty(WinterIraq.BlockRule))
                CargoDeny = JsonMapper.ToObject<BlockRuleData>(WinterIraq.BlockRule);
#if ZT
            if (!string.IsNullOrEmpty(ConfigData.CashOut_Data))
                CashOut_Data = JsonMapper.ToObject<CashOutData>(ConfigData.CashOut_Data);
#endif

#if JT
            if (!string.IsNullOrEmpty(WinterIraq.CashOut_Data))
            {
                JT_CashOut_Data = JsonMapper.ToObject<JT_CashOutData>(WinterIraq.CashOut_Data);
                ZJT_Manager.AshForecast().Init();
            }
#endif

            //GameReady();
            AshTrimSoul();
        }
    }
    /// <summary>
    /// 进入游戏
    /// </summary>
    void RoomLapis()
    {
        //打开admanager
        SoGrecian.SetActive(true);
        //进度条可以继续
        Blame = true;
    }

    /// <summary>
    /// 向后台发送adjustId
    /// </summary>
    public void VastSandalSpew()
    {
        string serverId = CellIraqGrecian.GetString(CWinter.Or_RoundInformAt);
        string adjustId = SandalWineGrecian.Instance.AshSandalSpew();
        if (string.IsNullOrEmpty(serverId) || string.IsNullOrEmpty(adjustId))
        {
            return;
        }

        string url = SandalThe + "&serverId=" + serverId + "&adid=" + adjustId;
        WedLackGrecian.AshForecast().HttpAsh(url,
            (data) =>
            {
                Debug.Log("服务器更新adjust adid 成功" + data.downloadHandler.text + " adjustId:" + adjustId);
            },
            () =>
            {
                Debug.Log("服务器更新adjust adid 失败");
            });
      
        //CashOutManager.GetInstance().ReportAdjustID();
    }


    //获取用户信息
    string TrimIraqNss= "";
[UnityEngine.Serialization.FormerlySerializedAs("UserData")]    public UserInfoData TrimIraq;
    int AshTrimSoulImply= 0;
    void AshTrimSoul()
    {
        //检查归因渠道信息
        TraitSandalOrleans();

        //还有进入正常模式的可能
        if (PlayerPrefs.HasKey("OtherChance") && PlayerPrefs.GetString("OtherChance") == "YES")
            PlayerPrefs.DeleteKey("Save_AP");
        //已经记录过用户信息 跳过检查
        if (PlayerPrefs.HasKey("OtherChance") && PlayerPrefs.GetString("OtherChance") == "NO")
        {
            RoomLapis();
            return;
        }

        //获取用户信息
        string CheckUrl = SakeThe + "/api/client/user/checkUser";
        WedLackGrecian.AshForecast().HttpAsh(CheckUrl,
        (data) =>
        {
            TrimIraqNss = data.downloadHandler.text;
            print("+++++ 获取用户数据 成功" + TrimIraqNss);
            UserRootData rootData = JsonMapper.ToObject<UserRootData>(TrimIraqNss);
            TrimIraq = JsonMapper.ToObject<UserInfoData>(rootData.data);
            if (TrimIraqNss.Contains("apple")
            || TrimIraqNss.Contains("Apple")
            || TrimIraqNss.Contains("APPLE"))
                TrimIraq.IsHaveApple = true;
            RoomLapis();
        }, () => { });
        Invoke(nameof(ReAshTrimSoul), 1);
    }
    void ReAshTrimSoul()
    {
        if (!Blame)
        {
            AshTrimSoulImply++;
            if (AshTrimSoulImply < 10)
            {
                print("+++++ 获取用户数据失败 重试： " + AshTrimSoulImply);
                AshTrimSoul();
            }
            else
            {
                print("+++++ 获取用户数据 失败次数过多，放弃");
                RoomLapis();
            }
        }
    }

    //轮询检查Adjust归因信息
    int TraitImply= 0;
    [HideInInspector] [UnityEngine.Serialization.FormerlySerializedAs("IsOrganic")]public bool? OnGeneral;
    public void TraitSandalOrleans() //检查Adjust归因信息
    {
        if (Application.isEditor) //编译器跳过检查
        {
            OnGeneral = true;
            print("Adjust 是否是自然量用户： " + OnGeneral);
            return;
        }
        if (OnGeneral.HasValue) //已经拿到归因信息
            return;

        CancelInvoke(nameof(TraitSandalOrleans));
        try
        {
            com.adjust.sdk.AdjustAttribution Soul= com.adjust.sdk.Adjust.getAttribution();
            if (string.IsNullOrEmpty(Soul.trackerName))
            {
                TraitImply++;
                Debug.Log("Adjust 获取信息失败：" + " 重试次数：" + TraitImply);
                if (TraitImply < 10)
                    Invoke(nameof(TraitSandalOrleans), 1);
                return;
            }
            print("Adjust 获取信息成功 归因渠道：" + Soul.trackerName);
            ColumnStud.Sandal_ShrubbyLash = Soul.trackerName;
            if (Soul.trackerName == "Organic" || Soul.trackerName == "No User Consent")
                OnGeneral = true;
            else
                OnGeneral = false;
        }
        catch (System.Exception e)
        {
            TraitImply++;
            Debug.Log("Adjust 获取信息失败：" + e.Message + " 重试次数：" + TraitImply);
            if (TraitImply < 10)
                Invoke(nameof(TraitSandalOrleans), 1);
        }
    }
}
