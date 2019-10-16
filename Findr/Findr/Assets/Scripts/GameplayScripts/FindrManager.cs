using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class FindrManager : MonoBehaviour
{
    public Text scoreText;
    public Text timeText;

    public GameObject matcheeCard;
    public GameObject cardSpawn;
    SpriteRenderer sr;

    Vector2 initialPos;

    private GameObject spawnedCard;
    private bool destroyCard;
    private bool held;

    [SerializeField]
    private int cardCount;


    // Start is called before the first frame update
    void Start()
    {
        //gives instiated object a variable to allow it to be swipable
        spawnedCard = Instantiate(matcheeCard,cardSpawn.transform);
        //position to return to if swipe requirements arent met
        initialPos = cardSpawn.transform.position;
        Debug.Log(cardSpawn.transform.childCount);
        cardCount = cardSpawn.transform.childCount;
    }

    // Update is called once per frame
    void Update()
    {
        
        //Check if LMB is held down
        if (Input.GetMouseButton(0))
        {           
            Vector2 pos = Input.mousePosition;
            spawnedCard.transform.position = pos;
            //Debug.Log(pos);
            held = true;
            //Check if you let go of mouse button
            if(spawnedCard.transform.position.x <= 50)
            {
                destroyCard = true;
                Debug.Log("You swiped left!");
                Destroy(spawnedCard);                
                
            }
            else if(spawnedCard.transform.position.x >= 350)
            {
                destroyCard = true;
                Debug.Log("you swiped right!");
                Destroy(spawnedCard);                
               
            }

        }
        else
        {
            held = false;
        }

        destroyCard = false;
     


        

    }


    private void LateUpdate()
    {
        cardCount = cardSpawn.transform.childCount;
        if (cardCount == 0 && !held)
        {
            spawnedCard = Instantiate(matcheeCard, cardSpawn.transform);
        }

        if (!Input.GetMouseButton(0) && !destroyCard)
        {
            spawnedCard.transform.position = initialPos;
        }
    }



}
