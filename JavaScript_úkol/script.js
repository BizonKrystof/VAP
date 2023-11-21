let a = 0;
let b = 0;

let x = 1;
let nasobek = 0;
function zvysitA(){
    a++;
    console.log(a);
}
function zvysitB(){
    b++;
    console.log(b);
}
function vypsatCisla(){
    nasobek = a*b
    while (x<=nasobek) {
        console.log(x);
        x+=2;
    }
}
function resetovat() {
    a = 0;
    b = 0;
}