using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    //Vector2 move;
    Rigidbody2D playerRb;
    float inputX, forceY;
    [HideInInspector] public bool IsStarted;
    [HideInInspector] public int yumScore, yuckScore, realYuck;
    SpriteRenderer playerSR;
    [SerializeField] TextMeshProUGUI yum, yuck;
    [SerializeField] private float speed;
    [SerializeField] AudioSource source;
    [SerializeField] AudioClip eatSound, ewSound;

    void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerSR = GetComponent<SpriteRenderer>();
        source = GetComponent<AudioSource>();
        yumScore = 0;
        yuckScore = 0;//it's all fake bcz u have to eat 3 candies to vanish that bad taste ..
        realYuck = 0;//like aftertaste :D seriously, I'm gonna check this one instead of yuckScore
        IsStarted = false;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        yum.text = yumScore.ToString();
        yuck.text = yuckScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(!GameManager.instance.gameOver)///if the game ends, u can't move
            inputX = Input.GetAxisRaw("Horizontal");
        //forceY = Input.GetAxisRaw("Vertical");
        //Debug.LogFormat("This is delta: {0}\n This is fixedDelta: {1}", Time.deltaTime, Time.fixedDeltaTime);
    }

    void FixedUpdate()
    {
        //move = new Vector2(inputX, forceY);
        //playerRb.linearVelocity = new Vector2(inputX * speed, playerRb.linearVelocityY);//gonna control the player movements more "in control"
        //if(transform.position.x > 7)
        //     transform.position = new Vector2(7, transform.position.y);//setting the boundaries
        // else if(transform.position.x < -7)
        //     transform.position = new Vector2(-7, transform.position.y);//it behaves strangely, bounce back from the boundaries
        //there is a basic way to control that
        if (!GameManager.instance.gameOver)
        {
            Vector2 tempPos = playerRb.position + new Vector2(inputX * speed * Time.fixedDeltaTime, 0);//it controls the next frame's location
            tempPos.x = Mathf.Clamp(tempPos.x, -7, 7);//it controls the value between min and max amount of x axis, and reassigns it
            playerRb.MovePosition(tempPos);//we moving the player's position w fixed x axis value, so it cannot move any further from the boundaries
        }
    }

    void LateUpdate()
    {
        if(inputX > 0)
            playerSR.flipX = false;//flip the caracter(for better visuals)
        else if(inputX < 0)
            playerSR.flipX = true;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Candies")
        {
            MakeSound(eatSound);//crunch sound
            Destroy(collision.gameObject);
            //Debug.Log("I ate the candie!");
            if (!GameManager.instance.gameOver)//no more calculating
            {
                if(realYuck > 0)
                    --realYuck;
                if(realYuck == 0 && yuckScore > 0)
                {
                    yuckScore--;
                    if(yuckScore != 0)
                        realYuck = 3;//needs to vanish other bad tastes
                    yuck.text = yuckScore.ToString();
                }
                else if(yuckScore == 0)
                    yumScore++;
                yum.text = yumScore.ToString();
            }
        }
        else if(collision.gameObject.tag == "PepperCandy")
        {
            MakeSound(ewSound);
            Destroy(collision.gameObject);
            //Debug.Log("Yuck!");
            if (!GameManager.instance.gameOver)
            {
                    yuckScore++;
                if(yuckScore > 0)
                    realYuck = 3;
                yuck.text = yuckScore.ToString();    
            }
        }
    }

    void MakeSound(AudioClip sound)
    {
        source.pitch = Random.Range(0.8f, 1.2f);//we're making every crunch sound different, so it feels good :)
        source.PlayOneShot(sound);
    }
    
}
