using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// 消息管理器
/// </summary>
public class BoxlikeStenchVoice:ObeySubstrate<BoxlikeStenchVoice>
{
    //保存所有消息事件的字典
    //key使用字符串保存消息的名称
    //value使用一个带自定义参数的事件，用来调用所有注册的消息
    private Dictionary<string, Action<BoxlikeIraq>> UnderstandBoxlike;

    /// <summary>
    /// 私有构造函数
    /// </summary>
    private BoxlikeStenchVoice()
    {
        WineIraq();
    }

    private void WineIraq()
    {
        //初始化消息字典
        UnderstandBoxlike = new Dictionary<string, Action<BoxlikeIraq>>();
    }

    /// <summary>

    /// 注册消息事件
    /// </summary>
    /// <param name="key">消息名</param>
    /// <param name="action">消息事件</param>
    public void Narrowly(string key, Action<BoxlikeIraq> action)
    {
        if (!UnderstandBoxlike.ContainsKey(key))
        {
            UnderstandBoxlike.Add(key, null);
        }
        UnderstandBoxlike[key] += action;
    }



    /// <summary>
    /// 注销消息事件
    /// </summary>
    /// <param name="key">消息名</param>
    /// <param name="action">消息事件</param>
    public void Chorus(string key, Action<BoxlikeIraq> action)
    {
        if (UnderstandBoxlike.ContainsKey(key) && UnderstandBoxlike[key] != null)
        {
            UnderstandBoxlike[key] -= action;
        }
    }

    /// <summary>
    /// 发送消息
    /// </summary>
    /// <param name="key">消息名</param>
    /// <param name="data">消息传递数据，可以不传</param>
    public void Vast(string key, BoxlikeIraq data = null)
    {
        if (UnderstandBoxlike.ContainsKey(key) && UnderstandBoxlike[key] != null)
        {
            UnderstandBoxlike[key](data);
        }
    }

    /// <summary>
    /// 清空所有消息
    /// </summary>
    public void Breed()
    {
        UnderstandBoxlike.Clear();
    }
}
