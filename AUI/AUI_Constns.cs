﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using System.Diagnostics;

namespace AUI
{
    //constants the ui needs to function and draw properly

    public static class Assets
    {   //contains color scheme and texture ui uses to draw
        public static Color ForegroundColor = Color.CornflowerBlue;
        public static Color BackgroundColor = Color.MonoGameOrange;
        public static Color TextColor = Color.MonoGameOrange;
        public static Color OverColor = Color.Yellow;

        public static Texture2D recTex;
        public static SpriteFont font;

        public static float Layer_0 = 0.999990f; //furthest 'back'
        public static float Layer_1 = 0.999989f;
        public static float Layer_2 = 0.999988f;
        public static float Layer_3 = 0.999987f;

        public static void Load(GraphicsDeviceManager GDM, ContentManager CM)
        {
            recTex = new Texture2D(GDM.GraphicsDevice, 1, 1);
            recTex.SetData<Color>(new Color[] { Color.White });







            font = CM.Load<SpriteFont>("pixelFont");
        }
    }

    public class Int4
    {   //used to draw, animate, and collision check ui
        public int X, Y, W, H = 0;
        public Int4() { }
        public Int4(int x, int y, int w, int h)
        {
            X = x; Y = y;
            W = w; H = h;
        }
    }

    public enum DisplayState
    {
        Opening, Opened, Closing, Closed
    }

    public static class Functions
    {   //efficient drawing, collision checking, and random int generation
        public static Random Random = new Random();

        public static Boolean Contains(Int4 int4, float x, float y)
        {
            return ((((int4.X <= x) && (x < (int4.X + int4.W)))
                && (int4.Y <= y)) && (y < (int4.Y + int4.H)));
        }

        public static Boolean Contains(Rectangle Rec, float x, float y)
        {
            return ((((Rec.X <= x) && (x < (Rec.X + Rec.Width)))
                && (Rec.Y <= y)) && (y < (Rec.Y + Rec.Height)));
        }
        
        static Rectangle DrawRec = new Rectangle();
        public static void DrawInt4(SpriteBatch SB, Int4 int4, Color color, float alpha)
        {   //match draw rec to int4
            DrawRec.X = int4.X;
            DrawRec.Y = int4.Y;
            DrawRec.Width = int4.W;
            DrawRec.Height = int4.H;
            //draw with draw rec at color at alpha
            SB.Draw(Assets.recTex, DrawRec, color * alpha);
        }
    }
}