

namespace GameSettings
{
    public static class NameScenes
    {
        public static string LEVEL_MENU_SCENE       = "LevelMenuScene";
        public static string HOME_SCENE             = "HomeScene";
        public static string SCENE_GAME_1           = "SceneGame1";
        public static string SCENE_GAME_2           = "SceneGame2";
        public static string SCENE_GAME_3           = "SceneGame3";
        public static string[] ALL_LEVEL_NAME_ARRAY = { SCENE_GAME_1, SCENE_GAME_2, SCENE_GAME_3 };
    }

    public static class Background
    {
        public const float BKGD_DRIFT_SPEED         = 1.0f;
        public const float BKDK_GAME_START_X        = 30.0f;
        public const float BKGD_GAME_START_Y        = -5.0f;
    }

    public static class Camera
    {
        public const float CAM_GAME_START_X         = 15f;
        public const float CAM_GAME_START_Y         = -5f;
        public const float CAM_FOLLOW_RATIO_X       = 0.35f;
    }

    public static class GamePhysics
    {
        public const float GRAVITY                  = 2.5f;
    }

    public static class Screen
    {
        public static float SCREEN_WIDTH            = 1920;
        public static float SCREEN_HEIGHT           = 1080;
    }

    public static class PlayerData
    {
        public const float PLY_START_XPOS           = 5.0f;
        public const float PLY_START_YPOS           = -8.0f;
        public const float PLAYER_SPEED             = 5f;
        public const float PLAYER_JUMP_VAL          = 15f;
        public const int   PLAYER_MAX_JUMP_STEP     = 2;
        public const int   PLAYER_FALL_JUMP_STEP    = 1;
        public const float PLY_FALL_VAL             = GamePhysics.GRAVITY * 2 / 3;
        public const float PLY_LOW_FALL_VAL         = GamePhysics.GRAVITY;
        public const int   PLAYER_PIECE_NUM         = 6;
        public const float IMPACT_BOOTS             = 3.0f;
    }

    public static class Map
    {
        public const int MAX_MAP_X                  = 100;
        public const int MAX_MAP_Y                  = 12;
        public const int MAX_GRD_TILE_TYPE          = 2;
    }

    public static class MapFilePaths
    {
        public const string path_map1               = "MapFiles/map1.txt";
        public const string path_map2               = "MapFiles/map2.txt";
    }
}
