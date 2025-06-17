using UnityEngine;
using static GameSettings.Camera;


public class CameraData : MonoBehaviour
{
    public float cam_width_              { private set; get; } = 0;
    public float cam_height_             { private set; get; } = 0;
    public float cam_follow_val_         { private set; get; } = 0;
    public bool is_Cam_move_            = false;


    void Start()
    {
        CamSize();
        SetCamFollowDeathZone();
        SetCamStartPos();
    }

    void CamSize()
    {
        cam_height_ = Camera.main.orthographicSize * 2f;
        cam_width_ = cam_height_ * Camera.main.aspect;
    }

    void SetCamFollowDeathZone()
    {
        cam_follow_val_ = cam_width_ * CAM_FOLLOW_RATIO_X;
    }

    void SetCamStartPos()
    {
        Vector3 cam_start_pos = new Vector3(    CAM_GAME_START_X,
                                                CAM_GAME_START_Y,
                                                transform.position.z     );

        gameObject.transform.position = cam_start_pos;
    }
}
