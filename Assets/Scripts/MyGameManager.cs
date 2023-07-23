using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MyGameManager : MonoBehaviour
{
    public int iron = 0;
    public int food = 0;
    public int gold = 0;
    public int wood = 0;

    public float player1Time = 0;
    public float player2Time = 0;
    public float gameTime = 0;
    public int currentPlayer = 1;

    public bool isGameOver = false; // Ajouté pour arrêter la partie.

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        player1Time = 0;
        player2Time = 0;
        StartCoroutine(GameTimer());
    }

    IEnumerator GameTimer()
    {
        while (!isGameOver) // Modification pour arrêter la partie.
        {
            yield return new WaitForSeconds(1);
            gameTime++;

            if (currentPlayer == 1)
                player1Time++;
            else
                player2Time++;
        }
    }

    public void EndGame()
    {
        StopCoroutine(GameTimer());

        if (currentPlayer == 1 && player2Time == 0)
        {
            currentPlayer = 2;
            SceneManager.LoadScene("Player2");
        }
        else if (currentPlayer == 2 && player1Time == 0)
        {
            currentPlayer = 1;
            SceneManager.LoadScene("SampleScene");
        }
        else
        {
            // Les deux joueurs ont terminé, déclarer le gagnant
            if (player1Time < player2Time)
            {
                Debug.Log("Le joueur 1 a gagné !");
                isGameOver = true; // Ajouté pour arrêter la partie.
            }
            else if (player2Time < player1Time)
            {
                Debug.Log("Le joueur 2 a gagné !");
                isGameOver = true; // Ajouté pour arrêter la partie.
            }
            else
            {
                Debug.Log("C'est un match nul !");
                isGameOver = true; // Ajouté pour arrêter la partie.
            }
        }
    }

    void Update()
    {
        
    }
}
