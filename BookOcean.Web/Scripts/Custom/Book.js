$(function ($) {
    var Param = {};
    //Param.Name = "";
    //Param.Email = "";
    //Param.ZipCode = "";
    $("#addFavMedi").hide();


    $("#btnStock").on('click', function () {


        $("#addFavMedi").show();


        $("#Name").val('');
        $("#UOMId").val('');




    });


    //$("#CloseStock").on('click', function () {
    //    if ($('#addFavMedi').css('display') == 'none') {

    //        $("#addFavMedi").show();

    //    }
    //    else {
    //        $("#addFavMedi").hide();

    //    }


    //});


    $(document).ready(function () {
       
        $("#btnFilter").click(function () {

            var UnitName = $("#UnitName").val();



            Param.clickBtn = true;
            // form = $('#EditForm');
            if (Drugname != "") {
                Param.UnitName = Drugname;
            }
            else {
                Param.UnitName = "";

            }




            $('#unitgrid').bootstrapTable('filterBy');
            Param.clickBtn = false;
        });

        //alert("Hello testing ");

        var reqUrl = $_BaseUrl + '/API/BookAPI/GetBooks';
        var headers = $("#token").val();
        // alert("Header1=" + headers);
        $('#grid').bootstrapTable({
            headers: headers,
            method: 'post',
            url: reqUrl,
            cache: true,
            height: 500,
            classes: 'table table-hover',
            customParams: Param,
            striped: true,
            pageNumber: 1,
            pagination: true,
            pageSize: 10,
            pageList: [5, 10, 20, 30],
            search: false,
            showColumns: true,
            //showRefresh: true,
            sidePagination: 'server',
            minimumCountColumns: 2,
            showHeader: true,
            showFilter: false,
            smartDisplay: true,
            clickToSelect: true,
            rowStyle: rowStyle,
            toolbar: '#custom-toolbar',
            columns: [
                 {
                     field: 'FavouriteMedicationId',
                     title: 'FavouriteMedicationId',
                     checkbox: false,
                     type: 'search',
                     visible: false,
                     switchable: false,
                     sortable: true,
                 },
                    {
                        field: 'BookName',
                        title: 'Unit Name',
                        checkbox: false,
                        type: 'search',
                        sortable: true,
                    },

                     {
                         field: 'Publication',
                         title: 'Status',
                         formatter: operateFormatters,
                         events: operateEvents
                     },
                      {
                          field: 'operate',
                          title: 'Actions',


                          clickToSelect: false,
                          formatter: operateFormatter,
                          events: operateEvents
                      }
            ],
            onSubmit: function () {
                var data = $('#filter-bar').bootstrapTableFilter('getData');
                console.log(data);
            },
            onLoadSuccess: function () {
                Addtitle();
            },
            onPageChange: function () {
                Addtitle();
            }
        });

        $(".columns.columns-right.btn-group.pull-right").remove()

    });



    // Edit and Delete Formattte links
    function operateFormatter(value, row, index) {
        debugger;
        if (row.IsUsed) {
            return [
                 '<a id="edit"  class="edit ml10 isAllowEdit" href="javascript:void(0)" title="Edit">',
                    '<i class="glyphicon glyphicon-edit"></i>',
                '</a>&nbsp;&nbsp;'
                //'<a id="delete" class="remove ml10 isAllowDelete" href="javascript:void(0)" title="Remove">',
                //    '<i class="glyphicon glyphicon-remove"></i>',
                //'</a>'
            ].join('');
        }




    }


    function operateFormatters(value, row, index) {

        if (row.IsActive) {

            return [
                '<a id="Activate"  class="Activate ml10 isAllowEdit" href="javascript:void(0)" title="Deactivate">',
                   '<i class="glyphicon glyphicon-ok"></i>',
               '</a>&nbsp;&nbsp;'
               //'<a id="delete" class="remove ml10 isAllowDelete" href="javascript:void(0)" title="Remove">',
               //    '<i class="glyphicon glyphicon-remove"></i>',
               //'</a>'
            ].join('');
        }
        else {
            return [
               '<a id="Activate"  class="Activate ml10 isAllowEdit" href="javascript:void(0)" title="Activate">',
                  '<i class="glyphicon glyphicon-remove"></i>',
              '</a>&nbsp;&nbsp;'
              //'<a id="delete" class="remove ml10 isAllowDelete" href="javascript:void(0)" title="Remove">',
              //    '<i class="glyphicon glyphicon-remove"></i>',
              //'</a>'
            ].join('');
        }


    }



    // Link Events Edit and Delete
    window.operateEvents = {

        'click .edit': function (e, value, row, index) {
            debugger;
            // $("#MedicationTemplateId").val(row.MedicationTemplateId);
            $.ajax({
                type: "GET",
                url: $_BaseUrl + "/DrugInfo/Drug/EditUnit",
                data: { UOMId: row.UOMId, Name: row.Name },
                success: function (data) {
                    $("#addFavMedi").empty();
                    $("#addFavMedi").html(data);
                    $("#addFavMedi").show();


                }
            });
        },

        'click .Activate': function (e, value, row, index) {
            debugger;
            BootstrapDialog.show({
                title: 'Confirmation',
                message: row.IsActive ? 'Are you sure you want to deactivate this record?' : "Are you sure you want to activate this record?",
                buttons: [{
                    label: 'Yes',
                    cssClass: 'btn-primary',
                    action: function (dialogItself) {
                        $.ajax({
                            type: "POST",
                            url: $_BaseUrl + "/DrugInfo/Drug/ChangeStatus",
                            data: row,
                            success: function (resultdata) {


                                RefreshGrid();
                                dialogItself.close();

                            },
                            //error: function (jqXHR, textStatus, errorThrown) {
                            //    if (jqXHR.status === 400) {
                            //         BootstrapDialog.show({
                            //             message: 'You are not authorized to do this action.',
                            //             buttons: [{
                            //                 label: 'Ok',
                            //                 cssClass: 'btn-primary',
                            //                 action: function (dialogItself) {

                            //                     location.href = $_redirecturl;
                            //                 }
                            //             }]
                            //         });
                            //     }
                            //},
                            headers: {
                                'RequestVerificationToken': $("#TokenValue").val()//'@TokenHeaderValue()'
                            }
                        });
                    }
                }, {
                    label: 'No',
                    cssClass: 'btn-danger',
                    action: function (dialogItself) {
                        dialogItself.close();
                    }
                }]
            });

        }
    };




    //for row styling 
    function rowStyle(row, index) {
        var classes = ['active', '', 'info', 'warning', 'danger'];

        if (index % 2 === 0) {
            return {
                classes: classes[1]
            };
        }
        return {};
    }
    //for adding titls -next,first,last,previos to paging
    function Addtitle() {
        $('.page-next').attr('Title', 'Next');
        $('.page-first').attr('Title', 'First');
        $('.page-last').attr('Title', 'Last');
        $('.page-pre').attr('Title', 'Previous');
    }


    $("#Name").on("keydown", function (e) {
        return e.which !== 32;
    });
    $("#Email").on("keydown", function (e) {
        return e.which !== 32;
    });
    $("#CellNumber").on("keydown", function (e) {
        return e.which !== 32;
    });
});

function AddNew() {
    $("#AddModal").modal('show');
    //$('#FormPharmacy').focus_first();
}


function RefreshGrid() {
    $('#unitgrid').bootstrapTable('refresh', { silent: true });

}
function AddUnitSuccess(data) {


    $("#unitgrid").bootstrapTable('refresh');
    $("#addFavMedi").hide();

    $("#Name").val('');
    $("#UOMId").val('');




}
function EditPharmacySuccess(data) {
    //alert(data.Addstatus);
    if (data.editstatus == true) {
        //alert(data);
        $("#EditModal").modal('hide');
        $(".modal-backdrop").hide();
        $("#EditModal").hide();
        $("#grid").bootstrapTable('refresh');
        RefreshGrid();
    }
}

function Close() {
    if ($('#addFavMedi').css('display') == 'none') {

        $("#addFavMedi").show();

    }
    else {
        $("#addFavMedi").hide();

    }
}

function GetSigDesc(item) {
    debugger;

    var Sig = "Take";

    if ($(item).hasClass("numberCircle")) {
        debugger;
        $(item).siblings(".numberCircle").removeClass("selectedItem");
    }

    if ($(item).hasClass("medicineForm")) {
        $(item).siblings(".medicineForm").removeClass("selectedItem");
    }

    if ($(item).hasClass("medicineTake")) {
        $(item).siblings(".medicineTake").removeClass("selectedItem");
    }
    if ($(item).hasClass("medicineTime")) {
        $(item).siblings(".medicineTime").removeClass("selectedItem");
    }

    $(item).addClass("selectedItem");
    debugger;
    $(".selectedItem").each(function (i, items) {
        Sig += ' ' + $(items).attr('title');
    })

    $("#SigDescription").val(Sig);
}


function validate() {
    var temp = true;
    if (!CheckRequired($("#SearchDrug"), "Required field.")) {
        temp = false;
    }
    else if (!CheckRequired($("#SigDescription"), "Required field.")) {
        temp = false;
    }

    return temp;
}

