using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LitVe.Render;

namespace LitVe.ComponentData.Mapping {
	class Floor {

		private Dictionary <Vector2,TerrainPiece> terrainPieces;
		private int seed;
		private Texture2D texture;

		public Floor (int se, Texture2D tex) {
			terrainPieces = new Dictionary<Vector2,TerrainPiece> ();
			seed = se;
			texture = tex;
		}

		public void addPiece (Vector2 pos) {
			terrainPieces.Add (pos, new TerrainPiece (pos, texture, seed));
		}

		public List <TerrainPiece>  getPieces () {
			return terrainPieces.Values.ToList();
		}

		public TerrainPiece getPiece (Vector2 pos) {
			return terrainPieces [pos];
		}

	}
}
