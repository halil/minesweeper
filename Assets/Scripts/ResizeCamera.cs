using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
public class ResizeCamera : MonoBehaviour 
{
	private float   DesignOrthographicSize;
	private float   DesignAspect;
	private float   DesignWidth;
	
	public  float   DesignAspectHeight;
	public  float   DesignAspectWidth;
	
	public void Awake()
	{
		this.DesignOrthographicSize = this.camera.orthographicSize;
		this.DesignAspect = this.DesignAspectHeight / this.DesignAspectWidth;
		this.DesignWidth = this.DesignOrthographicSize * this.DesignAspect;
		
		this.Resize();
	}
	
	public void Resize()
	{       
		float wantedSize = this.DesignWidth / this.camera.aspect;
		this.camera.orthographicSize = Mathf.Max(wantedSize, 
		                                         this.DesignOrthographicSize);
	}
}
