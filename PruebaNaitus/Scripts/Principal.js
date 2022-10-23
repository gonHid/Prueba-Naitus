function boton1() {
    const nombre = document.getElementById("t1").querySelector("h2").innerHTML;
    const desc = document.getElementById("t1").querySelector("P").innerHTML;

    localStorage.setItem("NAME", nombre);
    localStorage.setItem("DESC", desc);
    console.log("EVENTO BOTON");
    alert("nombre", nombre);
}