$(document).ready(function () {
    for (let i = 0; i < 8; i++) {
        //para el estatico, esta es la plantilla
        let libro = `
                <div class="card">
                    <a asp-controller="LibroLector" asp-action="Details" asp-route-id="@item.Id" type="button" class="card-link">
                        <img class="card-img-top libro" src="@Html.DisplayFor(modelItem => item.Imagen)" alt="" />
                    </a>
                    <div class="card-body">
                        <h5 class="card-title">Los ojos de mona</h5>
                    </div>
                </div>
            `;
        $("#libros").append(libro)
    }
    for (let i = 0; i < 7; i++) {
        //para el estatico, esta es la plantilla
        let autor = `
                <div class="card border-0">
                    <a href="" class="card-link">
                        <img src="../Imagenes/Prueba/Autores/Stephen King.jpg" class="card-img-top rounded-circle" alt="...">
                    </a>
                    <div class="card-body">
                        <h5 class="card-title text-center">Stephen King</h5>
                    </div>
                </div>
            `;
        $("#autores").append(autor)
    }
})