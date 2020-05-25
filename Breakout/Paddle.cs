using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout
{
    class Paddle
    {
        Rectangle paddle;
        Texture2D paddleDrawing;
        Color[] color;
        
        public Paddle(GraphicsDevice device, int x, int y, int width, int height)
        {
            paddle = new Rectangle(x, y, width, height);
            color = new Color[paddle.Width * paddle.Height];
            for (int i = 0; i < color.Length; i++)
                color[i] = new Color(255, 255, 255);
            paddleDrawing = new Texture2D(device, paddle.Width, paddle.Height);
            paddleDrawing.SetData(color);
        }

        public Rectangle PaddleRect
        {
            get
            {
                return paddle;
            }
        }

        public void MoveLeft()
        {
            paddle.X -= 5;
        }

        public void MoveRight()
        {
            paddle.X+=5;
        }

        public void Draw(SpriteBatch batch)
        {
            batch.Begin();
            batch.Draw(paddleDrawing, paddle, Color.White);
            batch.End();
        }
    }
}
