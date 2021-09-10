using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject _listOfLevelsObj;
    [SerializeField] private GameObject _sceneObj;

    public void OnClickButtonPlay()
    {
        _sceneObj.SetActive(false);
        _listOfLevelsObj.SetActive(true);
    }

    public void OnClickButtonSettings()
    {

    }

    public void OnClickButtonExit()
    {
        PlayerPrefs.DeleteAll();
    }
}
