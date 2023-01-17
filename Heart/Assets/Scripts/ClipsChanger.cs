using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class ClipsChanger : MonoBehaviour
{
    [SerializeField]
    VideoPlayer player;
    public void changeClipDelayed(VideoClip Clip,float time)
    {
        StartCoroutine(ChangeClipDelayed(Clip,time));
    }
    IEnumerator ChangeClipDelayed(VideoClip clip, float time)
    {
        player.clip = clip;
        player.Stop();
        player.Prepare();
        yield return new WaitForSeconds(time);
        player.Play();
    }
}
