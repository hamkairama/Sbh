
function RefreshChatBox() {
    var txtWaCode = null;
    $.ajax({
        url: fullOrigin + '/Chatting/GetListChatBox/',
        type: 'Post',
        data: { WaCode: txtWaCode },
        success: function (result) {
            console.log(result);
            var table = $('#tbl_BankCode').DataTable({
                destroy: true,
                orderCellsTop: true,
                // "searching": false,
                //"bFilter": false,
                data: result,

                columns: [
                 {
                     "render": function (data, type, full, meta) {

                         return "<a href='" + fullOrigin + "/BankCode/Edit?Id=" + full.BankCode + "' target='_top' class='ace-icon fa fa-pencil bigger-130'></a> <a href='" + fullOrigin + "/BankCode/Delete?Id=" + full.BankCode + "' class='ace-icon fa fa-trash-o bigger-130' target='_top'></a>"
                     }
                 },

                { data: "BankCode" },
                { data: "BiBankCode" },
                { data: "BankName" },
                { data: "BankDesc" },
                { data: "BankState" }

                ]
            })


            $('#tbl_BankCode thead tr:eq(1) th').each(function () {
                var title = $('#tbl_BankCode thead tr:eq(0) th').eq($(this).index()).text();
                $(this).html('<input type="text" style="width:100%" placeholder="Search ' + title + '" />');
            });

            table.columns().every(function (index) {
                $('#tbl_BankCode thead tr:eq(1) th:eq(' + index + ') input').on('keyup change', function () {
                    table.column($(this).parent().index() + ':visible')
                        .search(this.value)
                        .draw();
                });
            });

            /*
            **Restore state column filters this dont' work now!
            **/
            //var state = table.state.loaded();
            //if (state) {
            //    table.columns().eq(0).each(function (colIdx) {
            //        var colSearch = state.columns[colIdx].search;

            //        if (colSearch.search) {
            //            $('input', table.column(colIdx).footer()).val(colSearch.search);
            //        }
            //    });

            //    table.draw();
            //}


        }
    })
}