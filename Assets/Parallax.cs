using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{

    public Transform[] background;
    float[] parallaxScales;
    public float smoothing = 1;

    Transform cam;
    Vector3 previousCamPos;

    private void Awake()
    {
        cam = GameObject.Find("Camera").transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        previousCamPos = cam.position;

        parallaxScales = new float[background.Length];

        for(int i = 0; i < background.Length; i++)
        {
            parallaxScales[i] = background[i].position.z * -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < background.Length; i++)
        {
            float parallax = (previousCamPos.x - cam.position.x) * parallaxScales[i];

            float backgroundTargetPosX = background[i].position.x + parallax;

            Vector3 targetPos = new Vector3(backgroundTargetPosX, background[i].position.y, background[i].position.z);

            background[i].position = Vector3.Lerp(background[i].position, targetPos, smoothing * Time.deltaTime);
        }
        previousCamPos = cam.position;
    }
}
