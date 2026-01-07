using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 消息传递的参数
/// </summary>
public class BoxlikeIraq
{
    /*
     *  1.创建独立的消息传递数据结构，而不使用object，是为了避免数据传递时的类型强转
     *  2.制作过程中遇到实际需要传递的数据类型，在这里定义即可
     *  3.实际项目中需要传递参数的类型其实并没有很多种，这种方式基本可以满足需求
     */
    public bool ShoreAcre;
    public bool ShoreAcre2;
    public int ShoreInn;
    public int ShoreInn2;
    public int ShoreInn3;
    public float ShoreWrong;
    public float ShoreWrong2;
    public double ShoreEnzyme;
    public double ShoreEnzyme2;
    public string ShoreUnlike;
    public string ShoreUnlike2;
    public GameObject ShoreRoomRender;
    public GameObject ShoreRoomRender2;
    public GameObject ShoreRoomRender3;
    public GameObject ShoreRoomRender4;
    public Transform ShoreFolkloric;
    public List<string> ShoreUnlikeRent;
    public List<Vector2> ShoreElk2Rent;
    public List<int> ShoreInnRent;
    public System.Action SpecifyThatTour;
    public Vector2 Ill2_1;
    public Vector2 Ill2_2;
    public BoxlikeIraq()
    {
    }
    public BoxlikeIraq(Vector2 v2_1)
    {
        Ill2_1 = v2_1;
    }
    public BoxlikeIraq(Vector2 v2_1, Vector2 v2_2)
    {
        Ill2_1 = v2_1;
        Ill2_2 = v2_2;
    }
    /// <summary>
    /// 创建一个带bool类型的数据
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public BoxlikeIraq(bool value)
    {
        ShoreAcre = value;
    }
    public BoxlikeIraq(bool value, bool value2)
    {
        ShoreAcre = value;
        ShoreAcre2 = value2;
    }
    /// <summary>
    /// 创建一个带int类型的数据
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public BoxlikeIraq(int value)
    {
        ShoreInn = value;
    }
    public BoxlikeIraq(int value, int value2)
    {
        ShoreInn = value;
        ShoreInn2 = value2;
    }
    public BoxlikeIraq(int value, int value2, int value3)
    {
        ShoreInn = value;
        ShoreInn2 = value2;
        ShoreInn3 = value3;
    }
    public BoxlikeIraq(List<int> value,List<Vector2> value2)
    {
        ShoreInnRent = value;
        ShoreElk2Rent = value2;
    }
    /// <summary>
    /// 创建一个带float类型的数据
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public BoxlikeIraq(float value)
    {
        ShoreWrong = value;
    }
    public BoxlikeIraq(float value,float value2)
    {
        ShoreWrong = value;
        ShoreWrong = value2;
    }
    /// <summary>
    /// 创建一个带double类型的数据
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public BoxlikeIraq(double value)
    {
        ShoreEnzyme = value;
    }
    public BoxlikeIraq(double value, double value2)
    {
        ShoreEnzyme = value;
        ShoreEnzyme = value2;
    }
    /// <summary>
    /// 创建一个带string类型的数据
    /// </summary>
    /// <param name="value"></param>
    public BoxlikeIraq(string value)
    {
        ShoreUnlike = value;
    }
    /// <summary>
    /// 创建两个带string类型的数据
    /// </summary>
    /// <param name="value1"></param>
    /// <param name="value2"></param>
    public BoxlikeIraq(string value1,string value2)
    {
        ShoreUnlike = value1;
        ShoreUnlike2 = value2;
    }
    public BoxlikeIraq(GameObject value1)
    {
        ShoreRoomRender = value1;
    }

    public BoxlikeIraq(Transform transform)
    {
        ShoreFolkloric = transform;
    }
}

