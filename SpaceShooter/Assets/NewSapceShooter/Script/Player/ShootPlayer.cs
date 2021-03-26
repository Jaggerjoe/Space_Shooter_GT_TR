using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerCanon
{
    public int bonusNumberNeeded = 1;
    public Transform[] canon;
}
public class ShootPlayer : MonoBehaviour
{
    [SerializeField][Header("InputManager")][Space(20)]
    private SO_PlayerController m_Controller = null;

    //PlayerCanon
    [SerializeField]
    private PlayerCanon[] m_PlayerCanon = null;

    [Header("Element pour le tir du joueur")][SerializeField][Space(20)]
    private int m_NumberOfBonus = 0;

    [SerializeField]
    private float m_FireRate = 1;

    [SerializeField]
    private GameObject PlayerBullet = null;


    private float m_PlayerLaser;
    private float m_PlayerFireRate = 0;
    public float m_ShootingPlayer = 0;

    // Update is called once per frame
    void Update()
    {
        Shoot(m_Controller.ShootPlayer);   
    }

    private void Shoot(bool _FiraRate)
    {
        m_PlayerFireRate += Time.deltaTime;
        if (_FiraRate)
        {
            if (m_PlayerFireRate >= m_FireRate)
            {

                //Mise de l'index de la liste a 0 du nombre de canon du player
                PlayerCanon IndexOfBinus = m_PlayerCanon[0];
                //Boucle pour selectionné quel canon va tiré en fonction des bonus récupérer
                foreach (PlayerCanon item in m_PlayerCanon)
                {
                    if (m_NumberOfBonus >= item.bonusNumberNeeded)
                    {
                        IndexOfBinus = item;
                    }
                    else
                    {
                        break;
                    }
                }

                //création de l'instance de la bullet au moment du tir du joueur
                foreach (Transform item in IndexOfBinus.canon)
                {
                    Instantiate(PlayerBullet, item.position, item.rotation);
                    //Creation d'une liste pour randomisé les sons du tir
                    //m_EventPlayer.OnShoot.Invoke();
                }
                m_PlayerFireRate = 0;
                //Récuperation de l'audio manager
                //FindObjectOfType<AudioManager>().PlayerSound();
            }
        }
    }
}
