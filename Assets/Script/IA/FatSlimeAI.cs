using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FatSlimeAI : MonoBehaviour
{
    private NavMeshAgent agent;
    private Vector3 randomDestination;

    private string[] greetings = {"Bonjour, la récolte avance", "Belle journée", "Avez-vous vu les plaines du nord ?"};
    
    private float minX = -100.0f; // Modifier en fonction de votre carte
    private float maxX = 100.0f;  // Modifier en fonction de votre carte
    private float minZ = -100.0f; // Modifier en fonction de votre carte
    private float maxZ = 100.0f;  // Modifier en fonction de votre carte

    // Démarrer
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        SetRandomDestination();
    }

    // Mettre à jour
    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            SetRandomDestination();
        }
    }

    // Définit une destination aléatoire pour l'agent NavMesh
    private void SetRandomDestination()
    {
        randomDestination = new Vector3(Random.Range(minX, maxX), 0.0f, Random.Range(minZ, maxZ));
        agent.SetDestination(randomDestination);
    }

    // Écrire un message dans la console lorsque l'utilisateur clique sur ce GameObject
    void OnMouseDown()
    {
        int index = Random.Range(0, greetings.Length);
        Debug.Log(greetings[index]);
        StartCoroutine(PauseMovement());
    }

    // Pause le mouvement pendant une seconde
    IEnumerator PauseMovement()
    {
        agent.isStopped = true;
        yield return new WaitForSeconds(1);
        agent.isStopped = false;
    }
}
