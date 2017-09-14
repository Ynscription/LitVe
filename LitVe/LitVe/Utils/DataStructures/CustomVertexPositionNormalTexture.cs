using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LitVe.Utils.DataStructures {
	public struct CustomVertexPositionNormalTexture {
		public Vector3 Position;
		public Vector3 Normal;
		public Vector2 TextureCoordinate;

		public CustomVertexPositionNormalTexture (Vector3 pos, Vector3 nor, Vector2 texCoor) {
			Position = pos;
			Normal = nor;
			TextureCoordinate = texCoor;
		}

		public readonly static VertexDeclaration VertexDeclaration = new VertexDeclaration
		(
			new VertexElement (0, VertexElementFormat.Vector3, VertexElementUsage.Position, 0),
			new VertexElement (12, VertexElementFormat.Vector3, VertexElementUsage.Normal, 0),
			new VertexElement (24, VertexElementFormat.Vector2, VertexElementUsage.TextureCoordinate, 0)
			
		);
	}
}
