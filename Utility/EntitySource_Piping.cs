namespace Terraria.DataStructures
{
    //
    // Summary:
    //     Used when wiring activates an effect like a cannon or fireworks
    public class EntitySource_Piping : AEntitySource_Tile
    {
        public EntitySource_Piping(int tileCoordsX, int tileCoordsY, string? context = null)
            : base(tileCoordsX, tileCoordsY, context)
        {
        }
    }
}