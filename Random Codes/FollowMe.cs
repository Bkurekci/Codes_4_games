using UnityEngine;

public class FollowMe : MonoBehaviour
{
    [SerializeField] Transform target;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPos = new Vector3(target.position.x, transform.position.y, target.position.z);
        if(target != null)
        {
            transform.LookAt(targetPos);//lock the current object's z axis to the target's center position (y axis not included)
        }
    }
}
