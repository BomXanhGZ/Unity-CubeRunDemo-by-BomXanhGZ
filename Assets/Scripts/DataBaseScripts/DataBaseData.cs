using System;
using static StaticDBConstants;
using static GameSettings.NameScenes;


public class DataBaseData : SingletonObject<DataBaseData>
{

    readonly int level_quantity = ALL_LEVEL_NAME_ARRAY.Length;
    readonly int data_quantity = Enum.GetValues(typeof(LevelField)).Length;
    public int[,] data_base_matrix_ { set; get; }


    private void Awake()
    {
        data_base_matrix_ = new int[level_quantity, data_quantity];
    }

    private void Start()
    {
        InitSingletonObject();
    }
}
