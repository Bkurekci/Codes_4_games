using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] Color newColor;
    [SerializeField] AudioClip blop;
    AudioSource music;
    void Start()
    {
        music = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }

    void LateUpdate()
    {
        if(transform.position.y < -4)
            Destroy(this.gameObject);
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            GetComponent<MeshRenderer>().material.color = newColor;
            music.pitch = Random.Range(0.5f, 1.2f);//to produce unique thin and thick sounds for each ball
            music.PlayOneShot(blop);//play the sound for one time
        }
    }
}
