using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//登录服务器返回数据
public class RootData
{
    public int code { get; set; }
    public string msg { get; set; }
    public ServerData data { get; set; }
}
//用户登录信息
public class ServerUserData
{
    public int code { get; set; }
    public string msg { get; set; }
    public int data { get; set; }
}
//服务器的数据
public class ServerData
{
    public string init { get; set; }
    public string version { get; set; }

    public string apple_pie { get; set; }
    public string inter_b2f_count { get; set; }
    public string inter_freq { get; set; }
    public string relax_interval { get; set; }
    public string trial_MaxNum { get; set; }
    public string nextlevel_interval { get; set; }
    public string adjust_init_rate_act { get; set; }
    public string adjust_init_act_position { get; set; }
    public string adjust_init_adrevenue { get; set; }

    public string GameData { get; set; } //游戏数据



    public string CashOut_Data { get; set; } //真提现数据
    public string JT_CashOut_Data { get; set; } //假提数据
    public string BlockRule { get; set; } //屏蔽规则
}
public class Init
{
    public MultiGroup[] cash_group { get; set; }
    public MultiGroup[] gold_group { get; set; }
}

public class MultiGroup
{
    public int max { get; set; }
    public double multi { get; set; }
}

public class GameData
{
    public double break_multi { get; set; } // 点击掉落球间隔时间
    public double click_drop_ball_gap { get; set; } // 点击掉落球间隔时间
    public double block_wall_anim_time { get; set; } // 黑洞挡板动画时间
    public double block_wall_stay_time { get; set; } // 黑洞挡板停留时间
    public int supply_ball_time { get; set; } // 补充球时间间隔
    public int ball_less_total { get; set; } // 球不足时，补充球的数量
    public int buyballprice { get; set; } // 购买球的价格
    public int buyball_usecointime { get; set; } // 买球使用金币时间间隔
    //public int firstcoinnum { get; set; } // 首次进游戏的金币数量
    public int ball_recover { get; set; } // 球数量恢复时间(秒)
    public int buyballnum { get; set; } // 买球数量
    public int basereward_coin { get; set; } // 全局奖励基础数值，所有multi乘这个值
    public double basereward_cash { get; set; } // 全局奖励基础数值，所有multi乘这个值
    public string baserandom_coin { get; set; } // 全局基础奖励随机值
    public string baserandom_cash { get; set; } // 全局基础奖励随机值
    public double plinko_multi { get; set; } // 撞击金币奖励系数
    public int collect_A_count { get; set; } // 收集物A的奖励
    public int collect_B_count { get; set; } // 收集物B的奖励
    public double slot_win_weight { get; set; } // slot中奖权重
    public int ball_count { get; set; } // 球的上限数量
    public int split_lanch_time { get; set; } // 分裂挡板持续时间；
    public int fever_time { get; set; } // Fever time的持续时间
    public int fever_count { get; set; } // Fever time激活需要击碎的圆柱数量
    public int fever_chest_count { get; set; } // Fever time击破宝箱需要的击打次数
    public double fever_chest_award_mutli { get; set; } // Fever time击破宝箱奖励系数
    public double jackpot_reward_multi { get; set; } // 黑洞宝箱奖励系数
    public FlyBubbleData fly_bubble;
    public List<CollectData> collect_list { get; set; }
    public List<ItemData> item_list { get; set; }
    public List<SlotsData> slots_list { get; set; }
    public List<WheelData> wheel_list { get; set; } //转盘数据
    public List<UnderCollecterData> under_collecter_award_list { get; set; } //底部收集器数据
}
public class CollectData //收集物数据
{
    public string id; //收集物名字
    public int hp; //击碎需要次数
    public int cd; //刷新时间
    public string position; //出现位置
    public int live_limit; //最大数量
}
public class ItemData //物体数据
{
    public string id; //收集物名字
    public int hp; //击碎需要次数
    public int weight; //权重
    public int live_limit; //最大数量
}
public class SlotsData //slots数据
{
    public string type;
    public int weight;
    public double value;
}
public class FlyBubbleData //飞行气泡
{
    public double multi;
    public int cold_down;
    public int destroy_time;
}
public class WheelData //转盘数据
{
    public string type;
    public int count;
    public int weight;
}
public class UnderCollecterData //底部收集器数据
{
    public int weight;
    public double multi;
}


public class UserRootData
{
    public int code { get; set; }
    public string msg { get; set; }
    public string data { get; set; }
}

public class LocationData
{
    public double X;
    public double Y;
    public double Radius;
}

public class UserInfoData
{
    public double lat;
    public double lon;
    public string query; //ip地址
    public string regionName; //地区名称
    public string city; //城市名称
    public bool IsHaveApple; //是否有苹果
}

public class BlockRuleData //屏蔽规则
{
    public LocationData[] LocationList; //屏蔽位置列表
    public string[] CityList; //屏蔽城市列表
    public string[] IPList; //屏蔽IP列表
    public string fall_down; //自然量
    public bool BlockVPN; //屏蔽VPN
    public bool BlockSimulator; //屏蔽模拟器
    public bool BlockRoot; //屏蔽root
    public bool BlockDeveloper; //屏蔽开发者模式
    public bool BlockUsb; //屏蔽USB调试
    public bool BlockSimCard; //屏蔽SIM卡
    public int OrganicMaxAdNum; //自然量用户 每日最大广告次数
    public bool MinuteCheck; //每分钟检查用户是否被封禁
}

public class CashOutData //提现
{
    public string MoneyName; //货币名称
    public string Description; //玩法描述
    public string convert_goal; //兑换目标
    public List<CashOut_TaskData> TaskList; //任务列表
}

public class CashOut_TaskData
{
    public string Name; //任务名称
    public float NowValue; //当前值
    public double Target; //目标值
    public string Description; //任务描述
    public bool IsDefault; //是否默认（循环）任务
}

#if JT
public class JT_CashOutData //假提
{
    public int FunctionState; // 0抢钱 1档位 2抢钱+档位
    public int CardBornGap; //抢钱卡生成间隔
    public List<JT_CardItemData> Exchange_ItemDataList; //档位列表
    public List<JT_CashOut_TaskData> TaskList; //任务列表
    public List<List<int>> TaskGroupIndexsList; //任务组索引列表
    public List<LanguagesData> LanguagesList; //语言列表
}
public class JT_CashOut_TaskData
{
    public int Index; //任务索引
    public string Name; //任务名称 (Ad看广告 Wait等时间)
    public double Target; //目标值
    public bool IsJump; //是否需要跳转
    public int FastWaitTime; //快速等待时间
    public string Description; //任务描述
}
public class LanguagesData
{
    public string Languages; //语言
    public double Rate; //汇率
}
#endif

