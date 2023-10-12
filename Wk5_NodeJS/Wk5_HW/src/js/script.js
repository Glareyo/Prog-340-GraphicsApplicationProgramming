///Credits
// - https://stackoverflow.com/questions/44463634/how-to-change-color-with-three-js#:~:text=THREE.Material%20does%20some%20magic%20when%20you%20provide%20certain,change%20it%20you%20need%20to%20do%20yourMaterial.color.setRGB%20%281%2C0%2C1%29
// Explained how to change colors on a material

// - https://www.bing.com/videos/riverview/relatedvideo?q=ThreeJS+import+dat.gui&mid=3EBB511F05CE1DEFAAA33EBB511F05CE1DEFAAA3&FORM=VIRE
// Helped demonstrate how to use and add GUI

///Things to search online about
// - NodeJS ==> Installation
// - Adding Shadows
// - Animations
// - GUI options / UI Options

/// V Stackoverflow Links V ///

// Can't install parcel
// https://stackoverflow.com/questions/63399475/i-cant-install-parcel-with-npm

// Parcel Not Recognizing as a Command <== Maybe most important
// https://stackoverflow.com/questions/67729696/parcel-is-not-recognized-as-an-internal-or-external-command-operable-program
// - input 'npm uninstall parcel'
// - input 'npm uninstall -g parcel'
// ==> Unistalls parcels
// Input 'npm install parcel --save-dev' ==> Another way to install parcel

// Parcel Command Not Found <== Important as well.
// https://stackoverflow.com/questions/59707387/parcel-command-not-found
// - input 'npx parcel build index.html' ==> Might fix problem

/// ^ Stackoverflow Links ^ ///

import * as THREE from "three";

// Reason for specifics ==> Import from a specifc module.
import {OrbitControls} from 'three/examples/jsm/controls/OrbitControls.js';
import {GUI} from 'dat.gui';
import bg1 from '../img/h-default-image.png';

// const loader = new THREE.TextureLoader('../img/h-default-image.png');
var bgTexture = new THREE.TextureLoader().load('../img/h-default-image.png');

var height = window.innerHeight;
var width = window.innerWidth;

var renderer = new THREE.WebGLRenderer();
renderer.setClearColor("#e5e5e5");
renderer.setSize(width,height);
renderer.shadowMap = true;
// renderer.setClearColorHex( 0x000000, 1 );
// renderer.setClearColorHex( 0xffffff, 0);


document.body.appendChild(renderer.domElement);

//Create the scene
const scene = new THREE.Scene();
scene.background = bgTexture;

//Create the camera
const camera = new THREE.PerspectiveCamera(45,width/height,0.1,1000);
const orbit = new OrbitControls(camera,renderer.domElement);

// Create axes helper
const axesHelper = new THREE.AxesHelper(6);
scene.add(axesHelper);

camera.position.set(-10,30,30);
orbit.update();

// const myDirectionalLight = new THREE.DirectionalLight(0xFFFFFF,0.2);
// myDirectionalLight.castShadow = true;
// scene.add(myDirectionalLight);
// myDirectionalLight.position.set(-20,10,20);

const mySpotLight = new THREE.SpotLight(0xFFFFFF,0.2);
mySpotLight.castShadow = true;
scene.add(mySpotLight);
mySpotLight.position.set(-20,10,20);


const dirSpotLightHelper = new THREE.DirectionalLightHelper(mySpotLight);
scene.add(dirSpotLightHelper);

//Cone Geometry ==> Rotating
var coneHeight = 5;
const coneGeo = new THREE.ConeGeometry(1,coneHeight);
const coneMat = new THREE.MeshBasicMaterial();

https://stackoverflow.com/questions/44463634/how-to-change-color-with-three-js#:~:text=THREE.Material%20does%20some%20magic%20when%20you%20provide%20certain,change%20it%20you%20need%20to%20do%20yourMaterial.color.setRGB%20%281%2C0%2C1%29
//Explained how to change colors on a material
coneMat.color.setRGB(0.1,0.3,0.4);

const cone = new THREE.Mesh(coneGeo,coneMat);
cone.position.set(0,coneHeight/2,0);
cone.castShadow = true; //Sphere can now cast a shadow

scene.add(cone);



//Cone Geometry ==> Rotating
var ringHeight = 8;
const ringGeo = new THREE.RingGeometry(4,ringHeight,50,4,4,5);
const ringMat = new THREE.MeshBasicMaterial();

https://stackoverflow.com/questions/44463634/how-to-change-color-with-three-js#:~:text=THREE.Material%20does%20some%20magic%20when%20you%20provide%20certain,change%20it%20you%20need%20to%20do%20yourMaterial.color.setRGB%20%281%2C0%2C1%29
//Explained how to change colors on a material
ringMat.color.setRGB(0.1,0.3,0.4);

const ring = new THREE.Mesh(ringGeo,ringMat);
ring.position.set(0,ringHeight,0);
ring.castShadow = true; //Ring can now cast a shadow

scene.add(ring);

//Plane Object
const planeGeo = new THREE.BoxGeometry(30,30,0.4);
const planeMat = new THREE.MeshBasicMaterial({color: 0xFFFFFF, side:THREE.DoubleSide});
const plane = new THREE.Mesh(planeGeo,planeMat);
planeMat.color.setRGB(0,0.5,0);

plane.position.set(0,0,0);
plane.receiveShadow = true; //plane can now recieve a shadow ==> Shadow will appear on the plane
scene.add(plane);
plane.rotation.x = -0.5 * Math.PI;


//https://www.bing.com/videos/riverview/relatedvideo?q=ThreeJS+import+dat.gui&mid=3EBB511F05CE1DEFAAA33EBB511F05CE1DEFAAA3&FORM=VIRE
//Helped demonstrate how to use and add GUI
const gui = new GUI();
gui.add(cone.position,"x",-10,10,0.1).name("Cone: X Position");
gui.add(ring.rotation,"y",0,5,0.1).name("Ring: Y Rotation");

const guiOptions = {
    RingColor: '#0000FF',
    RingSpeed: 1,
};

gui.addColor(guiOptions,'RingColor').onChange(function(e){ring.material.color.set(e);});

var RingSpeed = 0.1;

function animate(time)
{
    cone.rotation.x = time / 1000;
    cone.rotation.z = time / 1000;
    cone.rotation.y = time / 1000;


    RingSpeed +=0.01;

    ring.position.x = -10 * Math.sin(RingSpeed);
    ring.rotation.z = -10 * Math.sin(RingSpeed);

    renderer.render(scene,camera);

}

renderer.setAnimationLoop(animate);