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
        //declaration & pos ennemi
        private ennemi[,] ennemi_tableau;
        int encrage_x = 0;
        int encrage_y = 0;

        //declaration player
        Player ship = new Player();
        
        
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
            public virtual void LoadContent(ContentManager content)
            {
                ship.LoadContent(content);
            }

       
        public virtual void Draw(SpriteBatch spritebatch, GameTime gametime, int pos_x, int pos_y)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 4; j++) 
                {
                    ennemi_tableau[i, j].Draw(spritebatch, ennemi_tableau[i, j].enn_public, encrage_x + i * 28, encrage_y + j * 28);
                }
            
            }
            ship.Draw(spritebatch, gametime);
        }


    }
    }

