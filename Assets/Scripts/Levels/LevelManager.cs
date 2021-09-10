using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class LevelManager : MonoBehaviour
{

    //public IPassing Passing { private get; set; }
    public Level Level;
    [HideInInspector] public bool IsPassed = false;

    [SerializeField] private GameObject _finishZone;
    [SerializeField] private Door _door;
    


    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "Level_1")
            Level = new Level_1();
        else if (SceneManager.GetActiveScene().name == "Level_2")
            Level = new Level_2();
        else if (SceneManager.GetActiveScene().name == "Level_3")
            Level = new Level_3();
        else if (SceneManager.GetActiveScene().name == "Level_4")
            Level = new Level_4();
        else if (SceneManager.GetActiveScene().name == "Level_5")
            Level = new Level_5();
        else if (SceneManager.GetActiveScene().name == "Level_6")
            Level = new Level_6();
        else if (SceneManager.GetActiveScene().name == "Level_7")
            Level = new Level_7();
    }

    private void Update()
    {
        if(!IsPassed && Level.Passed() == true)
        {
            IsPassed = true;
            _door.Opening();
            _finishZone.SetActive(true);
        }
    }
}

public abstract class Level
{
    protected PlayerController _playerContr = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    public abstract bool Passed();

}

class Level_1 : Level
{
    private LevelButton _button;

    public Level_1()
    {
        _button = GameObject.FindWithTag("LevelButton").GetComponent<LevelButton>();
    }

    override public bool Passed()
    {
        if (_button.IsActive)
            return true;

        return false;
    }
}

class Level_2 : Level
{
    private LevelButton _button;

    public Level_2()
    {
        _button = GameObject.FindWithTag("LevelButton").GetComponent<LevelButton>();
    }

    override public bool Passed()
    {
        if (_button.IsActive)
            return true;

        return false;
    }
}

class Level_3 : Level
{
    override public bool Passed()
    {
        return false;
    }
}

class Level_4 : Level
{
    private Key _key;

    public Level_4()
    {
        _key = GameObject.FindWithTag("Key").GetComponent<Key>();
    }

    override public bool Passed()
    {
        if (_playerContr.CountJumps > 0)
            _key.IsKillPlayer = true;
        if (_key == null)
            return true;

        return false;
    }
}

class Level_5 : Level
{
    private LevelButton _button;

    public Level_5()
    {
        _button = GameObject.FindWithTag("LevelButton").GetComponent<LevelButton>();
    }

    override public bool Passed()
    {
        if (_button.IsActive)
            return true;

        return false;
    }
}

class Level_6 : Level
{
    override public bool Passed()
    {
        return false;
    }
}

class Level_7 : Level
{
    override public bool Passed()
    {
        return false;
    }
}