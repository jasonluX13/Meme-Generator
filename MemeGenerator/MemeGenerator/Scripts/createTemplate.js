const canvas = document.getElementById("canvas");
const ctx = canvas.getContext('2d');

const width = 400;
canvas.crossOrigin = "Anonymous";

ctx.fillStyle = "black";
function addText() {
    let src = document.getElementById('url').value;
    document.getElementById('image').innerHTML = '<img id="img" style="display: none" class="meme-img" src="' + src + '" />';
    //let img = document.querySelector('#img');
    let img = new Image();
    img.src = src;
    img.onload = function () {
        canvas.width = width;
        canvas.height = width * img.height / img.width;
        ctx.drawImage(img, 0, 0, canvas.width, canvas.height);

        document.getElementById('clear').style.display = '';
        canvas.removeEventListener('mousedown', getCursorPosition);
        canvas.addEventListener('mousedown', getCursorPosition);
    };
   
}


function getCursorPosition(event) {
    const rect = canvas.getBoundingClientRect()
    const textboxlist = document.getElementById('textboxes');

    const x = event.clientX - rect.left
    const y = event.clientY - rect.top
    ctx.font = "20pt Verdana";
    ctx.fillText("text", x, y);
    textboxlist.innerHTML += '<input type="text" name="coords" value="'+x+','+y +'" />'
    console.log("x: " + x + " y: " + y)
    document.getElementById('submit').disabled = false;
    document.getElementById('addTextboxes').style.display = 'none';
   
}

function clear() {
    ctx.clearRect(0, 0, canvas.width, canvas.height);
    ctx.drawImage(img, 0, 0, canvas.width, canvas.height);
    document.getElementById('textboxes').innerHTML = '';
}


document.getElementById('addTextboxes').addEventListener('click', addText);
document.getElementById('clear').addEventListener('click', clear);
