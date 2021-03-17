using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField]
    private float m_TimeBeforeNextFire = 3;

    [SerializeField]
    private GameObject m_BulletEnemy = null;

    [SerializeField]
    private Transform m_Canon = null;

    private float m_CurrentTimeBeforeNextFire = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    public void Shoot()
    {
        if(m_CurrentTimeBeforeNextFire <= m_TimeBeforeNextFire)
        {
            m_CurrentTimeBeforeNextFire += Time.deltaTime;
        }
        else
        {
            Instantiate(m_BulletEnemy, m_Canon.position, Quaternion.identity);
            m_CurrentTimeBeforeNextFire = 0;
        }
    }
}
