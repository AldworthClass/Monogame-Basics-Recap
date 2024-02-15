using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Importing_Scaling_and_Randomization
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Random generator = new Random();

        Texture2D backgroundTexture;
        Rectangle backgroundRect;

        Texture2D shipTexture;
        Rectangle shipRect;

        List<Texture2D> shipTextures;

        SpriteFont titleFont;

        float angle;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {

            // TODO: Add your initialization logic here
            Window.Title = "Content, Scaling and Text";

            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 500;
            _graphics.ApplyChanges();

            shipRect = new Rectangle(generator.Next(_graphics.PreferredBackBufferWidth - 75), generator.Next(_graphics.PreferredBackBufferHeight - 75), 75, 100);
            backgroundRect = new Rectangle(0, 0, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);
            
            // Calculates random angle from 0-360 to rotate ship
            angle = 2 * MathF.PI * (float)generator.NextDouble();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            titleFont = Content.Load<SpriteFont>("Fonts/TitleFont");
            backgroundTexture = Content.Load<Texture2D>("Images/space_background");
            shipTextures = new List<Texture2D>();
            for (int i = 1; i <= 5; i++)
                shipTextures.Add(Content.Load<Texture2D>("Images/enterprise_" + i));
            shipTexture = shipTextures[generator.Next(shipTextures.Count)];
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            _spriteBatch.Draw(backgroundTexture, backgroundRect, Color.White);
            _spriteBatch.DrawString(titleFont, "Space", new Vector2(300, 10), Color.Yellow);
            _spriteBatch.Draw(shipTexture, shipRect, Color.White);
            _spriteBatch.Draw(shipTexture, shipRect, null, Color.White, angle, new Vector2(shipTexture.Width / 2, shipTexture.Height / 2), SpriteEffects.None, 1f);
            
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}