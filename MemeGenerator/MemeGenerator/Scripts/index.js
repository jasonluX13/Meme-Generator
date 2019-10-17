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
        let imgList = data.map(meme => '<li class = "meme"><h4>'+ meme.Title +'</h4><a href="/Meme/Details/' + meme.Id + '"><img class="meme-img"  src="/Home/RenderImage/' + meme.Id + '"/></a><div><span id="upvote" data-upvoteid="' + meme.Id + '" class="bold upvote">▲</span><span id="votes" data-voteid="'+ meme.Id +'" class = "bold votecount">0</span><span id="downvote" data-downvoteid='+meme.Id+' class="bold downvote">▼</span></div></li>');
        let innerHtml = imgList.join('');
        list.innerHTML = innerHtml;    
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

