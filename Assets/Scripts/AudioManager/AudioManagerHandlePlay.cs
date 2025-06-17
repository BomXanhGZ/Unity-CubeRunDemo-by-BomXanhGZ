

using UnityEngine;
using static GlobalSpace.GameUtilities;


public class AudioManagerHandlePlay : MonoBehaviour
{
    [SerializeField] AudioManagerData ref_AudioManagerData;


    private void Start()
    {
         CheckIsNotNull(ref_AudioManagerData, "ref_AudioManagerData is AudioManagerHandlePlay");
    }

    public void PlayBGMAudio(AudioClip _BGM_audio)
    {
        if(!_BGM_audio)
        {
            Debug.LogError("Null At: " + _BGM_audio.name);
        }

        if (!ref_AudioManagerData.BGM_channel_1_.isPlaying)
        {
            ref_AudioManagerData.BGM_channel_1_.clip = _BGM_audio;
            ref_AudioManagerData.BGM_channel_1_.loop = false;
            ref_AudioManagerData.BGM_channel_1_.Play();

            return;
        }
        else if (!ref_AudioManagerData.BGM_channel_2_.isPlaying)
        {
            ref_AudioManagerData.BGM_channel_2_.clip = _BGM_audio;
            ref_AudioManagerData.BGM_channel_2_.loop = false;
            ref_AudioManagerData.BGM_channel_2_.Play();

            return;
        }

        Debug.LogError("No audio Channel is Available");
    }

    public void PlayerSFXAudio(AudioClip _SFX_audio)
    {
        if(!_SFX_audio)
        {
            Debug.LogError("Null At: " + _SFX_audio.name);
            return;
        }

        ref_AudioManagerData.SFX_channel_.PlayOneShot(_SFX_audio);
    }
}
