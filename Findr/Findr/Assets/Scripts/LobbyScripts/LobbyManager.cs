using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class LobbyManager : MonoBehaviour
{
    public static LobbyManager Instance { get; private set; }

    [SerializeField]
    private int lobbyLevel = 0;
    [SerializeField]
    private int money = 0;

    
    public Button upgradeButton;
    public Text moneyText;
    public Text lobbyLevelText;
    public GameObject clientSelection;

    [Header("Client Lists")]
    public List<CustomClients> customClientList = new List<CustomClients>();
    public List<NormalClients> normalClientList = new List<NormalClients>();    
    public List<GameObject> clients = new List<GameObject>();
    List<CustomClients> randomizedList;


    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(this);



        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            
            //CheckPlayerPrefs();
            UpdateLobbyText();
            CheckLevel();
        }

        randomizedList.Clear();
        
    }

    private void Start()
    {
        //CheckClients();
    }


    
    public void OpenClientSelection()
    {
        clientSelection.SetActive(true);
    }

    public void CloseClientSelection()
    {
        clientSelection.SetActive(false);
    }


    private void GetRandomClients(int capacity)
    {
        //Only get Custom Client for now will fill up with more once we have more sharks.
        randomizedList.Clear();
        randomizedList = new List<CustomClients>(capacity);

        for(int i = 0; i < capacity; i++)
        {
            CustomClients randomClient = customClientList[Random.Range(0, customClientList.Count)];
            if (!randomizedList.Contains(randomClient))
            {
                randomizedList.Add(randomClient);
            }
            else
            {
                while(randomizedList.Contains(randomClient))
                {
                    randomizedList.Remove(randomClient);
                    randomClient = customClientList[Random.Range(0, customClientList.Count)];
                    randomizedList.Add(randomClient);              

                }
            }

        }

        


    }

    private void SpawnClients()
    {



    }

    private void CheckLevel()
    {
        switch (lobbyLevel)
        {
            case 0:
                clients[0].SetActive(true);
                GetRandomClients(1);
                break;

            case 1:
                for(int i = 0; i < 3; i++)
                {
                    clients[i].SetActive(true);
                }
                GetRandomClients(3);
                break;

            case 2:
                for (int i = 0; i < 6; i++)
                {
                    clients[i].SetActive(true);
                }
                GetRandomClients(6);
                break;

            case 3:
                for (int i = 0; i < clients.Count; i++)
                {
                    clients[i].SetActive(true);
                }
                GetRandomClients(9);
                break;

            default:
                for (int i = 0; i < 2; i++)
                {
                    clients[i].SetActive(true);
                }
                GetRandomClients(3);
                break;
        }
    }

    private void CheckPlayerPrefs()
    {
        //Check if the game has been played before and gets previous money and level values.
        if (PlayerPrefs.HasKey("Money"))
        {
            getMoney();
        }
        else
        {
            saveMoney();
        }

        if (PlayerPrefs.HasKey("Level"))
        {
            getLevel();
        }
        else
        {
            saveLevel();
        }
    }    

    private void UpdateLobbyText()
    {
        moneyText.text = "Money: " + money;
        lobbyLevelText.text = "Level " + lobbyLevel;
    }
           
    private void saveLevel()
    {
        PlayerPrefs.SetInt("Level", lobbyLevel);
    }

    private void getLevel()
    {
        money = PlayerPrefs.GetInt("Level");
    }

    private void saveMoney()
    {
        PlayerPrefs.SetInt("Money", money);
    }

    private void getMoney()
    {
        money = PlayerPrefs.GetInt("Money");
    }

}
