using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class FindrManager : MonoBehaviour
{
    public Text scoreText;
    public Text timeText;

    public Text finalScoreText;
    public Text moneyText;

    public GameObject matcheeCard;
    public GameObject cardSpawn;

    public GameObject gamePanel;
    public GameObject startBtn;
    public GameObject returnBtn;

    public GameObject finalScoreObject;
    public GameObject moneyObject;

    Vector2 initialPos;

    private GameObject spawnedCard;
    private bool destroyCard;
    private bool held;

    private float mainTimer = 6.0f;
    private float timer;
    public bool canCount = false;
    private bool doOnce = false;
    
    private int initialScore = 0;
    private int score;
    private float rightSwipePos;
    [SerializeField]
    private int cardCount;

    int calculateMoney;

    private LobbyManager lobbyManager;

    public Image selectedClientImage;
    public Text selectedClientName;
    public List<GameObject> selectedClientTraits;

    private CustomClients customClient;
    private NormalClients normalClient;

    public GameObject rightSwipeBox;
    public GameObject leftSwipeBox;

    public static FindrManager main;
    public static string staticSelectedClientName;

    // Start is called before the first frame update
    void Start()
    {

        StartGameScene();

       if(Camera.main.aspect >= .56)
        {
            Debug.Log("9:16");              
        }
        else if (Camera.main.aspect == .5)
        {
            Debug.Log("9:18");           
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

            //Check if colliders intersect and allocate points.
            if(spawnedCard.GetComponent<BoxCollider2D>().bounds.Intersects(leftSwipeBox.GetComponent<BoxCollider2D>().bounds))
            {
                destroyCard = true;
                score += 100;
                Debug.Log("You swiped left!");
                Destroy(spawnedCard);                
                
            }
            else if(spawnedCard.GetComponent<BoxCollider2D>().bounds.Intersects(rightSwipeBox.GetComponent<BoxCollider2D>().bounds))
            {
                destroyCard = true;
                score += 100;
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

        UpdateScoreText();
    }

    public void StartGame()
    {
        startBtn.SetActive(false);
        gamePanel.SetActive(false);
        canCount = true;
        
        
    }

    private void StartGameScene()
    {
        gamePanel.SetActive(true);
        moneyObject.SetActive(false);
        finalScoreObject.SetActive(false);        
        startBtn.SetActive(true);
        lobbyManager = LobbyManager.Instance;
        Debug.Log(lobbyManager.selectedClient.name);

        //Check type of the selected Client
        if(lobbyManager.selectedClient is CustomClients)
        {
            customClient = (CustomClients)lobbyManager.selectedClient;
            int clientTraitsNum = customClient.likedTraits.Count;
            selectedClientName.text = customClient.name;
            staticSelectedClientName = customClient.name;
            selectedClientImage.sprite = customClient.artwork;
            for(int i = 0; i < clientTraitsNum; i++)
            {
                selectedClientTraits[i].GetComponent<Image>().sprite = customClient.likedTraits[i].traitImage.sprite;
                selectedClientTraits[i].SetActive(true);
            }                     

        }
        else
        {
            Debug.Log("I shouldnt be in here");
        }

        



    }

    private void Timer()
    {
        if (!UIManager.isPaused)
        {
            if (timer >= 0.0f && canCount)
            {
                timer -= Time.deltaTime;
                timeText.text = timer.ToString("F");
            }
            else if (timer <= 0.0f && !doOnce)
            {
                canCount = false;
                doOnce = true;
                timeText.text = "0.00";
                timer = 0.0f;
                ScoreToMoney();
                ReturnPanel();
                //Adds money
                LobbyManager.Instance.money += calculateMoney;
            }
        }
    }

    private void ReturnPanel()
    {

        finalScoreText.text = scoreText.text;
        moneyText.text = calculateMoney.ToString();
        gamePanel.SetActive(true);
        moneyObject.SetActive(true);
        finalScoreObject.SetActive(true);
        returnBtn.SetActive(true);
    }

    private void UpdateScoreText()
    {
        scoreText.text = score.ToString();
    }

    private void ScoreToMoney()
    {
        calculateMoney = score / 100;        
    }

    public void ReturnToLobby()
    {
        SceneManager.LoadScene(1);
    }
   



}
