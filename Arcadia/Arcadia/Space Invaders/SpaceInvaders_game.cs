using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Arcadia.Space_Invaders
{
    public class SpaceInvaders_game
    {

        private ennemi[,] ennemi_tableau;
        

        public virtual void Initialize(ContentManager content) 
        {
            ennemi_tableau = new ennemi[10, 4];
            
            for (int x = 0; x < 10; x++)
            {
                ennemi_tableau[x, 0] = new ennemi();
                ennemi_tableau[x, 0].Initialize();
                ennemi_tableau[x, 0].LoadContent(content, "SpaceInvaders/ennemi1");
                ennemi_tableau[x, 1] = new ennemi();
                ennemi_tableau[x, 1].Initialize();
                ennemi_tableau[x, 1].LoadContent(content, "SpaceInvaders/ennemi2");
                ennemi_tableau[x, 2] = new ennemi();
                ennemi_tableau[x, 2].Initialize();
                ennemi_tableau[x, 2].LoadContent(content, "SpaceInvaders/ennemi3");
                ennemi_tableau[x, 3] = new ennemi();
                ennemi_tableau[x, 3].Initialize();
                ennemi_tableau[x, 3].LoadContent(content, "SpaceInvaders/ennemi1");

            }
            

        }
        public virtual void Draw(SpriteBatch spritebatch, GameTime gametime, int pos_x, int pos_y)
        {
            for (int x = 0; x < 10; x++)
            {
                ennemi_tableau[x, 0].Draw(spritebatch,ennemi_tableau[x,0].enn_public, pos_x, pos_y);
                pos_x = pos_x + 5;
                
                
            }
            pos_y = pos_y +30;

            for (int x = 0; x < 10; x++)
            {
                ennemi_tableau[x, 1].Draw(spritebatch, ennemi_tableau[x, 1].enn_public, pos_x, pos_y);
                pos_x = pos_x + 5;

            }

            pos_y = pos_y + 30;

            for (int x = 0; x < 10; x++)
            {
                ennemi_tableau[x, 2].Draw(spritebatch, ennemi_tableau[x, 2].enn_public, pos_x, pos_y);
                pos_x = pos_x + 5;

            }

            pos_y = pos_y + 30;

            for (int x = 0; x < 10; x++)
            {
                ennemi_tableau[x, 3].Draw(spritebatch, ennemi_tableau[x, 3].enn_public , pos_x, pos_y);
                pos_x = pos_x + 5;

            }
        }


    }
    }

