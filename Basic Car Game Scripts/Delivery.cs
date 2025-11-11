using UnityEngine;

public class Delivery : MonoBehaviour
{

    bool hasPackage;
    [SerializeField] float delay = 0.1f;
    [SerializeField] Color32 hasPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 noPackageColor = new Color32(0, 0, 0, 0);

    SpriteRenderer spriterndr;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log(hasPackage);
        spriterndr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Ouch!");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("is it workin?");
        //This is for the package 
        if (collision.tag == "Package" && !hasPackage)
        {
            Debug.Log("Package picked up!");
            hasPackage = true;
            spriterndr.color = hasPackageColor; 
            Destroy(collision.gameObject, delay);
        }
        if (collision.tag == "Customer" && hasPackage)
        {
            Debug.Log("Package delivered!");
            collision.gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
            spriterndr.color = noPackageColor;
            hasPackage = false;
        }
    }
}
