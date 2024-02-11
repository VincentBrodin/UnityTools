namespace UnityTools.GridCreation.Demo
{
    public class GridDemo
    {
        public void CreateGrid()
        {
            Grid<GridTileDemo> grid = new(10, 10);
            grid.InitializeGrid();
            
            GridTileDemo tile = new(){
                IsWalkable = true
            };
            grid[0, 0] = tile;
            grid[0, 0].IsWalkable = false;
        }
    }
    
    public class GridTileDemo : GridTile
    {
        public bool IsWalkable;
    }
}