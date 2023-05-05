using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;
using System.Collections.Generic;



namespace Titus_the_One_Handed
{
    public class FramePlayer
    {
        private Texture2D _texture;
        private string _currentAnimation;

        private int _currentFrame;
        private float _updateFrame;
        private Dictionary<string, Animation> _animations;

        private ContentManager _content;
        private SpriteBatch _spriteBatch;


        public FramePlayer(Dictionary<string, Animation> animations, ContentManager content, SpriteBatch spriteBatch)
        {
            _currentAnimation = "idle";
            _animations = new Dictionary<string, Animation>(animations);
            _content = content;
            _currentFrame = 0;
            _spriteBatch = spriteBatch;

        }

        public void SetCurrentAnimation(string animation)
        {
            _currentAnimation = animation;
        }

        public void LoadContent()
        {
            Debug.Assert(_animations.ContainsKey("idle"));
            _texture = _content.Load<Texture2D>(_animations[_currentAnimation].Filename);
        }

        public void Update(GameTime gameTime)
        {

            _updateFrame += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (_currentFrame <= _animations[_currentAnimation].NumOfFrames - 2 && _updateFrame >= _animations[_currentAnimation].FPS)
            {
                _currentFrame++;
                _updateFrame = 0;
            }
            else if (_currentFrame > _animations[_currentAnimation].NumOfFrames - 2 && _updateFrame >= _animations[_currentAnimation].FPS)
            {
                _currentFrame = 0;
                _updateFrame = 0;
            }

        }

        public void Draw(Vector2 pos, SpriteEffects spriteEffects)
        {
            Debug.Assert(_texture.Width / _animations[_currentAnimation].NumOfFrames * _currentFrame >= 0);
            Debug.Assert(_spriteBatch != null);

            _spriteBatch.Draw(
                _texture,
                pos,
                new Rectangle
                    (
                    new Point(_texture.Width / _animations[_currentAnimation].NumOfFrames * _currentFrame, 0),
                    new Point(_texture.Width / _animations[_currentAnimation].NumOfFrames, _texture.Height)
                    ),
                Color.White,
                0,
                Vector2.Zero,
                Vector2.One,
                spriteEffects,
                0
            );
        }
    }
}