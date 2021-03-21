using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float m_Life = 3;
    
    private AreaPlay m_AreaGame = null;

    // Start is called before the first frame update
    void Start()
    {
        m_AreaGame = FindObjectOfType<AreaPlay>();
    }

    // Update is called once per frame
    void Update()
    {
        LimitationMap();
    }

    public void TakeDamages(int p_Damages)
    {
        m_Life -= p_Damages;
        if(m_Life <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    private void LimitationMap()
    {
        if (transform.position.x < m_AreaGame.ScreenBound.x / -1.5f)
        {
            Die();
        }
    }
}
