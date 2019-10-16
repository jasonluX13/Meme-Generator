const canvas = document.getElementById("canvas");
const ctx = canvas.getContext('2d');
const img = document.getElementById('template');
const width = 400;
canvas.width = width;
canvas.crossOrigin = "Anonymous";
canvas.height = width * img.height / img.width;
ctx.drawImage(img, 0, 0, canvas.width, canvas.height);
ctx.font = "20pt Verdana";

const button = document.getElementById('preview');
const form = document.getElementById('form');

function wrapText(context, text, x, y, maxWidth, lineHeight) {
    var words = text.split(' ');
    var line = '';

    for (var n = 0; n < words.length; n++) {
        var testLine = line + words[n] + ' ';
        var metrics = context.measureText(testLine);
        var testWidth = metrics.width;
        if (testWidth > maxWidth && n > 0) {
            context.fillText(line, x, y);
            line = words[n] + ' ';
            y += lineHeight;
        }
        else {
            line = testLine;
        }
    }
    context.fillText(line, x, y);
}

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
        //ctx.fillText(t.value, x, y);
        wrapText(ctx, t.value, x, y, 100, 20);
    });

});

form.addEventListener('submit', function () {
    let dataURL = canvas.toDataURL();
    let hiddenInput = document.getElementById('dataURL');
    hiddenInput.value = dataURL;
    
});