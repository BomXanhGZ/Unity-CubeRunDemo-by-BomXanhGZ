using UnityEngine;
using static GlobalSpace.GameUtilities;


public class GameManagerGameOver : MonoBehaviour
{
    [SerializeField] GameManagerData ref_GameManagerData;
    [SerializeField] UIGameOver ref_UIGameOver;

    private void Start()
    {
        CheckIsNotNull(ref_GameManagerData, "ref_GameManagerData in GameManagerGameOver");
        CheckIsNotNull(ref_UIGameOver, "ref_UIGameOver in GameManagerGameOver");
    }

    public void HandleGameOver()
    {
        if (ref_GameManagerData.is_game_over_)
        {
            ref_UIGameOver.ShowGameOverUI();

            //...
        }
    }
}
