using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
	[SerializeField]private GameObject mainMenu;
	[SerializeField]private GameObject optionsMenu;
    [SerializeField]private GameObject levelMenu;

    private int levelComplete;
	public Button level2;
	public Button level3;

    void Start()
    {
        levelComplete = PlayerPrefs.GetInt("levelComplete");
        level2.interactable = false;
		level3.interactable = false;

		switch (levelComplete)
		{
			case 1:
				level2.interactable = true;
				break;
			case 2:
				level2.interactable = true;
				level3.interactable= true;
				break;
		}
	}

	public void LoadTo(int level)
	{
		SceneManager.LoadScene(level);

    }

    public void Reset()
    {
        level2.interactable = false;
        level3.interactable = false;
		PlayerPrefs.DeleteAll();
    }

    public void ExitGame()
	{
		Application.Quit();
	}
	public void OpenOptions()
	{
        optionsMenu.SetActive(true);
		mainMenu.SetActive(false);
	}

	public void CloseOptions()
	{
        optionsMenu.SetActive(false);
		mainMenu.SetActive(true);
	}
	public void OpenLevel()
	{
        levelMenu.SetActive(true);
        mainMenu.SetActive(false);
    }
	public void CloseLevel()
	{
        levelMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
}
