using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MatcheeCardScript : MonoBehaviour
{    public bool isMouseOver = false;

    RectTransform rt;
    Bounds b;
    public bool rightSwipe = false;
    public bool leftSwipe = false;

    private void Start()
    {
        rt = GetComponent<RectTransform>();
        DisplayWorldCorners();
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







    public void MouseOver()
    {
        isMouseOver = true;
    }

    public void MouseExit()
    {
        isMouseOver = false;
    }
}
