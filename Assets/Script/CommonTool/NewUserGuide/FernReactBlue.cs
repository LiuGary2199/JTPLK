using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

/// <summary>
/// 矩形遮罩镂空
/// </summary>
public class FernReactBlue : MonoBehaviour
{
    public static FernReactBlue instance;
[UnityEngine.Serialization.FormerlySerializedAs("Hand")]    public GameObject Also;

    /// <summary>
    /// 高亮显示目标
    /// </summary>
    private GameObject Studio;
[UnityEngine.Serialization.FormerlySerializedAs("Text")]
    public Text Drug;
    /// <summary>
    /// 区域范围缓存
    /// </summary>
    private Vector3[] License= new Vector3[4];
    /// <summary>
    /// 镂空区域中心
    /// </summary>
    private Vector4 Spinal;
    /// <summary>
    /// 最终的偏移x
    /// </summary>
    private float StudioRadiumX= 0;
    /// <summary>
    /// 最终的偏移y
    /// </summary>
    private float StudioRadiumY= 0;
    /// <summary>
    /// 遮罩材质
    /// </summary>
    private Material Quantify;
    /// <summary>
    /// 当前的偏移x
    /// </summary>
    private float BesidesRadiumX= 0f;
    /// <summary>
    /// 当前的偏移y
    /// </summary>
    private float BesidesRadiumY= 0f;
    /// <summary>
    /// 高亮区域缩放的动画时间
    /// </summary>
    private float PaddlePest= 0.1f;
    /// <summary>
    /// 事件渗透组件
    /// </summary>
    private SargeantNewlyInspector MaybeInspector;

    private void Awake()
    {
        instance = this;
    }


    /// <summary>
    /// 显示引导遮罩
    /// </summary>
    /// <param name="_target">要引导到的目标对象</param>
    /// <param name="text">引导说明文案</param>

    public void EvenReact(GameObject _target, string text)
    {
        gameObject.SetActive(true);

        if (_target == null)
        {
            Also.SetActive(false);
            if (Quantify == null)
            {
                Quantify = GetComponent<Image>().material;
            }
            Quantify.SetVector("_Center", new Vector4(0, 0, 0, 0));
            Quantify.SetFloat("_SliderX", 0);
            Quantify.SetFloat("_SliderY", 0);
            // 如果没有target，点击任意区域关闭引导
            GetComponent<Button>().onClick.AddListener(() =>
            {
                gameObject.SetActive(false);
            });
        }
        else
        {
            DOTween.Kill("NewUserHandAnimation");
            Wine(_target);
            GetComponent<Button>().onClick.RemoveAllListeners();
        }

        if (!string.IsNullOrEmpty(text))
        {
            Drug.text = text;
            Drug.transform.parent.gameObject.SetActive(true);
        }
        else
        {
            Drug.transform.parent.gameObject.SetActive(false);
        }
    }


    public void Wine(GameObject _target)
    {
        this.Studio = _target;
        
        MaybeInspector = GetComponent<SargeantNewlyInspector>();
        if (MaybeInspector != null)
        {
            MaybeInspector.GelAthensStorm(_target.GetComponent<Image>());
        }

        Canvas canvas = UIGrecian.AshForecast().MainEnsure.GetComponent<Canvas>();

        //获取高亮区域的四个顶点的世界坐标
        if (Studio.GetComponent<RectTransform>() != null)
        {
            Studio.GetComponent<RectTransform>().GetWorldCorners(License);
        }
        else
        {
            Vector3 pos = Camera.main.WorldToScreenPoint(_target.transform.position);
            pos = UIGrecian.AshForecast()._TieUIWeight.GetComponent<Camera>().ScreenToWorldPoint(pos);
            float width = 1;
            float height = 1;
            License[0] = new Vector3(pos.x - width, pos.y - height);
            License[1] = new Vector3(pos.x - width, pos.y + height);
            License[2] = new Vector3(pos.x + width, pos.y + height);
            License[3] = new Vector3(pos.x + width, pos.y - height);
        }
        //计算高亮显示区域在画布中的范围
        StudioRadiumX = Vector2.Distance(FocusGoEnsureTwo(canvas, License[0]), FocusGoEnsureTwo(canvas, License[3])) / 2f;
        StudioRadiumY = Vector2.Distance(FocusGoEnsureTwo(canvas, License[0]), FocusGoEnsureTwo(canvas, License[1])) / 2f;
        //计算高亮显示区域的中心
        float x = License[0].x + ((License[3].x - License[0].x) / 2);
        float y = License[0].y + ((License[1].y - License[0].y) / 2);
        Vector3 centerWorld = new Vector3(x, y, 0);
        Vector2 Spinal= FocusGoEnsureTwo(canvas, centerWorld);
        //设置遮罩材质中的中心变量
        Vector4 centerMat = new Vector4(Spinal.x, Spinal.y, 0, 0);
        Quantify = GetComponent<Image>().material;
        Quantify.SetVector("_Center", centerMat);
        //计算当前高亮显示区域的半径
        RectTransform canRectTransform = canvas.transform as RectTransform;
        if (canRectTransform != null)
        {
            //获取画布区域的四个顶点
            canRectTransform.GetWorldCorners(License);
            //计算偏移初始值
            for (int i = 0; i < License.Length; i++)
            {
                if (i % 2 == 0)
                {
                    BesidesRadiumX = Mathf.Max(Vector3.Distance(FocusGoEnsureTwo(canvas, License[i]), Spinal), BesidesRadiumX);
                }
                else
                {
                    BesidesRadiumY = Mathf.Max(Vector3.Distance(FocusGoEnsureTwo(canvas, License[i]), Spinal), BesidesRadiumY);
                }
            }
        }
        //设置遮罩材质中当前偏移的变量
        Quantify.SetFloat("_SliderX", BesidesRadiumX);
        Quantify.SetFloat("_SliderY", BesidesRadiumY);
        Also.transform.localScale = new Vector3(1, 1, 1);
        StartCoroutine(EvenAlso(Spinal));
    }

    private IEnumerator EvenAlso(Vector2 center)
    {
        Also.SetActive(false);
        yield return new WaitForSeconds(PaddlePest);
        
        Also.transform.localPosition = center;
        AlsoVisualize();
        
        Also.SetActive(true);
    }
    /// <summary>
    /// 收缩速度
    /// </summary>
    private float PaddleEngenderX= 0f;
    private float PaddleEngenderY= 0f;
    private void Update()
    {
        if (Quantify == null) return;

        BesidesRadiumX = StudioRadiumX;
        Quantify.SetFloat("_SliderX", BesidesRadiumX);
        BesidesRadiumY = StudioRadiumY;
        Quantify.SetFloat("_SliderY", BesidesRadiumY);
        //从当前偏移量到目标偏移量差值显示收缩动画
        //float valueX = Mathf.SmoothDamp(currentOffsetX, targetOffsetX, ref shrinkVelocityX, shrinkTime);
        //float valueY = Mathf.SmoothDamp(currentOffsetY, targetOffsetY, ref shrinkVelocityY, shrinkTime);
        //if (!Mathf.Approximately(valueX, currentOffsetX))
        //{
        //    currentOffsetX = valueX;
        //    material.SetFloat("_SliderX", currentOffsetX);
        //}
        //if (!Mathf.Approximately(valueY, currentOffsetY))
        //{
        //    currentOffsetY = valueY;
        //    material.SetFloat("_SliderY", currentOffsetY);
        //}


    }

    /// <summary>
    /// 世界坐标转换为画布坐标
    /// </summary>
    /// <param name="canvas">画布</param>
    /// <param name="world">世界坐标</param>
    /// <returns></returns>
    private Vector2 FocusGoEnsureTwo(Canvas canvas, Vector3 world)
    {
        Vector2 position;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, world, canvas.GetComponent<Camera>(), out position);
        return position;
    }

    public void AlsoVisualize() 
    {
        
        var s = DOTween.Sequence();
        s.Append(Also.transform.DOLocalMoveY(Also.transform.localPosition.y + 10f, 0.5f));
        s.Append(Also.transform.DOLocalMoveY(Also.transform.localPosition.y, 0.5f));
        s.Join(Also.transform.DOScaleY(1.1f, 0.125f));
        s.Join(Also.transform.DOScaleX(0.9f, 0.125f).OnComplete(()=> 
        {
            Also.transform.DOScaleY(0.9f, 0.125f);
            Also.transform.DOScaleX(1.1f, 0.125f).OnComplete(()=> 
            {
                Also.transform.DOScale(1f, 0.125f);
            });
        }));
        s.SetLoops(-1);
        s.SetId("NewUserHandAnimation");
    }

    public void OnDisable()
    {
        DOTween.Kill("NewUserHandAnimation");
    }
}
