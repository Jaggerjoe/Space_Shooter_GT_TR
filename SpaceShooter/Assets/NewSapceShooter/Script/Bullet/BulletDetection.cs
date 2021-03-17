using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDetection : MonoBehaviour
{
    [SerializeField]
    private int m_Damages = 1;

    [SerializeField]
    private float m_Radius = .5f;

    [SerializeField]
    private LayerMask m_Layer = 0;

    private Enemy m_Enemy = null;

    private HealthPlayer m_PlayerLife = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SetDamages(m_Damages);
    }

    private void SetDamages(int p_Damages)
    {
        Collider[] l_HitCollider = Physics.OverlapSphere(transform.position, m_Radius, m_Layer);
        foreach (var item in l_HitCollider)
        {
            if(item.GetComponent<Enemy>() != null)
            {
                m_Enemy = item.GetComponent<Enemy>();
                m_Enemy.TakeDamages(p_Damages);
                Destroy(gameObject);
            }

            if(item.GetComponent<HealthPlayer>() != null)
            {
                m_PlayerLife = item.GetComponent<HealthPlayer>();
                m_PlayerLife.TakesDamages(p_Damages);
                Destroy(gameObject);
            }

            Debug.Log("j'ai touché : " + item.gameObject.name);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, m_Radius);
    }
}
