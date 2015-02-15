using UnityEngine;
using System;
using System.Collections.Generic;
namespace pickable {
	public class PickableManager {
		private Dictionary<string,int> dictPickablesCount;
		private  static int coinIncrementerValue ;
		private static bool magnet_on;
		private static Dictionary<string,float> pickableTimers;

		public PickableManager() {
			coinIncrementerValue = 1;
			pickableTimers = new Dictionary<string,float > ();
			dictPickablesCount = new Dictionary<string,int> ();
			addItems ();
		}
		public void addItems() {
			dictPickablesCount.Add (Constants.COIN, 0);
			dictPickablesCount.Add (Constants.COINDOUBLER, 0);
		}
		public void incrementItemCountfor(string item) {
			int value;
			setBonusforItem(item);
		}

		void setBonusforItem(string item) {
			switch (item) {
			case Constants.COIN:
				int value;
				if(dictPickablesCount.TryGetValue(item,out value)) {
					value+=coinIncrementerValue;
					dictPickablesCount[item] = value;
					//Debug.Log("Coin Collected"+value);
					UIController.setCoins(value);
				}
				break;
			case Constants.COINDOUBLER:
				coinIncrementerValue = 2;
				pickableTimers[Constants.COINDOUBLER] = UpdateManager.Instance.getCurrentValueforUpgrade(Constants.COINDOUBLER);
				break;
			case Constants.MAGNET :
				Debug.Log("Magnet power is "+UpdateManager.Instance.getCurrentValueforUpgrade(Constants.MAGNET));
				pickableTimers[Constants.MAGNET] = UpdateManager.Instance.getCurrentValueforUpgrade(Constants.MAGNET);
				//Debug.Log("Inside collide Magnet");
				break;
			}
		}

		public int getCountForItem(string item){
			int value;
			if (dictPickablesCount.TryGetValue (item, out value)) {
				return value;
			}
			return 0;
		}

		public static void setCoinIncrementerValue(int value) {
			coinIncrementerValue = value;
		}

		public static void updateTimers(float deltatime) {
			List<string> keyList = new List<string>(pickableTimers.Keys);
			foreach (string key in keyList) {
				float value;
				if (pickableTimers.TryGetValue (key, out value)) {
					if(value > 0) {
						value -=deltatime;
						pickableTimers[key] = value;
					}else {
						switch(key) {
						case Constants.COINDOUBLER:
							coinIncrementerValue = 1;
							break;
						}
						pickableTimers.Remove(key);

					}
				}
			}
		}

		public static bool isTimerOnforItem(string item) {
			float value;
			return pickableTimers.TryGetValue (item, out value);
		}
	} 
}