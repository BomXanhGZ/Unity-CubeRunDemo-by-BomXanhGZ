
using UnityEngine;
using static GameSettings.Background;


public class HomeBackGround : MonoBehaviour
{
    float cam_width_;
    float bkgd_width_;
    float x_move_ = BKGD_DRIFT_SPEED;
    float x_offset_;                                            // of 3*x_cam vs x_bkgd_size
                                                                // (/3) because using 3 bkground for looping


    private void Start()
    {
        cam_width_ = Camera.main.orthographicSize * 2f * Camera.main.aspect;
        bkgd_width_ = GetComponent<Renderer>().bounds.size.x;
        x_offset_     = bkgd_width_ - 3*cam_width_;
    }

    private void Update()
    {
        //move
        Vector3 move_val = new Vector3(x_move_, 0, 0);
        transform.position -= move_val * Time.deltaTime;

        //loop
        float loop_point = Camera.main.transform.position.x - (cam_width_ + x_offset_);
        if ( transform.position.x < loop_point )
        {
            transform.position = new Vector3(Camera.main.transform.position.x + cam_width_ + x_offset_ ,0,0);
        }
    }
}
