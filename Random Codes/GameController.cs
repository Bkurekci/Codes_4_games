using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;//this one is new :D If you encounter an Ambiguous Reference error, you can specify the keyword you want to use from the beginning.

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject ball;
    Vector3 mousePos;
    float maxX, maxZ;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("SpawnBall", 1f, .5f);
        //SpawnBall();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetButtonDown("Fire1"))
        //{
            //mousePos = Input.mousePosition;
            //mousePos.z = 10f;
            //SpawnBall(mousePos);  
        //}
    }

    void SpawnBall()
    {
        float maxX = Random.Range(-5f, 5f);
        float maxZ = Random.Range(4f, -2f);
        Vector3 spawnPoint = new Vector3(maxX, transform.position.y, maxZ);
        Instantiate(ball, spawnPoint, Quaternion.identity);
    }
    // void SpawnBall(Vector3 mousePos)
    // {
    //     Instantiate(ball, Camera.main.ScreenToWorldPoint(mousePos), quaternion.identity);        
    // }takes the mouse position
}
