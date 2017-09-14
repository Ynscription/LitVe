using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LitVe.ComponentData.Mapping;
using LitVe.Utils.DataStructures;
using Microsoft.Xna.Framework.Content;

namespace LitVe.Render {
	class MapActor : Actor{

		private GraphicsDevice graphicsDevice;
		Floor floor;
		BasicEffect effect;

		public MapActor (Floor f, Vector3 p, Vector3 r, GraphicsDevice gD) : base (p, r) {
			graphicsDevice = gD;
			floor = f;
			effect = new BasicEffect (graphicsDevice);
			//effect.EnableDefaultLighting ();
			effect.LightingEnabled = true;
			effect.AmbientLightColor = new Vector3 (0.3f, 0.3f, 0.3f);
			effect.DirectionalLight0.Direction = new Vector3 (1f, 1f, -1f);
			effect.DirectionalLight0.DiffuseColor = new Vector3 (0.8f, 0.8f, 0.8f);
		}

		public override void LoadContent (ContentManager Content) {
			base.LoadContent (Content);
		}

		public override void draw (Matrix world, Camera camera) {
			RasterizerState rasterizerState = new RasterizerState ();
			rasterizerState.CullMode = CullMode.None;
			graphicsDevice.RasterizerState = rasterizerState;

			Matrix projection = camera.Projection;
			Matrix view = camera.View;

			effect.Projection = projection;
			effect.View = view;
			effect.TextureEnabled = true;
			
			
			List <TerrainPiece> pieces = floor.getPieces ();
			effect.Texture = pieces[0].Texture;

			foreach (TerrainPiece e in pieces) {
				Vector3 relativePos = new Vector3 ();
				relativePos.X = e.Position.X*15;
				relativePos.Y = e.Position.Y*15;
				effect.World = world * Matrix.CreateTranslation (relativePos) * Matrix.CreateRotationX (Rotation.X) * Matrix.CreateRotationY (Rotation.Y) * Matrix.CreateRotationZ (Rotation.Z);
				
				foreach (EffectPass pass in effect.CurrentTechnique.Passes) {
					pass.Apply ();
					
					CustomVertexPositionNormalTexture [] vertices = e.getVerticesPosNorTex ();
					int [] indices = e.getIndices ();
					graphicsDevice.DrawUserIndexedPrimitives <CustomVertexPositionNormalTexture>(PrimitiveType.TriangleList, vertices, 0, vertices.Length, indices, 0, indices.Length / 3, CustomVertexPositionNormalTexture.VertexDeclaration);
				}
			}

		}
	}
}
