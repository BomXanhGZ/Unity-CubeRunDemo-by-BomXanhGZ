

using UnityEngine;
using UnityEngine.UI;
using static GlobalSpace.GameUtilities;


public class MusicSlider : MonoBehaviour
{
    AudioManagerData ref_AudioManagerData;
    [SerializeField] Slider ref_MusicSlider;


    private void Start()
    {
        ref_AudioManagerData = AudioManagerData.GetInstance;

        CheckIsNotNull(ref_AudioManagerData, "ref_AudioManagerData in MusicSlider");
        CheckIsNotNull(ref_MusicSlider, "ref_MusicSlider in MusicSlider");

        ref_MusicSlider.onValueChanged.AddListener( SetMusicVolume );           //sub change event 
    }

    public void SetMusicVolume(float _volume)
    {
        ref_AudioManagerData.BGM_channel_1_.volume = _volume;
        ref_AudioManagerData.BGM_channel_2_.volume = _volume;


        //debug
        Debug.Log("GameMusic Channel 1 is: " + ref_AudioManagerData.BGM_channel_1_.volume);
        Debug.Log("GameMusic Channel 2 is: " + ref_AudioManagerData.BGM_channel_2_.volume);
    }
}
