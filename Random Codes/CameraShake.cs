using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    Vector3 originalPos;
    [SerializeField]float shakeRange, shakeTime;//we're gonna set the shake intensity and duration
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        originalPos = Camera.main.transform.position;//maintain the original position at the beginning
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(ShakeCamera());//every click makes the camera shake :D
        }
    }

    IEnumerator ShakeCamera()
    {
        float elapsedTime = 0;
        while (elapsedTime < shakeTime)//The shaking process should continue for a while, so we create a loop.
        {
            Vector3 tempPos = originalPos + shakeRange * Random.onUnitSphere;//The unit sphere is an abstract sphere centered at the point (0, 0, 0) with a radius of 1 unit. This expression rotates a random Vector3 position within this sphere. These values can never be greater than 1.
            tempPos.z = originalPos.z;//we don't want it move in the z axis so we keep this axis as original/or we can use onUnitCircle for this(usually using for 2d games)
            Camera.main.transform.position = tempPos; //a separate position for shaking in each frame
            elapsedTime += Time.deltaTime;//time is passing (fps)
            yield return null;//until the next frame
        }
        Camera.main.transform.position = originalPos;//When everything is finished, we reset the camera to its original position; otherwise, it will continue to shake with its new random position.
    }
}
