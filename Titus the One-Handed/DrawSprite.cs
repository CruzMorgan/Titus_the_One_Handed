using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Titus_the_One_Handed
{
    public class DrawSprite
    {

        private List<Sprite> _spriteList;

        public DrawSprite()
        {
            _spriteList = new List<Sprite>();
        }

        public void Add(Sprite sprite)
        {
            _spriteList.Add(sprite);
        }

        public void LoadContent()
        {
            foreach (Sprite sprite in _spriteList)
            {
                sprite.LoadContent();
            }
        }

        public void Update(GameTime gameTime)
        {
            foreach(Sprite sprite in _spriteList)
            {
                sprite.Update(gameTime);
            }
        }

        public void Draw()
        {
            foreach (Sprite sprite in _spriteList)
            {
                sprite.Draw();
            }
        }
    }
}
