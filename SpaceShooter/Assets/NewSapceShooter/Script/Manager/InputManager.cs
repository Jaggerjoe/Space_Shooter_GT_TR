using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    private InputActionAsset Controls = null;
    private InputActionMap m_PlayerMap;

    private MovementPlayer m_PlayerMove;
    private ShootPlayer m_PlayerShoot;

    private void Awake()
    {
        m_PlayerMove = FindObjectOfType<MovementPlayer>();
        m_PlayerShoot = FindObjectOfType<ShootPlayer>();
        //Recuperation des inputs dans l'input manager
        m_PlayerMap = Controls.FindActionMap("Player");

        //Tir du joueur
        InputAction shootAction = m_PlayerMap.FindAction("Shoot");
        shootAction.performed += (context) => { m_PlayerShoot.m_ShootingPlayer = context.ReadValue<float>(); };
        shootAction.canceled += (context) => { m_PlayerShoot.m_ShootingPlayer = 0f; };

        //Mouvement Player
        InputAction moveAction = m_PlayerMap.FindAction("Movements");
        moveAction.performed += (context) => { m_PlayerMove.MovementInput= context.ReadValue<Vector2>(); };
        moveAction.canceled += (context) => { m_PlayerMove.MovementInput = Vector2.zero; };


        InputAction reloadScene = m_PlayerMap.FindAction("ReloadScene");
        //reloadScene.performed += (context) => { Retry(); };

        InputAction pauseAction = m_PlayerMap.FindAction("Pause");
        pauseAction.performed += (context) => { Pause(); };


    }
    private void OnEnable()
    {
        //Activation des input crée dans l'imput manager
        m_PlayerMap.Enable();
        //reloadMap.Enable();
        //pauseMap.Enable();
    }
    private void OnDisable()
    {
        
    }

    public void Pause()
    {
        if(Time.timeScale == 1)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
    public void Restart()
    {

    }
}
