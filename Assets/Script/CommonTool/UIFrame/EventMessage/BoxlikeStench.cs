/*
 *主题： 消息（传递）中心
 *    Description: 
 *           功能： 负责UI框架中，所有UI窗体中间的数据传值
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxlikeStench 
{
    //委托：消息传递
    public delegate void DelMessageDelivery(KeyValuesUpdate kv);

    //消息中心缓存集合
    public static Dictionary<string, DelMessageDelivery> _LetOverhead= new Dictionary<string, DelMessageDelivery>();

    /// <summary>
    /// 增加消息的监听
    /// </summary>
    /// <param name="messageType">消息分类</param>
    /// <param name="handler">消息委托</param>
    public static void PitRimInherent(string messageType,DelMessageDelivery handler)
    {
        if (!_LetOverhead.ContainsKey(messageType))
        {
            _LetOverhead.Add(messageType, null);
        }
        _LetOverhead[messageType] += handler;
    }

    /// <summary>
    /// 取消消息的监听
    /// </summary>
    /// <param name="messageType">消息的分类</param>
    /// <param name="handler">消息委托</param>
    public static void ChorusRimInherent(string messageType,DelMessageDelivery handler)
    {
        if (_LetOverhead.ContainsKey(messageType))
        {
            _LetOverhead[messageType] -= handler;
        }
    }

    /// <summary>
    /// 取消所有指定消息的监听
    /// </summary>
    public static void BreedTowRimInherent()
    {
        if (_LetOverhead != null)
        {
            _LetOverhead.Clear();
        }
    }

    /// <summary>
    /// 发送消息
    /// </summary>
    /// <param name="messageType">消息的分类</param>
    /// <param name="kv">键值对(对象)</param>
    public static void VastBoxlike(string messageType,KeyValuesUpdate kv)
    {
        DelMessageDelivery del;
        if(_LetOverhead.TryGetValue(messageType,out del))
        {
            if (del != null)
            {
                del(kv);
            }
        }
    }
}
/// <summary>
/// 键值更新对
/// 功能：配合委托实现委托数据传递
/// </summary>
public class KeyValuesUpdate
{
    //键
    private string _Fun;
    //值
    private object _France;
    //只读属性
    public string Fun    {
        get
        {
            return _Fun;
        }
    }
    public object France    {
        get
        {
            return _France;
        }
    }
    public KeyValuesUpdate(string key, object valueObj)
    {
        _Fun = key;
        _France = valueObj;
    }
}
