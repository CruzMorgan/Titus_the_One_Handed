using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;
using System.ComponentModel;

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
            
            //ADD SPRITES 
            
            var dog = new Player("Magic_Dog_Run", 12, 4, Content, _spriteBatch, new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2));
            var bull = new Sprite("Bull_Run_Spritesheet", 12, 4, Content, _spriteBatch);

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