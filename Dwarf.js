 $(document).ready(function() {

var usersObj
        if (!localStorage.getItem('accounts')) {
            usersObj = {
                "users": []
            }
        } else {
            usersObj = JSON.parse(localStorage.getItem('accounts'))
        }

var favorisObj
    if (!localStorage.getItem('favoris')) {
            favorisObj = {
                "favorisSongs": []
        }
    } else {
        favorisObj = JSON.parse(localStorage.getItem('favoris'))
    	}
var playlistObj
    if (!localStorage.getItem('playlistUser')) {
            playlistObj = {
                "playlists": []
        }
    } else {
        playlistObj = JSON.parse(localStorage.getItem('playlistUser'))
        }

        if (!sessionStorage.getItem("session")) {
            $('#loginDiv').show()
            $('#wallDiv').hide()
            $('body').css('background-color', '#454343');
        } else {
            $('#wallDiv').show()
             $('#loginDiv').hide()
             $('#navbarRL').hide()
             $('body').css('background-color', 'black');
        }

 var titresTemplate = `
	 <div class="selectTitre modifTitre row g-0">
	 	<div class="containImg">
	 		<img class="modifImg" src="%img%" alt="">
	 	</div>
	 	<div class="containTxt">
		 	<h4 class="nom card-title">%name%</h4>
		 	<p class="artiste card-text">%artist%</p>
	 	</div>
	 	<div class="containLogo" data-idC="%coeurId%">
	 		<i class="far fa-heart fa-2x"></i>
	 	</div>
        <div  class="dropstart containLogoPlay">
            <a  class="dropdown-toggle" href="#" role="button" data-bs-toggle="dropdown" id="dropdownMenuLink" aria-expanded="false">
                <i class="fas fa-ellipsis-v fa-2x"></i>
            </a>
            <ul class="dropdown-menu" aria-labelledby="dropdownMenuLink">
                <li><a class="playDrop dropdown-item" href="#" >Playlist</a></li>
                <li><a class="newPlaylist dropdown-item" href="#">Nouvelle Playlist</a></li>
            </ul>
        </div>
	 </div>
		`
var titresTemplateVide = `
     <div class="selectTitre modifTitreVide row g-0">
        <div class="containImg">
            <img class="modifImg" src="%img%" alt="">
        </div>
        <div class="containTxt">
            <h4 class="nom card-title">%name%</h4>
            <p class="artiste card-text">%artist%</p>
        </div>
        <div class="containLogo">
        </div>
     </div>
        `

var playlistTemplate =`
    
        <div>
    	   <div class="favShowDis favShow playlistSize"><i class="coeur fas fa-heart fa-6x"></i></div>
        </div>
    
	`
var playlistTemplateUser =`
    
        <div class="laPlaylist" data-id='%id%'>
            <div class="playShow playlistSize">
            </div>
            <p id="nomDuPlay">%nameplay%</p>
        </div>
    
    `
var templateDrop=`
    <ul class="dropdown-menu">
        <li><a class="dropdown-item dropdown-toggle" href="#"role="button" id="dropdownMenuLink" data-bs-toggle="dropdown" aria-expanded="false">Playlist</a></li>
            <ul class="dropdown-menu" aria-labelledby="dropdownMenuLink">
                <li><a class="dropdown-item" href="#">Action</a></li>
            </ul>
        <li><a class="newPlaylist dropdown-item" href="#">Nouvelle Playlist</a></li>
    </ul>
        `
//...
//REGISTER LOGIN............

$('#loginMenu').click((event) => {
            event.preventDefault()
            displayLogin()
        })
$('#registerMenu').click((event) => {
            event.preventDefault()
            displayRegister()
        })

$('#registerForm').submit(register)

$('#loginForm').submit(login)
//navBarre............
$('.retour').click(function(){ //btn home(reload provisoire)	
	location.reload();
})
$('#exit').click(function (event) { //btn deconnection
    event.preventDefault()
    sessionStorage.removeItem('session')
    $('#wallDiv').hide()
    $('#loginDiv').show()
    $('#navbarRL').show()
    $('body').css('background-color', '#454343');
 })

//...
 var urlMusic="https://raw.githubusercontent.com/damecle/realisation/master/jsonMusiqueTemps.json"
 var urlTarget=urlMusic
 var buttonColorOnPress = "white";
$.getJSON(urlTarget, function(data){
//les variables
	var x
    var playlist = data;
    var index = 0;
    var indexing = playlist.songs[index];
    var time = 0;
    var totalTime = 0;
    var timeList = [];
    var counter = 0;
    var songRepeat = 0;
    var songShuffle = 0;
    var mute = 0;
    var stopTimer;
    var previousTime;
    var safeKill = 0;
    var play = 0;
    var audio = document.getElementById('audioFile'); //on laisse JS natif pour utiliser la fonction .play() car pas dispo en jquery
//Acceuil.......

//genere les titres
   
	for(x in playlist.songs){
		var allsongs=data.songs[x]
		generateTitre(allsongs) 
	}
    clickSearch()
    $('.containLogo').click(CoeurPleinVide)
      generateVide() //genere un titre vide à la fin pour ne pas gener avec le lecteur
//les playlists
    loadFavorito()
    showPlaylist()

    if (!JSON.parse(sessionStorage.getItem("session")).image != null) {
        $('.playlistSize').css('background-image','url(' + JSON.parse(sessionStorage.getItem("session")).image + ')');
    }
    
//la playlistFavoris
     generatePlaylistHeart()

     
//le lecteur
	//evenements
    loadSong(indexing);
     loadSongClick()
    $('#prev').on('click',prevSong);
    $('#next').on('click',nextSong);
    $('#play').on('click',playSong);
    $('#repeat').on('click',toggleRepeat);
    $('#shuffle').on('click',toggleShuffle);
   

//Favoris

    //ajout au Local storage
	$('.favShow').click(ShowFavoris) //aller dans les favoris
    $('.laPlaylist').click(function(){
        let lui=$(this)
        affichageTitrePlay(lui)
    })
//Playlist
    //playlist div
    $('#navPlay').click(function(){//navbraPlaylist
        $('#titre2').html("")
        $('.liste').empty()
        $('#player').hide()
        $('#carroussel').hide()
        $('.playlist').empty()
        showPlaylist()
        if (!JSON.parse(sessionStorage.getItem("session")).image != null) {
        $('.playlistSize').css('background-image','url(' + JSON.parse(sessionStorage.getItem("session")).image + ')');
    }
        generatePlaylistHeart()
        $('#player2').html(`
                <div class="d-grid gap-2">
                    <button type="button" class="newPlaylist btnCreat btn btn-primary" data-toggle="tooltip" data-bs-target="#exampleModal">
                     Nouvelle playlist
                    </button>
                </div>
            `)
        $('.newPlaylist').click(function(){
            $('#modalPlaylist').modal('show')
            ajoutPlayLs()
        })
        $('.laPlaylist').click(function(){
        let lui=$(this)
        affichageTitrePlay(lui)
        })
    })
    //modale

    $('.closeMod').click(function(){
        $('#modalPlaylist').modal('hide')
    })
    $('.closeMod').click(function(){
        $('#modalePlay').modal('hide')
    })
    //dropdown
    openDropdowns()



//les fcts&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
//génération
function generateTitre(songsX){ //genere les titres

	 	var texte=titresTemplate

	 	texte = texte.replace(/%img%/g,songsX.image)
	 	texte = texte.replace(/%name%/g,songsX.name)
	 	texte = texte.replace(/%artist%/g,songsX.artist)
        texte = texte.replace(/%coeurId%/g,songsX.id)
        
	 	$('.liste').append(texte)
}
function generateVide(){
    var texte=titresTemplateVide

        texte = texte.replace(/%img%/g," ")
        texte = texte.replace(/%name%/g," ")
        texte = texte.replace(/%artist%/g," ")
    $('.liste').append(texte)
}

//fonctions favoris......................................
function generatePlaylistHeart(){ //genere la playlist favoris
    var playHeart = playlistTemplate
    $('.playlist').prepend(playHeart)
}
// function generatePlaylistHeartCarrou(){
//     var playHeart = playlistTemplate
//     $('.slider').prepend(playHeart)
// }
function ShowFavoris(){ //ouvre les favoris
	$(".liste").empty()//empty
    $('#player2').hide()
    $('#player').show()
    $('#titre2').html('Favoris')
	let x
	for(x in favorisObj.favorisSongs) {
		var allFav = favorisObj.favorisSongs[x]
		generateFav(allFav)
        
	}
    generateVide()
    loadFavorito()

}


function CoeurPleinVide(){
var btnCoeur = $(this)
var unCoeur= btnCoeur.html()
var coeurPlein='<i class="fas fa-heart fa-2x"></i>'
var coeurVide='<i class="far fa-heart fa-2x"></i>'
    if (unCoeur == coeurVide) {
        btnCoeur.html('<i class="fas fa-heart fa-2x"></i>')
        ajoutFavorisLs(btnCoeur)  
    }else {
        btnCoeur.html('<i class="far fa-heart fa-2x"></i>')
    }
}
//loadFav
function loadFavorito(){
    $('.colone3').find('.selectTitre').each(function(){
            var leCoeur = $(this).find('.containLogo').html()
            var leNom = $(this).find('.nom').html()
            var lartist = $(this).find('.artiste').html()
            var coeurPlein='<i class="fas fa-heart fa-2x"></i>'
            var coeurVide='<i class="far fa-heart fa-2x"></i>'

            let x
            for(x in favorisObj.favorisSongs) {
            var allFav = favorisObj.favorisSongs[x]
                if((allFav.name == leNom) || (allFav.artist == lartist)){

                    $(this).find('.containLogo').html(coeurPlein)
                    
                }

            }
 
        })    
}
function ajoutFavorisLs(selection){ // ajout dans le LS
	var valName=selection.parent().children().first().next().children().first().text()
	var valArtist=selection.parent().children().first().next().children().last().text()
	var titre= getTitreByNameArtist(valName,valArtist)//le tableau du titre
	//let titreExist = false
    /*let x
    for (x in favorisObj.favorisSongs) {
      let actualTitre = favorisObj.favorisSongs[x]
        if (actualTitre.name == valName) {
        titreExist = true
        break;
        }
        if (titreExist) {
        }
    }*/
    var newFavoris = 
	    {
	    	name:valName,
	    	artist:valArtist,
	    	image:titre.image,
	    	son:titre.song,
	    	id:titre.id
	    }
    
    favorisObj.favorisSongs.push(newFavoris)
    saveTitre()
    
}
function generateFav(allFav){ //generation des titres
	var titreT = titresTemplate
	titreT = titreT.replace(/%name%/g,allFav.name)
	titreT = titreT.replace(/%artist%/g,allFav.artist)
	titreT = titreT.replace(/%img%/g,allFav.image)
		$('.liste').append(titreT)
}

function supprFav(element){//suppr les favoris du LS
	var monTitreSppr = element
	var valName=monTitreSppr.parent().children().first().next().children().first().text()
	let x
	for (x in favorisObj.favorisSongs){}
		var currentTitle = favorisObj.favorisSongs[x]
		if(currentTitle.name == valName)
		favorisObj.favorisSongs.splice(x,1)
		saveTitre()
}
//fonctions playlist..............................................................................................................................
 
function showPlaylist(){ //affiche toutes les playlists users
    let x
    for(x in playlistObj.playlists) {
        var allPlay = playlistObj.playlists[x]
        generatePlaylistUser(allPlay)

    }
}
// function showPlaylistCarrou(){
//     let x
//     for(x in playlistObj.playlists) {
//         var allPlay = playlistObj.playlists[x]
//         generatePlaylistUserCarrou(allPlay)

//     }
// }
function generatePlaylistUser(allPlay){ //genere la playlist User
    var playTempUsers = playlistTemplateUser
        playTempUsers = playTempUsers.replace(/%nameplay%/g,allPlay.name)
        playTempUsers = playTempUsers.replace(/%id%/g,allPlay.id)
    $('.playlist').prepend(playTempUsers)
}
// function generatePlaylistUserCarrou(allPlay){
//     var playTempUsers = playlistTemplateUser
//         playTempUsers = playTempUsers.replace(/%nameplay%/g,allPlay.name)
//         playTempUsers = playTempUsers.replace(/%id%/g,allPlay.id)
//     $('.slider').prepend(playTempUsers)
// }
function ajoutPlayLs(){ //creation playlist dans le LS
    $('#creation').click(function(){
        var valNamePlay= $('#recipient-name').val()
        if (valNamePlay == "") {
            alert("rempli ton champ")
        }else{
            let namePlayExist =false
            let x 
            for(x in playlistObj.playlists){
                let actualPlaylist = playlistObj.playlists[x]
                if (actualPlaylist.name == valNamePlay) {
                    namePlayExist = true
                    break;
                }
            }
            if (namePlayExist) {
                alert('le nom existe déja')
            }else {

                var userPlay = {
                    id: "play_" + uuidv4(),
                    auteur: JSON.parse(sessionStorage.getItem("session")).id,
                    name: valNamePlay,
                    titre: []
                }
            
                playlistObj.playlists.push(userPlay)
                savePlay()
                $('#recipient-name').val("")
                $('#modalPlaylist').modal('hide')
                $('#titre2').html("")
                $('.liste').empty()
                $('#player').hide()
                $('.playlist').empty()
                showPlaylist()
                generatePlaylistHeart()
                $('#player2').html(`
                        <div class="d-grid gap-2">
                            <button type="button" class="newPlaylist btnCreat btn btn-primary" data-toggle="tooltip" data-bs-target="#exampleModal">
                             Nouvelle playlist
                            </button>
                        </div>
                    `)
                $('.newPlaylist').click(function(){
                    $('#modalPlaylist').modal('show')
                    ajoutPlayLs()
                })
                $('.laPlaylist').click(function(){
                let lui=$(this)
                affichageTitrePlay(lui)
                })
            }
        }
    })
}
    //ajout des titres dans la playlist
    
    function ajoutTitrePlayLS(celuila,ok){ //ajout des titres playlist dans le LS

        var valName=ok.parent().children().first().next().children().first().text()
        var valArtist=ok.parent().children().first().next().children().last().text()
        var titre= getTitreByNameArtist(valName,valArtist)
        var idTitre= celuila.attr("data-id")
        console.log()


        var newtitrePlay = 
            {
                name:valName,
                artist:valArtist,
                image:titre.image,
                son:titre.song,
                id:titre.id
            }

            let x
            for (x in playlistObj.playlists){
                let actualTitre=playlistObj.playlists[x]
                if (actualTitre.id == idTitre){
                    actualTitre.titre.push(newtitrePlay)
                    savePlay()
                }
            }
    }

    function affichageTitrePlay(lui){
        $(".liste").empty()
        $('#player2').hide()
        $('#player').show()
        var idplay = lui.attr('data-id')
        let x 
        for(x in playlistObj.playlists){
            let actualTitre=playlistObj.playlists[x]
            let actTitre = actualTitre.titre
            if (actualTitre.id == idplay){
                let y
                for(y in actualTitre.titre){
                    var lesTitres = actualTitre.titre[y]
                    generateTitre(lesTitres)
                }
            }
        }
        generateVide() 
        loadFavorito()  
    }
    // fonctions playlist 3 points
    function openDropdowns(){ //fct des evenement du dropdown
        $('.containLogoPlay').click(function(){
            var cetteMus = $(this)
            $('.containLogoPlay').dropdown('hide')
            $(this).dropdown('show')
            $('.newPlaylist').click(function(){
                $('#modalPlaylist').modal('show')
                ajoutPlayLs()
            })
            $('.playDrop').click(function(){
                $('#modalePlay').modal('show')
                $('.iciPlay').empty()
                showNamePlaylist()
            
            })
            $('.nomDeLaPlay').click(function(){
                var ok = $(this)
                ajoutLSplaylist(ok,cetteMus)
            })
        })
    }
    // modalPlaylist
    function showNamePlaylist(){ //affiche tout les nom des playlists users dans la modal
    let x
    for(x in playlistObj.playlists) {
        var allPlay = playlistObj.playlists[x]
        modalplay(allPlay)
        }
    }
    function modalplay(allPlay){
    var playlistTemplate=`<a class="nomDeLaPlay dropdown-item" data-id="%id%" href="#" >%namePlaylist%</a>`
    var playTemp = playlistTemplate
        playTemp = playTemp.replace(/%namePlaylist%/g,allPlay.name)
        playTemp = playTemp.replace(/%id%/g,allPlay.id)
    $('.iciPlay').prepend(playTemp)
    }
    
function ajoutLSplaylist(ok,cetteMus){
    var cetteMuse = cetteMus 
    var celuila= ok
    ajoutTitrePlayLS(celuila, cetteMuse)
    $('#modalePlay').modal('hide')
}
 //FONCTIONS LECTEUR.................................................................
 //chargements du JSon
     function loadSong(leSon){ //chargement du son
        $('#audioFile').attr('src',leSon.song);
            processing(data);
            totalTime = NaN;
            stopTimer = setInterval(function(){
                updateTimer(data);},1000);
            
    } 
 //Boutons  
 //btn play
function playSong(){
        if(play==0){
            play = 1;
            audio.play(); //fct du js natif
            $('#menu button#play i').removeClass("fa-play");//suppr icone play
            $('#menu button#play i').addClass("fa-pause"); //ajoute icone pause
        }

        else{
            play = 0;
            audio.pause();
            $('#menu button#play i').removeClass("fa-pause");
            $('#menu button#play i').addClass("fa-play");}
}
//boutons suivant et prec
    function prevSong(){
        remiseZero()
        index = (index-1)%playlist.songs.length;
        indexing = playlist.songs[index];
        $('#audioFile').attr('src',indexing.audio);
        loadSong(indexing);
    }
    function nextSong(){
        remiseZero()
        index = (index+1)%playlist.songs.length;
        indexing = playlist.songs[index];
        $('#audioFile').attr('src',indexing.audio);
        loadSong(indexing); 
    }
//btn bonus
    function toggleRepeat(){//bouton répété
        if(songRepeat == 0){
            $('#repeat').css("color",buttonColorOnPress);
            songRepeat=1;
        }else{
            $('#repeat').css("color","grey");
            songRepeat=0;
        }}
    function toggleShuffle(){ //bouton aléatoire
            if(songShuffle == 0){
                $('#shuffle').css("color",buttonColorOnPress);
                songShuffle = 1;
            }else{
                $('#shuffle').css("color","grey");songShuffle = 0;}}
    function toggleMute(){//bouton mute
            if(mute == 0){
                mute=1;audio.volume = 0;
            }else{
                mute = 0;audio.volume = 1;
             }}
//Progress Barre
//affichage du temps de la musique
function processTime(time){ //traduit le tempss
    var minutes = parseInt(time/60000);
    var secondes = parseInt((time%60000)/1000);
    if(secondes < 10){ secondes = "0"+secondes; }
    return minutes+":"+secondes;
}
function processing(data){ //temps total situer à droite
$('#totalTime').html(processTime(totalTime));
    $('#currentTime').html(processTime(time));
    var percent = time/totalTime * 100;
    $('#progress').css("width",percent+"%");
}
function changeProgress(){ //pour modifier la barre de progress à la souris
    dragHandler = (event)=>{
        event.preventDefault;
        if(event.offsetY > 5 || event.offsetY < 1) return;
        var width = $('#progress-bar').css("width");
        var percent = parseInt(event.offsetX)/parseInt(width)*100;
         $('#progress').css("width",percent+"%");
         time = parseInt(totalTime * (percent/100));
         audio.currentTime = parseInt(time/1000);
    }
}
 function updateTimer(data){
        if(totalTime == 0 || isNaN(totalTime)){
        	totalTime = parseInt((audio.duration * 1000));processing(data);
        }
        //A la fin de la chanson
        if(time >= totalTime){
        	if(play == 0) return;
        	 playSong();
        	  if(songRepeat == 1){
        	   reset();
        	    playSong();
        	     return;
        	}else{ 
        		nextSong();
        		 playSong();
        	} return;
        }
        //mise a jour du timer
        if(play == 1){time = time + 1000;}
        else if(play == -1){time = 0;}
        //mise a jour du temps en fct de la progresse bar
        if(audio.currentTime != previousTime){
        	previousTime=audio.currentTime;
        	$('#currentTime').html(processTime(time));
        	var percent = time/totalTime * 100;
        	$('#progress').css("width",percent+"%");
        }else{ 
        	time = parseInt(audio.currentTime*1000);
        	if(time>100)time=time-100;
        	if(play==1){
        		audio.pause();
        		if(audio.readyState == 4){
        			audio.play();
        		}
        	}}
        safeKill = 0;
        while(true){
            safeKill += 1;
            if(safeKill >= 100) break;
            if(counter == 0){if(time < timeList[counter]){/*previous();*/break;}}
            if((counter == timeList.length) && (time <= timeList[counter-1])){counter--;/*previous();*/}
            if(time >= timeList[counter]){if(counter<=timeList.length){counter++;}/*next();*/}
            else if(time < timeList[counter-1]){counter--;/*previous();*/}
            else{if(play == 1 && !audio.paused && !audio.ended);break;}
        }
    }
function reset(){
        time = 0;
        audio.currentTime = 0;
}
function getTitreByNameArtist(name,artist){ //recherche le titre en fonction du nom et artist
	let i
	for(i in playlist.songs){
		var currentTitre = playlist.songs[i]
		if((currentTitre.name == name) && (currentTitre.artist == artist)){
			return currentTitre
		}
	}
	return null
}
function loadSongClick(){ //chargement du titre au click dessus
	$('.containImg').click(function(){
		var valName=$(this).parent().children().first().next().children().first().text()
		var valArtist=$(this).parent().children().first().next().children().last().text()
		var titre= getTitreByNameArtist(valName,valArtist)//le tableau du titre
		remiseZero()
		loadSong(titre)
	})
	$('.containTxt').click(function(){
		var valName=$(this).parent().children().first().next().children().first().text()
		var valArtist=$(this).parent().children().first().next().children().last().text()
		var titre= getTitreByNameArtist(valName,valArtist)//le tableau du titre
		remiseZero()
		loadSong(titre)
	})
}
function remiseZero(){ //remise à zéro du temps de la musique pour tout réaligner
	reset(); 
    timeList=[];
    previousTime=0;
    counter=0;
    clearInterval(stopTimer);
}
//barre de recherche
function clickSearch(){
    $('#searchForm').submit(recherche)
}
function recherche(event){
    event.preventDefault()
    var valSearch = $('#searchTxt').val()

        $('.colone3').find('.selectTitre').each(function(){
            var leNom = $(this).find('.nom').html()
            var lartist = $(this).find('.artiste').html()
            console.log(leNom)

            if((valSearch == leNom)||(valSearch == lartist)){
                
                $(this).show()
                
            }else {
                
                $(this).hide()
            }
            generateVide()
        })    
}


	})//fin URL
//fonctions en dehors 
//fontions register LOgin
function displayRegister() {
            $('#registerDiv').show()
            $('#loginDiv').hide()
            $('#registerMenu').parent().addClass("active")
            $('#loginMenu').parent().removeClass("active")
        }
function displayLogin() {
            $('#loginDiv').show()
            $('#registerDiv').hide()
            $('#loginMenu').parent().addClass("active")
            $('#registerMenu').parent().removeClass("active")
        }
        function register(event) {
            event.preventDefault()
            //Etape a : Récupération des champs
            var pseudo = $('#registerPseudo').val()
            var email = $('#registerEmail').val()
            var mdp = $('#registerPassword').val()
            var photo = $('#registerPhoto').val()
            //Etape b :  Verifications
            //Verification des champs vides
            if (mdp == "" || pseudo == "" || email == "") {
                alert("Tu dois remplir les champs")
            } else {
                //Verification numéro 2
                // le pseudo ou l'email ou les 2 si besoin existent ils déja dans notre [] d'utlisateurs ?
                let pseudoExist = false
                let emailExist =false
                let x
                let maRegex = new RegExp(/^(?=.*[A-Za-z])(?=.*\d)(?=.*[\&\#\-\_\+\=\@\{\}\[\]\(\)])[A-Za-z\d\&\#\-\_\+\=\@\{\}\[\]\(\)]{6,}$/g)
                for (x in usersObj.users) {
                    let actualUser = usersObj.users[x]
                    if (actualUser.pseudo == pseudo) {
                        pseudoExist = true
                        break;
                    }
                    if (actualUser.email == email) {
                        pseudoExist = true
                        break;
                    }
                }
                if ((pseudoExist) || (emailExist)) {
                    alert("pseudo ou email existe deja")

                } else { 
                    if (mdp.match(maRegex)){
                    //Etape c : création de l'objet utlisateur :
                    var user = {
                        id: uuidv4(),
                        pseudo: pseudo,
                        email: email,
                        image: photo,
                        mdp: mdp
                    }
                    //Etape d : Ajout du nouvel utilisateur dans la liste des utilisateurs
                    usersObj.users.push(user);
                    //Etape e : Sauvegarde dans le localStorage
                    saveUsers()

                    //ETAPES FACULTATIVES :
                    //On va vider les champs :
                    var pseudo = $('#registerPseudo').val("")
                    var email = $('#registerEmail').val("")
                    var mdp = $('#registerPassword').val("")
                    var photo = $('#registerPhoto').val("")
                    //on va afficher le panneau de login
                    displayLogin()
                    }else {
                        alert("le mot de passe ne correspond pas au exigences")
                    }

                }
            }
        }
function login(event) {
            event.preventDefault()
            //Etape a : Récupération des champs
            var pseudo = $('#loginPseudo').val()
            var password = $('#loginPassword').val()
            //Etape b : VERIFICATIONS  :

            // les champs sont ils tous remplis ?
            if (password == "" || pseudo == "") {
                alert("Remplis tout les champs")
            } else {
                // le pseudo existe il ? et si oui le mdp correspond il ?
                let isConnected = false
                let x
                for (x in usersObj.users) {
                    var actualUser = usersObj.users[x]
                    if ((actualUser.pseudo == pseudo) ||(actualUser.email == pseudo)) {
                        if (actualUser.mdp == password) {
                            isConnected = true
                            sessionStorage.setItem("session", JSON.stringify(actualUser))
                            break;
                        }
                    }
                }
                if (isConnected) {
                    alert("Bienvenue")

                    $('#loginDiv').hide()
                    $('#wallDiv').show()
                    $('#navbarRL').hide()
                    $('body').css('background-color', 'black');
                    location.reload();


                } else {
                    alert("Pseudo ou mot de passe erroné")
                }

            }
        }
function saveUsers() {
    localStorage.setItem('accounts', JSON.stringify(usersObj))
        }
function saveTitre(){
	localStorage.setItem('favoris', JSON.stringify(favorisObj))
}
function savePlay(){
    localStorage.setItem('playlistUser', JSON.stringify(playlistObj))
}

//four tout
        function uuidv4() {
            return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
                var r = Math.random() * 16 | 0, v = c == 'x' ? r : (r & 0x3 | 0x8);
                return v.toString(16);
            });
        }
$(window).resize(function(){
    versionSmart()
    versionSmartPay()
})
versionSmart()
versionSmartPay()

function versionSmart(){
    var largeurWindow = $(window).width()
    if (largeurWindow < 527) {
        $('span').hide()
        $('.retour').css('width','75px')
    }
}
function versionSmartPay(){
    var hauteurWindow = $(window).height()
    if (hauteurWindow < 450) {
        $('#player').css("margin-bottom","10%")
    }
}
}) //ready}


