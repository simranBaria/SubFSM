using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions {

	public class NeedToPeeCT : ConditionTask {
		public float detectionRange;
		public LayerMask fireHydrants;

		public BBParameter<Transform> targetFireHydrant;
		public BBParameter<float> peeLevel;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit(){
			return null;
		}

		//Called whenever the condition gets enabled.
		protected override void OnEnable() {
			
		}

		//Called whenever the condition gets disabled.
		protected override void OnDisable() {
			
		}

		//Called once per frame while the condition is active.
		//Return whether the condition is success or failure.
		protected override bool OnCheck() {
			// Detect fire hydrants
			try
			{
				Collider[] colliders = Physics.OverlapSphere(agent.transform.position, detectionRange, fireHydrants);
				// Go pee if pee level is over 50
				targetFireHydrant.value = colliders[0].gameObject.transform;
				if (peeLevel.value >= 50) return true;
			}
            catch { }

			// Go pee regardless of detection if pee level is max
			if (peeLevel.value >= 100)
			{
				targetFireHydrant.value = GameObject.FindGameObjectWithTag("Fire Hydrant").transform;
				return true;
			}

			return false;
		}
	}
}