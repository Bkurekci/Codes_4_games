using UnityEngine;

public class ColliderN : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //playing w colliders
    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Enemy")
        {
            Debug.Log("hit!");
            Destroy(this.gameObject); Destroy(col.gameObject);
        }
    }
}
