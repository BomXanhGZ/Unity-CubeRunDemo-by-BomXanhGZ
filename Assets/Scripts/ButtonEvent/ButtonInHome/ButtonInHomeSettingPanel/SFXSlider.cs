

using UnityEngine;
using UnityEngine.UI;
using static GlobalSpace.GameUtilities;


public class SFXSlider : MonoBehaviour
{
    AudioManagerData ref_AudioManagerData;
    [SerializeField] Slider ref_SFXSlider;


    private void Start()
    {
        ref_AudioManagerData = AudioManagerData.GetInstance;

        CheckIsNotNull(ref_AudioManagerData, "ref_AudioManagerData in SFXSlider");
        CheckIsNotNull(ref_SFXSlider, "ref_SFXSlider in SFXSlider");

        ref_SFXSlider.onValueChanged.AddListener( SetSFXVolume );                   //sub change event
    }

    public void SetSFXVolume(float _volume)
    {
        ref_AudioManagerData.SFX_channel_.volume = _volume;


        //debug
        Debug.Log("SFX volume is: " + ref_AudioManagerData.SFX_channel_.volume);
    }
}
