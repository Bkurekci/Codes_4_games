using Unity.Mathematics;
using UnityEngine;

public class Instantiation : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] Material[] materials;
    [SerializeField] GameObject FirePos;//taking the muzzle position (for optimization)
    [SerializeField] float bulletSpeed = 5f;
    Transform muzzlePos;
    bool canFire = true;
    float fCountdown = 0.5f;

    //Color32 bulletColor;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Awake()
    {
        if(FirePos)
            muzzlePos = FirePos.transform;

        materials = Resources.LoadAll<Material>("Materials");//Taking the colors from the asset field
        //we cannot and shouldn't take directly from the assets because of Dead Asset Stripping
        //which is Unity scans the scene during compilation, checking, “Has this material been
        //  used on an object in the scene?” If it has been used, it packages it as an .exe.
        // If it hasn't been used, it discards it. To avoid inflating the size of the .exe file, it does not include it in the game.
        //If we place the material file in Resources, we are essentially telling Unity,
        //  “Package this folder and index it in memory; it will be called by the code.”
        //  That's why the Resources.Load command only looks in the Resources folder.
        if (materials.Length == 0)
        {
            Debug.LogError("Fatal Error: Materials folder is empty or cannot found!");
        }else
            Debug.Log($"{materials.Length} materials loaded.");
    
    }
    void Start()
    {
        InvokeRepeating("ClassicBullet", 2f, 1f);
    }

    // Update is called once per frame
    void Update(){
        
        if (FirePos && canFire && Input.GetMouseButtonDown(0))
        {
            canFire = false;
            BulletMaker();
            Invoke("resetCooldown", fCountdown);
        }else if (Input.GetKeyDown(KeyCode.Space))
        {
            CancelInvoke();
            CancelInvoke("BulletMaker");
        }
    
    }

    void BulletMaker()
    {
        int randomNum = UnityEngine.Random.Range(0, materials.Length);//picks a random number between 0 - 3 (for example) (includes 0 but not 3)
        //instantiating the bullet from the muzzle position and we don't want it move wrong or weird, so we made it move according to the muzzle position
        GameObject newBullet = Instantiate(bullet, muzzlePos.position, muzzlePos.rotation);
        
        //we're gonna change the bullet's color and give it a force for its launch
        Renderer bulletRend = newBullet.GetComponent<Renderer>();
        Rigidbody2D rb = newBullet.GetComponent<Rigidbody2D>();
        
        if (bulletRend && rb)
        {
            bulletRend.material = materials[randomNum];
            rb.linearVelocity = muzzlePos.right * bulletSpeed;
        }
            Destroy(newBullet, 1f);
    }

    void resetCooldown()
    {
        canFire = true;
    }

    void ClassicBullet()
    {
        GameObject bulletClas = Instantiate(bullet, transform.position, Quaternion.identity);
    }


}

