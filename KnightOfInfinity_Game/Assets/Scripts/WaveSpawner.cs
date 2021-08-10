using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class WaveSpawner : MonoBehaviour {

	public enum SpawnState { SPAWNING, WAITING, COUNTING };
	public TMP_Text TimerLabel;
	public TMP_Text WaveLabel;
	public GameObject EnemyWarning;
	public int addBonusHealth;
	public int addBonusDamage;

	
	public GameObject trollobject;
	public GameObject wizardobject;

	private EnemyHealth enemytroll;
	private EnemyHealth enemywizard;
	private EnemyWizard projectile;
	private EnemyTroll hitboxdamage;

	[System.Serializable]
	public class Wave
	{
		public string name;
		public Transform enemy;
		public Transform enemy2;
		public int count;
		public float rate;
	}

	public Wave[] waves;
	private int nextWave = 0;
	private int WavesCount = 0;
	public int NextWave
	{
		get { return nextWave + 1; }
	}

	public Transform[] spawnPoints;

	public float timeBetweenWaves = 5f;
	private float waveCountdown;
	public float WaveCountdown
	{
		get { return waveCountdown; }
	}

	private float searchCountdown = 1f;

	private SpawnState state = SpawnState.COUNTING;
	public SpawnState State
	{
		get { return state; }
	}

	void Start()
	{
		enemytroll = trollobject.GetComponent<EnemyHealth>();
		enemywizard = wizardobject.GetComponent<EnemyHealth>();

		hitboxdamage = trollobject.GetComponent<EnemyTroll>();
		projectile = wizardobject.GetComponent<EnemyWizard>();
		

		if (spawnPoints.Length == 0)
		{
			Debug.LogError("No spawn points referenced.");
		}

		waveCountdown = timeBetweenWaves;
	}

	void Update()
	{

		TimerLabel.text = (int)waveCountdown+"";
		WaveLabel.text = WavesCount + "";
		if (state == SpawnState.WAITING)
		{
			if (!EnemyIsAlive())
			{
				WaveCompleted();
			}
			else
			{
				return;
			}
		}

		if (waveCountdown <= 0)
		{
			if (state != SpawnState.SPAWNING)
			{
				StartCoroutine( SpawnWave ( waves[nextWave] ) );
			}
		}
		else
		{
			waveCountdown -= Time.deltaTime;
		}
	}

	void WaveCompleted()
	{
		Debug.Log("Wave Completed!");

		state = SpawnState.COUNTING;
		waveCountdown = timeBetweenWaves;

		if (nextWave + 1 > waves.Length - 1)
		{
			nextWave = 0;
			Debug.Log("ALL WAVES COMPLETE! Looping...");
			EnemyWarning.SetActive(true);
			Invoke("EnemyUPWarning", 3.0f);
			EnemyUpgrade();
			WavesCount++;
		}
		else
		{
			WavesCount++;
			nextWave++;
		}
	}
    void EnemyUPWarning()
    {
		EnemyWarning.SetActive(false);

	}
	bool EnemyIsAlive()
	{
		searchCountdown -= Time.deltaTime;
		if (searchCountdown <= 0f)
		{
			searchCountdown = 1f;
			if (GameObject.FindGameObjectWithTag("Enemy") == null)
			{
				return false;
			}
		}
		return true;
	}

	IEnumerator SpawnWave(Wave _wave)
	{
		Debug.Log("Spawning Wave: " + _wave.name);
		state = SpawnState.SPAWNING;

		for (int i = 0; i < _wave.count; i++)
		{
			SpawnEnemy(_wave.enemy);
			SpawnEnemy(_wave.enemy2);
			yield return new WaitForSeconds( 1f/_wave.rate );
		}

		state = SpawnState.WAITING;

		yield break;
	}

	void SpawnEnemy(Transform _enemy)
	{
		Debug.Log("Spawning Enemy: " + _enemy.name);

		Transform _sp = spawnPoints[ Random.Range (0, spawnPoints.Length) ];
		Instantiate(_enemy, _sp.position, _sp.rotation);
	}
	 void EnemyUpgrade()
    {
		enemytroll.AddBonusHealth(addBonusHealth);
		projectile.Damage(addBonusDamage);
		enemywizard.AddBonusHealth(addBonusHealth);
		hitboxdamage.Damage(addBonusDamage);
	}

}
