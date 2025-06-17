
using UnityEngine;
using StaticAudioClips;
using static GlobalSpace.GameUtilities;


public class AudioManagerData : SingletonObject<AudioManagerData>
{
    public AudioSource SFX_channel_;
    public AudioSource BGM_channel_1_;
    public AudioSource BGM_channel_2_;


    private void Awake()
    {
        InitSingletonObject();

        CheckIsNotNull(SFX_channel_, "SFX_channel_ in AudioManagerData");
        CheckIsNotNull(BGM_channel_1_, "BGM_channel_1_ in AudioManagerData");
        CheckIsNotNull(BGM_channel_2_, "BGM_channel_2_ in AudioManagerData");
    }

    private void Start()
    {
        InitAudioData.LoadAudioClips();
    }
}
