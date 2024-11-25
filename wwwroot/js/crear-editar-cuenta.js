document.getElementById("Input_Imagen").addEventListener("input", function (event) {
    const imageUrl = event.target.value;
    const imgElement = document.getElementById("usuarioImage");
    imgElement.src = imageUrl || "/images/perfil-default.png";
});

document.getElementById("usuarioImage").addEventListener("error", function () {
    this.src = "/images/perfil-default.png"; // Imagen por defecto
});