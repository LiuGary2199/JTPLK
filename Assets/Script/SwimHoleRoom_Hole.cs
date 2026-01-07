using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary> 掉球游戏的球 </summary>
public class SwimHoleRoom_Hole : MonoBehaviour
{
    bool CutChopEnzymeSymptom= true; // 是否可以过翻倍机
    bool OnNetFiord; // 是否是顶部进入
    Collider2D EnzymeSymptomConsider; // 翻倍机的碰撞体
    Rigidbody2D Due;


    private void OnEnable()
    {
        if (Due == null)
            Due = GetComponent<Rigidbody2D>();
        // 生成后过一段时间才允许触发翻倍机 防止新生成的球再次触发翻倍机
        CutChopEnzymeSymptom = false;
        PestGrecian.AshForecast().Novel_SoloBeach(0.1f, () =>
        {
            CutChopEnzymeSymptom = true;
        });
    }

    private void FixedUpdate()
    {
        if (transform.localPosition.y < -1200)
            SymbolHoleSkyFrayOat();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.name == "弹板")
        {
            Vector2 Force = Vector2.up * GameConfig.Instance.DropBallBouncePower;
            Due.AddForce(Force, ForceMode2D.Impulse);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (CutChopEnzymeSymptom)
        {
            if (other.transform.name == "翻倍机")
            {
                EnzymeSymptomConsider = other;
                if (transform.position.y > EnzymeSymptomConsider.transform.position.y)
                    OnNetFiord = true;
                else
                    OnNetFiord = false;
            }
        }
        if (other.transform.name == "锁")
        {
            SwimHoleRoomCigar.Instance.PostPit();
            SymbolHoleSkyFrayOat();
            ShootHue.AshForecast().NormTraffic(Lofelt.NiceVibrations.HapticPatterns.PresetType.LightImpact);
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

    void SymbolHoleSkyFrayOat()
    {
        ObjectPool.Instance.Return("松爪掉球_球", gameObject);
        SwimHoleRoomCigar.Instance.FrayNetHole();
        EnzymeSymptomConsider = null;
        OnNetFiord = false;
        CutChopEnzymeSymptom = false;
    }
}
