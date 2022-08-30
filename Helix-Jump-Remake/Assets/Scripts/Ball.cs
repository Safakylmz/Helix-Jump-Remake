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
        // -0.22 y'de spawn oluyor yere sabit kals�n diye. z rotasyonunda rastgele d�n�yor ki her splash birbirinde farkl� olsun.
        splash.transform.SetParent(collision.gameObject.transform);
        // splash efektini �arpt��� yerin child objesi yap�yor yani orada kalmas�n� sa�l�yor.

        string materialName = collision.gameObject.GetComponent<MeshRenderer>().material.name;  
        //platformlar�n tag'e gerek kalmadan materiyal isimlerine g�re i�lev yap�l�yor.

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
