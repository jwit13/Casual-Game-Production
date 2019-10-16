using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class RandomShark : MonoBehaviour,IPointerClickHandler
{
    public List<CustomClients> customClients = new List<CustomClients>();
    public List<Clients> normalClients = new List<Clients>();
    public GameObject profilePanel;
    private GameObject background;

    bool sharkType;

    // Start is called before the first frame update
    void Start()
    {
        //Set panel size and stuff
        //Check for better way to do this later if need be but it works for now.
        background = GameObject.FindGameObjectWithTag("Background");
        profilePanel.transform.position = background.transform.position;

        profilePanel.GetComponent<RectTransform>().sizeDelta = background.GetComponent<RectTransform>().sizeDelta;       
        

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

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!profilePanel.activeSelf)
        {
            //makes sure the selected clients panel is the top most layer.
            gameObject.transform.parent.SetAsLastSibling();
            profilePanel.SetActive(true);
        }
        else
        {
            profilePanel.SetActive(false);
        }
                      
    }




}
