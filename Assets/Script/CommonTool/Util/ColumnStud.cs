using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnStud
{
    [HideInInspector] public static string Sandal_ShrubbyLash; //归因渠道名称 由WedSoulHue的CheckAdjustNetwork方法赋值
    static string Cell_AP; //ApplePie的本地存档 存储第一次进入状态 未来不再受ApplePie开关影响
    static string MatrixTallLash= "pie"; //正常模式名称
    static string Virginian; //距离黑名单位置的距离 打点用
    static string Induct; //进审理由 打点用
    [HideInInspector] public static string FaceMaw= ""; //判断流程 打点用

    public static bool OnDaily()
    {
        //测试
       // return true;

        if (Application.platform == RuntimePlatform.Android) //安卓平台无需判断ApplePie
            return false;

        if (PlayerPrefs.HasKey("Save_AP"))  //优先使用本地存档
            Cell_AP = PlayerPrefs.GetString("Save_AP");
        if (string.IsNullOrEmpty(Cell_AP)) //无本地存档 读取网络数据
            TraitNamelyIraq();

        if (Cell_AP != "P")
            return true;
        else
            return false;
    }
    public static void TraitNamelyIraq() //读取网络数据 判断进入哪种游戏模式
    {
        string OtherChance = "NO"; //进审之后 是否还有可能变正常
        Cell_AP = "P";
        if (WedSoulHue.Instance.WinterIraq.apple_pie != MatrixTallLash) //审模式 
        {
            OtherChance = "YES";
            Cell_AP = "A";
            if (string.IsNullOrEmpty(Induct))
                Induct = "ApplePie";
        }
        FaceMaw = "0:" + Cell_AP;
        //判断运营商信息
        if (WedSoulHue.Instance.TrimIraq != null && WedSoulHue.Instance.TrimIraq.IsHaveApple)
        {
            Cell_AP = "A";
            if (string.IsNullOrEmpty(Induct))
                Induct = "HaveApple";
            FaceMaw += "1:" + Cell_AP;
        }
        if (WedSoulHue.Instance.CargoDeny != null)
        {
            //判断经纬度
            LocationData[] LocationDatas = WedSoulHue.Instance.CargoDeny.LocationList;
            if (LocationDatas != null && LocationDatas.Length > 0 && WedSoulHue.Instance.TrimIraq != null && WedSoulHue.Instance.TrimIraq.lat != 0 && WedSoulHue.Instance.TrimIraq.lon != 0)
            {
                for (int i = 0; i < LocationDatas.Length; i++)
                {
                    float Distance = AshCarnival((float)LocationDatas[i].X, (float)LocationDatas[i].Y,
                    (float)WedSoulHue.Instance.TrimIraq.lat, (float)WedSoulHue.Instance.TrimIraq.lon);
                    Virginian += Distance.ToString() + ",";
                    if (Distance <= LocationDatas[i].Radius)
                    {
                        Cell_AP = "A";
                        if (string.IsNullOrEmpty(Induct))
                            Induct = "Location";
                        break;
                    }
                }
            }
            FaceMaw += "2:" + Cell_AP;
            //判断城市
            string[] HeiCityList = WedSoulHue.Instance.CargoDeny.CityList;
            if (!string.IsNullOrEmpty(WedSoulHue.Instance.TrimIraq.regionName) && HeiCityList != null && HeiCityList.Length > 0)
            {
                for (int i = 0; i < HeiCityList.Length; i++)
                {
                    if (HeiCityList[i] == WedSoulHue.Instance.TrimIraq.regionName
                    || HeiCityList[i] == WedSoulHue.Instance.TrimIraq.city)
                    {
                        Cell_AP = "A";
                        if (string.IsNullOrEmpty(Induct))
                            Induct = "City";
                        break;
                    }
                }
            }
            FaceMaw += "3:" + Cell_AP;
            //判断黑名单
            string[] HeiIPs = WedSoulHue.Instance.CargoDeny.IPList;
            if (HeiIPs != null && HeiIPs.Length > 0 && !string.IsNullOrEmpty(WedSoulHue.Instance.TrimIraq.query))
            {
                string[] IpNums = WedSoulHue.Instance.TrimIraq.query.Split('.');
                for (int i = 0; i < HeiIPs.Length; i++)
                {
                    string[] HeiIpNums = HeiIPs[i].Split('.');
                    bool isMatch = true;
                    for (int j = 0; j < HeiIpNums.Length; j++) //黑名单IP格式可能是任意位数 根据位数逐个比对
                    {
                        if (HeiIpNums[j] != IpNums[j])
                            isMatch = false;
                    }
                    if (isMatch)
                    {
                        Cell_AP = "A";
                        if (string.IsNullOrEmpty(Induct))
                            Induct = "IP";
                        break;
                    }
                }
            }
            FaceMaw += "4:" + Cell_AP;
        }
        //判断自然量
        if (!string.IsNullOrEmpty(WedSoulHue.Instance.CargoDeny.fall_down))
        {
            // if (WedSoulHue.Instance.BlockRule.fall_down == "bottom") //仅判断Organic
            // {
            //     if (Adjust_TrackerName == "Organic") //打开自然量 且 归因渠道是Organic 审模式
            //     {
            //         Save_AP = "A";
            //         if (string.IsNullOrEmpty(Reason))
            //             Reason = "FallDown";
            //     }
            // }
            // else if (WedSoulHue.Instance.BlockRule.fall_down == "down") //判断Organic + NoUserConsent
            // {
            //     if (Adjust_TrackerName == "Organic" || Adjust_TrackerName == "No User Consent") //打开自然量 且 归因渠道是Organic或NoUserConsent 审模式
            //     {
            //         Save_AP = "A";
            //         if (string.IsNullOrEmpty(Reason))
            //             Reason = "FallDown";
            //     }
            // }
        }
        FaceMaw += "5:" + Cell_AP;

        PlayerPrefs.SetString("Save_AP", Cell_AP);
        PlayerPrefs.SetString("OtherChance", OtherChance);

        //打点
        if (!string.IsNullOrEmpty(CellIraqGrecian.GetString(CWinter.Or_RoundInformAt)))
            VastNewly();
    }
    static float AshCarnival(float lat1, float lon1, float lat2, float lon2) //判断玩家是否在区域内
    {
        const float R = 6371f; // 地球半径，单位：公里
        float latDistance = Mathf.Deg2Rad * (lat2 - lat1);
        float lonDistance = Mathf.Deg2Rad * (lon2 - lon1);
        float a = Mathf.Sin(latDistance / 2) * Mathf.Sin(latDistance / 2)
               + Mathf.Cos(Mathf.Deg2Rad * lat1) * Mathf.Cos(Mathf.Deg2Rad * lat2)
               * Mathf.Sin(lonDistance / 2) * Mathf.Sin(lonDistance / 2);
        float c = 2 * Mathf.Atan2(Mathf.Sqrt(a), Mathf.Sqrt(1 - a));
        return R * c * 1000; // 距离，单位：米
    }

    public static void VastNewly() //打点 3000是否进审及经纬度和ip等信息  3001是否进审及理由
    {
        //打点
        if (WedSoulHue.Instance.TrimIraq != null)
        {
            string Info1 = "[" + (Cell_AP == "A" ? "审" : "正常") + "] [" + Induct + "]";
            string Info2 = "[" + WedSoulHue.Instance.TrimIraq.lat + "," + WedSoulHue.Instance.TrimIraq.lon + "] [" + WedSoulHue.Instance.TrimIraq.regionName + "] [" + Virginian + "]";
            string Info3 = "[" + WedSoulHue.Instance.TrimIraq.query + "] [Null]";  // [" + Adjust_TrackerName + "]";
            SashNewlyBroker.AshForecast().VastNewly("3000", Info1, Info2, Info3);
        }
        else
            SashNewlyBroker.AshForecast().VastNewly("3000", "No UserData");
        SashNewlyBroker.AshForecast().VastNewly("3001", (Cell_AP == "A" ? "审" : "正常"), FaceMaw, WedSoulHue.Instance.IraqArea);
        PlayerPrefs.SetInt("SendedEvent", 1);
    }

    // 安卓平台特殊屏蔽规则 被屏蔽玩家显示提示 阻止进入 3002打点记录屏蔽原因
    public static bool BizarreCargoTrait()
    {
        //测试
        // UIGrecian.GetInstance().ShowUIForms(nameof(CargoCigar)).GetComponent<CargoCigar>().EvenSoul("测试");
        // return true;


        if (Application.platform == RuntimePlatform.Android && WedSoulHue.Instance.CargoDeny != null)
        {
            AndroidJavaClass aj = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject p = aj.GetStatic<AndroidJavaObject>("currentActivity");
            string Induct= "";
            string Soul= "";

            if (WedSoulHue.Instance.CargoDeny.BlockVPN)
            {
                bool isVpnConnected = p.CallStatic<bool>("isVpn");
                if (isVpnConnected)
                {
                    Induct += "VPN ";
                    Soul = "Please turn off your VPN, restart the game and try again.";
                }
            }
            if (WedSoulHue.Instance.CargoDeny.BlockSimulator)
            {
                bool isSimulator = p.CallStatic<bool>("isSimulator");
                if (isSimulator)
                {
                    Induct += "模拟器 ";
                    Soul = "This game cannot be run on emulators.";
                }
            }
            if (WedSoulHue.Instance.CargoDeny.BlockRoot)
            {
                bool isRoot = p.CallStatic<bool>("isRoot");
                if (isRoot)
                {
                    Induct += "Root ";
                    Soul = "This game cannot be played on rooted devices.";
                }
            }
            if (WedSoulHue.Instance.CargoDeny.BlockDeveloper)
            {
                bool isDeveloper = p.CallStatic<bool>("isDeveloper");
                if (isDeveloper)
                {
                    Induct += "开发者 ";
                    Soul = "Please switch off Developer Option, restart the game and try again.";
                }
            }
            if (WedSoulHue.Instance.CargoDeny.BlockUsb)
            {
                bool isUsb = p.CallStatic<bool>("isUsb");
                if (isUsb)
                {
                    Induct += "USB ";
                    Soul = "Please switch off USB debugging, restart the game and try again.";
                }
            }
            if (WedSoulHue.Instance.CargoDeny.BlockSimCard)
            {
                bool isSimCard = p.CallStatic<bool>("isSimcard");
                if (!isSimCard)
                {
                    Induct += "Sim卡 ";
                    Soul = "Please check if the SIM card is inserted, then restart the game and try again.";
                }
            }
            if (!string.IsNullOrEmpty(Soul))
            {
                UIGrecian.AshForecast().EvenUIDaddy(nameof(CargoCigar)).GetComponent<CargoCigar>().EvenSoul(Soul);
                SashNewlyBroker.AshForecast().VastNewly("3002", Induct);
                return true;
            }
        }
        return false;
    }

    public static bool OnVacant()
    {
#if UNITY_EDITOR
        return true;
#else
        return false;
#endif
    }

    /// <summary>
    /// 是否为竖屏
    /// </summary>
    /// <returns></returns>
    public static bool OnGoldfish()
    {
        return Screen.height > Screen.width;
    }

    /// <summary>
    /// UI的本地坐标转为屏幕坐标
    /// </summary>
    /// <param name="tf"></param>
    /// <returns></returns>
    public static Vector2 RoundScene2SprawlScene(RectTransform tf)
    {
        if (tf == null)
        {
            return Vector2.zero;
        }

        Vector2 fromPivotDerivedOffset = new Vector2(tf.rect.width * 0.5f + tf.rect.xMin, tf.rect.height * 0.5f + tf.rect.yMin);
        Vector2 screenP = RectTransformUtility.WorldToScreenPoint(null, tf.position);
        screenP += fromPivotDerivedOffset;
        return screenP;
    }


    /// <summary>
    /// UI的屏幕坐标，转为本地坐标
    /// </summary>
    /// <param name="tf"></param>
    /// <param name="startPos"></param>
    /// <returns></returns>
    public static Vector2 SprawlScene2RoundScene(RectTransform tf, Vector2 startPos)
    {
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(tf, startPos, null, out localPoint);
        Vector2 pivotDerivedOffset = new Vector2(tf.rect.width * 0.5f + tf.rect.xMin, tf.rect.height * 0.5f + tf.rect.yMin);
        return tf.anchoredPosition + localPoint - pivotDerivedOffset;
    }

    public static Vector2 AshFocusNarrowlyOfFernFolkloric(RectTransform rectTransform)
    {
        // 从RectTransform开始，逐级向上遍历父级
        Vector2 worldPosition = rectTransform.anchoredPosition;
        for (RectTransform rt = rectTransform; rt != null; rt = rt.parent as RectTransform)
        {
            worldPosition += new Vector2(rt.localPosition.x, rt.localPosition.y);
            worldPosition += rt.pivot * rt.sizeDelta;

            // 考虑到UI元素的缩放
            worldPosition *= rt.localScale;

            // 如果父级不是Canvas，则停止遍历
            if (rt.parent != null && rt.parent.GetComponent<Canvas>() == null)
                break;
        }

        // 将结果从本地坐标系转换为世界坐标系
        return rectTransform.root.TransformPoint(worldPosition);
    }
}
