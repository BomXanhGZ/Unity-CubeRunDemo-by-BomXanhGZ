using UnityEngine;
using static GlobalSpace.GameUtilities;


public class CoinStateUpDate : MonoBehaviour
{
    const int ROTATION_SPEED = 5;
    float x_scale_update_ = 0;
    GameManagerIncrementCoin ref_GameManagerIncrementCoin;


    private void Start()
    {
        ref_GameManagerIncrementCoin = GameManagerData.GetInstance.GetComponent<GameManagerIncrementCoin>();
        CheckIsNotNull(ref_GameManagerIncrementCoin, "ref_ameManagerIncrementCoin in CoinStateUpDate");   
    }

    void Update()
    {
        x_scale_update_ += Time.deltaTime * ROTATION_SPEED;
        transform.localScale = new Vector3(x_scale_update_, transform.localScale.y, transform.localScale.z);

        if (x_scale_update_ >= 1)
        { x_scale_update_ = -1; }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if( col.gameObject.CompareTag("Player") )
        {
            ref_GameManagerIncrementCoin.IncrementCoin(this.gameObject);

            if (CheckIsNotNull(this.gameObject, "this.GameObject in CoinStateUpdate"))
            { Destroy(this.gameObject); }
        }
    }
}
