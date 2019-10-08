using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlinkingText : MonoBehaviour
{

    Text text;
    float alpha;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();       
    }



    // Update is called once per frame
    void Update()
    {        
        text.color = new Color(text.color.r,text.color.g,text.color.b, Mathf.PingPong(Time.time, 1));        
    }
}
