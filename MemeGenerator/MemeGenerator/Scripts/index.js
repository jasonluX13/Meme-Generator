(async ()=> {
    async function getMemes(){
        return await fetch('https://api.imgflip.com/get_memes');
    }

    let response = await getMemes();
    let data = await response.json();
    let memeList = data.data.memes;
    console.log(memeList);
    let memeListfull = memeList;
    let list = document.getElementById('list');
    

    async function displayMemes(){
        let imgList = memeList.map(meme => '<li><img class="meme-img" src="' + meme.url + '"/></li>');
        let innerHtml = imgList.join('');
        console.log(innerHtml);
        list.innerHTML = innerHtml;
    }

    async function filterMemes() {
        let searchCriteria = document.getElementById("filter").value;
        let result = [];
        for(let i=0;i<memeListfull.length;i++){
            
            if(memeListfull[i].name.includes(searchCriteria)) result.push(memeListfull[i]);
        }
        memeList = result;
        list.innerHTML = "";
        displayMemes(); 
    }

    async function clearFilter(){
        memeList = memeListfull;
        list.innerHTML="";
        displayMemes();
    }

    displayMemes();
    document.getElementById("Search").addEventListener("click", filterMemes);
    document.getElementById("Clear").addEventListener("click", clearFilter);



})();
