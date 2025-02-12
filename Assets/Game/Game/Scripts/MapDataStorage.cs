public static class MapDataStorage
{
    public static MapData mapData { get; private set; }

    public static void SetData(MapData data)
    {
        mapData = data;
    }

    public static void RemoveData() => mapData = null;
}

public static class PlayerDataStorage
{
    public static PlayerData playerData { get; private set; }

    public static void SetData(PlayerData data)
    {
        playerData = data;
    }
}

public static class GameStatusStorage
{
    public static EndGameStatus gameStatus { get; private set; }

    public static void SetStatus(EndGameStatus status)
    {
        gameStatus = status;
    }
}