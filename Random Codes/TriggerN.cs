using UnityEngine;
using UnityEngine.AI;
public class TriggerN : MonoBehaviour
{
    
    [SerializeField] GameObject playerScript;
    PlayerControls PlayerS;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerS = playerScript.GetComponent<PlayerControls>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //playin w triggers
    void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
            PlayerS.inCloud = true;
    }


    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
            PlayerS.inCloud = false;
    }
}
