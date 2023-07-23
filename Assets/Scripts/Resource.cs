using System.Collections;
using UnityEngine;

public class Resource : MonoBehaviour
{
    public int harvestLimit = 20;
    private int timesHarvested = 0;

    private bool isHarvestable = true;

    public void Harvest()
    {
        if (isHarvestable && timesHarvested < harvestLimit)
        {
            // Ici vous pouvez ajouter le code pour récolter la ressource
            timesHarvested++;

            if (timesHarvested >= harvestLimit)
            {
                StartCoroutine(Cooldown());
            }
        }
        else
        {
            Debug.Log("Cette ressource n'est pas disponible pour la récolte pour l'instant.");
        }
    }

    private IEnumerator Cooldown()
    {
        isHarvestable = false;
        yield return new WaitForSeconds(30 * 60); // Attendez 30 minutes
        isHarvestable = true;
        timesHarvested = 0; // Réinitialiser le compteur de récolte
    }
}
