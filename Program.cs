using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
/*
 Cameron Lloyd, Bradley Graves
 z1853137, z1853328
 Assignment 2
 CSCI 473
 This is a program to a test functionality for Players and Items in the gane 'World of ConflictCraft'
 It includes definitions for the item and player classes as well as some static functions used for
 finding and verifying that items,players, or guilds exist.
 Then finally a menu interface for using and interacting with all of these functions.
 */
namespace Assignment2
{
    static class Program
    {  
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Assign2Form());
        }
    }
}
