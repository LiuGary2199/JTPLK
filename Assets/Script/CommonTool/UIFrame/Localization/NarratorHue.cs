/*
 * 
 * 多语言
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarratorHue 
{
    public static NarratorHue _Fertilize;
    //语言翻译的缓存集合
    private Dictionary<string, string> _FeeNarratorThigh;

    private NarratorHue()
    {
        _FeeNarratorThigh = new Dictionary<string, string>();
        //初始化语言缓存集合
        WineNarratorThigh();
    }

    /// <summary>
    /// 获取实例
    /// </summary>
    /// <returns></returns>
    public static NarratorHue AshForecast()
    {
        if (_Fertilize == null)
        {
            _Fertilize = new NarratorHue();
        }
        return _Fertilize;
    }

    /// <summary>
    /// 得到显示文本信息
    /// </summary>
    /// <param name="lauguageId">语言id</param>
    /// <returns></returns>
    public string EvenDrug(string lauguageId)
    {
        string strQueryResult = string.Empty;
        if (string.IsNullOrEmpty(lauguageId)) return null;
        //查询处理
        if(_FeeNarratorThigh!=null && _FeeNarratorThigh.Count >= 1)
        {
            _FeeNarratorThigh.TryGetValue(lauguageId, out strQueryResult);
            if (!string.IsNullOrEmpty(strQueryResult))
            {
                return strQueryResult;
            }
        }
        Debug.Log(GetType() + "/ShowText()/ Query is Null!  Parameter lauguageID: " + lauguageId);
        return null;
    }

    /// <summary>
    /// 初始化语言缓存集合
    /// </summary>
    private void WineNarratorThigh()
    {
        //LauguageJSONConfig_En
        //LauguageJSONConfig
        IWinterGrecian config = new WinterGrecianDyMute("LauguageJSONConfig");
        if (config != null)
        {
            _FeeNarratorThigh = config.SeaPavlova;
        }
    }
}
