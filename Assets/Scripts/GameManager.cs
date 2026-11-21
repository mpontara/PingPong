using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;


public class GameManager : MonoBehaviour
{

    public Transform playerPaddle;
    public Transform enemyPaddle;
    public BallController ballcontroller;

    public int playerScore = 0;
    public int enemyScore = 0;

    public TextMeshProUGUI textPointsPlayer;
    public TextMeshProUGUI textPointsEnemy;

    public GameObject screenEndGame;

    public TextMeshProUGUI textEndGame;

    public int winPoints = 5;

    void Start()
    {
       ResetGame(); 
    }

    
    public void ResetGame()
    {
        playerPaddle.position = new Vector3(-7f, 0f, 0f);
        enemyPaddle.position = new Vector3(7f, 0f, 0f);

        ballcontroller.ResetBall();

        playerScore = 0;
        enemyScore = 0;

        textPointsPlayer.text = playerScore.ToString();
        textPointsEnemy.text = enemyScore.ToString();

        screenEndGame.SetActive(false);

    }

    public void ScorePlayer()
    {
        playerScore++;
        textPointsPlayer.text = playerScore.ToString();
        CheckWin();
    }

    public void ScoreEnemy()
    {
        enemyScore++;
        textPointsEnemy.text = enemyScore.ToString();
        CheckWin();
    }

    public void CheckWin()
    {
        if(enemyScore >= winPoints || playerScore >= winPoints)
        {
            //ResetGame();
            EndGame();
        }
    }

    public void EndGame()
    {
        screenEndGame.SetActive(true);
        string winner = SaveController.Instance.GetName(playerScore > enemyScore);
        textEndGame.text =  winner + " Won";
        SaveController.Instance.SaveWinner(winner);

        Invoke("LoadMenu", 2f);
        
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }

}
