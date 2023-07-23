using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    bool mining = false;
    bool canMine = true;
    public float timeToMine = 2 ;
    InventoryManager inventoryManager;
    PeasantMovementController movementController;
    public GameObject targetMine;
    MyGameManager gameManager;
    public bool hasSpeedBonus = false;

    // Start is called before the first frame update
    void Start()
    {
        inventoryManager= GetComponent<InventoryManager>();
        movementController = GetComponent<PeasantMovementController>();
        gameManager = GameObject.Find("GameManager").GetComponent<MyGameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(mining)
        {
            Mining();
        }
    }
    void Mining()
    {
        //if he doesn't any ressources in his inventory
        if(inventoryManager.itemTypes.Count < inventoryManager.maxItemsInInventory)
        {
            movementController.target = targetMine.transform.position;
            if(Vector3.Distance(targetMine.transform.position, transform.position )< 2.1)
            {
                if(canMine)
                {
                    StartCoroutine(Mine());
                }

          
            }
            //Mine the object
            //continue to mine
        }
        else
        {
            // if inventory is full drop off at town center
            movementController.target = GameObject.Find("TownCenter").transform.position;
            if(Vector3.Distance(GameObject.Find("TownCenter").transform.position, transform.position)<2.1)
            {
                foreach(ItemType item in inventoryManager.itemTypes)
                {
                    switch(item)
                    {
                        case ItemType.Iron:
                            gameManager.iron++;
                            break;
                        case ItemType.Food:
                            gameManager.food++;
                            break;
                        case ItemType.Gold:
                            gameManager.gold++;
                            break;
                        case ItemType.Wood:
                            gameManager.wood++;
                            break;
                       
                    }
                 
                }
                //deposit items
               
               inventoryManager.itemTypes.Clear();
               
            }
        }
        //find a place to mine 

       
    }
    IEnumerator Mine()
    {
        canMine = false;
        float waitTime = hasSpeedBonus ? timeToMine / 2 : timeToMine;
        yield return new WaitForSeconds(waitTime);
        if(Vector3.Distance(targetMine.transform.position, transform.position )< 2.1)
        {
            RessourceType ressourceType = targetMine.GetComponent<RessourceType>();
            if (ressourceType != null)
            {
                ressourceType.Harvest();
                if (ressourceType.isHarvestable)
                {
                    inventoryManager.itemTypes.Add(ressourceType.ressource);
                }
                else
                {
                    Debug.Log("Cette ressource n'est pas disponible pour la récolte pour l'instant.");
                }
            }
        }
        canMine = true;
    }

    public void StartMining(GameObject miningTarget)
    {
        targetMine = miningTarget;
        mining = true;
    }
}