var dataTable;


$(document).ready(function () {
    console.log("Document is ready");

    loadDataTable();
});


function loadDataTable() {
    console.log("Executing loadDataTable");
    const table = $('#tblData1');
    console.log("Table element:", table);

    if ($.fn.DataTable.isDataTable('#tblData1')) {
        console.log("Destroying existing DataTable");
        $('#tblData1').DataTable().destroy();


    }


    dataTable = $('#tblData1').DataTable({
        "ajax": {
            url: '/admin/company/getall',
            dataSrc: 'data'
        },

        "columns": [
            { data: 'name', "width": "25%" },
            { data: 'streetAddress', "width": "25%" },
            { data: 'city', "width": "25%" },
            { data: 'state', "width": "25%" },
            { data: 'postalCode', "width": "25%" },

            {
                data: 'id',
                "render": function (data) {
                    return `<div class="w-75 btn-group" role="group">
                  <a href="/admin/company/upsert?id=${data}" class="btn btn-primary mx-2"> <i class="fa-solid fa-pen-to-square"></i>
                 
                  </a>
                   <a onClick=Delete('/admin/company/delete/${data}') class="btn btn-danger mx-2"> <i class="fa-solid fa-trash"></i></a>
                  </div>`
                },

                "width": "25%"
            }

        ]
    });
}


function Delete(url) {
    Swal.fire({
        title: "Are you sure?",
        text: "You won't be able to revert this!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Yes, delete it!"
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    dataTable.ajax.reload();
                    Swal.fire.success(data.message);
                }
            })
        }
    });
}


