using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public static LevelController instance = null;

    [SerializeField] private GameObject WinMenu;

    int sceneIndex;
    int levelComplete;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        levelComplete = PlayerPrefs.GetInt("levelComplete");
    }

    private void isEndGame()
    {
        if (sceneIndex ==3)
        {
            Invoke("LoadMainMenu", 1f);
        }
        else
        {
            if (levelComplete < sceneIndex)
            {
                PlayerPrefs.SetInt("levelComplete", sceneIndex);
            }
            Invoke("NextLevel", 1f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        WinMenu.SetActive(true);
    }

    public void LoadScene()
    {
        isEndGame();
    }

    void NextLevel()
    {
        SceneManager.LoadScene(sceneIndex + 1);
    }
    void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Restart(int restart)
    {
        SceneManager.LoadScene(restart);
    }
}
