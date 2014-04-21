﻿using System;
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
        private maison[,] mais_tableau1;
        private maison[,] mais_tableau2;
        private maison[,] mais_tableau3;


        int encrage_x_enn = 210;
        int encrage_y_enn = 100;

        
        

        public virtual void Initialize(ContentManager content) 
        {
            ennemi_tableau = new ennemi[10, 4];
            mais_tableau1 = new maison[4, 3];
            mais_tableau2 = new maison[4, 3];
            mais_tableau3 = new maison[4, 3];
            
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

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    mais_tableau1[i, j] = new maison();
                    mais_tableau1[i, j].Initialize();
                    mais_tableau1[i, j].LoadContent(content);

                    mais_tableau2[i, j] = new maison();
                    mais_tableau2[i, j].Initialize();
                    mais_tableau2[i, j].LoadContent(content);

                    mais_tableau3[i, j] = new maison();
                    mais_tableau3[i, j].Initialize();
                    mais_tableau3[i, j].LoadContent(content);
                }
            }
            

        }
        public virtual void Draw(SpriteBatch spritebatch, GameTime gametime, int pos_x, int pos_y)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 4; j++) 
                {
                    ennemi_tableau[i, j].Draw(spritebatch, ennemi_tableau[i, j].enn_public, encrage_x_enn + i * 28, encrage_y_enn + j * 28);
                }
            
            }

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    mais_tableau1[i,j].Draw(spritebatch, mais_tableau1[i,j].mais_public,
 
                }
            }
        }


    }
    }

