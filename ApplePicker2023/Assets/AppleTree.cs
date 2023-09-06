using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Inscribed")]
    // prefab for instantiating apples
    public GameObject appleprefab;
    //speed at which the apple moves
    public float speed = -10f;
    //Distance at which the AppleTree turns around
    public float leftandRightEdge = 11f;
    //chance that the apple tree will change directions
    public float changeDirChance = 0.01f;
    //seconds between Apple drops
    public float appleDropDelay = 1f;


    // Start is called before the first frame update
    void Start()
    {
        // start dropping apples
        Invoke("DropApple", 2f);
    }

    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(appleprefab);
        apple.transform.position = transform.position;
        Invoke("DropApple", appleDropDelay);
    }

    // Update is called once per frame
    void Update()
    {
        // basic movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;
        // changing direction
        if (pos.x < -leftandRightEdge)
        {
            speed = Mathf.Abs(speed); // move right
        }
        else if (pos.x > leftandRightEdge)
        {
            speed = -Mathf.Abs(speed); // move right
        } 
    }
    void FixedUpdate()
    {
        if (Random.value < changeDirChance)
        {
            speed *= -1;
        }
    }
}
