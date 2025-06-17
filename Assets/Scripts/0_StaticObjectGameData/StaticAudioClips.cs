
using UnityEngine;

namespace StaticAudioClips
{
    public static class BGMAudioClip
    {
        public static AudioClip BGM_home_;
        public static AudioClip BGM_level_menu_;
        public static AudioClip BGM_victory_;
        public static AudioClip BGM_lose_;
        public static AudioClip BGM_game1_;
        public static AudioClip BGM_game2_;
        public static AudioClip BGM_game3_;

        //...
    }

    public static class SFXAudioClip
    {
        //SFX_Player
        public static AudioClip SFX_player_destroyed_;
        public static AudioClip SFX_player_jump_;
        public static AudioClip SFX_player_is_landing_;
        public static AudioClip SFX_player_landed_from_fall_;

        //SFX_Mouse
        public static AudioClip SFX_click_mouse_;

        //SFX_Select_Item
        public static AudioClip SFX_increment_coin_;

        //Another...
    }


  /*InitAudioData*/
    public static class InitAudioData
    {
        const string BGM_PATH_ = "Audio/BkGdAudio/";
        const string SFX_PATH_ = "Audio/EffectAudio/";

        public static void LoadAudioClips()
        {
            //load method from:
            Debug.Log(SFX_PATH_ + "IncrementCoin.wav");
            SFXAudioClip.SFX_increment_coin_ = Resources.Load<AudioClip>(SFX_PATH_ + "IncrementCoin");
        }
    }
}