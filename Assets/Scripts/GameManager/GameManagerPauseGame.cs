using UnityEngine;
using static GlobalSpace.GameUtilities;


public class GameManagerPauseGame : MonoBehaviour
{
    [SerializeField] GameManagerData ref_GameManagerData;


    private void Start()
    {
        CheckIsNotNull(ref_GameManagerData, "ref_GameManagerData in GameManagerPauseGame");    
    }

    public void HandlePauseGame()
    {
        if(ref_GameManagerData.is_pause_)
        {
            Time.timeScale = 0;
        }

        else
        {
            Time.timeScale = 1.0f;
        }
    }
}
