using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortAttack : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ScanDestroy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator ScanDestroy()
    {
        //0.3초 딜레이, 파괴 
        yield return new WaitForSeconds(0.3f);

        Destroy(this.gameObject);
    }
}
