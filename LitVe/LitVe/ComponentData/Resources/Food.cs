using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LitVe.ComponentData.Resources {
	class Food : Resource, IRenewable{
		float renewRate;

		public float RenewRate {
			get {return renewRate;}
			set {renewRate = RenewRate;}
		}
		
		public Food (int initq) : base (initq) {
			renewRate = 0;
		}


		public void renew () {

		}
	}
}
