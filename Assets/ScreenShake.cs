using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    float shakeTimeRemaining, shakePower;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    private void LateUpdate()
    {
        if(shakeTimeRemaining > 0)
        {
            shakeTimeRemaining -= Time.deltaTime;

            float xShake = Random.Range(-1f, 1f) * shakePower;
            float yShake = Random.Range(-1f, 1f) * shakePower;
            transform.position += new Vector3(xShake, yShake, 0);
        }
    }

    public void StartShake(float length, float power)
    {
        shakeTimeRemaining = length;
        shakePower = power;

    }
}
