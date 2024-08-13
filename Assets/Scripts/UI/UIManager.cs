using UnityEngine;
using UnityEngine.Scripting;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [Header ("GameOver") ]
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private AudioClip gameOverSound;

    [Header ("Pause") ]
    [SerializeField] private GameObject pauseScreen;

    private void Awake()
    {
        gameOverScreen.SetActive(false);
        pauseScreen.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            //si la pantallita de pausa ya esta activa entonces la unpausa y viceversa

            if(pauseScreen.activeInHierarchy)
                PauseGame(false);
            else
                PauseGame(true);
        }
    }

    #region Game Over

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
    }

    //funciones

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

     public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

     public void Quit()
    {
        Application.Quit(); //solamente funciona en la build final

    }

    #endregion
    #region Pause

    public void PauseGame(bool status)
    {
        //si status == true lo pausa, si status == false lo unpausa
        pauseScreen.SetActive(status);

        if (status)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }

    public void soundVolume()
    {

    }

    public void musicVolume()
    {
        
    }

    #endregion
}
