using System.Numerics;
using UnityEngine;
using UnityEngine.UIElements;

public class Car : MonoBehaviour
{
    Rigidbody2D tires;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    void Start()
    {
        //Getting the rigidbody component of a child (first founded) and then change it's properties 
        tires = GetComponentInChildren<Rigidbody2D>();
        tires.mass = 100;
        tires.gravityScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        //Rotation around itself / UnityEngine and System.Numerics namespaces has the same struct(Vector3)
        transform.Rotate(UnityEngine.Vector3.forward, 5f * Time.deltaTime);
        transform.Translate(UnityEngine.Vector3.right * 1f * Time.deltaTime, Space.World);//I don't want it to move in the direction of rotation; I want to move it in 'World' space
        if(transform.position.x >= 20)
        {
            transform.position = new UnityEngine.Vector3(1,2,0);
            transform.localScale += UnityEngine.Vector3.one; //every start brings extra growth
        }
    }
}
