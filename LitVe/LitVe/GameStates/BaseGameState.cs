using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using LitVe.GUI.Controls;

namespace LitVe.GameStates {
	public abstract partial class BaseGameState :GameState {

		protected Game1 GameRef;

		protected ControlManager ControlManager;

		public BaseGameState (Game game, GameStateManager manager) :base (game, manager) {
			GameRef = (Game1)game;
		}

		protected override void LoadContent () {
			ContentManager content = Game.Content;
			SpriteFont menuFont = content.Load<SpriteFont> (@"Fonts\ControlFont");
			ControlManager = new ControlManager (menuFont);
			base.LoadContent ();
		}

		public override void Update (GameTime gameTime) {
			base.Update (gameTime);
		}

		public override void Draw (GameTime gameTime) {
			base.Draw (gameTime);
		}


	}
}
