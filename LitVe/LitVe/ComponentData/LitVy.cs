using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LitVe.ComponentData{
	public class LitVy : Entity{

		private int age = 0;
		private Random random;
		private float speed;


		public LitVy () {
			beingColor = Color.White.ToVector3();
			position = Vector3.Zero;
			rotation = Vector3.Zero;
			random = new Random ();
			speed = 0.05f;
		}

		public override void update (GameTime gameTime) {
			
		}


	}
}
