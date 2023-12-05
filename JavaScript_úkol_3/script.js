let platno = document.getElementById("platno")
let context = platno.getContext("2d")

let stredKruhuX = 100
let stredKruhuY = 100

platno.onmousemove = p

function p (event) {
    stredKruhuX = event.clientX
    stredKruhuY =  event.clientY
}

function nakresli() {
    context.clearRect(0, 0, 700, 700)
    context.beginPath()
    context.arc(stredKruhuX, stredKruhuY, 50, 0, Math.PI*2)
    context.fill()
    context.fillRect(200, 200, 50, 50)
    requestAnimationFrame(nakresli)
}

nakresli()