using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using LitJson;
using UnityEngine;
using UnityEngine.Events;

#if JT

public class JT_Manager : ObeySubstrate<JT_Manager>
{
    [Header("登录平台")]
    public LoginPlatform _LoginPlatform = LoginPlatform.Android;
    [Header("真提现后台的产品id")]
    public string AppInfo = "4";
    string WithdrawPlatform = "PAYPAL";
    [Header("真提现后台地址 （http不带s + 域名）")]
    public string BaseUrl = "https://us.nicedramatv.com";
    [HideInInspector] public CashOutResponseData Data;

    [HideInInspector] public FunctionState State = FunctionState.Both;
    [HideInInspector] public int CurrentPlatformIndex = 0; //当前平台索引
    [HideInInspector] public JT_CashOutPanel _CashOutPanel;
    [HideInInspector] public float JT_Money1;
    [HideInInspector] public float JT_Money2;
    int CardBornGap = 10; // 卡片生成间隔
    [HideInInspector] public int CardBornTimer = 0; // 卡片生成定时器
    [HideInInspector] public List<JT_CardItemData> Cash_ItemDataList = new List<JT_CardItemData>(); //抢钱 所有卡片数据
    [HideInInspector] public List<JT_CardItemData> Exchange_ItemDataList = new List<JT_CardItemData>(); // 所有档位数据
    [HideInInspector] public List<JT_OrderItemData> Order_ItemDataList = new List<JT_OrderItemData>(); // 所有订单数据

    List<JT_CashOut_TaskData> TaskList = new List<JT_CashOut_TaskData>(); //任务列表
    List<List<int>> TaskGroupIndexsList = new List<List<int>>(); //任务组索引列表
    int TaskGroupIndex = 0; //任务组索引

    [HideInInspector] public float Rate = 1; //汇率
    bool IsCountOfflineTime;
    [HideInInspector] public long StartTime;
    string ClientIP;
    string RealIP;


    void Update()
    {
        //测试
        // if (Input.GetKeyDown(KeyCode.Q))
        // {
        //     AddMoney(Random.Range(10, 100), "JT_Money1");
        //     AddMoney(Random.Range(500, 1000), "JT_Money2");
        // }
        // if (Input.GetKey(KeyCode.R))
        // {
        //     if (Input.GetKeyDown(KeyCode.A))
        //         ADGrecian.Forecast.AmidUnlessRebel((ok) => { print("模拟看广告"); }, "0");
        // }
    }

    public void Init()
    {
        //根据i2插件获取当前语言
        string CurrentLanguage = I2.Loc.LocalizationManager.CurrentLanguage;
        // 获取所有语言
        // List<string> AllLanguages = I2.Loc.LocalizationManager.GetAllLanguages();
        // foreach (string lang in AllLanguages)
        //     print($"语言:{lang}");
        // 根据当前语言获取汇率
        for (int i = 0; i < WedSoulHue.Instance.JT_CashOut_Data.LanguagesList.Count; i++)
        {
            //print($"语言:{WedSoulHue.Instance.JT_CashOut_Data.LanguagesList[i].Languages} 汇率:{WedSoulHue.Instance.JT_CashOut_Data.LanguagesList[i].Rate}");
            if (WedSoulHue.Instance.JT_CashOut_Data.LanguagesList[i].Languages == CurrentLanguage)
            {
                Rate = (float)WedSoulHue.Instance.JT_CashOut_Data.LanguagesList[i].Rate;
                break;
            }
        }
        print($"当前语言:{CurrentLanguage} 汇率:{Rate}");

        // 线上配置
        State = (FunctionState)WedSoulHue.Instance.JT_CashOut_Data.FunctionState;
        CardBornGap = WedSoulHue.Instance.JT_CashOut_Data.CardBornGap;
        Exchange_ItemDataList = WedSoulHue.Instance.JT_CashOut_Data.Exchange_ItemDataList;
        TaskList = WedSoulHue.Instance.JT_CashOut_Data.TaskList;
        TaskGroupIndexsList = WedSoulHue.Instance.JT_CashOut_Data.TaskGroupIndexsList;

        // 读本地数据
        // 当前平台索引
        CurrentPlatformIndex = PlayerPrefs.GetInt("CurrentPlatformIndex", 0);
        // 抢钱 所有卡数据
        string Cash_ItemDataJson = PlayerPrefs.GetString("Cash_ItemDataList", "");
        if (!string.IsNullOrEmpty(Cash_ItemDataJson))
            Cash_ItemDataList = JsonMapper.ToObject<List<JT_CardItemData>>(Cash_ItemDataJson);
        //档位
        string Exchange_ItemDataJson = PlayerPrefs.GetString("Exchange_ItemDataList", "");
        if (!string.IsNullOrEmpty(Exchange_ItemDataJson))
            Exchange_ItemDataList = JsonMapper.ToObject<List<JT_CardItemData>>(Exchange_ItemDataJson);

        // 订单
        string Order_ItemDataJson = PlayerPrefs.GetString("Order_ItemDataList", "");
        if (!string.IsNullOrEmpty(Order_ItemDataJson))
            Order_ItemDataList = JsonMapper.ToObject<List<JT_OrderItemData>>(Order_ItemDataJson);
        // 钱
        JT_Money1 = PlayerPrefs.GetFloat("JT_Money1", 0);
        JT_Money2 = PlayerPrefs.GetFloat("JT_Money2", 0);
        // 任务组索引
        TaskGroupIndex = PlayerPrefs.GetInt("TaskGroupIndex", 0);

        StartCoroutine(RepeatingIE_RealTime(1, CountTime));
        IsCountOfflineTime = true;
    }

    void SaveData() // 保存数据
    {
        if (Cash_ItemDataList.Count > 0)
        {
            string Cash_ItemDataJson = JsonMapper.ToJson(Cash_ItemDataList);
            PlayerPrefs.SetString("Cash_ItemDataList", Cash_ItemDataJson);
        }
        if (Exchange_ItemDataList.Count > 0)
        {
            string Exchange_ItemDataJson = JsonMapper.ToJson(Exchange_ItemDataList);
            PlayerPrefs.SetString("Exchange_ItemDataList", Exchange_ItemDataJson);
        }
        if (Order_ItemDataList.Count > 0)
        {
            string Order_ItemDataJson = JsonMapper.ToJson(Order_ItemDataList);
            PlayerPrefs.SetString("Order_ItemDataList", Order_ItemDataJson);
        }
    }

    IEnumerator RepeatingIE_RealTime(float RepeatTime, UnityAction OnRepeat) //重复调用 不受时间缩放影响
    {
        WaitForSecondsRealtime WaitTime = new WaitForSecondsRealtime(RepeatTime);
        while (true)
        {
            yield return WaitTime;
            OnRepeat?.Invoke();
        }
    }
    void CountTime()
    {
        //游戏开始 计算一次离线时间
        int OfflineTime = 0;
        if (IsCountOfflineTime)
        {
            OfflineTime = GetOfflineTime();
            //OfflineTime = 99999999;
            IsCountOfflineTime = false;
            print($"离线时间:{OfflineTime}");
        }

        // 抢钱卡片生成计时
        if (State == FunctionState.Cash || State == FunctionState.Both)
        {
            CardBornTimer = PlayerPrefs.GetInt("CardBornTimer", CardBornGap);
            CardBornTimer--;
            CardBornTimer -= OfflineTime;
            if (CardBornTimer <= 0)
            {
                CardBornTimer = CardBornGap;
                if (JT_Money1 > 0)
                {
                    // 生成新卡
                    JT_CardItemData NewCard = new JT_CardItemData();
                    NewCard.Money = JT_Money1;
                    Cash_ItemDataList.Add(NewCard);
                    // 记录卡片组
                    SaveData();
                    // 刷新UI
                    _CashOutPanel?.CreateCard(NewCard);
                    // 扣除卡片金额
                    AddMoney(-JT_Money1, "JT_Money1");
                }
            }
            PlayerPrefs.SetInt("CardBornTimer", CardBornTimer);
            _CashOutPanel?.UpdateBaseCardUI();
        }


        bool IsCounted = false; // 是否有任务卡片进行了计时
        // 抢钱所有等待任务计时
        if (Cash_ItemDataList.Count > 0)
        {
            for (int i = 0; i < Cash_ItemDataList.Count; i++)
            {
                JT_CardItemData CardItemData = Cash_ItemDataList[i];
                if (CardItemData.CardState == 3 || CardItemData.CardState == 4)
                {
                    CardItemData.TaskValue--;
                    CardItemData.TaskValue -= OfflineTime;
                    if (CardItemData.TaskValue <= 0)
                        AddTastValue("Wait");
                    if (CardItemData.TaskValue > 0)
                        _CashOutPanel?.UpdateOneCardUI_Cash(i);
                    IsCounted = true;
                }
            }
        }
        //档位等待任务计时
        if (Exchange_ItemDataList.Count > 0)
        {
            for (int i = 0; i < Exchange_ItemDataList.Count; i++)
            {
                JT_CardItemData CardItemData = Exchange_ItemDataList[i];
                if (CardItemData.CardState == 3 || CardItemData.CardState == 4)
                {
                    CardItemData.TaskValue--;
                    CardItemData.TaskValue -= OfflineTime;
                    if (CardItemData.TaskValue <= 0)
                        AddTastValue("Wait");
                    if (CardItemData.TaskValue > 0)
                        _CashOutPanel?.UpdateOneCardUI_Exchange(i);
                    IsCounted = true;
                }
            }
        }
        // 如果有卡片进行了计时 则刷新本地数据
        if (IsCounted)
            SaveData();
    }

    public void OpenCardAndSetTask(bool CashOrExchange, JT_CardItemData Card) //开启卡片 设置任务
    {
        if (CashOrExchange)
            AddMoney((float)-Card.Money, "JT_Money1");
        else
            AddMoney((float)-Card.NeedMoney, Card.NeedMoneyType);

        long CurrentTime = (long)(System.DateTime.Now - new System.DateTime(1970, 1, 1, 0, 0, 0, System.DateTimeKind.Local)).TotalSeconds;
        Card.TimeStr = GetTimeStr(CurrentTime);
        Card.TaskGroupIndex = TaskGroupIndex;
        // 刷新任务组索引
        TaskGroupIndex++;
        if (TaskGroupIndex >= TaskGroupIndexsList.Count)
            TaskGroupIndex = 0;
        PlayerPrefs.SetInt("TaskGroupIndex", TaskGroupIndex);

        SaveData();
    }

    public void AddMoney(float Money, string Type)
    {
        if (Type == "JT_Money1")
        {
            JT_Money1 += Money;
            if (JT_Money1 <= 0)
                JT_Money1 = 0;
            JT_Money1 = (float)System.Math.Round(JT_Money1, 2);
            PlayerPrefs.SetFloat("JT_Money1", JT_Money1);
        }
        else if (Type == "JT_Money2")
        {
            JT_Money2 += Money;
            if (JT_Money2 <= 0)
                JT_Money2 = 0;
            JT_Money2 = (float)System.Math.Round(JT_Money2, 2);
            PlayerPrefs.SetFloat("JT_Money2", JT_Money2);
        }
        _CashOutPanel?.UpdateBaseCardUI();
        _CashOutPanel?.UpdateExchangeMoneyUI();
        _CashOutPanel?.UpdateExchangeListUI();

        // 金币减少后调用事件
        if (Money < 0)
            ZJT_Manager.AshForecast().AfterReduceMoney();
    }

    public void AddTastValue(string TaskName, double Value = 1) //增加任务进度
    {
        for (int i = 0; i < Cash_ItemDataList.Count; i++)
        {
            JT_CardItemData CardData = Cash_ItemDataList[i];
            if (CardData.CardState != 0)
            {
                int TaskIndex = TaskGroupIndexsList[CardData.TaskGroupIndex][CardData.CompletedTaskNum];
                JT_CashOut_TaskData TaskData = GetTaskData(TaskIndex);
                if (TaskData != null && TaskData.Name == TaskName)
                {
                    CardData.TaskValue += Value;
                    // 完成任务 判断进行下个任务 或 移入订单 (等待任务是倒计时 倒计时结束触发此方法即完成)
                    if (CardData.TaskValue >= TaskData.Target || TaskName == "Wait")
                    {
                        // 完成任务打点
                        SashNewlyBroker.AshForecast().VastNewly("1403", TaskIndex.ToString(), TaskData.Name, CardData.TaskValue.ToString());

                        CardData.CompletedTaskNum++;
                        // 完成所有任务 移入订单页
                        if (CardData.CompletedTaskNum >= TaskGroupIndexsList[CardData.TaskGroupIndex].Count)
                        {
                            int MoveToOrder1019 = PlayerPrefs.GetInt("MoveToOrder1019", 0);
                            MoveToOrder1019 += 1;
                            PlayerPrefs.SetInt("MoveToOrder1019", MoveToOrder1019);
                            SashNewlyBroker.AshForecast().VastNewly("1019", MoveToOrder1019.ToString());
                            MoveToOrder(CardData);
                        }
                        else // 还有任务 继续做任务
                            CheckNextTask(CardData);
                    }
                }
            }
        }
        for (int i = 0; i < Exchange_ItemDataList.Count; i++)
        {
            JT_CardItemData ExchangeItemData = Exchange_ItemDataList[i];
            if (ExchangeItemData.CardState != 0)
            {
                int TaskIndex = TaskGroupIndexsList[ExchangeItemData.TaskGroupIndex][ExchangeItemData.CompletedTaskNum];
                JT_CashOut_TaskData TaskData = GetTaskData(TaskIndex);
                if (TaskData != null && TaskData.Name == TaskName)
                {
                    ExchangeItemData.TaskValue += Value;
                    // 完成任务 判断进行下个任务 或 移入订单 (等待任务是倒计时 倒计时结束触发此方法即完成)
                    if (ExchangeItemData.TaskValue >= TaskData.Target || TaskName == "Wait")
                    {
                        // 完成任务打点
                        SashNewlyBroker.AshForecast().VastNewly("1403", TaskIndex.ToString(), TaskData.Name, ExchangeItemData.TaskValue.ToString());

                        ExchangeItemData.CompletedTaskNum++;
                        // 完成所有任务 移入订单页
                        if (ExchangeItemData.CompletedTaskNum >= TaskGroupIndexsList[ExchangeItemData.TaskGroupIndex].Count)
                        {
                            int MoveToOrder1023 = PlayerPrefs.GetInt("MoveToOrder1023", 0);
                            MoveToOrder1023 += 1;
                            PlayerPrefs.SetInt("MoveToOrder1023", MoveToOrder1023);
                            SashNewlyBroker.AshForecast().VastNewly("1023", MoveToOrder1023.ToString());
                            MoveToOrder(ExchangeItemData);
                        }
                        else // 还有任务 继续做任务
                            CheckNextTask(ExchangeItemData);
                    }
                }
            }
        }
        SaveData();
        _CashOutPanel?.UpdateCardListUI();
        _CashOutPanel?.UpdateExchangeListUI();
        _CashOutPanel?.UpdateOrderListUI();
    }
    public void AddTask_FastWait(JT_CardItemData CardData, int FastWaitTime) //增加任务进度 -快速等待
    {
        if (Cash_ItemDataList.Contains(CardData))
            CardData.TaskValue -= FastWaitTime;
        else if (Exchange_ItemDataList.Contains(CardData))
            CardData.TaskValue -= FastWaitTime;

    }
    public JT_CardItemData CheckNextTask(JT_CardItemData CardData)
    {
        // 没任务组  视为已完成 直接移入订单页
        List<int> TaskGroupIndexsList = GetTaskGroupIndexs(CardData.TaskGroupIndex);
        if (TaskGroupIndexsList == null || TaskGroupIndexsList.Count <= 0)
            MoveToOrder(CardData);
        // 有任务组 
        else
        {
            JT_CashOut_TaskData TaskData = GetTaskData(TaskGroupIndexsList[CardData.CompletedTaskNum]);
            // 任务组里没任务  视为已完成 直接移入订单页
            if (TaskData == null)
                MoveToOrder(CardData);
            // 任务组里有任务 开始做任务
            else
            {
                // 遇到编号99的任务 移入订单页去排队
                if (TaskData.Index == 99)
                    MoveToOrder(CardData, true);
                // 其他任务 刷新UI 显示任务信息
                else
                {
                    // 等时间任务
                    if (TaskData.Name == "Wait")
                    {
                        if (TaskData.FastWaitTime > 0)
                            CardData.CardState = 4;
                        else
                            CardData.CardState = 3;
                        CardData.TaskValue = TaskData.Target;
                    }
                    // 带跳转按钮的任务
                    else if (TaskData.IsJump)
                    {
                        CardData.CardState = 1;
                        CardData.TaskValue = 0;
                    }
                    // 不带跳转按钮的任务
                    else
                    {
                        CardData.CardState = 2;
                        CardData.TaskValue = 0;
                    }
                }
            }
        }
        return CardData;
    }

    void MoveToOrder(JT_CardItemData CardData, bool IsQueue = false) // 
    {
        // 任务完成后 加入订单列表
        JT_OrderItemData OrderItemData = new JT_OrderItemData();
        OrderItemData.Money = CardData.Money;
        long CurrentTime = (long)(System.DateTime.Now - new System.DateTime(1970, 1, 1, 0, 0, 0, System.DateTimeKind.Local)).TotalSeconds;
        OrderItemData.Time = CurrentTime;
        OrderItemData.PlatformIndex = CurrentPlatformIndex;
        if (IsQueue) //如果是排队任务 随机一个队列号
            OrderItemData.Queue = UnityEngine.Random.Range(8000, 10000);
        Order_ItemDataList.Add(OrderItemData);

        //抢钱从卡片列表移除
        if (Cash_ItemDataList.Contains(CardData))
            Cash_ItemDataList.Remove(CardData);
        // 档位卡 数据恢复初始状态
        if (Exchange_ItemDataList.Contains(CardData))
        {
            CardData.CardState = 0;
            CardData.TimeStr = "";
            CardData.TaskValue = 0;
            CardData.CompletedTaskNum = 0;
        }
    }

    public List<int> GetTaskGroupIndexs(int TaskGroupIndex) //根据任务组索引获取任务索引列表
    {
        if (TaskGroupIndex >= TaskGroupIndexsList.Count)
            return null;
        return TaskGroupIndexsList[TaskGroupIndex];
    }

    public JT_CashOut_TaskData GetTaskData(int TaskIndex) //根据索引获取任务数据
    {
        foreach (JT_CashOut_TaskData Task in TaskList)
        {
            if (Task.Index == TaskIndex)
                return Task;
        }
        return null;
    }

    public void JumpBtnClick() //跳转按钮 关闭提现面板 跳转到游戏某个位置
    {
        _CashOutPanel.Close();
        ZJT_Manager.AshForecast().JumpBtnClick();
    }

    public void UpdateCash_ItemDataList(JT_CardItemData CardData, bool RemoveCard = false) //数据发生变动时 更新卡片数据
    {
        //删除卡片
        if (RemoveCard)
            Cash_ItemDataList.Remove(CardData);
        //更新卡片数据
        else
        {
            for (int i = 0; i < Cash_ItemDataList.Count; i++)
            {
                if (Cash_ItemDataList[i].TimeStr == CardData.TimeStr) //根据卡片生成时间查找对应唯一卡片
                {
                    Cash_ItemDataList[i] = CardData;
                    break;
                }
            }
        }
        // 记录卡片组
        SaveData();
    }

    public string GetTimeStr(long time, bool WithYear = false) //时间转特定格式
    {
        //long CurrentTime = (long)(System.DateTime.Now - new System.DateTime(1970, 1, 1, 0, 0, 0, System.DateTimeKind.Local)).TotalSeconds;
        if (WithYear) //格式 yyyy-MM-dd HH:mm:ss
        {
            System.DateTime dateTime = new System.DateTime(1970, 1, 1, 0, 0, 0, System.DateTimeKind.Local).AddSeconds(time);
            return dateTime.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss");
        }
        else //格式 hh:mm:ss
        {
            System.TimeSpan timeSpan = System.TimeSpan.FromSeconds(time);
            return timeSpan.ToString(@"hh\:mm\:ss");
        }
    }
    public string GetFormattedDurationStr(long totalSeconds)
    {
        System.TimeSpan duration = System.TimeSpan.FromSeconds(totalSeconds);
        if (duration.TotalHours > 1)
        {
            return duration.ToString(@"hh\:mm\:ss");
        }
        else
        {
            return duration.ToString(@"mm\:ss");
        }
    }



    public string Translate(string key) //翻译
    {
        string Str = I2.Loc.LocalizationManager.GetTranslation(key);
        if (string.IsNullOrEmpty(Str))
            return key;
        return I2.Loc.LocalizationManager.GetTranslation(key);
    }

    //获取离线时间（以秒为单位）
    int GetOfflineTime()
    {
        if (PlayerPrefs.HasKey("JT_LastOnline"))
        {
            long lastOnline = long.Parse(PlayerPrefs.GetString("JT_LastOnline"));
            return (int)(GetUnixTimeStamp() - lastOnline);
        }
        else
            return 0;
    }
    //获取Unix时间戳（以秒为单位）
    public long GetUnixTimeStamp()
    {
        return System.DateTimeOffset.Now.ToUnixTimeSeconds();
    }
    //更新最后在线时间
    private void UpdateLastOnlineTime()
    {
        PlayerPrefs.SetString("JT_LastOnline", GetUnixTimeStamp().ToString());
    }
    void OnApplicationQuit()
    {
        UpdateLastOnlineTime();
    }
    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            IsCountOfflineTime = true;
            UpdateLastOnlineTime();
        }

        if (pause)
            ReportEvent(1005);
        else
            ReportEvent(1006);
    }


    #region 短剧后台各类接口
    Dictionary<string, string> Headers() // 请求头
    {
#if UNITY_EDITOR //编译器不传设备信息
        return new Dictionary<string, string>
        {
            {"app-version", Application.version},
            {"lang", I2.Loc.LocalizationManager.CurrentLanguageCode},
            {"Authorization", CellIraqGrecian.GetString("CashOut_Token")},
            {"platform", WithdrawPlatform},
            {"os-version", ""},
            {"device-name", ""},
        };
#endif

        return new Dictionary<string, string>
        {
            {"app-version", Application.version},
            {"lang", I2.Loc.LocalizationManager.CurrentLanguageCode},
            {"Authorization", CellIraqGrecian.GetString("CashOut_Token")},
            {"platform", WithdrawPlatform},
            {"os-version", GetOperatingSystem()},
            {"device-name", SystemInfo.deviceName},
        };
    }
    string GetOperatingSystem() // 获取操作系统版本
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            try
            {
                using (AndroidJavaClass versionClass = new AndroidJavaClass("android.os.Build$VERSION"))
                {
                    string release = versionClass.GetStatic<string>("RELEASE");  // 获取系统版本号，如 "14"
                    int sdkInt = versionClass.GetStatic<int>("SDK_INT"); // 获取 SDK 等级，如 34
                    return release + "_" + sdkInt;
                }
            }
            catch (System.Exception e)
            {
                Debug.LogError("获取 Android 系统版本失败：" + e.Message);
                return "unknown";
            }
        }
        else if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            try
            {
                string osString = SystemInfo.operatingSystem; // 示例："iPhone OS 17.5.1"
                System.Text.RegularExpressions.Match match = System.Text.RegularExpressions.Regex.Match(osString, @"\d+(\.\d+)*"); // 用正则表达式提取版本号中的纯数字部分（例如 17.5.1）
                if (match.Success)
                    return match.Value;
                else
                    return "unknown";
            }
            catch (System.Exception e)
            {
                Debug.LogError("获取 iOS 系统版本失败：" + e.Message);
                return "unknown";
            }
        }
        return "unknown";
    }

    public void Login() // 登录
    {
        string Platform = "Editor";
        string Manufacturer = "Editor";
        string DeviceAdId = "";
        if (_LoginPlatform == LoginPlatform.Android)
        {
            Platform = "Android";
            DeviceAdId = CellIraqGrecian.GetString("gaid");
            if (Application.platform == RuntimePlatform.Android)
            {
                AndroidJavaClass aj = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
                AndroidJavaObject p = aj.GetStatic<AndroidJavaObject>("currentActivity");
                Manufacturer = p.CallStatic<string>("getManufacturer");
            }
        }
        else
        {
            Platform = "iOS";
            Manufacturer = "Apple";
            DeviceAdId = CellIraqGrecian.GetString("idfv");
        }
        StringBuilder uuidsb = new StringBuilder();
        uuidsb.Append(SystemInfo.deviceUniqueIdentifier);
        //UUID存在不同应用相同ID的情况 用SystemInfo.deviceUniqueIdentifier + AppInfo 
        bool isNewPlayer = !PlayerPrefs.HasKey(CWinter.Or_OnOatViewer + "Bool") || CellIraqGrecian.GetBool(CWinter.Or_OnOatViewer);
        bool hasuuidAndAppid = CellIraqGrecian.GetBool("UuidAndAPPid");
        if (isNewPlayer || hasuuidAndAppid) //新老用户兼容
            uuidsb.Append(AppInfo);
        var loginRequest = new Request_Login
        {
            platform = Platform,
            bundle_id = Application.identifier,
            uuid = uuidsb.ToString(),
            device_ad_id = DeviceAdId,
            device_lang = System.Globalization.CultureInfo.CurrentCulture.Name,
            model = SystemInfo.deviceModel,
            manufacturer = Manufacturer,
            screen_size = Mathf.RoundToInt(Screen.width) + "*" + Mathf.RoundToInt(Screen.height),
            screen_pixel = Mathf.RoundToInt(Screen.currentResolution.width) + "*" + Mathf.RoundToInt(Screen.currentResolution.height),
        };

        string jsonBody = JsonMapper.ToJson(loginRequest);
        string loginUrl = $"{BaseUrl}/login";
        CashOutLog($"请求登录  请求体: {jsonBody}", false);

        WedLackGrecian.AshForecast().BeadSashMute(
            url: loginUrl,
            jsonData: jsonBody,
            success: (result) =>
            {
                try
                {
                    var response = JsonMapper.ToObject<Response_User>(result.downloadHandler.text);
                    if (response.code == 0)
                    {
                        CashOutLog("登录成功 数据： " + result.downloadHandler.text, false, true);
                        //UUID 新老用户兼容
                        bool isNewPlayer = !PlayerPrefs.HasKey(CWinter.Or_OnOatViewer + "Bool") || CellIraqGrecian.GetBool(CWinter.Or_OnOatViewer);
                        if (isNewPlayer)
                            CellIraqGrecian.SetBool("UuidAndAPPid", true);
                        //刷新token 
                        CellIraqGrecian.SetString("CashOut_Token", response.data.token);
                        Data = new CashOutResponseData();
                        Data.UserID = response.data.id.ToString();

                        //上报ip
                        GetClientIP();
                        GetRealIP_Step1();

                        //游戏启动打点 需要先登录成功才能打点 这里的时间戳参数由ReportEvent方法内部特殊处理
                        ReportEvent(1000);

                        //上报设备信息
                        ReportEvent_DeviceInfo();
                    }
                    else
                    {
                        CashOutLog($"登录失败: {response.msg}", true);
                        CashOutLog("1. 如果报错是 app not found，检查包名和真提现后台ID是否填对，如果都对 联系乔梁删后台错误数据", true);
                        CashOutLog("2. 如果报错是 user block，是被真提现后台反作弊策略命中了， 联系乔梁删把你加白名单", true);
                        CashOutLog("3. 如果报错是 app version not found，是真提现后台没创建对应版本， 检查版本是否填对 或联系乔梁创建对应版本后台", true);
                        CashOutLog("4. 如果报错是 server not xxx，一般在虚拟机出现，是真提现不在这个地区提供服务， 换个网或者vpn", true);
                    }
                }
                catch (System.Exception e)
                {
                    CashOutLog($"解析登录响应数据失败: {e.Message}", true);
                }
            },
            fail: () =>
            {
                CashOutLog("登录请求失败", true);
            },
            timeout: 3f,
            headers: Headers()
        );
    }

    public void ReportAdjustID() // 上报adjust_id
    {
        string url = $"{BaseUrl}/user/ad";
        RequestData_ReportAdjustID requestData = new RequestData_ReportAdjustID();
        requestData.id = SandalWineGrecian.Instance.AshSandalSpew();
        string jsonBody = JsonMapper.ToJson(requestData);
        CashOutLog($"上报adjust_idURL: {url}  请求体: {jsonBody}", false);
        WedLackGrecian.AshForecast().BeadSashMute(
            url: url,
            jsonData: jsonBody,
            success: (result) =>
            {
                CashOutLog("上报adjust_id数据： " + result.downloadHandler.text, false);
                try
                {
                    var response = JsonMapper.ToObject<BaseResponse>(result.downloadHandler.text);
                    if (response.code == 0) // 成功状态码
                    {
                        CashOutLog("上报adjust_id成功", false);
                    }
                    else
                    {
                        CashOutLog($"上报adjust_id失败: {response.msg}", true);
                    }
                }
                catch (System.Exception e)
                {
                    CashOutLog($"解析上报adjust_id响应数据失败: {e.Message}", true);
                }
            },
            fail: () =>
            {
                CashOutLog("上报adjust_id请求失败", true);
            },
            timeout: 3f,
            headers: Headers()
        );
    }

    public string EcpmRequestID() // 获取上报ecpm的request_id 广告加载时生成
    {
        string uuid = System.Guid.NewGuid().ToString();
        string formattedUuid = uuid.ToLowerInvariant().Replace("-", "");
        return formattedUuid;
    }

    void GetClientIP() // 获取客户端IP
    {
        string url = "http://ip-api.com/json/?key=NN3ExblXQt2Esoy";
        WedLackGrecian.AshForecast().HttpAsh(
            url: url,
            success: (result) =>
            {
                //CashOutLog("获取客户端IP数据： " + result.downloadHandler.text, false);
                try
                {
                    string json = result.downloadHandler.text;
                    JsonData data = JsonMapper.ToObject(json);
                    if (data.ContainsKey("query"))
                    {
                        ClientIP = data["query"].ToString();
                        ReportIDs();
                    }
                    else
                    {
                        CashOutLog("未找到IP地址", true);
                    }
                }
                catch (Exception e)
                {
                    CashOutLog($"解析获取客户端IP响应数据失败: {e.Message}", true);
                }
            },
            fail: () =>
            {
                CashOutLog("获取客户端IP请求失败", true);
            },
            timeout: 3f,
            headers: null
        );
    }
    void GetRealIP_Step1() // 获取真实IP网址
    {
        string url = "https://nstool.netease.com/";
        WedLackGrecian.AshForecast().HttpAsh(
            url: url,
            success: (result) =>
            {
                //CashOutLog("获取真实IP网址： " + result.downloadHandler.text, false);
                try
                {
                    // 使用正则表达式匹配iframe的src属性
                    var match = System.Text.RegularExpressions.Regex.Match(result.downloadHandler.text, @"<iframe\s+[^>]*src=['""]([^'""]+)['""][^>]*>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                    if (match.Success)
                    {
                        GetRealIP_Step2(match.Groups[1].Value);
                        //RealIP = match.Groups[1].Value;
                    }
                }
                catch (Exception e)
                {
                    CashOutLog($"解析获取真实IP网址响应数据失败: {e.Message}", true);
                }
            },
            fail: () =>
            {
                CashOutLog("获取真实IP网址请求失败", true);
            },
            timeout: 3f,
            headers: null
        );
    }
    void GetRealIP_Step2(string url) // 获取真实IP
    {
        WedLackGrecian.AshForecast().HttpAsh(
           url: url,
           success: (result) =>
           {
               //CashOutLog("获取真实IP数据： " + result.downloadHandler.text, false);
               try
               {
                   string ipPattern = @"(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)";
                   var match = System.Text.RegularExpressions.Regex.Match(result.downloadHandler.text, ipPattern);
                   if (match.Success)
                   {
                       RealIP = match.Groups[0].Value;
                       ReportIDs();
                   }
               }
               catch (Exception e)
               {
                   CashOutLog($"解析获取真实IP响应数据失败: {e.Message}", true);
               }
           },
           fail: () =>
           {
               CashOutLog("获取真实IP请求失败", true);
           },
           timeout: 3f,
           headers: null
       );
    }
    void ReportIDs() // 上报各种ID
    {
        CashOutLog("上报ID  客户端Ip：" + ClientIP + "  真实Ip：" + RealIP);
        string url = $"{BaseUrl}/user/meta";
        WedLackGrecian.AshForecast().BeadSashMute(
            url: url,
            jsonData: GetReportIDsBody(),
            success: (result) =>
            {
                try
                {
                    var response = JsonMapper.ToObject<BaseResponse>(result.downloadHandler.text);
                    if (response.code == 0) // 成功状态码
                    {
                        CashOutLog("上报ID成功 数据： " + result.downloadHandler.text, false, true);
                    }
                    else
                    {
                        CashOutLog($"上报各种ID失败: {response.msg}", true);
                    }
                }
                catch (Exception e)
                {
                    CashOutLog($"解析上报各种ID响应数据失败: {e.Message}", true);
                }
            },
            fail: () =>
            {
                CashOutLog("上报各种ID请求失败", true);
            },
            timeout: 3f,
            headers: Headers()
        );
    }
    string GetReportIDsBody() // 获取上报各种ID的请求体(处理某个ip为空的情况)
    {
        if (string.IsNullOrEmpty(ClientIP))
            return JsonMapper.ToJson(new { REAL_IP = RealIP });
        if (string.IsNullOrEmpty(RealIP))
            return JsonMapper.ToJson(new { CLIENT_IP = ClientIP });
        return JsonMapper.ToJson(new { CLIENT_IP = ClientIP, REAL_IP = RealIP });
    }

    public void ReportEvent(int type, string string_0 = null, string string_1 = null, int? big_int_0 = null) // 上报事件
    {
        if (string.IsNullOrEmpty(CellIraqGrecian.GetString("CashOut_Token")))
        {
            CashOutLog($"没Token不上报事件{type}", true);
            return;
        }

        long EventTimestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds(); //毫秒时间戳
        if (type == 1000)  //游戏启动时间戳 由于要先等登录成功获取token 所以特殊处理
            EventTimestamp = StartTime;
        RequestData_ReportEvent EventRequest = new RequestData_ReportEvent();
        EventRequest.network = GetNetworkInt();
        EventRequest.time_zone = GetTimeZone();
        EventRequest.timestamp = EventTimestamp;
        EventRequest.events = new List<RequestData_ReportEvent_Event>();
        RequestData_ReportEvent_Event Event = new RequestData_ReportEvent_Event();
        Event.type = type;
        Event.timestamp = EventTimestamp;
        Event.string_0 = string_0;
        Event.string_1 = string_1;
        Event.big_int_0 = big_int_0;
        EventRequest.events.Add(Event);

        string url = $"{BaseUrl}/event";
        CashOutLog($"上报事件{type}  请求体: {JsonMapper.ToJson(EventRequest)}", false);
        WedLackGrecian.AshForecast().BeadSashMute(
            url: url,
            jsonData: JsonMapper.ToJson(EventRequest),
            success: (result) =>
            {
                //CashOutLog("上报事件数据： " + result.downloadHandler.text, false);
                try
                {
                    var response = JsonMapper.ToObject<BaseResponse>(result.downloadHandler.text);
                    if (response.code == 0) // 成功状态码
                    {
                        CashOutLog($"上报事件{type}成功", false, true);
                    }
                    else
                    {
                        CashOutLog($"上报事件{type}失败: {response.msg}", true);
                    }
                }
                catch (Exception e)
                {
                    CashOutLog($"解析上报事件响应数据失败: {e.Message}", true);
                }
            },
            fail: () =>
            {
                CashOutLog("上报事件请求失败", true);
            },
            timeout: 3f,
            headers: Headers()
        );
    }
    int GetNetworkInt() //根据网络类型获取对应的int值 
    {
        //安卓调原生方法 获取更详细的网络类型
        if (Application.platform == RuntimePlatform.Android)
        {
            AndroidJavaClass aj = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject p = aj.GetStatic<AndroidJavaObject>("currentActivity");
            return p.CallStatic<int>("getNetwork");
        }

        //苹果端暂时这样处理
        NetworkReachability reachability = Application.internetReachability;
        if (reachability == NetworkReachability.ReachableViaLocalAreaNetwork)
            return 1; // WIFI
        else
            return 0; // 其他网络
    }
    int GetTimeZone() //获取当前时区相对于UTC0时区的差值，单位：秒
    {
        // 获取当前本地时间
        DateTime localTime = DateTime.Now;
        // 获取当前时间对应的UTC时间
        DateTime utcTime = localTime.ToUniversalTime();
        // 计算时间差（本地时间 - UTC时间）
        TimeSpan offset = localTime - utcTime;
        // 将时间差转换为秒
        return (int)offset.TotalSeconds;
    }
    public void ReportEvent_LoadingTime() //上报loading时间
    {
        long LoadingTime = System.DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() - StartTime;
        ReportEvent(1004, null, null, (int)LoadingTime);
    }
    void ReportEvent_DeviceInfo() //上报设备信息
    {
        //目前只有安卓上报
        if (Application.platform == RuntimePlatform.Android)
        {
            AndroidJavaClass aj = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject p = aj.GetStatic<AndroidJavaObject>("currentActivity");
            bool isVpn = p.CallStatic<bool>("isVpn");
            if (isVpn)
                ReportEvent(1007);
            bool isSimulator = p.CallStatic<bool>("isSimulator");
            if (isSimulator)
                ReportEvent(1008);
            bool isRoot = p.CallStatic<bool>("isRoot");
            if (isRoot)
                ReportEvent(1009);
            bool isDeveloper = p.CallStatic<bool>("isDeveloper");
            if (isDeveloper)
                ReportEvent(1010);
            bool isUsb = p.CallStatic<bool>("isUsb");
            if (isUsb)
                ReportEvent(1011);
            bool isSimCard = p.CallStatic<bool>("isSimcard");
            ReportEvent(1012, null, null, isSimCard ? 1 : 0);
        }
    }


    void CashOutLog(string log, bool IsError = false, bool IsOk = false) //提现相关功能日志
    {
        if (IsError)
            Debug.LogError("<color=red><b>+++++   " + log + "</b></color>");
        else
        {
            if (IsOk)
                print("<color=cyan><b>+++++   " + log + "</b></color>");
            else
                print("<color=yellow><b>+++++   " + log + "</b></color>");
        }
    }
    #endregion

}

public enum FunctionState
{
    Cash, //仅开启抢钱功能
    Exchange, //仅开启档位功能
    Both, // 同时开始
}

[System.Serializable]
public class JT_CardItemData //每张卡片数据 （避免存储量太大 任务相关只存索引）
{
    public int CardState = 0; // 卡片状态 0 等待开启 1 任务带跳转 2 任务不跳转 3 任务等待
    public double Money; // 提现金额
    public string TimeStr; // 卡片生成时间(可作为唯一标识)
    public int TaskGroupIndex; //任务组索引
    public int CompletedTaskNum; // 已完成任务数量
    public double TaskValue; //任务值

    public string NeedMoneyType; //开启这个档位卡所需的金额类型
    public double NeedMoney; //开启这个档位卡所需的金额
}
[System.Serializable]
public class JT_OrderItemData
{
    public double Money; // 提现金额
    public long Time; // 订单生成时间
    public int Queue; //排队
    public int PlatformIndex; //平台索引
}


#endif