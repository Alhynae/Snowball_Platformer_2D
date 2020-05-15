using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Sprite[] growthBarArray;
    public Sprite[] dashIconArray;
    public Image growthBar;
    public Image dashIcon;
    public Image health30;
    public Image health60;

    public Slider Health;

    //Growthbar  
    public void SetGrowth(float _Health) 
    { 
        Health.value = _Health;

        if (_Health < 30)
        {
            health30.enabled = false;
            health60.enabled = false;
        } else if (_Health > 30 && _Health < 60)
        {
            health30.enabled = true;
            health60.enabled = false;
            
            
        } else if (_Health > 60)
        {
            health30.enabled = true;
            health60.enabled = true;
        }
    }

    //DashIcon
    public void SetDashIcon(int dashReady) 
    { 
        dashIcon.sprite = dashIconArray[dashReady]; 
    }
}
