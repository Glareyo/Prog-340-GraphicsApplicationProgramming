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


import * as THREE from "three";

// Reason for specifics ==> Import from a specifc module.
import { OrbitControls } from 'three/examples/jsm/controls/OrbitControls.js';
import { GUI } from 'dat.gui';
import bg1 from '../img/h-default-image.png';

import diceOne from '../img/one.JPG';
import diceTwo from '../img/two.JPG';
import diceThree from '../img/three.JPG';
import diceFour from '../img/four.JPG';
import diceFive from '../img/five.JPG';
import diceSix from '../img/six.JPG';


var height = window.innerHeight;
var width = window.innerWidth;

var renderer = new THREE.WebGLRenderer();
// renderer.setClearColor("#e5e5e5");
renderer.setSize(width, height);

//Possible renderer.shadowMap.enabled = true;
renderer.shadowMap = true;

document.body.appendChild(renderer.domElement);

//Create the scene
const scene = new THREE.Scene();

//Credit
// https://threejs.org/manual/#en/fog
//Adding Fog
{
    const color = 'lightblue';
    // color,near,far
	scene.fog = new THREE.Fog( color, 0.1, 100 );
}


///Documentation Used to learn about backgrounds
//https://threejs.org/manual/#en/backgrounds
//Set up background
var loader = new THREE.TextureLoader();
const texture = loader.load(
    bg1,
    () => {
        texture.mapping = THREE.EquirectangularReflectionMapping;
        texture.colorSpace = THREE.SRGBColorSpace;
        scene.background = texture;
    });
// Code excerpt taken from documentation

//Another method for backgorund
{
    // const bgTexture = new THREE.TextureLoader();
    // scene.background = bgTexture.load(bg1);
}
//Cube texture background
{
    // - Set as an array ==> [image1,image2,image3,image4,image5,image6]
    // const cubeLoader = new THREE.CubeTexureLoader();
	// scene.background = cubeLoader.load([bg1,bg1,bg1,bg1,bg1,bg1])
}
	


//Create the camera
const camera = new THREE.PerspectiveCamera(45, width / height, 0.1, 1000);
const orbit = new OrbitControls(camera, renderer.domElement);

// Create axes helper
const axesHelper = new THREE.AxesHelper(6);
scene.add(axesHelper);

camera.position.set(-10, 30, 30);
orbit.update();

const mySpotLight = new THREE.SpotLight(0xFFFFFF, 0.2);
mySpotLight.castShadow = true;
scene.add(mySpotLight);
mySpotLight.position.set(-20, 10, 20);

const dirSpotLightHelper = new THREE.DirectionalLightHelper(mySpotLight);
scene.add(dirSpotLightHelper);

//Cone Geometry ==> Rotating
var coneHeight = 5;
const coneGeo = new THREE.ConeGeometry(1, coneHeight);
const coneMat = new THREE.MeshBasicMaterial(); //Possible Shadow Error ==> Change material to a MeshStandardMaterial
// OR USE MeshPhongMaterial() OR MeshStandardMaterial() ==> MeshBasicMaterial DOES NOT WORK FOR SHADOWS
// Credit
// https://threejs.org/manual/#en/shadows

https://stackoverflow.com/questions/44463634/how-to-change-color-with-three-js#:~:text=THREE.Material%20does%20some%20magic%20when%20you%20provide%20certain,change%20it%20you%20need%20to%20do%20yourMaterial.color.setRGB%20%281%2C0%2C1%29
//Explained how to change colors on a material
coneMat.color.setRGB(0.1, 0.3, 0.4);

const cone = new THREE.Mesh(coneGeo, coneMat);
cone.position.set(0, coneHeight / 2, 0);
cone.castShadow = true; //Sphere can now cast a shadow
scene.add(cone);

//Adding textures to Geos
{
    // - map:loader.load(//image) ==> Loads the texture onto the geo material

    // const box1Geo = new THREE.BoxGeometry(4,4,4);
    // const box1Mat = new THREE.MeshBasicMaterial({color: 0xFFFFFF,map:loader.load(bg1)});
    // const box1 = new THREE.Mesh(box1Geo,box1Mat);

    // - Another way to load in a texture
    // box1.material.map = loader.load(bg1);
    // box1.position.set(0,1,0);

    // - A way to customize textures on multiple sides
    // const box2Materials = [
    //     new THREE.MeshBasicMaterial({map:loader.load(diceOne)}),
    //     new THREE.MeshBasicMaterial({map:loader.load(diceTwo)}),
    //     new THREE.MeshBasicMaterial({map:loader.load(diceThree)}),
    //     new THREE.MeshBasicMaterial({map:loader.load(diceFour)}),
    //     new THREE.MeshBasicMaterial({map:loader.load(diceFive)}),
    //     new THREE.MeshStandardMaterial({map:loader.load(diceSix)}) //MeshStandard on purpose, otherwise different results may occur.
    // ]

    // const box2Geo = new THREE.BoxGeometry(4,4,4);
    // const box2 = new THREE.Mesh(box1Geo,box1Materials);
    // scene.add(box2);
}


//Cone Geometry ==> Rotating
var ringHeight = 8;
const ringGeo = new THREE.RingGeometry(4, ringHeight, 50, 4, 4, 5);
const ringMat = new THREE.MeshBasicMaterial();
https://stackoverflow.com/questions/44463634/how-to-change-color-with-three-js#:~:text=THREE.Material%20does%20some%20magic%20when%20you%20provide%20certain,change%20it%20you%20need%20to%20do%20yourMaterial.color.setRGB%20%281%2C0%2C1%29
//Explained how to change colors on a material
ringMat.color.setRGB(0.1, 0.3, 0.4);
const ring = new THREE.Mesh(ringGeo, ringMat);
ring.position.set(0, ringHeight, 0);
ring.castShadow = true; //Ring can now cast a shadow
scene.add(ring);

//Plane Object
const planeGeo = new THREE.BoxGeometry(30, 30, 0.4);
const planeMat = new THREE.MeshBasicMaterial({ color: 0xFFFFFF, side: THREE.DoubleSide });
const plane = new THREE.Mesh(planeGeo, planeMat);
planeMat.color.setRGB(0, 0.5, 0);

plane.position.set(0, 0, 0);
plane.receiveShadow = true; //plane can now recieve a shadow ==> Shadow will appear on the plane
scene.add(plane);
plane.rotation.x = -0.5 * Math.PI;




//A way to minimize code for navigation
{// GUI Controls

    //https://www.bing.com/videos/riverview/relatedvideo?q=ThreeJS+import+dat.gui&mid=3EBB511F05CE1DEFAAA33EBB511F05CE1DEFAAA3&FORM=VIRE
    //Helped demonstrate how to use and add GUI
    const gui = new GUI();
    gui.add(cone.position, "x", -10, 10, 0.1).name("Cone: X Position");
    gui.add(ring.rotation, "y", 0, 5, 0.1).name("Ring: Y Rotation");

    const guiOptions = {
        RingColor: '#0000FF',
        RingSpeed: 1,
        angle: 1,
        penumbro: 1,
        intensity: 1,
    };

    gui.addColor(guiOptions, 'RingColor').onChange(function (e) { ring.material.color.set(e); });
    gui.add(guiOptions, "angle", 0, 5, 0.1).name("Spotlight: Angle");
    gui.add(guiOptions, "penumbro", 0, 5, 0.1).name("Spotlight: Penumbro");
    gui.add(guiOptions, "intensity", 0, 5, 0.1).name("Spotlight: Intensity");
}

//Adding a ray to interact with objects
{
    // const mousePos = new THREE.Vector2();

    // window.addEventListener('mousemove',function(e){
    //     mousePos.x = (e.clientX / width) * 2 - 1;
    //     mousePos.y = (e.clientY / height) * 2 + 1;
    // });

    // const rayCaster = new THREE.Raycaster();
    // rayCaster.setFromCamera(mousePos,camera);

    // //Gets the name of the object being interacted with.
    // const intersectObj = rayCaster.intersectObjects(scene.children);
    // console.log(intersectObj);

    // // Loop
    // // Different between: == vs ===
    // for(var i = 0; i<intersectObj.length;i++)
    // {

    //     //Can use either ID or Name
    //     if (intersectObj[i].object.id === cone.id)
    //     {
    //         intersectObj[i].object.material.color.set(0xFF0000);
    //     }
    //     if (intersectObj[i].object.id === ring.name)
    //     {
    //         intersectObj[i].object.rotation.x = time/1000;
    //         intersectObj[i].object.rotation.y = time/1000;
    //     }
    // }
}




var RingSpeed = 0.1;
function animate(time) {
    cone.rotation.x = time / 1000;
    cone.rotation.z = time / 1000;
    cone.rotation.y = time / 1000;


    RingSpeed += 0.01;

    ring.position.x = -10 * Math.sin(RingSpeed);
    ring.rotation.z = -10 * Math.sin(RingSpeed);

    mySpotLight.angle = angle;
    mySpotLight.penumbra = penumbro;
    mySpotLight.intensity = intensity;

    renderer.render(scene, camera);

}

renderer.setAnimationLoop(animate);