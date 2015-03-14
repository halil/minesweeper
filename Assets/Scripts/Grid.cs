using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour {

	public static int w = 10;
	public static int h = 13; 
	public static Element[,] elements = new Element[w, h];

	void Start () {

	}

	void Update () {
	
	}

	public static void uncoverMines() {
		foreach (Element element in elements) {
			if (element.mine) {
				element.loadTexture(0);
			}
		}
	}

	public static bool mineAt(int x, int y) {
		if ((x >= 0 && y >= 0) && (x < w && y < h)) {
			return elements[x, y].mine;
		}
			
		return false;
	}

	public static int adjacentMines(int x, int y) {
		int count = 0;
		
		if (mineAt(x,   y+1)) ++count; // top
		if (mineAt(x+1, y+1)) ++count; // top-right
		if (mineAt(x+1, y  )) ++count; // right
		if (mineAt(x+1, y-1)) ++count; // bottom-right
		if (mineAt(x,   y-1)) ++count; // bottom
		if (mineAt(x-1, y-1)) ++count; // bottom-left
		if (mineAt(x-1, y  )) ++count; // left
		if (mineAt(x-1, y+1)) ++count; // top-left
		
		return count;
	}

	public static void FFuncover(int x, int y, bool[,] visited) {
		if (x >= 0 && y >= 0 && x < w && y < h) {
			if (visited[x, y]) {
				return;
			}

			elements[x, y].loadTexture(adjacentMines(x, y));

			if (adjacentMines(x, y) > 0) {
				return;
			}

			visited[x, y] = true;

			FFuncover(x-1, y, visited);
			FFuncover(x+1, y, visited);
			FFuncover(x, y-1, visited);
			FFuncover(x, y+1, visited);
		}
	}

	public static bool isFinished() {
		foreach (Element element in elements) {
			if (element.isCovered() && !element.mine) {
				return false;
			}	
		}

		return true;
	}
}