 window.onload = function () {

  var seconds = 00;
  var tens = 00;
  var appendTens = document.getElementById("tens")
  var appendSeconds = document.getElementById("seconds")
  var buttonStart = document.getElementById('button-start');
  var buttonStop = document.getElementById('button-stop');
  var buttonRestart = document.getElementById('button-restart');
  var Interval ;

  buttonStart.onclick = function() {

     clearInterval(Interval);
     Interval = setInterval(startTimer, 10);

  }
  var animateButton = function(e) {

    e.preventDefault;
    //reset animation
    e.target.classList.remove('animate');

    e.target.classList.add('animate');
    setTimeout(function(){
      e.target.classList.remove('animate');
    },700);
  };

  var bubblyButtons = document.getElementsByClassName("button-start");

  for (var i = 0; i < bubblyButtons.length; i++) {
    bubblyButtons[i].addEventListener('click', animateButton, false);
  }

    buttonStop.onclick = function() {
       clearInterval(Interval);
  }


  buttonRestart.onclick = function() {
    clearInterval(Interval);
    tens = "00";
  	seconds = "00";
    appendTens.innerHTML = tens;
  	appendSeconds.innerHTML = seconds;
  }

  function startTimer () {
    tens++;

    if(tens < 9){
      appendTens.innerHTML = "0" + tens;
    }

    if (tens > 9){
      appendTens.innerHTML = tens;
    }

    if (tens > 99) {
      console.log("seconds");
      seconds++;
      appendSeconds.innerHTML = "0" + seconds;
      tens = 0;
      appendTens.innerHTML = "0" + 0;
    }

    if (seconds > 9){
      appendSeconds.innerHTML = seconds;
    }
  }

}
