using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RedCubeAI : MonoBehaviour
{
    private NavMeshAgent agent;
    private Vector3 randomDestination;

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
}
