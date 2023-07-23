using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereUnit : MonoBehaviour
{
    public float detectionRange = 10.0f;
    public float attackPower = 3.0f;

    void Update()
    {
        // Détecter les unités ennemies
        Collider[] enemiesInRange = Physics.OverlapSphere(transform.position, detectionRange);
        foreach (Collider enemy in enemiesInRange)
        {
            // Si l'ennemi a une balise Enemy, attaquez-le.
            if (enemy.gameObject.tag == "Enemy")
            {
                Attack(enemy.gameObject);
            }
        }
    }

    void Attack(GameObject enemy)
    {
        // Ici vous pouvez ajouter du code pour attaquer l'ennemi.
        
    }
}
