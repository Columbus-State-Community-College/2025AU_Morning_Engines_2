using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    private int playerHealth = 3;
    public Text PlayerHP;
    public GameObject GameOverScreen;

    public void HP_Decrease()
    {
        playerHealth -= 1;
        PlayerHP.text = "HP: " + playerHealth.ToString();
        HP_Zero();
    }

    public void HP_Zero()
    {
        if (playerHealth == 0)
        {
            GameOver();

        }
    }

    public void ResartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        GameOverScreen.SetActive(true);
    }
}
