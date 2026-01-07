using System;
using System.Collections;
using System.Collections.Generic;
using com.adjust.sdk;
using DG.Tweening;
using LitJson;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class ADGrecian : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("MAX_SDK_KEY")]    public string MAX_SDK_KEY= "";
[UnityEngine.Serialization.FormerlySerializedAs("MAX_REWARD_ID")]    public string MAX_REWARD_ID= "";
[UnityEngine.Serialization.FormerlySerializedAs("MAX_INTER_ID")]    public string MAX_INTER_ID= "";
[UnityEngine.Serialization.FormerlySerializedAs("isTest")]
    public bool isGain= false;
    public static ADGrecian Forecast{ get; private set; }

    private int PeachMassive;   // 广告加载失败后，重新加载广告次数
    private bool GoThunderTo;     // 是否正在播放广告，用于判断切换前后台时是否增加计数

    public int SectNormPestPassive{ get; private set; }   // 距离上次广告的时间间隔
    public int Chinese101{ get; private set; }     // 定时插屏(101)计数器
    public int Chinese102{ get; private set; }     // NoThanks插屏(102)计数器
    public int Chinese103{ get; private set; }     // 后台回前台插屏(103)计数器

    private string AdmireOrleansLash;
    private Action<bool> AdmireThatTourMutual;    // 激励视频回调
    private bool AdmireMonster;     // 激励视频是否成功收到奖励
    private string AdmireSwing;     // 激励视频的打点

    private string ExperimentalOrleansLash;
    private int ExperimentalMuch;      // 当前播放的插屏类型，101/102/103
    private string ExperimentalSwing;     // 插屏广告的的打点
    public bool SpawnPestUnacceptable{ get; private set; } // 定时插屏暂停播放

    private List<Action<ADType>> SoCollegeSupersede;    // 广告播放完成回调列表，用于其他系统广告计数（例如商店看广告任务）

    private long AldosteroneBeachTellurium;     // 切后台时的时间戳
    private Ad_CustomData UnlessToDragonIraq; //激励视频自定义数据
    private Ad_CustomData UnacceptableToDragonIraq; //插屏自定义数据

    private double InterstitialRewardnum = 0;
    bool isTIpsted = false;
    private int ShaleEverestToBuy= 0; // 今日已播放广告次数
    private readonly string[] NearKill= new string[]
    {
        "https://worldtimeapi.org/api/timezone/Etc/UTC",
        "https://timeapi.io/api/Time/current/zone?timeZone=UTC",
        "https://google.com",
        "https://www.bing.com"
    };


    private void Awake()
    {
        Forecast = this;

        StartCoroutine(TraitSkySwissToImply());
    }
    //联网确认是否过了一天联网确认是否过了一天 若过了一天则返回 true，并重置广告次数
    public IEnumerator TraitSkySwissToImply()
    {
        DateTime? netTime = null;
        foreach (string url in NearKill)
        {
            using (UnityEngine.Networking.UnityWebRequest req = UnityEngine.Networking.UnityWebRequest.Head(url))
            {
                yield return req.SendWebRequest();
                if (!req.isNetworkError && !req.isHttpError)
                {
                    if (req.GetResponseHeader("Date") != null)
                    {
                        if (DateTime.TryParse(req.GetResponseHeader("Date"), out DateTime parsed))
                        {
                            netTime = parsed.ToUniversalTime();
                            print("广告计数联网检查 使用接口： " + url + "  时间：" + netTime.Value.Date);
                            break;
                        }
                    }
                    else if (req.downloadHandler.text.Contains("utc_datetime"))
                    {
                        string json = req.downloadHandler.text;
                        int idx = json.IndexOf("utc_datetime");
                        if (idx >= 0)
                        {
                            int start = json.IndexOf(":", idx) + 2;
                            int end = json.IndexOf("\"", start);
                            string timeStr = json.Substring(start, end - start);
                            if (DateTime.TryParse(timeStr, out DateTime parsedJson))
                            {
                                netTime = parsedJson.ToUniversalTime();
                                print("广告计数联网检查 使用接口： " + url + "  时间：" + netTime.Value.Date);
                                break;
                            }
                        }
                    }
                }
            }
        }
        if (netTime == null)
            netTime = DateTime.UtcNow;
        DateTime TodayWatchedAdCheckTime = DateTime.TryParse(CellIraqGrecian.GetString("TodayWatchedAdCheckTime"), out DateTime CheckTime) ? CheckTime : DateTime.UtcNow;
        bool isNewDay = netTime.Value.Date > TodayWatchedAdCheckTime.Date;
        if (isNewDay)
            ShaleEverestToBuy = 0;
        else
            ShaleEverestToBuy = CellIraqGrecian.GetInt("TodayWatchedAdNum");
        TodayWatchedAdCheckTime = netTime.Value;
        CellIraqGrecian.SetString("TodayWatchedAdCheckTime", TodayWatchedAdCheckTime.ToString());
        print("广告计数联网检查 是否过了一天  " + isNewDay);
    }

    private void OnEnable()
    {
        SpawnPestUnacceptable = false;
        GoThunderTo = false;
        SectNormPestPassive = 999;  // 初始时设置一个较大的值，不阻塞插屏广告
        AdmireMonster = false;

        // Android平台将Adjust的adid传给Max；iOS将randomKey传给Max
#if UNITY_ANDROID
        MaxSdk.SetSdkKey(AshPowderIraq.DecryptDES(MAX_SDK_KEY));
        // 将adjust id 传给Max
        string adjustId = CellIraqGrecian.GetString(CWinter.sv_AdjustAdid);
        if (string.IsNullOrEmpty(adjustId))
        {
            adjustId = Adjust.getAdid();
        }
        if (!string.IsNullOrEmpty(adjustId))
        {
            MaxSdk.SetUserId(adjustId);
            MaxSdk.InitializeSdk();
            CellIraqGrecian.SetString(CWinter.sv_AdjustAdid, adjustId);
        }
        else
        {
            StartCoroutine(setAdjustAdid());
        }
#else
        MaxSdk.SetSdkKey(AshPowderIraq.SubsistDES(MAX_SDK_KEY));
        MaxSdk.SetUserId(CellIraqGrecian.GetString(CWinter.Or_LocalTrimAt));
        MaxSdk.InitializeSdk();
#endif

        MaxSdkCallbacks.OnSdkInitializedEvent += (MaxSdkBase.SdkConfiguration sdkConfiguration) =>
        {
            // 打开调试模式
            //MaxSdk.ShowMediationDebugger();

            SturdinessSeasonalCar();
            MaxSdk.SetCreativeDebuggerEnabled(true);

            // 每秒执行一次计数
            InvokeRepeating(nameof(MinutePawnee), 1, 1);
        };
    }

    IEnumerator KeaSandalSpew()
    {
        int i = 0;
        while (i < 5)
        {
            yield return new WaitForSeconds(1);
            if (ColumnStud.OnVacant())
            {
                MaxSdk.SetUserId(CellIraqGrecian.GetString(CWinter.Or_LocalTrimAt));
                MaxSdk.InitializeSdk();
                yield break;
            }
            else
            {
                string adjustId = Adjust.getAdid();
                if (!string.IsNullOrEmpty(adjustId))
                {
                    MaxSdk.SetUserId(adjustId);
                    MaxSdk.InitializeSdk();
                    CellIraqGrecian.SetString(CWinter.Or_SandalSpew, adjustId);
                    yield break;
                }
            }
            i++;
        }
        if (i == 5)
        {
            MaxSdk.SetUserId(CellIraqGrecian.GetString(CWinter.Or_LocalTrimAt));
            MaxSdk.InitializeSdk();
        }
    }

    public void SturdinessSeasonalCar()
    {
        // Attach callback
        MaxSdkCallbacks.Rewarded.OnAdLoadedEvent += OnRewardedAdLoadedEvent;
        MaxSdkCallbacks.Rewarded.OnAdLoadFailedEvent += OnRewardedAdLoadFailedEvent;
        MaxSdkCallbacks.Rewarded.OnAdDisplayedEvent += OnRewardedAdDisplayedEvent;
        MaxSdkCallbacks.Rewarded.OnAdClickedEvent += OnRewardedAdClickedEvent;
        MaxSdkCallbacks.Rewarded.OnAdRevenuePaidEvent += OnRewardedAdRevenuePaidEvent;
        MaxSdkCallbacks.Rewarded.OnAdHiddenEvent += OnRewardedAdHiddenEvent;
        MaxSdkCallbacks.Rewarded.OnAdDisplayFailedEvent += OnRewardedAdFailedToDisplayEvent;
        MaxSdkCallbacks.Rewarded.OnAdReceivedRewardEvent += OnRewardedAdReceivedRewardEvent;

        MaxSdkCallbacks.Interstitial.OnAdLoadedEvent += OnInterstitialLoadedEvent;
        MaxSdkCallbacks.Interstitial.OnAdLoadFailedEvent += OnInterstitialLoadFailedEvent;
        MaxSdkCallbacks.Interstitial.OnAdDisplayedEvent += OnInterstitialDisplayedEvent;
        MaxSdkCallbacks.Interstitial.OnAdClickedEvent += OnInterstitialClickedEvent;
        MaxSdkCallbacks.Interstitial.OnAdRevenuePaidEvent += OnInterstitialRevenuePaidEvent;
        MaxSdkCallbacks.Interstitial.OnAdHiddenEvent += OnInterstitialHiddenEvent;
        MaxSdkCallbacks.Interstitial.OnAdDisplayFailedEvent += OnInterstitialAdFailedToDisplayEvent;

        // Load the first rewarded ad
        FourSeasonalTo();

        // Load the first interstitial
        FourUnacceptable();
    }

    private void FourSeasonalTo()
    {
        MaxSdk.LoadRewardedAd(MAX_REWARD_ID);
    }

    private void FourUnacceptable()
    {
        MaxSdk.LoadInterstitial(MAX_INTER_ID);
    }

    private void OnRewardedAdLoadedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
    {
        // Rewarded ad is ready for you to show. MaxSdk.IsRewardedAdReady(adUnitId) now returns 'true'.

        // Reset retry attempt
        PeachMassive = 0;
        AdmireOrleansLash = adInfo.NetworkName;

        UnlessToDragonIraq = new Ad_CustomData();
        UnlessToDragonIraq.user_id = ZJT_Manager.AshForecast().GetUserID();
        UnlessToDragonIraq.version = Application.version;
        UnlessToDragonIraq.request_id = ZJT_Manager.AshForecast().GetEcpmRequestID();
        UnlessToDragonIraq.vendor = adInfo.NetworkName;
    }

    private void OnRewardedAdLoadFailedEvent(string adUnitId, MaxSdkBase.ErrorInfo errorInfo)
    {
        // Rewarded ad failed to load 
        // AppLovin recommends that you retry with exponentially higher delays, up to a maximum delay (in this case 64 seconds).

        PeachMassive++;
        double retryDelay = Math.Pow(2, Math.Min(6, PeachMassive));

        Invoke(nameof(FourSeasonalTo), (float)retryDelay);
    }

    private void OnRewardedAdDisplayedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
    {
#if UNITY_IOS
        ShootHue.AshForecast().HeShootPorous = !ShootHue.AshForecast().HeShootPorous;
        Time.timeScale = 0;
#endif
    }

    private void OnRewardedAdFailedToDisplayEvent(string adUnitId, MaxSdkBase.ErrorInfo errorInfo, MaxSdkBase.AdInfo adInfo)
    {
        // Rewarded ad failed to display. AppLovin recommends that you load the next ad.
        FourSeasonalTo();
        GoThunderTo = false;
    }

    private void OnRewardedAdClickedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
    {

    }

    private void OnRewardedAdHiddenEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
    {
        // Rewarded ad is hidden. Pre-load the next ad
#if UNITY_IOS
        Time.timeScale = 1;
        ShootHue.AshForecast().HeShootPorous = !ShootHue.AshForecast().HeShootPorous;
#endif

        GoThunderTo = false;
        FourSeasonalTo();
        if (AdmireMonster)
        {
            AdmireMonster = false;
            AdmireThatTourMutual?.Invoke(true);

            AfterToNormMonster(ADType.Rewarded);
            SashNewlyBroker.AshForecast().VastNewly("9007", AdmireSwing);
        }
        else
        {
            AdmireThatTourMutual?.Invoke(false);
        }

        // 上报ecpm
      //  CashOutManager.GetInstance().ReportEcpm(adInfo, RewardAdCustomData.request_id, "REWARD");
    }

    private void OnRewardedAdReceivedRewardEvent(string adUnitId, MaxSdk.Reward reward, MaxSdkBase.AdInfo adInfo)
    {
        // The rewarded ad displayed and the user should receive the reward.
        AdmireMonster = true;
    }

    private void OnRewardedAdRevenuePaidEvent(string adUnitId, MaxSdkBase.AdInfo info)
    {
        // Ad revenue paid. Use this callback to track user revenue.
        //从MAX获取收入数据
        var adRevenue = new AdjustAdRevenue(AdjustConfig.AdjustAdRevenueSourceAppLovinMAX);
        adRevenue.setRevenue(info.Revenue, "USD");
        adRevenue.setAdRevenueNetwork(info.NetworkName);
        adRevenue.setAdRevenueUnit(info.AdUnitIdentifier);
        adRevenue.setAdRevenuePlacement(info.Placement);

        //发回收入数据给自己后台
        string countryCodeByMAX = MaxSdk.GetSdkConfiguration().CountryCode; // "US" for the United States, etc - Note: Do not confuse this with currency code which is "USD"
        SashNewlyBroker.AshForecast().VastNewly("9008", info.Revenue.ToString(), countryCodeByMAX);

        //带广告收入的漏传策略
        //SandalWineGrecian.Instance.AddAdCount(countryCodeByMAX, info.Revenue);

        string adjustAdid = SandalWineGrecian.Instance.AshSandalSpew();
        //发回收入数据给Adjust
        if (!string.IsNullOrEmpty(adjustAdid))
        {
            Adjust.trackAdRevenue(adRevenue);
            UnityEngine.Debug.Log("Max to Adjust (rewarded), adUnitId:" + adUnitId + ", revenue:" + info.Revenue + ", network:" + info.NetworkName + ", unit:" + info.AdUnitIdentifier + ", placement:" + info.Placement);
        }

        // 发回收入数据给Mintegral
        if (!string.IsNullOrEmpty(adjustAdid))
        {
#if UNITY_ANDROID || UNITY_IOS
            MBridgeRevenueParamsEntity mBridgeRevenueParamsEntity = new MBridgeRevenueParamsEntity(MBridgeRevenueParamsEntity.ATTRIBUTION_PLATFORM_ADJUST, adjustAdid);
            ///MaxSdkBase.AdInfo类型的adInfo
            mBridgeRevenueParamsEntity.SetMaxAdInfo(info);
            MBridgeRevenueManager.Track(mBridgeRevenueParamsEntity);
            UnityEngine.Debug.Log(nameof(MBridgeRevenueManager) + "~Rewarded revenue:" + info.Revenue);
#endif
        }
    }

    private void OnInterstitialLoadedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
    {
        // Interstitial ad is ready for you to show. MaxSdk.IsInterstitialReady(adUnitId) now returns 'true'

        // Reset retry attempt
        PeachMassive = 0;
        ExperimentalOrleansLash = adInfo.NetworkName;

        UnacceptableToDragonIraq = new Ad_CustomData();
        UnacceptableToDragonIraq.user_id = ZJT_Manager.AshForecast().GetUserID();
        UnacceptableToDragonIraq.version = Application.version;
        UnacceptableToDragonIraq.request_id = ZJT_Manager.AshForecast().GetEcpmRequestID();
        UnacceptableToDragonIraq.vendor = adInfo.NetworkName;
    }

    private void OnInterstitialLoadFailedEvent(string adUnitId, MaxSdkBase.ErrorInfo errorInfo)
    {
        // Interstitial ad failed to load 
        // AppLovin recommends that you retry with exponentially higher delays, up to a maximum delay (in this case 64 seconds)

        PeachMassive++;
        double retryDelay = Math.Pow(2, Math.Min(6, PeachMassive));

        Invoke(nameof(FourUnacceptable), (float)retryDelay);
    }

    private void OnInterstitialDisplayedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
    {
#if UNITY_IOS
        ShootHue.AshForecast().HeShootPorous = !ShootHue.AshForecast().HeShootPorous;
        Time.timeScale = 0;
#endif
    }

    private void OnInterstitialAdFailedToDisplayEvent(string adUnitId, MaxSdkBase.ErrorInfo errorInfo, MaxSdkBase.AdInfo adInfo)
    {
        // Interstitial ad failed to display. AppLovin recommends that you load the next ad.
        FourUnacceptable();
        GoThunderTo = false;
    }

    private void OnInterstitialClickedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo) { }

    private void OnInterstitialRevenuePaidEvent(string adUnitId, MaxSdkBase.AdInfo info)
    {
        //从MAX获取收入数据
        var adRevenue = new AdjustAdRevenue(AdjustConfig.AdjustAdRevenueSourceAppLovinMAX);
        adRevenue.setRevenue(info.Revenue, "USD");
        adRevenue.setAdRevenueNetwork(info.NetworkName);
        adRevenue.setAdRevenueUnit(info.AdUnitIdentifier);
        adRevenue.setAdRevenuePlacement(info.Placement);

        //发回收入数据给自己后台
        string countryCodeByMAX = MaxSdk.GetSdkConfiguration().CountryCode; // "US" for the United States, etc - Note: Do not confuse this with currency code which is "USD"
        SashNewlyBroker.AshForecast().VastNewly("9108", info.Revenue.ToString(), countryCodeByMAX);

        //带广告收入的漏传策略
        //SandalWineGrecian.Instance.AddAdCount(countryCodeByMAX, info.Revenue);

        //发回收入数据给Adjust
        if (!string.IsNullOrEmpty(SandalWineGrecian.Instance.AshSandalSpew()))
        {
            Adjust.trackAdRevenue(adRevenue);
            UnityEngine.Debug.Log("Max to Adjust (interstitial), adUnitId:" + adUnitId + ", revenue:" + info.Revenue + ", network:" + info.NetworkName + ", unit:" + info.AdUnitIdentifier + ", placement:" + info.Placement);
        }

        // 发回收入数据给Mintegral
        string adjustAdid = SandalWineGrecian.Instance.AshSandalSpew();
        if (!string.IsNullOrEmpty(adjustAdid))
        {
#if UNITY_ANDROID || UNITY_IOS
            MBridgeRevenueParamsEntity mBridgeRevenueParamsEntity = new MBridgeRevenueParamsEntity(MBridgeRevenueParamsEntity.ATTRIBUTION_PLATFORM_ADJUST, adjustAdid);
            ///MaxSdkBase.AdInfo类型的adInfo
            mBridgeRevenueParamsEntity.SetMaxAdInfo(info);
            MBridgeRevenueManager.Track(mBridgeRevenueParamsEntity);
            UnityEngine.Debug.Log(nameof(MBridgeRevenueManager) + "~Interstitial revenue:" + info.Revenue);
#endif
        }
    }

    private void OnInterstitialHiddenEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
    {
        // Interstitial ad is hidden. Pre-load the next ad.
#if UNITY_IOS
        Time.timeScale = 1;
        ShootHue.AshForecast().HeShootPorous = !ShootHue.AshForecast().HeShootPorous;
#endif
        FourUnacceptable();

        AfterToNormMonster(ADType.Interstitial);
        SashNewlyBroker.AshForecast().VastNewly("9107", ExperimentalSwing);
        // 上报ecpm
    //    CashOutManager.GetInstance().ReportEcpm(adInfo, InterstitialAdCustomData.request_id, "INTER");
    }


    /// <summary>
    /// 播放激励视频广告
    /// </summary>
    /// <param name="callBack"></param>
    /// <param name="index"></param>
    public void AmidUnlessRebel(Action<bool> callBack, string index)
    {
        if (isGain)
        {
            callBack(true);
            AfterToNormMonster(ADType.Rewarded);
            return;
        }

        // 自然量用户 超过当日最大播放次数 不播放广告
        if (WedSoulHue.Instance.OnGeneral == true && ShaleEverestToBuy >= WedSoulHue.Instance.CargoDeny.OrganicMaxAdNum)
        {
            ExaltGrecian.AshForecast().EvenExalt("No ads right now, please try it later.");
            callBack(false);
            print("自然量用户超过当日最大播放次数不播放激励广告 当日累计次数： " + ShaleEverestToBuy + "  最大次数： " + WedSoulHue.Instance.CargoDeny.OrganicMaxAdNum);
            return;
        }

        bool rewardVideoReady = MaxSdk.IsRewardedAdReady(MAX_REWARD_ID);
        AdmireThatTourMutual = callBack;
        if (rewardVideoReady)
        {
            // 打点
            AdmireSwing = index;
            SashNewlyBroker.AshForecast().VastNewly("9002", index);
            GoThunderTo = true;
            AdmireMonster = false;
            string placement = index + "_" + AdmireOrleansLash;
            UnlessToDragonIraq.placement_id = placement;
            MaxSdk.ShowRewardedAd(MAX_REWARD_ID, placement, JsonMapper.ToJson(UnlessToDragonIraq));
        }
        else
        {
            ExaltGrecian.AshForecast().EvenExalt("No ads right now, please try it later.");
            AdmireThatTourMutual(false);
        }
    }

    /// <summary>
    /// 播放插屏广告
    /// </summary>
    /// <param name="index"></param>
    public void AmidUnacceptableTo(int index)
    {
        if (index == 101 || index == 102 || index == 103)
        {
            UnityEngine.Debug.LogError("广告点位不允许为101、102、103");
            return;
        }

        AmidUnacceptable(index);
    }

    /// <summary>
    /// 播放插屏广告
    /// </summary>
    /// <param name="index">101/102/103</param>
    /// <param name="customIndex">用户自定义点位</param>
    private void AmidUnacceptable(int index, int customIndex = 0)
    {
        ExperimentalMuch = index;

        if (GoThunderTo)
        {
            return;
        }

        // 自然量用户 超过当日最大播放次数 不播放广告
        if (WedSoulHue.Instance.OnGeneral == true && ShaleEverestToBuy >= WedSoulHue.Instance.CargoDeny.OrganicMaxAdNum)
        {
            print("自然量用户超过当日最大播放次数不播放插屏广告 当日累计次数： " + ShaleEverestToBuy + "  最大次数： " + WedSoulHue.Instance.CargoDeny.OrganicMaxAdNum);
            return;
        }

        // 当用户过关数 < trial_MaxNum时，不弹插屏广告
        int sv_trialNum = CellIraqGrecian.GetInt(CWinter.Or_So_Nurse_Don);
        int trial_MaxNum = int.Parse(WedSoulHue.Instance.WinterIraq.trial_MaxNum);
        if (sv_trialNum < trial_MaxNum)
            return;

        // 时间间隔低于阈值，不播放广告
        if (SectNormPestPassive < int.Parse(WedSoulHue.Instance.WinterIraq.inter_freq))
        {
            return;
        }

        if (isGain)
        {
            AfterToNormMonster(ADType.Interstitial);
            return;
        }

        bool interstitialVideoReady = MaxSdk.IsInterstitialReady(MAX_INTER_ID);
        if (interstitialVideoReady)
        {
            if (ExperimentalMuch == 101)
            {
                GoThunderTo = true;
                DOVirtual.DelayedCall(0.1f, () => //停顿
                {
                    isTIpsted = false;
                    UIGrecian.AshForecast().WispyBySymbolUIDaddy(nameof(InsertTips));
                    string point = index.ToString();
                    if (customIndex > 0)
                    {
                        point += customIndex.ToString().PadLeft(2, '0');
                    }
                    ExperimentalSwing = point;
                    SashNewlyBroker.AshForecast().VastNewly("9102", point);
                    string placement = point + "_" + ExperimentalOrleansLash;
                    UnacceptableToDragonIraq.placement_id = placement;
                    MaxSdk.ShowInterstitial(MAX_INTER_ID, placement, JsonMapper.ToJson(UnacceptableToDragonIraq));
                });
            }
            else
            {
                GoThunderTo = true;
                // 打点
                string point = index.ToString();
                if (customIndex > 0)
                {
                    point += customIndex.ToString().PadLeft(2, '0');
                }
                ExperimentalSwing = point;
                SashNewlyBroker.AshForecast().VastNewly("9102", point);
                string placement = point + "_" + ExperimentalOrleansLash;
                UnacceptableToDragonIraq.placement_id = placement;
                MaxSdk.ShowInterstitial(MAX_INTER_ID, placement, JsonMapper.ToJson(UnacceptableToDragonIraq));
            }
        }
    }

    /// <summary>
    /// 每秒更新一次计数器 - 101计数器 和 时间间隔计数器
    /// </summary>
    private void MinutePawnee()
    {
        SectNormPestPassive++;

        int relax_interval = int.Parse(WedSoulHue.Instance.WinterIraq.relax_interval);
        // 计时器阈值设置为0或负数时，关闭广告101；
        // 播放广告期间不计数；
        if (relax_interval <= 0 || GoThunderTo)
        {
            return;
        }
        else
        {
            Chinese101++;
            if (Chinese101 >= relax_interval && !SpawnPestUnacceptable)
            {
                AmidUnacceptable(101);
            }
            if (Chinese101 + 2 >= relax_interval && !SpawnPestUnacceptable && !isTIpsted)
            {
                if (GoThunderTo)
                {
                    return;
                }
                int sv_trialNum = CellIraqGrecian.GetInt(CWinter.Or_So_Nurse_Don);
                int trial_MaxNum = int.Parse(WedSoulHue.Instance.WinterIraq.trial_MaxNum);
                if (sv_trialNum < trial_MaxNum)
                {
                    return;
                }
                if (SectNormPestPassive < int.Parse(WedSoulHue.Instance.WinterIraq.inter_freq))
                {
                    return;
                }
                if (isGain)
                {
                    AfterToNormMonster(ADType.Interstitial);
                    return;
                }
                bool interstitialVideoReady = MaxSdk.IsInterstitialReady(MAX_INTER_ID);
                if (ColumnStud.OnDaily())
                {
                    return;
                }
                if (interstitialVideoReady)
                {
                    isTIpsted = true;
                    InterstitialRewardnum = GameConfig.Instance.GetTIpsReward();
                    UIGrecian.AshForecast().EvenUIDaddy(nameof(InsertTips));
                    InsertTips.Instance.InitData(InterstitialRewardnum);
                }
            }
        }
    }

    /// <summary>
    /// NoThanks插屏 - 102
    /// </summary>
    public void NoAssertPitImply(int customIndex = 0)
    {
        // 用户行为累计次数计数器阈值设置为0或负数时，关闭广告102
        int nextlevel_interval = int.Parse(WedSoulHue.Instance.WinterIraq.nextlevel_interval);
        if (nextlevel_interval <= 0)
        {
            return;
        }
        else
        {
            Chinese102 = CellIraqGrecian.GetInt("NoThanksCount") + 1;
            CellIraqGrecian.SetInt("NoThanksCount", Chinese102);
            if (Chinese102 >= nextlevel_interval)
            {
                AmidUnacceptable(102, customIndex);
            }
        }
    }

    /// <summary>
    /// 前后台切换计数器 - 103
    /// </summary>
    /// <param name="pause"></param>
    private void OnApplicationPause(bool pause)
    {
        if (!pause)
        {
            // 切回前台
            if (!GoThunderTo)
            {
                // 前后台切换时，播放间隔计数器需要累加切到后台的时间
                if (AldosteroneBeachTellurium > 0)
                {
                    SectNormPestPassive += (int)(LiraStud.Discern() - AldosteroneBeachTellurium);
                    AldosteroneBeachTellurium = 0;
                }
                // 后台切回前台累计次数，后台配置为0或负数，关闭该广告
                int inter_b2f_count = int.Parse(WedSoulHue.Instance.WinterIraq.inter_b2f_count);
                if (inter_b2f_count <= 0)
                {
                    return;
                }
                else
                {
                    Chinese103++;
                    if (Chinese103 >= inter_b2f_count)
                    {
                        AmidUnacceptable(103);
                    }
                }
            }
        }
        else
        {
            // 切到后台
            AldosteroneBeachTellurium = LiraStud.Discern();
        }
    }

    /// <summary>
    /// 暂停定时插屏播放 - 101
    /// </summary>
    public void BeachPestUnacceptable()
    {
        SpawnPestUnacceptable = true;
    }

    /// <summary>
    /// 恢复定时插屏播放 - 101
    /// </summary>
    public void ChangePestUnacceptable()
    {
        SpawnPestUnacceptable = false;
    }

    /// <summary>
    /// 更新游戏的TrialNum
    /// </summary>
    /// <param name="num"></param>
    public void DifferAwfulBuy(int num)
    {
        int sv_trialNum = CellIraqGrecian.GetInt(CWinter.Or_So_Nurse_Don);
        sv_trialNum += num;
        CellIraqGrecian.SetInt(CWinter.Or_So_Nurse_Don, sv_trialNum);
    }

    /// <summary>
    /// 注册看广告的回调事件
    /// </summary>
    /// <param name="callback"></param>
    public void RegisterNormDistance(Action<ADType> callback)
    {
        if (SoCollegeSupersede == null)
        {
            SoCollegeSupersede = new List<Action<ADType>>();
        }

        if (!SoCollegeSupersede.Contains(callback))
        {
            SoCollegeSupersede.Add(callback);
        }
    }

    /// <summary>
    /// 广告播放成功后，执行看广告回调事件
    /// </summary>
    private void AfterToNormMonster(ADType adType)
    {
        GoThunderTo = false;
        // 播放间隔计数器清零
        SectNormPestPassive = 0;
        // 插屏计数器清零
        if (adType == ADType.Interstitial)
        {
            // 计数器清零
            if (ExperimentalMuch == 101)
            {
                RoomCigar.Instance.ImplyMoth((float)InterstitialRewardnum);
                InterstitialRewardnum = 0;
                Chinese101 = 0;
            }
            else if (ExperimentalMuch == 102)
            {
                Chinese102 = 0;
                CellIraqGrecian.SetInt("NoThanksCount", 0);
            }
            else if (ExperimentalMuch == 103)
            {
                Chinese103 = 0;
            }
        }

        // 看广告总数+1
        CellIraqGrecian.SetInt(CWinter.Or_Pylon_So_Don + adType.ToString(), CellIraqGrecian.GetInt(CWinter.Or_Pylon_So_Don + adType.ToString()) + 1);
        // 提现任务 
        if (adType == ADType.Rewarded)
            ZJT_Manager.AshForecast().AddTaskValue("Ad",1);
        ShaleEverestToBuy++;
        CellIraqGrecian.SetInt("TodayWatchedAdNum", ShaleEverestToBuy);
        
        // 回调
        if (SoCollegeSupersede != null && SoCollegeSupersede.Count > 0)
        {
            foreach (Action<ADType> callback in SoCollegeSupersede)
            {
                callback?.Invoke(adType);
            }
        }
    }

    /// <summary>
    /// 获取总的看广告次数
    /// </summary>
    /// <returns></returns>
    public int AshPrideToBuy(ADType adType)
    {
        return CellIraqGrecian.GetInt(CWinter.Or_Pylon_So_Don + adType.ToString());
    }
}

public enum ADType { Interstitial, Rewarded }

[System.Serializable]
public class Ad_CustomData //广告自定义数据
{
    public string user_id; //用户id
    public string version; //版本号
    public string request_id; //请求id
    public string vendor; //渠道
    public string placement_id; //广告位id
}