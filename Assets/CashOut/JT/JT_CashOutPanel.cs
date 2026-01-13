using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Runtime.InteropServices;



public class JT_CashOutPanel : SakeUIDaddy
{
#if JT

    bool IsInit = false; //是否初始化
    public Button CloseBtn; //关闭按钮
    public Button FeedbackBtn; //反馈按钮

    [Header("页面切换")]
    public RectTransform FunctionBtnBg; //功能按钮背景
    public Transform FunctionBtnChoosedBg; //已选择的功能按钮背景
    public Button PageBtn_Cash; //抢钱按钮
    public Text PageBtn_Cash_Text; //抢钱按钮文字
    public Button PageBtn_Exchange; //档位按钮
    public Text PageBtn_Exchange_Text; //档位按钮文字
    public Button PageBtn_Order; // 订单按钮
    public Text PageBtn_Order_Text; //订单按钮文字
    public Transform CashPage; //抢钱页面
    public Transform ExchangePage; //档位页面
    public Transform OrderPage; //订单页面
    public Transform AccountPage; //账号页面
    float PageAnimTime = .3f;

    [Header("账号信息")]
    public Text NoAccountText; //没有账号文字
    public Text AccountText; //账号文字
    public Button ChangeAccountBtn; //切换账号按钮
    public string[] PlatformNames;
    public Sprite[] PlatformIcons; //平台图标
    public ScrollRect PlatformScrollRect;
    public Button PlatformBtnPrefab;
    List<Button> PlatformBtnList = new List<Button>();
    [HideInInspector] public string CurrentAccount = ""; //当前账号

    [Header("输入账号")]
    public Image InputAccountPanel; //输入账号页面
    public Transform InputPage; //输入账号
    public InputField AccountInputField; //账号输入框
    public InputField ReInputField; //二次确认输入框
    public Text AccountErrorText; //账号错误文字
    public Button OpenConfirmPageBtn; //打开确认账号页面按钮
    public Button CloseEnterPageBtn; //关闭输入账号页面按钮

    public Transform ConfirmPage; //确认页面
    public Text ConfirmTipText; //确认文字
    public Text ConfirmAccountText; //确认账号文字
    public Button ConfirmAccountBtn; //确认账号按钮
    public Button OpenInputPageBtn; //打开输入账号页面按钮
    public Button PolicyBtn; // 政策按钮
    public Toggle PolicyToggle; // 政策勾选框
    public Button CloseConfirmPageBtn; //关闭确认页面按钮
#if UNITY_IOS
    [DllImport("__Internal")] // 打开外部链接
    internal extern static void openUrl(string url);
#endif

    [Header("抢钱")]
    public JT_CardItem CardItem; // 卡片预制体
    public Text BaseCard_MoneyText; //基础卡片金额文字
    public Text BaseCard_TimeText_Hour; //基础卡片时间文字-时
    public Text BaseCard_TimeText_Minute; //基础卡片时间文字-分
    public Text BaseCard_TimeText_Second; //基础卡片时间文字-秒
    List<JT_CardItem> CardItemList = new List<JT_CardItem>();

    [Header("档位")]
    public JT_CardItem ExchangeItem; // 档位预制体
    public Sprite MoneyIcon1;
    public Sprite MoneyIcon2;
    public Text ExchangeMoneyText1; // 档位金额文字
    public Text ExchangeMoneyText2; // 档位金额文字
    List<JT_CardItem> ExchangeItemList = new List<JT_CardItem>();

    [Header("订单")]
    public JT_OrderItem OrderItem; // 订单预制体
    public GameObject NoOrderGO;
    List<JT_OrderItem> OrderItemList = new List<JT_OrderItem>();

    [Header("反馈")]
    public GameObject FeedbackPage; //反馈页面
    public Button CloseFeedbackPageBtn; //关闭反馈页面按钮
    public Dropdown FeedbackDropdown; //反馈下拉框
    public InputField FeedbackInputField; //反馈输入框
    public InputField FeedbackEmailInputField; //反馈邮箱输入框
    public Button SubmitFeedbackBtn; //提交反馈按钮


    public override void Display(object OrPureDemise)
    {
        base.Display(OrPureDemise);
        if (ZJT_Manager.AshForecast().DisplayScale != Vector2.zero)
            transform.root.GetComponent<CanvasScaler>().referenceResolution = ZJT_Manager.AshForecast().DisplayScale;

        //打开假提面板打点
        SashNewlyBroker.AshForecast().VastNewly("1401", JT_Manager.AshForecast().JT_Money1.ToString("F2"), JT_Manager.AshForecast().JT_Money2.ToString("F2"));
        string page = "1";
        try
        {
            page =OrPureDemise.ToString();
            if (page == "1")
            {
                OnPageBtn(PageBtn_Cash);
            }
            else if (page == "2")
            {
                OnPageBtn(PageBtn_Exchange);
            }
        }
        catch (System.Exception)
        {

            throw;
        }
    }
    public override void Hidding()
    {
        base.Hidding();
        if (ZJT_Manager.AshForecast().HiddingScale != Vector2.zero)
            transform.root.GetComponent<CanvasScaler>().referenceResolution = ZJT_Manager.AshForecast().HiddingScale;
    }

    private void OnEnable()
    {
        JT_Manager.AshForecast()._CashOutPanel = this;
        if (!IsInit)
        {
            SetPage();
            SetAccountPage();
            CardItem.gameObject.SetActive(false);
            ExchangeItem.gameObject.SetActive(false);
            OrderItem.gameObject.SetActive(false);
            IsInit = true;
        }
        // 抢钱
        UpdateBaseCardUI();  // 更新最顶部 下一张卡牌预计生成金额和时间UI
        UpdateCardListUI(); // 更新所有卡片UI 

        // 档位
        UpdateExchangeMoneyUI();
        UpdateExchangeListUI();  // 更新所有档位UI
        UpdateExchangeListUI_PlatformIcon(); // 更新所有档位平台图标

        // 订单
        UpdateOrderListUI(); // 更新所有订单UI
    }

    void Start()
    {
        CloseBtn.onClick.AddListener(Close);
        FeedbackBtn.onClick.AddListener(OpenFeedbackPage);
        CloseFeedbackPageBtn.onClick.AddListener(CloseFeedbackPage);
        SubmitFeedbackBtn.onClick.AddListener(SubmitFeedback);
    }

    public void Close()
    {
        WispyUIPure(nameof(JT_CashOutPanel));
        RoomCigar.Instance.MyRoomBeach();
    }

    #region 页面切换
    void SetPage() //根据状态设置页面
    {
        switch (JT_Manager.AshForecast().State)
        {
            case FunctionState.Cash:
                FunctionBtnBg.sizeDelta = new Vector2(740, 144);
                PageBtn_Cash.gameObject.SetActive(true);
                PageBtn_Exchange.gameObject.SetActive(false);
                PageBtn_Cash.transform.localPosition = new Vector2(-180, 0);
                PageBtn_Order.transform.localPosition = new Vector2(180, 0);
                FunctionBtnChoosedBg.localPosition = new Vector2(-180, 0);
                CashPage.gameObject.SetActive(true);
                ExchangePage.gameObject.SetActive(false);
                CashPage.localPosition = new Vector2(0, -783);
                OrderPage.localPosition = new Vector2(1080, -480);
                break;
            case FunctionState.Exchange:
                FunctionBtnBg.sizeDelta = new Vector2(740, 144);
                PageBtn_Cash.gameObject.SetActive(false);
                PageBtn_Exchange.gameObject.SetActive(true);
                PageBtn_Exchange.transform.localPosition = new Vector2(-180, 0);
                PageBtn_Order.transform.localPosition = new Vector2(180, 0);
                FunctionBtnChoosedBg.localPosition = new Vector2(-180, 0);
                CashPage.gameObject.SetActive(false);
                ExchangePage.gameObject.SetActive(true);
                ExchangePage.localPosition = new Vector2(0, -783);
                OrderPage.localPosition = new Vector2(1080, -480);
                PageBtn_Exchange_Text.color = new Color32(38, 0, 176, 255);
                break;
            case FunctionState.Both:
                FunctionBtnBg.sizeDelta = new Vector2(1005, 144);
                PageBtn_Cash.gameObject.SetActive(true);
                PageBtn_Exchange.gameObject.SetActive(true);
                PageBtn_Cash.transform.localPosition = new Vector2(-325, 0);
                PageBtn_Exchange.transform.localPosition = new Vector2(0, 0);
                PageBtn_Order.transform.localPosition = new Vector2(325, 0);
                FunctionBtnChoosedBg.localPosition = new Vector2(-325, 0);
                CashPage.gameObject.SetActive(true);
                ExchangePage.gameObject.SetActive(true);
                CashPage.localPosition = new Vector2(0, -783);
                ExchangePage.localPosition = new Vector2(1080, -783);
                OrderPage.localPosition = new Vector2(2160, -480);
                break;
        }
        PageBtn_Cash.onClick.AddListener(() => OnPageBtn(PageBtn_Cash));
        PageBtn_Exchange.onClick.AddListener(() => OnPageBtn(PageBtn_Exchange));
        PageBtn_Order.onClick.AddListener(() => OnPageBtn(PageBtn_Order));
    }
    void OnPageBtn(Button btn)  //切页面 滑动动画
    {
        FunctionBtnChoosedBg.DOLocalMoveX(btn.transform.localPosition.x, PageAnimTime);
        if (btn == PageBtn_Cash && CashPage.localPosition.x != 0)
        {
            CashPage.DOLocalMoveX(0, PageAnimTime);
            if (JT_Manager.AshForecast().State == FunctionState.Cash)
            {
                AccountPage.DOLocalMoveX(0, PageAnimTime);
                OrderPage.DOLocalMoveX(1080, PageAnimTime);
            }
            else if (JT_Manager.AshForecast().State == FunctionState.Both)
            {
                AccountPage.DOLocalMoveX(0, PageAnimTime);
                ExchangePage.DOLocalMoveX(1080, PageAnimTime);
                OrderPage.DOLocalMoveX(2160, PageAnimTime);
            }

            PageBtn_Cash_Text.DOColor(new Color32(38, 0, 176, 255), PageAnimTime);
            PageBtn_Exchange_Text.DOColor(Color.white, PageAnimTime);
            PageBtn_Order_Text.DOColor(Color.white, PageAnimTime);
            PageBtn_Cash_Text.DOFade(1, PageAnimTime);
            PageBtn_Exchange_Text.DOFade(.6f, PageAnimTime);
            PageBtn_Order_Text.DOFade(.6f, PageAnimTime);
        }
        else if (btn == PageBtn_Exchange && ExchangePage.localPosition.x != 0)
        {
            ExchangePage.DOLocalMoveX(0, PageAnimTime);
            if (JT_Manager.AshForecast().State == FunctionState.Exchange)
            {
                AccountPage.DOLocalMoveX(0, PageAnimTime);
                OrderPage.DOLocalMoveX(1080, PageAnimTime);
            }
            else if (JT_Manager.AshForecast().State == FunctionState.Both)
            {
                AccountPage.DOLocalMoveX(0, PageAnimTime);
                CashPage.DOLocalMoveX(-1080, PageAnimTime);
                OrderPage.DOLocalMoveX(1080, PageAnimTime);
            }

            PageBtn_Cash_Text.DOColor(Color.white, PageAnimTime);
            PageBtn_Exchange_Text.DOColor(new Color32(38, 0, 176, 255), PageAnimTime);
            PageBtn_Order_Text.DOColor(Color.white, PageAnimTime);
            PageBtn_Cash_Text.DOFade(.6f, PageAnimTime);
            PageBtn_Exchange_Text.DOFade(1, PageAnimTime);
            PageBtn_Order_Text.DOFade(.6f, PageAnimTime);
        }
        else if (btn == PageBtn_Order && OrderPage.localPosition.x != 0)
        {
            OrderPage.DOLocalMoveX(0, PageAnimTime);
            if (JT_Manager.AshForecast().State == FunctionState.Cash)
            {
                AccountPage.DOLocalMoveX(-1080, PageAnimTime);
                CashPage.DOLocalMoveX(-1080, PageAnimTime);
            }
            else if (JT_Manager.AshForecast().State == FunctionState.Exchange)
            {
                AccountPage.DOLocalMoveX(-1080, PageAnimTime);
                ExchangePage.DOLocalMoveX(-1080, PageAnimTime);
            }
            else if (JT_Manager.AshForecast().State == FunctionState.Both)
            {
                AccountPage.DOLocalMoveX(-1080, PageAnimTime);
                CashPage.DOLocalMoveX(-2160, PageAnimTime);
                ExchangePage.DOLocalMoveX(-1080, PageAnimTime);
            }

            PageBtn_Cash_Text.DOColor(Color.white, PageAnimTime);
            PageBtn_Exchange_Text.DOColor(Color.white, PageAnimTime);
            PageBtn_Order_Text.DOColor(new Color32(38, 0, 176, 255), PageAnimTime);
            PageBtn_Cash_Text.DOFade(.6f, PageAnimTime);
            PageBtn_Exchange_Text.DOFade(.6f, PageAnimTime);
            PageBtn_Order_Text.DOFade(1, PageAnimTime);
        }
    }
    #endregion

    #region 账户
    void SetAccountPage() //设置账号页面
    {
        PlatformBtnPrefab.gameObject.SetActive(false);
        for (int i = 0; i < PlatformNames.Length; i++)
        {
            Button NewBtn = Instantiate(PlatformBtnPrefab, PlatformBtnPrefab.transform.parent);
            NewBtn.transform.Find("Icon").GetComponent<Image>().sprite = PlatformIcons[i];
            NewBtn.gameObject.SetActive(true);
            NewBtn.onClick.AddListener(() => OnPlatformBtn(NewBtn));
            PlatformBtnList.Add(NewBtn);
        }
        CurrentAccount = PlayerPrefs.GetString("Account" + JT_Manager.AshForecast().CurrentPlatformIndex, "");
        if (string.IsNullOrEmpty(CurrentAccount))
            OnPlatformBtn(PlatformBtnList[0]);
        else
            OnPlatformBtn(PlatformBtnList[JT_Manager.AshForecast().CurrentPlatformIndex]);

        //输入账户
        ChangeAccountBtn.onClick.AddListener(OpenEnterAccountPage);
        AccountInputField.onEndEdit.AddListener((Info) => OnInputEnd());
        ReInputField.onEndEdit.AddListener((Info) => OnInputEnd());
        OpenConfirmPageBtn.onClick.AddListener(OpenConfirmAccountPage);
        CloseEnterPageBtn.onClick.AddListener(() => { InputAccountPanel.gameObject.SetActive(false); });

        //确认账户
        OpenInputPageBtn.onClick.AddListener(() =>
        {
            ConfirmPage.gameObject.SetActive(false);
            InputPage.gameObject.SetActive(true);
        });
        ConfirmAccountBtn.onClick.AddListener(OnConfimAccountBtn);
        PolicyBtn.onClick.AddListener(() =>
        {
            string url = WedSoulHue.Instance.SakeThe + "/privacy_policy.html";
#if UNITY_ANDROID || UNITY_EDITOR
            Application.OpenURL(url);
#elif UNITY_IOS
            openUrl(url);
#endif
        });
        CloseConfirmPageBtn.onClick.AddListener(() => { InputAccountPanel.gameObject.SetActive(false); });
    }

    void OnPlatformBtn(Button btn)
    {
        for (int i = 0; i < PlatformBtnList.Count; i++)
            PlatformBtnList[i].transform.Find("已选中").gameObject.SetActive(PlatformBtnList[i] == btn);
        JT_Manager.AshForecast().CurrentPlatformIndex = PlatformBtnList.IndexOf(btn);
        CurrentAccount = PlayerPrefs.GetString("Account" + JT_Manager.AshForecast().CurrentPlatformIndex, "");
        if (string.IsNullOrEmpty(CurrentAccount))
        {
            AccountText.gameObject.SetActive(false);
            NoAccountText.gameObject.SetActive(true);
            string Str = JT_Manager.AshForecast().Translate("Please enter your {0} account.");
            NoAccountText.text = string.Format(Str, PlatformNames[JT_Manager.AshForecast().CurrentPlatformIndex]);
            AccountInputField.transform.Find("输入提示").GetComponent<Text>().text = string.Format(Str, PlatformNames[JT_Manager.AshForecast().CurrentPlatformIndex]);
            string ConfirmStr = JT_Manager.AshForecast().Translate("Please confirm your {0} account.");
            ReInputField.transform.Find("输入提示").GetComponent<Text>().text = string.Format(ConfirmStr, PlatformNames[JT_Manager.AshForecast().CurrentPlatformIndex]);
            ConfirmTipText.text = string.Format(ConfirmStr, PlatformNames[JT_Manager.AshForecast().CurrentPlatformIndex]);
        }
        else
        {
            NoAccountText.gameObject.SetActive(false);
            AccountText.gameObject.SetActive(true);
            AccountText.text = CurrentAccount;
            PlatformScrollRect.normalizedPosition = new Vector2(Mathf.Clamp01((float)JT_Manager.AshForecast().CurrentPlatformIndex / (PlatformBtnList.Count - 1)), 0);
            PlayerPrefs.SetInt("CurrentPlatformIndex", JT_Manager.AshForecast().CurrentPlatformIndex);
        }
    }

    public void OpenEnterAccountPage() //打开输入账号页面
    {
        InputAccountPanel.gameObject.SetActive(true);
        InputAccountPanel.color = new Color32(0, 0, 0, 0);
        InputAccountPanel.DOFade(.4f, PageAnimTime);
        InputPage.gameObject.SetActive(true);
        InputPage.localScale = Vector2.zero;
        InputPage.DOScale(Vector2.one, PageAnimTime * .3f).SetDelay(PageAnimTime);
        ConfirmPage.gameObject.SetActive(false);
        AccountInputField.text = "";
        ReInputField.text = "";
        AccountErrorText.text = "";
    }

    void OnInputEnd() //输入框数据校验
    {
        string Account = AccountInputField.text;
        string ConfirmAccount = ReInputField.text;
        if (string.IsNullOrEmpty(Account))
            AccountErrorText.text = "* Account cannot be empty";
        else if (!System.Text.RegularExpressions.Regex.IsMatch(Account, @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"))
            AccountErrorText.text = "* Account format error";
        else if (!string.IsNullOrEmpty(ConfirmAccount) && Account != ConfirmAccount)
            AccountErrorText.text = "* Accounts don't match";
        else
            AccountErrorText.text = "";

        if (!string.IsNullOrEmpty(AccountErrorText.text))
        {
            AccountErrorText.transform.DOKill();
            AccountErrorText.transform.localPosition = new Vector2(0, AccountErrorText.transform.localPosition.y);
            AccountErrorText.transform.DOLocalMoveX(-30, .1f).SetEase(Ease.InOutBack);
            AccountErrorText.transform.DOLocalMoveX(50, .2f).SetDelay(.1f).SetEase(Ease.InOutBack);
            AccountErrorText.transform.DOLocalMoveX(0, .1f).SetDelay(.3f).SetEase(Ease.InOutBack);
        }
    }

    void OpenConfirmAccountPage() //打开确认账号页面
    {
        string Account = AccountInputField.text;
        string ReAccount = ReInputField.text;
        if (string.IsNullOrEmpty(Account) || string.IsNullOrEmpty(ReAccount))
        {
            ExaltGrecian.AshForecast().EvenExalt("Account cannot be empty");
            return;
        }
        if (!string.IsNullOrEmpty(AccountErrorText.text))
        {
            ExaltGrecian.AshForecast().EvenExalt(AccountErrorText.text);
            return;
        }

        InputPage.gameObject.SetActive(false);
        ConfirmPage.gameObject.SetActive(true);
        ConfirmAccountText.text = AccountInputField.text;
    }

    void OnConfimAccountBtn() //确认账号
    {
        if (!PolicyToggle.isOn)
        {
            ExaltGrecian.AshForecast().EvenExalt("Please agree to the policy");
            return;
        }

        CurrentAccount = AccountInputField.text;
        NoAccountText.gameObject.SetActive(false);
        AccountText.gameObject.SetActive(true);
        AccountText.text = CurrentAccount;
        AccountText.transform.DOKill();
        AccountText.transform.localScale = Vector2.one;
        AccountText.transform.DOScale(Vector2.one * 1.4f, .3f).SetLoops(2, LoopType.Yoyo);
        InputAccountPanel.gameObject.SetActive(false);

        PlayerPrefs.SetInt("CurrentPlatformIndex", JT_Manager.AshForecast().CurrentPlatformIndex);
        PlayerPrefs.SetString("Account" + JT_Manager.AshForecast().CurrentPlatformIndex, CurrentAccount);
    }

    #endregion

    #region 抢钱
    public void UpdateBaseCardUI() //更新最顶部 下一张卡牌预计生成金额和时间UI
    {
        BaseCard_MoneyText.text = "$ " + JT_Manager.AshForecast().JT_Money1.ToString("F1");
        string TimeStr = JT_Manager.AshForecast().GetTimeStr(JT_Manager.AshForecast().CardBornTimer);
        BaseCard_TimeText_Hour.text = TimeStr.Substring(0, 2);
        BaseCard_TimeText_Minute.text = TimeStr.Substring(3, 2);
        BaseCard_TimeText_Second.text = TimeStr.Substring(6, 2);
    }

    public void UpdateCardListUI() //更新所有卡片UI 
    {
        // 如果UI数量大于数据数量 说明有的卡被移入订单界面了 删除多余的卡
        if (CardItemList.Count > JT_Manager.AshForecast().Cash_ItemDataList.Count)
        {
            for (int j = CardItemList.Count - 1; j >= JT_Manager.AshForecast().Cash_ItemDataList.Count; j--)
            {
                Destroy(CardItemList[j].gameObject);
                CardItemList.RemoveAt(j);
            }
        }
        // 更新所有卡片UI
        for (int i = 0; i < JT_Manager.AshForecast().Cash_ItemDataList.Count; i++)
        {
            JT_CardItemData CardData = JT_Manager.AshForecast().Cash_ItemDataList[i];
            if (i < CardItemList.Count) // 已有的卡片 更新UI
                CardItemList[i].UpdateUI(CardData);
            else // 新增卡片
                CreateCard(CardData);
        }
    }
    public void UpdateOneCardUI_Cash(int Index) //单独更新指定卡片UI（等待任务计时使用）
    {
        JT_CardItemData CardData = JT_Manager.AshForecast().Cash_ItemDataList[Index];
        CardItemList[Index].UpdateUI(CardData);
    }

    public void CreateCard(JT_CardItemData CardData) //创建新卡片
    {
        JT_CardItem NewCard = Instantiate(CardItem, CardItem.transform.parent);
        NewCard.UpdateUI(CardData);
        NewCard.gameObject.SetActive(true);
        CardItemList.Add(NewCard);
    }

    #endregion

    #region  档位
    public void UpdateExchangeMoneyUI()
    {
        ExchangeMoneyText1.text = JT_Manager.AshForecast().JT_Money1.ToString("F1");
        ExchangeMoneyText2.text = JT_Manager.AshForecast().JT_Money2.ToString("F0");
    }

    public void UpdateExchangeListUI() //更新所有档位UI
    {
        for (int i = 0; i < JT_Manager.AshForecast().Exchange_ItemDataList.Count; i++)
        {
            JT_CardItemData ExchangeData = JT_Manager.AshForecast().Exchange_ItemDataList[i];
            if (i < ExchangeItemList.Count) // 已有的卡片 更新UI
                ExchangeItemList[i].UpdateUI(ExchangeData);
            else // 新增卡片
            {
                JT_CardItem NewExchange = Instantiate(ExchangeItem, ExchangeItem.transform.parent);
                NewExchange.UpdateUI(ExchangeData);
                NewExchange.gameObject.SetActive(true);
                ExchangeItemList.Add(NewExchange);
            }
        }
    }

    public void UpdateExchangeListUI_PlatformIcon() //所有档位卡片的平台设为当前所选平台
    {
        for (int i = 0; i < ExchangeItemList.Count; i++)
        {
            ExchangeItemList[i].SetPlatformIcon(PlatformIcons[JT_Manager.AshForecast().CurrentPlatformIndex]);
        }
    }

    public void UpdateOneCardUI_Exchange(int Index) //单独更新指定卡片UI（等待任务计时使用）
    {
        JT_CardItemData CardData = JT_Manager.AshForecast().Exchange_ItemDataList[Index];
        ExchangeItemList[Index].UpdateUI(CardData);
    }

    #endregion

    #region 订单
    public void UpdateOrderListUI() //更新所有订单UI
    {
        NoOrderGO.SetActive(JT_Manager.AshForecast().Order_ItemDataList.Count <= 0);

        for (int i = 0; i < JT_Manager.AshForecast().Order_ItemDataList.Count; i++)
        {
            JT_OrderItemData OrderData = JT_Manager.AshForecast().Order_ItemDataList[i];
            if (i < OrderItemList.Count) // 已有的卡片 更新UI
                OrderItemList[i].Init(OrderData);
            else // 新增卡片
            {
                JT_OrderItem NewOrder = Instantiate(OrderItem, OrderItem.transform.parent);
                NewOrder.Init(OrderData);
                NewOrder.gameObject.SetActive(true);
                OrderItemList.Add(NewOrder);
            }
        }
    }
    #endregion

    #region 反馈
    public void OpenFeedbackPage() //打开反馈页面
    {
        FeedbackDropdown.value = 0;
        FeedbackInputField.text = "";
        FeedbackEmailInputField.text = "";
        FeedbackPage.SetActive(true);
    }
    public void CloseFeedbackPage() //关闭反馈页面
    {
        FeedbackPage.SetActive(false);
    }
    public void SubmitFeedback() //提交反馈
    {
        if (string.IsNullOrEmpty(FeedbackInputField.text))
        {
            ExaltGrecian.AshForecast().EvenExalt(JT_Manager.AshForecast().Translate("Please describe your issue."));
            return;
        }
        if (string.IsNullOrEmpty(FeedbackEmailInputField.text))
        {
            ExaltGrecian.AshForecast().EvenExalt(JT_Manager.AshForecast().Translate("Please enter your email address."));
            return;
        }
        if (!System.Text.RegularExpressions.Regex.IsMatch(FeedbackEmailInputField.text, @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"))
        {
            ExaltGrecian.AshForecast().EvenExalt(JT_Manager.AshForecast().Translate("Please input a valid email."));
            return;
        }

        string Type = FeedbackDropdown.options[FeedbackDropdown.value].text;
        string Content = FeedbackInputField.text;
        print($"反馈类型:{Type} 反馈内容:{Content}");
        CloseFeedbackPage();
        ExaltGrecian.AshForecast().EvenExalt(JT_Manager.AshForecast().Translate("Feedback Submit Success"));
    }
    #endregion

#endif
}
