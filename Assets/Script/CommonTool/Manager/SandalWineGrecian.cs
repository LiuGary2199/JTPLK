using System;
using System.Collections;
using com.adjust.sdk;
using LitJson;
using UnityEngine;
using Random = UnityEngine.Random;

public class SandalWineGrecian : MonoBehaviour
{
    public static SandalWineGrecian Instance;
[UnityEngine.Serialization.FormerlySerializedAs("adjustID")]
    public string BrightID;     // 由遇总的打包工具统一修改，无需手动配置

    //用户adjust 状态KEY
    private string sv_ADWifeWineMuch= "sv_ADJustInitType";

    //adjust 时间戳
    private string Or_ADWifePest= "sv_ADJustTime";

    //adjust行为计数器
    public int _BesidesImply{ get; private set; }

    public double _BesidesNothing{ get; private set; }

    double BrightWineToNothing= 0;


    private void Awake()
    {
        Instance = this;
        CellIraqGrecian.SetString(Or_ADWifePest, LiraStud.Discern().ToString());

#if UNITY_IOS
        CellIraqGrecian.SetString(sv_ADWifeWineMuch, AdjustStatus.OpenAsAct.ToString());
        SandalWine();
#endif
    }

    private void Start()
    {
        _BesidesImply = 0;
    }


    void SandalWine()
    {
#if UNITY_EDITOR
        return;
#endif
        AdjustConfig adjustConfig = new AdjustConfig(BrightID, AdjustEnvironment.Production, false);
        adjustConfig.setLogLevel(AdjustLogLevel.Verbose);
        adjustConfig.setSendInBackground(false);
        adjustConfig.setEventBufferingEnabled(false);
        adjustConfig.setLaunchDeferredDeeplink(true);
        Adjust.start(adjustConfig);

        StartCoroutine(CellSandalSpew());
    }

    private IEnumerator CellSandalSpew()
    {
        while (true)
        {
            string adjustAdid = Adjust.getAdid();
            if (string.IsNullOrEmpty(adjustAdid))
            {
                yield return new WaitForSeconds(1);
            }
            else
            {
                CellIraqGrecian.SetString(CWinter.Or_SandalSpew, adjustAdid);
                WedSoulHue.Instance.VastSandalSpew();
                ZJT_Manager.AshForecast().ReportAdjustID();
                yield break;
            }
        }
    }

    public string AshSandalSpew()
    {
        return CellIraqGrecian.GetString(CWinter.Or_SandalSpew);
    }

    /// <summary>
    /// 获取adjust初始化状态
    /// </summary>
    /// <returns></returns>
    public string AshSandalAccord()
    {
        return CellIraqGrecian.GetString(sv_ADWifeWineMuch);
    }

    /*
     *  API
     *  Adjust 初始化
     */
    public void WineSandalIraq(bool isOldUser = false)
    {
#if UNITY_IOS
            return;
#endif
        // 如果后台配置的adjust_init_act_position <= 0，直接初始化
        if (string.IsNullOrEmpty(WedSoulHue.Instance.WinterIraq.adjust_init_act_position) || int.Parse(WedSoulHue.Instance.WinterIraq.adjust_init_act_position) <= 0)
        {
            CellIraqGrecian.SetString(sv_ADWifeWineMuch, AdjustStatus.OpenAsAct.ToString());
        }
        print(" user init adjust by status :" + CellIraqGrecian.GetString(sv_ADWifeWineMuch));
        //用户二次登录 根据标签初始化
        if (CellIraqGrecian.GetString(sv_ADWifeWineMuch) == AdjustStatus.OldUser.ToString() || CellIraqGrecian.GetString(sv_ADWifeWineMuch) == AdjustStatus.OpenAsAct.ToString())
        {
            print("second login  and  init adjust");
            SandalWine();
        }
    }



    /*
     * API
     *  记录行为累计次数
     *  @param2 打点参数
     */
    public void PitActImply(string param2 = "")
    {
#if UNITY_IOS
            return;
#endif
        if (CellIraqGrecian.GetString(sv_ADWifeWineMuch) != "") return;
        _BesidesImply++;
        print(" add up to :" + _BesidesImply);
        if (string.IsNullOrEmpty(WedSoulHue.Instance.WinterIraq.adjust_init_act_position) || _BesidesImply == int.Parse(WedSoulHue.Instance.WinterIraq.adjust_init_act_position))
        {
            FourSandalOrThe(param2);
        }
    }

    /// <summary>
    /// 记录广告行为累计次数，带广告收入
    /// </summary>
    /// <param name="countryCode"></param>
    /// <param name="revenue"></param>
    public void PitToImply(string countryCode, double revenue)
    {
#if UNITY_IOS
            return;
#endif
        //if (CellIraqGrecian.GetString(sv_ADJustInitType) != "") return;

        _BesidesImply++;
        _BesidesNothing += revenue;
        print(" Ads count: " + _BesidesImply + ", Revenue sum: " + _BesidesNothing);

        //如果后台有adjust_init_adrevenue数据 且 能找到匹配的countryCode，初始化adjustInitAdRevenue
        if (!string.IsNullOrEmpty(WedSoulHue.Instance.WinterIraq.adjust_init_adrevenue))
        {
            JsonData jd = JsonMapper.ToObject(WedSoulHue.Instance.WinterIraq.adjust_init_adrevenue);
            if (jd.ContainsKey(countryCode))
            {
                BrightWineToNothing = double.Parse(jd[countryCode].ToString(), new System.Globalization.CultureInfo("en-US"));
            }
        }

        if (
            string.IsNullOrEmpty(WedSoulHue.Instance.WinterIraq.adjust_init_act_position)                   //后台没有配置限制条件，直接走LoadAdjust
            || (_BesidesImply == int.Parse(WedSoulHue.Instance.WinterIraq.adjust_init_act_position)         //累计广告次数满足adjust_init_act_position条件，且累计广告收入满足adjust_init_adrevenue条件，走LoadAdjust
                && _BesidesNothing >= BrightWineToNothing)
        )
        {
            FourSandalOrThe();
        }
    }

    /*
     * API
     * 根据行为 初始化 adjust
     *  @param2 打点参数 
     */
    public void FourSandalOrThe(string param2 = "")
    {
        if (CellIraqGrecian.GetString(sv_ADWifeWineMuch) != "") return;

        // 根据比例分流   adjust_init_rate_act  行为比例
        if (string.IsNullOrEmpty(WedSoulHue.Instance.WinterIraq.adjust_init_rate_act) || int.Parse(WedSoulHue.Instance.WinterIraq.adjust_init_rate_act) > Random.Range(0, 100))
        {
            print("user finish  act  and  init adjust");
            CellIraqGrecian.SetString(sv_ADWifeWineMuch, AdjustStatus.OpenAsAct.ToString());
            SandalWine();

            // 上报点位 新用户达成 且 初始化
            SashNewlyBroker.AshForecast().VastNewly("1091", AshSandalPest(), param2);
        }
        else
        {
            print("user finish  act  and  not init adjust");
            CellIraqGrecian.SetString(sv_ADWifeWineMuch, AdjustStatus.CloseAsAct.ToString());
            // 上报点位 新用户达成 且  不初始化
            SashNewlyBroker.AshForecast().VastNewly("1092", AshSandalPest(), param2);
        }
    }


    /*
     * API
     *  重置当前次数
     */
    public void SwissTheImply()
    {
        print("clear current ");
        _BesidesImply = 0;
    }


    // 获取启动时间
    private string AshSandalPest()
    {
        return LiraStud.Discern() - long.Parse(CellIraqGrecian.GetString(Or_ADWifePest)) + "";
    }
}


/*
 *@param
 *  OldUser     老用户
 *  OpenAsAct   行为触发且初始化
 *  CloseAsAct  行为触发不初始化
 */
public enum AdjustStatus
{
    OldUser,
    OpenAsAct,
    CloseAsAct
}