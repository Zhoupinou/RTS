using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    GameObject gameObjectBeingBuilt = null;
    public LayerMask layerMask;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObjectBeingBuilt)
        {
            
             //attach is to the mouse postion relative to the ground
             Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
             RaycastHit hit;
             if(Physics.Raycast(ray, out  hit, 1000, layerMask))
             {
                gameObjectBeingBuilt.transform.position = hit.point;
                
                if(Input.GetMouseButtonDown(0))
                {
                    gameObjectBeingBuilt = null;
                }
             }
        }
    }
    public void ConstructBuilding(GameObject buildingToBuild)
    {
        // spawn in a building
        gameObjectBeingBuilt =  Instantiate(buildingToBuild, Vector3.zero, Quaternion.identity);
        gameObjectBeingBuilt.GetComponentInChildren<UnityEngine.AI.NavMeshObstacle>().enabled = false;
        gameObjectBeingBuilt.GetComponentInChildren<BoxCollider>().enabled = false;
        //On left click place building construction version of building and stop followin mouse
    }
}
