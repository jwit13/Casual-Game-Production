using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyManager : MonoBehaviour
{
    [SerializeField]
    private int lobbyLevel = 0;
    [SerializeField]
    private int money = 0;

    public GameObject clientTemplate;
    public Button upgradeButton;
    public Text moneyText;
    public Text lobbyLevelText;
    public List<GameObject> spawnPoints;

    



    private void Awake()
    {
        CheckPlayerPrefs();
        UpdateLobbyText();
        SpawnClients();
    }


    private void SpawnClients()
    {
        for(int i = 0; i < spawnPoints.Count; i++)
        {
            Instantiate(clientTemplate, spawnPoints[i].transform);
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
