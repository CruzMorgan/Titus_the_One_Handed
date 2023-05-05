using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;


namespace Titus_the_One_Handed
{
    public class FramePlayer
    {
        public Texture2D _texture;

        private string _spritesheet;
        private float _frameSpeed;
        private int _frameNum;
        private int _currentFrame;
        private float _updateFrame;

        private ContentManager _content;
        private SpriteBatch _spriteBatch;


        public FramePlayer(string spritesheet, float frameSpeed, int frameNum, ContentManager content, SpriteBatch spriteBatch)
        {

            _spritesheet = spritesheet;
            _frameSpeed = 1.0f / frameSpeed;
            _frameNum = frameNum;
            _content = content;
            _currentFrame = 0;
            _spriteBatch = spriteBatch;

        }

        public void LoadContent()
        {
            _texture = _content.Load<Texture2D>(_spritesheet);
        }

        public void Update(GameTime gameTime)
        {

            _updateFrame += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (_currentFrame <= _frameNum - 2 && _updateFrame >= _frameSpeed)
            {
                _currentFrame++;
                _updateFrame = 0;
            }
            else if (_currentFrame > _frameNum - 2 && _updateFrame >= _frameSpeed)
            {
                _currentFrame = 0;
                _updateFrame = 0;
            }

        }

        public void Draw(Vector2 pos, SpriteEffects spriteEffects)
        {
            Debug.Assert(_texture.Width / _frameNum * _currentFrame >= 0);
            Debug.Assert(_spriteBatch != null);

            _spriteBatch.Draw(
                _texture,
                pos,
                new Rectangle
                    (
                    new Point(_texture.Width / _frameNum * _currentFrame, 0),
                    new Point(_texture.Width / _frameNum, _texture.Height)
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