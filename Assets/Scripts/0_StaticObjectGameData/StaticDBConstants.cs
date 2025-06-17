

public static class StaticDBConstants
{
    public static readonly string CUBE_RUN_DB_FILE_NAME = "GameDataBase.db";        //db file name

    //LEVEL TABLE
    public static readonly string CONTROLL_LEVEL_TABLE_NAME = "level_table";        //table name
    public static readonly string ID_LEVEL_NAME = "id";                             //level id column name
    public static readonly string SCORE = "score";                             //score column name
    public static readonly string IS_PASSED = "is_passed";                     //is_passed column name

    public static readonly string CREATE_LEVEL_TABLE_COMMAND =
                                        "CREATE TABLE IF NOT EXISTS " + CONTROLL_LEVEL_TABLE_NAME + " (" +
                                        ID_LEVEL_NAME + " INTEGER PRIMARY KEY AUTOINCREMENT, " +
                                        IS_PASSED + " INTEGER, " +
                                        SCORE + " INTEGER);";

    public enum LevelField                                                            //Data Type
    {
        LEVEL_IDX = 0,
        IS_PASSED = 1,
        LEVEL_SCORE = 2,
    };
}
