public interface ITile : IPositioned
{
    TileType TileType { get; }
    bool isStepable();

    void leaveTile(IBuisnessObject buisnessObject);

    void enterTile(IBuisnessObject buisnessObject);
}
