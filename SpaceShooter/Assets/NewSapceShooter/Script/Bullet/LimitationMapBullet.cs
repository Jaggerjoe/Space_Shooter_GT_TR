using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitationMapBullet : MonoBehaviour
{
    [SerializeField]
    private AreaPlay m_AreaGame = null;

    // Start is called before the first frame update
    void Start()
    {
        m_AreaGame = FindObjectOfType<AreaPlay>();
    }

    // Update is called once per frame
    void Update()
    {
        DestroyBulletOutOfRange();
    }
    public void DestroyBulletOutOfRange()
    {
        //Destruction de la balles si elle sort de l'ecran de jeu, a l'extremite gauche et extremite droite.
        if (transform.position.x < m_AreaGame.ScreenBound.x / -2)
        {
            Destroy(gameObject);
        }
        if (transform.position.x > (m_AreaGame.ScreenBound.x) / 2)
        {
            Destroy(gameObject);
        }
    }
}
