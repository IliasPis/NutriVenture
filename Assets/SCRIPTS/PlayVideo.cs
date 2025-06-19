using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PlayVideo : MonoBehaviour
{
    [SerializeField] string videoFileName;

    void Start()
    {
        playvideoplay();
    }

    public void playvideoplay()

    {

     VideoPlayer videoPlayer = GetComponent<VideoPlayer>();

    if (videoPlayer)
    {
        string videopath = System.IO.Path.Combine(Application.streamingAssetsPath, videoFileName);
        Debug.Log(videopath);
        videoPlayer.url = videopath;
        videoPlayer.Play();

    }
    }
}