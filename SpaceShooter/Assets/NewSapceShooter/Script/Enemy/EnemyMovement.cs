using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    //private Vector3 m_MyPosition;
    private AreaPlay m_Bounds = null;
    [SerializeField]
    private List<Vector3> m_MyPositions = new List<Vector3>();
    private int wayPoint = 0;

    private void Awake()
    {
        m_Bounds = FindObjectOfType<AreaPlay>();
    }

    private void Start()
    {
        GetPoint();
    }

    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        //Deplacement en ligne droite du vaisceux
        transform.position = Vector3.MoveTowards(transform.position, m_MyPositions[wayPoint], 5 * Time.deltaTime);
        if (transform.position == m_MyPositions[wayPoint])
        {
            wayPoint++;
        }
    }

    public void GetPoint()
    {
        m_MyPositions[0] = transform.position;

        for (int i = 1; i < m_MyPositions.Count; i++)
        {
            float l_RandomY = Random.Range(-10, 10);
            m_MyPositions[i] = m_MyPositions[i - 1] + new Vector3(-10, l_RandomY, 0);
            while (-m_MyPositions[i].y > (m_Bounds.ScreenBound.y) / 2)
            {
                float rd = Random.Range(-10, 10);
                m_MyPositions[i] = m_MyPositions[i - 1] + new Vector3(-10, rd, 0);
            }

            while (m_MyPositions[i].y > (m_Bounds.ScreenBound.y) / 2)
            {
                float rd = Random.Range(-10, 10);
                m_MyPositions[i] = m_MyPositions[i - 1] + new Vector3(-10, rd, 0);
            }
        }
    }

    //private void CreationBaliseDeplacement()
    //{
    //    float l_RandomY = Random.Range(-10, 10);
    //    m_MyPosition = transform.position + new Vector3(-10, l_RandomY, 0);
    //    if (m_MyPosition.y > (m_Bounds.ScreenBound.y) / 2)
    //    {
    //        CreationBaliseDeplacement();
    //    }
    //    if (-m_MyPosition.y > (m_Bounds.ScreenBound.y) / 2)
    //    {
    //        CreationBaliseDeplacement();
    //    }
    //}

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(m_MyPositions[wayPoint], .5f);
    }
}
