using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaPlay : MonoBehaviour
{
    [SerializeField]
    private Vector2 m_ScreenBouds;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(transform.position, m_ScreenBouds);
    }

    public Vector2 ScreenBound
    {
        get { return m_ScreenBouds; }
        set { m_ScreenBouds = value; }
    }
}
