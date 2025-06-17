using UnityEngine;
using UnityEngine.SceneManagement;
using static GlobalSpace.GameUtilities;


public class GameManagerData : SingletonObject<GameManagerData>
{
    public bool is_game_over_ { get; set; } = false;
    public bool is_win_game_ { set; get; } = false;
    public bool is_pause_ { set; get; } = false;
    public string current_scene_name { set; get; }
    public int score_ { set; get; } = 0;

    [SerializeField] private GameManagerWinGame ref_GameManagerWinGame;
    [SerializeField] private GameManagerGameOver ref_GameManagerGameOver;


    private void Awake()
    {
        InitSingletonObject();
    }

    void Start()
    {
        CheckIsNotNull(ref_GameManagerGameOver, "ref_GameManagerGameOver in GameManagerData ");
        CheckIsNotNull(ref_GameManagerWinGame, "ref_GameManagerGameOver in GameManagerData");

        //game data
        Time.timeScale = 1.0f;
        //selected_scene_name = "";
        current_scene_name = SceneManager.GetActiveScene().name;
    }

    private void Update()
    {
        //End Game
        if(is_game_over_)
        {ref_GameManagerGameOver.HandleGameOver();}

        if (is_win_game_)
        { ref_GameManagerWinGame.HandleWinGame();}
    }
}
