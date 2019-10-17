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
        let imgList = data.map(meme => '<li class = "meme"><img class="meme-img" style="display:none" src="' + meme.Url + '"/><h4>'+ meme.Title +'</h4><a href="/Meme/Details/' + meme.Id + '"><canvas class="canvas" ></canvas></a><div><span id="upvote" data-upvoteid="' + meme.Id + '" class="bold upvote">▲</span><span id="votes" data-voteid="'+ meme.Id +'" class = "bold votecount">0</span><span id="downvote" data-downvoteid='+meme.Id+' class="bold downvote">▼</span></div></li>');
        let innerHtml = imgList.join('');
        list.innerHTML = innerHtml;
        //console.log(list.innerHTML);
        setTimeout(displayCanvas, 0);

       
    }

    async function handleVoting(){
        console.log(event.target);
        if(event.target.id == "upvote"){
            let memeId = event.target.dataset.upvoteid;
            console.log(memeId);
            await fetch("http://localhost:53520/api/votes/"+memeId+"/add/true", {method: 'PUT'});
            updateVotes(memeId);
            getCurrentUserVotes();
        }
        else if(event.target.id == "downvote"){
            let memeId = event.target.dataset.downvoteid;
            console.log(memeId);
            await fetch("http://localhost:53520/api/votes/"+memeId+"/add/false", {method: 'PUT'});
            updateVotes(memeId);
            getCurrentUserVotes();
        }
    }

    function makeRed(memeId){
        var scoreDisplay = document.querySelector('[data-voteid="'+ memeId +'"]');
        var downArrow = document.querySelector('[data-downvoteid="'+memeId+'"]');
        var upArrow = document.querySelector('[data-upvoteid="'+memeId+'"]');
        scoreDisplay.classList = "bold votecount red";
        downArrow.classList = "bold votedown red";
        upArrow.classList = "bold voteup";

    }

    function makeGreen(memeId){
        var scoreDisplay = document.querySelector('[data-voteid="'+ memeId +'"]');
        var downArrow = document.querySelector('[data-downvoteid="'+memeId+'"]');
        var upArrow = document.querySelector('[data-upvoteid="'+memeId+'"]');
        
        scoreDisplay.className = "bold votecount green";
        downArrow.className = "bold votedown";
        upArrow.className = "bold voteup green";

    }


    async function updateAllVotes(){
        var response = await fetch("http://localhost:53520/api/votes/all");
        var votes = await response.json();
        for(var i=0;i<votes.length;i++){
            console.log('li[data-id="'+ votes[i].MemeId +'"]');
            var scoreField = document.querySelector('[data-voteid="'+ votes[i].MemeId +'"]');
            console.log(scoreField);
            var score = parseInt(scoreField.innerHTML);
            if(votes[i].UpDown) score++;
            else score--;
            scoreField.innerHTML = score;
        }
    }

    async function updateVotes(memeId){
        var response = await fetch("http://localhost:53520/api/votes/"+memeId+"/all");
        var votes = await response.json();
        var scoreField = document.querySelector('[data-voteid="'+ memeId +'"]');
        var score = 0;
        for(var i=0;i<votes.length;i++){
            if(votes[i].UpDown) score++;
            else score--;
        }
        scoreField.innerHTML = score; 
    }

    async function getCurrentUserVotes(){
        var response = await fetch("http://localhost:53520/api/votes/self/all");
        var userVotes = await response.json();

        var scoreDisplayElements = document.getElementsByClassName("bold");

        for(var c=0;c<scoreDisplayElements.length;c++){
            scoreDisplayElements[c].classList ="bold votecount";
        }

        for(var i=0;i<userVotes.length;i++){
            if(userVotes[i].UpDown) makeGreen(userVotes[i].MemeId);
            else makeRed(userVotes[i].MemeId);
        }
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
    updateAllVotes();
    document.getElementById("list").addEventListener("click", handleVoting);
    getCurrentUserVotes();
})();

