/**
 * 
 * 网络请求的post对象
 * 
 * ***/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class WedLackSashRender 
{
    //post请求地址
    public string URL;
    //post的数据表单
    public WWWForm Pure;
    //post成功回调
    public Action<UnityWebRequest> SashMonster;
    //post失败回调
    public Action SashFact;
    public WedLackSashRender(string url,WWWForm  form,Action<UnityWebRequest> success,Action fail)
    {
        URL = url;
        Pure = form;
        SashMonster = success;
        SashFact = fail;
    }
}
