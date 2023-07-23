using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingSlime : MonoBehaviour
{
    public int harvestLimitIncrease = 10;
    private string resourceTag = "Selectable"; // Remplacez par le tag que vous avez utilisé pour marquer vos objets de ressources

    void Start()
    {
        GameObject[] allResources = GameObject.FindGameObjectsWithTag(resourceTag);
        foreach (GameObject resource in allResources)
        {
            RessourceType ressourceType = resource.GetComponent<RessourceType>();
            if (ressourceType != null)
            {
                ressourceType.harvestLimit += harvestLimitIncrease;
            }
        }
    }
}
