using UnityEngine;
using static GlobalSpace.GameUtilities;


public class PlayerHandleDeath : MonoBehaviour
{
    [SerializeField] PlayerData ref_PlayerData;
    [SerializeField] GameCT_DestroyPlayerEffect ref_GameCT_DestroyPlayerEffect;
    private GameManagerData ref_GameManagerData;

    private void Start()
    {
        ref_GameManagerData = GameManagerData.GetInstance;

        CheckIsNotNull(ref_PlayerData, "ref_PlayerData in PlayerHandleDeath");
        CheckIsNotNull(ref_GameManagerData, "ref_GameManagerData in PlayerHandleDeath");
        CheckIsNotNull(ref_GameCT_DestroyPlayerEffect, "ref_GameCT_DestroyPlayerEffect in PlayerHandleDeath");
    }

    public void HandleDeath( Vector2 impDir_ = new Vector2() )
    {
        ref_PlayerData.move_x_ = 0;
        GetComponent<Renderer>().enabled = false;
        ref_GameManagerData.is_game_over_ = true;
        ref_GameCT_DestroyPlayerEffect.ShowDestroyPlayerEffect(impDir_, this.transform.position);
        gameObject.SetActive(false);
    }
}
