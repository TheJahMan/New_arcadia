using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Threading;
using System.Drawing;

namespace Arcadia.Space_Invaders
{
    class ennemi
    {
        private Texture2D enn;
        bool is_alive;
        
        public virtual void Initialize()
        {
            is_alive = true;
        }
        public virtual void LoadContent(ContentManager content, string typ_enn) // jai passé le truc en fonction retournant une texture pour le draw 
        {
            enn = content.Load<Texture2D>(typ_enn);
           
        }

        public virtual void Draw(SpriteBatch spriteBatch, int pos_x, int pos_y)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(enn, new Vector2(pos_x,pos_y), Microsoft.Xna.Framework.Color.White);
            spriteBatch.End();
        }

    }
}
