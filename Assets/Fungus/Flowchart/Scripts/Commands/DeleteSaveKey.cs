using UnityEngine;
using System;
using System.Collections;

namespace Fungus
{
	[CommandInfo("Variable", 
	             "Delete Save Key", 
	             "Deletes a saved value from permanent storage.")]
	[AddComponentMenu("")]
	public class DeleteSaveKey : Command
	{
		[Tooltip("Name of the saved value. Supports variable substition e.g. \"player_{$PlayerNumber}")]
		public string key = "";

		public override void OnEnter()
		{
			if (key == "")
			{
				Continue();
				return;
			}
			
			Flowchart flowchart = GetFlowchart();
			
			// Prepend the current save profile (if any)
			string prefsKey = SetSaveProfile.saveProfile + "_" + flowchart.SubstituteVariables(key);
			
			PlayerPrefs.DeleteKey(prefsKey);

			Continue();
		}
		
		public override string GetSummary()
		{
			if (key.Length == 0)
			{
				return "Error: No stored value key selected";
			}

			return key;
		}
		
		public override Color GetButtonColor()
		{
			return new Color32(235, 191, 217, 255);
		}
	}
	
}