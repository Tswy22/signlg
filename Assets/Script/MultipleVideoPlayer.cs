using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class MultipleVideoPlayer : MonoBehaviour
{
    public RawImage[] rawImages; // ตัวแปรเก็บ RawImage ที่จะแสดงวิดีโอ
    public VideoClip[] videoClips; // ตัวแปรเก็บ VideoClip สำหรับแต่ละวิดีโอ

    private VideoPlayer[] videoPlayers; // ตัวแปรเก็บ VideoPlayer สำหรับแต่ละวิดีโอ

    void StartPlayingVideos()
{
    // กำหนดขนาดของ RenderTexture
    int videoWidth = 1920; // ปรับตามขนาดของวิดีโอ
    int videoHeight = 1080;

    videoPlayers = new VideoPlayer[rawImages.Length];
    for (int i = 0; i < rawImages.Length; i++)
    {
        GameObject videoPlayerObject = new GameObject("VideoPlayer" + i);
        videoPlayers[i] = videoPlayerObject.AddComponent<VideoPlayer>();

        // สร้าง RenderTexture ใหม่
        RenderTexture renderTexture = new RenderTexture(videoWidth, videoHeight, 0);
        renderTexture.name = "VideoRenderTexture" + i;

        // กำหนดให้ RawImage แสดงผลจาก RenderTexture ใหม่
        rawImages[i].texture = renderTexture;

        videoPlayers[i].source = VideoSource.VideoClip;
        videoPlayers[i].clip = videoClips[i];
        videoPlayers[i].targetTexture = renderTexture; // กำหนด RenderTexture ให้กับ VideoPlayer
        videoPlayers[i].Prepare();
        videoPlayers[i].Play();
    }
}


    void OnDestroy()
    {
        // หยุดการเล่นวิดีโอเมื่อเล่นเสร็จสิ้น
        foreach (var player in videoPlayers)
        {
            if (player != null)
            {
                player.Stop();
            }
        }
    }
}
