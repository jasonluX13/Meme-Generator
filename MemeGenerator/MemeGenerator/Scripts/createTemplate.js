const canvas = document.getElementById("canvas");
const ctx = canvas.getContext('2d');

const width = 400;
canvas.crossOrigin = "Anonymous";

ctx.fillStyle = "black";
function addText() {
    let src = document.getElementById('url').value;
    document.getElementById('image').innerHTML = '<img id="img" style="display: none" class="meme-img" src="' + src + '" />';
    let img = document.getElementById('img');

    canvas.width = width;
    canvas.height = width * img.height / img.width;
    ctx.drawImage(img, 0, 0, canvas.width, canvas.height);
    document.getElementById('addTextboxes').style.display = 'none';
    document.getElementById('clear').style.display = '';
}


function getCursorPosition(canvas, event) {
    const rect = canvas.getBoundingClientRect()
    const textboxlist = document.getElementById('textboxes');

    const x = event.clientX - rect.left
    const y = event.clientY - rect.top
    ctx.font = "20pt Verdana";
    ctx.fillText("text", x, y);
    textboxlist.innerHTML += '<input type="text" name="coords" value="'+x+','+y +'" />'
    console.log("x: " + x + " y: " + y)
    document.getElementById('submit').disabled = false;
   
}

function clear() {
    ctx.clearRect(0, 0, canvas.width, canvas.height);
    ctx.drawImage(img, 0, 0, canvas.width, canvas.height);
    document.getElementById('textboxes').innerHTML = '';
}
canvas.addEventListener('mousedown', function(e) {
    getCursorPosition(canvas, e)
})
document.getElementById('addTextboxes').addEventListener('click', addText);
document.getElementById('clear').addEventListener('click', clear);