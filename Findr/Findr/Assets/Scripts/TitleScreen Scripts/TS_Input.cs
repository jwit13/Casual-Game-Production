using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TS_Input : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        
        if(Input.touchCount > 0 || Input.GetMouseButtonDown(0))
        {
            Debug.Log("You touched me!");
            SceneManager.LoadScene(1);

        }

    }
}
