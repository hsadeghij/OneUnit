//-----------------------------------------------Shifts------------------------------------------------------

var Shifts = []
//fetch Shifts from database
function LoadShift(element) {
    if (Shifts.length == 0) {
        //ajax function for fetch data
        $.ajax({
            type: "GET",
            url: '@Url.Action("GetShiftWithJson", "QC", new { Area = "QC" })',
            success: function (data) {
                Shifts = data;
                //render catagory
                renderShift(element);
            }
        })
    }
    else {
        //render catagory to the element
        renderShift(element);
    }
}

function renderShift(element) {
    var $ele = $(element);
    $ele.empty();
    $ele.append($('<option/>').val('0').text('Select'));
    $.each(Shifts, function (i, val) {
        $ele.append($('<option/>').val(val.Id).text(val.Name));
    })
}

//----------------------------------------------ProcessNames-----------------------------------------------------
var ProcessNames = []
//fetch ProcessName from database
function LoadProcessName(element) {
    if (ProcessNames.length == 0) {
        //ajax function for fetch data
        $.ajax({
            type: "GET",
            url: '@Url.Action("GetProcessNameWithJson", "QC", new { Area = "QC" })',
            success: function (data) {
                ProcessNames = data;
                //render catagory
                renderProcessName(element);
            }
        })
    }
    else {
        //render catagory to the element
        renderProcessName(element);
    }
}

function renderProcessName(element) {
    var $ele = $(element);
    $ele.empty();
    $ele.append($('<option/>').val('0').text('Select'));
    $.each(ProcessNames, function (i, val) {
        $ele.append($('<option/>').val(val.Id).text(val.Name));
    })
}
//---------------------------------------QParameterStatus------------------------------------------------------------
var QParameterStatuss = []
//fetch QParameterStatus from database
function LoadQParameterStatus(element) {
    if (QParameterStatuss.length == 0) {
        //ajax function for fetch data
        $.ajax({
            type: "GET",
            url: '@Url.Action("GetQParameterStatusWithJson", "QC", new { Area = "QC" })',
            success: function (data) {
                QParameterStatuss = data;
                //render catagory
                renderQParameterStatus(element);
            }
        })
    }
    else {
        //render catagory to the element
        renderQParameterStatus(element);
    }
}

function renderQParameterStatus(element) {
    var $ele = $(element);
    $ele.empty();
    $ele.append($('<option/>').val('0').text('Select'));
    $.each(QParameterStatuss, function (i, val) {
        $ele.append($('<option/>').val(val.Id).text(val.Name));
    })
}

//---------------------------------------Confirmation------------------------------------------------------------
var Confirmations = []
//fetch QParameterStatus from database
function LoadConfirmation(element) {
    if (Confirmations.length == 0) {
        //ajax function for fetch data
        $.ajax({
            type: "GET",
            url: '@Url.Action("GetConfirmationWithJson", "QC", new { Area = "QC" })',
            success: function (data) {
                Confirmations = data;
                //render catagory
                renderConfirmation(element);
            }
        })
    }
    else {
        //render catagory to the element
        renderConfirmation(element);
    }
}

function renderConfirmation(element) {
    var $ele = $(element);
    $ele.empty();
    $ele.append($('<option/>').val('0').text('Select'));
    $.each(Confirmations, function (i, val) {
        $ele.append($('<option/>').val(val.Id).text(val.Name));
    })
}
//----------------------------------------------ControlParameter--------------------------------------------------------

//fetch ControlParameter
function Load(ProcessNameDD) {
    $.ajax({
        type: "GET",
        url: '@Url.Action("GetControlParameterWithJson", "QC", new { Area = "QC" })',
        data: { 'ProcessNameID': $(ProcessNameDD).val() },
        success: function (data) {
            //render ControlParameters to appropriate dropdown
            renderControlParameter($(ProcessNameDD).parents('.mycontainer').find('select.ControlParameter'), data);
        },
        error: function (error) {
            console.log(error);
        }
    })
}

function renderControlParameter(element, data) {
    //render ControlParameter
    var $ele = $(element);
    $ele.empty();
    $ele.append($('<option/>').val('0').text('Select'));
    $.each(data, function (i, val) {
        $ele.append($('<option/>').val(val.Id).text(val.Name));
    })
}
//---------------------------------------------------------------------------

$(document).ready(function () {
    //Add button click event
    $('#add').click(function () {
        //validation and add order items
        var isAllValid = true;
        if ($('#Shift').val() == "0") {
            isAllValid = false;
            $('#Shift').siblings('span.error').css('visibility', 'visible');
        }
        else {
            $('#Shift').siblings('span.error').css('visibility', 'hidden');
        }

        if ($('#ProcessName').val() == "0") {
            isAllValid = false;
            $('#ProcessName').siblings('span.error').css('visibility', 'visible');
        }
        else {
            $('#ProcessName').siblings('span.error').css('visibility', 'hidden');
        }
        if ($('#ControlParameter').val() == "0") {
            isAllValid = false;
            $('#ControlParameter').siblings('span.error').css('visibility', 'visible');
        }
        else {
            $('#ControlParameter').siblings('span.error').css('visibility', 'hidden');
        }
        if ($('#QParameterStatus').val() == "0") {
            isAllValid = false;
            $('#QParameterStatus').siblings('span.error').css('visibility', 'visible');
        }
        else {
            $('#QParameterStatus').siblings('span.error').css('visibility', 'hidden');
        }
        if ($('#Confirmation').val() == "0") {
            isAllValid = false;
            $('#Confirmation').siblings('span.error').css('visibility', 'visible');
        }
        else {
            $('#Confirmation').siblings('span.error').css('visibility', 'hidden');
        }

        if (!($('#ValueLimit').val().trim() != '' && !isNaN($('#ValueLimit').val().trim()))) {
            isAllValid = false;
            $('#ValueLimit').siblings('span.error').css('visibility', 'visible');
        }
        else {
            $('#ValueLimit').siblings('span.error').css('visibility', 'hidden');
        }

        if (isAllValid) {
            var $newRow = $('#mainrow').clone().removeAttr('id');
            $('.Shift', $newRow).val($('#Shift').val());
            $('.ProcessName', $newRow).val($('#ProcessName').val());
            $('.ControlParameter', $newRow).val($('#ControlParameter').val());
            $('.QParameterStatus', $newRow).val($('#QParameterStatus').val());
            $('.Confirmation', $newRow).val($('#Confirmation').val());
            //Replace add button with remove button
            $('#add', $newRow).addClass('remove').val('Remove').removeClass('btn-success').addClass('btn-danger');

            //remove id attribute from new clone row
            $('#Shift,#ProcessName,#ControlParameter,#QParameterStatus,#Confirmation,#ValueLimit,#add', $newRow).removeAttr('id');
            $('span.error', $newRow).remove();
            //append clone row
            $('#orderdetailsItems').append($newRow);

            //clear select data
            $('#Shift,#ProcessName,#ControlParameter,#QParameterStatus,#Confirmation').val('0');
            $('#ValueLimit').val('');
            $('#orderItemError').empty();
        }

    })

    //remove button click event
    $('#orderdetailsItems').on('click', '.remove', function () {
        $(this).parents('tr').remove();
    });

    $('#submit').click(function () {
        var isAllValid = true;

        //validate order items
        $('#orderItemError').text('');
        var list = [];
        var errorItemCount = 0;
        $('#orderdetailsItems tbody tr').each(function (index, ele) {
            if (
                $('select.Shift', this).val() == "0" ||
                $('select.ProcessName', this).val() == "0" ||
                $('select.QParameterStatus', this).val() == "0" ||
                $('select.Confirmation', this).val() == "0" ||
                $('.ValueLimit', this).val() == "" ||
                isNaN($('.ValueLimit', this).val())
                ) {
                errorItemCount++;
                $(this).addClass('error');
            } else {
                var orderItem = {
                    ShiftId: $('select.Shift', this).val(),
                    ProcessNameId: $('select.ProcessName', this).val(),
                    ControlParameterId: $('select.ControlParameter', this).val(),
                    QParameterStatusId: $('select.QParameterStatus', this).val(),
                    ConfirmationId: $('select.Confirmation', this).val(),
                    ValueLimit: parseFloat($('.ValueLimit', this).val())
                }
                list.push(orderItem);
            }
        })

        if (errorItemCount > 0) {
            $('#orderItemError').text(errorItemCount + " invalid entry in order item list.");
            isAllValid = false;
        }

        if (list.length == 0) {
            $('#orderItemError').text('At least 1 order item required.');
            isAllValid = false;
        }


        if ($('#orderDate').val().trim() == '') {
            $('#orderDate').siblings('span.error').css('visibility', 'visible');
            isAllValid = false;
        }
        else {
            $('#orderDate').siblings('span.error').css('visibility', 'hidden');
        }

        if (isAllValid) {
            var data = {
          
                OrderDateString: $('#orderDate').val().trim(),
                OrderDetails: list
            }

            $(this).val('Please wait...');

            $.ajax({
                type: 'POST',
                url: '@Url.Action("GetProcessNameWithJson", "QC", new { Area = "QC" })',
                data: JSON.stringify(data),
                contentType: 'application/json',
                success: function (data) {
                    if (data.status) {
                        alert('Successfully saved');
                        //here we will clear the form
                        list = [];
                        $('#orderNo,#orderDate,#description').val('');
                        $('#orderdetailsItems').empty();
                    }
                    else {
                        alert('Error');
                    }
                    $('#submit').text('Save');
                },
                error: function (error) {
                    console.log(error);
                    $('#submit').text('Save');
                }
            });
        }

    });

});

LoadShift($('#Shift'));
