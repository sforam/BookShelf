var dataTable;

$(document).ready(function () {
    var url = window.location.search;
    if (url.includes("inprocess")) {
        loadDataTable("inprocess");
    }
    else {
        if (url.includes("completed")) {
            loadDataTable("completed");
        }
        else {
            if (url.includes("pending")) {
                loadDataTable("pending");
            }
            else {
                if (url.includes("approved")) {
                    loadDataTable("approved");
                }
                else {
                    loadDataTable("all");
                }
            }
        }
    }
    
});


function loadDataTable(status) {
    console.log("Loading DataTable");
    if ($.fn.DataTable.isDataTable('#tblData1')) {
        console.log("Destroying existing DataTable");
        $('#tblData1').DataTable().destroy();

        
    }


    dataTable = $('#tblData1').DataTable({
        "ajax": { url: '/admin/order/getall?status=' + status },

      "columns": [
          { data: 'id' ,"width":"5%"},
          { data: 'applicationUser.name', "width": "25%" },
          { data: 'phoneNumber', "width": "20%" },
          { data: 'applicationUser.email', "width": "20%" },
          { data: 'orderStatus', "width": "10%" },
          { data: 'orderTotal', "width": "10%" },
          {
              data: 'id',
              "render": function (data) {
                  return `<div class="w-75 btn-group" role="group">
                  <a href="/admin/order/details?orderId=${data}" class="btn btn-primary mx-2"> <i class="fa-solid fa-pen-to-square"></i>
                 
                  </a>
                 
                  </div>`
              },

              "width": "10%"
          }

        ]
    });
}



