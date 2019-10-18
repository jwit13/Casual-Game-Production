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
    public Image profileImage;
    public Text nameText;
    public Text bioText;
    
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
        
        //Gets a random client between the trash clients and custom clients
        sharkType = (Random.value > 0.5f);

        CreateShark();        
        

    }



    private void CreateShark()
    {
        //Replace/Add to these later with a while loop that gets another value until there are no sharks that have the same artwork (to account for both Custom and Trash sharks).
        if (sharkType)
        {
            //Gets a random custom client
            CustomClients randomCustClient = customClients[Random.Range(0, customClients.Count)];

            gameObject.GetComponent<Image>().sprite = randomCustClient.artwork;
            profileImage.sprite = gameObject.GetComponent<Image>().sprite;
            nameText.text = randomCustClient.name;
            bioText.text = randomCustClient.bio;



        }
        else
        {
            //Gets a random trash client (WIP)
            //Replace with trash clients when we get them ready.
            CustomClients randomClient = customClients[Random.Range(0, customClients.Count)];

            Debug.Log("I'm supposed to be trash sharks but we don't have any yet so I'll just use custom sharks aswell RIP.");

            gameObject.GetComponent<Image>().sprite = randomClient.artwork;
            profileImage.sprite = gameObject.GetComponent<Image>().sprite;
            nameText.text = randomClient.name;
            bioText.text = randomClient.bio;
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
