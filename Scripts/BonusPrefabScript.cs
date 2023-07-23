using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusPrefabScript : MonoBehaviour
{
    // Ici, vous pouvez ajouter le code pour activer le bonus pour tous les Peasants
    // Cela pourrait être fait en recherchant tous les Peasants dans la scène et en réglant leur "hasSpeedBonus" à vrai
    void Start()
    {
        var peasants = GameObject.FindGameObjectsWithTag("Selectable");
        foreach (var peasant in peasants)
        {
            var taskManager = peasant.GetComponent<TaskManager>();
            if (taskManager != null)
            {
                taskManager.hasSpeedBonus = true;
            }
        }
    }
}
