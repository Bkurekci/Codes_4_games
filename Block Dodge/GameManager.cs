using System.Collections;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] GameObject cratePrefab;
    [SerializeField] Transform createSpot;
    [SerializeField] GameObject tapStart;
    [SerializeField] public TextMeshProUGUI scoreText;
    Vector2 newPos;
    float Timelapse;
    [HideInInspector] public int score = 0;
    [HideInInspector] public bool IsGameStarted;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if(instance == null)
            instance = this;
        else
            Destroy(gameObject);
        Timelapse = Time.deltaTime;
    }
    void Start()
    {
        newPos = createSpot.position;
        //Debug.LogFormat("X axis = {0}, Y axis = {1}", newPos.x, newPos.y);
        //StartCoroutine(CheckingTime());
        //InvokeRepeating("CreateCrate", 1f, 0.5f); I'm gonna use IEnumerator instead
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0) && !IsGameStarted)
        {
            IsGameStarted = true;
            tapStart.SetActive(false);
            StartCoroutine(FallingCrates());
        }
    }

    void CreateCrate()
    {
        float randomNum = Random.Range(2f, -2f);
        newPos.x = randomNum;
        Instantiate(cratePrefab, newPos, createSpot.rotation);
    }

    IEnumerator FallingCrates()
    {
        while(IsGameStarted)
        {
            CreateCrate();
            yield return new WaitForSeconds(1f);
        }
        StopAllCoroutines();
    }
}
