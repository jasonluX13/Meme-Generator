(async ()=>{

    var commentArea = document.getElementById("commentArea");

    async function comment(){
        var commentbox = document.getElementById("commentbox");
        var commenttext = commentbox.value;
        var url = window.location.href;
        var memeId = url.split("/")[5];
        await fetch("http://localhost:53520/api/memes/meme/"+memeId+"/"+commenttext, {method: 'PATCH'});
        window.location.href = url;
    }

    if(isAuthenticated){
        commentArea.innerHTML = '<textarea id="commentbox" rows="4" cols="50"></textarea> <br/> <button id="sendcomment" class="btn btn-success">Post Comment</button>';
        document.getElementById("sendcomment").addEventListener("click", comment);

    }




})();