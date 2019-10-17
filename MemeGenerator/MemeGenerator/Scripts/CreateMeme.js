const canvas = document.getElementById("canvas");
const ctx = canvas.getContext('2d');
const image = document.getElementById('template');
let draw = false;
const width = 400;
canvas.width = width;
canvas.crossOrigin = "Anonymous";
let img = new Image();
img.crossOrigin = "Anonymous";
img.src = image.src;

img.onload = function () {
    canvas.height = width * img.height / img.width;
    ctx.drawImage(img, 0, 0, canvas.width, canvas.height);
    //ctx.font = "20pt Verdana";
 
    // ctx.font.fontcolor = 

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
        let size = document.getElementById('size').value;
        ctx.font = size + "pt Verdana";
        size = parseInt(size, 10);
        console.log(document.getElementById('size').value);
        ctx.fillStyle = document.getElementById('color').value;
        textboxes.forEach(t => {
            let x = parseInt(t.getAttribute('data-X'), 10);
            let y = parseInt(t.getAttribute('data-Y'), 10);
            console.log(t.value, x, y);
            //ctx.fillText(t.value, x, y);
            wrapText(ctx, t.value, x, y, 100, size);
        });

    });

    form.addEventListener('submit', function () {
        let dataURL = canvas.toDataURL();
        let hiddenInput = document.getElementById('dataURL');
        hiddenInput.value = dataURL;

    });

    //canvas.addEventListener('mousedown', function (e) {
    //    draw = true;
      
    //});

    //canvas.addEventListener('mouseup', function () {
    //    draw = false;
    //});

    //canvas.addEventListener('mousemove', function (e) {
    //    console.log(draw);
    //    if (draw === true) {

    //        let x = e.pageX - this.offsetLeft;
    //        let y = e.pageY - this.offsetTop;
    //        ctx.fillRect(x, y, 10, 10);
    //        console.log(x, y);
    //    }
    //})

    var mouse = { x: 0, y: 0 };
    var touch = { x: 0, y: 0 };
    canvas.addEventListener('mousemove', function (e) {
        mouse.x = e.pageX - this.offsetLeft;
        mouse.y = e.pageY - this.offsetTop;
    }, false);

    
    ctx.lineWidth = 3;
    ctx.lineJoin = 'round';
    ctx.lineCap = 'round';
    ctx.strokeStyle = '#00CC99';

    canvas.addEventListener('mousedown', function (e) {
        ctx.strokeStyle = document.getElementById('brush-color').value;
        ctx.lineWidth = document.getElementById('brush-size').value;

        ctx.beginPath();
        ctx.moveTo(mouse.x, mouse.y);

        canvas.addEventListener('mousemove', onPaint, false);
    }, false);

    canvas.addEventListener('mouseup', function () {
        canvas.removeEventListener('mousemove', onPaint, false);
    }, false);

    var onPaint = function () {
        ctx.lineTo(mouse.x, mouse.y);
        ctx.stroke();
    };

    canvas.addEventListener('touchstart', function (e) {
        ctx.strokeStyle = document.getElementById('brush-color').value;
        ctx.lineWidth = document.getElementById('brush-size').value;

        ctx.beginPath();
        //ctx.moveTo(touch.x, touch.y);

        canvas.addEventListener('touchmove', onPaintTouch, false);
    }, false);

    canvas.addEventListener('touchend', function () {
        canvas.removeEventListener('touchmove', onPaintTouch, false);
        console.log("touchend");
    }, false);

    canvas.addEventListener('touchmove', function (e) {
        var touches = e.touches[0];
        touch.x = touches.clientX - this.offsetLeft;
        touch.y = touches.clientY - this.offsetTop;
    }, false);

    var onPaintTouch = function () {
        ctx.lineTo(touch.x, touch.y);
        ctx.stroke();
    };

};


