using System.Collections;
using System.Collections.Generic;
using Coffee.UIExtensions;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

/// <summary>  </summary>
public class Hole : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("NormalTail")]    public UIParticle MatrixFirm; //拖尾
[UnityEngine.Serialization.FormerlySerializedAs("FerverTail")]    public UIParticle UpholdFirm; //疯狂模式拖尾
    bool CutChopEnzymeSymptom= true; // 是否可以过翻倍机
    bool OnNetFiord; // 是否是顶部进入
    Collider2D EnzymeSymptomConsider; // 翻倍机的碰撞体
[UnityEngine.Serialization.FormerlySerializedAs("Rig")]    public Rigidbody2D Due;
[UnityEngine.Serialization.FormerlySerializedAs("BallImage")]    public Image HoleStorm;
[UnityEngine.Serialization.FormerlySerializedAs("BounceBallIcon")]    public GameObject BackupHoleDarn; // 弹力球图标
[UnityEngine.Serialization.FormerlySerializedAs("BallCollider")]    public CircleCollider2D HoleConsider; // 球的碰撞体
[UnityEngine.Serialization.FormerlySerializedAs("NormalMaterial")]    public PhysicsMaterial2D MatrixRotation; // 正常物理材质
[UnityEngine.Serialization.FormerlySerializedAs("BounceMaterial")]    public PhysicsMaterial2D BackupRotation; // 弹力物理材质


    private void OnEnable()
    {
        MatrixFirm.gameObject.SetActive(!RoomCigar.Instance.OnWhaleTall);
        UpholdFirm.gameObject.SetActive(RoomCigar.Instance.OnWhaleTall);
        if (RoomCigar.Instance.OnWhaleTall)
        {
            HoleStorm.color = Color.yellow;
            UpholdFirm.StartEmission();
        }
        else
            HoleStorm.color = Color.white;
        Due.isKinematic = false;
        Due.simulated = true;
        // 生成后过一段时间才允许触发翻倍机 防止新生成的球再次触发翻倍机
        CutChopEnzymeSymptom = false;
        PestGrecian.AshForecast().Novel_SoloBeach(0.1f, () =>
        {
            CutChopEnzymeSymptom = true;
        });
    }

    public void GelBackup()
    {
        HoleConsider.sharedMaterial = BackupRotation;
        BackupHoleDarn.SetActive(true);
    }

    private void FixedUpdate()
    {
        if (transform.localPosition.y < -1200)
            SymbolGoBias();

        if (Due.velocity.magnitude > GameConfig.Instance.BallSpeed_ShowTrail)
        {
            if (!RoomCigar.Instance.OnWhaleTall)
                MatrixFirm.StartEmission();
        }
        else
        {
            MatrixFirm.StopEmission();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("物体"))
        {
            other.transform.parent.GetComponent<Home>().Hot(1, BackupHoleDarn.activeSelf);
        }
        else if (other.transform.name == "疯狂宝箱")
        {
            RoomCigar.Instance.WhaleAnglePit();
            ShootHue.AshForecast().NormTraffic(Lofelt.NiceVibrations.HapticPatterns.PresetType.MediumImpact);
            ShootHue.AshForecast().NormButton(ShootMuch.UIMusic.strike_right);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.name == "黑洞")
        {
            BreedRanch();
            transform.DOMove(other.transform.position, .3f).SetEase(Ease.InBack).OnComplete(() =>
            {
                if (!PestGrecian.AshForecast().OnBeach)
                {
                    RoomCigar.Instance.CargoMuchPit();
                    ShootHue.AshForecast().NormButton(ShootMuch.UIMusic.ball_hole);
                }
                SymbolGoBias();
            });

        }
        else if (other.transform.name == "黑洞引力")
        {
            Vector2 Force = (other.transform.position - transform.position).normalized * 10;
            Due.AddForce(Force, ForceMode2D.Impulse);
        }
        else if (CutChopEnzymeSymptom && other.transform.name == "翻倍机")
        {
            EnzymeSymptomConsider = other;
            if (transform.position.y > EnzymeSymptomConsider.transform.position.y)
                OnNetFiord = true;
            else
                OnNetFiord = false;
        }
        else if (other.transform.name == "收集器")
        {
            other.transform.GetComponent<Circulate>().Methane();
            SymbolGoBias();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (EnzymeSymptomConsider != null && other == EnzymeSymptomConsider)
        {
            if (OnNetFiord && transform.position.y < EnzymeSymptomConsider.transform.position.y)
                EnzymeSymptomConsider.GetComponent<EnzymeSymptom>().ChopTestify();
            EnzymeSymptomConsider = null;
            OnNetFiord = false;
        }
    }

    void SymbolGoBias()
    {
        BreedRanch();
        ObjectPool.Instance.Return("球", gameObject);
    }

    void BreedRanch() // 清除状态 不参与交互    
    {
        Due.isKinematic = true;
        Due.simulated = false;
        Due.velocity = Vector2.zero;
        EnzymeSymptomConsider = null;
        OnNetFiord = false;
        CutChopEnzymeSymptom = false;
        HoleConsider.sharedMaterial = MatrixRotation;
        BackupHoleDarn.SetActive(false);
    }
}
