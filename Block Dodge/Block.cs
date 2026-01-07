using UnityEngine;
public class Block : MonoBehaviour
{
    [SerializeField] string[] layerNames;
    SpriteRenderer layerz;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        layerz = GetComponent<SpriteRenderer>();
        int randomLayer = Random.Range(0, 3);
        layerz.sortingLayerName = layerNames[randomLayer];
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Ground")
        {
            GameManager.instance.score++;
            GameManager.instance.scoreText.text = GameManager.instance.score.ToString();
            Destroy(this.gameObject);
        }
    }

    
}
