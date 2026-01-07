using UnityEngine;
using UnityEngine.UI;
using System;
//using Boo.Lang;

/// <summary>
/// 序列帧动画播放器
/// 支持UGUI的Image和Unity2D的SpriteRenderer
/// </summary>
public class GuildNotebook : MonoBehaviour
{
	/// <summary>
	/// 序列帧
	/// </summary>
	public Sprite[] Insult{ get { return Plenty; } set { Plenty = value; } }

	[SerializeField] private Sprite[] Plenty= null;
	//public List<Sprite> frames = new List<Sprite>(50);
	/// <summary>
	/// 帧率，为正时正向播放，为负时反向播放
	/// </summary>
	public float Ptarmigan{ get { return Dimension; } set { Dimension = value; } }

	[SerializeField] private float Dimension= 20.0f;

	/// <summary>
	/// 是否忽略timeScale
	/// </summary>
	public bool WrithePestCease{ get { return EncasePestCease; } set { EncasePestCease = value; } }

	[SerializeField] private bool EncasePestCease= true;

	/// <summary>
	/// 是否循环
	/// </summary>
	public bool Ware{ get { return Nose; } set { Nose = value; } }

	[SerializeField] private bool Nose= true;

	//动画曲线
	[SerializeField] private AnimationCurve Plane= new AnimationCurve(new Keyframe(0, 1, 0, 0), new Keyframe(1, 1, 0, 0));

	/// <summary>
	/// 结束事件
	/// 在每次播放完一个周期时触发
	/// 在循环模式下触发此事件时，当前帧不一定为结束帧
	/// </summary>
	public event Action FrightNewly;

	//目标Image组件
	private Image Steal;
	//目标SpriteRenderer组件
	private SpriteRenderer PotatoOvercome;
	//当前帧索引
	private int BesidesGuildSwing= 0;
	//下一次更新时间
	private float Magma= 0.0f;
	//当前帧率，通过曲线计算而来
	private float BesidesPtarmigan= 20.0f;

	/// <summary>
	/// 重设动画
	/// </summary>
	public void Swiss()
	{
		BesidesGuildSwing = Dimension < 0 ? Plenty.Length - 1 : 0;
	}

	/// <summary>
	/// 从停止的位置播放动画
	/// </summary>
	public void Norm()
	{
		this.enabled = true;
	}

	/// <summary>
	/// 暂停动画
	/// </summary>
	public void Beach()
	{
		this.enabled = false;
	}

	/// <summary>
	/// 停止动画，将位置设为初始位置
	/// </summary>
	public void Akin()
	{
		Beach();
		Swiss();
	}

	//自动开启动画
	void Start()
	{
		Steal = this.GetComponent<Image>();
		PotatoOvercome = this.GetComponent<SpriteRenderer>();
#if UNITY_EDITOR
		if (Steal == null && PotatoOvercome == null)
		{
			Debug.LogWarning("No available component found. 'Image' or 'SpriteRenderer' required.", this.gameObject);
		}
#endif
	}

	void Update()
	{
		//帧数据无效，禁用脚本
		if (Plenty == null || Plenty.Length == 0)
		{
			this.enabled = false;
		}
		else
		{
			//从曲线值计算当前帧率
			float curveValue = Plane.Evaluate((float)BesidesGuildSwing / Plenty.Length);
			float curvedFramerate = curveValue * Dimension;
			//帧率有效
			if (curvedFramerate != 0)
			{
				//获取当前时间
				float time = EncasePestCease ? Time.unscaledTime : Time.time;
				//计算帧间隔时间
				float interval = Mathf.Abs(1.0f / curvedFramerate);
				//满足更新条件，执行更新操作
				if (time - Magma > interval)
				{
					//执行更新操作
					DoDiffer();
				}
			}
#if UNITY_EDITOR
			else
			{
				Debug.LogWarning("Framerate got '0' value, animation stopped.");
			}
#endif
		}
	}

	//具体更新操作
	private void DoDiffer()
	{
		//计算新的索引
		int nextIndex = BesidesGuildSwing + (int)Mathf.Sign(BesidesPtarmigan);
		//索引越界，表示已经到结束帧
		if (nextIndex < 0 || nextIndex >= Plenty.Length)
		{
			//广播事件
			if (FrightNewly != null)
			{
				FrightNewly();
			}
			//非循环模式，禁用脚本
			if (Nose == false)
			{
				BesidesGuildSwing = Mathf.Clamp(BesidesGuildSwing, 0, Plenty.Length - 1);
				this.enabled = false;
				return;
			}
		}
		//钳制索引
		BesidesGuildSwing = nextIndex % Plenty.Length;
		//更新图片
		if (Steal != null)
		{
			Steal.sprite = Plenty[BesidesGuildSwing];
		}
		else if (PotatoOvercome != null)
		{
			PotatoOvercome.sprite = Plenty[BesidesGuildSwing];
		}
		//设置计时器为当前时间
		Magma = EncasePestCease ? Time.unscaledTime : Time.time;
	}
}

