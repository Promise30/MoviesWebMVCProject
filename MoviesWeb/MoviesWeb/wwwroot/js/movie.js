
$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/admin/movie/getall' },

        "columns": [
            { data: 'title', "width": "20%" },
            { data: 'director', "width" : "20%" },
            { data: 'releaseDate' , "width" : "20%"},
            { data: 'rating', "width": "10%" },
            { data: 'genre.name', "width": "10%" },
            {
                data: 'id',
                "render": function (data) {
                    return `<div class="m-75 btn-group" role="group">
                    <a href="/admin/movie/upsert?id=${data}" class="btn btn-primary mx-2"><i class="bi bi-pencil-square"></i>Edit</a>
                    <a href="" class="btn btn-primary mx-2"><i class="bi bi-trash-fill"></i>Delete</a>
                    
                    </div >`
                     
                },
                "width": "25%"
            }
        ]
    ]);
}


