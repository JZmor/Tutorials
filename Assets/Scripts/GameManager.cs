using UnityEditor.Analytics;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool gameIsOver;

    public GameObject gamerOverUI;

    public GameObject completeLevelUI;

    void Start()
    {
        gameIsOver = false;
    }

    void Update()
    {
        if (gameIsOver)
        {
            return;
        }

        if (Input.GetKeyDown("e"))
        {
           EndGame(); 
        }

        if (PlayerStats.lives <= 0)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        gameIsOver = true;
        gamerOverUI.SetActive(true);
    }

    public void WinLevel()
    {
        completeLevelUI.SetActive(true);
        gameIsOver = true;
    }
}
