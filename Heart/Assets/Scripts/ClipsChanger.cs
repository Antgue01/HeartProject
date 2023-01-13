using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class ClipsChanger : MonoBehaviour
{
    VideoPlayer player;
    [SerializeField]
    VideoClip[] clips;
    int index = 0;
    string path;
    // Start is called before the first frame update
    private void Awake()
    {
        //foreach (VideoClip video in clips)
        //{
        //    path = string.Concat(Application.persistentDataPath, "/", video.name,".mp4");
        //    Resources.LoadAsync<VideoClip>(path);
        //}
    }
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
    }
}
