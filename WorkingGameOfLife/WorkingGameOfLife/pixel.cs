using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace WorkingGameOfLife
{
    public class pixel : GameEntity
    {
        public int arrayloc;
        public Vector2 spriteloc;
        public bool isalive=true;
        int counter = 0;
        new Rectangle spriterec = new Rectangle();
        public Vector2 spritelocrec; 


        public pixel()
        {
        }
        public pixel(int r)
        {
            if (r == 1)
            {
                isalive = true;
            }
            else
            {
                isalive = false;
            }
        }
        public override void Draw()
        {

            if (isalive == true)
            {
                Game1.instance.spriteBatch.Draw(sprite, spriteloc, Color.White);

            }





        }
        public override void LoadContent()
        {
            sprite = Game1.instance.Content.Load<Texture2D>("pixel");
            
        }


        public override void Update(GameTime gameTime)
        {
            
            
            int over = arrayloc - ((int)Game1.instance.screenwidth/sprite.Width);
            int under = arrayloc + ((int)Game1.instance.screenwidth/sprite.Width);
            int arraylen = Game1.instance.array.Count-1 ;
            //if its inside the array
            if ((arrayloc > 0) && (arrayloc < arraylen))
            {
                //if its the top left corner
                if  (arrayloc == 0) {
                    if (Game1.instance.gen[arrayloc + 1] == true)
                        counter++;
                    if (Game1.instance.gen[under] == true) 
                        counter++;
                    if (Game1.instance.gen[under+1] == true)
                        counter++;
                    
                }//end if top left
                //if top right
                else if (arrayloc == ((Game1.instance.screenwidth / sprite.Width)-1))
                {
                    if (Game1.instance.gen[arrayloc - 1] == true)
                        counter++;
                    if (Game1.instance.gen[under] == true)
                        counter++;
                    if (Game1.instance.gen[under - 1] == true)
                        counter++;
                }//end top right
                //if bottom left
                else if(arrayloc==((Game1.instance.array.Count)-(Game1.instance.screenwidth/sprite.Height)))
                {
                    if (Game1.instance.gen[arrayloc + 1] == true)
                        counter++;
                    if (Game1.instance.gen[over] == true)
                        counter++;
                    if (Game1.instance.gen[over + 1] == true)
                        counter++;
                }//end if bottom left
                //if bottom right
                else if(arrayloc==(Game1.instance.array.Count)){
                    if (Game1.instance.gen[arrayloc - 1] == true)
                        counter++;
                    if (Game1.instance.gen[over] == true)
                        counter++;
                    if (Game1.instance.gen[over - 1] == true)
                        counter++;
                }//end bottom right
                //bottom line
                else if (arrayloc >= ((Game1.instance.array.Count) - (Game1.instance.screenwidth / sprite.Height)))
                {
                    if (Game1.instance.gen[arrayloc + 1] == true)
                        counter++;
                    if (Game1.instance.gen[arrayloc - 1] == true)
                        counter++;
                    if (Game1.instance.gen[over] == true)
                        counter++;
                    if (Game1.instance.gen[over + 1] == true)
                        counter++;
                    if (Game1.instance.gen[over - 1] == true)
                        counter++;
                }//end bottom line

                //if left side
                else if ((arrayloc % ((Game1.instance.screenwidth/sprite.Width)) == 0)&&(arrayloc!=1))
                {
                    if (Game1.instance.gen[arrayloc + 1] == true)
                        counter++;
                    if (Game1.instance.gen[over] == true) 
                        counter++;
                    if (Game1.instance.gen[over + 1] == true)
                        counter++;
                    if (Game1.instance.gen[under] == true)
                        counter++;
                    if (Game1.instance.gen[under+1] == true)
                        counter++;
                }//end left side
                //if top line
                else if (arrayloc < (Game1.instance.screenwidth / sprite.Width))
                {
                    if (Game1.instance.gen[arrayloc + 1] == true)
                        counter++;
                    if (Game1.instance.gen[arrayloc-1] == true)
                        counter++;
                    if (Game1.instance.gen[under] == true)
                        counter++;
                    if (Game1.instance.gen[under+1] == true)
                        counter++;
                    if (Game1.instance.gen[under - 1] == true)
                        counter++;
                }//end top line
                //if right side
                else if (arrayloc % ((Game1.instance.screenwidth / sprite.Width)) == (Game1.instance.screenwidth / sprite.Width)-1)
                {
                    if (Game1.instance.gen[arrayloc - 1] == true)
                        counter++;
                    if (Game1.instance.gen[over] == true)
                        counter++;
                    if (Game1.instance.gen[over - 1] == true)
                        counter++;
                    if (Game1.instance.gen[under] == true)
                        counter++;
                    if (Game1.instance.gen[under - 1] == true)
                        counter++;
                }//end right side
                
                    
                //else in the middle
                else
                {
                    if (Game1.instance.gen[arrayloc + 1] == true)
                        counter++;
                    if (Game1.instance.gen[arrayloc - 1] == true)
                        counter++;
                    if (Game1.instance.gen[over] == true)
                        counter++;
                    if (Game1.instance.gen[over + 1] == true)
                        counter++;
                    if (Game1.instance.gen[over - 1] == true)
                        counter++;
                    if (Game1.instance.gen[under] == true)
                        counter++;
                    if (Game1.instance.gen[under + 1] == true)
                        counter++;
                    if (Game1.instance.gen[under - 1] == true)
                        counter++;
                }//end else
            }

     
        if ((isalive == false) && (counter == 3))
            {
                isalive = true;
            }
            else if((isalive == true) &&  (counter < 2))
            {
                isalive = false;

            }
            else if((isalive == true) &&  (counter == 2))
            {
                isalive = true;
            }
            else if((isalive == true) &&  (counter == 3))
            {
                isalive = true;
            }
            else if ((isalive == true) && (counter > 3) ){
                isalive = false;
            }
            counter = 0;
            }

        }

    }

    


