﻿let datatable;

$(document).ready(function () {
    datatable = $('#DT_Load').DataTable({
        "ajax": {
            "url": "/api/book",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "name", "width": "30%" },
            { "data": "author", "width": "30%" },
            { "data": "isbn", "width": "30%" },
            {
                "data": "id", "render": function (data) {
                    return `<div class="text-center">
                                <a href="/BookList/Edit?id=${data}" class="btn btn-success text-white" style="cursor:pointer; width:100px;">
                                    Edit
                                </a>
                                <a class="btn btn-danger text-white" style="cursor:pointer; width:100px;">
                                    Delete
                                </a>
                            </div>
                        `;
                }, "width":"30%"
            }
        ],
        "language": {
            "emptyTable": "no data found"
        },
        "width": "100%"
    });
});