using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject upgradesMenu;

    public static bool menuUp;

    public static UIManager instance;

    private void Awake()
    {
        // Prevents there from being more than one
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // Prevents from being destroyed when loading new scene
        DontDestroyOnLoad(gameObject);
        instance = this;

        menuUp = false;
    }

    void Start()
    {

    }


    void Update()
    {
        if (true)
        {
            if (!menuUp)
            {
                Time.timeScale = 0;
                menuUp = true;
            }

            else
            {
                Time.timeScale = 1;
                menuUp = false;
            }
        }

    }


}
