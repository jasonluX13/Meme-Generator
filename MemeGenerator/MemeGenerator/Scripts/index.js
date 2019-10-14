(async ()=> {
    async function getMemes(){
        return await fetch('http://localhost:53520/api/memes/all');
    }

    let response = await getMemes();
    let data = await response.json();
    console.log(data);
    let memeListfull = data;
    let list = document.getElementById('list');
    

    async function displayMemes(){
        let imgList = data.map(meme => '<li><img class="meme-img" style="display:none" src="' + meme.Url + '"/><h4>'+ meme.Title +'</h4><a href="/Meme/Details/' + meme.Id + '"><canvas class="canvas" ></canvas></a></li>');
        let innerHtml = imgList.join('');
        
        list.innerHTML = innerHtml;
        console.log(list.innerHTML);
        setTimeout(displayCanvas, 0);

       
    }
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

    function displayCanvas(){

        let canvases = document.querySelectorAll('.canvas');
        let images = document.querySelectorAll('.meme-img');

        for (let i = 1; i < canvases.length; i++){
            let image = new Image();
            image.src = data[i-1].Url;
            image.onload = function () {
                let canvas = canvases[i];
                let ctx = canvas.getContext('2d');
                canvas.crossOrigin = "Anonymous";
                let img = images[i-1];

                canvas.width = 400;
                canvas.height = canvas.width * img.height / img.width;
                ctx.drawImage(image, 0, 0, canvas.width, canvas.height);
                ctx.fillStyle = "black";
                ctx.font = "20pt Verdana";

                let textboxes = data[i-1].MemeCoordinates;
                for (let j = 0; j < textboxes.length; j++){
                    let x = textboxes[j].X;
                    let y = textboxes[j].Y;
                    let text = textboxes[j].Text;
                    //ctx.fillText(text, x, y);
                    wrapText(ctx, text, x, y, 100, 20);
                }
            };
            
        }
    } 

    async function filterMemes() {
        let searchCriteria = document.getElementById("filter").value.toLowerCase();
        let result = [];
        for(let i=0;i<memeListfull.length;i++){
            console.log(i);
            if(memeListfull[i].Title.toLowerCase().includes(searchCriteria)) result.push(memeListfull[i]);
        }
        data = result;
        list.innerHTML = "";
        displayMemes(); 
        console.log(data);
    }

    async function clearFilter(){
        data = memeListfull;
        list.innerHTML="";
        displayMemes();
    }

    displayMemes();
    document.getElementById("Search").addEventListener("click", filterMemes);
    document.getElementById("Clear").addEventListener("click", clearFilter);



})();


//(async ()=> {
//    async function getMemes(){
//        return await fetch('https://api.imgflip.com/get_memes');
//    }

//    let response = await getMemes();
//    let data = await response.json();
//    let memeList = data.data.memes;
//    console.log(memeList);
//    let memeListfull = memeList;
//    let list = document.getElementById('list');
    

//    async function displayMemes(){
//        let imgList = memeList.map(meme => '<li><img class="meme-img" src="' + meme.url + '"/></li>');
//        let innerHtml = imgList.join('');
//        console.log(innerHtml);
//        list.innerHTML = innerHtml;
//    }

//    async function filterMemes() {
//        let searchCriteria = document.getElementById("filter").value.toLowerCase();
//        let result = [];
//        for(let i=0;i<memeListfull.length;i++){
            
//            if(memeListfull[i].name.toLowerCase().includes(searchCriteria)) result.push(memeListfull[i]);
//        }
//        memeList = result;
//        list.innerHTML = "";
//        displayMemes(); 
//    }

//    async function clearFilter(){
//        memeList = memeListfull;
//        list.innerHTML="";
//        displayMemes();
//    }

//    displayMemes();
//    document.getElementById("Search").addEventListener("click", filterMemes);
//    document.getElementById("Clear").addEventListener("click", clearFilter);



//})();

