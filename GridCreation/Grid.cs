using System.Collections;

namespace UnityTools.GridCreation
{
    public class Grid<T> : IEnumerable where T : GridTile
    {
        public int Width{ get; private set; }
        public int Height{ get; private set; }
        
        private readonly T[,] _gridArray;
        
        public Grid(int width, int height)
        {
            Width = width;
            Height = height;
            _gridArray = new T[width, height];
        }
        
        /// <summary>
        /// Initializes the grid with default values
        /// </summary>
        public void InitializeGrid()
        {
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    _gridArray[x, y] = default;
                }
            }
        }
        
        /// <summary>
        /// Returns the tile at the given coordinates
        /// </summary>
        /// <param name="x">X Position</param>
        /// <param name="y">Y Position</param>
        /// <returns></returns>
        public T GetTile(int x, int y)
        {
            if (x >= 0 && y >= 0 && x < Width && y < Height)
                return _gridArray[x, y];
            
            return default;
        }
        
        /// <summary>
        /// Sets the tile at the given coordinates to the given value
        /// </summary>
        /// <param name="x">X Position</param>
        /// <param name="y">Y Position</param>
        /// <param name="value">The value to set</param>
        public void SetTile(int x, int y, T value)
        {
            if (x >= 0 && y >= 0 && x < Width && y < Height)
                _gridArray[x, y] = value;
        }

        /// <summary>
        /// Returns the tile at the given coordinates
        /// </summary>
        /// <param name="x">X Position</param>
        /// <param name="y">Y Position</param>
        public T this[int x, int y]{
            get => _gridArray[x, y];
            set => _gridArray[x, y] = (T)value;
        }


        public IEnumerator GetEnumerator(){
            return _gridArray.GetEnumerator();
        }
    }
}