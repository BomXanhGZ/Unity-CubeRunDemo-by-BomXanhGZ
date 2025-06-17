using UnityEngine;
using static GlobalSpace.GameUtilities;
using StaticAudioClips;


public class GameManagerIncrementCoin : MonoBehaviour
{
    [SerializeField] GameManagerData ref_GameManagerData;
    [SerializeField] AudioManagerHandlePlay ref_AudioManagerHandlePlay;


    private void Start()
    {
        CheckIsNotNull(ref_GameManagerData, "ref_GameManageData in GameManagerIncrementCoin");
        CheckIsNotNull(ref_AudioManagerHandlePlay, "ref_AudioManagerHandlePlay in GameManagerIncrementCoin");
    }

    public void IncrementCoin(GameObject _selectedObj)
    {
        //Item Type => Score...
        ref_GameManagerData.score_++;
        ref_AudioManagerHandlePlay.PlayerSFXAudio( SFXAudioClip.SFX_increment_coin_ );
        Debug.Log("score is: " + ref_GameManagerData.score_);
    }
}
