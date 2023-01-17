using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class LayoutMngr : MonoBehaviour
{
    [SerializeField]
    Animator[] _buttons;
    [SerializeField]
    AnimateShader[] _animateShaders;
    [SerializeField]
    ClipsChanger _clipsChanger;
    float buttonMaxTime;
    float shaderMaxTime;
    private void Start()
    {
        buttonMaxTime = 0;
        shaderMaxTime = _animateShaders[0].getLength("Fade In",0);
        foreach (AnimationClip clip in _buttons[0].runtimeAnimatorController.animationClips)
        {
            float len = clip.length;
            if (len > buttonMaxTime)
                buttonMaxTime = len;
        }
       
    }
    public void activate()
    {

        foreach (AnimateShader shader in _animateShaders)
        {
            shader.Play("Fade In");
        }
        StartCoroutine(PlayButton(shaderMaxTime,"Fade In"));
    }
    public void deActivate()
    {
        foreach (Animator button in _buttons)
        {
            button.Play("Fade Out");
            
        }
        StartCoroutine(PlayShader(buttonMaxTime, "Fade Out"));

    }
    IEnumerator PlayButton(float waitTime,string anim)
    {
        yield return new WaitForSeconds(waitTime);
        foreach (Animator button in _buttons)
        {
            button.Play(anim);
        }
    }
    IEnumerator PlayShader(float waitTime, string anim)
    {
        yield return new WaitForSeconds(waitTime);
        foreach (AnimateShader shader in _animateShaders)
        {
            shader.Play(anim);
        }
    }
    public void ChangeClips(VideoClip clip)
    {
        _clipsChanger.changeClipDelayed(clip,shaderMaxTime + buttonMaxTime);
    }


}
