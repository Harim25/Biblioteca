$(document).ready(function () {
    for (let i = 0; i < 50; i++) {
        //para el estatico, esta es la plantilla
        let objeto = `
                <tr>
                    <th scope="row">${i + 1}</th>
                    <td>Chalino Sánchez</td>
                    <td><img src="../Imagenes/Prueba/Autores/Stephen King.jpg" alt="" class="rounded-circle autor"></td>
                    <td>${i + 13}</td>
                    <td><a href="vista-autor.html" type="button" class="btn btn-dark"><i class="bi bi-info-circle"></i> Info</a></td>
                    <td><a asp-controller="Administrar" asp-action="CrearEditarAutor" type="button" class="btn btn-dark"><i class="bi bi-pencil"></i> Editar</a></td>
                    <td><a type="button" class="btn btn-dark eliminar-btn" href="#" data-bs-toggle="modal" data-bs-target="#modalEliminar"><i class="bi bi-trash me-1"></i>Eliminar</a></td>
                </tr>
            `;
        $("#contenido").append(objeto)
    }
    let rowToDelete
    $("#contenido").on("click", ".eliminar-btn", function () {
        rowToDelete = $(this).closest("tr")
    });
    $("#footerEliminar .btn-danger").on("click", function () {
        if (rowToDelete) {
            rowToDelete.remove()
            rowToDelete = null
        }
    })
})