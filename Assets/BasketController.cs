using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketController : MonoBehaviour
{
    public AudioClip appleSE;
    public AudioClip bombSE;
    AudioSource aud;
    void Start()
    {
        Application.targetFrameRate = 60;
        this.aud = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        // if (other.gameObject.tag == "Apple")
        if (other.CompareTag("Apple"))  // 教科書よりこっちの方が高速で推奨されている
        {
            Debug.Log("Appleeeeeeeeeeeeeeeeeeeeee");
            this.aud.PlayOneShot(this.appleSE);
        }
        else
        {
            Debug.Log("Bombbbbbbbbbbbbbbbbbbbbbbb");
            this.aud.PlayOneShot(this.bombSE);
        }
        Destroy(other.gameObject);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // 光線（ray）が何かしらのColliderが付与されているオブジェクト（今回はstage）にぶつかったかどうかをBooleanで返す
            // outを付けると参照渡しになり、メソッド内で初期化されることがルールになっている。（今回はPhysics.Raycastで初期化されている）
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                float x = Mathf.RoundToInt(hit.point.x);
                float z = Mathf.RoundToInt(hit.point.z);
                transform.position = new Vector3(x, 0, z);
            }
        }
    }
}
