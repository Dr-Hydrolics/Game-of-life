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

namespace WorkingGameOfLife
{

    public class Game1 : Microsoft.Xna.Framework.Game
    {
        public GraphicsDeviceManager graphics;
        public static Game1 instance;
        public SpriteBatch spriteBatch;
        public float screenwidth;
        public float screenheight;
        int boxcount;
        public pixel test = new pixel();
        public List<pixel> array= new List<pixel>();
        Random rand = new Random();
        public List<bool> gen = new List<bool>();
 

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            instance = this;
            this.IsFixedTimeStep = false;
        }

        protected override void Initialize()
        {
            this.IsMouseVisible = true;


            LoadContent();
            
        }

        protected override void  LoadContent()

        {
            spriteBatch = new SpriteBatch(GraphicsDevice);


            screenwidth = GraphicsDevice.Viewport.Width;
            screenheight = GraphicsDevice.Viewport.Height;
            test.LoadContent();

            boxcount = ((GraphicsDevice.Viewport.Height * GraphicsDevice.Viewport.Width) / (test.sprite.Width * test.sprite.Height));
                

            for (int i = 0; i < (boxcount); ++i)
            {
                int ran = new Random().Next(0, 2);      
                array.Add(new pixel(ran));
                array[i].LoadContent();
                array[i].arrayloc = i;
                 
                gen.Add(array[i].isalive);

 
            }
            Vector2 spriteloc = new Vector2();
            spriteloc.X = 0;
            spriteloc.Y = 0;
            for (int i = 0; i < (boxcount); i++)
            {

                array[i].spriteloc = spriteloc;
                spriteloc.X =spriteloc.X+ (float)array[i].sprite.Width;
                array[i].spritelocrec = spriteloc;

                if (spriteloc.X >= (screenwidth) )
                {
                    spriteloc.X = 0;
                    spriteloc.Y =spriteloc.Y+ (float)array[i].sprite.Height;
                }
                if (spriteloc.Y > screenheight)
                {
                    break;
                }
            }



        }


        protected override void UnloadContent()
        {

        }


        protected override void Update(GameTime gameTime)
        {
            
            
            for (int i = 0; i < (boxcount); i++)
            {

                array[i].Update(gameTime);
                
            }
            for (int i = 0; i < gen.Count; i++)
            {
                gen[i] = array[i].isalive;
            }
           



            
            
        }


        protected override void Draw(GameTime gameTime)
        {


            
            GraphicsDevice.Clear(Color.White);
            spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.Opaque);
            for (int i = 0; i < (boxcount); i++)
            {
                array[i].Draw();

            }
            spriteBatch.End();

                
        }





    }
}

