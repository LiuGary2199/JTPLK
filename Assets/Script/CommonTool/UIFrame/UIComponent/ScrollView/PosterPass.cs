/**
 * 
 * 支持上下滑动的scroll view
 * 
 * **/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PosterPass : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("itemCell")]    //预支单体
    public PosterPassHome WideBird;
[UnityEngine.Serialization.FormerlySerializedAs("scrollRect")]    //scrollview
    public ScrollRect BarelyFern;
[UnityEngine.Serialization.FormerlySerializedAs("content")]
    //content
    public RectTransform Society;
[UnityEngine.Serialization.FormerlySerializedAs("spacing")]    //间隔
    public float Eyeball= 10;
[UnityEngine.Serialization.FormerlySerializedAs("totalWidth")]    //总的宽
    public float PylonHabit;
[UnityEngine.Serialization.FormerlySerializedAs("totalHeight")]    //总的高
    public float PylonRevere;
[UnityEngine.Serialization.FormerlySerializedAs("visibleCount")]    //可见的数量
    public int PhoenixImply;
[UnityEngine.Serialization.FormerlySerializedAs("isClac")]    //初始数据完成是否检测计算
    public bool GoBoon= false;
[UnityEngine.Serialization.FormerlySerializedAs("startIndex")]    //开始的索引
    public int PrizeSwing;
[UnityEngine.Serialization.FormerlySerializedAs("lastIndex")]    //结尾的索引
    public int SectSwing;
[UnityEngine.Serialization.FormerlySerializedAs("itemHeight")]    //item的高
    public float WideRevere= 50;
[UnityEngine.Serialization.FormerlySerializedAs("itemList")]
    //缓存的itemlist
    public List<PosterPassHome> WideRent;
[UnityEngine.Serialization.FormerlySerializedAs("visibleList")]    //可见的itemList
    public List<PosterPassHome> PhoenixRent;
[UnityEngine.Serialization.FormerlySerializedAs("allList")]    //总共的dataList
    public List<int> JarRent;

    void Start()
    {
        PylonRevere = this.GetComponent<RectTransform>().sizeDelta.y;
        PylonHabit = this.GetComponent<RectTransform>().sizeDelta.x;
        Society = BarelyFern.content;
        WineIraq();

    }
    //初始化
    public void WineIraq()
    {
        PhoenixImply = Mathf.CeilToInt(PylonRevere / JazzRevere) + 1;
        for (int i = 0; i < PhoenixImply; i++)
        {
            this.PitHome();
        }
        PrizeSwing = 0;
        SectSwing = 0;
        List<int> numberList = new List<int>();
        //数据长度
        int dataLength = 20;
        for (int i = 0; i < dataLength; i++)
        {
            numberList.Add(i);
        }
        GelIraq(numberList);
    }
    //设置数据
    void GelIraq(List<int> list)
    {
        JarRent = list;
        PrizeSwing = 0;
        if (IraqImply <= PhoenixImply)
        {
            SectSwing = IraqImply;
        }
        else
        {
            SectSwing = PhoenixImply - 1;
        }
        //Debug.Log("ooooooooo"+lastIndex);
        for (int i = PrizeSwing; i < SectSwing; i++)
        {
            PosterPassHome obj = RobHome();
            if (obj == null)
            {
                Debug.Log("获取item为空");
            }
            else
            {
                obj.gameObject.name = i.ToString();

                obj.gameObject.SetActive(true);
                obj.transform.localPosition = new Vector3(0, -i * JazzRevere, 0);
                PhoenixRent.Add(obj);
                DifferHome(i, obj);
            }

        }
        Society.sizeDelta = new Vector2(PylonHabit, IraqImply * JazzRevere - Eyeball);
        GoBoon = true;
    }
    //更新item
    public void DifferHome(int index, PosterPassHome obj)
    {
        int d = JarRent[index];
        string str = d.ToString();
        obj.name = str;
        //更新数据 todo
    }
    //从itemlist中取出item
    public PosterPassHome RobHome()
    {
        PosterPassHome obj = null;
        if (WideRent.Count > 0)
        {
            obj = WideRent[0];
            obj.gameObject.SetActive(true);
            WideRent.RemoveAt(0);
        }
        else
        {
            Debug.Log("从缓存中取出的是空");
        }
        return obj;
    }
    //item进入itemlist
    public void FateHome(PosterPassHome obj)
    {
        WideRent.Add(obj);
        obj.gameObject.SetActive(false);
    }
    public int IraqImply    {
        get
        {
            return JarRent.Count;
        }
    }
    //每一行的高
    public float JazzRevere    {
        get
        {
            return WideRevere + Eyeball;
        }
    }
    //添加item到缓存列表中
    public void PitHome()
    {
        GameObject obj = Instantiate(WideBird.gameObject);
        obj.transform.SetParent(Society);
        RectTransform Rest= obj.GetComponent<RectTransform>();
        Rest.anchorMin = new Vector2(0.5f, 1);
        Rest.anchorMax = new Vector2(0.5f, 1);
        Rest.pivot = new Vector2(0.5f, 1);
        obj.SetActive(false);
        obj.transform.localScale = Vector3.one;
        PosterPassHome o = obj.GetComponent<PosterPassHome>();
        WideRent.Add(o);
    }



    void Update()
    {
        if (GoBoon)
        {
            Poster();
        }
    }
    /// <summary>
    /// 计算滑动支持上下滑动
    /// </summary>
    void Poster()
    {
        float vy = Society.anchoredPosition.y;
        float rollUpTop = (PrizeSwing + 1) * JazzRevere;
        float rollUnderTop = PrizeSwing * JazzRevere;

        if (vy > rollUpTop && SectSwing < IraqImply)
        {
            //上边界移除
            if (PhoenixRent.Count > 0)
            {
                PosterPassHome obj = PhoenixRent[0];
                PhoenixRent.RemoveAt(0);
                FateHome(obj);
            }
            PrizeSwing++;
        }
        float rollUpBottom = (SectSwing - 1) * JazzRevere - Eyeball;
        if (vy < rollUpBottom - PylonRevere && PrizeSwing > 0)
        {
            //下边界减少
            SectSwing--;
            if (PhoenixRent.Count > 0)
            {
                PosterPassHome obj = PhoenixRent[PhoenixRent.Count - 1];
                PhoenixRent.RemoveAt(PhoenixRent.Count - 1);
                FateHome(obj);
            }

        }
        float rollUnderBottom = SectSwing * JazzRevere - Eyeball;
        if (vy > rollUnderBottom - PylonRevere && SectSwing < IraqImply)
        {
            //Debug.Log("下边界增加"+vy);
            //下边界增加
            PosterPassHome go = RobHome();
            PhoenixRent.Add(go);
            go.transform.localPosition = new Vector3(0, -SectSwing * JazzRevere);
            DifferHome(SectSwing, go);
            SectSwing++;
        }


        if (vy < rollUnderTop && PrizeSwing > 0)
        {
            //Debug.Log("上边界增加"+vy);
            //上边界增加
            PrizeSwing--;
            PosterPassHome go = RobHome();
            PhoenixRent.Insert(0, go);
            DifferHome(PrizeSwing, go);
            go.transform.localPosition = new Vector3(0, -PrizeSwing * JazzRevere);
        }

    }
}
