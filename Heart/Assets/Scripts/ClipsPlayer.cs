using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class ClipsPlayer : MonoBehaviour
{
    VideoPlayer player;
    [SerializeField]
    VideoClip[] clips;
    [SerializeField]
    UnityEvent onFinish;
    int index = 0;
    
    void Start()
    {

        player = GetComponent<VideoPlayer>();
        player.loopPointReached += changeClips;
        player.clip = clips[0];
    }

    void changeClips(VideoPlayer source)
    {
        if (index + 1 < clips.Length)
        {
            index++;
            source.clip = clips[index];
        }
        else
        {
            onFinish?.Invoke();
            player.loopPointReached-= changeClips; 
        } 
    }
}
