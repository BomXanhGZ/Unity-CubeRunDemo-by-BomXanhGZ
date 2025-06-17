using UnityEngine;
using static GlobalSpace.GameUtilities;


public class IntroCubeHandleMove : MonoBehaviour
{
    const float LEFT_DEATH_ZONE = -9;
    const float RIGHT_DEATH_ZONE = 9;
    const float TOP_DEATH_ZONE = 2.5f;
    const float BOT_DEATH_ZONE = -1;
    const float SPEED = 7;
    const float BOUNCE_FORCE = 0.2f;
    const int MAX_COMEBACK_VAL = 200;
    public const int DIR_LEFT = -1;
    public const int DIR_RIGHT = 1;

    int comeback_count_ = 0;     //fram
    int Dir_ = 0;
    [SerializeField] Rigidbody2D rigidbody_;
    [SerializeField] IntroCubeHandleSprite ref_IntroCubeHandleSprite;


    private void Start()
    {
        CheckIsNotNull(ref_IntroCubeHandleSprite, "ref_IntroCubeHandleSprite in IntroCubeHandleMove");
        CheckIsNotNull(rigidbody_, "rigidbody in IntroCubeHandleMove");
        Dir_ = DIR_RIGHT;
    }

    private void Update()
    {
        UpdatePos();
        HandleMove();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if( col.collider.CompareTag("Ground") )
        {
            rigidbody_.AddForce( new Vector2(0, BOUNCE_FORCE), ForceMode2D.Impulse );
        }
    }

    void UpdatePos()
    {
        if(comeback_count_ < MAX_COMEBACK_VAL)          //Handle comeback
        {
            comeback_count_++;
            Debug.Log("comeback count is: " + comeback_count_);
            return;
        }
        else { comeback_count_ = 0;}

        Vector3 pos = transform.position;
        if(pos.x > LEFT_DEATH_ZONE && pos.x < RIGHT_DEATH_ZONE)
        { return; }

        if( g_random.Next(2) == 1 )                     //Random Direction & X_POS
        {
            Dir_ = DIR_RIGHT;
            pos.x = LEFT_DEATH_ZONE;
            ref_IntroCubeHandleSprite.UpdateSprite(Dir_);
        }
        else
        {
            Dir_ = DIR_LEFT;
            pos.x = RIGHT_DEATH_ZONE;
            ref_IntroCubeHandleSprite.UpdateSprite(Dir_);
        }

        pos.y = (float)g_random.NextDouble() * (TOP_DEATH_ZONE - BOT_DEATH_ZONE) + BOT_DEATH_ZONE;      //Random Y_POS


        rigidbody_.velocity = new Vector2(0, 0);            //Reset velocity
        this.transform.position = pos;                      //Update Pos
    }

    void HandleMove()
    {
        rigidbody_.velocity = new Vector2(SPEED * Dir_, rigidbody_.velocity.y);
    }
}
