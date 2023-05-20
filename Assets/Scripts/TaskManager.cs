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
        if(inventoryManager.itemsInInventory < inventoryManager.maxItemsInInventory)
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
                //deposit items
               if(inventoryManager.itemType == itemType.Iron)
               {
                gameManager.iron += inventoryManager.itemsInInventory;
               inventoryManager.itemsInInventory=0;
               }
               
            }
        }
        //find a place to mine 

       
    }
    IEnumerator Mine()
    {
        canMine = false;
        yield return new WaitForSeconds(timeToMine);
        inventoryManager.itemsInInventory++;
        inventoryManager.itemType = itemType.Iron;
        canMine = true;
    }

    public void StartMining(GameObject miningTarget)
    {
        targetMine = miningTarget;
        mining = true;
    }
}
