using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject splashPrefab;
    [SerializeField]private float jumpForce = 10f;
    private GameManager gm;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        gm = GameObject.FindObjectOfType<GameManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        rb.velocity = Vector3.up * jumpForce;

        GameObject splash = Instantiate(splashPrefab, transform.position + new Vector3(0f, -0.22f, 0f), transform.rotation * Quaternion.Euler(0, 0, Random.Range(0, 360))); 
        // -0.22 y'de spawn oluyor yere sabit kalsýn diye. z rotasyonunda rastgele dönüyor ki her splash birbirinde farklý olsun.
        splash.transform.SetParent(collision.gameObject.transform);
        // splash efektini çarptýðý yerin child objesi yapýyor yani orada kalmasýný saðlýyor.

        string materialName = collision.gameObject.GetComponent<MeshRenderer>().material.name;  
        //platformlarýn tag'e gerek kalmadan materiyal isimlerine göre iþlev yapýlýyor.

        if (materialName == "Danger Area (Instance)")
        {
            gm.GameScore(-10);
            Debug.Log("-10 points penalty. danger area.");
        }

        if (materialName == "Ending (Instance)")
        {
            Debug.Log("Game Over");        
        }
    }


}
