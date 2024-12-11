using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private float movementSpeed = 2f;
    private float width = 0.2f;
    private float height = 0.2f;
    private int pierce = 1;
    
    private bool isFriendly;

    private LogicManagerScript logicManager;

    void Start()
    {
        logicManager = GameObject.Find("LogicManager").GetComponent<LogicManagerScript>();
        StartCoroutine(SelfDestruct());
    }

    void Update() {
        transform.position += transform.up * movementSpeed * Time.deltaTime;
    }

    public void updateValues(float newSpeed, float newWidth, float newHeight, int newPierce) {
        movementSpeed = newSpeed;

        Vector3 localScale = this.gameObject.transform.localScale;
        localScale.x = newWidth;
        localScale.y = newHeight;
        this.gameObject.transform.localScale = localScale;

        pierce = newPierce;
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.GetComponent<ShipScript>() != null && !isFriendly) {
            destroyObject(col);
        } else if (col.gameObject.GetComponent<EnemyScript>() != null && isFriendly) {
            destroyObject(col);
        }
    }

    public void setFriendly(bool isFriend) {
        isFriendly = isFriend;
    }

    private void destroyObject(Collider2D col) {
        int points = col.gameObject.GetComponent<EnemyScript>().getScoreValue();
        logicManager.updateScore(points);

        Object.Destroy(col.gameObject);

        if (pierce > 1) {
            pierce--;
        } else {
            Destroy(gameObject);
        }
    }

    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
