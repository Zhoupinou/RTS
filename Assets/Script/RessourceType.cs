using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RessourceTypes
{
    Iron,
    Food,
    Wood,
    Gold
}

public class RessourceType : MonoBehaviour
{
    public ItemType ressource;

    public int timesHarvested = 0;
    public int harvestLimit = 20;
    public bool isHarvestable = true;
    public float resetTime = 1800.0f;  // 30 minutes in seconds

    public void Harvest()
    {
        if (isHarvestable && timesHarvested < harvestLimit)
        {
            timesHarvested++;
            if (timesHarvested >= harvestLimit)
            {
                StartCoroutine(ResetResource());
            }
        }
        else
        {
            Debug.Log("Cette ressource n'est pas disponible pour la récolte pour l'instant.");
        }
    }

    IEnumerator ResetResource()
    {
        isHarvestable = false;
        yield return new WaitForSeconds(resetTime);
        isHarvestable = true;
        timesHarvested = 0;
    }
}
