using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class teacherScript : MonoBehaviour
{
    public workerClass workerClassFile;
    public GameObject videoPlayer;
    public GameObject teacher;
    public VideoClip slide2;
    public VideoClip slide3;
    public VideoClip slide4;
    public VideoClip slide5;
    public VideoClip slide6;
    public VideoClip slide7;
    public VideoClip slide8;

    int slide;
    public void nextSlide()
    {
        if (slide < 8)
        {
            switch (slide)
            {
                case 1:
                    videoPlayer.GetComponent<VideoPlayer>().clip = slide2;
                    break;
                case 2:
                    videoPlayer.GetComponent<VideoPlayer>().clip = slide3;
                    break;
                case 3:
                    videoPlayer.GetComponent<VideoPlayer>().clip = slide4;
                    break;
                case 4:
                    videoPlayer.GetComponent<VideoPlayer>().clip = slide5;
                    break;
                case 5:
                    videoPlayer.GetComponent<VideoPlayer>().clip = slide6;
                    break;
                case 6:
                    videoPlayer.GetComponent<VideoPlayer>().clip = slide7;
                    break;
                case 7:
                    videoPlayer.GetComponent<VideoPlayer>().clip = slide8;
                    break;
            }
            teacher.transform.GetChild(2 + slide).gameObject.SetActive(false);
            teacher.transform.GetChild(3 + slide).gameObject.SetActive(true);
            slide++;
        }
    }

    public void close()
    {
        workerClassFile.letsStart = true;
        this.gameObject.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        slide = 1;
        this.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
