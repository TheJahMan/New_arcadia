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
    class ennemi_game
    {
        public ennemi[,] ennemi_tableau;
        

        public virtual void Initialize(ContentManager content) // jai passé un contentmanager en parametre sinon ca passe pas ds le ennemi_tableau[x, ...].LoadContent
        {
            ennemi_tableau = new ennemi[10, 4];
            for (int x = 0; x < 10; x++)
            {
                ennemi_tableau[x, 1] = new ennemi();
                ennemi_tableau[x, 1].Initialize();
                ennemi_tableau[x, 1].LoadContent(content, "SpaceInvaders/ennemi1");
                ennemi_tableau[x, 2] = new ennemi();
                ennemi_tableau[x, 2].Initialize();
                ennemi_tableau[x, 2].LoadContent(content, "SpaceInvaders/ennemi2");
                ennemi_tableau[x, 3] = new ennemi();
                ennemi_tableau[x, 3].Initialize();
                ennemi_tableau[x, 3].LoadContent(content, "SpaceInvaders/ennemi3");
                ennemi_tableau[x, 4] = new ennemi();
                ennemi_tableau[x, 4].Initialize();
                ennemi_tableau[x, 4].LoadContent(content, "SpaceInvaders/ennemi4");

            }


        }
        public virtual void Draw(SpriteBatch spritebatch, GameTime gametime, int pos_x, int pos_y)
        {
            for (int x = 0; x < 10; x++)
            {
                ennemi_tableau[x, 1].Draw(spritebatch, pos_x, pos_y);
                pos_x = pos_x + 5;
                pos_y = pos_y + 5;
                
                
            }
        }


    }
}
