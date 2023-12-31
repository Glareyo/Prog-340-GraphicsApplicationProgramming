// https://www.youtube.com/watch?v=hdI2bqOjy3c
document.getElementById('main-form');

const btn = document.getElementById('my-btn');
const input1 = document.getElementById('input-1');
const input2 = document.getElementById('input-2');

btn.addEventListener('click',(e) => {
    console.log('clicked-mated');
    const product = document.getElementById('product-result');
    const result1 = document.getElementById('first-square-root');
    const result2 = document.getElementById('second-square-root');
    

    // https://stackoverflow.com/questions/17433557/how-to-save-user-input-into-a-variable-in-html-and-javascript
    // https://stackoverflow.com/questions/1133770/how-to-convert-a-string-to-an-integer-in-javascript
    const n1 = Number(input1.value);
    const n2 = Number(input2.value);

    // https://www.w3schools.com/js/js_htmldom_html.asp
    // https://www.w3schools.com/js/js_arithmetic.asp
    let r1 = n1 + n2;
    
    product.innerText = "";
    result1.innerText = "";
    result2.innerText = "";
    
    
    product.appendChild(document.createTextNode(n1 + n2));

    // https://www.bing.com/search?q=javascript+square+root&qs=AS&pq=javascript+square&sc=10-17&cvid=8ABF9FBD6207418AAE549B4AB66A0D1B&FORM=QBRE&sp=1&ghc=1&lq=0
    result1.appendChild(document.createTextNode(Math.sqrt(n1)));
    result2.appendChild(document.createTextNode(Math.sqrt(n2)));
});