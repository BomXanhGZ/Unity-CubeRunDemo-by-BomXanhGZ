using UnityEngine;
using static GlobalSpace.GameUtilities;
using static GameSettings.Background;


public class BackGroundHandleMove : MonoBehaviour
{
    private float drift_val_ = BKGD_DRIFT_SPEED;

    [SerializeField] private PlayerData ref_PlayerData;
    [SerializeField] private BackGroundData ref_BackGroundData;
    [SerializeField] private CameraData ref_CameraData;
    private Camera ref_Camera;
    private GameManagerData ref_GameManagerData;


    private void Start()
    {
        ref_Camera = Camera.main;
        ref_GameManagerData = GameManagerData.GetInstance;
        //set y_pos

        CheckIsNotNull(ref_Camera, "ref_Camera in BackGroundHandleMove");
        CheckIsNotNull(ref_GameManagerData, "ref_GameManagerData in BackGroundHandleMove");
        CheckIsNotNull(ref_PlayerData, "ref_PlayerData in BackGroundHandleMove");
        CheckIsNotNull(ref_BackGroundData, "ref_BackGroundData in BackGroundHandleMove");
        CheckIsNotNull(ref_CameraData, "ref_CameraData in BackGroundHandleMove");
    }

    private void FixedUpdate()
    {
        HandleMoveBkGround();
        HandleLoopBkGround();
    }

    void HandleMoveBkGround()
    {
        if (ref_GameManagerData.is_game_over_)
        { return; }

        if(!ref_CameraData.is_Cam_move_)
        { return; }

        Vector3 bkGd_move_x = new Vector3( (ref_PlayerData.move_x_ - drift_val_) * Time.deltaTime, 0, 0);
        transform.position += bkGd_move_x;
    }

    void HandleLoopBkGround()
    {
        if (this.transform.position.x <= ref_Camera.transform.position.x - ref_BackGroundData.bkgd_offSet_val_)
        {
            float new_pos_x = ref_Camera.transform.position.x + ref_BackGroundData.bkgd_offSet_val_;
            transform.position = new Vector3(new_pos_x, transform.position.y, transform.position.z);
        }
    }

}
