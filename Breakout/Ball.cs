using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout
{
    class Ball
    {
        Rectangle ball;
        Texture2D ballDrawing;
        Color[] color;
        int speedX = 2;
        int speedY = 2;

        public Ball(GraphicsDevice graphics, int x, int y, int dimensions)
        {
            ball = new Rectangle(x, y, dimensions, dimensions);
            color = new Color[ball.Width * ball.Height];
            for (int i = 0; i < color.Length; i++)
                color[i] = new Color(255, 50, 50);
            ballDrawing = new Texture2D(graphics, ball.Width, ball.Height);
            ballDrawing.SetData(color);
        }

        public Rectangle BallRect
        {
            get
            {
                return ball;
            }
        }

        public void Move()
        {
            ball.X += speedX;
            ball.Y += speedY;
        }

        public void CollisionX()
        {
            speedX *= -1;
        }

        public void CollisionY()
        {
            speedY *= -1;
        }

        public void Draw(SpriteBatch batch)
        {
            batch.Begin();
            batch.Draw(ballDrawing, ball, Color.White);
            batch.End();
        }
    }
}
