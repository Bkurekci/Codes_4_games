using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float speed, amount;
    public int max, min, max3d;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Camera.main.orthographic)//(2d camera)
        {
            amount = Camera.main.orthographicSize; // amount shouldn't be 0 or lower 
            float value = Input.GetAxis("Mouse ScrollWheel");
            if(value != 0)
            {
                amount -= speed * value;//if the value is 0.1, then orthographic size gonna be smaller amount(which means it'll approach to the object), if it's negative value, then it's gonna be a bigger amount(which means it'll move away)
                // for example
                //amount = amount - 5 * 0.1 
                // amount = -0.5 decreasing every notch(approaching)
                //if it's negative value, then it's gonna be 0.5 increasing every notch (move away)
                //amount -= speed * value *  Time.deltaTime;//zoom out//zoom in it's not necessary to multiply it w deltaTime bcz it's really small amount of number like 0.1
                amount = Mathf.Clamp(amount, min, max);//Clamp method is controlling the 'amount' between min anc max values, if it's bigger or smaller than these values, it's gonna return fixed value (min or max  value)
                Camera.main.orthographicSize = amount;//setting the zoom in or out amount to the camera    
            }
        }else//for 3d camera (perspective)
        {
            amount = Camera.main.fieldOfView; 
            float value = Input.GetAxis("Mouse ScrollWheel");
            if(value != 0)
            {
                amount -= speed * value;
                Camera.main.fieldOfView = Mathf.Clamp(amount, min, max3d);
            }
            
        }
        

    }
}
