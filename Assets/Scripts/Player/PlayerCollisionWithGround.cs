using UnityEngine;
using static GlobalSpace.GameUtilities;
using static GameSettings.PlayerData;


public class PlayerCollisionWithGround : MonoBehaviour
{

    const float COL_VAL = 0.85f;
    [SerializeField] PlayerData ref_PlayerData;
    [SerializeField] PlayerHandleDeath ref_PlayerHandleDeath;


    private void Start()
    {
        CheckIsNotNull(ref_PlayerData, "ref_PlayerData in PlayerCollisionWithGround");
        CheckIsNotNull(ref_PlayerHandleDeath, "ref_PlayerHandleDeath in PlayerCollisionWithGround");
    }

    private void OnCollisionStay2D(Collision2D col)
    {
        ContactPoint2D[] l_contacts = col.contacts;
        Vector2 colDir = new Vector2(0, 0);
        foreach (var contact in l_contacts)
        {
            float contact_length = Mathf.Sqrt(contact.normal.x * contact.normal.x + contact.normal.y * contact.normal.y);
            Vector2 normalize_contact = new Vector2(contact.normal.x / contact_length, contact.normal.y / contact_length);  // chuan hoa tung vector
            colDir += normalize_contact;    //tong vector da chuan hoa
        }

        colDir = colDir.normalized;     //chuan hoa lai vector tong cua cac vector da chuan hoa

        if (Mathf.Abs(colDir.x) >= COL_VAL || colDir.y <= -COL_VAL)
        {
            ref_PlayerHandleDeath.HandleDeath(colDir);
            return;
        }
        else
        {
            ref_PlayerData.is_on_ground_ = true;
            ref_PlayerData.jump_state_ = PLAYER_MAX_JUMP_STEP;
        }
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.rigidbody.CompareTag("Ground"))
        {
            ref_PlayerData.is_on_ground_ = false;
            ref_PlayerData.jump_state_ = PLAYER_FALL_JUMP_STEP;
        }


        else
        { return; }
    }

    #region  another - test
    /*
      void HandleColByRayCasts()
        {
            float offset_rayCast        = 0.02f;
            Vector2 ply_size = GetComponent<BoxCollider2D>().size ;
            Vector2 l_pos = transform.position;

            Vector2 bottomStart = new Vector2(l_pos.x + offset_rayCast - ply_size.x * 0.5f, l_pos.y - offset_rayCast * 2 - ply_size.y * 0.5f);
            Vector2 topStart = new Vector2(l_pos.x + offset_rayCast - ply_size.x * 0.5f, l_pos.y + offset_rayCast + ply_size.y * 0.5f);
            Vector2 leftStart = new Vector2(l_pos.x - offset_rayCast - ply_size.x * 0.5f, l_pos.y - offset_rayCast + ply_size.y * 0.5f);
            Vector2 rightStart = new Vector2(l_pos.x + offset_rayCast + ply_size.x * 0.5f, l_pos.y - offset_rayCast + ply_size.y * 0.5f);

            float rayLength = ply_size.x - offset_rayCast * 5;
            float rayHeight = ply_size.y - offset_rayCast * 5;

            RaycastHit2D bottom = Physics2D.Raycast(bottomStart, Vector2.right, rayLength);
            RaycastHit2D top = Physics2D.Raycast(topStart, Vector2.right, rayLength);
            RaycastHit2D left = Physics2D.Raycast(leftStart, Vector2.down, rayHeight);
            RaycastHit2D right = Physics2D.Raycast(rightStart, Vector2.down, rayHeight);

            Debug.DrawRay(bottomStart, Vector2.right * rayLength, Color.green);
            Debug.DrawRay(topStart, Vector2.right * rayLength, Color.green);
            Debug.DrawRay(leftStart, Vector2.down * rayHeight, Color.green);
            Debug.DrawRay(rightStart, Vector2.down * rayHeight, Color.green);



            if (top.collider?.CompareTag("Ground") == true )
            {
                HandleDeath(Direction.Dir_UP);
                return;
            }

            else if (left.collider?.CompareTag("Ground") == true)
            {
                HandleDeath(Direction.Dir_LEFT);
                return;
            }

            else if (right.collider?.CompareTag("Ground") == true )
            {
                HandleDeath(Direction.Dir_RIGHT);
                return;
            }

            if (bottom.collider?.CompareTag("Ground") == true)
            {
                is_on_ground_ = true;
                jump_state_ = GameData.PLAYER_MAX_JUMP_STEP;
            }
        }
     */
    #endregion
}
