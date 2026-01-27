using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class JT_CardItem : MonoBehaviour
{
#if JT

    JT_CardItemData CardData;
    List<int> TaskGroupIndexsList;
    JT_CashOut_TaskData TaskData;
    public Image PlatformIcon;
    public Text MoneyText;
    [Header("状态0 等待开启")]
    public Transform State_Open;
    public Text State_Open_MoneyText;
    public Button OpenBtn;
    public Image NeedMoneyIcon;
    public Text NeedMoneyText;
    public Image NeedMoneyFill;
    [Header("状态1 任务带跳转")]
    public Transform State_Task_Jump;
    public Text State_Task_Jump_MoneyText;
    public Text State_Task_Jump_DescText;
    public Button JumpBtn;
    [Header("状态2 任务不跳转")]
    public Transform State_Task_NoJump;
    public Text State_Task_NoJump_MoneyText;
    public Text State_Task_NoJump_DescText;
    [Header("状态3 任务等待")]
    public Transform State_Task_Wait;
    public Text State_Task_Wait_MoneyText;
    public Text State_Task_Wait_DescText;
    public Text TimeText_Hour;
    public Text TimeText_Minute;
    public Text TimeText_Second;
    [Header("状态4 等待任务可以看广告加速")]
    public Transform State_Task_Wait_Ad;
    public Text State_Task_Wait_Ad_MoneyText;
    public Text State_Task_Wait_Ad_DescText;
    public Text State_Task_Wait_Ad_TimeText_Hour;
    public Text State_Task_Wait_Ad_TimeText_Minute;
    public Text State_Task_Wait_Ad_TimeText_Second;
    public Button AdFastWaitBtn;
    public Text AdFastWaitBtnText;



    public void UpdateUI(JT_CardItemData CardData) //更新UI 
    {
        this.CardData = CardData;
        // 更新金额
        if (MoneyText != null)
            MoneyText.text = "$ " + CardData.Money.ToString("F2");
        if (State_Open_MoneyText != null)
            State_Open_MoneyText.text = "$ " + CardData.Money.ToString("F2");
        if (State_Task_Jump_MoneyText != null)
            State_Task_Jump_MoneyText.text = "$ " + CardData.Money.ToString("F2");
        if (State_Task_NoJump_MoneyText != null)
            State_Task_NoJump_MoneyText.text = "$ " + CardData.Money.ToString("F2");
        if (State_Task_Wait_MoneyText != null)
            State_Task_Wait_MoneyText.text = "$ " + CardData.Money.ToString("F2");
        if (State_Task_Wait_Ad_MoneyText != null)
            State_Task_Wait_Ad_MoneyText.text = "$ " + CardData.Money.ToString("F2");
        // 更新任务信息
        if (CardData.CardState != 0)
        {
            TaskGroupIndexsList = JT_Manager.AshForecast().GetTaskGroupIndexs(CardData.TaskGroupIndex);
            TaskData = JT_Manager.AshForecast().GetTaskData(TaskGroupIndexsList[CardData.CompletedTaskNum]);
            string DescriptionStr = JT_Manager.AshForecast().Translate(TaskData.Description);
            DescriptionStr = string.Format(DescriptionStr, CardData.TaskValue, TaskData.Target);
            State_Task_Jump_DescText.text = DescriptionStr;
            State_Task_NoJump_DescText.text = DescriptionStr;
            State_Task_Wait_DescText.text = DescriptionStr;
            State_Task_Wait_Ad_DescText.text = DescriptionStr;
        }

        if (CardData.CardState == 0) //状态0 等待开启
        {
            State_Open.gameObject.SetActive(true);
            State_Task_Jump.gameObject.SetActive(false);
            State_Task_NoJump.gameObject.SetActive(false);
            State_Task_Wait.gameObject.SetActive(false);
            State_Task_Wait_Ad.gameObject.SetActive(false);

            OpenBtn.onClick.RemoveAllListeners();
            OpenBtn.onClick.AddListener(OpenBtnClick);

            if (NeedMoneyIcon != null)
            {
                if (CardData.NeedMoneyType == "JT_Money1")
                {
                    NeedMoneyIcon.sprite = JT_Manager.AshForecast()._CashOutPanel.MoneyIcon1;
                    NeedMoneyText.text = JT_Manager.AshForecast().JT_Money1.ToString("F2") + "/" + CardData.NeedMoney.ToString("F2");
                    NeedMoneyFill.fillAmount = JT_Manager.AshForecast().JT_Money1 / (float)CardData.NeedMoney;
                }
                else
                {
                    NeedMoneyIcon.sprite = JT_Manager.AshForecast()._CashOutPanel.MoneyIcon2;
                    NeedMoneyText.text = JT_Manager.AshForecast().JT_Money2.ToString("F2") + "/" + CardData.NeedMoney.ToString("F2");
                    NeedMoneyFill.fillAmount = JT_Manager.AshForecast().JT_Money2 / (float)CardData.NeedMoney;
                }
                NeedMoneyIcon.SetNativeSize();
            }
        }
        else if (CardData.CardState == 1) //状态1 任务带跳转
        {
            State_Open.gameObject.SetActive(false);
            State_Task_Jump.gameObject.SetActive(true);
            State_Task_NoJump.gameObject.SetActive(false);
            State_Task_Wait.gameObject.SetActive(false);
            State_Task_Wait_Ad.gameObject.SetActive(false);

            JumpBtn.onClick.RemoveAllListeners();
            JumpBtn.onClick.AddListener(JumpBtnClick);
        }
        else if (CardData.CardState == 2) //状态2 任务不跳转
        {
            State_Open.gameObject.SetActive(false);
            State_Task_Jump.gameObject.SetActive(false);
            State_Task_NoJump.gameObject.SetActive(true);
            State_Task_Wait.gameObject.SetActive(false);
            State_Task_Wait_Ad.gameObject.SetActive(false);
        }
        else if (CardData.CardState == 3) //状态3 任务等待
        {
            State_Open.gameObject.SetActive(false);
            State_Task_Jump.gameObject.SetActive(false);
            State_Task_NoJump.gameObject.SetActive(false);
            State_Task_Wait.gameObject.SetActive(true);
            State_Task_Wait_Ad.gameObject.SetActive(false);

            System.TimeSpan timeSpan = System.TimeSpan.FromSeconds(CardData.TaskValue);
            TimeText_Hour.text = timeSpan.Hours.ToString("D2");
            TimeText_Minute.text = timeSpan.Minutes.ToString("D2");
            TimeText_Second.text = timeSpan.Seconds.ToString("D2");
        }
        else if (CardData.CardState == 4) //状态4 等待任务可以看广告加速
        {
            State_Open.gameObject.SetActive(false);
            State_Task_Jump.gameObject.SetActive(false);
            State_Task_NoJump.gameObject.SetActive(false);
            State_Task_Wait.gameObject.SetActive(false);
            State_Task_Wait_Ad.gameObject.SetActive(true);

            System.TimeSpan timeSpan = System.TimeSpan.FromSeconds(CardData.TaskValue);
            State_Task_Wait_Ad_TimeText_Hour.text = timeSpan.Hours.ToString("D2");
            State_Task_Wait_Ad_TimeText_Minute.text = timeSpan.Minutes.ToString("D2");
            State_Task_Wait_Ad_TimeText_Second.text = timeSpan.Seconds.ToString("D2");

            AdFastWaitBtn.onClick.RemoveAllListeners();
            AdFastWaitBtn.onClick.AddListener(AdFastWaitBtnClick);
            string TimeStr = JT_Manager.AshForecast().Translate("Watch Ad Accelerate {0} Seconds");
            AdFastWaitBtnText.text = string.Format(TimeStr, TaskData.FastWaitTime);
        }
    }

    public void SetPlatformIcon(Sprite Icon) // 设置平台图标
    {
        if (PlatformIcon != null)
            PlatformIcon.sprite = Icon;
    }

    void OpenBtnClick() // 开启卡片 根据配置做任务或移入订单
    {
        // 档位卡 没钱无法开启
        if (CardData.NeedMoney > 0)
        {
            float NowMoney = 0;
            if (CardData.NeedMoneyType == "JT_Money1")
                NowMoney = JT_Manager.AshForecast().JT_Money1;
            else if (CardData.NeedMoneyType == "JT_Money2")
                NowMoney = JT_Manager.AshForecast().JT_Money2;
            if (NowMoney < CardData.NeedMoney)
            {
                SashNewlyBroker.AshForecast().VastNewly(JT_Manager.AshForecast().Translate("Not Enough Money"));
                UIGrecian.AshForecast().EvenUIDaddy(nameof(Exalt), JT_Manager.AshForecast().Translate("Not Enough Money"));
                return;
            }
        }

        // 账号为空 无法开启
        if (string.IsNullOrEmpty(JT_Manager.AshForecast()._CashOutPanel.CurrentAccount))
        {
            JT_Manager.AshForecast()._CashOutPanel.OpenEnterAccountPage();
            return;
        }

        // 开启卡片 开始做任务
      
        JT_Manager.AshForecast().OpenCardAndSetTask(CardData.NeedMoney == 0, CardData);
        CardData = JT_Manager.AshForecast().CheckNextTask(CardData);
        JT_Manager.AshForecast().UpdateCash_ItemDataList(CardData);
        UpdateUI(CardData);

        //开启卡片打点
        if (CardData.NeedMoney > 0)
        {
            if (CardData.NeedMoneyType == "JT_Money1")
            {
                int opencard = PlayerPrefs.GetInt("OpenCard1016", 0);
                opencard += 1;
                PlayerPrefs.SetInt("OpenCard1016", opencard);
                SashNewlyBroker.AshForecast().VastNewly("1016", opencard.ToString());
                SashNewlyBroker.AshForecast().VastNewly("1402", JT_Manager.AshForecast().JT_Money1.ToString("F2"), "1");

            }
            else if (CardData.NeedMoneyType == "JT_Money2") 
            {
                int OpenCard1020 = PlayerPrefs.GetInt("OpenCard1020", 0);
                OpenCard1020 += 1;
                PlayerPrefs.SetInt("OpenCard1020", OpenCard1020);
                SashNewlyBroker.AshForecast().VastNewly("1020", OpenCard1020.ToString());
                SashNewlyBroker.AshForecast().VastNewly("1402", JT_Manager.AshForecast().JT_Money2.ToString("F2"), "1");
            }
        }
        else
            SashNewlyBroker.AshForecast().VastNewly("1402", JT_Manager.AshForecast().JT_Money1.ToString("F2"), "0");
    }

    void JumpBtnClick() // 跳转按钮点击
    {
        JT_Manager.AshForecast().JumpBtnClick();
    }

    void AdFastWaitBtnClick() // 广告快速等待按钮点击
    {
        ADGrecian.Forecast.AmidUnlessRebel((ok) =>
        {
            JT_Manager.AshForecast().AddTask_FastWait(CardData, TaskData.FastWaitTime);
        }, "0");
    }

#endif
}