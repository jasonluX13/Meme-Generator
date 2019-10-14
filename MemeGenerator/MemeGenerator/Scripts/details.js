(async () => {
    const img = document.getElementById('image');
    const canvas = document.getElementById('canvas');
    const ctx = canvas.getContext('2d');

    canvas.crossOrigin = "Anonymous";
    canvas.width = 400;
    canvas.height = canvas.width * img.height / img.width;
    ctx.drawImage(img, 0, 0, canvas.width, canvas.height);
    ctx.fillStyle = "black";
    ctx.font = "20pt Verdana";

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

    let url = "http://localhost:53520/api/memes/meme/" + img.getAttribute('data-id');
    console.log(url);

    let response = await fetch(url, {
        method: 'post'
    });
    let data = await response.json();
    let textboxes = data.MemeCoordinates;
    for (let i = 0; i < textboxes.length; i++){
        let x = textboxes[i].X;
        let y = textboxes[i].Y;
        let text = textboxes[i].Text;
        //ctx.fillText(text,x,y);
        wrapText(ctx, text, x, y, 100, 20);
    }
})();
