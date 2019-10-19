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
        gameObject.GetComponent<Image>().sprite = customClient.artwork;
    }

    public void OpenSelectedPanel()
    {
        selectedSharkPanel.SetActive(true);
    }




}
