using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesAI : MonoBehaviour
{
    public float roamChangeDirFloat = 2f;    

    private enum State 
	{
		Roaming
	}

	private State state;
	private EnemiesPath enemiesPathfinding;

    private void Awake()
	{
		enemiesPathfinding = GetComponent<EnemiesPath>();
		state = State.Roaming;
	}

    private void Start()
	{
		StartCoroutine(RoamingRoutine());
	}

    private IEnumerator RoamingRoutine()
	{
		while (state == State.Roaming)
		{
			Vector2 roamPosition = GetRoamingPosition();
			enemiesPathfinding.MoveTo(roamPosition);
			yield return new WaitForSeconds(roamChangeDirFloat);
		}
	}

    private Vector2 GetRoamingPosition()
	{
		return new Vector2(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f)).normalized;
	}
}
