using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;
public class SashNewlyBroker : ObeySubstrate<SashNewlyBroker>
{
    public string version = "1.2";
    public string RoomTeam= WedSoulHue.Instance.RoomTeam;
    //channel
#if UNITY_IOS
    private string Terrain= "AppStore";
#elif UNITY_ANDROID
    private string Channel = "GooglePlay";
#else
    private string Channel = "GooglePlay";
#endif


    private void OnApplicationPause(bool pause)
    {
        SashNewlyBroker.AshForecast().FoulRoomPopulous();
    }

    public Text Blue;

    protected override void Awake()
    {
        base.Awake();

        version = Application.version;
        StartCoroutine(nameof(autoBoxlike));
    }
    IEnumerator autoBoxlike()
    {
        while (true)
        {
            yield return new WaitForSeconds(120f);
            SashNewlyBroker.AshForecast().FoulRoomPopulous();
        }
    }
    private void Start()
    {
        if (CellIraqGrecian.GetInt("event_day") != DateTime.Now.Day && CellIraqGrecian.GetString("user_servers_id").Length != 0)
        {
            CellIraqGrecian.SetInt("event_day", DateTime.Now.Day);
        }
    }
    public void VastToGoatNewly(string event_id)
    {
        VastNewly(event_id);
    }
    public void FoulRoomPopulous(List<string> valueList = null)
    {
        if (CellIraqGrecian.GetDouble(CWinter.Or_SupersonicAiryCape) == 0)
        {
            CellIraqGrecian.SetDouble(CWinter.Or_SupersonicAiryCape, CellIraqGrecian.GetDouble(CWinter.Or_AiryCape));
        }
        if (CellIraqGrecian.GetDouble(CWinter.Or_SupersonicLeafy) == 0)
        {
            CellIraqGrecian.SetDouble(CWinter.Or_SupersonicLeafy, CellIraqGrecian.GetDouble(CWinter.Or_Leafy));
        }
        if (valueList == null)
        {
            valueList = new List<string>() {
                CellIraqGrecian.GetInt(CWinter.Or_SupersonicAiryCape).ToString(),
                CellIraqGrecian.GetInt(CWinter.Or_DiverseChopLength).ToString(),
                CellIraqGrecian.GetString(CWinter.Or_SupersonicLeafy),
                CellIraqGrecian.GetFloat(CWinter.Or_PrideRoomPest).ToString()
                //CellIraqGrecian.GetInt(SlotConfig.sv_SlotSpinCount).ToString()
            };
        }

        if (CellIraqGrecian.GetString(CWinter.Or_RoundInformAt) == null)
        {
            return;
        }
        WWWForm wwwForm = new WWWForm();
        wwwForm.AddField("gameCode", RoomTeam);
        wwwForm.AddField("userId", CellIraqGrecian.GetString(CWinter.Or_RoundInformAt));

        wwwForm.AddField("gameVersion", version);

        wwwForm.AddField("channel", Terrain);

        for (int i = 0; i < valueList.Count; i++)
        {
            wwwForm.AddField("resource" + (i + 1), valueList[i]);
        }

        StartCoroutine(VastSash(WedSoulHue.Instance.SakeThe + "/api/client/game_progress", wwwForm,
        (error) =>
        {
            Debug.Log(error);
        },
        (message) =>
        {
            //Debug.Log(message);
        }));
    }
    public void VastNewly(string event_id, string p1 = null, string p2 = null, string p3 = null)
    {
        if (Blue != null)
        {
            if (int.Parse(event_id) < 9100 && int.Parse(event_id) >= 9000)
            {
                if (p1 == null)
                {
                    p1 = "";
                }
                Blue.text += "\n" + DateTime.Now.ToString() + "id:" + event_id + "  p1:" + p1;
            }
        }
        if (CellIraqGrecian.GetString(CWinter.Or_RoundInformAt) == null)
        {
            WedSoulHue.Instance.Cramp();
            return;
        }
        WWWForm wwwForm = new WWWForm();
        wwwForm.AddField("gameCode", RoomTeam);
        wwwForm.AddField("userId", CellIraqGrecian.GetString(CWinter.Or_RoundInformAt));
        //Debug.Log("userId:" + CellIraqGrecian.GetString(CWinter.sv_LocalServerId));
        wwwForm.AddField("version", version);
        //Debug.Log("version:" + version);
        wwwForm.AddField("channel", Terrain);
        //Debug.Log("channel:" + channal);
        wwwForm.AddField("operateId", event_id);
        //print("打点 事件ID:" + event_id + "   参数1:" + p1 + "   参数2:" + p2 + "   参数3:" + p3);


        if (p1 != null)
        {
            wwwForm.AddField("params1", p1);
        }
        if (p2 != null)
        {
            wwwForm.AddField("params2", p2);
        }
        if (p3 != null)
        {
            wwwForm.AddField("params3", p3);
        }
        StartCoroutine(VastSash(WedSoulHue.Instance.SakeThe + "/api/client/log", wwwForm,
        (error) =>
        {
            Debug.Log(error);
        },
        (message) =>
        {
            //Debug.Log(message);
        }));
    }
    IEnumerator VastSash(string _url, WWWForm wwwForm, Action<string> fail, Action<string> success)
    {
        //Debug.Log(SerializeDictionaryToJsonString(dic));
        using UnityWebRequest request = UnityWebRequest.Post(_url, wwwForm);
        yield return request.SendWebRequest();
        if (request.isNetworkError || request.isNetworkError)
        {
            fail(request.error);
            endCapsize();
            request.Dispose();
        }
        else
        {
            success(request.downloadHandler.text);
            endCapsize();
            request.Dispose();
        }
    }
    private void endCapsize()
    {
        StopCoroutine(nameof(VastSash));
    }


}