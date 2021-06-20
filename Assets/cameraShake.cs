using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class cameraShake : MonoBehaviour
{
    CinemachineVirtualCamera cam;
    public static cameraShake Instance { get; private set; }
    float shakeTime;
    CinemachineBasicMultiChannelPerlin noise;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        cam = GetComponent<CinemachineVirtualCamera>();
        noise = cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }


    public void ShakeCamera(float length, float power)
    {
        noise.m_AmplitudeGain = power;
        shakeTime = length;
    }
    private void Update()
    {
        if(shakeTime > 0)
        {
            shakeTime -= Time.deltaTime;
        }
        if (shakeTime <= 0)
        {
            shakeTime = 0;
            noise.m_AmplitudeGain = 0;         
        }
    }

}
