using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    Rigidbody2D playerRB;
    float X;
    Vector2 fixedPos;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameManager.instance.IsGameStarted)
        {
            if (Input.GetMouseButton(0))
            {
                Vector3 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                float direction = 0;

                if(touchPos.x < 0)
                    direction = -1;//left
                else
                    direction = 1;//right
                //playerRB.AddForce(speed * Vector2.left);
                float temp = playerRB.position.x + (speed * direction * Time.deltaTime);
                temp = Mathf.Clamp(temp, -2.08f, 2.08f);//for setting boundaries w code, u can do it basically w objects
                playerRB.MovePosition(new Vector2(temp, playerRB.position.y));
            }else
                playerRB.linearVelocity = Vector2.zero;

        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Box"))
        {
            GameManager.instance.IsGameStarted = false;
            SceneManager.LoadScene(0);
        }
    }

    // void FixedUpdate()
    // {
    //     if (!GameManager.instance.IsGameOver)
    //     {
    //         fixedPos = playerRB.position + new Vector2(X * speed * Time.fixedDeltaTime, 0);
    //         fixedPos.x = Mathf.Clamp(fixedPos.x, -2.08f, 2.08f);
    //         fixedPos.y = playerRB.position.y;
    //         playerRB.MovePosition(fixedPos);
    //         playerRB.linearVelocityX = speed * X;    
    //     }else
    //         playerRB.MovePosition(playerRB.position);//it's moving that's so annoying >:[
    // }
}
