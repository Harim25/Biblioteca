$(document).ready(function () {
    $('#TLibros').DataTable({
        paging: true,       // Habilitar paginación
        searching: true,    // Habilitar la búsqueda
        ordering: true,     // Habilitar el ordenamiento
        responsive: true    // Opcional: tablas responsivas
    });
});