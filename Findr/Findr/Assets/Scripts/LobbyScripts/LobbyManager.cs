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
                
        
    }



    
    public void UpgradeLobby()
    {
        switch (lobbyLevel)
        {
            case 0:
                if(money >= 0)
                {
                    lobbyLevel = 1;
                    UpdateLobbyText();
                    CheckLevel();
                }
                else
                {
                    Debug.Log("Not enough money!");
                }
                break;
            case 1:
                if (money >= 0)
                {
                    lobbyLevel = 2;
                    UpdateLobbyText();
                    CheckLevel();
                }
                else
                {
                    Debug.Log("Not enough money!");
                }
                break;
            case 2:
                if (money >= 0)
                {
                    lobbyLevel = 3;
                    UpdateLobbyText();
                    CheckLevel();
                }
                else
                {
                    Debug.Log("Not enough money!");
                }
                break;            
            default:
                Debug.Log("Max Level");
                break;
        }

        
    }

    //Opens the Client selection window by clicking on the clipboard
    public void OpenClientSelection()
    {
        clientSelection.SetActive(true);
    }

    //Closes client selection window
    public void CloseClientSelection()
    {
        clientSelection.SetActive(false);
    }

    //gets random clients, (idk if this shit works)
    private void GetRandomClients(int capacity)
    {
        Debug.Log(capacity); //Looks like its getting the correct number here.

        //Only get Custom Client for now will fill up with more once we have more sharks.
        randomizedList.Clear();
        randomizedList = new List<CustomClients>(capacity);

        //Theres definately something wrong here but fuck arrays and lists. But also I'm 100% sure I'm making this harder then I need to be.
        for(int i = 0; i < capacity; i++)
        {
            //Gets a random client from the list and assigns it 
            CustomClients randomClient = customClientList[Random.Range(0, customClientList.Count)];
            
            //Checks the randomized list to see if it already contains this (maybe, I mean thats what I think it should be doing, maybe it isn't doing that, fuck me).
            if (!randomizedList.Contains(randomClient))
            {
                randomizedList.Add(randomClient);
                
            }
            else
            {
                //I'm pretty sure this is toxic and might crash u so save before u end up using this.
                while(randomizedList.Contains(randomClient))
                {
                    //Idk just some stuff that looks correct but prolly isn't
                    randomizedList.Remove(randomClient);
                    randomClient = customClientList[Random.Range(0, customClientList.Count)];
                    randomizedList.Add(randomClient);              

                }
            }

        }

        


    }
    
    //Checks the level of the lobby and updates the available selectable clients in the selection window
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

    //Player prefs shit.
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

    //Does what it says it does
    private void UpdateLobbyText()
    {
        moneyText.text = "Money: " + money;
        lobbyLevelText.text = "Level " + lobbyLevel;
    }
           
    //Idk if any of these work but dw about them for now lol.
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
