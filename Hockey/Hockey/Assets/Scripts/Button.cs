using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour
{
	public void LoadScene(int level)
	{
		Application.LoadLevel(level);
	}
}
