(async ()=>{

    var upvote = document.getElementById("upvote");
    var downvote = document.getElementById('downvote');
    var votecount = document.getElementById("votes");
    var memeId = window.location.href.split("/")[5];
    async function voteup(){
        await fetch("http://localhost:53520/api/votes/"+memeId+"/add/true", {method: 'PUT'});
        getvotes();
        makeGreen();
    }

    async function votedown(){
        await fetch("http://localhost:53520/api/votes/"+memeId+"/add/false", {method: 'PUT'});
        getvotes();
        makeRed();
    }

    async function getvotes(){
        var response = await fetch("http://localhost:53520/api/votes/"+memeId+"/all");
        var votes = await response.json();
        var score = 0;
        for(var i=0; i<votes.length;i++){
            if(votes[i].UpDown) score ++;
            else score--;
        }
        votecount.innerHTML = score;
    }

    function makeRed(){
        upvote.className = "bold";
        votecount.className = "bold red";
        downvote.className = "bold red";
    }

    function makeGreen(){
        upvote.className = "bold green";
        votecount.className = "bold green";
        downvote.className = "bold";
    }

    async function setUserVoteColor(){
        var response = await fetch("http://localhost:53520/api/votes/"+ memeId);
        var vote = await response.json();
        console.log(vote);
        if(vote === null) return;
        if(vote.UpDown) makeGreen();
        else makeRed();
    }

    getvotes();
    upvote.addEventListener("click", voteup);
    downvote.addEventListener("click", votedown);
    setUserVoteColor();

})();