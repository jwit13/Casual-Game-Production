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
    public GameObject startPanel;


    Vector2 initialPos;

    private GameObject spawnedCard;
    private bool destroyCard;
    private bool held;

    private float mainTimer = 60.0f;
    private float timer;
    public bool canCount = false;
    private bool doOnce = false;
    
    private float initialScore = 0.0f;
    private float score;
    private float rightSwipePos;
    [SerializeField]
    private int cardCount;


    // Start is called before the first frame update
    void Start()
    {
       if(Camera.main.aspect >= .56)
        {
            Debug.Log("9:16");
            rightSwipePos = 350;


        }
        else if (Camera.main.aspect == .5)
        {
            Debug.Log("9:18");
            rightSwipePos = 310;
        }

        timer = mainTimer;
        score = initialScore;

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
        Timer();
        UpdateScoreText();
      
       
        //Check if LMB is held down
        if (Input.GetMouseButton(0) && spawnedCard.GetComponent<MatcheeCardScript>().isMouseOver && spawnedCard != null)
        {           
            Vector2 pos = Input.mousePosition;
            spawnedCard.transform.position = pos;
            //Debug.Log(pos);
            held = true;

            //Check if you let go of mouse button
            if(spawnedCard.transform.position.x <= 90)
            {
                destroyCard = true;
                Debug.Log("You swiped left!");
                Destroy(spawnedCard);                
                
            }
            else if(spawnedCard.transform.position.x >= rightSwipePos)
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

    public void StartGame()
    {
        startPanel.SetActive(false);
        canCount = true;
        
    }


    private void Timer()
    {

        if(timer >= 0.0f && canCount)
        {
            timer -= Time.deltaTime;
            timeText.text = timer.ToString("F");
        }
        else if(timer <= 0.0f && !doOnce)
        {
            canCount = false;
            doOnce = true;
            timeText.text = "0.00";
            timer = 0.0f;
        }

    }

    private void UpdateScoreText()
    {
        scoreText.text = score.ToString();
    }



   



}
