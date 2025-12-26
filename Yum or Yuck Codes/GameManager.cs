using System;
using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;//I can use this scripts variables, functions etc. from everywhere, and I prove that GameManager is only and one (^^) 
    CandieMove candi;//to use candies' move speed
    int score;
    [SerializeField] PlayerController player;
    [SerializeField] GameObject[] candies;
    [SerializeField] Transform spot;

    [HideInInspector] public int lives;
    [SerializeField] GameObject livesPanel;
    [HideInInspector] public bool gameOver;
    [SerializeField] TextMeshProUGUI yuckText, candieText, scoreText, apprecText;
    [SerializeField] GameObject GameOverPanel;
    [SerializeField] AudioSource source;
    [SerializeField] AudioClip yuckSound, wastedSound, wohoSound, greatSound;
    float waitSec;
    //[SerializeField] GameObject hotCandie;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (!instance)
        {
            instance = this;//if instance variable is not defined, then this script is the instance
        }
        gameOver = false;
        lives = 10;
        source = GetComponent<AudioSource>();
        GameOverPanel.SetActive(false);
        candieText.gameObject.SetActive(false);
    }

    void Start()
    {

        //Invoke("CreateCandie", .5f);
        waitSec = 3.5f;
        InvokeRepeating("DecreaseWaitSec", 5f, 2f);
        StartCoroutine(StartCandyRain());
    }

    // Update is called once per frame
    void LateUpdate()
    {
       
        if(!gameOver && (player.yuckScore > player.yumScore))//I don't want it to control this values in every frame after the game ends
        {
            //Debug.Log("Too much bad taste... YUCK!");
            gameOver = true;//no more checks after the game ends
            GameOver();
            source.PlayOneShot(yuckSound);
        }
    }

    void DecreaseWaitSec()
    {
        if(waitSec >= 1)//will speed up over time
            waitSec -= .1f;
        else
            CancelInvoke();///stop calling me
    }

    public void DecreaseLives()
    {
        if(lives > 0)
        {
            lives--;
            livesPanel.transform.GetChild(lives).gameObject.SetActive(false);//removing hearts from the stage
        }
        if(lives == 0)
        {
            gameOver = true;
            Debug.Log("All these candies... are wasted!");
            source.PlayOneShot(wastedSound);
            GameOver();
        }
    }

    IEnumerator StartCandyRain()
    {
        while (true)
        {
            CreateCandie();
            yield return new WaitForSeconds(waitSec);//wait for some time to create another candy
        }
    }
    
    void CreateCandie()
    {
        int num = UnityEngine.Random.Range(0, candies.Length);
        while(!player.IsStarted && num == 2)//we don't want to instanciate the first candy to be hot candy
        {
            num = UnityEngine.Random.Range(0, candies.Length);
        }
        player.IsStarted = true;
        float randomX = UnityEngine.Random.Range(-5, 5);//pick a random float number for x axis position
        spot.position = new Vector2(randomX, spot.position.y);//add it to spot pozition's x value
        GameObject createdCandi = Instantiate(candies[num], spot.position, spot.rotation);//then create the candy where it has to be created
        candi = createdCandi.GetComponent<CandieMove>();
        candi.speed = UnityEngine.Random.Range(3f, 8f);//and give that candy it's very own move speed
    }

    void GameOver()
    {
        source.Stop();//stop the main music
        StopAllCoroutines();//stop instanciate the candies
        CancelInvoke();//stop decreasing wait time
        player.yumScore -= (player.yuckScore * 3);
        score = (player.yumScore * 100) / 67; //It's calculated out of 67 points (my hometown's license plate number :D)
        GameOverPanel.SetActive(true);
        candieText.gameObject.SetActive(true);
        scoreText.text = score.ToString();
        
        if(score == 100)
        {
            apprecText.text = "YOU ARE THE ONE!!!!!!!";
            source.PlayOneShot(wohoSound);
        }
        else if(score >= 75)
        {
            apprecText.text = "SUPER CANDY MONSTER!";
            source.PlayOneShot(wohoSound);
        }
        else if(score > 50 && score < 75)
        {
            apprecText.text = "Great!";
            source.PlayOneShot(greatSound);
        }
        else if(score > 25 && score < 50)
        {
            apprecText.text = "You can do better ~(^o^)~";
            source.PlayOneShot(greatSound);
        }
        else
            apprecText.text = "C'mon, candiiieeeess!! :(";
    }
}
