using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    [SerializeField]
    private int m_PlayerSpeed = 0;
    public Vector2 MovementInput = Vector2.zero;

   
    private void Update()
    {
        Movements(MovementInput, Time.deltaTime);
    }

    public void Movements(Vector2 _Direction, float _DeltaTime)
    {
        //On normalise les vecteur afin que leur valeur soit toujours egale a 1.
        _Direction.Normalize();
        //Création du nouveau vecteur de mouvement
        Vector3 movement = new Vector2(_Direction.x, _Direction.y);
        //Deplacement du joueur en fonction du vecteur de direction et le temps courant du jeu.
        transform.position += movement * m_PlayerSpeed * _DeltaTime;
    }
}
