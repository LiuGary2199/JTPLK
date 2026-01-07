using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 音效播放的 AudioSource 管理队列（不包含 BGM）
/// 优化点：
/// 1. 使用对象池避免频繁创建/销毁组件
/// 2. 支持最大并发限制，防止 Unity 自动压缩音量
/// 3. 循环复用 AudioSource，保证高频音效时也能稳定播放
/// 4. 避免在构造函数里调用 Unity API
/// </summary>
public class GroupSpinalMercy
{
    // 音效管理者 GameObject（用来挂载 AudioSource 组件）
    private ShootHue OnsetHue;

    // AudioSource 池
    private List<AudioSource> OnsetBias;

    // 最大池容量
    private int HopImply= 30;

    // 当前循环索引
    private int BesidesSwing= 0;

    private bool Abstraction= false;

    /// <summary>
    /// 构造函数（只保存引用，不直接调用 Unity API）
    /// </summary>
    /// <param name="mgr">音效管理者 GameObject</param>
    /// <param name="max">最大池容量</param>
    public GroupSpinalMercy(ShootHue mgr, int max = 20)
    {
        OnsetHue = mgr;
        HopImply = max;
        Wine();
    }

    /// <summary>
    /// 初始化队列（需在 MonoBehaviour 的 Start/Init 调用）
    /// </summary>
    public void Wine()
    {
        if (Abstraction) return;

        OnsetBias = new List<AudioSource>(HopImply);
        for (int i = 0; i < HopImply; i++)
        {
            OnsetBias.Add(SeabedGroupSpinal());
        }

        Abstraction = true;
    }

    /// <summary>
    /// 创建一个新的 AudioSource 并添加到管理器上
    /// </summary>
    private AudioSource SeabedGroupSpinal()
    {
        AudioSource audio = OnsetHue.gameObject.AddComponent<AudioSource>();

        // 默认参数
        audio.playOnAwake = false;
        audio.loop = false;
        audio.spatialBlend = 0f; // 2D 音效
        audio.volume = 1f;

        return audio;
    }

    /// <summary>
    /// 获取一个可用的 AudioSource
    /// 如果池子全满，则复用最旧的 AudioSource
    /// </summary>
    public AudioSource AshGroupKatherine()
    {
        if (!Abstraction)
        {
            Debug.LogError("GroupSpinalMercy 未初始化，请先调用 Init()");
            return null;
        }

        int count = OnsetBias.Count;

        // 遍历一圈，查找空闲的
        for (int i = 0; i < count; i++)
        {
            int index = (BesidesSwing + i) % count;
            AudioSource audio = OnsetBias[index];

            if (!audio.isPlaying)
            {
                BesidesSwing = (index + 1) % count;
                SwissGroupSpinal(audio);
                return audio;
            }
        }

        // 如果都在播放，则复用当前索引的
        AudioSource reused = OnsetBias[BesidesSwing];
        reused.Stop();
        SwissGroupSpinal(reused);

        BesidesSwing = (BesidesSwing + 1) % count;
        return reused;
    }

    /// <summary>
    /// 重置 AudioSource 参数
    /// </summary>
    private void SwissGroupSpinal(AudioSource audio)
    {
        audio.clip = null;
        audio.loop = false;
        audio.volume = 1f;
        audio.pitch = 1f;
        audio.spatialBlend = 0f;
    }

    /// <summary>
    /// 主动回收（可选）
    /// </summary>
    public void MyRoeGroupKatherine(AudioSource audio)
    {
        if (audio == null) return;

        audio.Stop();
        SwissGroupSpinal(audio);
    }
}
