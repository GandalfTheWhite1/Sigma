using UnityEngine;
using System.Collections;

public class MapCreature : MonoBehaviour {

	public int [] minMapSize = new int[2];
	public int [] maxMapSize = new int[2];
	public int [,] map;

	public int xArray = 0;
	public int yArray = 0;

	public int[] startUnit = new int[2];
	public int[] workOnUnit = new int[2];
	// Use this for initialization
	void Start () 
	{
		RandomMap();
	}
	
	// Update is called once per frame
	void Update ()
	{

	}

	public void RandomMap()
	{
		createMapSize();
		resetMap();
		populateMap();
	}

	public void createMapSize()
	{
		xArray = Random.Range(minMapSize[0],maxMapSize[0]);
		yArray = Random.Range(minMapSize[1],maxMapSize[1]);
		map = new int[xArray,yArray];
		//map = new int[3,3];

	}

	public void populateMap()
	{
		startPlace();

		for(int i = 0;i<xArray;i++)
		{
			for(int z = 0;z<yArray;z++)
			{
				map[i,z] = (int)Vector2.Distance(new Vector2(startUnit[0],startUnit[1]),new Vector2(i,z));
				Debug.Log (map[i,z]);
			}
		}



	}

	public void resetMap()
	{
		for(int i = 0;i<xArray;i++)
		{
			for(int z = 0;z<yArray;z++)
			{
				map[i,z] = 0;
			}
		}
	}

	public void startPlace()
	{
		startUnit[0] = Random.Range(2,xArray);
		startUnit[1] = Random.Range(2,yArray);
		map[startUnit[0],startUnit[1]] = 1;
	}




}
