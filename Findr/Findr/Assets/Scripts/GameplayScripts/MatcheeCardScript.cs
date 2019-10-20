using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MatcheeCardScript : MonoBehaviour
{    public bool isMouseOver = false;

    public void MouseOver()
    {
        isMouseOver = true;
    }

    public void MouseExit()
    {
        isMouseOver = false;
    }
}
