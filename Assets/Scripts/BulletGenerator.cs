using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGenerator : MonoBehaviour
{
  [SerializeField]
  private GameObject BulletPrefab;
  
  public void startFire()
  {
    StartCoroutine("Shoot");

  }
	public void stopFire()
	{
		StopCoroutine("Shoot");

	}
  private IEnumerator Shoot()
  {
    while (true)
    {
      Instantiate(BulletPrefab, transform.position, Quaternion.identity);
      yield return new WaitForSeconds(0.1f);
    }
  }
}
