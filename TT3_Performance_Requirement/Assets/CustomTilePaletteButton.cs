using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityToolbarExtender;


[InitializeOnLoad]
	public class CustonTilePaletteButton
	{
		static CustonTilePaletteButton()
		{
			ToolbarExtender.LeftToolbarGUI.Add(OnToolbarGUI);
		}

		static void OnToolbarGUI()
		{
			GUILayout.FlexibleSpace();

			// if(GUILayout.Button(new GUIContent("1", "Start Scene 1"), ToolbarStyles.commandButtonStyle))
			// {
			// 	SceneHelper.StartScene("Assets/ToolbarExtender/Example/Scenes/Scene1.unity");
			// }

			// if(GUILayout.Button(new GUIContent("2", "Start Scene 2"), ToolbarStyles.commandButtonStyle))
			// {
			// 	SceneHelper.StartScene("Assets/ToolbarExtender/Example/Scenes/Scene2.unity");
			// }
		}
	}