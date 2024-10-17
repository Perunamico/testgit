using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reproduction : MonoBehaviour
{
    HapticPlugin[] devices;      //Is the stylus in the effect zone?
    Vector3[] devicePoint;  // Current location of stylus         // Distance from stylus to zone collider.
    int[] FXID;             // ID of the effect.  (Per device.)
	public Vector3 LocalStylusPos;
	// Start is called before the first frame update
	void Start()
	{
		//Initialize the list of haptic devices.
		devices = (HapticPlugin[])Object.FindObjectsOfType(typeof(HapticPlugin));
		devicePoint = new Vector3[devices.Length];
		FXID = new int[devices.Length];
		// Generate an OpenHaptics effect ID for each of the devices.
		for (int ii = 0; ii < devices.Length; ii++)
		{
			devicePoint[ii] = Vector3.zero;
			FXID[ii] = HapticPlugin.effects_assignEffect(devices[ii].configName);
			int ID = FXID[ii];
			HapticPlugin device = devices[ii];

		}

	}


	//!  Update() is called once per frame.
	//! 
	//! This function 
	//! - Determines if a haptic stylus is inside the collider
	//! - Updates the effect settings.
	//! - Starts and stops the effect when appropriate.
	void Update()
	{
		for (int ii = 0; ii < devices.Length; ii++)
		{
			//Debug.Log(devices.Length);
			HapticPlugin device = devices[ii];
			int ID = FXID[ii];

			// If a haptic effect has not been assigned through Open Haptics, assign one now.
			if (ID == -1)
			{
				FXID[ii] = HapticPlugin.effects_assignEffect(devices[ii].configName);
				ID = FXID[ii];

				if (ID == -1) // Still broken?
				{
					Debug.LogError("Unable to assign Haptic effect.");
					continue;
				}
			}

			// Determine if the stylus is in the "zone". 
			Vector3 StylusPos = device.stylusPositionWorld; //World Coordinates
			LocalStylusPos = device.transform.InverseTransformPoint(StylusPos);
			//Debug.Log(LocalStylusPos);

		




		}
	}



}
