using UnityEngine;
using static GlobalSpace.GameUtilities;
using static GameSettings.NameScenes;
using static GameSettings.Screen;


public class SpawnPlayerLevelButton : MonoBehaviour
{
    const float VERTICAL_DISTANCE_BETWEEN_TWO_BUTTONS = 175.0f;
    const float HORIZONTAL_DISTANCE_BETWEEN_TWO_BUTTONS = 200.0f;

    [SerializeField] GameObject ref_PrefabPlayerLevelButton;
    //private PlayLevelButtonText ref_PlayLevelButtonText;


    private void Start()
    {
        CheckIsNotNull(ref_PrefabPlayerLevelButton, "ref_PrefabPlayerLevelButton in SpawnPlayerLevelButton");
        //CheckIsNotNull(ref_SetTextPlayLevelButton, "ref_SetTextPlayLevelButton in SpawnPlayerLevelButton");

        SpawnPlayLevelButton();
    }

    void SpawnPlayLevelButton()
    {
        float spawn_start_pos_x = -SCREEN_WIDTH * 0.5f + HORIZONTAL_DISTANCE_BETWEEN_TWO_BUTTONS;  //Set Spawn Start pos
        float spawn_start_pos_y = SCREEN_HEIGHT * 0.5f - VERTICAL_DISTANCE_BETWEEN_TWO_BUTTONS;
        Vector2 set_spawn_pos = new Vector2(spawn_start_pos_x, spawn_start_pos_y);

        for (int idx = 0; idx < ALL_LEVEL_NAME_ARRAY.Length; idx++)                                //Spawn with Horizontal
        {
            GameObject Prefab_Button = Instantiate(ref_PrefabPlayerLevelButton, this.transform);            //Spawn Child
            RectTransform rect_local_button = Prefab_Button.GetComponent<RectTransform>();                  //set Rect Child
            rect_local_button.anchoredPosition = set_spawn_pos;

            PlayLevelButton local_ref_PlayerLevelButton = Prefab_Button.GetComponent<PlayLevelButton>();    //Handle Button
            local_ref_PlayerLevelButton.SetDataPlayLevelButton(idx);    

            PlayLevelButtonText local_ref_PlayerLevelButtonTextSetter =                                     //Handle Text
                                        Prefab_Button.GetComponentInChildren<PlayLevelButtonText>();
            local_ref_PlayerLevelButtonTextSetter.SetTextPlayLevelButton(idx);                                 

            set_spawn_pos.x += VERTICAL_DISTANCE_BETWEEN_TWO_BUTTONS;                                       //Set next spawn Rect
        }
    }
}
