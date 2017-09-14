using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LitVe.Utils.DataStructures;

namespace LitVe.ComponentData.Mapping {
	class TerrainPiece {

		private int sizex, sizey;
		private float [,] heightMap;
		private CustomVertexPositionNormalTexture[] verPosTexNor;
		private int [] indices;

		private Vector2 position;
		private int seed;
		private Texture2D texture;

		public Vector2 Position {
			get { return position; }
			set { position = value; }
		}
		public Texture2D Texture {
			get { return texture; }
			set { texture = value; }
		}

		public TerrainPiece (Vector2 pos, Texture2D tex, int se) {
			position = pos;
			seed = se;
			sizex = 16;
			sizey = 16;
			texture = tex;
			heightMap = new float [sizex, sizey];
			verPosTexNor = new CustomVertexPositionNormalTexture [sizex * sizey];
			generateHeightMap (seed);
			setUpVertices ();
			setUpIndices ();
			setUpNormals();

		}

		private void generateHeightMap (int seed) {
			PerlinGenerator generator = new PerlinGenerator (1f, 0.01f, 8f, 6, seed);
			for (int i = 0; i < sizex; i++) {
				for (int j = 0; j < sizey; j++) {
					heightMap [i, j] = generator.getHeight (i + position.X * sizex - position.X, j + position.Y * sizey - position.Y);
				}
			}
		}

		private void setUpVertices () {
			for (int x = 0; x < sizex; x++) {
				for (int y = 0; y < sizey; y++) {
					verPosTexNor [x + y * sizex].Position = new Vector3 (x, y, heightMap [x, y]);
					verPosTexNor[x + y * sizex].TextureCoordinate.X = (float)x / 30.0f;
					verPosTexNor[x + y * sizex].TextureCoordinate.Y = (float)y / 30.0f;
				}
			}
		}

		private void setUpIndices () {
			indices = new int [(sizex - 1) * (sizey - 1) * 6];
			int counter = 0;
			for (int y = 0; y < sizey - 1; y++) {
				for (int x = 0; x < sizex - 1; x++) {
					int lowerLeft = x + y * sizex;
					int lowerRight = (x + 1) + y * sizex;
					int topLeft = x + (y + 1) * sizex;
					int topRight = (x + 1) + (y + 1) * sizex;

					indices [counter++] = topLeft;
					indices [counter++] = lowerRight;
					indices [counter++] = lowerLeft;

					indices [counter++] = topLeft;
					indices [counter++] = topRight;
					indices [counter++] = lowerRight;
				}
			}
		}

		private void setUpNormals () {
			for (int i = 0; i < heightMap.Length; i++) {
				verPosTexNor [i].Normal = new Vector3 (0, 0, 0);
			}
			for (int i = 0; i < indices.Length / 3; i++) {
				int index1 = indices [i * 3];
				int index2 = indices [i * 3 + 1];
				int index3 = indices [i * 3 + 2];

				Vector3 side1 = verPosTexNor [index1].Position - verPosTexNor [index3].Position;
				Vector3 side2 = verPosTexNor [index1].Position - verPosTexNor [index2].Position;
				Vector3 normal = Vector3.Cross (side1, side2);

				verPosTexNor [index1].Normal += normal;
				verPosTexNor [index2].Normal += normal;
				verPosTexNor [index3].Normal += normal;
			}
 
		}

		public CustomVertexPositionNormalTexture [] getVerticesPosNorTex () {
			return verPosTexNor;
		}
		public int [] getIndices () {
			return indices;
		}


	}
}
