using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Titus_the_One_Handed
{
    //DEFAULT SPRITE
    public class Sprite
    {
        private FramePlayer _animation;
        protected Vector2 _pos;
        protected SpriteEffects _spriteEffects;

        public Sprite(Dictionary<string, Animation> animations, ContentManager content, SpriteBatch spriteBatch)
        {
            _animation = new FramePlayer(animations, content, spriteBatch);
            _pos = new Vector2();
        }

        public void LoadContent()
        {
            _animation.LoadContent();
            _pos = Vector2.Zero;
        }

        public virtual void Update(GameTime gameTime)
        {
            _animation.Update(gameTime);
        }

        public void Draw()
        {
            _animation.Draw(_pos, _spriteEffects);
        }

    }

    //PLAYER SPRITE
    public class Player : Sprite
    {
        private float dogSpeed;

        public Player(Dictionary<string, Animation> animations, ContentManager content, SpriteBatch spriteBatch, Vector2 startPos) : base(animations, content, spriteBatch)
        {
            _pos = startPos;
            dogSpeed = 400.0f;
        }

        public override void Update(GameTime gameTime)
        {
            var keyPressed = Keyboard.GetState();

            if (keyPressed.IsKeyDown(Keys.Up))
            {
                _pos.Y -= dogSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            if (keyPressed.IsKeyDown(Keys.Down))
            {
                _pos.Y += dogSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            if (keyPressed.IsKeyDown(Keys.Right))
            {
                _pos.X += dogSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                _spriteEffects = SpriteEffects.None;
            }

            if (keyPressed.IsKeyDown(Keys.Left))
            {
                _pos.X -= dogSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                _spriteEffects = SpriteEffects.FlipHorizontally;
            }
            _pos.Y = (float)Math.Round(_pos.Y);
            _pos.X = (float)Math.Round(_pos.X);

            base.Update(gameTime);
        }
    }
}
