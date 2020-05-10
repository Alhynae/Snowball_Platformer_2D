using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SnowyHUD : MonoBehaviour
{
    public Sprite[] growthBarArray;
    public Sprite[] dashIconArray;
    public Image growthBar;
    public Image dashIcon;

    //Growthbar
    public void SetMaxGrowth(int maxGrowthState)
    {
        growthBar.sprite = growthBarArray[maxGrowthState];
    }    
    public void SetGrowth(int growthState) 
    { 
        growthBar.sprite = growthBarArray[growthState]; 
    }

    //DashIcon
    public void SetDashIcon(int dashReady) 
    { 
        dashIcon.sprite = dashIconArray[dashReady]; 
    }
}
