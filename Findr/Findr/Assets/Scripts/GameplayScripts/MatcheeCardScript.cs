using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MatcheeCardScript : MonoBehaviour
{    public bool isMouseOver = false;

    RectTransform rt;
    Bounds b;
    public bool rightSwipe = false;
    public bool leftSwipe = false;

    public Image ProfilePic;
    public Text Name;
    public Text Bio;
    public List<Image> Traits;

    public List<ScriptableObject> MatcheeList;
    public List<Trait> TraitList;
    public List<int> usedTraitNums;

    private void Start()
    {
        rt = GetComponent<RectTransform>();
        DisplayWorldCorners();
        Populate();
    }

    private void DisplayWorldCorners()
    {
        Vector3[] v = new Vector3[4];
        rt.GetWorldCorners(v);

        Debug.Log("World Corners");
        for(int i = 0; i < 4; i++)
        {
            Debug.Log("World Corners " + i + " : " + v[i]);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {


        if (collision.gameObject.name == "RightSwipeBox")
        {
            rightSwipe = true;

        }
        else if (collision.gameObject.name == "LeftSwipeBox")
        {
            leftSwipe = true;
        }
    }

    private void Populate()
    {
        //string currentClient = FindrManager.main.selectedClientName.text;
        string currentClient = FindrManager.staticSelectedClientName;
        int randRange = MatcheeList.Count;
        ScriptableObject matchee;
        matchee = MatcheeList[UnityEngine.Random.Range(0, randRange)];
        while (matchee.name == currentClient)
        {
            matchee = MatcheeList[UnityEngine.Random.Range(0, randRange)];
        }

        if (matchee is CustomClients)
        {
            CustomClients cMatchee = (CustomClients)matchee;
            ProfilePic.sprite = cMatchee.artwork;
            Name.text = cMatchee.name;
            Bio.text = cMatchee.bio;
            foreach (Image i in Traits)
            {
                int randVal = UnityEngine.Random.Range(0, TraitList.Count);
                while (usedTraitNums.Contains(randVal))
                {
                    randVal = UnityEngine.Random.Range(0, TraitList.Count);
                }
                usedTraitNums.Add(randVal);
                i.sprite = TraitList[randVal].traitImage;
            }

        }
        else if (matchee is NormalClients)
        {
            NormalClients nMatchee = (NormalClients)matchee;
            ProfilePic.sprite = nMatchee.artwork;
            Name.text = nMatchee.name;
            Bio.text = nMatchee.bio;
            foreach (Image i in Traits)
            {
                int randVal = UnityEngine.Random.Range(0, TraitList.Count);
                while (usedTraitNums.Contains(randVal))
                {
                    randVal = UnityEngine.Random.Range(0, TraitList.Count);
                }
                usedTraitNums.Add(randVal);
                i.sprite = TraitList[randVal].traitImage;
            }
        }
    }

    public void MouseOver()
    {
        isMouseOver = true;
    }

    public void MouseExit()
    {
        isMouseOver = false;
    }
}
