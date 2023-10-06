import * as THREE from "three";

// Reason for specifics ==> Import from a specifc module.
import { OrbitControls } from 'three/examples/jsm/controls/OrbitControl.js';

var height = window.innerHeight;
var width = window.innerWidth;

const renderer = new THREE.WebGL1Renderer();

renderer.setSize(width,height);


document.body.appendChild(renderer,domElement);

//Create the scene
const scene = new THREE.Scene();

//Create the camera
const camera = new THREE.PerspectiveCamera(45,width/height,0.1,1000);
// Add the controls
const orbit = new OrbitControls(camera,renderer,docElement);

// Create axes helper
const axesHelper = new THREE.AxesHelper(3);
scene.add(axesHelper);
const gridHelper = new THREE.GridHelper(30);
scene.add(gridHelper);


// Set up the camera and update the orbit.
camera.position.set(-10,30,30);
orbit.update();

// Create the geometry and material of the box
const boxGeo = new THREE.BoxGeometry();
const boxMat = new THREE.MeshBasicMaterial({color: 0x00FF00});
const box = new THREE.Mesh(boxGeo,boxMat);
scene.add(box); // Add to Scene

const planeGeo = new THREE.BoxGeometry();
const planeMat = new THREE.MeshStandardMaterial({color: 0xFFFFFF, side:THREE.DoubleSide});
const plane = new THREE.Mesh(planeGeo,planeMat);
scene.add(plane);
plane.rotation.x = -0.5 * Math.PI;

const sphereGeo = new THREE.SphereGeometry(4,36,36);
const sphereMat = new THREE.MeshStandardMaterial({color: 0xFFFFFF, side:THREE.DoubleSide});
const sphere = new THREE.Mesh(planeGeo,planeMat);
scene.add(sphere);


// Animation function ==> blueprint that can be animated
function animate(time)
{
    box.rotation.x = time / 1000;
    box.rotation.y = time / 1000;
    renderer.render(scene,camera);
}

// Loop the animation
renderer.setAnimationLoop(animate);

