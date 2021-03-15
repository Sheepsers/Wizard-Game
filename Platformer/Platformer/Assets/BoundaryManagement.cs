using UnityEngine;

public class BoundaryManagement : MonoBehaviour
{
    BoxCollider2D managerBox;
    public Transform player;
    public GameObject boundary;

    // Start is called before the first frame update
    void Start()
    {
        managerBox = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(managerBox.bounds.min.x < player.position.x && player.position.x < managerBox.bounds.max.x && managerBox.bounds.min.y < player.position.y &&
           player.position.y < managerBox.bounds.max.y)
        {
            boundary.SetActive(true);
        }
        else
        {
            boundary.SetActive(false);
        }
    }
}
