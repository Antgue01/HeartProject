using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LayoutMngr : MonoBehaviour
{
    [SerializeField]
    Button[] buttons;
    public void activate(bool active)
    {
        foreach (var button in buttons)
        {
            button.interactable = active;
            button.GetComponent<Image>().enabled = active;  
        }
    
    }

}
