using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HealthPlayer : MonoBehaviour
{
    [SerializeField]
    private int m_Life = 3;

    private void Update()
    {
        if(Keyboard.current[Key.Q].wasPressedThisFrame)
        {
            TakesDamages(1);
        }
    }
    public void TakesDamages(int p_Damages)
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
}
