using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
public class MainMenuUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void PlayButton()
    {
        SceneManager.LoadScene("Level_1");
    }

    public void Level1()
    {
        SceneManager.LoadScene("Level_1");
    }
    public void Level2()
    {
        SceneManager.LoadScene("Level_2");
    }
    public void Level3()
    {
        SceneManager.LoadScene("Level_3");
    }
    public void LevelEndless()
    {
        SceneManager.LoadScene("Level_Endless");
    }


    public void QuitGame()
    {
        Application.Quit();
    }
}
