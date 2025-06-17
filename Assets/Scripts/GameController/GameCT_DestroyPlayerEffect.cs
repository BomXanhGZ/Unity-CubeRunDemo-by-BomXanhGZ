using UnityEngine;
using static GlobalSpace.GameUtilities;
using static GameSettings.PlayerData;


public class GameCT_DestroyPlayerEffect : MonoBehaviour
{

    [SerializeField] private GameObject[] ref_pieces = new GameObject[PLAYER_PIECE_NUM];
    [SerializeField] private Sprite[] ref_sprites = new Sprite[PLAYER_PIECE_NUM];


    private void Start()
    {
        for (int i = 0; i < ref_pieces.Length; i++) 
        { CheckIsNotNull(ref_pieces[i], " piece in GameCT_DestroyPlayerEffect at: " + i); }

        for (int i = 0; i < ref_sprites.Length; i++)
        { CheckIsNotNull(ref_sprites[i], " sprite in GameCT_DestroyPlayerEffect at: " + i); }
    }

    public void ShowDestroyPlayerEffect(Vector2 impDir_, Vector2 ply_pos)
    {
        Debug.Log("imp dir: " + impDir_);
        bool is_col_HoTal = Mathf.Abs(impDir_.x) > Mathf.Abs(impDir_.y) ? true : false;
        float imp_boots = IMPACT_BOOTS;

        for (int i = 0; i < ref_pieces.Length; i++)
        {
            var l_piece = Instantiate(ref_pieces[i], ply_pos, Quaternion.identity);         //spawn pice
            l_piece.GetComponent<SpriteRenderer>().sprite = ref_sprites[i];                 //set sprite
            float rand_force = ((float)g_random.NextDouble() * imp_boots * 2) - imp_boots;  //rand focre

            Vector2 bounce_force = new Vector2(impDir_.x * imp_boots,                       //focre
                                                impDir_.y * imp_boots);
            if (is_col_HoTal)
            {
                bounce_force.y += rand_force;       //col horizontal: y <=> 0
            }
            else
            {
                bounce_force.x += rand_force;       //col vertical: x <=> 0 
            }

            l_piece.GetComponent<Rigidbody2D>().AddForce(bounce_force, ForceMode2D.Impulse);    //Add fiocre
        }
    }
}
