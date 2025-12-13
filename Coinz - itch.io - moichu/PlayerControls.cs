using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;
using UnityEngine.SceneManagement;

public class PlayerControls : MonoBehaviour
{
    Rigidbody playerRB;
    [SerializeField] GameObject win;
    [SerializeField] GameObject finale;
    [SerializeField] float speed;
    [SerializeField] int totalCoin;
    float moveX, moveZ;
    int coins = 0, sceneIndex;
    bool levelWin;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        playerRB = GetComponent<Rigidbody>();
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveZ = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        Vector3 forceVector = new Vector3(moveX * speed, playerRB.linearVelocity.y, moveZ * speed);
        playerRB.AddForce(forceVector, ForceMode.Acceleration);//more realistic pyhsics

    }

    void LateUpdate()
    {
        if(coins == totalCoin)
        {
            win.SetActive(true);  
            levelWin = true;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Coin")
        {
            Destroy(other.gameObject);
            coins++;
        }
        if(levelWin && other.gameObject.tag == "DeadEnd" && sceneIndex + 1 <= SceneManager.sceneCount)
        {
            SceneManager.LoadScene(++sceneIndex); //go to other scene
        }
        else if (!levelWin && other.gameObject.tag == "DeadEnd")//if u didn't collect all the coinz, then there's no escape >:l
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if(levelWin && other.gameObject.tag == "DeadEnd" && sceneIndex == SceneManager.sceneCount)
        {
            win.SetActive(false);
            finale.SetActive(true);//u finally win yeey
            Destroy(this.gameObject);
        }
    }
}
