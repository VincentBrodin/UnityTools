using UnityEngine;

namespace UnityTools.DataStructures
{
    public class QuadTree
    {
        public readonly float Size;
        public readonly Vector2 Center;
        
        public bool IsLeaf => Children == null;
        public bool IsRoot => _parent == null;
        
        private readonly QuadTree _parent;
        public readonly int Depth;
        public readonly QuadTree[] Children;
        public int ObjectCount;
        
        private const int MaxDepth = 4;
        
        public QuadTree(int depth, float size, Vector2 center, QuadTree parent = null)
        {
            _parent = parent;
            Depth = depth;
            Size = size;
            
            if (depth == MaxDepth)
            {
                Center = center;
                ObjectCount = 0;
                return;
            }
            Children = new QuadTree[4];
            float childSize = size / 2; // Change this line to adjust the size of the child nodes
            Vector2 newCenter = Vector2.zero;
            for (int i = 0; i < 4; i++)
            {
                Vector2 childCenter = GetChildPosition(i % 2, i / 2, childSize, center, size);
                newCenter += childCenter;
                Children[i] = new QuadTree(depth + 1, childSize, childCenter, this);
            }
            Center = newCenter / 4;
        }
        
        private Vector2 GetChildPosition(int x, int y, float tileSize, Vector2 center, float parentSize)
        {
            float offsetX = (x - 0.5f) * tileSize;
            float offsetY = (y - 0.5f) * tileSize;
            return new Vector2(center.x + offsetX, center.y + offsetY);
        }
    }
}