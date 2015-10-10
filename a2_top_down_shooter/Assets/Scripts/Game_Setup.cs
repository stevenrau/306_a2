using UnityEngine;
using System.Collections;

public class Game_Setup : MonoBehaviour {

	//The player (more specifically, the player script)
	public Player_Control player;

	// The camera border
	private float top_screen_cam_border;
	private float left_screen_cam_border;
	private float bottom_screen_cam_border;
	private float right_screen_cam_border;

	// Game objects used to build the environment
	public GameObject stone_tile;
	public GameObject brick_top_left_corner;
	public GameObject brick_top_right_corner;
	public GameObject brick_bottom_left_corner;
	public GameObject brick_bottom_right_corner;
	public GameObject brick_top_middle;
	public GameObject brick_left_middle;
	public GameObject brick_right_middle;
	public GameObject brick_bottom_middle;
	public GameObject ground_top_left_corner;
	public GameObject ground_top_right_corner;
	public GameObject ground_bottom_left_corner;
	public GameObject ground_bottom_right_corner;
	public GameObject ground_top_middle;
	public GameObject ground_left_middle;
	public GameObject ground_right_middle;
	public GameObject ground_bottom_middle;
	public GameObject ground_middle;

	// Use this for initialization
	void Start () {
	
	}

	void Awake()
	{
		Get_Screen_Cam_Borders();

		//Get the min/max x/y vals. Top left pivot point on sprites, so right and bottom need one less tile
		int min_x_pos = (int)Mathf.Floor(left_screen_cam_border);
		int max_x_pos = (int)Mathf.Ceil(right_screen_cam_border) - 1;
		int min_y_pos = (int)Mathf.Floor(bottom_screen_cam_border) + 1;
		int max_y_pos = (int)Mathf.Ceil(top_screen_cam_border);
		//Build_Background(min_x_pos, max_x_pos, min_y_pos, max_y_pos);

		//Build the border for the playable area. move one tile in from camera limit
		/*min_x_pos += 1;
		max_x_pos -= 1;
		min_y_pos += 1;
		max_y_pos -= 1;*/
		Build_Brick_Border(min_x_pos, max_x_pos, min_y_pos, max_y_pos);

		//Build_Edge_Colliders(min_x_pos, max_x_pos, min_y_pos, max_y_pos);

		//Build the grass for the playable area. move one tile in from the brick border
		min_x_pos += 1;
		max_x_pos -= 1;
		min_y_pos += 1;
		max_y_pos -= 1;
		Build_Ground(min_x_pos, max_x_pos, min_y_pos, max_y_pos);

		//Instantiate the player in the centre of the screen
		Instantiate(player, Vector3.zero, Quaternion.identity);
	}

	/* Get the X and Y coordinates for the camera's border.
	 * These will be used to build the arena using the full screen real estate */
	void Get_Screen_Cam_Borders()
	{
		//Camera's orthographic size is 1/2 total screen height
		top_screen_cam_border = Camera.main.orthographicSize;
		//The cam is centered, so bottom border is negative of top limit
		bottom_screen_cam_border = -1f * top_screen_cam_border;
		//Get the right border by multiplying the height by the aspect ratio
		right_screen_cam_border = Camera.main.orthographicSize * ((Screen.width*1.0f)/Screen.height);
		left_screen_cam_border = -1f * right_screen_cam_border;
	}


	/**
	 * Fills the bacground with the background tile.
	 * This might not be used if the brick border extends to the edges of the camera
	 */
	void Build_Background(int min_x_pos, int max_x_pos, int min_y_pos, int max_y_pos)
	{
		//Build the background using the stone tiles
		for (int x = min_x_pos; x <= max_x_pos; x++)
		{
			for (int y = min_y_pos; y <= max_y_pos; y++)
			{
				Instantiate(stone_tile, new Vector3(x, y, 0), Quaternion.identity);
			}
		}
	}

	/*
	 * Builds a brick border to signify the playing area.
	 * Edge colliders will be built to disallow the player from leaving the bordered area
	 */
	void Build_Brick_Border(int min_x_pos, int max_x_pos, int min_y_pos, int max_y_pos)
	{
		//Build the background using the stone tiles
		for (int x = min_x_pos; x <= max_x_pos; x++)
		{
			for (int y = min_y_pos; y <= max_y_pos; y++)
			{
				if (x == min_x_pos && y == max_y_pos)
				{
					Instantiate(brick_top_left_corner, new Vector3(x, y, 0), Quaternion.identity);
				}
				else if (x == min_x_pos && y != max_y_pos && y != min_y_pos)
				{
					Instantiate(brick_left_middle, new Vector3(x, y, 0), Quaternion.identity);
				}
				else if (x == min_x_pos && y == min_y_pos)
				{
					Instantiate(brick_bottom_left_corner, new Vector3(x, y, 0), Quaternion.identity);
				}
				else if (y == min_y_pos && x != min_x_pos && x != max_x_pos)
				{
					Instantiate(brick_bottom_middle, new Vector3(x, y, 0), Quaternion.identity);
				}
				else if (y == min_y_pos && x == max_x_pos)
				{
					Instantiate(brick_bottom_right_corner, new Vector3(x, y, 0), Quaternion.identity);
				}
				else if (x == max_x_pos && y != max_y_pos && y != min_y_pos)
				{
					Instantiate(brick_right_middle, new Vector3(x, y, 0), Quaternion.identity);
				}
				else if (x == max_x_pos && y == max_y_pos)
				{
					Instantiate(brick_top_right_corner, new Vector3(x, y, 0), Quaternion.identity);
				}
				else if (y == max_y_pos && x != min_x_pos && x != max_x_pos)
				{
					Instantiate(brick_top_middle, new Vector3(x, y, 0), Quaternion.identity);
				}
			}
		}
	}

	/*
	 * Builds the ground inside the bordered area with the ground tiles
	 */
	void Build_Ground(int min_x_pos, int max_x_pos, int min_y_pos, int max_y_pos)
	{
		//Build the ground using the grass tiles
		for (int x = min_x_pos; x <= max_x_pos; x++)
		{
			for (int y = min_y_pos; y <= max_y_pos; y++)
			{
				if (x == min_x_pos && y == max_y_pos)
				{
					Instantiate(ground_top_left_corner, new Vector3(x, y, 0), Quaternion.identity);
				}
				else if (x == min_x_pos && y != max_y_pos && y != min_y_pos)
				{
					Instantiate(ground_left_middle, new Vector3(x, y, 0), Quaternion.identity);
				}
				else if (x == min_x_pos && y == min_y_pos)
				{
					Instantiate(ground_bottom_left_corner, new Vector3(x, y, 0), Quaternion.identity);
				}
				else if (y == min_y_pos && x != min_x_pos && x != max_x_pos)
				{
					Instantiate(ground_bottom_middle, new Vector3(x, y, 0), Quaternion.identity);
				}
				else if (y == min_y_pos && x == max_x_pos)
				{
					Instantiate(ground_bottom_right_corner, new Vector3(x, y, 0), Quaternion.identity);
				}
				else if (x == max_x_pos && y != max_y_pos && y != min_y_pos)
				{
					Instantiate(ground_right_middle, new Vector3(x, y, 0), Quaternion.identity);
				}
				else if (x == max_x_pos && y == max_y_pos)
				{
					Instantiate(ground_top_right_corner, new Vector3(x, y, 0), Quaternion.identity);
				}
				else if (y == max_y_pos && x != min_x_pos && x != max_x_pos)
				{
					Instantiate(ground_top_middle, new Vector3(x, y, 0), Quaternion.identity);
				}
				else
				{
					Instantiate(ground_middle, new Vector3(x, y, 0), Quaternion.identity);
				}
			}
		}
	}

	/*
	 * Builds edge colliders along the inside border of the tiles lying along the
	 * min/max x/y positions provided
	 */
	void Build_Edge_Colliders(int min_x_pos, int max_x_pos, int min_y_pos, int max_y_pos)
	{
		EdgeCollider2D edge = gameObject.AddComponent<EdgeCollider2D>();

		edge.points = new Vector2[]
		{
			new Vector2(-5, 0),
			new Vector2(5, 0)
		};
	}
}
