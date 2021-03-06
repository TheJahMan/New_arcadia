﻿using System;
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


namespace Arcadia
{

    public class FantomeIA
    {
        enum Direction_fantome
        {
            right = 1,
            left = 3,
            up = 2,
            down = 4
        };
        enum Old_direction_fantome
        {
            right = 1,
            left = 3,
            up = 2,
            down = 4
        };



        // variable fantome 
        private Texture2D fantome;
        public Texture2D fantome_public { get { return fantome; } }

        // pour la couleur du fantome + position 
        Random rand = new Random();


        // vecteur position 
        Vector2 fantome_position;
        public Vector2 Fantome_position { get { return fantome_position; } }

        // taille d'un carré 
        int size = 28;


        //variable map 
        Bitmap map;

        //vitesse du fantome 
        float speed = 1.1f;


        // direcion fantome 
        Direction_fantome direction_fantome;
        Old_direction_fantome old_direction_fantome;


        // bool pour savoir si manger
        public bool is_manger;
        public int nb_tour_manger;

        // bool pour changement de direction 
        bool test_u;
        bool test_r;
        bool test_l;
        bool test_d;

        // retard pour changer de direction pas immdeiatement 
        int retard;

        int j;

        //public Fantome(Texture2D fantome)
        //{
        //    this.fantome = fantome;
        //}
        public virtual void Initialize(string namemap, int jet, int level)
        {

            this.j = jet;

            if (level == 1)
                fantome_position = new Vector2(12 * size, 10 * size);
            else fantome_position = new Vector2(12 * size, 13 * size);

            if (j == 2) { direction_fantome = Direction_fantome.left; old_direction_fantome = Old_direction_fantome.left; }
            else if (j == 1) { direction_fantome = Direction_fantome.right; old_direction_fantome = Old_direction_fantome.right; }
            else { direction_fantome = Direction_fantome.down; old_direction_fantome = Old_direction_fantome.down; }

            map = new Bitmap(".../.../.../" + namemap);

            is_manger = false;
            nb_tour_manger = 0;

            retard = 0;
        }


        public virtual void LoadContent(ContentManager content)
        {
            fantome = content.Load<Texture2D>("Pacman/fantome");

        }


        public virtual void Update(ref int[,] tab, string namemap, int level, Pacman pacman)
        {

            test_u = false;
            test_r = false;
            test_l = false;
            test_d = false;



            bool test = false;

            if (!is_manger)
            {

                // position pacman en x et y en entier 
                int pos_x = Convert.ToInt32(fantome_position.X);
                int pos_y = Convert.ToInt32(fantome_position.Y);

                if (direction_fantome != Direction_fantome.up && Check_pixel(pos_x, pos_y - 5, map) && Check_pixel(pos_x + fantome.Width, pos_y - 5, map))
                    test_u = true;

                if (direction_fantome != Direction_fantome.down && Check_pixel(pos_x, pos_y + fantome.Height + 5, map) && Check_pixel(pos_x + fantome.Width, pos_y + fantome.Height + 5, map))
                    test_d = true;

                if (direction_fantome != Direction_fantome.right && Check_pixel(pos_x + fantome.Width + 5, pos_y, map) && Check_pixel(pos_x + fantome.Width + 5, pos_y + fantome.Height, map))
                    test_r = true;

                if (direction_fantome != Direction_fantome.left && Check_pixel(pos_x - 5, pos_y, map) && Check_pixel(pos_x - 5, pos_y + fantome.Height, map))
                    test_l = true;
                
                // si pacman plsu haut que fantomes
                if (test_u && pacman.Pacman_position.Y < fantome_position.Y) { direction_fantome = Direction_fantome.up; }
                
                // si pacman plus bas que fantome
                if (test_r && pacman.Pacman_position.Y > fantome_position.Y) { direction_fantome = Direction_fantome.down; }

                // si pacman plus à droite que fantome
                if (test_r && pacman.Pacman_position.X > fantome_position.X) { direction_fantome = Direction_fantome.right; }

                // si pacman plus à gauche que fantome
                if (test_l && pacman.Pacman_position.X < fantome_position.X) { direction_fantome = Direction_fantome.left; }


                // gestion des directions 
                if (direction_fantome == Direction_fantome.up && Check_pixel(pos_x, pos_y - 2, map) && Check_pixel(pos_x + fantome.Width, pos_y - 2, map))
                {
                    fantome_position.Y = fantome_position.Y - speed;
                    test = true;

                }
                else if (direction_fantome == Direction_fantome.down && Check_pixel(pos_x, pos_y + fantome.Height + 2, map) && Check_pixel(pos_x + fantome.Width, pos_y + fantome.Height + 2, map))
                {
                    fantome_position.Y = fantome_position.Y + speed;
                    test = true;
                }

                else if (direction_fantome == Direction_fantome.right && Check_pixel(pos_x + fantome.Width + 2, pos_y, map) && Check_pixel(pos_x + fantome.Width + 2, pos_y + fantome.Height, map))
                {
                    fantome_position.X = fantome_position.X + speed;
                    test = true;

                }
                else if (direction_fantome == Direction_fantome.left && Check_pixel(pos_x - 2, pos_y, map) && Check_pixel(pos_x - 2, pos_y + fantome.Height, map))
                {
                    fantome_position.X = fantome_position.X - speed;
                    test = true;
                }

                while (!test)
                {
                    int jet = rand.Next(1, 100);

                    if (jet < 25 && test_u)
                    {
                        direction_fantome = Direction_fantome.up;
                        test = true;
                    }

                    else if (jet < 50 && test_d)
                    {
                        direction_fantome = Direction_fantome.down;
                        test = true;
                    }
                    else if (jet < 75 && test_r) 
                    {
                        direction_fantome = Direction_fantome.right;
                        test = true;
                    }
                    else if (test_l)
                    {
                        direction_fantome = Direction_fantome.left;
                        test = true;
                    }
                
                }


            }



            else
            {
                nb_tour_manger++;

                if (nb_tour_manger > 500)
                {
                    this.Initialize(namemap, this.j, level);

                }
            }

            if (direction_fantome == Direction_fantome.up)
                old_direction_fantome = Old_direction_fantome.up;
            else if (direction_fantome == Direction_fantome.down)
                old_direction_fantome = Old_direction_fantome.down;
            else if (direction_fantome == Direction_fantome.left)
                old_direction_fantome = Old_direction_fantome.left;
            else if (direction_fantome == Direction_fantome.right)
                old_direction_fantome = Old_direction_fantome.right;


        }





        public virtual void Draw(SpriteBatch spriteBatch, Texture2D fantome)
        {
            if (!is_manger)
                spriteBatch.Draw(fantome, fantome_position, Microsoft.Xna.Framework.Color.White);

        }

        // fonction qui verifie que pixel  la où pacman veut aller est bien noir
        public bool Check_pixel(int x, int y, Bitmap img)
        {
            if (img.GetPixel(x, y).R == 0 && img.GetPixel(x, y).G == 0 && img.GetPixel(x, y).B == 0) return true;
            else return false;
        }
    }
}
