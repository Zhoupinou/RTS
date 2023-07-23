using UnityEngine;

public class Boucherie : MonoBehaviour
{
    MyGameManager gameManager;
    public float foodPerSecond = 10; // Mettez le nombre de nourriture que vous voulez générer par seconde ici
    private float foodGenerated; // quantité de nourriture générée, stockée comme un float pour plus de précision

    private void Start()
    {
        var gameManagerObject = GameObject.Find("GameManager");
        if(gameManagerObject != null)
        {
            gameManager = gameManagerObject.GetComponent<MyGameManager>();
        }
    }

    private void Update()
    {
        if(gameManager != null)
        {
            foodGenerated += foodPerSecond * Time.deltaTime;

            // si nous avons généré au moins 1 nourriture complète, ajoutez-la à gameManager.food
            if(foodGenerated >= 1)
            {
                gameManager.food += Mathf.FloorToInt(foodGenerated);
                foodGenerated -= Mathf.Floor(foodGenerated); // retirez la quantité de nourriture ajoutée à gameManager.food de foodGenerated
            }
        }
    }
}
