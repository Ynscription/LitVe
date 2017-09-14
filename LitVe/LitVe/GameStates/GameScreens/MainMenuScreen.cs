using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;using LitVe.Input;
using LitVe.GUI.Controls;

namespace LitVe.GameStates.GameScreens {
	public class MainMenuScreen :BaseGameState{

		PictureBox bgImage;
		PictureBox arrowImage;
		LinkLabel start;
		LinkLabel load;
		LinkLabel exit;
		float maxItemWidth = 0f;


		public MainMenuScreen (Game game, GameStateManager manager) : base (game,manager){

		}

		public override void Initialize () {
			base.Initialize ();
		}

		protected override void LoadContent () {
			base.LoadContent ();
			
			ContentManager content = Game.Content;
			//BackGround
			bgImage = new PictureBox (content.Load<Texture2D> (@"BackGrounds\titleScreen"), GameRef.ScreenRectangle);
			ControlManager.Add (bgImage);

			//Arrow
			Texture2D arrowTexture = content.Load<Texture2D> (@"GUI\leftArrowUp");
			arrowImage = new PictureBox (arrowTexture,new Rectangle (0,0,arrowTexture.Width,arrowTexture.Height));
			ControlManager.Add (arrowImage);

			//New Game
			start = new LinkLabel ();
			start.Text = "New Game";
			start.Size = start.SpriteFont.MeasureString(start.Text);
			start.Selected += new EventHandler (menuItem_Selected);
			ControlManager.Add (start);


			//LoadGame
			load = new LinkLabel ();
			load.Text = "Load Game";
			load.Size = load.SpriteFont.MeasureString (load.Text);
			load.Selected += new EventHandler (menuItem_Selected);
			ControlManager.Add (load);


			//Exit Game
			exit = new LinkLabel ();
			exit.Text = "Exit Game";
			exit.Size = load.SpriteFont.MeasureString (exit.Text);
			exit.Selected += new EventHandler (menuItem_Selected);
			ControlManager.Add (exit);

			ControlManager.NextControl ();
			ControlManager.FocusChanged += new EventHandler (ControlManager_FocusChanged);
			Vector2 position = new Vector2 (350, 500);


			foreach (Control c in ControlManager) {
				if (c is LinkLabel) {
					if (c.Size.X > maxItemWidth) {
						maxItemWidth = c.Size.X;
					}
					c.Position = position;
					position.Y += c.Size.Y +5f;
				}
			}

			ControlManager_FocusChanged (start, null);


		}

		public override void Update (GameTime gameTime) {
			ControlManager.Update (gameTime);
			base.Update (gameTime);
		}

		public override void Draw (GameTime gameTime) {
			GameRef.spriteBatch.Begin ();
			base.Draw (gameTime);
			ControlManager.Draw (GameRef.spriteBatch);
			GameRef.spriteBatch.End ();

		}

		private void menuItem_Selected (object sender, EventArgs e) {
			if (sender == start) {
				StateManager.PushState (GameRef.gamePlay);
			}else if (sender == load) {
				StateManager.PushState (GameRef.gamePlay);
			}else if (sender == exit) {
				GameRef.Exit();
			}
			
		}

		private void ControlManager_FocusChanged (object sender, EventArgs e) {
			Control control = sender as Control;
			Vector2 position = new Vector2 (control.Position.X + maxItemWidth + 10f, control.Position.Y);
			arrowImage.SetPosition(position);
		}

	}
}
