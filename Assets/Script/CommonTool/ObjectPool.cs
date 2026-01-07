using System.Collections.Generic;
using UnityEngine;

/// <summary> 对象池 </summary>
public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance; // 单例
    public NameAndPrefab[] Prefabs; // 公开的预制体数组 在监视面板填写名称和对应预制体
    private Dictionary<string, Queue<GameObject>> pool = new Dictionary<string, Queue<GameObject>>();

    private void Awake()
    {
        Instance = this;

        // 初始化对象池
        foreach (var item in Prefabs)
        {
            if (!pool.ContainsKey(item.Name))
            {
                pool[item.Name] = new Queue<GameObject>();
            }
        }
    }

    /// <summary> 从对象池中取出预制体 </summary>
    public GameObject Get(string Name)
    {
        if (pool.ContainsKey(Name) && pool[Name].Count > 0)
        {
            GameObject Obj = pool[Name].Dequeue();
            Obj.SetActive(true);
            return Obj;
        }
        else
        {
            // 如果对象池中没有可用的预制体，则实例化一个新的预制体
            foreach (var Item in Prefabs)
            {
                if (Item.Name == Name)
                {
                    GameObject Obj = Instantiate(Item.Prefab);
                    return Obj;
                }
            }
        }
        Debug.LogError("找不到名称为 " + Name + " 的预制体");
        return null;
    }

    /// <summary> 将预制体放回对象池中 </summary>
    public void Return(string Name, GameObject Obj)
    {
        Obj.SetActive(false);
        Obj.transform.position = Vector3.one * 10000; //把对象移到摄像机范围外
        if (pool.ContainsKey(Name))
            pool[Name].Enqueue(Obj);
        else
        {
            Destroy(Obj);
            Debug.LogWarning("尝试放回未在对象池中定义的预制体");
        }
    }
}

[System.Serializable]
public class NameAndPrefab
{
    public string Name;
    public GameObject Prefab;
}
