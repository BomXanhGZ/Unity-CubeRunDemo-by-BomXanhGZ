using UnityEngine;


public class GameManagerRunOutTimer : MonoBehaviour
{
    public float count_run_out_time_ { set; get; } = 0;
    const int RUN_OUT_TIMER = 3; //second
    const float SLOW_SPEED_VAL = 0.02f; //second


    public void HandleRunOutTime()
    {
        count_run_out_time_ += Time.deltaTime;

        if (count_run_out_time_ >= RUN_OUT_TIMER && Time.timeScale > 0)
        {
            Time.timeScale -= SLOW_SPEED_VAL;

            if (Time.timeScale < 0.2f)
            {
                Time.timeScale = 0;
                count_run_out_time_ = 0;
            }
        }
    }
}
