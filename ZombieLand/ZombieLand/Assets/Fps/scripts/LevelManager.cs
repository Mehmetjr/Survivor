 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int currentLevel = -1;

    public int easyDamage = 5;
    public int mediumDamage = 2;

    public int easyScore = 10;
    public int mediumScore = 5;

    //Singleton
    private static LevelManager _instance;
    private void Awake()
    {
        _instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
    public static LevelManager GetInstance() { return _instance; }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
