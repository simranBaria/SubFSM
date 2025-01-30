using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions {

	public class ThresholdReachCT : ConditionTask {
		public BBParameter<float> checkValue;
		public BBParameter<Transform> targetOnceReached, target;

		public float threshold;
		public bool checkIfAbove;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit(){
			return null;
		}

		//Called whenever the condition gets enabled.
		protected override void OnEnable() {
			target.value = targetOnceReached.value;
		}

		//Called whenever the condition gets disabled.
		protected override void OnDisable() {
			
		}

		//Called once per frame while the condition is active.
		//Return whether the condition is success or failure.
		protected override bool OnCheck() {
			// Check if the threshold is greater than or less than the value
			if (checkIfAbove) return checkValue.value >= threshold;
			else return checkValue.value <= threshold;
		}
	}
}