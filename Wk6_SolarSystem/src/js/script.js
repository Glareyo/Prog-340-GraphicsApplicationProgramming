///Credits
// - https://stackoverflow.com/questions/44463634/how-to-change-color-with-three-js#:~:text=THREE.Material%20does%20some%20magic%20when%20you%20provide%20certain,change%20it%20you%20need%20to%20do%20yourMaterial.color.setRGB%20%281%2C0%2C1%29
// Explained how to change colors on a material

// - https://www.bing.com/videos/riverview/relatedvideo?q=ThreeJS+import+dat.gui&mid=3EBB511F05CE1DEFAAA33EBB511F05CE1DEFAAA3&FORM=VIRE
// Helped demonstrate how to use and add GUI

// - https://threejs.org/manual/#en/backgrounds
// Documentation Used to learn about backgrounds

//https://threejs.org/docs/#api/en/geometries/RingGeometry
    //Showed how to make the ring have two sides rather than 1


import * as THREE from "three";

// Reason for specifics ==> Import from a specifc module.
import { OrbitControls } from 'three/examples/jsm/controls/OrbitControls.js';
import { GUI } from 'dat.gui';
import bg1 from '../img/h-default-image.png';


var height = window.innerHeight;
var width = window.innerWidth;

var renderer = new THREE.WebGLRenderer();
// renderer.setClearColor("#e5e5e5");
renderer.setSize(width, height);
renderer.shadowMap = true;

document.body.appendChild(renderer.domElement);

//Create the scene
const scene = new THREE.Scene();

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
// scene.add(mySpotLight);
mySpotLight.position.set(-20, 10, 20);


const dirSpotLightHelper = new THREE.DirectionalLightHelper(mySpotLight);
// scene.add(dirSpotLightHelper);

var planetRound = 30;

var sunScale = 1;
var mercuryScale = 0.5;
var venusScale = 1;
var earthScale = 1;
var marsScale = 0.8;
var jupiterScale = 3;
var saturnScale = 2.7;
var uranusScale = 1.5;
var neptuneScale = 0.9;
var plutoScale = 0.5;

var sunPosX = 0;
var mercuryPosX = 5;
var venusPosX = 15;
var earthPosX = 20;
var marsPosX = 25;
var jupiterPosX = 30;
var saturnPosX = 35;
var uranusPosX = 40;
var neptunePosX = 45;
var plutoPosX = 50;

var sunSpinSpd = 1;
var mercurySpinSpd = 1;
var venusSpinSpd = 1;
var earthSpinSpd = 1;
var marsSpinSpd = 1;
var jupiterSpinSpd = 1;
var saturnSpinSpd = 1;
var uranusSpinSpd = 1;
var neptuneSpinSpd = 1;
var plutoSpinSpd = 1;

var mercuryRotationSpd = 9;
var venusRotationSpd = 8;
var earthRotationSpd = 7;
var marsRotationSpd = 6;
var jupiterRotationSpd = 5;
var saturnRotationSpd = 4;
var uranusRotationSpd = 3;
var neptuneRotationSpd = 2;
var plutoRotationSpd = 1;

// var sun = 0;
// var mercury = 0;
// var venus = 0;
// var earth = 0;
// var mars = 0;
// var jupiter = 0;
// var saturn = 0;
// var uranus = 0;
// var neptune = 0;
// var pluto = 0;


// Vars set for calling in animation
var mercury;
var venus;
var earth;
var mars;
var jupiter;
var saturn;
var uranus;
var neptune;
var pluto;

var saturnRing;

var mercuryObj;
var venusObj;
var earthObj;
var marsObj;
var jupiterObj;
var saturnObj;
var uranusObj;
var neptuneObj;
var plutoObj;

{//Planets

    //Sun
    const sunGeo = new THREE.SphereGeometry(sunScale, 30, planetRound);
    const sunShader = new THREE.ShaderMaterial({
        vertexShader: document.getElementById("vertexShader").textContent,
        fragmentShader: document.getElementById("sunShader").textContent,
    });
    const sun = new THREE.Mesh(sunGeo, sunShader);
    scene.add(sun);


    //Mercury
    const mercuryGeo = new THREE.SphereGeometry(mercuryScale, 30, planetRound);
    const mercuryMat = new THREE.MeshPhongMaterial({ color: '#CA8' });
    mercury = new THREE.Mesh(mercuryGeo, mercuryMat);
    mercury.receiveShadow = true;
    scene.add(mercury);
    //Object 3D Creations
    mercuryObj = new THREE.Object3D();
    mercuryObj.add(mercury);
    mercuryObj.receiveShadow = true;
    //Add 3D Objects to Scene
    scene.add(mercuryObj);

    //Venus
    const venusGeo = new THREE.SphereGeometry(venusScale, 30, planetRound);
    const venusMat = new THREE.MeshPhongMaterial({ color: '#CA8' });
    venus = new THREE.Mesh(venusGeo, venusMat);
    venus.receiveShadow = true;
    scene.add(venus);
    //Object 3D Creations
    venusObj = new THREE.Object3D();
    venusObj.add(venus);
    venusObj.receiveShadow = true;
    //Add 3D Objects to Scene
    scene.add(venusObj);

    //earth
    const earthGeo = new THREE.SphereGeometry(earthScale, 30, planetRound);
    const earthMat = new THREE.MeshPhongMaterial({ color: '#CA8' });
    earth = new THREE.Mesh(earthGeo, earthMat);
    earth.receiveShadow = true;
    scene.add(earth);
    //Object 3D Creations
    earthObj = new THREE.Object3D();
    earthObj.add(earth);
    earthObj.receiveShadow = true;
    //Add 3D Objects to Scene
    scene.add(earthObj);

    //mars
    const marsGeo = new THREE.SphereGeometry(marsScale, 30, planetRound);
    const marsMat = new THREE.MeshPhongMaterial({ color: '#CA8' });
    mars = new THREE.Mesh(marsGeo, marsMat);
    mars.receiveShadow = true;
    scene.add(mars);
    //Object 3D Creations
    marsObj = new THREE.Object3D();
    marsObj.add(mars);
    marsObj.receiveShadow = true;
    //Add 3D Objects to Scene
    scene.add(marsObj);

    //jupiter
    const jupiterGeo = new THREE.SphereGeometry(jupiterScale, 30, planetRound);
    const jupiterMat = new THREE.MeshPhongMaterial({ color: '#CA8' });
    jupiter = new THREE.Mesh(jupiterGeo, jupiterMat);
    jupiter.receiveShadow = true;
    scene.add(jupiter);
    //Object 3D Creations
    jupiterObj = new THREE.Object3D();
    jupiterObj.add(jupiter);
    jupiterObj.receiveShadow = true;
    //Add 3D Objects to Scene
    scene.add(jupiterObj);

    //saturn
    const saturnGeo = new THREE.SphereGeometry(saturnScale, 30, planetRound,);
    const saturnMat = new THREE.MeshPhongMaterial({ color: '#CA8' });
    saturn = new THREE.Mesh(saturnGeo, saturnMat);
    saturn.receiveShadow = true;
    scene.add(saturn);

    //Add Saturns Rings
    const saturnRingGeo1 = new THREE.RingGeometry(saturnScale+0.5,saturnScale+1,planetRound);
    const saturnRingGeo2 = new THREE.RingGeometry(saturnScale+1.5,saturnScale+2,planetRound);
    const saturnRingGeo3 = new THREE.RingGeometry(saturnScale+2.5,saturnScale+3,planetRound);
    //const saturnRingMat = new THREE.MeshPhongMaterial({ color: '#CA8',side:THREE.DoubleSide });
    

    //Credit
    //https://threejs.org/docs/#api/en/geometries/RingGeometry
    //Showed how to make the ring have two sides rather than 1
    const saturnRingMat = new THREE.ShaderMaterial({
        vertexShader: document.getElementById("vertexShader").textContent,
        fragmentShader: document.getElementById("saturnRingShader").textContent,
        side:THREE.DoubleSide
    });

    saturnRing1 =  new THREE.Mesh(saturnRingGeo1,saturnRingMat);
    saturnRing1.receiveShadow = true;
    scene.add(saturnRing1);
    saturnRing2 =  new THREE.Mesh(saturnRingGeo2,saturnRingMat);
    saturnRing2.receiveShadow = true;
    scene.add(saturnRing2);
    saturnRing3 =  new THREE.Mesh(saturnRingGeo3,saturnRingMat);
    saturnRing3.receiveShadow = true;
    scene.add(saturnRing3);



    //Object 3D Creations
    saturnObj = new THREE.Object3D();
    saturnObj.add(saturn);
    saturnObj.receiveShadow = true;
    //Add 3D Objects to Scene
    scene.add(saturnObj);
    saturn.add(saturnRing1);    
    saturn.add(saturnRing2);
    saturn.add(saturnRing3);

    //uranus
    const uranusGeo = new THREE.SphereGeometry(uranusScale, 30, planetRound);
    const uranusMat = new THREE.MeshPhongMaterial({ color: '#CA8' });
    uranus = new THREE.Mesh(uranusGeo, uranusMat);
    uranus.receiveShadow = true;
    scene.add(uranus);
    //Object 3D Creations
    uranusObj = new THREE.Object3D();
    uranusObj.add(uranus);
    uranusObj.receiveShadow = true;
    //Add 3D Objects to Scene
    scene.add(uranusObj);

    //neptune
    const neptuneGeo = new THREE.SphereGeometry(neptuneScale, 30, planetRound);
    const neptuneMat = new THREE.MeshPhongMaterial({ color: '#CA8' });
    neptune = new THREE.Mesh(neptuneGeo, neptuneMat);
    neptune.receiveShadow = true;
    scene.add(neptune);
    //Object 3D Creations
    neptuneObj = new THREE.Object3D();
    neptuneObj.add(neptune);
    neptuneObj.receiveShadow = true;
    //Add 3D Objects to Scene
    scene.add(neptuneObj);

    //pluto
    const plutoGeo = new THREE.SphereGeometry(plutoScale, 30, planetRound);
    const plutoMat = new THREE.MeshPhongMaterial({ color: '#CA8' });
    pluto = new THREE.Mesh(plutoGeo, plutoMat);
    pluto.receiveShadow = true;
    scene.add(pluto);
    //Object 3D Creations
    plutoObj = new THREE.Object3D();
    plutoObj.add(pluto);
    plutoObj.receiveShadow = true;
    //Add 3D Objects to Scene
    scene.add(plutoObj);




    //Credit:
    //https://discourse.threejs.org/t/parenting-meshes/48952
    // Add obj to sun
    sun.add(mercuryObj);
    sun.add(venusObj);
    sun.add(earthObj);
    sun.add(marsObj);
    sun.add(jupiterObj);
    sun.add(saturnObj);
    sun.add(uranusObj);
    sun.add(neptuneObj);
    sun.add(plutoObj);


    {//Position Setting
        sun.position.set(sunPosX, 0, 0);
        mercury.position.set(mercuryPosX, 0, 0);
        venus.position.set(venusPosX, 0, 0);
        earth.position.set(earthPosX, 0, 0);
        mars.position.set(marsPosX, 0, 0);
        jupiter.position.set(jupiterPosX, 0, 0);

        saturn.position.set(saturnPosX, 0, 0);
        saturnRing1.position.set(0, 0, 0);
        saturnRing1.rotateX(180);
        saturnRing2.position.set(0, 0, 0);
        saturnRing2.rotateX(180);
        saturnRing3.position.set(0, 0, 0);
        saturnRing3.rotateX(180);

        uranus.position.set(uranusPosX, 0, 0);
        neptune.position.set(neptunePosX, 0, 0);
        pluto.position.set(plutoPosX, 0, 0);
    }
    //Credit
    //https://threejs.org/docs/index.html#api/en/lights/PointLight
    const sunColor = 0xFFFFFF;
    const sunIntensity = 30000;
    {//Sun Light Source
        const sunLight = new THREE.PointLight(sunColor, sunIntensity);

        scene.add(sunLight);
        const sunLightObj = new THREE.Object3D();
        sunLightObj.add(sunLight);
        sun.add(sunLight);
    }
}

{// Planet Speed Self Modifiers
    mercuryRotationSpd /= 1000;
    venusRotationSpd /= 1000;
    earthRotationSpd /= 1000;
    marsRotationSpd /= 1000;
    jupiterRotationSpd /= 1000;
    saturnRotationSpd /= 1000;
    uranusRotationSpd /= 1000;
    neptuneRotationSpd /= 1000;
    plutoRotationSpd /= 1000;
}

const gui = new GUI();

function animate(time) {
    renderer.render(scene, camera);


    {// Planet Animations
        mercury.rotateY(mercurySpinSpd);
        venus.rotateY(venusSpinSpd);
        earth.rotateY(earthSpinSpd);
        mars.rotateY(marsSpinSpd);
        jupiter.rotateY(jupiterSpinSpd);
        // saturn.rotateY(saturnSpinSpd);
        uranus.rotateY(uranusSpinSpd);
        neptune.rotateY(neptuneSpinSpd);
        pluto.rotateY(plutoSpinSpd);

        mercuryObj.rotateY(mercuryRotationSpd);
        venusObj.rotateY(venusRotationSpd);
        earthObj.rotateY(earthRotationSpd);
        marsObj.rotateY(marsRotationSpd);
        jupiterObj.rotateY(jupiterRotationSpd);
        saturnObj.rotateY(saturnRotationSpd);
        uranusObj.rotateY(uranusRotationSpd);
        neptuneObj.rotateY(neptuneRotationSpd);
        plutoObj.rotateY(plutoRotationSpd);
    }




}

renderer.setAnimationLoop(animate);