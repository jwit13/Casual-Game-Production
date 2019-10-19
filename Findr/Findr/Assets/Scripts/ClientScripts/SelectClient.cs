using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SelectClient : MonoBehaviour
{
    public GameObject selectedSharkPanel;
    public CustomClients customClient;
    
    private void Start()
    {
        customClient = LobbyManager.Instance.usedList[0];
        LobbyManager.Instance.usedList.RemoveAt(0);
        gameObject.GetComponent<Image>().sprite = customClient.artwork;
    }

    public void OpenSelectedPanel()
    {
        selectedSharkPanel.SetActive(true);
    }




}
