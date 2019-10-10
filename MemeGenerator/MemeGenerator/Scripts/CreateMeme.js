const canvas = document.getElementById("canvas");
const ctx = canvas.getContext('2d');
const img = document.getElementById('template');
const width = 400;
canvas.width = width;
canvas.crossOrigin = "Anonymous";
canvas.height = width * img.height / img.width;
ctx.drawImage(img, 0, 0, canvas.width, canvas.height);
ctx.font = "20pt Verdana";

const button = document.getElementById('submit');

button.addEventListener('click', function () {
    const textboxes = document.querySelectorAll('.textbox');

    ctx.clearRect(0, 0, canvas.width, canvas.height);
    ctx.drawImage(img, 0, 0, canvas.width, canvas.height);
    //refill text
    ctx.fillStyle = "black";
    textboxes.forEach(t => {
        let x = parseInt(t.getAttribute('data-X'), 10);
        let y = parseInt(t.getAttribute('data-Y'), 10);
        console.log(t.value, x, y);
        ctx.fillText(t.value, x, y);
    });

});