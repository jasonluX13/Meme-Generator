(async ()=> {
    function getMemes(){
        return fetch('http://wos-meme-generator.azurewebsites.net/api/templates/all');
    }

    let response = await getMemes();
    //let data = await response.json();
    //let memeList = data.data.memes;
    let memeList = await response.json();
    let memeListFull = memeList;
    console.log(memeList);

    function displayMemes(){
        let list = document.getElementById('list');
        //let imgList = memeList.map(meme => '<li><a href="/Home/Create">'+ meme. +'<img class="meme-img" src="' + meme.url + '"/></a></li>');
        let imgList = memeList.map(meme => '<li><a href="/Home/Create/' +meme.Id+ '"><h4><br />'+meme.Title+'</h4><img class="meme-img" src= "' + meme.Url +'"/></a></li>')
        let innerHtml = imgList.join('');
        console.log(innerHtml);
        list.innerHTML = innerHtml;
    }

    function filterMemes() {
        let searchCriteria = document.getElementById("filter").value.toLowerCase();
        let result = [];
        for(let i=0;i<memeListFull.length;i++){
            
            if(memeListFull[i].Title.toLowerCase().includes(searchCriteria)) result.push(memeListFull[i]);
        }
        memeList = result;
        list.innerHTML = "";
        displayMemes(); 
    }

    function clearFilter(){
        memeList = memeListFull;
        list.innerHTML="";
        displayMemes();
    }

    displayMemes();
    document.getElementById("Search").addEventListener("click", filterMemes);
    document.getElementById("Clear").addEventListener("click", clearFilter);
})();
