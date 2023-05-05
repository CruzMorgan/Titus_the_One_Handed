using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;
using System.ComponentModel;
using System.Collections.Generic;

namespace Titus_the_One_Handed
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private DrawSprite sprites;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            sprites = new DrawSprite();
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            //ADD ANIMATION DETAILS

            var dogRunning = new Animation
            {
                Filename = "Magic_Dog_Run",
                FPS = 12,
                NumOfFrames = 4
            };

            var dogIdle = new Animation
            {
                Filename = "Magic_Dog_Idle",
                FPS = 1,
                NumOfFrames = 1
            };

            var bullAnimation = new Animation
            {
                Filename = "Bull_Run_Spritesheet",
                FPS = 12,
                NumOfFrames = 4
            };

            var dogAnimations = new Dictionary<string, Animation> { { "running", dogRunning }, { "xidle", dogIdle } };
            var bullAnimations = new Dictionary<string, Animation> { { "running", bullAnimation } };

            //ADD SPRITES

            var dog = new Player(dogAnimations, Content, _spriteBatch, new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2));
            var bull = new Sprite(bullAnimations, Content, _spriteBatch);

            //ADD SPRITES TO SPRITE LIST

            sprites.Add(dog);
            sprites.Add(bull);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            sprites.LoadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            sprites.Update(gameTime);

            //exits window when pressing esc
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(new Color(55, 227, 250));

            _spriteBatch.Begin();

            sprites.Draw();

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}