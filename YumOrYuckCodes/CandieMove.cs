using UnityEngine;

public class CandieMove : MonoBehaviour
{
    [HideInInspector] public float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<Rigidbody2D>().linearVelocity = Vector2.down * speed;//increasing the speed in the GameManager script
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "DeadEnd")//they're destroying by the unvisible deadend gameobject
        {
            Destroy(this.gameObject);
            if(!GameManager.instance.gameOver && this.gameObject.tag != "PepperCandy")
            //well There's a logical error here because our object
            //  may appear to be working after it has been destroyed.
            //  Unity deletes objects at the end of each frame,
            //  so it works perfectly. However, for clean code,
            //  we should write this before the destroy function :)
                GameManager.instance.DecreaseLives();
        }
    }
}
