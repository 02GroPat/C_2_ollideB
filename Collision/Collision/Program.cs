﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
/*
 *  Collide
 *  Eine Simulation im 2-dimensionalen Raum
 *  Aufgabenverteilung
 *  a) Hueber Noemi
 *  b) Gross Patrick
 *  c) Zöschg Thomas
 *  d) Weiss Lukas
 * 
 * 2020 TFO-Meran
 */

namespace ConsoleApplication1
{
    class Program
    {
        const int seite = 50;
        static int[,] feld = new int[seite, seite];

        class einer
        {
            // Private Eigenschaften

            // Öffentliche Eigenschaften
            public int posx, posy;
            public ConsoleColor farbe;
            // Konstruktor
            public einer()
            {
            }
            //Private Methoden
            void show()
            {
            }
            void hide()
            {
            }
            void collide()
            {
            }
            //Öffentliche Methoden
            
            //Gross Patrick
            public void Move()
            {
                Random ZufallsZahl = new Random();
                int Richtung = ZufallsZahl.Next(1, 4);

                //springt in Methode "hide", zum Löschen des Objekts
                hide();

                //schreibt eine 0 auf die Position, wo es sich gerade befand
                feld[posx, posy] = 0;

                #region Position festlegen
                //Neue Position festlegen
                //Eine Zelle hoch
                if (Richtung == 1)
                {
                    //Schaut ob es sich bereits ganz oben befindet
                    if (posy == 0)  //wenn, dann springt es einfach auf der gegenüberliegenden Seite wieder ein(ganz unten)
                    {
                        posy = seite - 1;
                    }
                    else  //wenn nicht, dann ganz normal eine Zelle nach oben
                    {
                        posy--;
                    }
                }
                //Eine Zelle runter
                if (Richtung == 2)
                {
                    //Schaut ob es sich bereits ganz unten befindet
                    if (posy == seite - 1) //wenn, dann springt es einfach auf der gegenüberliegenden Seite wieder ein(ganz oben)
                    {
                        posy = 0;
                    }
                    else  //wenn nicht, einfach ganz normal eine Zelle nach unten
                    {
                        posy++;
                    }
                }
                //Eine Zelle nach links
                if (Richtung == 3)
                {
                    //Schaut ob es sich bereits ganz links befindet
                    if (posx == 0)  //wenn, dann springt es einfach auf der gegenüberliegenden Seite wieder ein(ganz rechts)
                    {
                        posx = seite - 1;
                    }
                    else  //wenn nicht, einfach ganz normal eine Zelle nach links
                    {
                        posx--;
                    }            
                    
                }
                //Eine Zelle nach rechts
                if (Richtung == 4)
                {
                    //Schaut ob es sich bereits ganz rechts befindet
                    if (posx == seite - 1)//wenn, dann springt es einfach auf der gegenüberliegenden Seite wieder ein(ganz links)
                    {
                        posx = 0;
                    }
                    else  //wenn nicht, einfach ganz normal eine Zelle nach rechts
                    {
                        posx++;
                    }                    
                }
                else
                { }
                #endregion

                //Schaut ob sich auf dieser Position bereits ein Objekt befindet oder nicht
                if (feld[posx, posy] == 0)  //wenn nicht, dann zeige es auf dieser Position an, und schreibe auf dieser Position eine 1
                {
                    //springt in Methode "show", zum Anzeigen des Objekts
                    show();

                    //schreibt eine 1 auf die Position, wo es sich aktuell befindet
                    feld[posx, posy] = 1;
                }
                else  //wenn doch, dann springe in die Methode collide
                {
                    //springt in Methode "collide", um eine Kollision anzuzeigen und eine neue Position festzulegen
                    collide();
                }
                //Ende Methode "Move"
            }


        }

        static void Main(string[] args)
        {
            Console.WindowWidth = seite * 2;
            Console.WindowHeight = seite;
            Console.Clear();
            Random ZG = new Random();
            int Anzahl = ZG.Next(1, 6);
            einer[] meineEiner = new einer[Anzahl];
            for (int i = 0; i < Anzahl; i++)
            {
                meineEiner[i] = new einer();
            }
            Console.CursorVisible = false;
            for (int i = 0; i < 1000; i++)
            {
                for (int j = 0; j < Anzahl; j++)
                {
                    meineEiner[j].Move();
                }
                System.Threading.Thread.Sleep(10);

            }
        }
    }
}
