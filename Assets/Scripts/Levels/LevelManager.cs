using UnityEngine;
using UnityEngine.SceneManagement;



public class LevelManager : MonoBehaviour
{

    //public IPassing Passing { private get; set; }
    public Level Level;
    [HideInInspector] public bool IsPassed = false;
    [SerializeField] private Door _door;
    [SerializeField] private Door _door2;


   

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
        else if (SceneManager.GetActiveScene().name == "Level_8")
            Level = new Level_8(_door2);
        else if (SceneManager.GetActiveScene().name == "Level_9")
            Level = new Level_9();
        else if (SceneManager.GetActiveScene().name == "Level_10")
            Level = new Level_10();
        else if (SceneManager.GetActiveScene().name == "Level_11")
            Level = new Level_11();




    }

    private void Update()
    {
        if(!IsPassed && Level.Passed() == true)
        {
            IsPassed = true;
            _door.Opening();
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
        return false;
    }
}

class Level_6 : Level
{
    private Lever _lever;
    private LevelButton _button;

    public Level_6()
	{
        _lever = GameObject.FindWithTag("Lever").GetComponent<Lever>();
        _button = GameObject.FindWithTag("LevelButton").GetComponent<LevelButton>();
    }
    override public bool Passed()
    {
        if (_lever.IsActive && _button.IsActive) return true;
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

class Level_8 : Level
{
    private Key _key;
    private LevelButton _button;
    private Lever _lever;
    private Door _door2;
    private bool isOpenDoor2 = false;
	public Level_8(object door)
	{
        _door2 = door as Door;
        _key = GameObject.FindWithTag("Key").GetComponent<Key>();
        _lever = GameObject.FindWithTag("Lever").GetComponent<Lever>();
        _button = GameObject.FindWithTag("LevelButton").GetComponent<LevelButton>();
        
    }
    override public bool Passed()
    {
        if(_key == null && isOpenDoor2 == false)
		{
            isOpenDoor2 = true;
            _door2.Opening();
        }

        if (_lever.IsActive && _button.IsActive) return true;
        return false;
    }
}

class Level_9 : Level
{
    override public bool Passed()
    {
        if (SystemInfo.batteryStatus == BatteryStatus.Charging)
            return true;

        return false;
    }
}

class Level_10 : Level
{
    public Level_10()
    {

    }

    override public bool Passed()
    {
        return false;
    }
}

class Level_11 : Level
{
    private LevelButton _button;

    public Level_11()
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

class Level_12 : Level
{
    private LevelButton _button;

    public Level_12()
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