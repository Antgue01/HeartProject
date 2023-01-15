using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LayoutMngr : MonoBehaviour
{
    [SerializeField]
    Button[] _buttons;
    [SerializeField]
    AnimateShader[] _animateShaders;
    Dictionary<bool, string> activeToAnimation;
    private void Start()
    {
        activeToAnimation = new Dictionary<bool, string>();
        activeToAnimation.Add(true, "Fade In");
        activeToAnimation.Add(false, "Fade Out");
    }
    public void activate(bool active)
    {
        foreach (var button in _buttons)
        {
            button.interactable = active;
        }
        foreach (var shader in _animateShaders)
        {
            activeToAnimation.TryGetValue(active, out string anim);
            shader.Play(anim);
        }
    
    }

}
