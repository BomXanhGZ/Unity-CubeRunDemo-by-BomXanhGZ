using UnityEngine;
using static GlobalSpace.GameUtilities;


public class CameraHandleMove : MonoBehaviour
{

    [SerializeField] CameraData ref_CameraData;
    [SerializeField] PlayerData ref_PlayerData;


    private void Start()
    {
        CheckIsNotNull(ref_PlayerData, "ref_PlayerData in CameraHandleMove");
        CheckIsNotNull(ref_CameraData, "ref_CameraData in CameraHandleMove");
    }

    private void FixedUpdate()
    {
        CheckIsMove();

        if(ref_CameraData.is_Cam_move_)
        {
            BkGroundMoveVertical();
        }
        
    }

    void CheckIsMove()
    {
        float follow_point =    + transform.position.x
                                - ref_CameraData.cam_width_ * 0.5f
                                + ref_CameraData.cam_follow_val_;
        if (ref_PlayerData.transform.position.x >= follow_point)
        {
            ref_CameraData.is_Cam_move_ = true;
            return;
        }

        ref_CameraData.is_Cam_move_ = false;
    }

    void BkGroundMoveVertical()
    {
        Vector3 cam_Pos = transform.position;
        cam_Pos.x += ref_PlayerData.move_x_ * Time.deltaTime;

        transform.position = cam_Pos;
    }
}
