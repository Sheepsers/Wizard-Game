using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBar : MonoBehaviour
{

    public Slider slider;

    // Start is called before the first frame update
    public void ManageHealth(float Health)
    { 
        slider.value = Health;
    }

}
