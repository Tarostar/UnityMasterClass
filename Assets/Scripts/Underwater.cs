using UnityEngine;
using System.Collections;

// This script enables the underwater effect.  Attach it to the main camera

public class Underwater : MonoBehaviour 
{
	// The underwater fog color
	public Color fogColor;
	
	// The water transform
	public Transform water;
	
	// The maximum density of the underwater fog
	public float maxFogDensity = 0.1f;
	
	// Save the scene fog settings
	private bool savedFogEnabledFlag;
	private Color savedFogColor;
	private float savedFogDensity;
	private Material savedSkyboxMaterial;
	
	// remember if we are under water
	private bool isUnderWater = false;
	
	// The level of the water surface
	private float underwaterLevel;
	
	// Use this for initialization
	void Start () 
	{
		// Set the camera background color
		camera.backgroundColor = fogColor;
		
		// Save the scene default fog settings
		savedFogEnabledFlag = RenderSettings.fog;
		savedFogColor = RenderSettings.fogColor;
		savedFogDensity = RenderSettings.fogDensity;
		savedSkyboxMaterial = RenderSettings.skybox;
		
		// cache the water surface level
		underwaterLevel = water.position.y;
		
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		// If the main camera is under the water
		if (transform.position.y < underwaterLevel)
		{
			if (false == isUnderWater)
			{
				// enable the fog
				RenderSettings.fog = true;
			
				// set the fog color
				RenderSettings.fogColor = fogColor;
			
				// set the fog density
				RenderSettings.fogDensity = maxFogDensity;
			
				// turn off the skybox
				RenderSettings.skybox = null;
			
				// rememeber we are under water
				isUnderWater = true;
			}
			
		}
		// The main camera is not under the water
		else
		{
			if (true == isUnderWater)
			{
				// restore the fog settings
				RenderSettings.fog = savedFogEnabledFlag;
				RenderSettings.fogColor = savedFogColor;
				RenderSettings.fogDensity = savedFogDensity;
				RenderSettings.skybox = savedSkyboxMaterial;
				
				// remember that the camera is not under water
				isUnderWater = false;
				
			}
		}
	
	}
}
