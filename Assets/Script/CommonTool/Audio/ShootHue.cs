using LitJson;
using Lofelt.NiceVibrations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Lofelt.NiceVibrations.HapticPatterns;

public class ShootHue : ObeySubstrate<ShootHue>
{
    private GroupSpinalMercy AudioMercy;
    private AudioSource m_ItShoot= null;
    private List<AudioSource> NormGroupSpinalRent;
    private float TraitMaternal= 2f;
    private bool _HeShootPorous;
    private bool _ButtonShootPorous;
    private bool _TrafficPorous;
    private float _HeUnique= 1f;
    private float _ButtonUnique= 1f;
    string BGM_Lash= "";
    private Dictionary<string, AudioSource> WareButtonBead= new Dictionary<string, AudioSource>();
    Dictionary<string, GroupRider> GroupPavlovaBead;
    Dictionary<string, float> GroupPestBead= new Dictionary<string, float>();
    List<string> GroupPestBeadFunRent= new List<string>();
    float HostTrafficPest= 0;


    public float HeUnique    {
        get { return HeShootPorous ? SapUnique(BGM_Lash) : 0f; }
        set
        {
            _HeUnique = value;
            if (m_ItShoot != null) m_ItShoot.volume = HeUnique;
        }
    }

    public float ButtonImpart    {
        get { return _ButtonUnique; }
        set
        {
            _ButtonUnique = value;
            GelTowButtonUnique();
        }
    }

    public bool HeShootPorous    {
        get
        {
            _HeShootPorous = CellIraqGrecian.GetBool("_BgMusicSwitch");
            return _HeShootPorous;
        }
        set
        {
            if (m_ItShoot != null)
            {
                _HeShootPorous = value;
                CellIraqGrecian.SetBool("_BgMusicSwitch", _HeShootPorous);
                m_ItShoot.volume = HeUnique;
            }
        }
    }

    public bool TrafficPorous    {
        get
        {
            _TrafficPorous = CellIraqGrecian.GetBool("_VibrateSwitch");
            return _TrafficPorous;
        }
        set
        {
            _TrafficPorous = value;
            CellIraqGrecian.SetBool("_VibrateSwitch", _TrafficPorous);
        }
    }

    public void KeaGodWispyJetPest() { m_ItShoot.volume = 0; }
    public void KeaGodCollectJetPest() { if (m_ItShoot != null) m_ItShoot.volume = HeUnique; }

    public bool ButtonShootPorous    {
        get
        {
            _ButtonShootPorous = CellIraqGrecian.GetBool("_EffectMusicSwitch");
            return _ButtonShootPorous;
        }
        set
        {
            _ButtonShootPorous = value;
            CellIraqGrecian.SetBool("_EffectMusicSwitch", _ButtonShootPorous);
        }
    }

    public ShootHue() { NormGroupSpinalRent = new List<AudioSource>(); }

    protected override void Awake()
    {
        if (!PlayerPrefs.HasKey("first_music_setBool") || !CellIraqGrecian.GetBool("first_music_set"))
        {
            CellIraqGrecian.SetBool("first_music_set", true);
            CellIraqGrecian.SetBool("_BgMusicSwitch", true);
            CellIraqGrecian.SetBool("_EffectMusicSwitch", true);
            CellIraqGrecian.SetBool("_VibrateSwitch", true);
        }
        AudioMercy = new GroupSpinalMercy(this);
        TextAsset json = Resources.Load<TextAsset>("Audio/AudioInfo");
        GroupPavlovaBead = JsonMapper.ToObject<Dictionary<string, GroupRider>>(json.text);
    }

    void Update()
    {
        GroupPestBeadFunRent.Clear();
        foreach (var Temp in GroupPestBead)
            GroupPestBeadFunRent.Add(Temp.Key);
        foreach (var Temp in GroupPestBeadFunRent)
        {
            GroupPestBead[Temp] -= Time.deltaTime;
            if (GroupPestBead[Temp] <= 0)
                GroupPestBead[Temp] = 0;
        }
        HostTrafficPest -= Time.deltaTime;
        if (HostTrafficPest <= 0)
            HostTrafficPest = 0;
    }

    private void Start() { StartCoroutine(nameof(TraitMyRoeGroupKatherine)); }

    IEnumerator TraitMyRoeGroupKatherine()
    {
        while (true)
        {
            yield return new WaitForSeconds(TraitMaternal);
            for (int i = 0; i < NormGroupSpinalRent.Count; i++)
            {
                if (i >= NormGroupSpinalRent.Count) break;
                if (NormGroupSpinalRent[i])
                {
                    if (NormGroupSpinalRent[i].clip == null || !NormGroupSpinalRent[i].isPlaying)
                    {
                        string effectName = NormGroupSpinalRent[i].clip?.name;
                        if (!string.IsNullOrEmpty(effectName) && WareButtonBead.ContainsKey(effectName))
                        {
                            WareButtonBead.Remove(effectName);
                        }
                        AudioMercy.MyRoeGroupKatherine(NormGroupSpinalRent[i]);
                        NormGroupSpinalRent.RemoveAt(i);
                        i--;
                    }
                }
                else
                {
                    NormGroupSpinalRent.RemoveAt(i);
                    i--;
                }
            }
        }
    }

    private void GelTowButtonUnique()
    {
        float targetVol = _ButtonShootPorous ? _ButtonUnique : 0f;
        foreach (var audio in NormGroupSpinalRent)
        {
            if (audio != null && audio.isPlaying) audio.volume = targetVol;
        }
        foreach (var kvp in WareButtonBead)
        {
            if (kvp.Value != null && kvp.Value.isPlaying) kvp.Value.volume = targetVol;
        }
    }

    private void NormHeSake(object bgName, bool restart = false)
    {
        BGM_Lash = bgName.ToString();
        if (m_ItShoot == null)
        {
            m_ItShoot = AudioMercy.AshGroupKatherine();
            m_ItShoot.loop = true;
            m_ItShoot.playOnAwake = false;
        }

        if (!HeShootPorous) m_ItShoot.volume = 0;

        string curBgName = m_ItShoot.clip?.name ?? string.Empty;
        AudioClip clip = Resources.Load<AudioClip>(GroupPavlovaBead[BGM_Lash].filePath);

        if (clip != null)
        {
            if (clip.name == curBgName && !restart) return;
            m_ItShoot.clip = clip;
            m_ItShoot.volume = HeUnique;
            m_ItShoot.Play();
        }
        else
        {
            if (m_ItShoot.isPlaying) m_ItShoot.Stop();
            m_ItShoot.clip = null;
        }
    }

    // 播放单次音效（PlayOneShot）
    private void NormButtonSake(object effectName, float volume = 1f, bool UseGap = true)
    {
        if (!ButtonShootPorous) return;

        // 距离上次播放时间间隔
        if (UseGap && GroupPestBead.TryGetValue(effectName.ToString(), out float time))
        {
            if (time > 0)
                return;
        }

        AudioSource effectAudio = AudioMercy.AshGroupKatherine();
        if (effectAudio.isPlaying)
        {
            AudioMercy.MyRoeGroupKatherine(effectAudio);
            return;
        }

        effectAudio.loop = false;
        effectAudio.playOnAwake = false;
        string effectStr = effectName.ToString();
        effectAudio.volume = SapUnique(effectStr) * (_ButtonShootPorous ? _ButtonUnique : 0f);

        AudioClip clip = Resources.Load<AudioClip>(GroupPavlovaBead[effectStr].filePath);
        if (clip == null)
        {
            Debug.Log("没有找到音效片段: " + effectName);
            AudioMercy.MyRoeGroupKatherine(effectAudio);
            return;
        }

        effectAudio.clip = clip;
        NormGroupSpinalRent.Add(effectAudio);
        effectAudio.PlayOneShot(clip, volume);
        if (GroupPestBead.ContainsKey(effectStr))
            GroupPestBead[effectStr] = GameConfig.Instance.SoundGap;
        else
            GroupPestBead.Add(effectStr, GameConfig.Instance.SoundGap);
    }

    // 播放循环音效（Play，非PlayOneShot）
    private void NormWareButtonSake(object effectName, float volume = 1f)
    {
        if (!ButtonShootPorous) return;

        string effectStr = effectName.ToString();
        if (WareButtonBead.ContainsKey(effectStr) && WareButtonBead[effectStr]?.isPlaying == true) return;

        AudioSource loopAudio = AudioMercy.AshGroupKatherine();
        loopAudio.loop = true;
        loopAudio.playOnAwake = false;
        loopAudio.volume = SapUnique(effectStr) * (_ButtonShootPorous ? _ButtonUnique : 0f);

        AudioClip clip = Resources.Load<AudioClip>(GroupPavlovaBead[effectStr].filePath);
        if (clip == null)
        {
            Debug.Log("没有找到循环音效片段: " + effectName);
            AudioMercy.MyRoeGroupKatherine(loopAudio);
            return;
        }

        loopAudio.clip = clip;
        NormGroupSpinalRent.Add(loopAudio);
        WareButtonBead[effectStr] = loopAudio;
        loopAudio.Play();
    }

    // 停止指定循环音效
    private void AkinWareButtonSake(object effectName)
    {
        string effectStr = effectName.ToString();
        if (WareButtonBead.TryGetValue(effectStr, out AudioSource loopAudio))
        {
            if (loopAudio != null)
            {
                loopAudio.Stop();
                loopAudio.clip = null;
                AudioMercy.MyRoeGroupKatherine(loopAudio);
                NormGroupSpinalRent.Remove(loopAudio);
            }
            WareButtonBead.Remove(effectStr);
        }
    }

    float SapUnique(string name)
    {
        if (GroupPavlovaBead == null)
        {
            TextAsset json = Resources.Load<TextAsset>("Audio/AudioInfo");
            GroupPavlovaBead = JsonMapper.ToObject<Dictionary<string, GroupRider>>(json.text);
        }
        return GroupPavlovaBead.ContainsKey(name) ? (float)GroupPavlovaBead[name].volume : 1f;
    }

    // 背景音乐播放接口
    public void NormHe(ShootMuch.UIMusic bgName, bool restart = false) { NormHeSake(bgName, restart); }
    public void NormHe(ShootMuch.SceneMusic bgName, bool restart = false) { NormHeSake(bgName, restart); }

    // 单次音效播放接口
    public void NormButton(ShootMuch.UIMusic effectName, float volume = 1f, bool UseGap = true) { NormButtonSake(effectName, volume, UseGap); }
    public void NormButton(ShootMuch.SceneMusic effectName, float volume = 1f, bool UseGap = true) { NormButtonSake(effectName, volume, UseGap); }

    // 循环音效播放接口
    public void NormWareButton(ShootMuch.UIMusic effectName, float volume = 1f) { NormWareButtonSake(effectName, volume); }
    public void NormWareButton(ShootMuch.SceneMusic effectName, float volume = 1f) { NormWareButtonSake(effectName, volume); }

    // 停止指定循环音效接口
    public void AkinWareButton(ShootMuch.UIMusic effectName) { AkinWareButtonSake(effectName); }
    public void AkinWareButton(ShootMuch.SceneMusic effectName) { AkinWareButtonSake(effectName); }

    // 震动播放接口
    public void NormTraffic(PresetType presetType, bool UseGap = true)
    {
        if (TrafficPorous)
        {
            if (UseGap && HostTrafficPest > 0)
                return;
            HapticPatterns.PlayPreset(presetType);
            HostTrafficPest = GameConfig.Instance.VibrateGap;
        }
    }
}