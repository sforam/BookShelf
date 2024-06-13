var dataTable;

$(document).ready(function () {
    loadDataTable();
});


function loadDataTable() {
    console.log("Loading DataTable");
    if ($.fn.DataTable.isDataTable('#tblData1')) {
        console.log("Destroying existing DataTable");
        $('#tblData1').DataTable().destroy();

        
    }


  dataTable=  $('#tblData1').DataTable({
        "ajax": { url:'/admin/product/getall'},

      "columns": [
          { data: 'id' ,"width":"10%"},
          { data: 'title', "width": "25%" },
          { data: 'isbn', "width": "15%" },
          { data: 'author', "width": "10%" },
          { data: 'listPrice', "width": "15%" },
          { data: 'category.name', "width": "10%" },
          {
              data: 'id',
              "render": function (data) {
                  return `<div class="w-75 btn-group" role="group">
                  <a href="/admin/product/upsert?id=${data}" class="btn btn-primary mx-2"> <i class="fa-solid fa-pen-to-square"></i>
                 
                  </a>
                   <a onClick=Delete('/admin/product/delete/${data}') class="btn btn-danger mx-2"> <i class="fa-solid fa-trash"></i></a>
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


