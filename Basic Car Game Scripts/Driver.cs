using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField]float steerSpeed = 1f;
    [SerializeField] float moveSpeed = 0.1f;
    float boostSpeed = 10f;
    float slowSpeed = 2f;

    // Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "SpeedUp")
        {
            moveSpeed += boostSpeed;
            Debug.Log("weeeeeeeee!");
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (moveSpeed >= 5f)
        {
            moveSpeed -= slowSpeed;
        }
            Debug.Log("That hurts :(");    
    }
}
