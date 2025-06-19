using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;


public class NewTryVideo : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    void Start()
    {
    videoPlayer.url = System.IO.Path.Combine(Application.streamingAssetsPath, "Untitled Project.mp4");
    }

}