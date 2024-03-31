using UnityEngine;
using UnityEngine.Video;

public class VideoPlayerka : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    void Start()
    {
        // ตรวจสอบว่า Video Player ไม่เท่ากับ null
        if (videoPlayer != null)
        {
            // เรียกใช้เมธอด Play เพื่อเริ่มเล่นวิดีโอ
            videoPlayer.Play();
        }
    }
}
