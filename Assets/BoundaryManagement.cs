using UnityEngine;

public class BoundaryManagement : MonoBehaviour
{
    public Transform player;
    public GameObject boundary;

    private void Start()
    {
        boundary.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            boundary.SetActive(true);
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            boundary.SetActive(false);
        }
    }
}
