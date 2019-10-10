const canvas = document.getElementById("canvas");
const ctx = canvas.getContext('2d');

const width = 400;
canvas.crossOrigin = "Anonymous";

document.getElementById('addTextboxes').addEventListener('click', function () {
    let src = document.getElementById('url').value;
    document.getElementById('image').innerHTML = '<img id="img" style="display: none" class="meme-img" src="' + src + '" />';
    let img = document.getElementById('img');

    canvas.width = width;
    canvas.height = width * img.height / img.width;
    ctx.drawImage(img, 0, 0, canvas.width, canvas.height);

});

function getCursorPosition(canvas, event) {
    const rect = canvas.getBoundingClientRect()
    const textboxlist = document.getElementById('textboxes');

    const x = event.clientX - rect.left
    const y = event.clientY - rect.top
    textboxlist.innerHTML += '<input type="text" name="coords" value="'+x+','+y +'" />'
    console.log("x: " + x + " y: " + y)
    document.getElementById('submit').disabled = false;
}

canvas.addEventListener('mousedown', function(e) {
    getCursorPosition(canvas, e)
})
