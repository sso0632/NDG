using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour {

    WaitForSeconds cloudMoveDelay = new WaitForSeconds(1);

    float moveForce;

    private void OnEnable()
    {
        moveForce = Random.Range(2, 8);

        StartCoroutine(CloudAnimation());
    }
    IEnumerator CloudAnimation()
    {
        while(gameObject.activeSelf)
        {
            yield return cloudMoveDelay;

            Vector2 screenPos = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

            if (screenPos.x > transform.position.x)
            {
                Vector2 cameraMax = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
                transform.position = new Vector2(cameraMax.x, Random.Range(cameraMax.y * 0.5f, cameraMax.y));
                moveForce = Random.Range(2, 8);
            }

                transform.position += Vector3.left * Time.deltaTime * moveForce;

        }

    }



}
