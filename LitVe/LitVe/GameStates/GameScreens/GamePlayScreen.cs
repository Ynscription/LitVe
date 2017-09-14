using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;using LitVe.Input;using LitVe.Render;using LitVe.ComponentData.Mapping;

namespace LitVe.GameStates.GameScreens {
	public class GamePlayScreen : BaseGameState{

		private Scene scene;

		public GamePlayScreen (Game game, GameStateManager manager) :base (game, manager){
			


		}


		public override void Initialize () {
			base.Initialize ();
			
		}

		protected override void LoadContent () {
			base.LoadContent ();
			Camera camera = new Camera (Vector3.Zero, Vector3.UnitX, Vector3.UnitZ, Matrix.CreatePerspectiveFieldOfView (MathHelper.ToRadians (90), Game.GraphicsDevice.Viewport.AspectRatio, 0.1f, 1000f));
			MouseHandler.FixedCursor = true;
			scene = new Scene (Game, camera);
			Game.Components.Add (scene);

			Actor world = new Actor (Vector3.Zero,Vector3.Zero);
			Texture2D texture = Game.Content.Load <Texture2D> (@"Map\Grass");
			Floor floor = new Floor (5600, texture);
			for (int i = 0; i < 3; i++) {
				for (int j = 0; j < 3; j++) {
					floor.addPiece (new Vector2 (i,j));
				}
			}
			MapActor  mapActor = new MapActor (floor, Vector3.Zero, Vector3.Zero, GraphicsDevice);

			scene.addActor (world);
			scene.addActor (world,mapActor);

			
		}

		public override void Update (GameTime gameTime) {
			if (KeyBoardHandler.KeyReleased (Keys.Escape)) {
				GameRef.Exit();
			}
			if (KeyBoardHandler.KeyReleased (Keys.C)) {
				MouseHandler.FixedCursor = !MouseHandler.FixedCursor;
			}
			base.Update (gameTime);
		}

		public override void Draw (GameTime gameTime) {
			base.Draw (gameTime);
		}


	}
}
