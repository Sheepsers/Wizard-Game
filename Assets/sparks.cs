using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sparks : MonoBehaviour
{
    public ParticleSystem hitSparks;
    public float lifetime;
    public GameObject hitSparksObj;

    void Awake()
    {
        hitSparks.Play();
        lifetime = 20f;
    }

    // Update is called once per frame
    void Update()
    {
        if(lifetime == 0)
        {
            Destroy(hitSparksObj);
        }
    }
    
    private void FixedUpdate()
    {
        if(lifetime > 0)
        {
            lifetime = lifetime - 1;
        }
    }
}
