using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace Breakout
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Paddle paddle;
        List<Block> blocks;
        Ball ball;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            paddle = new Paddle(GraphicsDevice, 300, 425, 100, 25);
            blocks = new List<Block>();
            for (int row = 0; row < 3; row++)
            {
                for (int column = 0; column < 8; column++)
                {
                    blocks.Add(new Block(GraphicsDevice, (column * 100) + 10, (row * 50) + 50, 75, 25));
                }
            }
            ball = new Ball(GraphicsDevice, 150, 300, 20);
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
                paddle.MoveLeft();
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
                paddle.MoveRight();
            if (ball.BallRect.Top < 0 || ball.BallRect.Intersects(paddle.PaddleRect))
                ball.CollisionY();
            if (ball.BallRect.Left < 0 || ball.BallRect.Right > Window.ClientBounds.Width)
                ball.CollisionX();
            for (int i = 0; i < blocks.Count; i++)
            {
                if(ball.BallRect.Intersects(blocks[i].BlockRect) && blocks[i].Visibility)
                {
                    blocks[i].Collision();
                    ball.CollisionY();
                }
            }
            ball.Move();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            paddle.Draw(spriteBatch);
            for (int i = 0; i < blocks.Count; i++)
                blocks[i].Draw(spriteBatch);
            ball.Draw(spriteBatch);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
