using UnityEngine;
using static GlobalSpace.GameUtilities;


public class WinFlag : MonoBehaviour
{
    private GameManagerData ref_GameManagerData;


    private void Start()
    {
        ref_GameManagerData = GameManagerData.GetInstance;
        CheckIsNotNull(ref_GameManagerData, "ref_GameManagerData in WinFlag");
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if( col.gameObject.CompareTag("Player") )
        {
            ref_GameManagerData.is_win_game_ = true;
            Destroy(this.gameObject);
        }
    }
}
