using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class KingAI : MonoBehaviour
{
    private NavMeshAgent agent;
    private Vector3 randomDestination;

    private string[] greetings = {
        "Le royaume prospère sous notre règne.",
        "Que la justice soit faite.",
        "Que la paix règne sur notre beau royaume.",
        "Nous devons toujours chercher la sagesse.",
        "Le courage de notre peuple est notre plus grande force.",
        "Le trône n'est pas simplement un siège, c'est une responsabilité.",
        "Chaque décision que je prends est pour le bien de notre royaume.",
        "Rappelez-vous, la loyauté est ce qui unit un royaume.",
        "En ces temps difficiles, restons forts.",
        "Que chaque jour soit une célébration de notre peuple et de notre terre."
    };
    
    private float minX = -100.0f; // Modifier en fonction de la carte
    private float maxX = 100.0f;  // Modifier en fonction de la carte
    private float minZ = -100.0f; // Modifier en fonction de la carte
    private float maxZ = 100.0f;  // Modifier en fonction de la carte

    // Démarrer
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        SetRandomDestination();
        StartCoroutine(Talk());
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

    // Commencer à parler toutes les 5 secondes
    IEnumerator Talk()
    {
        while (true)
        {
            int index = Random.Range(0, greetings.Length);
            Debug.Log(greetings[index]);
            yield return new WaitForSeconds(5);
        }
    }
}
