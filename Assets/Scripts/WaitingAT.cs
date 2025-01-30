using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class WaitingAT : ActionTask {
		public float changeInThirst, changeInPee;

		public BBParameter<float> thirstLevel, peeLevel;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			// Update thirst and pee
			thirstLevel.value += changeInThirst * Time.deltaTime;
			thirstLevel.value = Mathf.Clamp(thirstLevel.value, 0, 100);

			peeLevel.value += changeInPee * Time.deltaTime;
			peeLevel.value = Mathf.Clamp(peeLevel.value, 0, 100);
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}