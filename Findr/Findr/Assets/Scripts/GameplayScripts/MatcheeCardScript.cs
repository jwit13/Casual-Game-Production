using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatcheeCardScript : MonoBehaviour
{
    public bool isMouseOver = false;

    private void OnMouseOver()
    {
        isMouseOver = true;
    }

    private void OnMouseExit()
    {
        isMouseOver = false;
    }



}
