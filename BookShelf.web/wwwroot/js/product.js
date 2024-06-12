﻿$(document).ready(function () {
    loadDataTable();
});


function loadDataTable() {

    if ($.fn.DataTable.isDataTable('#tblData1')) {
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
                  <a class="btn btn-danger mx-2"> <i class="fa-solid fa-trash"></i>

                  </div>`
              }
         
          "width": "25%"

        ]
    });
}


