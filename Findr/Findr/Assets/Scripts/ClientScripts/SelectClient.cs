using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SelectClient : MonoBehaviour
{
    public GameObject selectedSharkPanel;
    public CustomClients customClient;
    private PopulateSelected populate; 

    private void Start()
    {
        
        customClient = LobbyManager.Instance.usedList[0];
        LobbyManager.Instance.usedList.RemoveAt(0);
        gameObject.GetComponent<Image>().sprite = customClient.artwork;
        populate = selectedSharkPanel.GetComponent<PopulateSelected>();
        
    }

    public void OpenSelectedPanel()
    {
        populate.selectedSharkImage.sprite = customClient.artwork;
        populate.selectedSharkName.text = customClient.name;
        populate.bioText.text = customClient.bio;
        SetupListedTraits();
        populate.selectedClient = customClient;
        selectedSharkPanel.SetActive(true);




    }


    private void SetupListedTraits()
    {
        int likedTraitCount = customClient.likedTraits.Count;
        int dislikedTraitCount = customClient.dislikedTraits.Count;

        Debug.Log("Liked Trait Count: " + likedTraitCount);
        Debug.Log("Disliked Trait Count: " + dislikedTraitCount);

        Debug.Log("Populate Liked Traits Count: " + populate.likedTraits.Count);
        Debug.Log("Populate Disliked Traits Count: " + populate.dislikedTraits.Count);

        for (int i = 0; i < populate.likedTraits.Count; i++)
        {
            if(i >= likedTraitCount)
            {
                //removes the trait square if there isn't any trait to fill it with
                populate.likedTraits[i].SetActive(false);
            }
            else
            {
                //Change color of trait square shit with the trait's set color
                populate.likedTraits[i].GetComponent<Image>().sprite = customClient.likedTraits[i].traitImage;
                populate.likedTraits[i].SetActive(true);
            }

        }

        if (dislikedTraitCount > 0)
        {
            for (int i = 0; i < populate.dislikedTraits.Count; i++)
            {
                if (i >= dislikedTraitCount)
                {
                    //removes the trait square if there isn't any trait to fill it with
                    populate.dislikedTraits[i].SetActive(false);
                }
                else
                {
                    //Change color of trait square shit with the trait's set color
                    populate.dislikedTraits[i].GetComponent<Image>().sprite = customClient.dislikedTraits[i].traitImage;
                    populate.dislikedTraits[i].SetActive(true);
                }

            }
        }
        else
        {
            //Removes all the trait squares if there aren't any.
            for(int i = 0; i < populate.dislikedTraits.Count; i++)
            {
                populate.dislikedTraits[i].SetActive(false);
            }
        }


    }




}
