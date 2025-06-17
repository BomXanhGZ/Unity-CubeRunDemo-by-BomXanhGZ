using UnityEngine;
using static GlobalSpace.GameUtilities;


public class HeadLightTranRotation : MonoBehaviour
{
    const int DIR_LEFT = 1;
    const int DIR_RIGHT = -1;
    private int tran_dir_ = 0;          //tran direction of angle

    [SerializeField] private float death_angle_left_;
    [SerializeField] private float death_angle_right_;


    private void Start()
    {
        tran_dir_ = DIR_RIGHT;
    }

    private void Update()
    {
        UpdateRotation();
        //...
    }

    private void UpdateRotation()
    {
        float rand_val = (float)g_random.Next(25);          //tran value with c# random

        if (tran_dir_ == DIR_LEFT && transform.rotation.z >= death_angle_left_)         //Handle Direction
        {
            tran_dir_ = DIR_RIGHT;
        }
        else if (tran_dir_ == DIR_RIGHT && transform.rotation.z <= death_angle_right_)
        { 
            tran_dir_ = DIR_LEFT; 
        }

        float tran_val = rand_val * tran_dir_ * Time.deltaTime;
        transform.Rotate(0, 0, tran_val);
    }

    //Update Intensity
    //light color
    //...
}
