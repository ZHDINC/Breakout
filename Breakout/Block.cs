using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout
{
    class Block
    {
        Rectangle block;
        Texture2D blockDrawing;
        Color[] color;
        bool isVisible;

        public Block(GraphicsDevice device, int x, int y, int width, int height)
        {
            block = new Rectangle(x, y, width, height);
            color = new Color[block.Width * block.Height];
            for (int i = 0; i < color.Length; i++)
                color[i] = new Color(255, 255, 255);
            blockDrawing = new Texture2D(device, block.Width, block.Height);
            blockDrawing.SetData(color);
            isVisible = true;
        }

        public Rectangle BlockRect
        {
            get
            {
                return block;
            }
        }

        public void Collision()
        {
            isVisible = false;
        }

        public bool Visibility
        {
            get => isVisible;
        }

        public void Draw(SpriteBatch batch)
        {
            if (isVisible)
            {
                batch.Begin();
                batch.Draw(blockDrawing, block, Color.White);
                batch.End();
            }
        }
    }
}
