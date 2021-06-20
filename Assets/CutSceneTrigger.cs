using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CutSceneTrigger : MonoBehaviour
{
    GameObject player;
    public CinemachineVirtualCamera cam;
    GameObject boss;
    public CinemachineVirtualCamera bosscam;
    public GameObject bossDoor;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        boss = GameObject.Find("Elder Boss");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            bossDoor.SetActive(true);
            player.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
            boss.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
            player.GetComponent<wizardAttack>().enabled = false;
            player.GetComponent<playerMove>().enabled = false;
            boss.GetComponent<ElderBossAI>().enabled = false;
            bosscam.Priority = 1;
            cam.Priority = 0;
            boss.GetComponent<Animator>().SetBool("isMoving", false);
            boss.GetComponent<Animator>().SetTrigger("Idle");
            Invoke("priority", 3f);
        }
    }

    void priority()
    {
        bosscam.Priority = 0;
        cam.Priority = 1;
        Invoke("reEnable", 1f);
    }

    void reEnable()
    {
        player.GetComponent<wizardAttack>().enabled = true;
        cam.Follow = player.transform;
        player.GetComponent<playerMove>().enabled = true;
        boss.GetComponent<ElderBossAI>().enabled = true;
        this.gameObject.SetActive(false);
    }

}
