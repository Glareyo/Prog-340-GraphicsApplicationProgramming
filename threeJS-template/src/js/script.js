///Credits
// - https://stackoverflow.com/questions/44463634/how-to-change-color-with-three-js#:~:text=THREE.Material%20does%20some%20magic%20when%20you%20provide%20certain,change%20it%20you%20need%20to%20do%20yourMaterial.color.setRGB%20%281%2C0%2C1%29
// Explained how to change colors on a material

// - https://www.bing.com/videos/riverview/relatedvideo?q=ThreeJS+import+dat.gui&mid=3EBB511F05CE1DEFAAA33EBB511F05CE1DEFAAA3&FORM=VIRE
// Helped demonstrate how to use and add GUI

// - https://threejs.org/manual/#en/backgrounds
// Documentation Used to learn about backgrounds



///Things to search online about
// - NodeJS ==> Installation
// - Adding Shadows
// - Animations
// - GUI options / UI Options



// DISPLAY TO SCREEN
// Terminal => type 'parcel src/index.html

import * as THREE from "three";

// Reason for specifics ==> Import from a specifc module.
import {OrbitControls} from 'three/examples/jsm/controls/OrbitControls.js';
import {GUI} from 'dat.gui';
import bg1 from '../img/h-default-image.png';


var height = window.innerHeight;
var width = window.innerWidth;

var renderer = new THREE.WebGLRenderer();
// renderer.setClearColor("#e5e5e5");
renderer.setSize(width,height);
renderer.shadowMap = true;

document.body.appendChild(renderer.domElement);

//Create the scene
const scene = new THREE.Scene();

//Create the camera
const camera = new THREE.PerspectiveCamera(45,width/height,0.1,1000);
const orbit = new OrbitControls(camera,renderer.domElement);

// Create axes helper
const axesHelper = new THREE.AxesHelper(6);
scene.add(axesHelper);

camera.position.set(-10,30,30);
orbit.update();

const mySpotLight = new THREE.SpotLight(0xFFFFFF,0.2);
mySpotLight.castShadow = true;
scene.add(mySpotLight);
mySpotLight.position.set(-20,10,20);


const dirSpotLightHelper = new THREE.DirectionalLightHelper(mySpotLight);
scene.add(dirSpotLightHelper);


//Plane Object
const planeGeo = new THREE.BoxGeometry(30,30,0.4);
const planeMat = new THREE.MeshBasicMaterial({color: 0xFFFFFF, side:THREE.DoubleSide});
const plane = new THREE.Mesh(planeGeo,planeMat);
planeMat.color.setRGB(0,0.5,0);

plane.position.set(0,0,0);
plane.receiveShadow = true; //plane can now recieve a shadow ==> Shadow will appear on the plane
scene.add(plane);
plane.rotation.x = -0.5 * Math.PI;


const gui = new GUI();

function animate(time)
{
    renderer.render(scene,camera);

}

renderer.setAnimationLoop(animate);