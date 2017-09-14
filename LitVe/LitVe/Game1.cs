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
using LitVe.Input;
using LitVe.GameStates;
using LitVe.GameStates.GameScreens;


namespace LitVe {
	
	public class Game1 : Microsoft.Xna.Framework.Game {
		GraphicsDeviceManager graphics;
		public SpriteBatch spriteBatch;

		GameStateManager stateManager;
		public TitleScreen title;
		public MainMenuScreen menu;
		public GamePlayScreen gamePlay;

		public int screenWidth = 1024;
		public int screenHeight = 768;

		public readonly Rectangle ScreenRectangle;


		private Model model;

		public Game1 () {
			graphics = new GraphicsDeviceManager (this);
			graphics.PreferredBackBufferWidth = screenWidth;
			graphics.PreferredBackBufferHeight = screenHeight;

			ScreenRectangle = new Rectangle (0, 0, screenWidth, screenHeight);
			Content.RootDirectory = "Content";

			Components.Add (new KeyBoardHandler (this));
			Components.Add (new MouseHandler (this));

			stateManager = new GameStateManager (this);
			Components.Add (stateManager);
			title = new TitleScreen (this, stateManager);
			menu = new MainMenuScreen (this, stateManager);
			gamePlay = new GamePlayScreen (this, stateManager);

			stateManager.ChangeState(title);
		}

		
		protected override void Initialize () {
			base.Initialize ();

		}

		
		protected override void LoadContent () {
			spriteBatch = new SpriteBatch (GraphicsDevice);
			model = Content.Load<Model> (@"Models\LitVy005");
			
		
		}

		
		protected override void UnloadContent () {
			
		
		}
		
		
		protected override void Update (GameTime gameTime) {
			if (KeyBoardHandler.KeyReleased (Keys.Escape)) {
				Exit();	
			}
			base.Update (gameTime);
		}

		
		protected override void Draw (GameTime gameTime) {
			GraphicsDevice.Clear (Color.CornflowerBlue);
					

			base.Draw (gameTime);
		}
	}
}
