using UnityEngine;
using UnityEngine.InputSystem;

public class RayCastTest : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Input.touchCount);
        //if there is a touch and it's started
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == UnityEngine.TouchPhase.Began)//touchcount'un 0dan buyuk olmasi demek, ekranda bir veya daha fazla parmak basti demektir, phase (adi ustunde asama, hangi asamada) ise suanda basili mi oldugunu kontrol eder 
        {
            Debug.Log(Input.GetTouch(0).position);//ekranda dokundugumuz pixel koordinatini verir, bunu 3d duzleme gecirmeliyiz ancak o sekilde oyunumuzla etkilesimli dokunma mekanigi yapabiliriz
            Debug.Log(Camera.main.ScreenPointToRay(Input.GetTouch(0).position));//View Matrix + Projection Matrix is inverted, resulting in a direction vector. 
            ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);//stroing the position informations in a Ray value

            Debug.DrawRay(ray.origin, ray.direction * 30, Color.red);//From the camera position (origin), the distance is multiplied based on the direction (x, y, z) the ray will travel, and it is advanced 30 units from the direction.
            //The slope is measured from the starting point of the camera (origin -> direction).
            if(Physics.Raycast(ray, out hit ,Mathf.Infinity))//Physics.Raycast function shoots an invisible line (ray) onto the stage and returns a bool value (If the beam hits something, it says true (I hit it); if it goes into empty space, it says false (I didn't hit anything))
            //ray is the starting point and direction of the beam.
            //Pass an empty RaycastHit hit variable to the function. When the function runs and hits something, it fills (out) the hit variable with all the information about the object it hit (who, where, what surface) and returns it to you.
            //Mathf.Infinity: It means going on forever. If you had written 10f here, the laser would only go 10 units forward.
            {
                Destroy(hit.transform.gameObject);
                //   hit: Collision information.
                // .transform: The position of the object we collided with.
                // .gameObject: The main object to which that transform is attached.
            }
        }   
    }
}
