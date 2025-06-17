using UnityEngine;
using static GameSettings.PlayerData;


class PlayerData : MonoBehaviour
{
    public float    move_x_       { set; get; }   = PLAYER_SPEED;
    public bool     is_on_ground_ { set; get; }   = false;
    public int      jump_state_   { set; get; }   = 0;
}