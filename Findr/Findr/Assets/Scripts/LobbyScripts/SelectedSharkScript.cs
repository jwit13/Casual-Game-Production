using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedSharkScript : MonoBehaviour
{


    public void ClosePanel()
    {
        if (gameObject.activeSelf)
        {
            gameObject.SetActive(false);
        }
    }

}
