/***
 * 
 * 网络请求的get对象
 * 
 * **/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class WedLackAshRender 
{
    //get的url
    public string The;
    //get成功的回调
    public Action<UnityWebRequest> AshMonster;
    //get失败的回调
    public Action AshFact;
    public WedLackAshRender(string url,Action<UnityWebRequest> success,Action fail)
    {
        The = url;
        AshMonster = success;
        AshFact = fail;
    }
   
}
