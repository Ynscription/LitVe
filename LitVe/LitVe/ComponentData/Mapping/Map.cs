using LitVe.ComponentData.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LitVe.ComponentData.Mapping {
	class Map {
		private Texture2D _terrainTexture;
		private Dictionary <Vector2, Resource> _resources;
		private Floor floor;


		public Map (Texture2D terraintx, int seed) {
			_terrainTexture = terraintx;
			
		}

	}
}
