using Unity.VisualScripting;
using UnityEngine;

public class PrintToConsole : MonoBehaviour
{
    ColorChange color;//we wanna print the other script's message
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        color = GetComponent<ColorChange>();//we get the scipt component at the very beginning (it has to be public, otherwise u cannot got it)
    }

    void Start()
    {
        GameObject circle = GameObject.FindGameObjectWithTag("dummy");//playing with tags
        if (circle)//finds the first one (more complicated at the background)
        {
            Debug.Log("I found it!");
            Destroy(circle);
        }

        GameObject[] circles = GameObject.FindGameObjectsWithTag("dummy");//taking all the dummies
        //print(!circles.IsUnityNull());
        if (!circles.IsUnityNull())//if we found them all (it only gets the ACTIVE objects)
        {
            print(circles.Length);
            foreach (GameObject dummy in circles)
            {
                Destroy(dummy, 1f);
                Debug.Log("Destroyed!");
            }
        }
        Debug.Log("Hello?");
        Debug.Log(color.message);//we went to scipt, got the message and now it's time to print
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
