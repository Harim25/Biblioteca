$(document).ready(function () {
    $('#TLibros').DataTable({
        paging: true,       // Habilitar paginaci�n
        searching: true,    // Habilitar la b�squeda
        ordering: true,     // Habilitar el ordenamiento
        responsive: true    // Opcional: tablas responsivas
    });
});