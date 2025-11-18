using System.Linq;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    [HideInInspector] public string message = "Hello From Color Change Script!";//we hide it in the inspector, we wanna use it in the other script(printtoconsole)
    [SerializeField] GameObject[] circles;//taking arrays from the inspector
    [SerializeField] Color[] colors;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //each one changing color
        for (int i = 0; i < circles.Length; i++)
            circles[i].GetComponent<SpriteRenderer>().color = colors[i];
        //print(circles.Length);
        //Debug.Log(message);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
