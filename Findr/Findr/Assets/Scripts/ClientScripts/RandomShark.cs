using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomShark : MonoBehaviour
{
    public List<CustomClients> customClients = new List<CustomClients>();
    public List<Clients> normalClients = new List<Clients>();

    bool sharkType;

    // Start is called before the first frame update
    void Start()
    {
        sharkType = (Random.value > 0.5f);

        if (sharkType)
        {
            gameObject.GetComponent<Image>().sprite = customClients[Random.Range(0, customClients.Count)].artwork;
        }
        else
        {
            Debug.Log("I'm supposed to be trash sharks but we don't have any yet so I'll just use custom sharks aswell RIP.");
            gameObject.GetComponent<Image>().sprite = customClients[Random.Range(0, customClients.Count)].artwork;

        }
    }


}
