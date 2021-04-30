using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthManagement : MonoBehaviour
{
    public float Health;
    public GameObject Healthbar;
    public float damageCooldown;
    GameObject cameraShake;
    Rigidbody2D rb;

    private void Awake()
    {
        cameraShake = GameObject.FindGameObjectWithTag("Camera");
        rb = GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(float damage)
    {
        if(damageCooldown == 0)
        {
            Health -= damage;
            damageCooldown = 2;
            cameraShake.GetComponent<ScreenShake>().StartShake(0.2f, 0.2f);
        }
        Healthbar.GetComponent<healthBar>().ManageHealth(Health);
    }
    private void Update()
    {
        if(Health < 0)
        {
            Health = 0;
        }
        if(Health == 0)
        {
            SceneManager.LoadScene(0);
        }
    }
    private void FixedUpdate()
    {
        if(damageCooldown > 0)
        {
            damageCooldown -= Time.deltaTime;
        }
        else if(damageCooldown < 0)
        {
            damageCooldown = 0;
        }
    }
}
