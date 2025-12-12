using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] float speed, jumpForce;
    [SerializeField] Transform bulletPos;
    [SerializeField] GameObject bullet;
    Rigidbody playerRB;
    bool isJump, onGround, fire;
    public bool inCloud;
    float moveX, moveZ;
    [SerializeField] float bulletSpeed = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Awake()
    {
        playerRB = GetComponent<Rigidbody>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveZ = Input.GetAxisRaw("Vertical");

        if (!isJump && onGround && Input.GetButtonDown("Jump"))
        {
            isJump = true;
        }

        if(!fire && !inCloud && Input.GetMouseButtonDown(0))
        {
            fire = true;
        }
        
    }

    void FixedUpdate()
    {
        playerRB.linearVelocity = new Vector3(moveX * speed, playerRB.linearVelocity.y, moveZ * speed);
        if (isJump && onGround)
        {
            onGround = false;
            Jump();
        }

        if (!inCloud && fire)
        {
            startFire();
            fire = false;
        }
    }
    void OnCollisionEnter(Collision other)
    {
        onGround = true;
        isJump = false;
        inCloud = false;
    }

    void Jump()
    {
        playerRB.AddForce(new Vector3(0, jumpForce, 0));
    }

    void startFire()
    {
        GameObject crBullet = Instantiate(bullet, bulletPos.position, bulletPos.rotation);
        Rigidbody bulletRb = crBullet.GetComponent<Rigidbody>();
        if (bulletRb)
        {
            bulletRb.linearVelocity = bulletPos.forward * bulletSpeed;
        }
        Destroy(crBullet, 0.5f);
    }

}
