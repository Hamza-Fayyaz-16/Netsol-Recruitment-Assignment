using System;
using UnityEngine;
using Wrld;
using Wrld.Space;
public class AircraftController : MonoBehaviour {
    // Constant forward thrust from the aircraft engines.
    public float forwardThrustForce = 40.0f;

    // Turning force as a multiple of the thrust force.
    public float turnForceMultiplier = 5000.0f;

    // Maximum speed in metres / second.
    public float maxSpeed = 400.0f;
    public float rotationSpeed;

    private Vector3 controlForce;
    private Rigidbody rigidBody;

    public LatLongAltitude lla;


    //float movementSpeed = 100.0f;
    //float turnSpeed = 90.0f;
    //float movementAngle = 0.0f;

    private void Awake()
    {
        lla = new LatLongAltitude(37.795641, -122.404173, 0);
       // lla = new LatLongAltitude(37.784468, -122.401268, 0);
    }

	// Update is called once per frame
	void Update () {

        double latitude = lla.GetLatitude();
        double longitude = lla.GetLongitude();
        double altitube = lla.GetAltitude();

        lla = new LatLongAltitude((((Input.GetAxis("Vertical") + 0.1f) * forwardThrustForce) / 50000) + latitude,  //make the vertical axis forward vector dependent
            ((Input.GetAxis("Horizontal")) * turnForceMultiplier / 50000) + longitude,
            altitube);

        //print(lla);

        //movementAngle += Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime;
        //if (movementAngle > 45)
        //{
        //    movementAngle = 45;
        //}
        //var latitudeDelta = Mathf.Cos(Mathf.Deg2Rad * movementAngle) * (Input.GetAxis("Vertical")+0.1f) * movementSpeed * Time.deltaTime ;
        //var longitudeDelta = Mathf.Sin(Mathf.Deg2Rad * movementAngle) * (Input.GetAxis("Vertical") ) * movementSpeed * Time.deltaTime;

        //lla.SetLatitude(lla.GetLatitude() + (latitudeDelta * 0.00006f));
        //lla.SetLongitude(lla.GetLongitude() + (longitudeDelta * 0.00006f));

    }

    void FixedUpdate()
    {
        Api.Instance.SetOriginPoint(lla);
        

    }
}
    