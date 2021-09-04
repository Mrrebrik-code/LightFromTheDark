using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenu;

    public void OnClickButtonPause()
    {
        Time.timeScale = 0;
        _pauseMenu.SetActive(true);
    }

    public void OnClickButtonMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    public void OnClickButtonSouns()
    {

    }
    public void OnClickButtonMusic()
    {

    }
    public void OnClickButtonContinue()
    {
        Time.timeScale = 1;
        _pauseMenu.SetActive(false);
    }

}
