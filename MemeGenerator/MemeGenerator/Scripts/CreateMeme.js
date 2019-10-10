const canvas = document.getElementById("canvas");
const ctx = canvas.getContext('2d');
const img = document.getElementById('template');
const width = 400;
canvas.width = width;
canvas.crossOrigin = "Anonymous";
canvas.height = width * img.height / img.width;
ctx.drawImage(img, 0, 0, canvas.width, canvas.height);
ctx.font = "24pt Verdana";

const button = document.getElementById('submit');

button.addEventListener('click', function () {
    const textbox1 = document.getElementById('textbox1');
    const textbox2 = document.getElementById('textbox2');

    ctx.clearRect(0, 0, canvas.width, canvas.height);
    ctx.drawImage(img, 0, 0, canvas.width, canvas.height);
    //refill text
    ctx.fillStyle = "black";

    ctx.fillText(textbox1.value, 300, 200);
    ctx.fillText(textbox2.value, 40, 40);

});