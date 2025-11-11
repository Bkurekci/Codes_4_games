using UnityEngine;
using UnityEngine.UIElements;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] GameObject car;
    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = car.transform.position + new Vector3(0, 0, -10);
    }
}
