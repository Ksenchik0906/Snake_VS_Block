using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameMeneg : MonoBehaviour
{
    public GameObject PanelMenu;

    void Awake()
    {
        Time.timeScale = 0.001f;
    }
    

    public void ReStart()
    {
        PanelMenu.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void LevelUp()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
      //  PanelMenu.SetActive(false);
    }
}