
using UnityEngine;
using static GlobalSpace.GameUtilities;


public class HomeIntroGroundCreator : MonoBehaviour
{
    public int      tile_num_;
    public float    x_tile_size_;
    public float    x_start_;
    float           y_start_ = -3;

    public GameObject[] Tiles_;
    [SerializeField] GameObject ref_PreFabGround;


    private void Awake()
    {
        SetXStart();
    }

    private void Start()
    {
        SetGroundSize();
        SetTileNum();
        SpawnGroundTile();
    }

    void SpawnGroundTile()
    {
        if (!CheckIsNotNull(ref_PreFabGround, "ref_PreFabGround in HomeIntroGroundCreator"))
        { return; }

        Tiles_ = new GameObject[tile_num_];
        for (int i = 0; i < tile_num_; i++)
        {
            GameObject ground = Instantiate(ref_PreFabGround, new Vector2 (x_start_ + x_tile_size_ * i, y_start_),
                                            Quaternion.identity, this.transform);
            Tiles_[i] = ground;
        }
    }

    void SetGroundSize()
    {
        GameObject l_Tile = Instantiate(ref_PreFabGround);
        x_tile_size_ = l_Tile.GetComponent<Renderer>().bounds.size.x;

        Destroy( l_Tile );
    }

    void SetTileNum()
    {
        float cam_width = Camera.main.orthographicSize * 2f * Camera.main.aspect;
        tile_num_ = (int)(cam_width / x_tile_size_) + 3;
    }

    void SetXStart()
    {
        float cam_width = Camera.main.orthographicSize * 2f * Camera.main.aspect;
        x_start_ = -cam_width / 2;
    }
}
