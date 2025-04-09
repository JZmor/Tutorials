using UnityEngine;
using UnityEngine.SceneManagement;


public class CompleteLevel : MonoBehaviour
{
    public SceneFader sceneFader;
    public string menuSceneName = "MainMenu";
    
    public string nextLevel = "Level 2";
    public int levelToUnlock = 2;

    public void Menu()
    {
        sceneFader.FadeTo(menuSceneName);
    }

    public void Continue()
    {
        PlayerPrefs.SetInt("levelReached", levelToUnlock);
        sceneFader.FadeTo(nextLevel);
    }
}
