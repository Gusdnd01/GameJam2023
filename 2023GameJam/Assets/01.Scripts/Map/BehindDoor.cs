using UnityEngine;

public class BehindDoor : MonoBehaviour
{
    private void Start()
    {
        gameObject.transform.GetChild(4).gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)    
    {
        if(other.gameObject.CompareTag("Player"))
        {
            gameObject.transform.GetChild(4).gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            gameObject.transform.GetChild(4).gameObject.SetActive(false);
        }
    }
}
