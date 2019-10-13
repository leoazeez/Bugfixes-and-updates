
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
//using System.Data;
using System.Diagnostics;
using SwinGameSDK;
static class GameLogic
{
	public static void Main()
	{
		//Opens a new Graphics Window
		SwinGame.OpenGraphicsWindow("Battle Ships", 800, 600);

		//Load Resources
		GameResources.LoadResources();

		SwinGame.PlayMusic(GameResources.GameMusic("Background"));
        bool sc = true;
        //Game Loop
        do {
			GameController.HandleUserInput();
			GameController.DrawScreen();
            if (SwinGame.KeyTyped(KeyCode.vk_m)&&(sc==true))
            {
                sc = false;
                SwinGame.PauseMusic();
            }
            else if (SwinGame.KeyTyped(KeyCode.vk_m)&&(sc==false))
            {
                sc = true;
                SwinGame.ResumeMusic();
            }
        } while (!(SwinGame.WindowCloseRequested() == true | GameController.CurrentState == GameState.Quitting));

		SwinGame.StopMusic();

		//Free Resources and Close Audio, to end the program.
		GameResources.FreeResources();
	}
}