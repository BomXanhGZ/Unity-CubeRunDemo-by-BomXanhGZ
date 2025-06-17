using UnityEngine;
using static GlobalSpace.GameUtilities;
using static GameSettings.PlayerData;


public class PlayerHandleMove : MonoBehaviour
{
    public bool is_jump_key_down_    { set; get; } = false;
    public bool is_jump_key_up_      { set; get; } = false;
    public bool is_hold_jump_key_    { set; get; } = false;

    [SerializeField] PlayerData ref_PlayerData;
    [SerializeField] Rigidbody2D ref_PlayerRigidbody2D;


    private void Start()
    {
        CheckIsNotNull(ref_PlayerData, "ref_PlayerData in PlayerHandleMove");
        CheckIsNotNull(ref_PlayerRigidbody2D, "ref_PlayerRigidbody2D in PlayerHandleMove");
    }

    private void Update()
    {
        HandleInput();
    }

    private void FixedUpdate()
    {
        HandleMovePlayer();
    }

    void HandleInput()
    {
        if ( Input.GetKeyDown(KeyCode.Space) && ref_PlayerData.jump_state_ > 0 )        //key down
        {
            ref_PlayerData.jump_state_--;
            is_jump_key_down_ = true;
        }

        if( Input.GetKeyUp(KeyCode.Space) )           //key up
        {
            is_jump_key_up_ = true;
        }

        if( Input.GetKey(KeyCode.Space) )
        {
            is_hold_jump_key_ = true;
        }
        else
        {
            is_hold_jump_key_ = false;
        }

    }

    void HandleMovePlayer()
    {
        //Move-R
        transform.position += new Vector3(ref_PlayerData.move_x_ * Time.deltaTime, 0, 0);

        //Jump
        if (is_jump_key_down_)
        {
            ref_PlayerRigidbody2D.velocity = new Vector2(ref_PlayerRigidbody2D.velocity.x, PLAYER_JUMP_VAL);
            is_jump_key_down_ = false;
        }

        if ( is_jump_key_up_ && ref_PlayerData.is_on_ground_ == false)
        {
            ref_PlayerRigidbody2D.velocity = Vector2.up * ref_PlayerRigidbody2D.velocity.y * 0.5f;
            is_jump_key_up_ = false;
        }

        //Fall - Gravity
        if (is_hold_jump_key_ && ref_PlayerData.is_on_ground_ == false)
        {
            ref_PlayerRigidbody2D.velocity += Vector2.up * Physics2D.gravity.y * (PLY_FALL_VAL - 1) * Time.deltaTime;
        }
        else
        {
            ref_PlayerRigidbody2D.velocity += Vector2.up * Physics2D.gravity.y * (PLY_LOW_FALL_VAL - 1) * Time.deltaTime;
        }
    }
}
