using UnityEngine;
using static GlobalSpace.GameUtilities;


public class HomeIntroGroundHandleMove : MonoBehaviour
{
    const float X_MOVE_SPEED = 3.5f;
    float x_start;
    [SerializeField] HomeIntroGroundCreator ref_HomeIntroGroundCreator;


    private void Start()
    {
        CheckIsNotNull(ref_HomeIntroGroundCreator, "ref_HomeIntroGroundCreator in HomeIntroGroundHandleMove");
        x_start = ref_HomeIntroGroundCreator.x_start_;
    }

    private void Update()
    {
        foreach (var tile in ref_HomeIntroGroundCreator.Tiles_)             
        {
            tile.transform.position -= new Vector3(X_MOVE_SPEED * Time.deltaTime, 0, 0);                //HanldeMove
                                                                                                    
            if(tile.transform.position.x < (x_start - ref_HomeIntroGroundCreator.x_tile_size_) )    //HanldeLoop                              
            {
                Vector3 update = new Vector3(ref_HomeIntroGroundCreator.tile_num_ * ref_HomeIntroGroundCreator.x_tile_size_
                                            ,0,0);

                tile.transform.position += update;
            }
        }
    }
}
