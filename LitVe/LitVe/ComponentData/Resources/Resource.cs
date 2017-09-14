using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LitVe.ComponentData.Resources {
	class Resource {
		protected int _quantity;

		public Resource (int initq) {
			_quantity = initq;
		}


		public int getQuantity () {
			return _quantity;
		}
		public void removeQuantity (int rq) {
			_quantity = _quantity - rq;
		}

	}
}
