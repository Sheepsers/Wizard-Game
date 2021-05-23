using UnityEngine;

public class BoundaryManagement : MonoBehaviour
{
    public Transform player;
    public GameObject boundary;

    private void Start()
    {
        boundary.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        boundary.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        boundary.SetActive(false);
    }
}
