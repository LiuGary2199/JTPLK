using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary> 时间管理器 </summary>
public class PestGrecian : ObeySubstrate<PestGrecian>
{
    public bool OnBeach{ get; set; } // 是否暂停

    /// <summary> 延迟调用 </summary>    
    public Coroutine Novel(float delay, Action action)
    {
        return StartCoroutine(NovelIE(delay, action));
    }
    IEnumerator NovelIE(float delay, Action action)
    {
        yield return new WaitForSeconds(delay);
        action?.Invoke();
    }

    /// <summary> 延迟调用，带暂停功能 </summary>
    public Coroutine Novel_SoloBeach(float delay, Action action)
    {
        return StartCoroutine(NovelIE_SoloBeach(delay, action));
    }
    IEnumerator NovelIE_SoloBeach(float delay, Action action)
    {
        float elapsed = 0;
        while (elapsed < delay)
        {
            if (!OnBeach)
                elapsed += Time.deltaTime;
            yield return null;
        }
        action?.Invoke();
    }

    /// <summary> 循环调用，带暂停功能 </summary>
    public void Minute_SoloBeach(float initialDelay, float interval, Action action)
    {
        StartCoroutine(MinuteSteamboat(initialDelay, interval, action));
    }
    private IEnumerator MinuteSteamboat(float initialDelay, float interval, Action action)
    {
        // 初始延迟
        yield return NovelIE_SoloBeach(initialDelay, () => { });
        // 循环调用
        while (true)
        {
            if (!OnBeach)
                action?.Invoke();
            yield return NovelIE_SoloBeach(interval, () => { });
        }
    }

    public void AkinNovel(Coroutine coroutine)
    {
        StopCoroutine(coroutine);
    }


    //获取离线时间（以秒为单位）
    public int AshRestfulPest()
    {
        if (PlayerPrefs.HasKey("LastOnline"))
        {
            long lastOnline = long.Parse(PlayerPrefs.GetString("LastOnline"));
            return (int)(AshHairPestLover() - lastOnline);
        }
        else
            return 0;
    }
    //获取Unix时间戳（以秒为单位）
    public long AshHairPestLover()
    {
        return DateTimeOffset.Now.ToUnixTimeSeconds();
    }
    //更新最后在线时间
    private void DifferHostNamelyPest()
    {
        PlayerPrefs.SetString("LastOnline", AshHairPestLover().ToString());
    }

    void OnApplicationQuit()
    {
        DifferHostNamelyPest();
    }
    private void OnApplicationPause(bool pause)
    {
        if (pause)
            DifferHostNamelyPest();
    }
}
