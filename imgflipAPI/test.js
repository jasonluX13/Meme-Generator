(async ()=> {
    async function getMemes(){
        return await fetch('https://api.imgflip.com/get_memes');
    }

    let response = await getMemes();
    let data = await response.json();
    let memeList = data.data.memes;
    console.log(memeList);

    let list = document.getElementById('list');

    let imgList = memeList.map(meme => '<li><img class="meme-img" src="' + meme.url + '"/></li>');
    let innerHtml = imgList.join('');
    console.log(innerHtml);
    list.innerHTML = innerHtml;
})();