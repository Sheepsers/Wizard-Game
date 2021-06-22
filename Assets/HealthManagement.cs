using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthManagement : MonoBehaviour
{
    public float Health;
    public GameObject Healthbar;
    public float damageCooldown;
    Rigidbody2D rb;
    Material matWhite;
    Material matDefault;
    SpriteRenderer sr;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        matWhite = Resources.Load("WhiteFlash", typeof(Material)) as Material;
        matDefault = sr.material;
    }

    public void TakeDamage(float damage)
    {
        if(damageCooldown == 0)
        {
            sr.material = matWhite;
            Invoke("returnToDefault", 0.1f);
            Health -= damage;
            damageCooldown = 2;
            cameraShake.Instance.ShakeCamera(0.2f, 5f);
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
    void returnToDefault()
    {
        sr.material = matDefault;
    }
}
