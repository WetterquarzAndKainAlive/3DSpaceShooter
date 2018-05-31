using UnityEngine;

public class PauseMenu : MonoBehaviour {

    public static bool isGamePaused = false;

    public GameObject pauseMenuUI;

    public GameObject helpMenuUI;

	// Update is called once per frame
	void Update () {
		
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isGamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

	}

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        helpMenuUI.SetActive(false);
        Time.timeScale = 1f;

        isGamePaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;

        isGamePaused = true;
    }

    public void EnterHelpMenu()
    {
        pauseMenuUI.SetActive(false);
        helpMenuUI.SetActive(true);

    }

    public void ExitHelpMenu()
    {
        helpMenuUI.SetActive(false);
        Pause();
    }
}
