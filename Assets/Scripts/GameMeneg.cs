using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMeneg : MonoBehaviour
{
    public GameObject PanelMenu;   

    void Awake()
    {
        if (N == 0)
        {
            PanelMenu.SetActive(true);
            Time.timeScale = 0.001f;
        }
        else
        {
            PanelMenu.SetActive(false);
            Time.timeScale = 1f;
        }       
    }    

    public void ReStart()
    {        
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Level = 0;
        N = 1;
    }
    public void LevelUp()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        N = 1;
    }
    public void Exit()
    {
        N = 0;
        Application.Quit();
    }
    public int Level
    {
        get => PlayerPrefs.GetInt("Level", 0);
        private set
        {
            PlayerPrefs.SetInt("Level", value);
            PlayerPrefs.Save();
        }
    }
    public int N
    {
        get => PlayerPrefs.GetInt("Level1", 0);
        set
        {
            PlayerPrefs.SetInt("Level1", value);
            PlayerPrefs.Save();
        }
    }
}