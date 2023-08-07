/* SCRIPT PARA LA INICIALIZACION DEFAULT DE LAS TABLAS */

var urlLanguage = '../lib/lang/' + urlLang
$(document).ready(function () {
    $.extend($.fn.dataTable.defaults, {
    /*$('.tabla').DataTable({*/
        //search: {
        //    search: '#',
        //},
        stateSave: true,
        //order: [
        //    [0, 'asc']
        //    //    //[4, 'desc'],
        //    //    //[5, 'desc']
        //],
        //columnDefs: [
        //    { targets: [0], visible: false },
        //    { searchable: false, targets: 0 }
        //],
        buttons: [
            //{ extend: 'copy' },
            //{ extend: 'csv' },
            //{ extend: 'excel', title: 'excel' },
            //{ extend: 'pdf', title: 'pdf' },
            //{
            //    extend: 'print',
            //    text: 'Imprimir',
            //    customize: function (win) {
            //        $(win.document.body).addClass('white-bg');
            //        $(win.document.body).css('font-size', '10px');

            //        $(win.document.body).find('table')
            //            .addClass('compact')
            //            .css('font-size', 'inherit');
            //    }
            //},
        ],
        pageLength: 10,
        lengthMenu: [
            [5, 10, 20, 25, 50, -1],
            [5, 10, 20, 25, 50, "Todos"]
        ],
        dom: "<'row'<'col-12 col-lg-2'l><'col-12 col-lg-10'f>>" + //Modifica la posicion de los botones de la tabla
            "<'row'<'col-12 col-lg-6 text-left'i><'col-12 col-lg-6 text-right'B>>" +
            "<'row'<'col-12 col-lg-12't>>" +
            "<'row'<'col-12 col-lg-12'p>>",
        language: {
            url: urlLanguage
        }
    });
});