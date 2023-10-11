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
import {OrbitControls} from 'three/examples/jsm/controls/OrbitControls.js'
import {dat} from "browserslist";

// import { data } from "browserslist";

var height = window.innerHeight;
var width = window.innerWidth;

var renderer = new THREE.WebGLRenderer();
renderer.setClearColor("#e5e5e5");
renderer.setSize(width,height);

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

var light = new THREE.PointLight(0xFFFFFF,1,500);
light.position.set(10,0,25);
scene.add(light);

// Create the geometry and material of the box
const boxGeo = new THREE.BoxGeometry();
const boxMat = new THREE.MeshBasicMaterial({color: 0x00FF00});
const box = new THREE.Mesh(boxGeo,boxMat);
scene.add(box); // Add to Scene 

//Plane Object
const planeGeo = new THREE.BoxGeometry(30,30);
const planeMat = new THREE.MeshStandardMaterial({color: 0xFFFFFF, side:THREE.DoubleSide});
const plane = new THREE.Mesh(planeGeo,planeMat);
plane.receiveShadow = true; //plane can now recieve a shadow ==> Shadow will appear on the plane
scene.add(plane);
plane.rotation.x = -0.5 * Math.PI;

// Sphere object
const sphereGeo = new THREE.SphereGeometry(4,36,36); 
const sphereMat = new THREE.MeshStandardMaterial({color: 0xFFFFFF,wireframe:false});
const sphere = new THREE.Mesh(sphereGeo,sphereMat);
sphere.position.set(-10,10,0);

scene.add(sphere);


//Current problem wit gui
const gui = new dat.gui();
const guiOptions = {
    SphereColor: '#0000FF',
};
                        // SphereColor ==> must match name in the guiOptions
gui.addColor(guiOptions,'SphereColor').onChange(function(e){sphere.material.color.set(e);});

function animate(time)
{
    box.rotation.x = time / 1000;
    box.rotation.y = time / 1000;
    renderer.render(scene,camera);

}

renderer.setAnimationLoop(animate);
// var render = function(){
//     requestAnimationFrame(render);

//     renderer.render(scene,camera);
// }

// render();