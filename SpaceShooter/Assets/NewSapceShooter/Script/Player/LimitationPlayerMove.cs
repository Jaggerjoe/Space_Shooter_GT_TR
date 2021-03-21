using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitationPlayerMove : MonoBehaviour
{
    [SerializeField]
    private AreaPlay m_GameManag;

    // Start is called before the first frame update
    void Start()
    {
        m_GameManag = FindObjectOfType<AreaPlay>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerLimiteMap();
    }

    public void PlayerLimiteMap()
    {
        //on limite le deplacemnt du joueur a la zone crée.
        if (transform.position.x > (m_GameManag.ScreenBound.x) / 2)
        {
            transform.position = new Vector2((m_GameManag.ScreenBound.x) / 2, transform.position.y);
        }
        if (transform.position.x < -(m_GameManag.ScreenBound.x) / 2)
        {
            transform.position = new Vector2(-(m_GameManag.ScreenBound.x) / 2, transform.position.y);
        }
        if (transform.position.y < -(m_GameManag.ScreenBound.y) / 2)
        {
            transform.position = new Vector2(transform.position.x, -(m_GameManag.ScreenBound.y) / 2);
        }
        if (transform.position.y > (m_GameManag.ScreenBound.y) / 2)
        {
            transform.position = new Vector2(transform.position.x, (m_GameManag.ScreenBound.y) / 2);
        }
    }
}
