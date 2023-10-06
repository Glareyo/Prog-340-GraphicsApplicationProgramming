import * as THREE from "three";

// Reason for specifics ==> Import from a specifc module.
import { OrbitControls } from 'three/examples/jsm/controls/OrbitControl.js';
import { data } from "browserslist";

var height = window.innerHeight;
var width = window.innerWidth;

const renderer = new THREE.WebGLRenderer();
renderer.setSize(width,height);
renderer.shadowMap = true;

document.body.appendChild(renderer,domElement);

//Create the scene
const scene = new THREE.Scene();

//Create the camera
const camera = new THREE.PerspectiveCamera(45,width/height,0.1,1000);
// Add the controls
const orbit = new OrbitControls(camera,renderer,domElement);

//Ambient lighting
const myAmbientLight = new THREE.AmbientLight(0x334455);
scene.add(myAmbientLight);

//Directional light
const myDirectionalLight = new THREE.DirectionalLight(0xFFFFFF,0.7);
scene.add(myDirectionalLight);
myDirectionalLight.position(-20,10,0);

// Create axes helper
const axesHelper = new THREE.AxesHelper(5);
scene.add(axesHelper);
const gridHelper = new THREE.GridHelper(30);
scene.add(gridHelper);
// Helps navigate/ visually show what the light is aiming at, without rendering.
const dirLightHelper = new THREE.DirectionalLightHelper(myDirectionalLight);
scene.add(dirLightHelper);

// Set up the camera and update the orbit.
camera.position.set(-10,30,30);
orbit.update();

// Create the geometry and material of the box
const boxGeo = new THREE.BoxGeometry();
const boxMat = new THREE.MeshBasicMaterial({color: 0x00FF00});
const box = new THREE.Mesh(boxGeo,boxMat);
scene.add(box); // Add to Scene

//Plane Object
const planeGeo = new THREE.BoxGeometry();
const planeMat = new THREE.MeshStandardMaterial({color: 0xFFFFFF, side:THREE.DoubleSide});
const plane = new THREE.Mesh(planeGeo,planeMat);
scene.add(plane);
plane.rotation.x = -0.5 * Math.PI;

// Sphere object
const sphereGeo = new THREE.SphereGeometry(4,36,36); 
const sphereMat = new THREE.MeshStandardMaterial({color: 0xFFFFFF,wireframe:true});
const sphere = new THREE.Mesh(sphereGeo,sphereMat);
scene.add(sphere);
sphere.position(-10,-10,0);

const gui = new dat.Gui();
var angle = 0;

const guiOptions = {
    SphereColor: '#0000FF',
    wireFrame: true,
    speed: .02,
    angle: .02,

};
                        // SphereColor ==> must match name in the guiOptions
gui.addColor(guiOptions,'SphereColor').onChange(function(e){sphere.material.color.set(e);});
gui.add(guiOptions,'wireframe').onChange(function(e){sphere.material.wireframe = e;});

gui.add(guiOptions,'angle',0,90);
gui.add(guiOptions,'speed',0,1);

// Animation function ==> blueprint that can be animated
function animate(time)
{
    box.rotation.x = time / 1000;
    box.rotation.y = time / 1000;
    renderer.render(scene,camera);

    angle += guiOptions.speed;
    
    //Make the sphere bounce
    sphere.position.y = 10 * Math.abs(Math.sin(angle));

    renderer.render(scene,camera);
}

// Loop the animation
renderer.setAnimationLoop(animate);

