using UnityEngine;
using static GlobalSpace.GameUtilities;
using static GameSettings.Background;


public class BackGroundData : MonoBehaviour
{
    public float bkgd_offSet_val_ { private set; get; }
    [SerializeField] private Renderer ref_Renderer;


    void Start()
    {
        CheckIsNotNull(ref_Renderer, "ref_Renderer In BackGroundData ");

        SetData();
    }

    public void SetData()
    {
        float bkGd_width = ref_Renderer.bounds.size.x / 2;                      //Offset Value
        bkgd_offSet_val_ = bkGd_width / 2;

        Vector2 bkgd_start_pos = new Vector2(   BKDK_GAME_START_X,     //Start Pos
                                                BKGD_GAME_START_Y  );
        transform.position = bkgd_start_pos;
    }
}
