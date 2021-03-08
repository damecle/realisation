$(document).ready(function() {




//...
 var urlMusic="https:raw.githubusercontent.com/damecle/damien/master/jsonMusique.json"
 var urlTarget=urlMusic
    var buttonColorOnPress = "white";
$.getJSON(urlTarget, function(data){
    //variables
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
 //evenements
    loadSong();
    $('#prev').on('click',prevSong);
    $('#next').on('click',nextSong);
    $('#play').on('click',playSong);
    $('#repeat').on('click',toggleRepeat);
    $('#shuffle').on('click',toggleShuffle);



 //FONCTIONS
 //chargements du JSon
     function loadSong(){ //chargement du son
        $('#audioFile').attr('src',indexing.song);
            //processing(data);
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
        reset();
        timeList=[];
        previousTime=0;
        counter=0;
        clearInterval(stopTimer);
        index = (index-1)%playlist.songs.length;
        indexing = playlist.songs[index];
        $('#audioFile').attr('src',indexing.audio);
        loadSong();
    }
    function nextSong(){
        reset();
        timeList=[];
        previousTime=0;
        counter=0;
        clearInterval(stopTimer);
        index = (index+1)%playlist.songs.length;
        indexing = playlist.songs[index];
        $('#audioFile').attr('src',indexing.audio);
        loadSong(); 
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
        if(totalTime == 0 || isNaN(totalTime)){totalTime = parseInt((audio.duration * 1000));processing(data);}
        //A la fin de la chanson
        if(time >= totalTime){if(play == 0) return; playSong(); if(songRepeat == 1){ reset(); playSong(); return; }else{ nextSong(); playSong(); } return;}
        //mise a jour du timer
        if(play == 1){time = time + 1000;}
        else if(play == -1){time = 0;}
        //mise a jour du temps en fct de la progresse bar
        if(audio.currentTime != previousTime){previousTime=audio.currentTime;$('#currentTime').html(processTime(time));var percent = time/totalTime * 100;$('#progress').css("width",percent+"%");}
        else{ time = parseInt(audio.currentTime*1000);if(time>100)time=time-100;if(play==1){audio.pause();if(audio.readyState == 4){audio.play();}} }
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

})//fin URL

})
