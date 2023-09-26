    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.SceneManagement;

    public class Ship : MonoBehaviour
    {
        public float rotationSpeed = 200f; //el public float hace q puedascambiar la velocidad de movimiento   // 5f
        public float movementSpeed = 400f;    // 5f
        public GameObject bulletPrefab;
        public GameObject LanzaMisil;

        private Rigidbody2D _rigid;

        public static int SCORE = 0;

    public static float xBlackHole, yBlackHole;


    public int poolSize = 25; // Tamaño del pool de balas
    private List<GameObject> bulletPool = new List<GameObject>();
    private int currentBulletIndex = 0;


    // Start is called before the first frame update
    void Start()
        {
            _rigid = GetComponent<Rigidbody2D>(); // inicializamos el componente para poder usarlo crea el componente como un cuerpo

            yBlackHole = Camera.main.orthographicSize+1;
            xBlackHole = (Camera.main.orthographicSize+1) * Screen.width / Screen.height;


        //creacion de las balas
        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab, Vector3.zero, Quaternion.identity);
            bullet.SetActive(false);
            bulletPool.Add(bullet);
        }


    }

    // Update is called once per frame
    void Update()
    {

        
            float thrust = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime; //para q vaya mejor el intervalo de frames  carga

            float rotation = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;


            Vector3 movemetDirection = (Vector3)transform.right;//el vector dos es igual a dn este el componenete del objeto siempre mirando a la derecha
            //si estuviera mirando la nave hacia arriba seria up
            //pa saber en q direccion nos estamos moviendo
            transform.Rotate(Vector3.forward, -rotation);
            //como ahora me va al reves para invertir la rotacion le pongo un - delante

            _rigid.AddForce(thrust * movemetDirection);//multiplico con el modulo del movimiento
            //aqui no pongo el movementSpeed porq ya estaba puesto


            var newPos = transform.position;
            if (newPos.x > xBlackHole)
                newPos.x = -xBlackHole + 1;
            else if (newPos.x < -xBlackHole)
                newPos.x = xBlackHole - 1;
            else if (newPos.y > yBlackHole)
                newPos.y = -yBlackHole + 1;
            else if (newPos.y < -yBlackHole)
                newPos.y = yBlackHole - 1;
            transform.position = newPos;


        
      

            if (Input.GetKeyDown(KeyCode.Space))
            {
                // Obtén una bala del pool
                GameObject bullet = bulletPool[currentBulletIndex];

                // Establece la posición y rotación de la bala
                bullet.transform.position = LanzaMisil.transform.position;
                bullet.transform.rotation = LanzaMisil.transform.rotation;

                // Activa la bala
                bullet.SetActive(true);

                // Incrementa el índice actual del pool
                currentBulletIndex = (currentBulletIndex + 1) % poolSize;
            }
        


    }



    
}
