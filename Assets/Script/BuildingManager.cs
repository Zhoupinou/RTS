using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    GameObject gameObjectBeingBuilt = null;
    public LayerMask layerMask;
    public GameObject buildingPrefab;

    void Start()
    {
        
    }

    void Update()
    {
        if (gameObjectBeingBuilt)
        {
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
        if(buildingToBuild == null)
        {
            Debug.Log("buildingToBuild est null");
            return;
        }

        var gameManagerObject = GameObject.Find("GameManager");
        if(gameManagerObject == null)
        {
            Debug.Log("GameManager n'a pas été trouvé");
            return;
        }

        MyGameManager gameManager = gameManagerObject.GetComponent<MyGameManager>();
        if(gameManager == null)
        {
            Debug.Log("MyGameManager n'a pas été trouvé");
            return;
        }

        // Ajouté pour arrêter la construction lorsque la partie est terminée.
        if(gameManager.isGameOver)
        {
            Debug.Log("La partie est terminée. Construction impossible.");
            return;
        }

        if (buildingToBuild.name == "FatSlime")
        {
        // vérifiez si vous avez suffisamment de ressources pour construire le 'Slime_03'
            if (gameManager.iron < 10 || gameManager.gold < 10 || gameManager.wood < 10)
            {
                Debug.Log("Pas assez de ressources pour construire le FatSlime !");
                return;
            }

            // Déduisez les coûts des ressources
            gameManager.iron -= 10;
            gameManager.gold -= 10;
            gameManager.wood -= 10;
        }

    
        if (buildingToBuild.GetComponent<Portal>() != null)
        {
            if (gameManager.iron < 5 || gameManager.gold < 5 || gameManager.wood < 10)
            {
                Debug.Log("Pas assez de ressources pour construire le portail !");
                return;
            }

            gameManager.iron -= 5;
            gameManager.gold -= 5;
            gameManager.wood -= 10;
        }

        // vérifiez si le bâtiment à construire est l'UltimateTower
        if (buildingToBuild.name == "UltimateTower")
        {
            // vérifiez si vous avez suffisamment de ressources pour construire l'UltimateTower
            if (gameManager.iron < 1 || gameManager.gold < 1 || gameManager.wood < 1)
            {
                Debug.Log("Pas assez de ressources pour construire l'UltimateTower !");
                return;
            }

            // Déduisez les coûts des ressources
            gameManager.iron -= 1;
            gameManager.gold -= 1;
            gameManager.wood -= 1;

            // Fin de la partie
            gameManager.EndGame();
        }

        if (gameManager.iron < 5)
        {
            Debug.Log("Pas assez de fer pour construire le prefab !");
            return;
        }

        gameManager.iron -= 5;
        
        gameObjectBeingBuilt =  Instantiate(buildingToBuild, Vector3.zero, Quaternion.identity);
        gameObjectBeingBuilt.GetComponentInChildren<UnityEngine.AI.NavMeshObstacle>().enabled = false;
        gameObjectBeingBuilt.GetComponentInChildren<BoxCollider>().enabled = false;
    }
}
