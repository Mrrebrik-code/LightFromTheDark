using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    //public IPassing Passing { private get; set; }
    public IPassing Passing;
    [HideInInspector] public bool IsPassed;

    [SerializeField] GameObject _finishZone;
    [SerializeField] Door _door;


    private void Start()
    {
        if(SceneManager.GetActiveScene().name == "Level_1")
            Passing = gameObject.AddComponent<Level_1>();
        else if (SceneManager.GetActiveScene().name == "Level_2")
            Passing = gameObject.AddComponent<Level_2>();
        else if (SceneManager.GetActiveScene().name == "Level_3")
            Passing = gameObject.AddComponent<Level_3>();
    }

    private void Update()
    {
        if(!IsPassed && Passing.Passed() == true)
        {
            IsPassed = true;
            _door.Opening();
            _finishZone.SetActive(true);
        }
    }
}

public interface IPassing
{
    bool Passed();
}

class Level_1 : MonoBehaviour, IPassing
{
    private LevelButton _button;

    private void Awake()
    {
        _button = GameObject.FindGameObjectWithTag("Button").GetComponent<LevelButton>();
    }

    public bool Passed()
    {
        if(_button.IsActive)
            return true;

        return false;
    }
}

class Level_2 : MonoBehaviour, IPassing
{
    private LevelButton _button;

    private void Awake()
    {
        _button = GameObject.FindGameObjectWithTag("Button").GetComponent<LevelButton>();
    }

    public bool Passed()
    {
        if (_button.IsActive)
            return true;

        return false;
    }
}

class Level_3 : MonoBehaviour, IPassing
{
    public bool Passed()
    {
        return false;
    }
}
